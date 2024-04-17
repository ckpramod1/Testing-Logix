using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using System.Data;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using iTextSharp.text.html;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Net.NetworkInformation;
using System.Globalization;
using System.Web.UI.HtmlControls;
using System.Text.RegularExpressions;
using System.Threading;

namespace logix
{
    public partial class Login : System.Web.UI.Page
    {
        string srt_pwd;
        string FADbname;
        public string Password;
        DataTable Dt;

        public string strUName, strPwd;
        public string strCtrlLst, strMsgLst, strDtypeLst;
        //Calendar CldrTemp = new Calendar();

        DataAccess.userlogin objLogin = new DataAccess.userlogin();
        //  DataAccess.HR.Employee obj_emp = new DataAccess.HR.Employee();

        DataAccess.Masters.MasterBranch da_obj_Branch = new DataAccess.Masters.MasterBranch();
        DataAccess.Masters.MasterDivision obj_div = new DataAccess.Masters.MasterDivision();
        DataAccess.HR.Employee da_obj_HrEmp = new DataAccess.HR.Employee();
        DataAccess.LogDetails da_obj_Log = new DataAccess.LogDetails();
        DataAccess.HR.FrontPage FrontpageObj = new DataAccess.HR.FrontPage();
        DataAccess.UserPermission userobj = new DataAccess.UserPermission();
        DataAccess.Masters.MasterPort PortObj = new DataAccess.Masters.MasterPort();
        DataAccess.userlogin obj_login = new DataAccess.userlogin();
        DataAccess.Masters.MasterExRate EXobj = new DataAccess.Masters.MasterExRate();
      
        string Ctrl_List, da, bmmail, bmmailid, rmmailid, strcompanyaddress;
        string Msg_List;
        string Dtype_List;
        string str_Uiid = "";
        DateTime doj, lastupdatedon, logindate, dtdate;
        int month, year, changepass;
        string hostname;
        DataTable dtlogget = new DataTable();
        int loginid;
        string strHTML, filename, strIPAddress, sysname;
        DateTime logoutdate;
        int ipcheck;
        int branchid, divisionId;
        DataTable dtmac = new DataTable();
        Boolean back;
        protected void Page_Load(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "GenerateLabelAfter();", true);

