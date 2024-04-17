using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using ClosedXML.Excel;
using System.IO;
using System.Web.Services;
using System.Collections.Generic;

namespace logix
{
    public partial class FIEBLInfo : System.Web.UI.Page
    {
        CustomerDataAccess.RegCustomer cusobj = new CustomerDataAccess.RegCustomer();
        //DataAccess.Masters.MasterCustomer MCus = new DataAccess.Masters.MasterCustomer();
        public DateTime Frm, To;
        string strTranType, strdbname, strBLno, strStatus;
        int i, cusID;
        DataTable Dt, dtCustIDs, DtCombined;
        DataColumn Dc;
        Calendar Frmobj, Toobj;
        Calendar cldr = new Calendar();
        Global glObj = new Global();
        CustomerDataAccess.PODetails Logobj = new CustomerDataAccess.PODetails();
        public string strTo, strFrom;

        protected void Page_Load(object sender, EventArgs e)
        {
            //prabha
            //string str = "BDJkl&amp;";
            //str = HttpUtility.HtmlDecode(str);
            ((ScriptManager)this.FindControl("ScriptManager1")).RegisterPostBackControl(btnExcel);
            ((ScriptManager)this.FindControl("ScriptManager1")).RegisterPostBackControl(btnview);
            if (Session["username"] == null)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alertify.alert('Session TimeOut');window.open('"+ Session["Site"].ToString() + "/','_top');", true);
            }
            ((ScriptManager)this.FindControl("ScriptManager1")).RegisterPostBackControl(btnExcel);
            ((ScriptManager)this.FindControl("ScriptManager1")).RegisterPostBackControl(GrdFEBL);
            if (!IsPostBack)
            {
                //Frmobj = new Calendar(this.Page, dtFrom, ImgFrm);
                //Toobj = new Calendar(this.Page, dtTo, ImgTo);
                //    dtFrom.Text = cldr.ConvertDate(DateTime.Now.AddDays(-30).ToShortDateString());
                DateTime dtmTMPSS = new DateTime();
                dtmTMPSS = DateTime.Now.AddDays(-90);
                dtFrom.Text = dtmTMPSS.ToString("dd/MM/yyyy");
                dtTo.Text = Convert.ToDateTime(Logobj.GetDate().ToShortDateString()).ToString("dd/MM/yyyy");
            }
            strTranType = Request.QueryString["Trantype"];
            if (strTranType == "FE")
            {
                pnlOIE.Visible = false;
                pnlAIE.Visible = false;
                Pln_OFE.Visible = true;
            }
            else if (strTranType == "FI")
            {
                pnlOIE.Visible = true;
                pnlAIE.Visible = false;
                Pln_OFE.Visible = false;
            }
            else
            {
                pnlOIE.Visible = false;
                pnlAIE.Visible = true;
                Pln_OFE.Visible = false;
            }


