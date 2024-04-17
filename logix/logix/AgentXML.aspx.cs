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
    public partial class AgentXML : System.Web.UI.Page
    {
        public string chkstatus, strblno, strvessel, strjobno, strcontainer, strsize, strseal, strvoyage, strmblno;
        public string strpor, strpol, strpod, strfd, strshippername, strconsgname, strshipaddress, strconsaddress, strpkgtype, strcontpkgtype;
        public int intbranchid, intpkgs, intcontpkgs, i, inttotlength;
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
        public DateTime Frm, To;
        int cusID;
        DataTable DtCombined;
        int intJobno, intBranchID;
        DataSet dsTemp = new DataSet();
        DataTable dtTemp, dtTemp1, dtTemp2, dtTemp3;
        //DataColumn Dc;
        Calendar Frmobj, Toobj;
        Calendar cldr = new Calendar();
        Global glObj = new Global();
        int intUID = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] == null)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alertify.alert('Session TimeOut');window.open('"+ Session["Site"].ToString() + "/','_top');", true);
            }
            if (!IsPostBack)
            {
                Frmobj = new Calendar(this.Page, dtFrom, ImgFrm);
                Toobj = new Calendar(this.Page, dtTo, ImgTo);
                DateTime dtmTemp = DateTime.Now.AddDays(-30);
                dtFrom.Text = cldr.ConvertDate(dtmTemp.ToShortDateString());
            }
            intUID = int.Parse(Request.QueryString["uid"].ToString());
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


        protected void Save_Click(object sender, EventArgs e)
        {
            string strTempData = "";

            strTempData = "<?xml version=" + '"' + "1.0" + '"' + " encoding=" + '"' + "utf-8" + '"' + " ?>";
            strTempData += "\n" + "<job>";
            for (i = 0; i < GrdXML.Rows.Count; i++)
            {
                if (((CheckBox)GrdXML.Rows[i].Cells[6].Controls[1]).Checked == true)
                {
                    GrdXML.SelectedIndex = i;
                    cusobj.InsWebCustLogDtl(intUID, CustomerDataAccess.RegCustomer.EventType.XML, DateTime.Now, GrdXML.Rows[i].Cells[1].Text);
                    intJobno = int.Parse(GrdXML.Rows[i].Cells[1].Text);
                    intBranchID = int.Parse(GrdXML.SelectedDataKey["branchid"].ToString());
                    dsTemp = cusobj.GetAgentXML(intJobno, intBranchID, "FE");

                    dtTemp = dsTemp.Tables[0];
                    dtTemp1 = dsTemp.Tables[1];
                    dtTemp2 = dsTemp.Tables[2];
                    dtTemp3 = dsTemp.Tables[3];

                    //---MBL,Vessel details for the Job #
                    strTempData += "\n" + "<mbl>";
                    strTempData += "\n" + "<mblno>" + dtTemp.Rows[0]["mblno"].ToString() + "</mblno>";
                    strTempData += "\n" + "<mbldate>" + dtTemp.Rows[0]["mbldate"].ToString() + "</mbldate>";
                    strTempData += "\n" + "<vessel>" + dtTemp.Rows[0]["vessel"].ToString() + "</vessel>";
                    strTempData += "\n" + "<voyage>" + dtTemp.Rows[0]["voyage"].ToString() + "</voyage>";
                    strTempData += "\n" + "<sailedon>" + dtTemp.Rows[0]["sailedon"].ToString() + "</sailedon>";
                    strTempData += "\n" + "<jobtype>" + dtTemp.Rows[0]["jobtype"].ToString() + "</jobtype>";
                    strTempData += "\n" + "</mbl>";

                    //---HBL Details for the Job #
                    for (int x = 0; x < dtTemp1.Rows.Count; x++)
                    {
                        strTempData += "\n" + "<hbl>";
                        strTempData += "\n" + "<blno>" + dtTemp1.Rows[x]["blno"].ToString() + "</blno>";
                        strTempData += "\n" + "<bldate>" + dtTemp1.Rows[x]["bldate"].ToString() + "</bldate>";
                        strTempData += "\n" + "<issuedat>" + dtTemp1.Rows[x]["issuedat"].ToString() + "</issuedat>";
                        strTempData += "\n" + "<freightstatus>" + dtTemp1.Rows[x]["freightstatus"].ToString() + "</freightstatus>";
                        strTempData += "\n" + "<incoterms>" + dtTemp1.Rows[x]["incoterms"].ToString() + "</incoterms>";
                        strTempData += "\n" + "<pono>";
                        string strTemp = "";
                        for (int z = 0; z < dtTemp3.Rows.Count; z++)
                        {
                            if (dtTemp1.Rows[x]["blno"].ToString() == dtTemp3.Rows[z]["blno"].ToString())
                            {
                                if (z == 0)
                                    strTemp = dtTemp3.Rows[z][1].ToString();
                                else
                                    strTemp += "," + dtTemp3.Rows[z][1].ToString();
                            }
                        }
                        strTempData += "\n" + strTemp;
                        strTempData += "\n" + "</pono>";
                        strTempData += "\n" + "<shipperasperbl>" + dtTemp1.Rows[x]["shipper"].ToString().Replace("&", "&amp;") + "</shipperasperbl>";
                        strTempData += "\n" + "<shippername>" + dtTemp1.Rows[x]["mshippername"].ToString().Replace("&", "&amp;") + "</shippername>";
                        strTempData += "\n" + "<saddress>" + dtTemp1.Rows[x]["mshipperaddress"].ToString().Replace("&", "&amp;") + "</saddress>";
                        strTempData += "\n" + "<scity>" + dtTemp1.Rows[x]["mshippercity"].ToString().Replace("&", "&amp;") + "</scity>";
                        strTempData += "\n" + "<consigneeasperbl>" + dtTemp1.Rows[x]["consignee"].ToString().Replace("&", "&amp;") + "</consigneeasperbl>";
                        strTempData += "\n" + "<consigneename>" + dtTemp1.Rows[x]["mcneename"].ToString().Replace("&", "&amp;") + "</consigneename>";
                        strTempData += "\n" + "<caddress>" + dtTemp1.Rows[x]["mcneeaddress"].ToString().Replace("&", "&amp;") + "</caddress>";
                        strTempData += "\n" + "<ccity>" + dtTemp1.Rows[x]["mcneecity"].ToString().Replace("&", "&amp;") + "</ccity>";
                        strTempData += "\n" + "<notifyasperbl>" + dtTemp1.Rows[x]["notify"].ToString().Replace("&", "&amp;") + "</notifyasperbl>";
                        strTempData += "\n" + "<notifypartyname>" + dtTemp1.Rows[x]["mnotifyname"].ToString().Replace("&", "&amp;") + "</notifypartyname>";
                        strTempData += "\n" + "<naddress>" + dtTemp1.Rows[x]["mnotifyaddress"].ToString().Replace("&", "&amp;") + "</naddress>";
                        strTempData += "\n" + "<ncity>" + dtTemp1.Rows[x]["mnotifycity"].ToString().Replace("&", "&amp;") + "</ncity>";
                        strTempData += "\n" + "<por>" + dtTemp1.Rows[x]["por"].ToString().Replace("&", "&amp;") + "</por>";
                        strTempData += "\n" + "<pol>" + dtTemp1.Rows[x]["pol"].ToString().Replace("&", "&amp;") + "</pol>";
                        strTempData += "\n" + "<pod>" + dtTemp1.Rows[x]["pod"].ToString().Replace("&", "&amp;") + "</pod>";
                        strTempData += "\n" + "<fd>" + dtTemp1.Rows[x]["fd"].ToString().Replace("&", "&amp;") + "</fd>";
                        strTempData += "\n" + "<grwt>" + dtTemp1.Rows[x]["grwt"].ToString() + "</grwt>";
                        strTempData += "\n" + "<ntwt>" + dtTemp1.Rows[x]["ntwt"].ToString() + "</ntwt>";
                        strTempData += "\n" + "<volume>" + dtTemp1.Rows[x]["volume"].ToString() + "</volume>";
                        strTempData += "\n" + "<noofpkgs>" + dtTemp1.Rows[x]["noofpkgs"].ToString() + "</noofpkgs>";
                        strTempData += "\n" + "<packagtype>" + dtTemp1.Rows[x]["packagtype"].ToString().Replace("&", "&amp;") + "</packagtype>";
                        strTempData += "\n" + "<marks>" + dtTemp1.Rows[x]["marks"].ToString().Replace("&", "&amp;") + "</marks>";
                        strTempData += "\n" + "<description>" + dtTemp1.Rows[x]["description"].ToString().Replace("&", "&amp;") + "</description>";
                        //--Container details for HBL
                        for (int y = 0; y < dtTemp2.Rows.Count; y++)
                        {
                            if (dtTemp1.Rows[x]["blno"].ToString() == dtTemp2.Rows[y]["blno"].ToString())
                            {
                                strTempData += "\n" + "<container>";
                                strTempData += "\n" + "<containerno>" + dtTemp2.Rows[y]["containerno"].ToString() + "</containerno>";
                                strTempData += "\n" + "<sizetype>" + dtTemp2.Rows[y]["sizetype"].ToString().Replace("&", "&amp;") + "</sizetype>";
                                strTempData += "\n" + "<sealno>" + dtTemp2.Rows[y]["sealno"].ToString().Replace("&", "&amp;") + "</sealno>";
                                strTempData += "\n" + "</container>";
                            }
                        }
                        strTempData += "\n" + "</hbl>";
                    }
                }
            }
            strTempData += "\n" + "</job>";
            ConvertToExCel.SetData(strTempData, "Shipment(s).xml", ConvertToExCel.ConversionType.XML);
            Response.Redirect("ToExcel.aspx?pmtr=String");
        }



        protected void BtnSelect_Click(object sender, EventArgs e)
        {
            cusID = int.Parse(Session["webgroupid"].ToString());
            DtCombined = cusobj.GetAgentJobs4XML(cusID, DateTime.Parse(cldr.ConvertDate(dtFrom.Text)), DateTime.Parse(cldr.ConvertDate(dtTo.Text)));
            GrdXML.DataSource = DtCombined;
            GrdXML.DataBind();

            if (DtCombined.Rows.Count != 0)
            {
                Save.Enabled = true;
                pnl1.Visible = true;
            }
            else
            {
                pnl1.Visible = false;
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            GrdXML.DataSource = null;
            GrdXML.DataBind();
            Save.Enabled = false;
            pnl1.Visible = false;
        }
    }
}