            MasterGlossary objGlossary = new MasterGlossary();
            DataTable dt = new DataTable();
            Random r= new Random();
            int RandomValue = r.Next(1, 77);
            //dt = objGlossary.GetGlossary(RandomValue);
            //txtGlossary.Text = dt.Rows[0]["GlossaryName"].ToString();
            //txtdecr.Text = dt.Rows[0]["Decr"].ToString();
            if (!IsPostBack)
            {
                Session["StrTranType"] = "";
                BindcountryDLL();
                // ddlCompany.Focus();
                //BindDivisionDLL();
                //hf_wrong.Value = "0";

                //back = false;
                //OpenWindow(sender, e);
                //if (back == true)
                //{
                //    hdnAppServerName.Value = "Yes";
                //    return;
                //}
                //else
                //{
                //    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "logix", "alertify.alert('Sorry Another instance is already opened');", true);
                //    return;
                //}

                //string u = Request.ServerVariables["HTTP_USER_AGENT"];
                //Regex b = new Regex(@"(android|bb\d+|meego).+mobile|avantgo|bada\/|blackberry|blazer|compal|elaine|fennec|hiptop|iemobile|ip(hone|od)|iris|kindle|lge |maemo|midp|mmp|mobile.+firefox|netfront|opera m(ob|in)i|palm( os)?|phone|p(ixi|re)\/|plucker|pocket|psp|series(4|6)0|symbian|treo|up\.(browser|link)|vodafone|wap|windows ce|xda|xiino", RegexOptions.IgnoreCase | RegexOptions.Multiline);
                //Regex v = new Regex(@"1207|6310|6590|3gso|4thp|50[1-6]i|770s|802s|a wa|abac|ac(er|oo|s\-)|ai(ko|rn)|al(av|ca|co)|amoi|an(ex|ny|yw)|aptu|ar(ch|go)|as(te|us)|attw|au(di|\-m|r |s )|avan|be(ck|ll|nq)|bi(lb|rd)|bl(ac|az)|br(e|v)w|bumb|bw\-(n|u)|c55\/|capi|ccwa|cdm\-|cell|chtm|cldc|cmd\-|co(mp|nd)|craw|da(it|ll|ng)|dbte|dc\-s|devi|dica|dmob|do(c|p)o|ds(12|\-d)|el(49|ai)|em(l2|ul)|er(ic|k0)|esl8|ez([4-7]0|os|wa|ze)|fetc|fly(\-|_)|g1 u|g560|gene|gf\-5|g\-mo|go(\.w|od)|gr(ad|un)|haie|hcit|hd\-(m|p|t)|hei\-|hi(pt|ta)|hp( i|ip)|hs\-c|ht(c(\-| |_|a|g|p|s|t)|tp)|hu(aw|tc)|i\-(20|go|ma)|i230|iac( |\-|\/)|ibro|idea|ig01|ikom|im1k|inno|ipaq|iris|ja(t|v)a|jbro|jemu|jigs|kddi|keji|kgt( |\/)|klon|kpt |kwc\-|kyo(c|k)|le(no|xi)|lg( g|\/(k|l|u)|50|54|\-[a-w])|libw|lynx|m1\-w|m3ga|m50\/|ma(te|ui|xo)|mc(01|21|ca)|m\-cr|me(rc|ri)|mi(o8|oa|ts)|mmef|mo(01|02|bi|de|do|t(\-| |o|v)|zz)|mt(50|p1|v )|mwbp|mywa|n10[0-2]|n20[2-3]|n30(0|2)|n50(0|2|5)|n7(0(0|1)|10)|ne((c|m)\-|on|tf|wf|wg|wt)|nok(6|i)|nzph|o2im|op(ti|wv)|oran|owg1|p800|pan(a|d|t)|pdxg|pg(13|\-([1-8]|c))|phil|pire|pl(ay|uc)|pn\-2|po(ck|rt|se)|prox|psio|pt\-g|qa\-a|qc(07|12|21|32|60|\-[2-7]|i\-)|qtek|r380|r600|raks|rim9|ro(ve|zo)|s55\/|sa(ge|ma|mm|ms|ny|va)|sc(01|h\-|oo|p\-)|sdk\/|se(c(\-|0|1)|47|mc|nd|ri)|sgh\-|shar|sie(\-|m)|sk\-0|sl(45|id)|sm(al|ar|b3|it|t5)|so(ft|ny)|sp(01|h\-|v\-|v )|sy(01|mb)|t2(18|50)|t6(00|10|18)|ta(gt|lk)|tcl\-|tdg\-|tel(i|m)|tim\-|t\-mo|to(pl|sh)|ts(70|m\-|m3|m5)|tx\-9|up(\.b|g1|si)|utst|v400|v750|veri|vi(rg|te)|vk(40|5[0-3]|\-v)|vm40|voda|vulc|vx(52|53|60|61|70|80|81|83|85|98)|w3c(\-| )|webc|whit|wi(g |nc|nw)|wmlb|wonu|x700|yas\-|your|zeto|zte\-", RegexOptions.IgnoreCase | RegexOptions.Multiline);
                //string device_info = string.Empty;

                //if (b.IsMatch(u) || v.IsMatch(u.Substring(0, 4)))
                //{
                //    device_info = b.Match(u).Groups[0].Value;

                //    device_info += v.Match(u).Groups[0].Value;

                //    Session["Deviceinfo"] = device_info;
                //}
                
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

        /* protected void OpenWindow(object sender, EventArgs e)
         {
            // string url = ""+ Session["Site"].ToString() + "/";
             string url = "FormMain.aspx";
             string s = "window.open('" + url + "', 'popup_window', 'width=1362,height=720,resizable=yes');"; //,left=100%,top=100
             ClientScript.RegisterStartupScript(this.GetType(), "script", s, true);
             back = true;
             return;
         }*/

        //public void BindDivisionDLL()
        //{
        //    DataTable obj_dtTemp = new DataTable();
        //    obj_dtTemp = da_obj_HrEmp.GetDivision("M");
        //    ddlCompany.Items.Clear();
        //    ddlCompany.Items.Add("Company");
        //    for (int i = 0; i <= obj_dtTemp.Rows.Count - 1; i++)
        //    {
        //        ddlCompany.Items.Add(obj_dtTemp.Rows[i]["divisionname"].ToString());
        //    }
        //    List<System.Web.UI.WebControls.ListItem> li = new List<System.Web.UI.WebControls.ListItem>();
        //    foreach (System.Web.UI.WebControls.ListItem list in ddlCompany.Items)
        //    {
        //        li.Add(list);
        //    }
        //    li.Sort((x, y) => string.Compare(x.Text, y.Text));
        //    ddlCompany.Items.Clear();
        //    ddlCompany.DataSource = li;
        //    ddlCompany.DataBind();
        //}

        //public void BindBranchDLL()
        //{
        //    if (ddlCompany.Text == "Company")
        //    {
        //        ddlbranch.Items.Clear();
        //    }
        //    else
        //    {
        //        DataTable obj_dtTemp = new DataTable();
        //        obj_dtTemp = da_obj_Branch.GetBranchByDivID(int.Parse(da_obj_HrEmp.GetDivisionId(ddlCompany.SelectedValue).ToString()));
        //        ddlbranch.Items.Clear();
        //        ddlbranch.Items.Add("Branch");
        //        for (int i = 0; i <= obj_dtTemp.Rows.Count - 1; i++)
        //        {
        //            ddlbranch.Items.Add(obj_dtTemp.Rows[i]["branch"].ToString());
        //        }
        //        //ddlbranch.DataSource = obj_dtTemp;
        //        //ddlbranch.DataBind();
        //    }
        //}

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {

        }

        //public void  GetMACAddress2()
        //{
        //    NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();

        //    foreach (NetworkInterface adapter in nics)
        //    {
        //        if (MacAddress == "")// only return MAC Address from first card  
        //        {
        //            //IPInterfaceProperties properties = adapter.GetIPProperties(); Line is not required
        //            MacAddress = adapter.GetPhysicalAddress().ToString();
        //        }
        //        logindate=
        //        hostName = System.Net.Dns.GetHostName();
        //    } 
        //}

        protected void btnSignin_Click(object sender, EventArgs e)
        {
            DataTable obj_Dt = new DataTable();
            DataAccess.userlogin obj_login = new DataAccess.userlogin();
            obj_Dt = obj_login.selEmpDetailsWOROLnew(txtusername.Text);
           
            Session["LoginEmpName"] = null;
            Session["LoginUserName"] = null;
            Session["branch"] = null;

           
           
            if (txtusername.Text == "")
            {
                ScriptManager.RegisterStartupScript(btnSignin, typeof(Button), "logix", "alertify.alert('Please Enter The Username');", true);
                txtusername.Focus();
                return;
            }
            else if (txtpassword.Text == "")
            {
                ScriptManager.RegisterStartupScript(btnSignin, typeof(Button), "logix", "alertify.alert('Please Enter The Password');", true);
                txtpassword.Focus();
                return;
            }
            NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();
            String MacAddress = string.Empty;
            foreach (NetworkInterface adapter in nics)
            {
                if (MacAddress == String.Empty)// only return MAC Address from first card  
                {
                    //IPInterfaceProperties properties = adapter.GetIPProperties(); Line is not required
                    MacAddress = adapter.GetPhysicalAddress().ToString();
                }
            }
            /*  logindate = da_obj_Log.GetDate();
              hostname = System.Net.Dns.GetHostName();
              dtlogget = obj_login.GetUserLoginDetails(txtusername.Text, "U");*/
            //divisionId = Convert.ToInt32(da_obj_HrEmp.GetDivisionId(ddlCompany.SelectedItem.Text.ToString()));
            //branchid = Convert.ToInt32(da_obj_HrEmp.GetBranchId(divisionId, ddlbranch.SelectedItem.Text.ToString()));

            /*if(divisionId ==1 || divisionId ==7)
            {
                dtmac = obj_login.GetUserLoginDetails4scm(MacAddress, "M", divisionId);
                if(dtmac.Rows.Count > 0)
                {
                    if(MacAddress == dtmac.Rows[0]["macaddress"].ToString())
                    {
                        if(txtusername.Text != dtmac.Rows[0]["Userid"].ToString())
                        {
                            ScriptManager.RegisterStartupScript(btnSignin, typeof(Button), "logix", "alertify.alert('Already Running');", true);
                            return;
                        }
                    }
                }

                dtlogget = obj_login.GetUserLoginDetails4scm(txtusername.Text, "U", divisionId);
                if(dtlogget.Rows.Count > 0)
                {
                    if (MacAddress == dtlogget.Rows[0]["macaddress"].ToString())
                    {
                        ScriptManager.RegisterStartupScript(btnSignin, typeof(Button), "logix", "alertify.alert('Already Running');", true);
                        return;
                    }
                }
            }
            else
            {
                dtmac = obj_login.GetUserLoginDetails(MacAddress, "M");
                if (dtmac.Rows.Count > 0)
                {
                    if (MacAddress == dtmac.Rows[0]["macaddress"].ToString())
                    {
                        if (txtusername.Text != dtmac.Rows[0]["Userid"].ToString())
                        {
                            ScriptManager.RegisterStartupScript(btnSignin, typeof(Button), "logix", "alertify.alert('Already Running');", true);
                            return;
                        }
                    }
                }

                dtlogget = obj_login.GetUserLoginDetails(txtusername.Text, "U");
                if (dtlogget.Rows.Count > 0)
                {
                    if (MacAddress == dtlogget.Rows[0]["macaddress"].ToString())
                    {
                        ScriptManager.RegisterStartupScript(btnSignin, typeof(Button), "logix", "alertify.alert('Already Running');", true);
                        return;
                    }
                }
            }*/
           
             if (obj_Dt.Rows.Count > 0)
            {
                int int_div = Convert.ToInt32(obj_Dt.Rows[0]["divisionid"]); //1;
                Session["countryid"] = obj_Dt.Rows[0]["countryid"].ToString();
                changepass = 0;
                if (!string.IsNullOrEmpty(obj_Dt.Rows[0]["mailid"].ToString()))
                {
                    Session["usermailid"] = obj_Dt.Rows[0]["mailid"].ToString();
                }
                else
                {
                    Session["usermailid"] = " ";
                }
               
                if (!string.IsNullOrEmpty(obj_Dt.Rows[0]["mailpwd"].ToString()))
                {
                    Session["mailpwd"] = obj_Dt.Rows[0]["mailpwd"].ToString();
                }
                else
                {
                    Session["mailpwd"] = " ";
                }

                if (txtusername.Text.Trim().ToUpper() != "")
                {
                    if (txtusername.Text.Trim().ToUpper() == obj_Dt.Rows[0]["mailid"].ToString() || txtusername.Text.ToString() == obj_Dt.Rows[0]["empcode"].ToString() || txtusername.Text.ToString() == obj_Dt.Rows[0]["phonehp"].ToString())
                    {
                        if (txtusername.Text.Trim().ToUpper() == obj_Dt.Rows[0]["mailid"].ToString())
                        {
                            string[] strTemptobcc = txtusername.Text.Trim().ToUpper().Split(';', ',');

                            for (int i = 0; i < strTemptobcc.Length; i++)
                            {
                                // if (IsValidEmailId(txt_EmailID.Text.Trim().ToUpper()))
                                if (IsValidEmailId(strTemptobcc[i].ToString().Trim().ToUpper()))
                                {
                                    if (ViewState["CurrentData"] != null)
                                    {
                                        DataTable dt = (DataTable)ViewState["CurrentData"];
                                        int count = dt.Rows.Count;
                                        // BindGrid(count, txt_EmailID.Text.Trim().ToUpper());
                                    }
                                    else
                                    {
                                        //BindGrid(1, txt_EmailID.Text.Trim().ToUpper());
                                    }

                                    //  txt_EmailID.Text = "";
                                    Session["usermailid"] = obj_Dt.Rows[0]["mailid"].ToString();
                                    txtusername.Focus();
                                }
                                else
                                {
                                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "logix", "alertify.alert('InValid Email Format');", true);
                                    txtusername.Text = "";
                                    txtusername.Focus();
                                    return;

                                }
                            }
                        }
                        else if (txtusername.Text.ToString() == obj_Dt.Rows[0]["phonehp"].ToString())
                        {
                            Session["usermailid"] = obj_Dt.Rows[0]["mailid"].ToString();
                            string mail = Session["usermailid"].ToString();
                        }

                        else if (txtusername.Text.ToString() == obj_Dt.Rows[0]["empcode"].ToString())
                        {
                            Session["usermailid"] = obj_Dt.Rows[0]["mailid"].ToString();
                            string mail = Session["usermailid"].ToString();
                        }

                    }

                    else
                    {
                        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "logix", "alertify.alert('Mail ID Can not Be Blank or USERNAME Can not Be Blank or PHONE NO Can not Be Blank');", true);
                        txtusername.Text = "";
                        txtusername.Focus();
                        return;
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "logix", "alertify.alert('Mail ID Can not Be Blank or  USERNAME Can not Be Blank or PHONE NO Can not Be Blank');", true);
                    txtusername.Text = "";
                    txtusername.Focus();
                    return;
                }
                
                if (txtpassword.Text.ToString() == obj_login.Decrypt(obj_Dt.Rows[0]["pwd"].ToString(), obj_Dt.Rows[0]["empid"].ToString()))
                {
                    Session["LoginDivisionId"] = int_div.ToString();
                     // Session["LoginDivisionId"] = "7";
                   //Session["LoginDivisionId"] = "6";
                    Session["LoginDivisionName"] = obj_div.GetMasterDivisionName(Convert.ToInt32(Session["LoginDivisionId"].ToString()));
                    Session["LoginDivisionNameReport"] = obj_div.GetMasterDivisionName(Convert.ToInt32(Session["LoginDivisionId"].ToString()));
                    Session["Site"] = obj_div.Selsite(Convert.ToInt32(Session["LoginDivisionId"].ToString()));

                    Session["LoginBranchName"] = obj_Dt.Rows[0]["branch"].ToString();// ddlbranch.SelectedItem.Text.ToString();
                    Session["LoginBranchid"] = da_obj_HrEmp.GetBranchId(Convert.ToInt16(Session["LoginDivisionId"].ToString()), obj_Dt.Rows[0]["branch"].ToString());
                    if (Session["LoginBranchName"].ToString()=="CORPORATE")
                    {
                        Session["Processcor"] = obj_Dt.Rows[0]["process"].ToString();
                        Session["Process"] = "";
                        Session["Process1"] = obj_Dt.Rows[0]["process"].ToString();
                    }
                    else
                    {
                        Session["Process"] = obj_Dt.Rows[0]["process"].ToString();
                        Session["Processcor"] = "";
                        Session["Process1"] = obj_Dt.Rows[0]["process"].ToString();
                    }
                   

                    
                    //Session["LoginUserName"] = txtusername.Text.ToString();
                    Session["LoginUserName"] = obj_Dt.Rows[0]["empcode"].ToString();

                    Session["LoginEmpId"] = obj_Dt.Rows[0]["Empid"].ToString();
                    Session["LoginEmpName"] = obj_Dt.Rows[0]["empname"].ToString();
                  
                    Session["usermailid"] = obj_Dt.Rows[0]["mailid"].ToString();
                    Session["usermailpwd"] = obj_Dt.Rows[0]["mailpwd"].ToString();
                    Session["designation"] = obj_Dt.Rows[0]["design"].ToString();
                    Session["dept"] = obj_Dt.Rows[0]["dept"].ToString();

                    Session["branch"] = obj_Dt.Rows[0]["branch"].ToString();
                    Session["Basecurr"] = EXobj.GetBaseCurrency(Convert.ToInt32(Session["LoginBranchid"]));
                    if (da_obj_Log.GetDate().Month < 4)
                    {
                        Session["Vouyear"] = da_obj_Log.GetDate().AddYears(-1).Year.ToString();
                        Session["Alogyear"] = Session["Vouyear"];
                    }
                    else
                    {
                        Session["Vouyear"] = da_obj_Log.GetDate().Year.ToString();
                        Session["Alogyear"] = Session["Vouyear"];
                    }

                    Session["Loginyear"] = Session["Vouyear"];
                    int Vyraer = Convert.ToInt32(Session["Vouyear"]);
                    GetFADBvou(Vyraer);
                    //dtlogget = obj_login.GetUserLoginDetails(txtusername.Text, "U");
                    /* if (dtlogget.Rows.Count == 0)
                     {
                         loginid = obj_login.InsertUserLoginDetails(txtusername.Text, MacAddress, hostname, logindate, Convert.ToInt32(Session["LoginDivisionId"].ToString()), Convert.ToInt32(Session["LoginBranchid"].ToString()));
                     }
                     else
                     {
                         if (MacAddress == dtlogget.Rows[0]["macaddress"])
                         {

                         }else
                         {
                             //hostname = dtlogget.Rows[0]["devicename"].ToString();
                             //ScriptManager.RegisterStartupScript(btnSignin, typeof(Button), "logix", "alertify.alert('This Username has been already used by - " + hostname +"');", true);
                             //return;
                         }
                     }*/

                    DataTable dtgst = new DataTable();
                    dtgst = da_obj_Log.GetGSTDts();
                    if (dtgst.Rows.Count > 0)
                    {
                        if (!string.IsNullOrEmpty(dtgst.Rows[0]["GSTDate"].ToString()))
                        {
                            //   hid_gstdate.Value 

                            Session["hid_gstdate"] = Convert.ToDateTime(dtgst.Rows[0]["GSTDate"].ToString()).ToString();

                        }

                    }

                    DateTime dtime = da_obj_Log.GetGSTDate();

                    Session["gstdaterpt"] = dtime.ToString();

                    if (obj_Dt.Rows[0]["pwd"].ToString() != "")
                    {
                        doj = Convert.ToDateTime(obj_Dt.Rows[0]["doj"].ToString());
                    }
                    if (obj_Dt.Rows[0]["lastupdatedon"].ToString() != "")
                    {
                        var cultureInfo = new CultureInfo("en-US");
                        Thread.CurrentThread.CurrentCulture = cultureInfo;
                        Thread.CurrentThread.CurrentUICulture = cultureInfo;
                        lastupdatedon = Convert.ToDateTime(obj_Dt.Rows[0]["lastupdatedon"].ToString());
                    }

                    DateTime today = Convert.ToDateTime(da_obj_Log.GetDate());
                    var b = ((today.Year - lastupdatedon.Year) * 12) + today.Month - lastupdatedon.Month;
                    if (b >= 1)
                    {
                        ScriptManager.RegisterStartupScript(btnSignin, typeof(Button), "logix", "alertify.alert('Please Change Your Password');", true);
                        changepass = 1;
                    }
                    month = doj.Month;
                    year = doj.Year;
                    if (month < 10)
                    {
                        month = int.Parse("0") + month;
                    }
                   // if (txtpassword.Text.Trim() == txtusername.Text.Trim() + month + year)
                    if (txtpassword.Text.Trim()==obj_Dt.Rows[0]["empcode"].ToString().Trim()+month+year)
                    {
                        ScriptManager.RegisterStartupScript(btnSignin, typeof(Button), "logix", "alertify.alert('Please Change Your Password');", true);
                        changepass = 1;
                    }
                    else if (txtpassword.Text.Trim().Length < 6)
                    {
                        ScriptManager.RegisterStartupScript(btnSignin, typeof(Button), "logix", "alertify.alert('Password Minimum 6 Characters... Please Change Your Password');", true);
                        changepass = 1;
                    }
                    dtdate = da_obj_Log.GetDate();
                  //  da_obj_HrEmp.UpdLiveUser(txtusername.Text);

                    da_obj_HrEmp.UpdLiveUser(obj_Dt.Rows[0]["empcode"].ToString());

                    //FrontpageObj.InsMasterACCode(ddlCompany.Text, ddlbranch.Text, Convert.ToInt32( Session["Vouyear"].ToString()));

                    DateTime date = new DateTime(dtdate.Year, dtdate.Month, 1);
                    if (date <= dtdate)
                    {
                        FrontpageObj.InsBudget(dtdate.Month, dtdate.Year);
                    }
                    da_obj_Log.CreateLogTable();
                   // da_obj_Log.CreateLogTablenew();
                    DataTable Dt = new DataTable();
                    //Dt = da_obj_Log.GetCompanyNameAdd(Convert.ToInt32(Session["LoginBranchid"].ToString()));
                    if (Dt.Rows.Count > 0)
                    {
                        bmmail = Dt.Rows[0]["email"].ToString();
                        bmmailid = Dt.Rows[0]["bm"].ToString();
                        rmmailid = Dt.Rows[0]["rm"].ToString();
                        Session["BM"] = bmmailid.ToString();
                        Session["rm"] = rmmailid.ToString();
                        strcompanyaddress = "<html><body text=blue><center> <FONT FACE=Arial SIZE=4>" + Dt.Rows[0]["branchname"].ToString() + "</FONT><br><FONT FACE=Arial SIZE=2>" + Dt.Rows[0]["address"].ToString() + " <br> Phone : " + Dt.Rows[0]["phone"].ToString() + " Fax : " + Dt.Rows[0]["fax"].ToString() + "</Font></center><HR width=100%></body>";
                        Session["Companyaddress"] = strcompanyaddress;
                    }
                   
                    /*if (txtusername.Text.Length == 4)
                    {
                        if (txtusername.Text != "0357" && txtusername.Text != "0024")
                        {
                            /*checkip(txtusername.Text, txtpassword.Text);
                            if (ipcheck == 1)
                            {
                                return;
                            }
                        }
                    }*/

                    if (changepass == 1)
                    {
                        this.pop_passemp.Show();
                        Session["Login"] = "";
                        return;
                    }

                    // if (ddlbranch.SelectedItem.Text == "CORPORATE")
                    // {
                    //     Session["StrTranType"] = "CO";
                    //     Session["RightsTranType"] = "MI";
                    //    // ScriptManager.RegisterStartupScript(btnSignin, typeof(Button), "logix", "alertify.alert('Please use a different browser to work simultaneously with multiple branches or companies do not use in other tabs in the same browser');", true);                        
                    //     Response.Redirect("FormMain.aspx");

                    // }
                    // else
                    // // Response.Redirect("MainPage/CRMDocked.aspx");
                    // { 
                    //     //Please use a different browser to work simultaneously with multiple branches / companies, do not use in other tabs in the same browser

                    //     Response.Redirect("FormMain.aspx");
                    //}
                    getexrate();
                   // Response.Redirect("MainFormNew.aspx");
                    if (ddlbranch.SelectedItem.Text == "CORPORATE")
                    {
                        Session["StrTranType"] = "CO";
                        Session["RightsTranType"] = "MI";
                        Response.Redirect("FormMain.aspx");

                    }
                    else
                    {
                        Response.Redirect("FormMain.aspx");

                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(btnSignin, typeof(Button), "logix", "alertify.alert('Enter The Correct Password');", true);
                    txtpassword.Focus();
                    //hf_wrong.Value =( Convert.ToInt32(hf_wrong.Value) + 1).ToString();
                    //if(hf_wrong.Value=="3")
                    //{
                    //    lnkforgetpwd.Focus();
                    //}
                    return;
                }
            }
            else
            {
                //ScriptManager.RegisterStartupScript(btnSignin, typeof(Button), "logix", "alertify.alert('Enter The Correct Username');", true);
                //txtusername.Focus();

                //return;
                DataAccess.RegCustomer cusobj = new DataAccess.RegCustomer();

                DataTable dtgst = new DataTable();
                dtgst = da_obj_Log.GetGSTDts();
                if (dtgst.Rows.Count > 0)
                {
                    if (!string.IsNullOrEmpty(dtgst.Rows[0]["GSTDate"].ToString()))
                    {
                        //   hid_gstdate.Value 

                        Session["hid_gstdate"] = Convert.ToDateTime(dtgst.Rows[0]["GSTDate"].ToString()).ToString();

                    }

                }

                Session["LoginUserName"] = txtusername.Text;
                Session["LoginEmpId"] = txtusername.Text;
                DateTime FromDate;
                DateTime ToDate;
                string find = "";

                FromDate = DateTime.Parse(ConvertDate(DateTime.Now.ToString("dd/MM/yyyy")));
                ToDate = DateTime.Parse(ConvertDate(DateTime.Now.ToString("dd/MM/yyyy")));
             //   find = cusobj.SPGetDBName4Jsonnew(FromDate, ToDate);

              //  Session["FADbname"] = find;

                Dt = cusobj.SelCusLoginDet(txtusername.Text);
                if (Dt.Rows.Count > 0)
                {
                    Password = Dt.Rows[0]["pwd"].ToString();

                    Session["Password_cs"] = Password;

                    //Session["webgroupid"] = Dt.Rows[0]["webgroupid"].ToString();
                    Session["webgroupid"] = Dt.Rows[0]["custportalcredentialsid"].ToString();
                    Session["webcuspanid"] = Dt.Rows[0]["panid"].ToString();
                    if (Password.Trim() == txtpassword.Text.Trim())
                    {
                        Session["username"] = txtusername.Text; //LBLStatus.InnerText = "";
                        Session["login"] = "1";
                        Session["LoginDivisionId"] = 1;
                        Session["LoginDivisionName"] = obj_div.GetMasterDivisionName(Convert.ToInt32(Session["LoginDivisionId"].ToString()));
                        cusobj.InsWebCustLogDtl(Convert.ToInt32(Session["webgroupid"].ToString()), DataAccess.RegCustomer.EventType.LoginSuccess, DateTime.Now, Session["webgroupid"] + "-LoginSuccessfully");
                        // Response.Redirect("Default.aspx?lgs='1'&uid=" + Dt.Rows[0]["webgroupid"].ToString());
                        

                        Response.Redirect("MainPage4CustPortal.aspx?lgs='1'&uid=" + Dt.Rows[0]["custportalcredentialsid"].ToString());

                        //Response.Redirect("MainPagenew.aspx?lgs='1'&uid=" + "110");

                    }

                    else
                    {
                        //  LBLStatus.InnerText = "Wrong Password";
                        cusobj.InsWebCustLogDtl(int.Parse(Session["webgroupid"].ToString()), DataAccess.RegCustomer.EventType.LoginFailed, DateTime.Now, Session["webgroupid"] + "-LoginFailed");
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(btnSignin, typeof(Button), "logix", "alertify.alert('Enter The Correct Username');", true);
                    txtusername.Text = "";
                    txtusername.Focus();
                    return;
                }
                //if (obj_Dt.Rows.Count == 0)
                //{
                //    ScriptManager.RegisterStartupScript(btnSignin, typeof(Button), "logix", "alertify.alert('Invalid Username / Password ');", true);
                //    txtusername.Text = "";
                //    txtpassword.Text = "";
                //    txtusername.Focus();
                //    return;
                //}
        
            }
        }
        public string ConvertDate(string strSource)
        {
            string strTemp = "";
            string[] datSrc = strSource.Split('/');

            if (datSrc[1].Length < 2)
                datSrc[1] = "0" + datSrc[1];

            if (datSrc[0].Length < 2)
                datSrc[0] = "0" + datSrc[0];

            strTemp = datSrc[1] + "/" + datSrc[0] + "/" + datSrc[2];
            return strTemp;
        }

        protected void sendmail()
        {

            

        }

        

        private DateTime DateSerial(int p1, int p2, int p3)
        {
            throw new NotImplementedException();
        }

        protected void txtusername_TextChanged(object sender, EventArgs e)
        {
            
            try
            {
                DataTable obj_Dt = new DataTable();
                DataAccess.userlogin obj_login = new DataAccess.userlogin();
                obj_Dt = obj_login.selEmpDetailsWOROLnew(txtusername.Text);
                if (obj_Dt.Rows.Count > 0)
                {
                    Session["usermailid"] = obj_Dt.Rows[0]["mailid"].ToString();
                    string mail = Session["usermailid"].ToString();
                }        
                txtusername.Text = txtusername.Text.ToUpper();

                if (obj_Dt.Rows.Count > 0)
                {
                    if (txtusername.Text.Trim().ToUpper() != "")
                    {
                        if (txtusername.Text.Trim().ToUpper() == obj_Dt.Rows[0]["mailid"].ToString() || txtusername.Text.ToString() == obj_Dt.Rows[0]["empcode"].ToString() || txtusername.Text.ToString() == obj_Dt.Rows[0]["phonehp"].ToString())
                        {
                            if (txtusername.Text.Trim().ToUpper() == obj_Dt.Rows[0]["mailid"].ToString())
                            {
                                string[] strTemptobcc = txtusername.Text.Trim().ToUpper().Split(';', ',');

                                for (int i = 0; i < strTemptobcc.Length; i++)
                                {
                                    // if (IsValidEmailId(txt_EmailID.Text.Trim().ToUpper()))
                                    if (IsValidEmailId(strTemptobcc[i].ToString().Trim().ToUpper()))
                                    {
                                        if (ViewState["CurrentData"] != null)
                                        {
                                            DataTable dt = (DataTable)ViewState["CurrentData"];
                                            int count = dt.Rows.Count;
                                            // BindGrid(count, txt_EmailID.Text.Trim().ToUpper());
                                        }
                                        else
                                        {
                                            //BindGrid(1, txt_EmailID.Text.Trim().ToUpper());
                                        }

                                        //  txt_EmailID.Text = "";
                                        Session["usermailid"] = obj_Dt.Rows[0]["mailid"].ToString();
                                        txtusername.Focus();
                                    }
                                    else
                                    {
                                        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "logix", "alertify.alert('InValid Email Format');", true);
                                        txtusername.Text = "";
                                        txtusername.Focus();
                                        return;

                                    }
                                }
                            }
                            else if (txtusername.Text.ToString() == obj_Dt.Rows[0]["phonehp"].ToString())
                            {
                                Session["usermailid"] = obj_Dt.Rows[0]["mailid"].ToString();
                                string mail = Session["usermailid"].ToString();
                            }

                            else if (txtusername.Text.ToString() == obj_Dt.Rows[0]["empcode"].ToString())
                            {
                                Session["usermailid"] = obj_Dt.Rows[0]["mailid"].ToString();
                                string mail = Session["usermailid"].ToString();
                            }

                        }

                        else
                        {
                            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "logix", "alertify.alert('Mail ID Can not Be Balnk or USERNAME Can not Be Balnk or PHONE NO Can not Be Balnk');", true);
                            txtusername.Text = "";
                            txtusername.Focus();
                            return;
                        }
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "logix", "alertify.alert('Mail ID Can not Be Blank or  USERNAME Can not Be Blank or PHONE NO Can not Be Blank');", true);
                        txtusername.Text = "";
                        txtusername.Focus();
                        return;
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "logix", "alertify.alert('Enter the correct UserName');", true);
                    txtusername.Text = "";
                    txtusername.Focus();
                    return;
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);

            }

        }

        private bool IsValidEmailId(string InputEmail)
        {
            //Regex To validate Email Address
            Regex regex = new Regex(@"^(([\w-]+\.)+[\w-]+|([a-zA-Z]{1}|[\w-]{2,}))@"
     + @"((([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\.([0-1]?
				[0-9]{1,2}|25[0-5]|2[0-4][0-9])\."
     + @"([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\.([0-1]?
				[0-9]{1,2}|25[0-5]|2[0-4][0-9])){1}|"
     + @"([a-zA-Z0-9]+[\w-]+\.)+[a-zA-Z]{1}[a-zA-Z0-9-]{1,23})$");

            Match match = regex.Match(InputEmail);
            if (match.Success)
                return true;
            else
                return false;
        }

        private void GetFADBvou(int vyearp)
        {
            string FAYear1;
            int vyear1;
            vyear1 = vyearp;
            FAYear1 = vyear1.ToString();
            FAYear1 = FAYear1.Substring(2, 2);
            vyear1 = vyear1 + 1;
            FAYear1 = FAYear1 + Convert.ToString(vyear1).Substring(2, 2);
            FADbname = "FA" + FAYear1;
            Session["FADbname"] = FADbname;
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            //ddlCompany.Focus();
            //BindDivisionDLL();
            txtusername.Text = "";
            txtpassword.Text = "";
        }

        protected void ddldivision_SelectedIndexChanged(object sender, EventArgs e)
        {

            //BindBranchDLL();
        }

        protected void lnkforgetpwd_Click(object sender, EventArgs e)
        {
            
            DataTable dt = new DataTable();
            DataTable obj_Dt = new DataTable();
            DataAccess.userlogin login = new DataAccess.userlogin();
            //if (ddlCompany.SelectedValue == "0")
            //{
            //    ScriptManager.RegisterStartupScript(btnSignin, typeof(Button), "UserName", "alertify.alert('Select Company');", true);
            //    ddlCompany.Focus();
            //    return;
            //}

            if (txtusername.Text == "")
            {
                ScriptManager.RegisterStartupScript(btnSignin, typeof(Button), "UserName", "alertify.alert('Invalid Username');", true);
                txtusername.Focus();
                return;
            }

            obj_Dt = login.selEmpDetailsWOROLnew(txtusername.Text);
            if (obj_Dt.Rows.Count > 0)
            {
                Session["usermailid"] = obj_Dt.Rows[0]["mailid"].ToString();
                Session["empname"] = obj_Dt.Rows[0]["empname"].ToString();
                Session["mailpwd"] = obj_Dt.Rows[0]["mailpwd"].ToString();
                string mail = Session["usermailid"].ToString();

             //   hdn_pwd.Value = login.Decrypt(obj_Dt.Rows[0][11].ToString(), obj_Dt.Rows[0]["empid"].ToString());

                hdn_pwd.Value = login.Decrypt(obj_Dt.Rows[0][12].ToString(), obj_Dt.Rows[0]["empid"].ToString());
                //Session["mailpwd"] = dt.Rows[0]["mailpwd"].ToString();

                MailMessage Msg = new MailMessage();

                Msg.From = new MailAddress("");
                string frommail = "";
                string tomail = Session["usermailid"].ToString();
                // Recipient e-mail address.
                Msg.To.Add(Session["usermailid"].ToString());
                // Msg.Subject = "Your Password Details";
                Msg.Body = "Dear   " + HttpContext.Current.Session["empname"].ToString() + "(" + obj_Dt.Rows[0]["empcode"] + ")," + System.Environment.NewLine + "Your Password Is: " + hdn_pwd.Value;
                string cont = Msg.Body;
                Msg.IsBodyHtml = true;

                SmtpClient smtp = new SmtpClient("");

                smtp.Host = "";
                smtp.EnableSsl = true;
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.UseDefaultCredentials = false;
                NetworkCredential NetworkCred = new NetworkCredential("", "logix");
                smtp.Credentials = NetworkCred;
                smtp.Port = 587;
                
                DataAccess.LogDetails da_obj_Log = new DataAccess.LogDetails();
                DataTable dtp = new DataTable();
                dtp = da_obj_Log.ForgetPwdLoginMailid();
                string UserName = dtp.Rows[0]["MailId"].ToString();
                string Pwd = dtp.Rows[0]["Password"].ToString();
               
            }
            else if (!string.IsNullOrEmpty(obj_Dt.Rows[0]["mailid"].ToString()))
            {
                
                return;
            }

        }

        public void getexrate()
        {
            DataAccess.LogDetails obj_da_Logobj = new DataAccess.LogDetails();
            string dtexdate = obj_da_Logobj.GetDate().ToString();
            DataTable dt = new DataTable();
            //dt = exrobj.GetExRateDetails(dtexdate);
            dt = EXobj.GetExRateDetails(Convert.ToDateTime(dtexdate));
           
        }
        protected void ddl_branch_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        public void BindcountryDLL()
        {
            //if (ddlCompany.Text == "Company")
            //{
            //    ddlbranch.Items.Clear();
            //}
            //else
            //{
            DataTable obj_dtTemp = new DataTable();
            obj_dtTemp = da_obj_Branch.Selcountry4login();
            ddl_country.Items.Clear();
            ddl_country.Items.Add("Country");
            for (int i = 0; i <= obj_dtTemp.Rows.Count - 1; i++)
            {
                ddl_country.Items.Add(obj_dtTemp.Rows[i]["country"].ToString());
            }
            //ddlbranch.DataSource = obj_dtTemp;
            //ddlbranch.DataBind();
            // }
        }

        protected void ddl_country_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable obj_dtTemp = new DataTable();
            obj_dtTemp = da_obj_Branch.Selbranch4login(ddl_country.SelectedItem.Text);
            ddlbranch.Items.Clear();
            ddlbranch.Items.Add("Branch");
            for (int i = 0; i <= obj_dtTemp.Rows.Count - 1; i++)
            {
                ddlbranch.Items.Add(obj_dtTemp.Rows[i]["branch"].ToString());
            }
        }
    }
}