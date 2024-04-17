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
using System.IO;
namespace logix
{
    public partial class XML : System.Web.UI.Page
    {
        public string chkstatus, strblno, strvessel, strjobno, strcontainer, strsize, strseal, strvoyage, strmblno;
        public string strpor, strpol, strpod, strfd, strshippername, strconsgname, strshipaddress, strconsaddress, strpkgtype, strcontpkgtype;
        public int intbranchid, intpkgs, intcontpkgs, i, inttotlength, x, y, z;
        public DateTime dtEta;
        public double dblwt, totkilos, grosswt;
        public StreamWriter sw;
        public FileStream fs;
        DataTable DT = new DataTable();
        DataTable Dtjob = new DataTable();
        //DataAccess.ForwardingExports.BLDetails feblobj = new DataAccess.ForwardingExports.BLDetails();
        //DataAccess.ForwardingExports.JobInfo fejobobj = new DataAccess.ForwardingExports.JobInfo();
        //DataAccess.Masters.MasterVessel vslobj = new DataAccess.Masters.MasterVessel();
        //DataAccess.Masters.MasterPort portobj = new DataAccess.Masters.MasterPort();
        //DataAccess.Masters.MasterPackages pkgobj = new DataAccess.Masters.MasterPackages();
        //DataAccess.Masters.MasterCustomer MCus = new DataAccess.Masters.MasterCustomer();

        CustomerDataAccess.RegCustomer cusobj = new CustomerDataAccess.RegCustomer();
        CustomerDataAccess.AgentXML objAgent = new CustomerDataAccess.AgentXML();
        public DateTime Frm, To;
        string strTranType, strBLno, strStatus;
        int cusID;
        DataTable Dt, dtCustIDs, DtCombined;
        DataColumn Dc;
        Calendar Frmobj, Toobj;
        Calendar cldr = new Calendar();
        Global glObj = new Global();
        int intUID = 0;
        public string strETA = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            strTranType = "FE";
            if (!IsPostBack)
            {
               // SetFocus(this.Page, txtBLNo);
                Frmobj = new Calendar(this.Page, dtFrom, ImgFrm);
                Toobj = new Calendar(this.Page, dtTo, ImgTo);
                DateTime dtmTemp = DateTime.Now.AddDays(-30);
                dtFrom.Text = cldr.ConvertDate(dtmTemp.ToShortDateString());
            }
            intUID = int.Parse(Request.QueryString["uid"].ToString());
        }

        protected void GrdXML_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Session["blno"] = GrdXML.SelectedRow.Cells[2].Text;
            //DataAccess.DashBoard.DBName dbObj = new DataAccess.DashBoard.DBName(int.Parse(GrdXML.Rows[GrdXML.SelectedIndex].Cells[8].Text));
            //Session["dbname"] = DataAccess.DashBoard.DBName.TDBName;
            //string str = Session["dbname"].ToString();
            //if (strTranType == "FE" || strTranType == "FI")
            //    Response.Redirect("FIEAIEBLPrint.aspx?blno=" + GrdXML.SelectedRow.Cells[2].Text + "&Trantype=" + strTranType);
            //else if (strTranType == "AE" || strTranType == "AI")
            //    Response.Redirect("AIEBLPrint.aspx?blno=" + GrdXML.SelectedRow.Cells[2].Text + "&Trantype=" + strTranType);
            //else { }
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

        //D:\Examples\FileCreation\Default.aspx
        //string strResult = "";
        //string strCrPath = Server.MapPath("XML.aspx");
        //strResult = strCrPath.Replace("XML.aspx", "");
        //return strResult;
        // Get the drive letter in a string

        protected void Save_Click(object sender, EventArgs e)
        {
            HiPageXML();
        }


        public void GetDetails(DataTable dtBLDetail)
        {
            DT = dtBLDetail;
            if (DT.Rows.Count > 0)
            {
                strvessel = DT.Rows[0]["vessel"].ToString();
                strvoyage = DT.Rows[0]["voyage"].ToString();
                strETA = DT.Rows[0]["eta"].ToString();
                strmblno = DT.Rows[0]["mblno"].ToString();
                strpor = DT.Rows[0]["por"].ToString();
                strpol = DT.Rows[0]["pol"].ToString();
                strpod = DT.Rows[0]["pod"].ToString();
                strfd = DT.Rows[0]["fd"].ToString();
                intpkgs = int.Parse(DT.Rows[0]["noofpkgs"].ToString());
                strpkgtype = DT.Rows[0]["units"].ToString();
                strshippername = DT.Rows[0]["sname"].ToString();
                strshipaddress = DT.Rows[0]["saddress"].ToString();
                strconsgname = DT.Rows[0]["conname"].ToString();
                strconsaddress = DT.Rows[0]["caddress"].ToString();
                grosswt = double.Parse(DT.Rows[0]["grweight"].ToString());
            }
        }


