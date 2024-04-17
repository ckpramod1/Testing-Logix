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
    public partial class eBL : System.Web.UI.Page
    {
        CustomerDataAccess.RegCustomer cusobj = new CustomerDataAccess.RegCustomer();
        //DataAccess.Masters.MasterCustomer MCus = new DataAccess.Masters.MasterCustomer();
        public DateTime Frm, To;
        string strTranType;
        int cusID;
        DataTable DtCombined;
        Calendar Frmobj, Toobj;
        Calendar cldr = new Calendar();
        Global glObj = new Global();
        public string strTo, strFrom;
        CustomerDataAccess.PODetails Logobj = new CustomerDataAccess.PODetails();
        DataAccess.LogDetails da_obj_Log = new DataAccess.LogDetails();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] == null)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alertify.alert('Session TimeOut');window.open('"+ Session["Site"].ToString() + "/','_top');", true);
            }
            if (!IsPostBack)
            {
                //Frmobj = new Calendar(this.Page, dtFrom, ImgFrm);
                // Toobj = new Calendar(this.Page, dtTo, ImgTo);
                //DateTime dtmTMPSS = new DateTime();
                //dtmTMPSS = DateTime.Now.AddDays(-30);
                //dtFrom.Text = dtmTMPSS.ToString("dd/MM/yyyy"); //cldr.ConvertDate(DateTime.Now.AddDays(-30).ToShortDateString());


                DateTime dtmTMPSS = new DateTime();
                dtmTMPSS = DateTime.Now.AddDays(-30);
                dtFrom.Text = dtmTMPSS.ToString("dd/MM/yyyy");
                dtTo.Text = Convert.ToDateTime(Logobj.GetDate().ToShortDateString()).ToString("dd/MM/yyyy");
            }
            strTranType = "FE";
            //ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "eBL", "alertify.alert('" + strTranType + "');", true);

            pnlOIE.Visible = true;

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
                //Response.Redirect("UserLogin.aspx");
                Session.Abandon();
                Session.Clear();
                Session.RemoveAll();
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "window.open('"+ Session["Site"].ToString() + "/','_top');", true);
            }
            else
            {
                LBLTitle.Text = "e-BL";

                //GrdFEIBL.Columns[0].Visible = false;
                //GrdFEIBL.Columns[4].HeaderText = "Voyage";
            }
        }
        protected void BtnSelect_Click(object sender, EventArgs e)
        {
            cusID = int.Parse(Request.QueryString["uid"].ToString());
            cusobj.InsWebCustLogDtl(cusID, CustomerDataAccess.RegCustomer.EventType.OceanExports, DateTime.Now, dtFrom.Text + " to" + dtTo.Text + " - " + strTranType + " BL Find");
            lblMsg.Text = "";

            DtCombined = cusobj.SelCusEBLInfo(cusID, strTranType, DateTime.Parse(cldr.ConvertDate(dtFrom.Text)), DateTime.Parse(cldr.ConvertDate(dtTo.Text)));

            if (DtCombined.Rows.Count == 0)
                lblMsg.Text = "No data available";
            else
                lblMsg.Text = "";

            GrdFEIBL.DataSource = DtCombined;
            GrdFEIBL.DataBind();

            for (int z = 0; z < GrdFEIBL.Rows.Count; z++)
            {
                GrdFEIBL.SelectedIndex = z;
                ImageButton imgTemp;
                imgTemp = (ImageButton)GrdFEIBL.Rows[z].Cells[0].Controls[0];
                string strTempUrl = "";
                strTempUrl = "window.open('eBLPrint.aspx?&bid=" + GrdFEIBL.SelectedDataKey["branchid"].ToString() + "&divisionid=" + GrdFEIBL.SelectedDataKey["divisionid"].ToString() + "&Trantype=" + strTranType + "&blno=" + GrdFEIBL.Rows[z].Cells[2].Text + "','BL','menubar=0,toolbar=0,titlebar=no,close=0,resizable=0,scrollbars=0');return false;";
                imgTemp.Attributes.Add("OnClick", strTempUrl);
                GrdFEIBL.SelectedIndex = -1;
            }

            //da_obj_Log.InsLogDetail(Convert.ToInt32(Session["webgroupid"].ToString()),2, 5, Convert.ToInt32(Session["LoginDivisionId"]), "EBL");
            cusobj.InsWebCustLogDtl(Convert.ToInt32(Session["webgroupid"].ToString()), CustomerDataAccess.RegCustomer.EventType.LoginSuccess, DateTime.Now, Convert.ToInt32(Session["LoginDivisionId"]) + "EBL");
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            if (btnCancel.Text == "Cancel")
            {
                GrdFEIBL.DataSource = null;
                GrdFEIBL.DataBind();
                lblMsg.Text = "";
                btnCancel.Text = "Back";

            }
            else
            {
                Response.Redirect("Default.aspx");
            }

        }
        public string ConvertDateReverse(string strSource)
        {
            strSource = strSource.Replace('~', '/');
            return strSource;
        }

        public string ConvertDate(string strSource)
        {
            strSource = strSource.Replace('/', '~');
            return strSource;
        }


        //protected void GrdFEIBL_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    string strTempBranch = GrdFEIBL.SelectedDataKey["branchid"].ToString();
        //    string strTempDiv = GrdFEIBL.SelectedDataKey["divisionid"].ToString();
        //    //string strTempDiv = GrdFEIBL.SelectedRow.Cells[11].Text;
        //    //cusobj.InsWebCustLogDtl(int.Parse(Request.QueryString["uid"]), CustomerDataAccess.RegCustomer.EventType.OceanExports, DateTime.Now, Session["blno"] + " / BL View");
        //    Response.Redirect("eBLPrint.aspx?&bid=" + strTempBranch + "&lgs=1&uid=" + Request.QueryString["uid"] + "&divisionid=" + strTempDiv + "&blno=" + GrdFEIBL.SelectedRow.Cells[2].Text + "&Trantype=" + strTranType + "&from=" + ConvertDate(dtFrom.Text) + "&to=" + ConvertDate(dtTo.Text));
        //    //Response.Redirect("BLPrint.aspx");
        //    //MvwMain.ActiveViewIndex = 1;
        //}
        protected void btnSave_Click(object sender, EventArgs e)
        {

        }
        protected void btnView_Click(object sender, EventArgs e)
        {

        }
    }
}