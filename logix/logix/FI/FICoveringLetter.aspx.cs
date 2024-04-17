using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.Services; 

namespace logix.FI
{
    public partial class FICoveringLetter : System.Web.UI.Page
    {
        string Ctrl_List1;
        string Msg_List1, Data_List1;
        string str_FornName, str_Uiid;

        DataAccess.ForwardingImports.JobInfo obj_da_fijob = new DataAccess.ForwardingImports.JobInfo();
        DataAccess.LogDetails obj_da_log = new DataAccess.LogDetails();
        DataAccess.ForwardingImports.BLDetails obj_da_fibl = new DataAccess.ForwardingImports.BLDetails();
        DataAccess.Masters.MasterCustomer obj_da_customer = new DataAccess.Masters.MasterCustomer();
        DataAccess.HR.Employee obj_da_hremp = new DataAccess.HR.Employee();
        DataAccess.LogDetails obj_da_Log1 = new DataAccess.LogDetails();

        protected void Page_Load(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "SpanTagMoveInputBottom();MuiTextField();", true);



            string Ccode = Convert.ToString(Session["Ccode"]);

            if (Ccode != "")
            {

                obj_da_log.GetDataBase(Ccode);
                obj_da_fijob.GetDataBase(Ccode);
                obj_da_fibl.GetDataBase(Ccode);
                obj_da_customer.GetDataBase(Ccode);
                obj_da_hremp.GetDataBase(Ccode);
                obj_da_Log1.GetDataBase(Ccode);
               



            }


