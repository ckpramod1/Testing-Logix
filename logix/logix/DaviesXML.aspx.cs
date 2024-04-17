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
namespace logix
{
    public partial class DaviesXML : System.Web.UI.Page
    {
        public string chkstatus, strblno, strvessel, strjobno, strcontainer, strsize, strseal, strvoyage, strmblno;
        public string strpor, strpol, strpod, strfd, strshippername, strconsgname, strshipaddress, strconsaddress, strpkgtype, strcontpkgtype;
        public int intbranchid, intpkgs, intcontpkgs, i, inttotlength, x, y, z;
        public DateTime dtEta;
        public double dblwt, totkilos, grosswt;
        //public StreamWriter sw;
        //public FileStream fs;
        DataTable DT = new DataTable();
        DataTable Dtcon = new DataTable();
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
            if (Session["username"] == null)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alertify.alert('Session TimeOut');window.open('"+ Session["Site"].ToString() + "/','_top');", true);
            }
            strTranType = "FE";
            if (!IsPostBack)
            {
                Frmobj = new Calendar(this.Page, dtFrom, ImgFrm);
                Toobj = new Calendar(this.Page, dtTo, ImgTo);
                DateTime dtmTemp = DateTime.Now.AddDays(-30);
                dtFrom.Text = cldr.ConvertDate(dtmTemp.ToShortDateString());
            }
            intUID = int.Parse(Request.QueryString["uid"].ToString());
        }
        protected void Save_Click(object sender, EventArgs e)
        {
            DaviesTurnerXML();
            btnXML.Enabled = true;
        }

        protected void BtnSelect_Click(object sender, EventArgs e)
        {
            ////cusID = int.Parse(Session["webgroupid"].ToString());
            //lblMsg.Text = "";
            //cusobj.InsWebCustLogDtl(cusID, CustomerDataAccess.RegCustomer.EventType.OceanExports, DateTime.Now, dtFrom.Text + " to" + dtTo.Text + " - " + strTranType + " BL Find");
            //Dt = new DataTable();
            //Dt = objAgent.GetAgentXML4Davis(DateTime.Parse(cldr.ConvertDate(dtFrom.Text)), DateTime.Parse(cldr.ConvertDate(dtTo.Text)), intUID);
            //grdDavis.DataSource = Dt;
            //grdDavis.DataBind();
            //if (Dt.Rows.Count == 0)
            //    lblMsg.Text = "Data Not Found";
            //else
            //    lblMsg.Text = "";
            btnXML.Enabled = false;

            if (txtconno.Text == "")
            {
                //cusID = int.Parse(Session["webgroupid"].ToString());
                lblMsg.Text = "";
                cusobj.InsWebCustLogDtl(cusID, CustomerDataAccess.RegCustomer.EventType.OceanExports, DateTime.Now, dtFrom.Text + " to" + dtTo.Text + " - " + strTranType + " BL Find");
                Dt = new DataTable();
                Dt = objAgent.GetAgentXML4Davis(DateTime.Parse(cldr.ConvertDate(dtFrom.Text)), DateTime.Parse(cldr.ConvertDate(dtTo.Text)), intUID);
                grdDavis.DataSource = Dt;
                grdDavis.DataBind();
                if (Dt.Rows.Count == 0)
                    lblMsg.Text = "Data Not Found";
                else
                    lblMsg.Text = "";
            }
            else
            {
                //cusID = int.Parse(Session["webgroupid"].ToString());
                lblMsg.Text = "";
                //cusobj.InsWebCustLogDtl(cusID, CustomerDataAccess.RegCustomer.EventType.OceanExports, DateTime.Now, dtFrom.Text + " to" + dtTo.Text + " - " + strTranType + " BL Find");
                Dtcon = new DataTable();
                Dtcon = objAgent.GetAgentXMLcontainer(txtconno.Text, intUID);
                grdDavis.DataSource = Dtcon;
                grdDavis.DataBind();
                if (Dtcon.Rows.Count == 0)
                    lblMsg.Text = "Data Not Found";
                else
                    lblMsg.Text = "";

            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            grdDavis.DataSource = null;
            grdDavis.DataBind();
            grdBL.DataSource = null;
            grdBL.DataBind();
            btnXML.Enabled = false;
            txtconno.Text = "";
        }

        public void DaviesTurnerXML()
        {

            DataSet dsTemp = new DataSet();
            DataTable dtTemp, dtTemp1, dtTemp2, dtTemp3;

            dsTemp = objAgent.GetAgentXML(int.Parse(hidJobNo.Value), int.Parse(hidBranchID.Value), "FE", int.Parse(hidDivID.Value));
            cusobj.InsWebCustLogDtl(intUID, CustomerDataAccess.RegCustomer.EventType.XML, DateTime.Now, hidJobNo.Value + "-" + hidBranchID.Value);
            dtTemp = dsTemp.Tables[0];
            dtTemp1 = dsTemp.Tables[1];
            dtTemp2 = dsTemp.Tables[2];
            dtTemp3 = dsTemp.Tables[3];

            string strTmp;
            strTmp = "";
            strTmp = "<?xml version=" + '"' + "1.0" + '"' + " encoding=" + '"' + "utf-8" + '"' + " ?>";
            strTmp += "<job>";
            strTmp += "<mbl>";
            strTmp += "<mblno>" + dtTemp.Rows[0]["mblno"].ToString() + "</mblno>";
            strTmp += "<mbldate>" + dtTemp.Rows[0]["mbldate"].ToString() + "</mbldate>";
            strTmp += "<vessel>" + dtTemp.Rows[0]["vessel"].ToString() + "</vessel>";
            strTmp += "<voyage>" + dtTemp.Rows[0]["voyage"].ToString() + "</voyage>";
            strTmp += "<sailedon>" + dtTemp.Rows[0]["sailedon"].ToString() + "</sailedon>";//   Shipped On Date'
            strTmp += "<jobtype>" + dtTemp.Rows[0]["jobtype"].ToString() + "</jobtype>";//      'FCL/LCL/Consol'
            strTmp += "</mbl>";
            //HBL Details for the Job #
            for (x = 0; x < dtTemp1.Rows.Count; x++)
            {
                strTmp += "<hbl>";
                strTmp += "<blno>" + dtTemp1.Rows[x]["blno"].ToString() + "</blno>";
                strTmp += "<bldate>" + dtTemp1.Rows[x]["bldate"].ToString() + "</bldate>";
                strTmp += "<issuedat>" + dtTemp1.Rows[x]["issuedat"].ToString() + "</issuedat>";
                strTmp += "<freightstatus>" + dtTemp1.Rows[x]["freightstatus"].ToString() + "</freightstatus>";
                strTmp += "<incoterms>" + dtTemp1.Rows[x]["incoterms"].ToString() + "</incoterms>";

                string strTempPo = "";
                //PONo(s) of a HBL
                for (z = 0; z < dtTemp3.Rows.Count; z++)
                {
                    if (dtTemp1.Rows[x]["blno"].ToString() == dtTemp3.Rows[z]["blno"].ToString())
                    {
                        if (z == 0)
                            strTempPo = dtTemp3.Rows[z][1].ToString();
                        else
                            strTempPo = strTempPo + "," + dtTemp3.Rows[z][1].ToString();
                    }
                }
                strTmp += "<pono>" + strTempPo + "</pono>";

                strTmp += "<shipperasperbl>" + dtTemp1.Rows[x]["shipper"].ToString().Replace("&", "&amp;") + "</shipperasperbl>";
                strTmp += "<shippername>" + dtTemp1.Rows[x]["mshippername"].ToString().Replace("&", "&amp;") + "</shippername>";
                strTmp += "<saddress>" + dtTemp1.Rows[x]["mshipperaddress"].ToString().Replace("&", "&amp;") + "</saddress>";
                strTmp += "<scity>" + dtTemp1.Rows[x]["mshippercity"].ToString().Replace("&", "&amp;") + "</scity>";

                strTmp += "<consigneeasperbl>" + dtTemp1.Rows[x]["consignee"].ToString().Replace("&", "&amp;") + "</consigneeasperbl>";
                strTmp += "<consigneename>" + dtTemp1.Rows[x]["mcneename"].ToString().Replace("&", "&amp;") + "</consigneename>";
                strTmp += "<caddress>" + dtTemp1.Rows[x]["mcneeaddress"].ToString().Replace("&", "&amp;") + "</caddress>";
                strTmp += "<ccity>" + dtTemp1.Rows[x]["mcneecity"].ToString().Replace("&", "&amp;") + "</ccity>";

                strTmp += "<notifyasperbl>" + dtTemp1.Rows[x]["notify"].ToString().Replace("&", "&amp;") + "</notifyasperbl>";
                strTmp += "<notifypartyname>" + dtTemp1.Rows[x]["mnotifyname"].ToString().Replace("&", "&amp;") + "</notifypartyname>";
                strTmp += "<naddress>" + dtTemp1.Rows[x]["mnotifyaddress"].ToString().Replace("&", "&amp;") + "</naddress>";
                strTmp += "<ncity>" + dtTemp1.Rows[x]["mnotifycity"].ToString().Replace("&", "&amp;") + "</ncity>";

                strTmp += "<por>" + dtTemp1.Rows[x]["por"].ToString().Replace("&", "&amp;") + "</por>";
                strTmp += "<pol>" + dtTemp1.Rows[x]["pol"].ToString().Replace("&", "&amp;") + "</pol>";
                strTmp += "<pod>" + dtTemp1.Rows[x]["pod"].ToString().Replace("&", "&amp;") + "</pod>";
                strTmp += "<fd>" + dtTemp1.Rows[x]["fd"].ToString().Replace("&", "&amp;") + "</fd>";
                strTmp += "<grwt>" + dtTemp1.Rows[x]["grwt"].ToString() + "</grwt>";
                strTmp += "<ntwt>" + dtTemp1.Rows[x]["ntwt"].ToString() + "</ntwt>";
                strTmp += "<volume>" + dtTemp1.Rows[x]["volume"].ToString() + "</volume>";
                strTmp += "<noofpkgs>" + dtTemp1.Rows[x]["noofpkgs"].ToString() + "</noofpkgs>";
                strTmp += "<packagtype>" + dtTemp1.Rows[x]["packagtype"].ToString().Replace("&", "&amp;") + "</packagtype>";
                strTmp += "<marks>" + dtTemp1.Rows[x]["marks"].ToString().Replace("&", "&amp;") + "</marks>";
                strTmp += "<description>" + dtTemp1.Rows[x]["description"].ToString().Replace("&", "&amp;") + "</description>";
                //'--Container details for HBL--
                for (y = 0; y < dtTemp2.Rows.Count; y++)
                {
                    if (dtTemp1.Rows[x]["blno"].ToString() == dtTemp2.Rows[y]["blno"].ToString())
                    {
                        strTmp += "<container>";
                        strTmp += "<containerno>" + dtTemp2.Rows[y]["containerno"].ToString() + "</containerno>";
                        strTmp += "<sizetype>" + dtTemp2.Rows[y]["sizetype"].ToString().Replace("&", "&amp;") + "</sizetype>";
                        strTmp += "<sealno>" + dtTemp2.Rows[y]["sealno"].ToString().Replace("&", "&amp;") + "</sealno>";
                        strTmp += "</container>";
                    }
                }
                strTmp += "</hbl>";
            }
            strTmp += "</job>";
            strTmp = strTmp.Replace("\r", "");
            strTmp = strTmp.Replace("\n", "");

            ConvertToExCel.SetData(strTmp, hidJobNo.Value + ".xml", ConvertToExCel.ConversionType.XML);
            Response.Redirect("ToExcel.aspx?pmtr=String");
        }
        protected void grdDavis_SelectedIndexChanged(object sender, EventArgs e)
        {
            hidBranchID.Value = grdDavis.SelectedDataKey["bid"].ToString();
            hidJobNo.Value = grdDavis.SelectedDataKey["jobno"].ToString();
            hidDivID.Value = grdDavis.SelectedDataKey["cid"].ToString();
            DtCombined = new DataTable();
            DtCombined = objAgent.GetJobsBLNos4Davis(int.Parse(hidJobNo.Value), int.Parse(hidBranchID.Value));
            grdBL.DataSource = DtCombined;
            grdBL.DataBind();
            btnXML.Enabled = true;

        }
    }
}