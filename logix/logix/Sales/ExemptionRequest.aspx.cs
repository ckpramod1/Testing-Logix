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

namespace logix.Sales
{
    public partial class ExemptionRequest : System.Web.UI.Page
    {
        //string strtrantype = (string)HttpContext.Current.Session["StrTranType"];
        //string strtrantype;
        DataAccess.LogDetails logobj = new DataAccess.LogDetails();
        DataAccess.ForwardingExports.BLPrinting FEBLPrinti = new DataAccess.ForwardingExports.BLPrinting();
        DataAccess.ForwardingImports.BLDetails FIBLobj = new DataAccess.ForwardingImports.BLDetails();
        DataAccess.AirImportExports.AIEJobInfo AEJobobj = new DataAccess.AirImportExports.AIEJobInfo();
        DataAccess.AirImportExports.AIEBLDetails AEBLobj = new DataAccess.AirImportExports.AIEBLDetails();
        DataAccess.CustomHousingAgent.JobInfo CHAobj = new DataAccess.CustomHousingAgent.JobInfo();
        DataAccess.CreditException Crexobj = new DataAccess.CreditException();
        DataAccess.Masters.MasterEmployee empobj = new DataAccess.Masters.MasterEmployee();
        DataAccess.Corporate Corpobj = new DataAccess.Corporate();
        DataAccess.HR.Employee hrempobj = new DataAccess.HR.Employee();
        DataAccess.Masters.MasterBranch BrObj = new DataAccess.Masters.MasterBranch();
        DataAccess.Masters.MasterCustomerGroup obj_da_Customer = new DataAccess.Masters.MasterCustomerGroup();

        DataTable DtCE = new DataTable();
        DataTable dt2 = new DataTable();
        DataTable dtinv = new DataTable();
        DataTable DtBL = new DataTable();
        DataTable DtExBL = new DataTable();
        int branchid;
        string trantype;
        string salesperson;
        int intcustid;
        Boolean BlnExist;
        int invbid;
        int invouno;
        DateTime invoudate;
        string invttype;
        string invblno;
        int invodays;
        string voutype;
        string invcname;
        double invamount;
        int i;
        int outstddays;
        double outstdamt;
        int reqby;
        DateTime bldate;
        string sendqry, strtrantype;
        double D, amount;
        string Trantype;
        int grdbid;
        string grdttype;
        double camt;
        int bid;
        int index;
        DataTable dt_MenuRights = new DataTable();
        int divisionid;
        protected void Page_Load(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "SpanTagMoveInputBottom();MuiTextField();", true);


            string Ccode = Convert.ToString(Session["Ccode"]);

            if (Ccode != "")
            {

                FEBLPrinti.GetDataBase(Ccode);
                FIBLobj.GetDataBase(Ccode);
                AEJobobj.GetDataBase(Ccode);
                AEBLobj.GetDataBase(Ccode);
                CHAobj.GetDataBase(Ccode);
                Crexobj.GetDataBase(Ccode);
                empobj.GetDataBase(Ccode);


                Corpobj.GetDataBase(Ccode);
                hrempobj.GetDataBase(Ccode);
                BrObj.GetDataBase(Ccode);
                obj_da_Customer.GetDataBase(Ccode);
                logobj.GetDataBase(Ccode);




            }

            if (Session["LoginUserName"] == null || Session["LoginEmpId"] == null || Session["LoginDivisionId"] == null || Session["LoginBranchid"] == null)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alertify.alert('Session TimeOut');window.open('"+ Session["Site"].ToString() + "/','_top');", true);
            }
            //else if (Session["StrTranType"] == null)
            //{
            //    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alertify.alert('Session TimeOut');window.open('"+ Session["Site"].ToString() + "/FormMain.aspx','_top');", true);
            //}

            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(btn_Back);
            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(txt_bl);


            if (ddl_product.Text != "" && ddl_product.Text != "0")
            {
              btn_Back.Text = "Cancel";

                btn_Back.ToolTip = "Cancel";
                btn_cancel1.Attributes["class"] = "btn ico-cancel";

                //if (Session["StrTranType"].ToString() == "FE")
                //{
                //    lblEx1.Visible = true;
                //    lblEx2.Visible = true;
                //    HeaderLabel1.InnerText = "OceanExports";
                //    headerlabel2.InnerText = "Sales";
                //}
                //else if (Session["StrTranType"].ToString() == "FI")
                //{
                //    lblEx1.Visible = true;
                //    lblEx2.Visible = true;
                //    HeaderLabel1.InnerText = "OceanImports";
                //    headerlabel2.InnerText = "Sales";
                //}
                //else if (Session["StrTranType"].ToString() == "AE")
                //{
                //    lblEx1.Visible = true;
                //    lblEx2.Visible = true;
                //    HeaderLabel1.InnerText = "AirExports";
                //    headerlabel2.InnerText = "Sales";
                //}
                //else if (Session["StrTranType"].ToString() == "AI")
                //{
                //    lblEx1.Visible = true;
                //    lblEx2.Visible = true;
                //    HeaderLabel1.InnerText = "AirImports";
                //    headerlabel2.InnerText = "Sales";
                //}
                //else if (Session["StrTranType"].ToString() == "CO")
                //{
                //    lblEx1.Visible = true;
                //    lblEx2.Visible = true;
                //    HeaderLabel1.InnerText = "Credit Control";
                //    headerlabel2.InnerText = "Credit";
                //}

                if (ddl_product.Text == "Ocean Exports")
                {
                    Session["StrTranType"] = "FE";
                    lblEx1.Visible = true;
                    lblEx2.Visible = true;
                    HeaderLabel1.InnerText = "OceanExports";
                    headerlabel2.InnerText = "Sales";
                }
                else if (ddl_product.Text == "Ocean Imports")
                {
                    Session["StrTranType"] = "FI";
                    lblEx1.Visible = true;
                    lblEx2.Visible = true;
                    HeaderLabel1.InnerText = "OceanImports";
                    headerlabel2.InnerText = "Sales";
                }
                else if (ddl_product.Text == "Air Exports")
                {
                    Session["StrTranType"] = "AE";
                    lblEx1.Visible = true;
                    lblEx2.Visible = true;
                    HeaderLabel1.InnerText = "AirExports";
                    headerlabel2.InnerText = "Sales";
                }
                else if (ddl_product.Text == "Air Imports")
                {
                    Session["StrTranType"] = "AI";
                    lblEx1.Visible = true;
                    lblEx2.Visible = true;
                    HeaderLabel1.InnerText = "AirImports";
                    headerlabel2.InnerText = "Sales";
                }
                //else if (Session["StrTranType"].ToString() == "Credit Control")
                //{
                //    Session["StrTranType"] = "MI";
                //    lblEx1.Visible = true;
                //    lblEx2.Visible = true;
                //    HeaderLabel1.InnerText = "Credit Control";
                //    headerlabel2.InnerText = "Credit";
                //}
                if (Request.QueryString.ToString().Contains("mis"))
                {
                    //breadcrumbs.Visible = false;
                    crumbsid.Attributes["class"] = "crumbs1";
                    btn_Back.Enabled = false;
                    btn_save.Enabled = false;

                }
                // if (Session["LoginBranchName"].ToString() =="CO")

                strtrantype = Session["StrTranType"].ToString();
                if (strtrantype == "CO")
                {
                    Load_Credit();
                }
                else
                {
                    getmodule();
                }
            }