            if (!IsPostBack)
            {
                strFrom = Request.QueryString["from"];
                strTo = Request.QueryString["to"];
                if (strFrom != null)
                    dtFrom.Text = ConvertDateReverse(strFrom);

                if (strTo != null)
                    dtTo.Text = ConvertDateReverse(strTo);

                if (strFrom != null && strTo != null)
                {
                    BtnSelect_Click(sender, e);
                }
            }
            if (strTranType == null)
            {
              //  Response.Redirect("Login.aspx");

                Session.Abandon();
                Session.Clear();
                Session.RemoveAll();
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "window.open('"+ Session["Site"].ToString() + "/','_top');", true);
            }
            else
            {
                switch (strTranType)
                {
                    case "FE":
                        LBLTitle.Text = "Ocean Exports";

                        break;
                    case "FI":
                        LBLTitle.Text = "Ocean Imports";
                        break;
                    case "AE":
                        LBLTitle.Text = "Air Exports";
                        break;
                    case "AI":
                        LBLTitle.Text = "Air Imports";
                        break;
                    case "CH":
                        LBLTitle.Text = "Custom House Details";
                        GrdFEIBL.Columns[0].Visible = false;
                        GrdFEIBL.Columns[4].HeaderText = "Voyage";
                        break;
                }

                lbl.InnerText = LBLTitle.Text;
            }
            GrdFEBL.Attributes.Add("style", "word-break:break-all;word-wrap:break-word");
        }


        [WebMethod]
        public static List<string> GetCustomer(string prefix)
        {
            List<string> list_result = new List<string>();
            DataTable dt = new DataTable();
            DataAccess.Masters.MasterCustomer obj_MasterCustomer = new DataAccess.Masters.MasterCustomer();
            // dt = obj_MasterCustomer.GetCustomerName(prefix);GetLikeCustomerAll
            dt = obj_MasterCustomer.GetLikeCustomerAll(prefix.ToUpper());
            //  list_result = Utility.Fn_TableToList(dt, "customername", "customerid");
            list_result = Utility.Fn_TableToList_Cust1(dt, "customer", "customerid", "address");
            return list_result;

        }

        protected void BtnSelect_Click(object sender, EventArgs e)
        {
            DateTime FromDate;
            DateTime ToDate;

            FromDate = DateTime.Parse(cldr.ConvertDate(dtFrom.Text));
            ToDate = DateTime.Parse(cldr.ConvertDate(dtTo.Text));
            if (FromDate > ToDate)
            {
                ScriptManager.RegisterStartupScript(BtnSelect, typeof(Button), "DataFound", "alertify.alert('From Date is Lesser than To Date');", true);
                return;
            }

            // Pnl_FE.Visible = false;
            // Pnl_FI.Visible = false;
            Pln_OFE.Visible = true;
            cusID = int.Parse(Request.QueryString["uid"].ToString());

            if (txtBLNo.Text == "")
            {
                switch (strTranType)
                {
                    case "FE":
                        cusobj.InsWebCustLogDtl(cusID, CustomerDataAccess.RegCustomer.EventType.OceanExports, DateTime.Now, dtFrom.Text + " to" + dtTo.Text + " - " + strTranType + " BL Find");
                        break;
                    case "FI":
                        cusobj.InsWebCustLogDtl(cusID, CustomerDataAccess.RegCustomer.EventType.OceanImports, DateTime.Now, dtFrom.Text + " to" + dtTo.Text + " - " + strTranType + " BL Find");
                        break;
                    case "AE":
                        cusobj.InsWebCustLogDtl(cusID, CustomerDataAccess.RegCustomer.EventType.AirExports, DateTime.Now, dtFrom.Text + " to" + dtTo.Text + " - " + strTranType + " BL Find");
                        break;
                    case "AI":
                        cusobj.InsWebCustLogDtl(cusID, CustomerDataAccess.RegCustomer.EventType.AirImports, DateTime.Now, dtFrom.Text + " to" + dtTo.Text + " - " + strTranType + " BL Find");
                        break;
                    case "CH":
                        cusobj.InsWebCustLogDtl(cusID, CustomerDataAccess.RegCustomer.EventType.AirImports, DateTime.Now, dtFrom.Text + " to" + dtTo.Text + " - " + strTranType + " BL Find");
                        break;
                }
            }
            else if (txtBLNo.Text != "")
            {
                switch (strTranType)
                {
                    case "FE":
                        cusobj.InsWebCustLogDtl(cusID, CustomerDataAccess.RegCustomer.EventType.OceanExports, DateTime.Now, txtBLNo.Text + " BL Find");
                        break;
                    case "FI":
                        cusobj.InsWebCustLogDtl(cusID, CustomerDataAccess.RegCustomer.EventType.OceanImports, DateTime.Now, txtBLNo.Text + " BL Find");
                        break;
                    case "AE":
                        cusobj.InsWebCustLogDtl(cusID, CustomerDataAccess.RegCustomer.EventType.AirExports, DateTime.Now, txtBLNo.Text + " BL Find");
                        break;
                    case "AI":
                        cusobj.InsWebCustLogDtl(cusID, CustomerDataAccess.RegCustomer.EventType.AirImports, DateTime.Now, txtBLNo.Text + " BL Find");
                        break;
                    case "CH":
                        cusobj.InsWebCustLogDtl(cusID, CustomerDataAccess.RegCustomer.EventType.AirImports, DateTime.Now, txtBLNo.Text + " BL Find");
                        break;
                }
            }

            //else if (txtBLNo.Text != "")
            //{
            //    switch (strTranType)
            //    {
            //        case "FE":
            //            cusobj.InsWebCustLogDtl(cusID, CustomerDataAccess.RegCustomer.EventType.OceanExports, DateTime.Now, txtBLNo.Text + " BL Find");
            //            break;
            //        case "FI":
            //            cusobj.InsWebCustLogDtl(cusID, CustomerDataAccess.RegCustomer.EventType.OceanImports, DateTime.Now, txtBLNo.Text + " BL Find");
            //            break;
            //        case "AE":
            //            cusobj.InsWebCustLogDtl(cusID, CustomerDataAccess.RegCustomer.EventType.AirExports, DateTime.Now, txtBLNo.Text + " BL Find");
            //            break;
            //        case "AI":
            //            cusobj.InsWebCustLogDtl(cusID, CustomerDataAccess.RegCustomer.EventType.AirImports, DateTime.Now, txtBLNo.Text + " BL Find");
            //            break;
            //    }
            //}


            lblMsg.Text = "";

            if (txtBLNo.Text.Trim() != "" && ddl_find.SelectedIndex == 0)
            {
                //DtCombined = cusobj.GetBLByBkgBLNo(strTranType, txtBLNo.Text, "BL",1);
              //  DtCombined = cusobj.GetBLByBkgBLNoNewWeb(strTranType, txtBLNo.Text, "BL", 1, DateTime.Parse(cldr.ConvertDate(dtFrom.Text)), DateTime.Parse(cldr.ConvertDate(dtTo.Text)));

                DtCombined = cusobj.CustomerLoginDetailsfilter(cusID, strTranType, DateTime.Parse(cldr.ConvertDate(dtFrom.Text)), DateTime.Parse(cldr.ConvertDate(dtTo.Text)), 1, txtBLNo.Text, "BL");

                if (DtCombined.Rows.Count == 0)
                {
                    lblMsg.Text = "";
                }
            }
            else if (txtBLNo.Text.Trim() != "" && ddl_find.SelectedIndex == 1)
            {
                //DtCombined = cusobj.GetBLByBkgBLNo(strTranType, txtBLNo.Text, "BG",1);
                //DtCombined = cusobj.GetBLByBkgBLNoNewWeb(strTranType, txtBLNo.Text, "BG", 1, DateTime.Parse(cldr.ConvertDate(dtFrom.Text)), DateTime.Parse(cldr.ConvertDate(dtTo.Text)));

                DtCombined = cusobj.CustomerLoginDetailsfilter(cusID, strTranType, DateTime.Parse(cldr.ConvertDate(dtFrom.Text)), DateTime.Parse(cldr.ConvertDate(dtTo.Text)), 1, txtBLNo.Text, "BG");


                if (DtCombined.Rows.Count == 0)
                    lblMsg.Text = "";
            }
            else if (txtBLNo.Text.Trim() != "" && ddl_find.SelectedIndex == 2)
            {
                //DtCombined = cusobj.GetBLByBkgBLNo(strTranType, txtBLNo.Text.TrimStart().TrimEnd(), "INV",1);
               // DtCombined = cusobj.GetBLByBkgBLNoNewWeb(strTranType, txtBLNo.Text, "INV", 1, DateTime.Parse(cldr.ConvertDate(dtFrom.Text)), DateTime.Parse(cldr.ConvertDate(dtTo.Text)));
                DtCombined = cusobj.CustomerLoginDetailsfilter(cusID, strTranType, DateTime.Parse(cldr.ConvertDate(dtFrom.Text)), DateTime.Parse(cldr.ConvertDate(dtTo.Text)), 1, txtBLNo.Text, "INV");
                if (DtCombined.Rows.Count == 0)
                    lblMsg.Text = "";
            }
            else if (txt_customer.Text != "" && ddl_find.SelectedIndex == 3)
            {
                //DtCombined = cusobj.GetBLByBkgBLNo(strTranType, txtBLNo.Text.TrimStart().TrimEnd(), "INV",1);
                // DtCombined = cusobj.GetBLByBkgBLNoNewWeb(strTranType, txtBLNo.Text, "INV", 1, DateTime.Parse(cldr.ConvertDate(dtFrom.Text)), DateTime.Parse(cldr.ConvertDate(dtTo.Text)));
                DtCombined = cusobj.CustomerLoginDetailsfilter(cusID, strTranType, DateTime.Parse(cldr.ConvertDate(dtFrom.Text)), DateTime.Parse(cldr.ConvertDate(dtTo.Text)), 1, Hiddenshipper.Value, "Shipper");
                if (DtCombined.Rows.Count == 0)
                    lblMsg.Text = "";
            }
            else if (txt_customer.Text != "" && ddl_find.SelectedIndex == 4)
            {
                //DtCombined = cusobj.GetBLByBkgBLNo(strTranType, txtBLNo.Text.TrimStart().TrimEnd(), "INV",1);
                // DtCombined = cusobj.GetBLByBkgBLNoNewWeb(strTranType, txtBLNo.Text, "INV", 1, DateTime.Parse(cldr.ConvertDate(dtFrom.Text)), DateTime.Parse(cldr.ConvertDate(dtTo.Text)));
                DtCombined = cusobj.CustomerLoginDetailsfilter(cusID, strTranType, DateTime.Parse(cldr.ConvertDate(dtFrom.Text)), DateTime.Parse(cldr.ConvertDate(dtTo.Text)), 1, Hiddenshipper.Value, "Consignee");
                if (DtCombined.Rows.Count == 0)
                    lblMsg.Text = "";
            }
            else
            {
                if (strTranType == "FE" || strTranType == "FI")
                    //DtCombined = cusobj.cus(cusID, strTranType, DateTime.Parse(cldr.ConvertDate(dtFrom.Text)), DateTime.Parse(cldr.ConvertDate(dtTo.Text)), 1);
                    DtCombined = cusobj.CustomerLoginDetails(cusID, strTranType, DateTime.Parse(cldr.ConvertDate(dtFrom.Text)), DateTime.Parse(cldr.ConvertDate(dtTo.Text)), 1);
                else
                    //DtCombined = cusobj.SelCusAIEBLInfo(cusID, strTranType, DateTime.Parse(cldr.ConvertDate(dtFrom.Text)), DateTime.Parse(cldr.ConvertDate(dtTo.Text)), 1);
                    DtCombined = cusobj.CustomerLoginDetails(cusID, strTranType, DateTime.Parse(cldr.ConvertDate(dtFrom.Text)), DateTime.Parse(cldr.ConvertDate(dtTo.Text)), 1);
            }
            if (DtCombined.Rows.Count == 0)
                lblMsg.Text = "No data available";
            else
                lblMsg.Text = "";

            if (strTranType == "FE" || strTranType == "FI")
            {
                if (strTranType == "FE")
                {
                    //Pnl_FE.Visible = true;
                    Pnl_FEGrd.Visible = true;
                    if (DtCombined.Rows.Count > 0)
                    {
                        GrdFEBL.DataSource = DtCombined;
                        GrdFEBL.DataBind();
                        //Grd_FETemp.DataSource = DtCombined;
                        //Grd_FETemp.DataBind();
                    }
                    else
                    {
                        Pnl_FEGrd.Visible = false;
                        GrdFEBL.DataSource = new DataTable();
                        GrdFEBL.DataBind();
                        Grd_FETemp.DataSource = new DataTable();
                        Grd_FETemp.DataBind();
                    }
                }
                else
                {
                    //Pnl_FI.Visible = true;

                    pnlOIE.Visible = true;
                    if (DtCombined.Rows.Count > 0)
                    {
                        GrdFEIBL.DataSource = DtCombined;
                        GrdFEIBL.DataBind();
                    }
                    else
                    {
                        GrdFEIBL.DataSource = new DataTable();
                        GrdFEIBL.DataBind();
                    }
                }
            }
            else
            {
                if (DtCombined.Rows.Count > 0)
                {
                    pnlAIE.Visible = true;
                    grdAIEBLInfo.DataSource = DtCombined;
                    grdAIEBLInfo.DataBind();
                }
                else
                {
                    grdAIEBLInfo.DataSource = new DataTable();
                    grdAIEBLInfo.DataBind();
                }
            }
            txtBLNo.Text = "";
            txtBLNo.Text = "";
            if (DtCombined.Rows.Count != 0)
            {
                btnExcel.Enabled = true;
              
            }

            //for (int z = 0; z < GrdFEIBL.Rows.Count; z++)
            //{
            //    ImageButton imgTemp;
            //    imgTemp = (ImageButton)GrdFEIBL.Rows[z].Cells[0].Controls[0];
            //    string strTempUrl = "";
            //    if (strTranType == "FI")
            //    {
            //        strTempUrl = "window.open('FIBLPrint.aspx?Trantype=" + strTranType + "&blno=" + GrdFEIBL.Rows[z].Cells[2].Text + "','BL','menubar=0,toolbar=0,titlebar=no,close=0,resizable=0,scrollbars=0');return false;";
            //        imgTemp.Attributes.Add("OnClick", strTempUrl);
            //    }
            //}
            //for (int x = 0; x < GrdFEBL.Rows.Count; x++)
            //{
            //    ImageButton imgTemp;
            //    imgTemp = (ImageButton)GrdFEBL.Rows[x].Cells[0].Controls[0];
            //    string strTempUrl = "";
            //    if (strTranType == "FE")
            //    {
            //        strTempUrl = "window.open('FEBLPrint.aspx?Trantype=" + strTranType + "&blno=" + GrdFEBL.DataKeys[x].Values[1].ToString() + "','BL','height=800,width=750,left=50,menubar=0,toolbar=0,titlebar=no,close=0,resizable=0,scrollbars=0');return false;";
            //        imgTemp.Attributes.Add("OnClick", strTempUrl);
            //    }
            //}
            //for (int y = 0; y < grdAIEBLInfo.Rows.Count; y++)
            //{
            //    ImageButton imgTemp;
            //    imgTemp = (ImageButton)grdAIEBLInfo.Rows[y].Cells[0].Controls[0];
            //    string strTempUrl = "";
            //    strTempUrl = "window.open('AIEBLPrint.aspx?Trantype=" + strTranType + "&blno=" + grdAIEBLInfo.Rows[y].Cells[2].Text + "','BL','menubar=0,toolbar=0,titlebar=no,close=0,resizable=0,scrollbars=0');return false;";
            //    imgTemp.Attributes.Add("OnClick", strTempUrl);
            //}
            Session["DTCombine"] = DtCombined;
        }

        public DataTable CombineData(DataTable DtSource, DataTable dtNew)
        {
            DataTable dtTemp;
            dtTemp = new DataTable();
            dtTemp = DtSource;

            for (int i = 0; i < dtNew.Rows.Count; i++)
            {
                DataRow dtrow = dtTemp.NewRow();

                for (int j = 0; j < dtTemp.Columns.Count; j++)
                {
                    dtrow[j] = dtNew.Rows[i][j];
                }
                dtTemp.Rows.Add(dtrow);
            }
            return dtTemp;
        }

        public string ConvertDate(string strSource)
        {
            //string strTemp = "";
            strSource = strSource.Replace('/', '~');
            return strSource;
        }

        public string ConvertDateReverse(string strSource)
        {
            //string strTemp = "";
            strSource = strSource.Replace('~', '/');
            return strSource;
        }
        protected void btnExcel_Click(object sender, EventArgs e)
        {

            btnview_Click(sender, e);
            DateTime FromDate;
            DateTime ToDate;

            FromDate = DateTime.Parse(cldr.ConvertDate(dtFrom.Text));
            ToDate = DateTime.Parse(cldr.ConvertDate(dtTo.Text));
            if (FromDate > ToDate)
            {
                ScriptManager.RegisterStartupScript(btnExcel, typeof(Button), "DataFound", "alertify.alert('From Date is Lesser than To Date');", true);
                return;
            }

            int[] intTempArray = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            int[] intAIEArray = { 1, 2, 3, 4, 5, 6, 7 };
            int[] intFETempArray = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13 };
            DataTable dtCheck;
            if (strTranType == "FE")
            {
                //dtCheck =(DataTable)Session["DTCombine"];
                //DataTable dt = (DataTable)Grd_FETemp.DataSource;
                //dtCheck = ConvertToExCel.GetDtblData();
                //dtCheck = ConvertToExCel.ConvertGridToDtbl(Grd_FETemp, intFETempArray);
                ExecelDownload();
            }
            else if (strTranType == "FI")
            {
                //dtCheck = ConvertToExCel.ConvertGridToDtbl(GrdFEIBL, intTempArray);
                ExecelDownload();
            }
            else
            {
                //dtCheck = ConvertToExCel.ConvertGridToDtbl(grdAIEBLInfo, intAIEArray);
                ExecelDownload();
            }
            //ConvertToExCel.SetData(dtCheck, "Shipment.csv", ConvertToExCel.ConversionType.Excel);
            ExecelDownload();

           

            btnExcel.Enabled = false;
            cusID = int.Parse(Session["webgroupid"].ToString());

            if (txtBLNo.Text == "" && txtBLNo.Text == "")
            {
                switch (strTranType)
                {
                    case "FE":
                        cusobj.InsWebCustLogDtl(cusID, CustomerDataAccess.RegCustomer.EventType.OceanExports, DateTime.Now, dtFrom.Text + " to" + dtTo.Text + " - " + strTranType + "/Excel");
                        break;
                    case "FI":
                        cusobj.InsWebCustLogDtl(cusID, CustomerDataAccess.RegCustomer.EventType.OceanImports, DateTime.Now, dtFrom.Text + " to" + dtTo.Text + " - " + strTranType + "/Excel");
                        break;
                    case "AE":
                        cusobj.InsWebCustLogDtl(cusID, CustomerDataAccess.RegCustomer.EventType.AirExports, DateTime.Now, dtFrom.Text + " to" + dtTo.Text + " - " + strTranType + "/Excel");
                        break;
                    case "AI":
                        cusobj.InsWebCustLogDtl(cusID, CustomerDataAccess.RegCustomer.EventType.AirImports, DateTime.Now, dtFrom.Text + " to" + dtTo.Text + " - " + strTranType + "/Excel");
                        break;
                }
            }
            else if (txtBLNo.Text != "")
            {
                switch (strTranType)
                {
                    case "FE":
                        cusobj.InsWebCustLogDtl(cusID, CustomerDataAccess.RegCustomer.EventType.OceanExports, DateTime.Now, txtBLNo.Text + "/Excel");
                        break;
                    case "FI":
                        cusobj.InsWebCustLogDtl(cusID, CustomerDataAccess.RegCustomer.EventType.OceanImports, DateTime.Now, txtBLNo.Text + "/Excel");
                        break;
                    case "AE":
                        cusobj.InsWebCustLogDtl(cusID, CustomerDataAccess.RegCustomer.EventType.AirExports, DateTime.Now, txtBLNo.Text + "/Excel");
                        break;
                    case "AI":
                        cusobj.InsWebCustLogDtl(cusID, CustomerDataAccess.RegCustomer.EventType.AirImports, DateTime.Now, txtBLNo.Text + "/Excel");
                        break;
                }
            }

            else if (txtBLNo.Text != "")
            {
                switch (strTranType)
                {
                    case "FE":
                        cusobj.InsWebCustLogDtl(cusID, CustomerDataAccess.RegCustomer.EventType.OceanExports, DateTime.Now, txtBLNo.Text + "/Excel");
                        break;
                    case "FI":
                        cusobj.InsWebCustLogDtl(cusID, CustomerDataAccess.RegCustomer.EventType.OceanImports, DateTime.Now, txtBLNo.Text + "/Excel");
                        break;
                    case "AE":
                        cusobj.InsWebCustLogDtl(cusID, CustomerDataAccess.RegCustomer.EventType.AirExports, DateTime.Now, txtBLNo.Text + "/Excel");
                        break;
                    case "AI":
                        cusobj.InsWebCustLogDtl(cusID, CustomerDataAccess.RegCustomer.EventType.AirImports, DateTime.Now, txtBLNo.Text + "/Excel");
                        break;
                }
            }
            //Response.Redirect("ToExcel.aspx?pmtr=Table");


            
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            if (btnCancel.Text == "Cancel")
            {
                GrdFEIBL.DataSource = new DataTable();
                GrdFEIBL.DataBind();
                GrdFEBL.DataSource = new DataTable();
                GrdFEBL.DataBind();
                grdAIEBLInfo.DataSource = new DataTable();
                grdAIEBLInfo.DataBind();
                Grd_FETemp.DataSource = new DataTable();
                Grd_FETemp.DataBind();
                btnExcel.Enabled = false;
                lblMsg.Text = "";
                btnCancel.Text = "Back";
            }
            else
            {
                Response.Redirect("Default.aspx");
            }
        }

        protected void grdAIEBLInfo_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = grdAIEBLInfo.SelectedRow.RowIndex;
            iframecost.Attributes["src"] = "AEIBLPrintNew.aspx";
            popupfro.Visible = true;
            PopupBL.Show();
            string blno = grdAIEBLInfo.SelectedDataKey["blno"].ToString();
            string flight = grdAIEBLInfo.Rows[index].Cells[4].Text;
            Session["flight"] = flight.ToString();
            Session["Blno"] = blno.ToString();
            Session["Btrantype"] = strTranType.ToString();
            //string strBranch = grdAIEBLInfo.SelectedDataKey["branch"].ToString();
            //Response.Redirect("AIEBLPrint.aspx?bid=" + strBranch + "&lgs=1&uid=" + Request.QueryString["uid"] + "&blno=" + grdAIEBLInfo.SelectedRow.Cells[2].Text + "&Trantype=" + strTranType + "&from=" + ConvertDate(dtFrom.Text) + "&to=" + ConvertDate(dtTo.Text));
        }

        protected void GrdFEBL_SelectedIndexChanged(object sender, EventArgs e)
        {
            //string strTempBranch = GrdFEIBL.SelectedDataKey["branchid"].ToString();
            //Session["blno"]= GrdFEIBL.SelectedRow.Cells[2].Text;
            //DataAccess.DashBoard.DBName dbObj = new DataAccess.DashBoard.DBName(int.Parse(GrdFEIBL.SelectedDataKey["branchid"].ToString()));// GrdFEIBL.Rows[GrdFEIBL.SelectedIndex].Cells[11].Text));
            //Session["dbname"] = DataAccess.DashBoard.DBName.TDBName;

            //iframecost.Attributes["src"] = "BLPrint.aspx";
            //popupfro.Visible = true;
            //PopupBL.Show();
            //string blno = GrdFEBL.SelectedDataKey["blno"].ToString();
            //Session["Blno"] = blno.ToString();
            //Session["Btrantype"] = strTranType.ToString();

            string str_sp = "", str_sf = "", str_RptName = "", str_Script = "";


            if (GrdFEBL.Rows.Count > 0)
            {
                str_RptName = "BL4PAN.rpt";
                Session["str_sfs"] = "{FEBLDetails.blno}='" + GrdFEBL.SelectedDataKey["blno"].ToString() + "'" + "and {FEBLDetails.bid}=" + GrdFEBL.SelectedDataKey["bid"].ToString();
                Session["LoginBranchid"] = GrdFEBL.SelectedDataKey["bid"].ToString();
                DataAccess.Masters.MasterBranch objb = new DataAccess.Masters.MasterBranch();
                str_sp = "location=" + objb.Getbranchname(Convert.ToInt32(GrdFEBL.SelectedDataKey["bid"])) + "~draft=Yes" + "~agent=Yes" + "~non=NO" + "~Doc=" + "FORWARDING PRIVATE LIMITED";
                str_Script = "window.open('../Tools/ReportView1.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";

            }

            ScriptManager.RegisterStartupScript(GrdFEBL, typeof(GridView), "BLRelease", str_Script, true);
            switch (strTranType)
            {
                case "FE":
                    cusobj.InsWebCustLogDtl(int.Parse(Request.QueryString["uid"]), CustomerDataAccess.RegCustomer.EventType.OceanExports, DateTime.Now, Session["Blno"] + " / BL View");
                    break;
                case "FI":
                    cusobj.InsWebCustLogDtl(int.Parse(Request.QueryString["uid"]), CustomerDataAccess.RegCustomer.EventType.OceanImports, DateTime.Now, Session["Blno"] + " / BL View");
                    break;
                case "AE":
                    cusobj.InsWebCustLogDtl(int.Parse(Request.QueryString["uid"]), CustomerDataAccess.RegCustomer.EventType.AirExports, DateTime.Now, Session["Blno"] + " / BL View");
                    break;
                case "AI":
                    cusobj.InsWebCustLogDtl(int.Parse(Request.QueryString["uid"]), CustomerDataAccess.RegCustomer.EventType.AirImports, DateTime.Now, Session["Blno"] + " / BL View");
                    break;
            }
            //string str = Session["dbname"].ToString();
            //if (strTranType == "FE")
            //    Response.Redirect("FEBLPrint.aspx?bid=" + strTempBranch + "&lgs=1&uid=" + Request.QueryString["uid"] + "&blno=" + GrdFEBL.SelectedDataKey.Values[1].ToString() + "&Trantype=" + strTranType + "&from=" + ConvertDate(dtFrom.Text) + "&to=" + ConvertDate(dtTo.Text));
            //if (strTranType == "FI")
            //    Response.Redirect("FIBLPrint.aspx?bid=" + strTempBranch + "&lgs=1&uid=" + Request.QueryString["uid"] + "&blno=" + GrdFEBL.SelectedDataKey.Values[1].ToString() + "&Trantype=" + strTranType + "&from=" + ConvertDate(dtFrom.Text) + "&to=" + ConvertDate(dtTo.Text));
        }
        protected void GrdFEIBL_SelectedIndexChanged(object sender, EventArgs e)
        {
            //string strTempBranch = GrdFEIBL.SelectedDataKey["branchid"].ToString();
            //Session["blno"]= GrdFEIBL.SelectedRow.Cells[2].Text;
            //DataAccess.DashBoard.DBName dbObj = new DataAccess.DashBoard.DBName(int.Parse(GrdFEIBL.SelectedDataKey["branchid"].ToString()));// GrdFEIBL.Rows[GrdFEIBL.SelectedIndex].Cells[11].Text));
            //Session["dbname"] = DataAccess.DashBoard.DBName.TDBName;
            iframecost.Attributes["src"] = "BLPrint.aspx";
            popupfro.Visible = true;
            PopupBL.Show();
            string blno = GrdFEIBL.SelectedDataKey["blno"].ToString();
            Session["Blno"] = blno.ToString();
            Session["Btrantype"] = strTranType.ToString();


            switch (strTranType)
            {
                case "FE":
                    cusobj.InsWebCustLogDtl(int.Parse(Request.QueryString["uid"]), CustomerDataAccess.RegCustomer.EventType.OceanExports, DateTime.Now, Session["Blno"] + " / BL View");
                    break;
                case "FI":
                    cusobj.InsWebCustLogDtl(int.Parse(Request.QueryString["uid"]), CustomerDataAccess.RegCustomer.EventType.OceanImports, DateTime.Now, Session["Blno"] + " / BL View");
                    break;
                case "AE":
                    cusobj.InsWebCustLogDtl(int.Parse(Request.QueryString["uid"]), CustomerDataAccess.RegCustomer.EventType.AirExports, DateTime.Now, Session["Blno"] + " / BL View");
                    break;
                case "AI":
                    cusobj.InsWebCustLogDtl(int.Parse(Request.QueryString["uid"]), CustomerDataAccess.RegCustomer.EventType.AirImports, DateTime.Now, Session["Blno"] + " / BL View");
                    break;
            }
            //string str = Session["dbname"].ToString();
            //if (strTranType == "FE")
            //    Response.Redirect("FEBLPrint.aspx?bid=" + strTempBranch + "&lgs=1&uid=" + Request.QueryString["uid"] + "&blno=" + GrdFEIBL.SelectedRow.Cells[1].Text + "&Trantype=" + strTranType + "&from=" + ConvertDate(dtFrom.Text) + "&to=" + ConvertDate(dtTo.Text));
            //if (strTranType == "FI")
            //    Response.Redirect("FIBLPrint.aspx?bid=" + strTempBranch + "&lgs=1&uid=" + Request.QueryString["uid"] + "&blno=" + GrdFEIBL.SelectedRow.Cells[1].Text + "&Trantype=" + strTranType + "&from=" + ConvertDate(dtFrom.Text) + "&to=" + ConvertDate(dtTo.Text));
        }
        public void ExecelDownload()
        {
            DataTable dt = Session["DTCombine"] as DataTable;
            dt.Columns.Remove("bid");
            string ExecelName = "";
            if (GrdFEBL.Rows.Count > 0)
            {
                ExecelName = "Ocean Export";
            }
            else if (GrdFEIBL.Rows.Count > 0)
            {
                ExecelName = "Ocean Import";
            }
            else if (grdAIEBLInfo.Rows.Count > 0)
            {
                ExecelName = "Air";
            }


            DateTime FromDate;
            DateTime ToDate;

            FromDate = DateTime.Parse(cldr.ConvertDate(dtFrom.Text));
            ToDate = DateTime.Parse(cldr.ConvertDate(dtTo.Text));
            if (FromDate > ToDate)
            {
                ScriptManager.RegisterStartupScript(btnExcel, typeof(Button), "DataFound", "alertify.alert('From Date is Lesser than To Date');", true);
                return;
            }

            cusID = int.Parse(Request.QueryString["uid"].ToString());

            DataTable dtnew = cusobj.getEBookingPerformance(0, 0, strTranType, FromDate, ToDate, cusID);

            string ExecelName1 = "";

            if (strTranType == "FE")
            {
                ExecelName1 = "Ocean Exports";
            }
            else if (strTranType == "FI")
            {
                ExecelName1 = "Ocean Imports";
            }
            else if (strTranType == "AE")
            {
                ExecelName1 = "Air Exports";
            }
            else if (strTranType == "AI")
            {
                ExecelName1 = "Air Imports";
            }
            else if (strTranType == "CH")
            {
                ExecelName1 = "CHA";
            }

           // ExportToSpreadsheet(dt, ExecelName);
            if (dt.Rows.Count > 0)
            {
                using (XLWorkbook wb = new XLWorkbook())
                {
                    wb.Worksheets.Add(dt, "CustomerBookingInfo");

                    if (dtnew.Rows.Count > 0)
                    {
                        wb.Worksheets.Add(dtnew, "BookingInfo");
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(BtnSelect, typeof(Button), "DataFound", "alertify.alert('No Data Found');", true);
                        return;
                    }
                    Response.Clear();
                    Response.Buffer = true;
                    Response.Charset = "";
                    Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                    Response.AddHeader("content-disposition", "attachment;filename=" + ExecelName1 + ".xls");
                    using (MemoryStream MyMemoryStream = new MemoryStream())
                    {
                        wb.SaveAs(MyMemoryStream);
                        MyMemoryStream.WriteTo(Response.OutputStream);
                        Response.Flush();
                        Response.End();
                    }



                   
                    //if (dt.Rows.Count > 0)
                    //{
                    //    ExecelName = "Ocean Export";
                    //}
                    //else if (dt.Rows.Count > 0)
                    //{
                    //    ExecelName = "Ocean Import";
                    //}
                    //else if (dt.Rows.Count > 0)
                    //{
                    //    ExecelName = "Air";
                    //}
                   
                    /*if (dtnew.Rows.Count > 0)
                    {
                        using (XLWorkbook wb = new XLWorkbook())
                        {
                            wb.Worksheets.Add(dt, "BookingInfo");
                            Response.Clear();
                            Response.Buffer = true;
                            Response.Charset = "";
                            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                            Response.AddHeader("content-disposition", "attachment;filename=" + ExecelName1 + ".xls");
                            using (MemoryStream MyMemoryStream = new MemoryStream())
                            {
                                wb.SaveAs(MyMemoryStream);
                                MyMemoryStream.WriteTo(Response.OutputStream);
                                Response.Flush();
                                Response.End();
                            }
                        }
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(BtnSelect, typeof(Button), "DataFound", "alertify.alert('No Data Found');", true);
                        return;
                    }*/







                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(BtnSelect, typeof(Button), "DataFound", "alertify.alert('No Data Found');", true);
                return;
            }
        }

        protected void GrdFEBL_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                for (int i = 0; i < e.Row.Cells.Count; i++)
                {
                    if (e.Row.Cells[i].Text == "&nbsp;")
                    {
                        e.Row.Cells[i].Text = "";
                    }
                    else
                    {
                        e.Row.Cells[i].ToolTip = e.Row.Cells[i].Text;
                    }
                    e.Row.Attributes.Add("onmouseover", "this.originalcolor=this.style.backgroundColor;" + " this.style.backgroundColor='#FDCB0A';");
                    e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalcolor;");
                    e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(GrdFEBL, "Select$" + e.Row.RowIndex);
                    e.Row.Attributes["style"] = "cursor:pointer";
                }
            }
        }

        protected void GrdFEIBL_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                for (int i = 0; i < e.Row.Cells.Count; i++)
                {
                    if (e.Row.Cells[i].Text == "&nbsp;")
                    {
                        e.Row.Cells[i].Text = "";
                    }
                    else
                    {
                        e.Row.Cells[i].ToolTip = e.Row.Cells[i].Text;
                    }
                    e.Row.Attributes.Add("onmouseover", "this.originalcolor=this.style.backgroundColor;" + " this.style.backgroundColor='#FDCB0A';");
                    e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalcolor;");
                    e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(GrdFEIBL, "Select$" + e.Row.RowIndex);
                    e.Row.Attributes["style"] = "cursor:pointer";
                }
            }
        }

        protected void grdAIEBLInfo_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                for (int i = 0; i < e.Row.Cells.Count; i++)
                {
                    if (e.Row.Cells[i].Text == "&nbsp;")
                    {
                        e.Row.Cells[i].Text = "";
                    }
                    else
                    {
                        e.Row.Cells[i].ToolTip = e.Row.Cells[i].Text;
                    }
                    e.Row.Attributes.Add("onmouseover", "this.originalcolor=this.style.backgroundColor;" + " this.style.backgroundColor='#FDCB0A';");
                    e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalcolor;");
                    e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(grdAIEBLInfo, "Select$" + e.Row.RowIndex);
                    e.Row.Attributes["style"] = "cursor:pointer";
                }
            }
        }

        protected void btnview_Click(object sender, EventArgs e)
        {
           
           // ExportToSpreadsheet(dt, ExecelName);
        }



        public static void ExportToSpreadsheet(DataTable table, string name)
        {
            HttpContext context = HttpContext.Current;

            context.Response.ClearContent();
            context.Response.ContentType = "text/vnd.ms-excel";
            context.Response.AppendHeader("Content-Disposition", "attachment; filename=" + name + ".xls");

            string tab = "";
            foreach (DataColumn dc in table.Columns)
            {
                context.Response.Write(tab + dc.ColumnName);
                tab = "\t";
            }
            context.Response.Write("\n");
            context.Response.Write("\n");
            int i;
            foreach (DataRow dr in table.Rows)
            {
                tab = "";
                for (i = 0; i < table.Columns.Count; i++)
                {
                    context.Response.Write(tab + dr[i].ToString());
                    tab = "\t";
                }
                context.Response.Write("\n");
            }
            context.Response.End();
        }

       

        protected void ddl_find_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddl_find.SelectedItem.Text == "Shipper" || ddl_find.SelectedItem.Text == "Consignee")
             {
                 txt_customer.Visible = true;
                 txtBLNo.Visible = false;
             }
             else
             {
                 txt_customer.Visible = false;
                 txtBLNo.Visible = true;
             }
        }

        protected void txt_customer_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (Hiddenshipper.Value != "0")
                {
                    // txt_consignee.Focus();
                }
                else
                {

                    txt_customer.Focus();
                    ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.TextBox), "logix", "alertify.alert('Enter Valid SHIPPER');", true);
                    return;
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.TextBox), "logix", "alertify.alert('" + message + "');", true);
            }
        }

    }
}