        protected void BtnSelect_Click(object sender, EventArgs e)
        {
            cusID = int.Parse(Session["webgroupid"].ToString());
            lblMsg.Text = "";

            if (txtBkgNo.Text != "" && txtBLNo.Text != "")
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
                }
            }

            else if (txtBkgNo.Text != "")
            {
                switch (strTranType)
                {
                    case "FE":
                        cusobj.InsWebCustLogDtl(cusID, CustomerDataAccess.RegCustomer.EventType.OceanExports, DateTime.Now, txtBkgNo.Text + " BL Find");
                        break;
                    case "FI":
                        cusobj.InsWebCustLogDtl(cusID, CustomerDataAccess.RegCustomer.EventType.OceanImports, DateTime.Now, txtBkgNo.Text + " BL Find");
                        break;
                    case "AE":
                        cusobj.InsWebCustLogDtl(cusID, CustomerDataAccess.RegCustomer.EventType.AirExports, DateTime.Now, txtBkgNo.Text + " BL Find");
                        break;
                    case "AI":
                        cusobj.InsWebCustLogDtl(cusID, CustomerDataAccess.RegCustomer.EventType.AirImports, DateTime.Now, txtBkgNo.Text + " BL Find");
                        break;
                }
            }

            if (txtBLNo.Text.Trim() != "")
            {
                DtCombined = cusobj.GetBLByBkgBLNo(strTranType, txtBLNo.Text, "BL", 1);
                if (DtCombined.Rows.Count == 0)
                    lblMsg.Text = "";
            }
            else if (txtBkgNo.Text.Trim() != "")
            {
                DtCombined = cusobj.GetBLByBkgBLNo(strTranType, txtBkgNo.Text, "BG", 1);
                if (DtCombined.Rows.Count == 0)
                    lblMsg.Text = "";
            }
            else
            {
                DtCombined = cusobj.SelCusFIEBLInfo(cusID, strTranType, DateTime.Parse(cldr.ConvertDate(dtFrom.Text)), DateTime.Parse(cldr.ConvertDate(dtTo.Text)), 1);
            }
            GrdXML.DataSource = DtCombined;
            GrdXML.DataBind();
            txtBkgNo.Text = "";
            txtBLNo.Text = "";

            if (DtCombined.Rows.Count != 0)
            {
                Save.Enabled = true;
                lblMsg.Text = "";
                pnl1.Visible = true;
            }
            else
            {
                lblMsg.Text = "No data available";
                pnl1.Visible = false;
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            GrdXML.DataSource = null;
            GrdXML.DataBind();
            Save.Enabled = false;
           // SetFocus(this.Page, txtBLNo);
        }
        public void HiPageXML()
        {
            string strTempData = "";

            strTempData = "<?xml version=" + '"' + "1.0" + '"' + " encoding = " + '"' + " UTF-8 " + '"' + "?" + ">";
            strTempData += "~<!-- Sample XML FILE generated by XMLSPY v5 rel. 2 U(http://www.xmlspy.com)-->";
            strTempData += "~<Manifest xmlns:xsi=" + '"' + "http://www.w3.org/2001/XMLSchema-instance xsi:noNamespaceSchemaLocation=" + "C:/Documents and Settings/hyokos/Desktop/XML/AMS Specs/AMS_Manifest_SPEC/XML_BILLofLading_SPEC/NVO/BillOfLading_NVO.xsd" + '"' + ">";
            for (i = 0; i < GrdXML.Rows.Count; i++)
            {
                if (((CheckBox)GrdXML.Rows[i].Cells[7].Controls[1]).Checked == true)
                {
                    DataSet dsTemp = new DataSet();
                    dsTemp = cusobj.GetFEBL4CustLoginXML(GrdXML.Rows[i].Cells[1].Text);
                    strblno = GrdXML.Rows[i].Cells[1].Text;
                    cusobj.InsWebCustLogDtl(intUID, CustomerDataAccess.RegCustomer.EventType.XML, DateTime.Now, GrdXML.Rows[i].Cells[1].Text);

                    GetDetails(dsTemp.Tables[0]);
                    strTempData += "~" + "<BillOfLading>";
                    strTempData += "~" + "<VesselName>" + strvessel + " </VesselName>";
                    strTempData += "~" + "<VesselFlag></VesselFlag>";
                    strTempData += "~" + "<VoyageNumber>" + strvoyage + "</VoyageNumber>";
                    strTempData += "~" + "<ETA>" + strETA + "</ETA>";
                    strTempData += "~" + "<HouseBillNumber>" + strblno + "</HouseBillNumber>";
                    strTempData += "~" + "<MasterBillNumber>" + strmblno + "</MasterBillNumber>";
                    strTempData += "~" + "<PortOfLoad>" + strpol + "</PortOfLoad>";
                    strTempData += "~" + "<PortOfDischarge>" + strpod + "</PortOfDischarge>";
                    strTempData += "~" + "<LastForeignPort>" + strfd + "</LastForeignPort>";
                    strTempData += "~" + "<TotalPieces>" + intpkgs + "</TotalPieces>";
                    strTempData += "~" + "<UnitOfMeasure>" + strpkgtype + "</UnitOfMeasure>";
                    strTempData += "~" + "<TotalKilos>" + grosswt + "</TotalKilos>";
                    strTempData += "~" + "<BillOfLadingType></BillOfLadingType>";
                    strTempData += "~" + "<SCAC_Carrier></SCAC_Carrier>";
                    strTempData += "~" + "<SCAC_Secondary></SCAC_Secondary>";
                    strTempData += "~" + "<AmendmentFlag>R</AmendmentFlag>";
                    strTempData += "~" + "<PlaceOfReceipt>" + strpor + "</PlaceOfReceipt>";
                    strTempData += "~" + "<SendersUniqueReference></SendersUniqueReference>";
                    strTempData += "~" + "<ShipperPartyInfo>";
                    strTempData += "~" + "<Name>" + strshippername + "</Name>";
                    strTempData += "~" + "<Address1>" + strshipaddress + "</Address1>";
                    strTempData += "~" + "</ShipperPartyInfo>";
                    strTempData += "~" + "<ConsigneePartyInfo>";
                    strTempData += "~" + "<Name>" + strconsgname + "</Name>";
                    strTempData += "~" + "<Address1>" + strconsaddress + "</Address1>";
                    strTempData += "~" + "</ConsigneePartyInfo>";

                    DT = dsTemp.Tables[1];
                    for (int j = 0; j < DT.Rows.Count; j++)
                    {
                        strcontainer = DT.Rows[j][0].ToString();
                        strsize = DT.Rows[j][1].ToString();
                        strseal = DT.Rows[j][2].ToString();
                        intcontpkgs = int.Parse(DT.Rows[j][3].ToString());
                        dblwt = double.Parse(DT.Rows[j][4].ToString());
                        totkilos = dblwt * 1000;
                        inttotlength = strcontainer.Length;

                        strTempData += "~" + "<Container>";
                        strTempData += "~" + "<EquipmentInitial>" + strcontainer.Substring(0, 4) + "</EquipmentInitial>";
                        strTempData += "~" + "<EquipmentNum>" + strcontainer.Substring(5, inttotlength - 5).Trim() + "</EquipmentNum>";
                        strTempData += "~" + "<EquipmentTypeCode>" + strsize + "</EquipmentTypeCode>";
                        strTempData += "~" + "<TypeOfServiceCode>" + strseal + "</TypeOfServiceCode>";
                        strTempData += "~" + "<ContainerContent>";
                        strTempData += "~" + "<Quantity>" + intcontpkgs + "</Quantity>";
                        strTempData += "~" + "<UnitOfMeasure></UnitOfMeasure>";// pkgtype not avaible in FECONTAINER Details 
                        strTempData += "~" + "<FreeFormDescription></FreeFormDescription>";
                        strTempData += "~" + "<MarksAndNumbers></MarksAndNumbers>";
                        strTempData += "~" + "<Kilos>" + totkilos + "</Kilos>";
                        strTempData += "~" + "</ContainerContent>";
                        strTempData += "~" + "</Container>";
                    }
                    strTempData += "~" + "</BillOfLading>";
                }
            }
            strTempData += "~</Manifest>";
            strTempData = strTempData.Replace("&", "&amp;");
            ConvertToExCel.SetData(strTempData, "Shipment(s).xml", ConvertToExCel.ConversionType.XML);
            Response.Redirect("ToExcel.aspx?pmtr=String");
        }
    }
}