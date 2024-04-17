using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using CustomerDataAccess;
using System.IO;
using System.Text;
using System.Web.Services;
using logix;


namespace logix
{
    public partial class CustomerRegistration : System.Web.UI.Page
    {
        RegCustomer custObj = new RegCustomer();
        //DataAccess.Masters.MasterCountry ctryObj = new DataAccess.Masters.MasterCountry();
        public string strName, strCustType, strContPerson, strAddr, strCity, strZip, strPhone, strFax, strEmail;
        public string strCtrlLists, strMsgLists, strDtypeLists;
        Global glObj = new Global();
        private string SCRIPT_DOFOCUS = Global.SCRIPT_DOFOCUS;
        public MailBox mailObj;
        public string strTempMailContent = "";
        char chrDivision = 'M';
        //string strDivision = "PL Shipping and Logistics Pvt Ltd";
        string strDivision = "FORWARDING PRIVATE LIMITED";
        DataTable Dt = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
           
            ((ScriptManager)Page.FindControl("ScriptManager1")).RegisterPostBackControl(btnSave);
            if (Request.QueryString["div"] != null)
            {
                chrDivision = Convert.ToChar(Request.QueryString["div"]);
            }
           
            if (!IsPostBack)
            {
                txtCompanyName.Focus();
                strCtrlLists = txtCompanyName.ClientID + "~" + txtContPerson.ClientID + "~" + txtAddr.ClientID + "~" + txtCity.ClientID + "~" + txtZip.ClientID + "~" + txtPhone.ClientID + "~" + txtFax.ClientID + "~" + txtEMail.ClientID + "~" + txtrefby.ClientID;
                strMsgLists = "Company Name" + "~" + "Contact Person" + "~" + "Address" + "~" + "City" + "~" + "Zip Code" + "~" + "Phone No" + "~" + "Fax No" + "~" + "eMail-ID" + "~" + "Referredby-ID";
                strDtypeLists = "String" + "~" + "String" + "~" + "String" + "~" + "String" + "~" + "String" + "~" + "String" + "~" + "String" + "~" + "EMail" + "~" + "String";
                img_Logo.ImageUrl = "images/MRnewrpt1.png";

                btnSave.Attributes.Add("OnClick", "return IsValid('" + strCtrlLists + "','" + strMsgLists + "','" + strDtypeLists + "')");
                //this.Page.Form.Attributes.Add("OnKeyDown", "return FocusNextControl();");        
                //mailObj = new MailBox(this.Page, txtEMail);
                Global.HookOnFocus(this.Page as Control);
                FillBranch();
            }
            ScriptManager.RegisterStartupScript(this.txtCompanyName, typeof(CustomerRegistration), "ScriptDoFocus", SCRIPT_DOFOCUS.Replace("REQUEST_LASTFOCUS", Request["__LASTFOCUS"]), true);
        }

        [WebMethod]
        public static List<string> GetLikePort(string prefix)
        {
            List<string> List_Result = new List<string>();
            RegCustomer custObj = new RegCustomer();
            DataTable dtCarrier = new DataTable();
            dtCarrier = custObj.selPortname4reg(prefix.ToUpper());

            List_Result = Fn_DatatableToList_string(dtCarrier, "portname", "countryname");
            return List_Result;
        }

        public static List<string> Fn_DatatableToList_string(DataTable dt, string str_Textfield, string str_Valuefield)
        {
            List<string> lst_details = new List<string>();
            lst_details = (from r in dt.AsEnumerable()
                           select r.Field<string>(str_Textfield) + "~" + r.Field<string>(str_Valuefield).ToString()).ToList();

            return lst_details;
        }