            if (Session["LoginUserName"] == null || Session["LoginEmpId"] == null || Session["LoginDivisionId"] == null || Session["LoginBranchid"] == null)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alertify.alert('Session TimeOut');window.open('"+ Session["Site"].ToString() + "/','_top');", true);
            }
            else if (Session["StrTranType"] == null)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alertify.alert('Session TimeOut');window.open('"+ Session["Site"].ToString() + "/FormMain.aspx','_top');", true);
            }
            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(btn_back);
            if (!IsPostBack == true)
            {
                Ctrl_List1 = txt_jobno.ID + "~" + txt_cfs.ID + "~" + ddl_format.ID;
                Msg_List1 = "Jobno~CFS~Format";
                Data_List1 = "string~string~DropDown";
                btn_print.Attributes.Add("OnClick", "return IsValid('" + Ctrl_List1 + "','" + Msg_List1 + "','" + Data_List1 + "');");
                txt_jobno.Attributes.Add("onkeypress", "return IntegerCheck(event);");
                fillddlformat();
                btn_back.Text = "Cancel";

                btn_back.ToolTip = "Cancel";
                btn_back1.Attributes["class"]="btn ico-cancel";
                txt_jobno.Focus();
                UserRights();
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

        [WebMethod]
        public static List<string> Getcfs(string prefix)
        {
            string strcustype = "D";
            DataTable obj_dt = new DataTable();
            DataAccess.Masters.MasterCustomer obj_da_customer = new DataAccess.Masters.MasterCustomer();
            string Ccode = HttpContext.Current.Session["Ccode"].ToString();
            obj_da_customer.GetDataBase(Ccode);
            List<string> cfs = new List<string>();
            obj_dt = obj_da_customer.GetLikeCustomerWDL(prefix);
            cfs = Utility.Fn_TableToList(obj_dt, "customername", "customerid", "customer", "Column1");
            return cfs;
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
                    Utility.Fn_CheckUserRights(str_Uiid, null, btn_print, null);
                    DataTable obj_Dtuser = new DataTable();
                    obj_Dtuser = (DataTable)Session["dt_UserRights"];
                    DataView obj_dtview = new DataView(obj_Dtuser);
                    obj_dtview.RowFilter = "uiid=" + str_Uiid + " and submenuname='" + str_FornName + "'";
                    obj_Dtuser = obj_dtview.ToTable();
                    btn_delete = Boolean.Parse(obj_Dtuser.Rows[0]["btndelete"].ToString());
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }



        protected void btn_print_Click(object sender, EventArgs e)
        {
            fn_btnprint_Click();
        }

        public void fn_btnprint_Click()
        {
            //DataAccess.ForwardingImports.JobInfo obj_da_fijob = new DataAccess.ForwardingImports.JobInfo();
            //DataAccess.LogDetails obj_da_log = new DataAccess.LogDetails();
            string str_sf = "";
            string str_sp = "";
            string str_Script = "";
            string str_RptName = "OOCL - Chennai.rpt";
            if (ddl_format.SelectedValue == "OOCL-CHENNAI")
            {
                str_sf = "{MasterBranch.branchid}=" + Convert.ToInt32(Session["LoginBranchid"]);
                str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                ScriptManager.RegisterStartupScript(btn_print, typeof(Button), "CoveringLetter", str_Script, true);
               
                Session["str_sfs"] = str_sf;
                Session["str_sp"] = str_sp;
                return;
            }
            GetReports();
            obj_da_fijob.UpdateFIEventcoveringsenton(Convert.ToInt32(txt_jobno.Text.ToString()), obj_da_log.GetDate(), Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(Session["LoginDivisionId"]));
            obj_da_log.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 121, 3, Convert.ToInt32(Session["LoginBranchid"]), txt_jobno.Text.ToString());
            UserRights();
        }

        public void GetReports()
        {
            string str_sp = "";
            string str_sf = "";
            string str_RptName = "";
            string str_Script = "";
            DataTable obj_dt = new DataTable();
            //DataAccess.ForwardingImports.BLDetails obj_da_fibl = new DataAccess.ForwardingImports.BLDetails();
            //DataAccess.HR.Employee obj_da_hremp = new DataAccess.HR.Employee();
            //DataAccess.LogDetails obj_da_log = new DataAccess.LogDetails();
            switch (ddl_format.SelectedValue)
            {
                case "General":
                    obj_dt = obj_da_fibl.GetBLDtJobno(Convert.ToInt32(txt_jobno.Text.ToString()), Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(Session["LoginDivisionId"]));
                    if (obj_dt.Rows.Count > 0)
                    {
                        for (int i = 0; i <= obj_dt.Rows.Count - 1; i++)
                        {
                            hf_pod.Value = obj_dt.Rows[i]["pod"].ToString();
                            hf_fd.Value = obj_dt.Rows[i]["fd"].ToString();
                            if (hf_pod.Value == hf_fd.Value)
                            {
                                hf_c1.Value = "1";
                            }
                            else
                            {
                                hf_icd.Value = "1";
                            }
                        }
                    }



                    if (hf_c1.Value == "1")
                    {
                        hf_c1.Value = "0";
                        if (Convert.ToInt32(Session["LoginBranchid"]) == 1)
                        {
                            str_RptName = "FICoveringLetter4PLFI.rpt";
                        }
                        else
                        {
                            str_RptName = "FICoveringLetter.rpt";
                        }
                        str_sf = "{FIJobInfo.bid}=" + Convert.ToInt32(Session["LoginBranchid"]) + " and {FIJobInfo.jobno}=" + txt_jobno.Text.ToString() + " and {FIJobInfo.cfsid}=" + hf_cfsid.Value;
                        str_sp = "jobno=" + txt_jobno.Text.ToString();
                        str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                        ScriptManager.RegisterStartupScript(btn_print, typeof(Button), "CoveringLetter", str_Script, true);
                        
                        Session["str_sfs"] = str_sf;
                        Session["str_sp"] = str_sp;
                    }
                    else if (hf_icd.Value == "1")
                    {
                        hf_icd.Value = "0";
                        if (Convert.ToInt32(Session["LoginBranchid"]) == 1)
                        {
                            str_RptName = "FICoveringLetterICD4PLFI.rpt";
                        }
                        else
                        {
                            str_RptName = "FICoveringLetterICD.rpt";
                        }

                        str_sf = "{FIJobInfo.bid}=" + Convert.ToInt32(Session["LoginBranchid"]) + " and {FIJobInfo.jobno}=" + txt_jobno.Text.ToString() + " and {FIJobInfo.cfsid}=" + hf_cfsid.Value;
                        str_sp = "jobno=" + txt_jobno.Text.ToString();
                        str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                        ScriptManager.RegisterStartupScript(btn_print, typeof(Button), "CoveringLetter", str_Script, true);
                        
                        Session["str_sfs"] = str_sf;
                        Session["str_sp"] = str_sp;
                    }
                    
                    break;
                case "Emirates Shipping":
                    str_RptName = "Emirates.rpt";
                    str_sp = "consignee=" + Session["LoginDivisionName"].ToString() + "~Notify=" + Session["LoginDivisionName"].ToString() + "~branchname=" + Session["LoginDivisionName"].ToString();
                    break;
                case "Globe Link":
                    str_RptName = "Globelink.rpt";
                    str_sp = "branchname=" + Session["LoginDivisionName"].ToString();
                    break;
                case "Shipping Corporation":
                    str_RptName = "SHIPPING CORP.rpt";
                    str_sp = "branchname=" + Session["LoginDivisionName"].ToString();
                    break;
                case "TeamGlobal":
                    str_RptName = "Teamglobal.rpt";
                    str_sp = "branchname=" + Session["LoginDivisionName"].ToString();
                    break;
                case "Oasis Shipping":
                    str_RptName = "OASIS.rpt";
                    str_sp = "branchname=" + Session["LoginDivisionName"].ToString();
                    break;
                case "Logistic Services":
                    str_RptName = "LOGISTICS.rpt";
                    str_sp = "branchname=" + Session["LoginDivisionName"].ToString();                   
                    break;
                case "ZIM Integrated":
                    str_RptName = "STAR SHIPPING AND ZIM.rpt";
                    str_sp = "branchname=" + Session["LoginDivisionName"].ToString();
                    break;
                case "Hanjin Shipping":
                    str_RptName = "HANJIN.rpt";
                    str_sp = "company=" + Session["LoginDivisionName"].ToString();
                    break;
                case "SeaHorse":
                    str_RptName = "SeaHorse.rpt";
                    str_sp = "company=" + Session["LoginDivisionName"].ToString();
                    break;
                case "Diamond Maritime":
                    str_RptName = "DIAMOND.rpt";
                    str_sp = "company=" + Session["LoginDivisionName"].ToString();
                    break;
                case "China Shipping":
                    str_RptName = "Excel Sheet-China.rpt";
                    break;
                case "LCL Agencies":
                 
                    if (str_RptName != "LCL.rpt")
                    {
                        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "FICoveringLetter", "alertify.alert('LCL Report is does not exits');", true);
                        return;
                    }
                    else
                    {
                        str_RptName = "LCL.rpt";
                    }
                  //  str_sp = "company=" + Session["LoginDivisionName"].ToString();
                    break;
                case "Samsara Shipping":
                    str_RptName = "SAMSARA.rpt";
                    str_sp = "company=" + Session["LoginDivisionName"].ToString();
                    break;
                case "Saturn Ship":
                    str_RptName = "STURAN.rpt";
                    break;
                case "Maritime Services":
                    str_RptName = "MariTime.rpt";
                    str_sp = "company=" + Session["LoginDivisionName"].ToString();
                    break;
                case "Hapag LLoyd":
                    str_RptName = "HAPAG Lloyd.rpt";
                    str_sp = "branchname=" + Session["LoginDivisionName"].ToString() + "~mailid=" + obj_da_hremp.GetMailAdd(Convert.ToInt32(Session["LoginEmpId"]));
                    break;
                case "ULA & K.Line":
                    str_RptName = "ULA & K LINE";
                    str_sp = "branchname=" + Session["LoginDivisionName"].ToString();
                    break;
                case "MaerskLine":
                    str_RptName = "MAERSK.rpt";
                    str_sp = "branchname=" + Session["LoginDivisionName"].ToString();
                    break;
                case "German Express":
                    str_RptName = "GERMAN.rpt";
                    str_sp = "branchname=" + Session["LoginDivisionName"].ToString();
                    break;
                case "OOCL":
                    str_RptName = "OOCL.rpt";
                    break;
                case "NYK Line":
                    str_RptName = "NYK line.rpt";
                    str_sp = "branchname=" + Session["LoginDivisionName"].ToString();
                    break;
                case "Chennai-Shipping Corporation":
                    str_RptName = "FIShippingCorporation.rpt";
                    break;
                case "CMA CGM":
                    str_RptName = "CMA CGM.rpt";
                    str_sp = "jobno=" + txt_jobno.Text.ToString();
                    break;
                case "CSAV Agencies":
                    str_RptName = "CSAV Agencies.rpt";
                    str_sp = "jobno=" + txt_jobno.Text.ToString() + "~branchname=" + Session["LoginDivisionName"].ToString();
                    break;
                case "Evergreen Agency":
                    str_RptName = "Evergreen Agency.rpt";
                    str_sp = "branchname=" + Session["LoginDivisionName"].ToString();
                    break;
                case "Forbes":
                    str_RptName = "Forbes.rpt";
                    str_sp = "jobno=" + txt_jobno.Text.ToString() + "~branchname=" + Session["LoginDivisionName"].ToString();
                    break;
                case "K-Line":
                    str_RptName = "K-Line.rpt";
                    str_sp = "jobno=" + txt_jobno.Text.ToString() + "~branchname=" + Session["LoginDivisionName"].ToString();
                    break;
                case "MSC Agency":
                    str_RptName = "MSC Agency.rpt";
                    str_sp = "branchname=" + Session["LoginDivisionName"].ToString();
                    break;
                case "Seabridge Maritime Agencies":
                    str_RptName = "Seabridge Maritime Agencies.rpt";
                    str_sp = "jobno=" + txt_jobno.Text.ToString();
                    break;
                case "Seashore Ship":
                    str_RptName = "Seashore Ship.rpt";
                    str_sp = "jobno=" + txt_jobno.Text.ToString() + "~branchname=" + Session["LoginDivisionName"].ToString();
                    break;
                case "Swift Freight":
                    str_RptName = "SWIFT FREIGHT.rpt";
                    str_sp = "branchname=" + Session["LoginDivisionName"].ToString() + "~jobno=" + txt_jobno.Text.ToString();
                    break;
                case "Trans Asian Shipping":
                    str_RptName = "Trans Asian Shipping.rpt";
                    str_sp = "branchname=" + Session["LoginDivisionName"].ToString() + "~jobno=" + txt_jobno.Text.ToString();
                    break;
                case "WAN HAI Lines":
                    str_RptName = "WAN HAI Lines.rpt";
                    str_sp = "branchname=" + Session["LoginDivisionName"].ToString();
                    break;

            }
            str_sf = "{FIJobInfo.bid}=" + Convert.ToInt32(Session["LoginBranchid"]) + " and {FIJobInfo.jobno}=" + txt_jobno.Text.ToString() + " and {FIJobInfo.cfsid}=" + hf_cfsid.Value;
            str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
            ScriptManager.RegisterStartupScript(btn_print, typeof(Button), "CoveringLetter", str_Script, true);
            
            Session["str_sfs"] = str_sf;
            Session["str_sp"] = str_sp;
        }

        protected void btn_back_Click(object sender, EventArgs e)
        {
             if (btn_back.ToolTip == "Cancel")
            {
                txt_cfs.Text = "";
                txt_jobno.Text = "";
                ddl_format.Items.Clear();
              
                btn_back.Text = "Back";
                btn_back.ToolTip = "Back";
                btn_back1.Attributes["class"] = "btn ico-back";
                txt_jobno.Focus();
            }
             else
             {
                // this.Response.End();
                 if (Session["home"] != null)
                 {
                     if (Session["home"].ToString() == "CS")
                     {
                         if (Session["StrTranType"] != null)
                         {
                             if (Session["StrTranType"].ToString() == "FI")
                             {
                                 Response.Redirect("../Home/OICSHome.aspx");
                             }

                         }
                     }
                 }
                 else
                 {
                     this.Response.End();
                 }
           
             }

        }
        public void fillddlformat()
        {
            //ddl_format.Items.Add("--FORMAT--");
            ddl_format.Items.Add("Chennai-Shipping Corporation");
            ddl_format.Items.Add("China Shipping");
            ddl_format.Items.Add("CMA CGM");
            ddl_format.Items.Add("CSAV Agencies");
            ddl_format.Items.Add("Diamond Maritime");
            ddl_format.Items.Add("Emirates Shipping");
            ddl_format.Items.Add("Evergreen Agency");
            ddl_format.Items.Add("Forbes");
            ddl_format.Items.Add("General");
            ddl_format.Items.Add("German Express");
            ddl_format.Items.Add("Globe Link");
            ddl_format.Items.Add("Hanjin Shipping");
            ddl_format.Items.Add("Hapag LLoyd");
            ddl_format.Items.Add("K-Line");
            ddl_format.Items.Add("LCL Agencies");
            ddl_format.Items.Add("Logistic Services");
            ddl_format.Items.Add("MaerskLine");
            ddl_format.Items.Add("MSC Agency");
            ddl_format.Items.Add("Oasis Shipping");
            ddl_format.Items.Add("OOCL");
            ddl_format.Items.Add("OOCL-CHENNAI");
            ddl_format.Items.Add("Samsara Shipping");
            ddl_format.Items.Add("Saturn Ship");
            ddl_format.Items.Add("Seabridge Maritime Agencies");
            ddl_format.Items.Add("Seashore Ship");
            ddl_format.Items.Add("Shipping Corporation");
            ddl_format.Items.Add("Swift Freight");
            ddl_format.Items.Add("TeamGlobal");
            ddl_format.Items.Add("Trans Asian Shipping");
            ddl_format.Items.Add("WAN HAI Lines");
            ddl_format.Items.Add("ZIM Integrated");
            ddl_format.Focus();
        }

        protected void txt_jobno_TextChanged(object sender, EventArgs e)
        {
            fn_txtjobno_Changed();
           

        }
        public void fn_txtjobno_Changed()
        {
            if (ddl_format.Items.Count == 0)
            {
                fillddlformat();
                
            }

            DataTable obj_dt = new DataTable();
            //DataAccess.Masters.MasterCustomer obj_da_customer = new DataAccess.Masters.MasterCustomer();
            //DataAccess.ForwardingImports.JobInfo obj_da_fijob = new DataAccess.ForwardingImports.JobInfo();
            if (txt_jobno.Text.ToString() != "")
            {
                obj_dt = obj_da_fijob.ShowJobDetails(Convert.ToInt32(txt_jobno.Text.ToString()), Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(Session["LoginDivisionId"]));
                if (obj_dt.Rows.Count > 0)
                {
                    hf_cfsid.Value = obj_dt.Rows[0][26].ToString();
                    txt_cfs.Text = (obj_da_customer.GetCustomername(Convert.ToInt32(hf_cfsid.Value)));
                }
            }
            txt_cfs.Focus();
            btn_back.Text = "Cancel";
            btn_back.ToolTip = "Cancel";
            btn_back1.Attributes["class"] = "btn ico-cancel";
            UserRights();
        }

        protected void txt_cfs_TextChanged(object sender, EventArgs e)
        {
            fn_txtcfs_Changed();
            txt_cfs.Focus();
            btn_back.Text = "Cancel";
            btn_back.ToolTip = "Cancel";
            btn_back1.Attributes["class"] = "btn ico-cancel";
        }
        public void fn_txtcfs_Changed()
        {
            if (txt_cfs.Text != "")
            {
                //rptclass.CheckCustomer(txtcfs, lst)
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
            //DataAccess.LogDetails obj_da_Log1 = new DataAccess.LogDetails();

            obj_dtlogdetails = obj_da_Log1.InsTempGrpLogdtlsGet(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), 121, "Job", txt_jobno.Text, txt_jobno.Text, Session["StrTranType"].ToString());
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