            if (!IsPostBack)
            {
                lblEx1.Visible = false;
                lblEx2.Visible = false;
                if (Session["trantype_process"] != null)
                {
                    dt_MenuRights = Session["trantype_process"] as DataTable;
                    ddl_product.Items.Add("");
                    for (int i = 0; i < dt_MenuRights.Rows.Count; i++)
                    {
                        if (dt_MenuRights.Rows[i]["trantype"].ToString() == "FE")
                        {
                            ddl_product.Items.Add("Ocean Exports");
                        }
                        else if (dt_MenuRights.Rows[i]["trantype"].ToString() == "FI")
                        {
                            ddl_product.Items.Add("Ocean Imports");
                        }
                        else if (dt_MenuRights.Rows[i]["trantype"].ToString() == "AE")
                        {
                            ddl_product.Items.Add("Air Exports");
                        }
                        else if (dt_MenuRights.Rows[i]["trantype"].ToString() == "AI")
                        {
                            ddl_product.Items.Add("Air Imports");
                        }
                    }
                    // Session["StrTranType"] = dt_MenuRights.Rows[i]["modulename"].ToString();
                }
                if (Session["LoginEmpName"]!=null)
                {
                    txt_req.Text = Session["LoginEmpName"].ToString();
                }
              
                // lbl_appro.Visible = false;
                txt_appro.Visible = true;
                //Label1.Visible = false;
                // TextBox1.Visible = true;
                DateTime date = logobj.GetDate();
                txt_reqdate.Text = Utility.fn_ConvertDate(date.ToShortDateString());
                if(Session["LoginDivisionId"]!=null)
                {
                    divisionid = Convert.ToInt32(Session["LoginDivisionId"].ToString());
                }
                 
                grd.DataSource = new DataTable();
                grd.DataBind();
                GrdExe.DataSource = new DataTable();
                GrdExe.DataBind();

            }

        }
        protected void Load_Credit()
        {
            //DataAccess.LogDetails Logobj = new DataAccess.LogDetails();
            //DataAccess.Corporate objcorp = new DataAccess.Corporate();
            DataTable dtempty = new DataTable();
            DataTable dtcell = new DataTable();
            int did = Convert.ToInt32(HttpContext.Current.Session["LoginDivisionid"].ToString());

            dtcell = Crexobj.GetDetails4Grd(did);
            if (dtcell.Rows.Count > 0)
            {
                this.popupQuot.Show();
                //intcustid = ("customerid");
                dtempty.Columns.Add("branch");
                dtempty.Columns.Add("docno");
                dtempty.Columns.Add("reqby");
                dtempty.Columns.Add("customer");
                dtempty.Columns.Add("creditamt");
                dtempty.Columns.Add("creditdays");
                dtempty.Columns.Add("bid");
                dtempty.Columns.Add("trantype");
                DataRow dr = dtempty.NewRow();

                for (int i = 0; i <= dtcell.Rows.Count - 1; i++)
                {
                    double temp2 = 0;
                    int count = dtempty.Rows.Count;
                    dtempty.Rows.Add();
                    dr = dtempty.NewRow();

                    dtempty.Rows[count]["branch"] = dtcell.Rows[i]["branch"].ToString(); ;
                    dtempty.Rows[count]["docno"] = dtcell.Rows[i]["docno"].ToString();
                    dtempty.Rows[count]["reqby"] = dtcell.Rows[i]["reqby"].ToString();
                    dtempty.Rows[count]["customer"] = dtcell.Rows[i]["customer"].ToString();
                    temp2 = Convert.ToDouble(dtcell.Rows[i]["creditamt"].ToString());
                    dtempty.Rows[count]["creditamt"] = temp2.ToString("#,0.00");
                    dtempty.Rows[count]["creditdays"] = dtcell.Rows[i]["creditdays"].ToString();
                    dtempty.Rows[count]["bid"] = dtcell.Rows[i]["bid"].ToString();
                    dtempty.Rows[count]["trantype"] = dtcell.Rows[i]["trantype"].ToString();


                }

                creditgrd.DataSource = dtempty;
                creditgrd.DataBind();
            }

        }

        protected void Load_fillData()
        {

            if (strtrantype == "CO")
            {

                bid = grdbid;
                Trantype = grdttype;

            }
            else
            {
                int bid = Convert.ToInt32(HttpContext.Current.Session["LoginBranchid"].ToString());
                Trantype = Session["StrTranType"].ToString();
            }

            DataTable dtinv = new DataTable();
            dtinv = FEBLPrinti.GetBLPrintInvDtCHK(txt_bl.Text, strtrantype, Convert.ToInt32(Session["LoginBranchid"].ToString()));

            if (dtinv.Rows.Count > 0)
            {

            }
            else
            {
                //Raja
                btn_save.Enabled = false;
                btn_save.ForeColor = System.Drawing.Color.Gray;
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Exemption", "alertify.alert('There is No Invoice for this Shipment.Hence Exemption Cannot be Given');", true);
                return;
            }
            //intcustid = dtgrd.Rows(i).Item("customerid").ToString()
            DataTable DtCE = new DataTable();
            DataTable DtCEnew1 = new DataTable();
            DtCE = Crexobj.GetBookingCust4CE(Trantype, txt_bl.Text, Convert.ToInt32(Session["LoginBranchid"].ToString()));
            if (DtCE.Rows.Count > 0)
            {
                btn_Back.Text = "Cancel";
                btn_Back.ToolTip = "Cancel";
                btn_cancel1.Attributes["class"] = "btn ico-cancel";

                txt_cus.Text = DtCE.Rows[index]["Customer"].ToString();
                intcustid = Convert.ToInt32(DtCE.Rows[index]["customerid"]);
                salesperson = DtCE.Rows[index]["salesperson"].ToString();
                txt_cus_addre.Text = DtCE.Rows[index]["customeraddress"].ToString();
                DtCEnew1 = Crexobj.getapprovedname(intcustid, Convert.ToInt32(Session["LoginDivisionId"].ToString()));

                if (DtCEnew1.Rows.Count > 0)
                {
                    txt_appro.Text = DtCEnew1.Rows[index]["empname"].ToString();
                }
            }
            else
            {
                intcustid = 0;
            }
            DataTable DtCE1 = new DataTable();
            DtCE1 = Crexobj.GetCustCreditAmtcust(intcustid, grdbid, Convert.ToInt32(Session["LoginDivisionid"].ToString()));
            double temp = 0;
            if (DtCE1.Rows.Count > 0)
            {
                txt_cdays.Text = DtCE1.Rows[index]["creditdays"].ToString();
                camt = Convert.ToInt32(DtCE1.Rows[index]["creditamt"].ToString());
                txt_credit.Text = camt.ToString("#,0.00");
            }
            else
            {
                if (Trantype != "CO")
                {
                    BlnExist = true;
                }
            }
            grdinv();
            txt_tot.Text = "0";
            for (i = 0; i <= grd.Rows.Count - 1; i++)
            {
                txt_tot.Text = (Convert.ToDouble(grd.Rows[i].Cells[5].Text) + Convert.ToDouble(txt_tot.Text)).ToString();
            }
            if (txt_tot.Text != "")
            {
                outstdamt = Convert.ToDouble(txt_tot.Text);
            }
            else
            {
                outstdamt = 0;
            }
            DtExBL = Crexobj.GetCustCE(intcustid);
            if (DtExBL.Rows.Count > 0)
            {
                GrdExe.DataSource = DtExBL;
                GrdExe.DataBind();
            }
            else
            {
                GrdExe.DataSource = new DataTable();
                GrdExe.DataBind();
            }

            reqby = empobj.GetNEmpid(txt_req.Text);
            if (strtrantype != "CO")
            {
                int empid = Convert.ToInt32(Session["LoginEmpId"].ToString());
                DataSet ds = new DataSet();
                //ds = Crexobj.GetExcemLimit(empid, branchid, divisionid);
                ds = Crexobj.GetExcemLimitbycust(intcustid, Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(Session["LoginDivisionId"]));
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        txt_approv.Text = ds.Tables[0].Rows[0]["excemlmt"].ToString();

                        if (ds.Tables[0].Rows[0]["overdue"] != "0")
                        {
                            double overdue = double.Parse(ds.Tables[0].Rows[0]["overdue"].ToString()) / 100;
                            amount = (double.Parse(txt_credit.Text) + ((double.Parse(txt_credit.Text) * overdue)));

                            if (outstdamt > amount)
                            {
                                //Raja
                                btn_save.Enabled = false;
                                btn_save.ForeColor = System.Drawing.Color.Gray;
                                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Exemption", "alertify.alert('You have fully utilized Credit Exemption Limit for this Month');", true);
                                if (ds.Tables[1].Rows.Count > 0)
                                {
                                    txt_excem.Text = ds.Tables[1].Rows[0]["GRPCExcem"].ToString();
                                    return;
                                }
                                else
                                {
                                    btn_save.Enabled = true;
                                    btn_save.ForeColor = System.Drawing.Color.White;
                                }
                            }
                        }

                        if (ds.Tables[1].Rows.Count > 0)
                        {
                            txt_excem.Text = ds.Tables[1].Rows[0]["GRPCExcem"].ToString();
                            int tt = Convert.ToInt32(ds.Tables[1].Rows[0].ItemArray[0]);
                            int ttt = Convert.ToInt32(ds.Tables[0].Rows[0].ItemArray[0]);
                            if (tt >= ttt)
                            {
                                //Raja
                                btn_save.Enabled = false;
                                btn_save.ForeColor = System.Drawing.Color.Gray;
                                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Exemption", "alertify.alert('You have fully utilized Credit Exemption Limit for this Month');", true);
                                return;
                            }
                        }
                        else
                        {
                            //Raja
                            btn_save.Enabled = false;
                            btn_save.ForeColor = System.Drawing.Color.Gray;
                            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Exemption", "alertify.alert('You can't give Excemption');", true);
                            return;
                        }
                    }


                }
                else
                {
                    //Raja
                    btn_save.Enabled = false;
                    btn_save.ForeColor = System.Drawing.Color.Gray;
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Exemption", "alertify.alert('You can't give Excemption');", true);
                    return;
                }
                DtCE = Crexobj.GetALLDetailsCreExec(txt_bl.Text, strtrantype, branchid);
                if (DtCE.Rows.Count > 0)
                {
                    txt_remarks.Text = DtCE.Rows[0]["reqremarks"].ToString();
                    //Raja
                    btn_save.Enabled = false;
                    btn_save.ForeColor = System.Drawing.Color.Gray;
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Exemption", "alertify.alert('Already Credit Exemption has Given');", true);
                }
                else
                {
                    btn_save.Enabled = true;
                    btn_save.ForeColor = System.Drawing.Color.White;
                }
            }



            DtBL = Crexobj.GetDetails4CE(trantype, txt_bl.Text, branchid);
            if (strtrantype == "CO")
            {
                btn_save.Enabled = true;
                btn_save.ForeColor = System.Drawing.Color.White;
            }

            if (strtrantype == "FI")
            {

                if (intcustid == 0)
                {
                    SendMailToCreditExe4COO();
                    //Utility.SendMail("", "", "Credit Exemption ", sendqry, "", Session["usermailpwd"].ToString());


                    Utility.SendMailnew("", "", "Credit Exemption ", sendqry, "", "Msncl2021$", "", ""); 

                    //sendmail.SendEmail("", "", "pandi", "Credit Exemption", sendqry, True, Login.MailServer, "", "", Login.MailUser, Login.mailpwd, "");
                }
                else
                {

                    if (Corpobj.GetGroupID(intcustid, divisionid) != 0)
                    {
                        btn_save.Enabled = true;
                        btn_save.ForeColor = System.Drawing.Color.White;
                       btn_Back.Text = "Cancel";


                        btn_Back.ToolTip = "Cancel";
                        btn_cancel1.Attributes["class"] = "btn ico-cancel";

                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Exemption", "alertify.alert('Credit not applied for this Customer" + "\n" + "Kindly contact your Branch Head');", true);
                        //Raja
                        btn_save.Enabled = false;
                        btn_save.ForeColor = System.Drawing.Color.Gray;
                       btn_Back.Text = "Cancel";
                        
                        btn_Back.ToolTip = "Cancel";
                        btn_cancel1.Attributes["class"] = "btn ico-cancel";
                        return;
                    }
                }
            }
            else
            {
                if (Corpobj.GetGroupID(intcustid, divisionid) != 0)
                {
                    btn_save.Enabled = true;
                    btn_save.ForeColor = System.Drawing.Color.White;
                   btn_Back.Text = "Cancel";


                    btn_Back.ToolTip = "Cancel";
                    btn_cancel1.Attributes["class"] = "btn ico-cancel";
                }

                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Exemption", "alertify.alert('Credit not applied for this Customer" + "\n" + "Kindly contact your Branch Head');", true);
                    //Raja
                    btn_save.Enabled = false;
                    btn_save.ForeColor = System.Drawing.Color.Gray;
                   btn_Back.Text = "Cancel";




                    btn_Back.ToolTip = "Cancel";
                    btn_cancel1.Attributes["class"] = "btn ico-cancel";
                    return;
                }
            }

        }



        protected void creditgrd_SelectedIndexChanged(object sender, EventArgs e)
        {

            try
            {
                if (creditgrd.Rows.Count > 0)
                {
                    index = creditgrd.SelectedRow.RowIndex;
                    txt_bl.Text = creditgrd.Rows[index].Cells[1].Text;
                    grdbid = Convert.ToInt32(creditgrd.Rows[index].Cells[6].Text);
                    grdttype = creditgrd.Rows[index].Cells[7].Text;
                    txt_req.Text = creditgrd.Rows[index].Cells[2].Text;

                }
                this.popupQuot.Hide();
                Load_fillData();

            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        protected void creditgrd_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    e.Row.Attributes.Add("onmouseover", "this.originalcolor=this.style.backgroundColor;" + " this.style.backgroundColor='#FDCB0A';");
                    e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalcolor;");

                    e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(creditgrd, "Select$" + e.Row.RowIndex);
                    e.Row.Attributes["style"] = "cursor:pointer";

                    for (int i = 0; i < e.Row.Cells.Count; i++)
                    {
                        if (e.Row.Cells[i].Text == "&nbsp;")
                        {
                            e.Row.Cells[i].Text = "";
                        }
                        e.Row.Cells[i].ToolTip = e.Row.Cells[i].Text;
                    }
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        protected void creditgrd_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            creditgrd.PageIndex = e.NewPageIndex;
            Load_Credit();

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
        protected void getmodule()
        {
            if (strtrantype == "FE")
            {
                //txt_mod.Text = "Ocean Exports";
            }
            else if (strtrantype == "FI")
            {
                //txt_mod.Text = " Ocean Imports";
            }
            else if (strtrantype == "AE")
            {
                //txt_mod.Text = "Air Exports";
            }
            else if (strtrantype == "AI")
            {
                //txt_mod.Text = "Air Imports";
            }
            else if (strtrantype == "C H A")
            {
                //txt_mod.Text = "C H A";
            }
            else if (strtrantype == "CO")
            {
                //txt_mod.Text = "CORPORATE";
            }
        }

        [WebMethod]
        public static List<string> GetLikeexcemption(string prefix)
        {
            DataAccess.ForwardingExports.BLDetails FEBobj = new DataAccess.ForwardingExports.BLDetails();
            DataAccess.ForwardingImports.BLDetails FIBLobj = new DataAccess.ForwardingImports.BLDetails();
            DataAccess.AirImportExports.AIEJobInfo AEJobobj = new DataAccess.AirImportExports.AIEJobInfo();
            DataAccess.AirImportExports.AIEBLDetails AEBLobj = new DataAccess.AirImportExports.AIEBLDetails();
            DataAccess.CustomHousingAgent.JobInfo CHAobj = new DataAccess.CustomHousingAgent.JobInfo();

            string Ccode = HttpContext.Current.Session["Ccode"].ToString();
            FEBobj.GetDataBase(Ccode);
            FIBLobj.GetDataBase(Ccode);
            AEJobobj.GetDataBase(Ccode);
            AEBLobj.GetDataBase(Ccode);
            CHAobj.GetDataBase(Ccode);
            List<string> list_result = new List<string>();
            DataTable dt = new DataTable();
            string strtrantype = Convert.ToString(HttpContext.Current.Session["StrTranType"]);
            //string strtrantype = "FE";
            int branchid = Convert.ToInt32(HttpContext.Current.Session["LoginBranchid"]);
            int divisionid = Convert.ToInt32(HttpContext.Current.Session["LoginDivisionId"]);
            if (strtrantype == "FE" || strtrantype == "FI")
            {
                if (strtrantype == "FE")
                {
                    dt = FEBobj.GetLikeBLDetails(prefix, branchid, divisionid);
                }
                if (strtrantype == "FI")
                {
                    dt = FIBLobj.GetLikeIBL(prefix, branchid, divisionid);
                }
                list_result = Utility.Fn_DatatableToList_Text(dt, "blno");
            }
            else if (strtrantype == "AE" || strtrantype == "AI")
            {
                if (strtrantype == "AE")
                {
                    dt = AEBLobj.GetLikeAIEBLDetails(prefix, "AE", branchid, divisionid);
                }
                if (strtrantype == "AI")
                {
                    dt = AEBLobj.GetLikeAIEBLDetails(prefix, "AI", branchid, divisionid);
                }
                list_result = Utility.Fn_DatatableToList_Text(dt, "hawblno");
            }
            else
            {
                dt = CHAobj.GetLikeDocno(prefix, branchid, divisionid);
                list_result = Utility.Fn_DatatableToList_Text(dt, "docno");
            }


            return list_result;
        }

        protected void txt_bl_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txtclear();
              
                int divisionid = Convert.ToInt32(Session["LoginDivisionId"]);
                Double camt;
                DataTable ddt;
                DataTable obj_dt = new DataTable();
                if (strtrantype == "CO")
                {

                }
                else
                {
                    branchid = Convert.ToInt32(Session["LoginBranchid"]);
                    // branchid = 1;
                    trantype = strtrantype;
                }
                //DataAccess.ForwardingExports.BLPrinting FEBLPrinti = new DataAccess.ForwardingExports.BLPrinting();
                DataTable dtinvc = new DataTable();
                dtinvc = FEBLPrinti.GetBLPrintInvDtCHK(txt_bl.Text, trantype, Convert.ToInt32(Session["LoginBranchid"]));
                if (dtinvc.Rows.Count > 0)
                {

                }
                else
                {
                    //Raja
                    btn_save.Enabled = false;
                    btn_save.ForeColor = System.Drawing.Color.Gray;
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Exemption", "alertify.alert('There is No Invoice for this Shipment.Hence Exemption Cannot be Given');", true);
                    return;
                }
                salesperson = "";
                DtCE = Crexobj.GetBookingCust4CE(trantype, txt_bl.Text, branchid);
                DataTable DtCEnew1 = new DataTable();
                if (DtCE.Rows.Count > 0)
                {
                     btn_Back.Text = "Cancel";

                    btn_Back.ToolTip = "Cancel";
                    btn_cancel1.Attributes["class"] = "btn ico-cancel";


                    txt_cus.Text = DtCE.Rows[0]["Customer"].ToString();
                    intcustid = Convert.ToInt32(DtCE.Rows[0]["customerid"].ToString());
                    salesperson = DtCE.Rows[0]["salesperson"].ToString();
                    //  txt_cus_addre.Text = DtCE.Rows[0]["caddress"].ToString();
                    txt_cus_addre.Text = DtCE.Rows[index]["customeraddress"].ToString();

                    DtCEnew1 = Crexobj.getapprovedname(intcustid, Convert.ToInt32(Session["LoginDivisionId"].ToString()));

                    if (DtCEnew1.Rows.Count > 0)
                    {
                        txt_appro.Text = DtCEnew1.Rows[index]["empname"].ToString();
                    }

                }
                else
                {
                    intcustid = 0;
                }
                dt2 = Crexobj.GetCustCreditAmtcust(intcustid, Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(Session["LoginDivisionId"]));
                if (dt2.Rows.Count > 0)
                {
                    txt_cdays.Text = dt2.Rows[0]["creditdays"].ToString();
                    camt = Convert.ToDouble(dt2.Rows[0]["creditamt"].ToString());
                    txt_credit.Text = Math.Round(camt, 2).ToString("#0.00");

                }
                else if (strtrantype != "CO")
                {
                    BlnExist = true;
                }

                grdinv();
                ddt = (DataTable)ViewState["dtt"];
                txt_tot.Text = "0";
                D = 0.0;
                if (ddt != null)
                {
                    for (int i = 0; i <= ddt.Rows.Count - 1; i++)
                    {
                        D = Convert.ToDouble(ddt.Rows[i]["osamount"].ToString()) + D;

                    }
                }
                else
                {

                }
                txt_tot.Text = Math.Round(D, 2).ToString("#0.00");
                if (txt_tot.Text != "")
                {
                    outstdamt = Convert.ToDouble(txt_tot.Text);
                }
                else
                {
                    outstdamt = 0;
                }
                DtExBL = Crexobj.GetCustCE(intcustid);
                if (DtExBL.Rows.Count > 0)
                {
                    GrdExe.DataSource = DtExBL;
                    GrdExe.DataBind();
                }
                else
                {
                    GrdExe.DataSource = new DataTable();
                    GrdExe.DataBind();
                }
                // reqby = 246;    
                reqby = empobj.GetNEmpid(txt_req.Text);
                if (strtrantype != "CO")
                {
                    int empid = Convert.ToInt32(Session["LoginEmpId"].ToString());
                    DataSet ds = new DataSet();
                    //ds = Crexobj.GetExcemLimit(empid, branchid, divisionid);
                    ds = Crexobj.GetExcemLimitbycust(intcustid, Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(Session["LoginDivisionId"]));
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            txt_approv.Text = ds.Tables[0].Rows[0]["excemlmt"].ToString();

                            if (ds.Tables[0].Rows[0]["overdue"] != "0")
                            {
                                double overdue = double.Parse(ds.Tables[0].Rows[0]["overdue"].ToString()) / 100;
                                amount = (double.Parse(txt_credit.Text) + ((double.Parse(txt_credit.Text) * overdue)));
                                string data = ds.Tables[0].Rows[0]["overdue"].ToString();
                                if (outstdamt > amount)
                                {
                                 //Raja
                                    btn_save.Enabled = false;
                                    btn_save.ForeColor = System.Drawing.Color.Gray;
                                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Exemption", "alertify.alert('Allowed Overdue is" + data + "% of credit amount " + txt_credit.Text + " Outstanding amount exceeded allowed overdue. Hence Exemption not allowed');", true);
                                    // ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Exemption", "alertify.alert('You have fully utilized Credit Exemption Limit for this Month');", true);
                                    if (ds.Tables[1].Rows.Count > 0)
                                    {
                                        txt_excem.Text = ds.Tables[1].Rows[0]["GRPCExcem"].ToString();

                                    }
                                    return;
                                }
                                else
                                {
                                    btn_save.Enabled = true;
                                    btn_save.ForeColor = System.Drawing.Color.White;
                                }
                                if (ds.Tables[1].Rows.Count > 0)
                                {
                                    txt_excem.Text = ds.Tables[1].Rows[0]["GRPCExcem"].ToString();
                                    int tt = Convert.ToInt32(ds.Tables[1].Rows[0].ItemArray[0]);
                                    int ttt = Convert.ToInt32(ds.Tables[0].Rows[0].ItemArray[0]);
                                    if (tt >= ttt)
                                    {
                                        //Raja
                                        btn_save.Enabled = false;
                                        btn_save.ForeColor = System.Drawing.Color.Gray;
                                        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Exemption", "alertify.alert('You have fully utilized Credit Exemption Limit for this Month');", true);
                                        return;
                                    }
                                }
                            }

                            else
                            {
                                //Raja
                                btn_save.Enabled = false;
                                btn_save.ForeColor = System.Drawing.Color.Gray;

                                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Exemption", "alertify.alert('Credit Facility not extended to this Customer" + txt_cus.Text + "');", true);
                                return;
                            }
                        }
                        else
                        {
                            //Raja
                            btn_save.Enabled = false;
                            btn_save.ForeColor = System.Drawing.Color.Gray;
                            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Exemption", "alertify.alert('Credit Facility not extended to this Customer" + txt_cus.Text + "');", true);
                            return;
                        }

                    }
                    DtCE = Crexobj.GetALLDetailsCreExec(txt_bl.Text, strtrantype, branchid);
                    if (DtCE.Rows.Count > 0)
                    {
                        txt_remarks.Text = DtCE.Rows[0]["reqremarks"].ToString();
                        //Raja
                        btn_save.Enabled = false;
                        btn_save.ForeColor = System.Drawing.Color.Gray;
                        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Exemption", "alertify.alert('Already Credit Exemption has Given');", true);
                    }
                    else
                    {
                        btn_save.Enabled = true;
                        btn_save.ForeColor = System.Drawing.Color.White;
                    }
                }
                DtBL = Crexobj.GetDetails4CE(trantype, txt_bl.Text, branchid);
                FillBLDetails();
                if (strtrantype == "CO")
                {
                    btn_save.Enabled = true;
                    btn_save.ForeColor = System.Drawing.Color.White;
                }
                if (strtrantype == "FI")
                {

                    if (intcustid == 0)
                    {
                        //  SendMailToCreditExe4COO();
                        // sendmail.SendEmail("", "", "pandi", "Credit Exemption", sendqry, True, Login.MailServer, "", "", Login.MailUser, Login.mailpwd, "");
                    }
                    else
                    {

                        if (Corpobj.GetGroupID(intcustid, divisionid) != 0)
                        {
                            btn_save.Enabled = true;
                            btn_save.ForeColor = System.Drawing.Color.White;
                            btn_Back.Text = "Cancel";



                            btn_Back.ToolTip = "Cancel";
                            btn_cancel1.Attributes["class"] = "btn ico-cancel";
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Exemption", "alertify.alert('Credit not applied for this Customer Kindly contact your Branch Head');", true);
                            //Raja
                            btn_save.Enabled = false;
                            btn_save.ForeColor = System.Drawing.Color.Gray;
                            btn_Back.Text = "Cancel";



                            btn_Back.ToolTip = "Cancel";
                            btn_cancel1.Attributes["class"] = "btn ico-cancel";
                            return;
                        }
                    }
                }
                else
                {
                    if (Corpobj.GetGroupID(intcustid, divisionid) != 0)
                    {
                        btn_save.Enabled = true;
                        btn_save.ForeColor = System.Drawing.Color.White;
                        btn_Back.Text = "Cancel";



                        btn_Back.ToolTip = "Cancel";
                        btn_cancel1.Attributes["class"] = "btn ico-cancel";
                    }

                    else
                    {
                        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Exemption", "alertify.alert('Credit not applied for this Customer" + "\n" + "Kindly contact your Branch Head');", true);
                        //Raja
                        btn_save.Enabled = false;
                        btn_save.ForeColor = System.Drawing.Color.Gray;
                       btn_Back.Text = "Cancel";


                        btn_Back.ToolTip = "Cancel";
                        btn_cancel1.Attributes["class"] = "btn ico-cancel";
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }
        protected void SendMailToCreditExe4COO()
        {
            sendqry = Session["Companyaddress"].ToString();
            sendqry = sendqry + "<table width=100%><FONT FACE=tahoma ><tr><td align=left>Dear Sir,</td></tr></font></table><br>";
            sendqry = sendqry + "<table width=100%><FONT FACE=tahoma ><tr><td align=left>" + txt_req.Text + " has tried to give credit exemption for import freehand shipment and find below the deatils of the same.  </td></tr></font><br>";
            sendqry = sendqry + "<FONT FACE=tahoma ><tr><td align=left>BL # : " + txt_bl.Text + " </td></tr></font>";
            sendqry = sendqry + "<FONT FACE=tahoma ><tr><td align=left>Shipper : " + txt_shipper.Text + " </td></tr></font>";
            sendqry = sendqry + "<FONT FACE=tahoma ><tr><td align=left>Consignee : " + txt_consignee.Text + " </td></tr></font>";
            sendqry = sendqry + "<FONT FACE=tahoma ><tr><td align=left>Shipment Details : " + txt_sdetails.Text + " </td></tr></font></table><br>";

            sendqry = sendqry + "<table width=100%><FONT FACE=tahoma ><tr><td align=left>Regards ,</td></tr></font></table><br>";
            sendqry = sendqry + "<table width=100%><FONT FACE=tahoma ><tr><td align=left></td></tr></font></table><br>";
        }

        protected void FillBLDetails()
        {
            try
            {
                if (DtBL.Rows.Count > 0)
                {
                    txt_shipper.Text = DtBL.Rows[0]["shipper"].ToString();
                    txt_consignee.Text = DtBL.Rows[0]["consignee"].ToString();

                    if (trantype == "FE" || trantype == "FI")
                    {
                        txt_sdetails.Text = DtBL.Rows[0]["shipment"].ToString().Trim() + " - " + DtBL.Rows[0]["vesselname"].ToString().Trim() + " V " + DtBL.Rows[0]["voyage"].ToString() + "/ POR :" + DtBL.Rows[0]["por"].ToString().Trim() + " /POL: " + DtBL.Rows[0]["pol"].ToString() + " /POD " + DtBL.Rows[0]["pod"].ToString().Trim() + " /FD: " + DtBL.Rows[0]["fd"].ToString().Trim();
                    }
                    else if (trantype == "AE" || trantype == "AI")
                    {
                        txt_sdetails.Text = DtBL.Rows[0]["flightno"].ToString().Trim() + " / " + DtBL.Rows[0]["flightdate"].ToString().Trim() + "/ FromPort :" + DtBL.Rows[0]["fromport"].ToString().Trim() + " /ToPort: " + DtBL.Rows[0]["toport"].ToString().Trim();
                    }
                    bldate = Convert.ToDateTime(DtBL.Rows[0]["bldate"]);
                    txt_date.Text = Utility.fn_ConvertDate(bldate.ToShortDateString());

                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        protected void grdinv()
        {
            try
            {
                grd.DataSource = new DataTable();
                grd.DataBind();
                dtinv = Crexobj.GetCustInvOut(intcustid, Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()));

                if (dtinv.Rows.Count > 0)
                {
                    DataTable dtt = new DataTable();
                    DataRow dr;
                    dtt.Columns.Add("shortname");
                    dtt.Columns.Add("customername");
                    dtt.Columns.Add("invoiceno");
                    dtt.Columns.Add("invdate");
                    dtt.Columns.Add("days");
                    dtt.Columns.Add("osamount");

                    for (i = 0; i <= (dtinv.Rows.Count - 1); i++)
                    {


                        //invbid = Convert.ToInt32(dtinv.Rows[i]["branchid"].ToString());
                        invouno = Convert.ToInt32(dtinv.Rows[i]["vouno"].ToString());
                        invoudate = Convert.ToDateTime(dtinv.Rows[i]["voudate"].ToString());
                        //invttype = dtinv.Rows[i]["trantype"].ToString();
                        //invblno = dtinv.Rows[i]["blno"].ToString();
                        invodays = Convert.ToInt32(dtinv.Rows[i]["noofdays"].ToString());
                        voutype = dtinv.Rows[i]["voutype"].ToString();
                        invamount = Convert.ToDouble(dtinv.Rows[i]["osamount"].ToString());
                        //invcname = dtinv.Rows[i]["customername"].ToString();

                        //DataColumn customername = new DataColumn("customername", typeof(string));
                        //dtinv.Columns.Add(customername);

                        //DataRow dr = dtinv.NewRow();
                        //dr["customername"] = invcname.ToString();
                        //dtinv.Rows.Add(dr);

                        //if (i == 0)
                        //{
                        //    outstddays = invodays;
                        //}
                        //else if (outstddays < invodays)
                        //{
                        //    outstddays = invodays;
                        //}
                        dr = dtt.NewRow();
                        dr["shortname"] = dtinv.Rows[i]["shortname"].ToString();
                        dr["customername"] = dtinv.Rows[i]["customername"].ToString();
                        dr["invoiceno"] = voutype + " - " + invouno;
                        dr["invdate"] = invoudate.ToShortDateString();
                        dr["days"] = invodays.ToString();
                        dr["osamount"] = Math.Round(invamount, 2).ToString();

                        dtt.Rows.Add(dr);


                        //}

                    }
                    ViewState["dtt"] = dtt;
                    grd.DataSource = dtt;
                    grd.DataBind();
                }
                else
                {
                    grd.DataSource = new DataTable();
                    grd.DataBind();
                }

            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }
        protected void btn_Back_Click(object sender, EventArgs e)
        {
            if (btn_Back.ToolTip == "Cancel")
            {
                txt_bl.Text = "";
                txtclear();
                ddl_product.SelectedValue = "0";
                btn_save.Enabled = true;
                btn_save.ForeColor = System.Drawing.Color.White;
              btn_Back.Text = "Back";
                btn_save.Text = "Save";


                btn_save.ToolTip = "Save";
                btn_save1.Attributes["class"] = "btn ico-save";


                btn_Back.ToolTip = "Back";
                btn_cancel1.Attributes["class"] = "btn ico-back";

            }
            else
            {
                if (Session["home"] != null)
                {
                    if (Session["StrTranType"] != null)
                    {
                        if (Session["StrTranType"].ToString()=="CO")
                        {
                            Response.Redirect("../CorMainPage/Credit_Control_Docked.aspx");  
                        }
                    }

                     else if (Session["home"].ToString() == "MIS")
                        {
                            Response.Redirect("../Home/MISAndApproval.aspx");
                        }
                   


                }


                //this.Response.End();
            }
        }

        protected void txtclear()
        {
            txt_appro.Text = "";
            txt_approv.Text = "";
            // txt_bl.Text = "";
            txt_cdays.Text = "";
            txt_consignee.Text = "";
            txt_credit.Text = "";
            txt_cus.Text = "";
            txt_date.Text = "";
            txt_excem.Text = "";

            txt_remarks.Text = "";
            txt_cus_addre.Text = "";

            txt_sdetails.Text = "";
            txt_shipper.Text = "";
            txt_tot.Text = "";
            grd.DataSource = new DataTable();
            grd.DataBind();
            GrdExe.DataSource = new DataTable();
            GrdExe.DataBind();
        }

        protected void btn_save_Click(object sender, EventArgs e)
        {
            try
            {
                if (ddl_product.SelectedIndex == 0)
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "logix", "alertify.alert('Please Select the Product Type');", true);
                   // blnerr = true;
                    ddl_product.Focus();
                    return;
                }
                trantype = strtrantype;
                string usermail = "";
                string sendqry = "";
                string subject = " Credit Exemption";

                int did = Convert.ToInt32(Session["LoginDivisionId"].ToString());
                reqby = empobj.GetNEmpid(txt_req.Text);
                branchid = Convert.ToInt32(Session["LoginBranchid"].ToString());
                DtCE = Crexobj.GetBookingCust4CE(trantype, txt_bl.Text, branchid);
                if (DtCE.Rows.Count > 0)
                {
                    intcustid = Convert.ToInt32(DtCE.Rows[0]["customerid"].ToString());
                    outstdamt = Convert.ToDouble(txt_tot.Text);
                    outstddays = Convert.ToInt32(txt_cdays.Text);
                    if (strtrantype == "CO")
                    {

                        Crexobj.UpdateCreditExec(branchid, Session["StrTranType"].ToString(), txt_bl.Text, Convert.ToInt32(Session["LoginEmpId"]), txt_remarks.Text, txt_approv.Text);

                        if (Session["StrTranType"].ToString()=="FE")
                        {
                            logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 457, 1, Convert.ToInt32(Session["LoginBranchid"]), "/BL #: " + txt_bl.Text + "/ S");
                        }
                        else if (Session["StrTranType"].ToString()=="FI")
                        {
                            logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 458, 1, Convert.ToInt32(Session["LoginBranchid"]), "/BL #: " + txt_bl.Text + "/ S");
                        }
                        else if (Session["StrTranType"].ToString() == "AE")
                        {
                            logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 459, 1, Convert.ToInt32(Session["LoginBranchid"]), "/BL #: " + txt_bl.Text + "/ S");
                        }
                        else if (Session["StrTranType"].ToString() == "AI")
                        {
                            logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 460, 1, Convert.ToInt32(Session["LoginBranchid"]), "/BL #: " + txt_bl.Text + "/ S");
                        }
                        else
                        {
                            logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 456, 1, Convert.ToInt32(Session["LoginBranchid"]), "/BL #: " + txt_bl.Text + "/ S");
                        }
                       
                    }
                    else
                    {
                        if (txt_remarks.Text == "")
                        {
                            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Exemption", "alertify.alert('Remarks Necessary');", true);
                            txt_remarks.Focus();
                            return;
                        }
                        if (txt_bl.Text.Trim() != "")
                        {
                            Crexobj.InsertCreditExec(Convert.ToInt32(Session["LoginBranchid"].ToString()), Session["StrTranType"].ToString(), txt_bl.Text.Trim(), reqby, txt_remarks.Text, intcustid, outstdamt, outstddays);
                            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Exemption", "alertify.alert('Credit For This - " + txt_bl.Text.Trim() + " -Has Been Exempted');", true);
                            sendExemptionmail();


                            if (did == 2 || did == 4 || did == 5)
                            {
                            }
                            else
                            {
                            }
                            txt_bl.Text = "";
                            txtclear();
                            btn_save.Enabled = false;
                            btn_save.ForeColor = System.Drawing.Color.Gray;
                          btn_Back.Text = "Cancel";

                            btn_Back.ToolTip = "Cancel";
                            btn_cancel1.Attributes["class"] = "btn ico-cancel";


                            if (Session["StrTranType"].ToString() == "FE")
                            {
                                logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 457, 1, Convert.ToInt32(Session["LoginBranchid"]), "/BL #: " + txt_bl.Text + "/ S");
                            }
                            else if (Session["StrTranType"].ToString() == "FI")
                            {
                                logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 458, 1, Convert.ToInt32(Session["LoginBranchid"]), "/BL #: " + txt_bl.Text + "/ S");
                            }
                            else if (Session["StrTranType"].ToString() == "AE")
                            {
                                logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 459, 1, Convert.ToInt32(Session["LoginBranchid"]), "/BL #: " + txt_bl.Text + "/ S");
                            }
                            else if (Session["StrTranType"].ToString() == "AI")
                            {
                                logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 460, 1, Convert.ToInt32(Session["LoginBranchid"]), "/BL #: " + txt_bl.Text + "/ S");
                            }
                            else
                            {
                                logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 456, 1, Convert.ToInt32(Session["LoginBranchid"]), "/BL #: " + txt_bl.Text + "/ S");
                            }
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






      

        protected void txt_appro_TextChanged(object sender, EventArgs e)
        {

        }

        public void sendExemptionmail()
        {

            DataTable dtinv = new DataTable();
            DataTable Dt = new DataTable();
            DataTable dtamt = new DataTable();
            string strtran = "";
            int invbid, invouno, invblno, invodays;
            double invamount;
            string invoudate, invttype, voutype, invcname, vamount = "", voudate;

            sendqry = sendqry + "<body text=darkblue font face =sans-serif size=1><table width=100%><FONT FACE=tahoma ><tr><td align=left>Dear " + empobj.GetEmployeeName(Convert.ToInt32(Session["LoginEmpId"].ToString())) + "  </td></tr></table>";
            if (Session["StrTranType"].ToString() == "FE")
            {
                if (txt_cus.Text != "")
                {
                    sendqry = sendqry + "<table ><tr><td align=left>You have given exemption to release the Bill of lading No : " + txt_bl.Text + " for the customer " + txt_cus.Text + " </td><br>";
                }
                else
                {
                    sendqry = sendqry + "<table ><tr><td align=left>You have given exemption to release the Bill of lading No : " + txt_bl.Text + " for the customer " + txt_shipper.Text + " </td><td align=left><br>";
                }
            }
            else
            {
                if (txt_cus.Text != "")
                {
                    sendqry = sendqry + "<table><tr><td align=left>You have given exemption to release the Delivery Order for the BL Number : " + txt_bl.Text + " for the customer " + txt_cus.Text + " </td><br>";
                }
                else
                {
                    sendqry = sendqry + "<table><tr><td align=left>You have given exemption to release the Delivery Order for the BL Number : " + txt_bl.Text + " for the customer " + txt_consignee.Text + "</td><br>";
                }
            }
            if (txt_remarks.Text != "")
            {
                sendqry = sendqry + "<tr><td>You have given reason  for Exemption as - " + txt_remarks.Text + " </td></tr>";
            }


            dtinv = Crexobj.GetCustInvOut(intcustid, Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(Session["LoginDivisionId"]));
            if (dtinv.Rows.Count > 0)
            {
                sendqry = sendqry + "<tr><td align=left colspan=4>Please find below the Outstanding Details for the Customer </td></tr><br></table>";
                sendqry = sendqry + "<table width=100% border =1 cellspacing=0 cellpadding=2 ><tr><td align =left>BL #</td><td align =left>Trantype</td><td align=left>Vou  # </td><td align =left>Vou Date</td><td align =left>Vou Type</td><td align =left>O/S Days</td><td align =left>Amount</td></tr>";
                for (int i = 0; i < dtinv.Rows.Count - 1; i++)
                {
                    invbid = Convert.ToInt32(dtinv.Rows[i]["branchid"].ToString());
                    invouno = Convert.ToInt32(dtinv.Rows[i]["vouno"].ToString());
                    invoudate = dtinv.Rows[i]["voudate"].ToString();
                    voudate = Utility.fn_ConvertDate(dtinv.Rows[i]["voudate"].ToString());
                    invttype = dtinv.Rows[i]["trantype"].ToString();
                    if (invttype == "FE")
                    {
                        strtran = "Ocean Exports";
                    }
                    else if (invttype == "FI")
                    {
                        strtran = "Ocean Imports";
                    }
                    else if (invttype == "AE")
                    {
                        strtran = "Air Exports";
                    }
                    else if (invttype == "AI")
                    {
                        strtran = "Air Imports";
                    }
                    else if (invttype == "CH")
                    {
                        strtran = "CHA";
                    }
                    string invblno1 = dtinv.Rows[i]["blno"].ToString();
                    invodays = Convert.ToInt32(dtinv.Rows[i]["noofdays"].ToString()); //dtinv.Rows(i).Item("noofdays").ToString()
                    voutype = dtinv.Rows[i]["voutype"].ToString();
                    dtamt = Crexobj.GetCustInvOutAmt(invbid, invouno, invttype, invblno1, voutype);
                    if (dtamt.Rows.Count > 0)
                    {
                        invamount = Convert.ToDouble(dtamt.Rows[0]["amount"].ToString());
                        vamount = string.Format("{0:#,##0.00}", invamount);
                        invcname = dtamt.Rows[0]["customername"].ToString();//dtamt.Rows(0).Item("customername").ToString()
                    }
                    sendqry = sendqry + "<tr><td align=left> " + invblno1 + " </td><td align=left> " + strtran + "</td><td align=left>" + invouno + " </td><td align=left>" + voudate + "</td><td align=left>" + voutype + " </td><td align=left>" + invodays + "</td><td align=Right> " + vamount + "</td></tr>";



                }
            }
            else
            {
                sendqry = sendqry + "<tr><td>This Customer is a Cash and Carry Customer </td></tr>";
            }
            sendqry = sendqry + "</table>";
            sendqry = sendqry + "<table><tr><td>Thanks & Regards</td></tr>";
            sendqry = sendqry + "<tr><td></td></tr></table></body>";


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



            if (strtrantype == "CO")
            {
                if (Session["StrTranType"].ToString() == "FE")
                {
                    obj_dtlogdetails = logobj.InsTempGrpLogdtlsGet(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), 457, "BL", txt_bl.Text, txt_bl.Text, Session["StrTranType"].ToString());
                }
                else if (Session["StrTranType"].ToString() == "FI")
                {
                    obj_dtlogdetails = logobj.InsTempGrpLogdtlsGet(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), 458, "BL", txt_bl.Text, txt_bl.Text, Session["StrTranType"].ToString());
                    
                }
                else if (Session["StrTranType"].ToString() == "AE")
                {
                    obj_dtlogdetails = logobj.InsTempGrpLogdtlsGet(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), 459, "BL", txt_bl.Text, txt_bl.Text, Session["StrTranType"].ToString());
                }
                else if (Session["StrTranType"].ToString() == "AI")
                {
                    obj_dtlogdetails = logobj.InsTempGrpLogdtlsGet(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), 460, "BL", txt_bl.Text, txt_bl.Text, Session["StrTranType"].ToString());
                }
                else
                {
                    obj_dtlogdetails = logobj.InsTempGrpLogdtlsGet(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), 456, "BL", txt_bl.Text, txt_bl.Text, Session["StrTranType"].ToString());
                }
            }
            else
            {
                if (Session["StrTranType"].ToString() == "FE")
                {
                    obj_dtlogdetails = logobj.InsTempGrpLogdtlsGet(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), 457, "BL", txt_bl.Text, txt_bl.Text, Session["StrTranType"].ToString());
                }
                else if (Session["StrTranType"].ToString() == "FI")
                {
                    obj_dtlogdetails = logobj.InsTempGrpLogdtlsGet(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), 458, "BL", txt_bl.Text, txt_bl.Text, Session["StrTranType"].ToString());

                }
                else if (Session["StrTranType"].ToString() == "AE")
                {
                    obj_dtlogdetails = logobj.InsTempGrpLogdtlsGet(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), 459, "BL", txt_bl.Text, txt_bl.Text, Session["StrTranType"].ToString());
                }
                else if (Session["StrTranType"].ToString() == "AI")
                {
                    obj_dtlogdetails = logobj.InsTempGrpLogdtlsGet(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), 460, "BL", txt_bl.Text, txt_bl.Text, Session["StrTranType"].ToString());
                }
                else
                {
                    obj_dtlogdetails = logobj.InsTempGrpLogdtlsGet(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), 456, "BL", txt_bl.Text, txt_bl.Text, Session["StrTranType"].ToString());
                }
            }
            if (txt_bl.Text != "")
            {
                JobInput.Text = txt_bl.Text;
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

        protected void GrdExe_PreRender(object sender, EventArgs e)
        {
            if (GrdExe.Rows.Count > 0)
            {
                GrdExe.UseAccessibleHeader = true;
                GrdExe.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }
    }
}