        private void FillBranch()
        {
            txtbranchoff.Items.Clear();
            Dt = custObj.GetBranchByDivID(1);
            if (Dt.Rows.Count > 0)
            {
                for (int i = 0; i <= Dt.Rows.Count - 1; i++)
                {
                    txtbranchoff.Items.Add(Dt.Rows[i]["branch"].ToString());
                }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            //if (recaptcha.IsValid)
            //{


                strDivision = "FORWARDING PRIVATE LIMITED";

                try
                {
                    if (custObj.ChkRegCust(txtCompanyName.Text.Trim()))
                    {
                        GetData();
                        custObj.InsRegDetails(strName, strCustType, strAddr, strCity, strZip, strPhone, strFax, strEmail, strContPerson, chrDivision, txtrefby.Text, txtbranchoff.SelectedItem.Text);
                        strTempMailContent = "<html><body style=font-family:Verdana;font-size:small>";
                        strTempMailContent += "Dear Sir, <br>The below customer has registered in " + strDivision + " website to access<br><br>";
                        strTempMailContent += "<table style=font-family:Verdana;font-size:small>";
                        strTempMailContent += "<tr><td align=right><b>Company&nbsp;Name</b></td><td>:</td><td>" + txtCompanyName.Text + "</td></tr>";
                        strTempMailContent += "<tr><td align=right><b>Type</b></td><td>:</td><td>" + ddlCustType.Text + "</td></tr>";
                        strTempMailContent += "<tr><td align=right><b>Contact&nbsp;Person&nbsp;</b></td><td>:</td><td>" + txtContPerson.Text + "</td></tr>";
                        strTempMailContent += "<tr><td align=right><b>Address</b></td><td>:</td><td>" + txtAddr.Text + "</td></tr>";
                        strTempMailContent += "<tr><td align=right><b>City</b></td><td>:</td><td>" + txtCity.Text + "</td></tr>";
                        strTempMailContent += "<tr><td align=right><b>Counry</b></td><td>:</td><td>" + txtCountry.Text + "</td></tr>";
                        strTempMailContent += "<tr><td align=right><b>Zip</b></td><td>:</td><td>" + txtZip.Text + "</td></tr>";
                        strTempMailContent += "<tr><td align=right><b>Phone</b></td><td>:</td><td>" + txtPhone.Text + "</td></tr>";
                        strTempMailContent += "<tr><td align=right><b>Fax</b></td><td>:</td><td>" + txtFax.Text + "</td></tr>";
                        strTempMailContent += "<tr><td align=right><b>e-Mail</b></td><td>:</td><td>" + txtEMail.Text + "</td></tr>";
                        strTempMailContent += "<tr><td align=right><b>Referredby</b></td><td>:</td><td>" + txtrefby.Text + "</td></tr>";
                        strTempMailContent += "<tr><td align=right><b>Branch Office</b></td><td>:</td><td>" + txtbranchoff.Text + "</td></tr>";
                        strTempMailContent += "</table>";
                        strTempMailContent += "<br>Kindly approve the request";
                        strTempMailContent += "</body></html>";

                        Utility.SendMailnew("", "", "customer registration (" + txtCompanyName.Text + ")", strTempMailContent, "", "",";");
 ScriptManager.RegisterStartupScript(btnSave, typeof(Button), "RegisterCustomer", "alertify.alert('Register Successfully...');", true);
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(btnSave, typeof(Button), "RegisterCustomer", "alertify.alert('Already Registered...');", true);
                    }
                }
                catch (Exception exp)
                {
                   
                }

                ClearFrm();
           // }
        }

        public void GetData()
        {
            strName = txtCompanyName.Text;
            strCustType = ddlCustType.Text;
            strContPerson = txtContPerson.Text;
            strAddr = txtAddr.Text;
            strCity = txtCity.Text;
            strZip = txtZip.Text;
            strPhone = txtPhone.Text;
            strFax = txtFax.Text;
            strEmail = txtEMail.Text;
            if (chrDivision == 'M')
                strDivision = "FORWARDING PRIVATE LIMITED";
        }

        protected void txtCity_TextChanged(object source, EventArgs e)
        {
            if (txtCity.Text != "")
                txtCountry.Text = custObj.GetCountryName(txtCity.Text);
            txtZip.Focus();
        }
        public void ClearFrm()
        {
            txtCompanyName.Text = "";
            txtContPerson.Text = "";
            txtAddr.Text = "";
            txtCity.Text = "";
            txtCountry.Text = "";
            txtZip.Text = "";
            txtPhone.Text = "";
            txtFax.Text = "";
            txtEMail.Text = "";
            txtrefby.Text = "";
            txtbranchoff.SelectedIndex = 0;
            FillBranch();
           // SetFocus(this.Page, txtCompanyName);
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            ClearFrm();
        }
    }
}