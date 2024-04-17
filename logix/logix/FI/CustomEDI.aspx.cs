using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.Services;
using System.IO;
using System.Text;
using System.Collections;
using IGM;

namespace logix.FI
{
    public partial class CustomEDI : System.Web.UI.Page
    {

        System.IO.TextWriter TW;

        int int_branchid;
        int int_empid;
        int int_divisionid;
        int int_jobno = 0;
        int int_imdateyear;
        int int_pol;
        int int_pod;
        int int_fd;
        int int_consigneeid;
        int int_noofpkgs;
        int int_pkg;
        int index;
        int int_Contpkg;
        int int_Blpkg;
        int int_logpodid;
        int int_notifyid;

        double int_weight;
        double int_ContWt;
        double int_BlWt;

        DateTime dt_mbldate;
        DateTime dt_imdate;
        DateTime dt_bldate;
        DateTime today;
        DataTable dtCustomEDI = new DataTable();
        DataTable dtCustomEDI1 = new DataTable();
        DataTable dtCustomEDI2 = new DataTable();

        string weight="";

        string str_Trantype;
        string str_VesInfo="";
        string str_CVslcode = "";
        string str_Voyage;
        string str_imocode, imocode;
        string str_mblno;
        string str_imno;
        string str_cfscode;
        string str_linecode="";
        string str_jobtype;
        string str_CargoInfo;
        string str_Lineno;
        string str_sublineno;
        string str_pol;
        string str_fd;
        string str_blno;
        string str_consignee;
        string str_cons;
        string str_cargo;
        string str_itemtype="";
        string str_type;
        string str_pkgtype;
        string str_unicode;
        string str_desc;
        string str_marks;
        string str_ContainerInfo;
        string str_callsign;
        string str_cardno;
        string str_notify;
        string str_noti;
        string str_polcode;
        string str_pod;
        string str_podcode;
        string str_panno;
        string str_podjob;
        string str_jobno;
        string str_igmjob="";
        string str_intjobtype;
        string str_clinecode;
        string str_cfspanno;
        string str_mlopano;
        string str_bondno;
        string str_loginpcode;
        string str_ediuser;
        string srt_itemtype;
        string filename;
        DataAccess.LogDetails obj_da_log = new DataAccess.LogDetails();
        DataAccess.ForwardingImports.JobInfo obj_da_jinfo = new DataAccess.ForwardingImports.JobInfo();
        DataAccess.Masters.MasterPort obj_da_mp = new DataAccess.Masters.MasterPort();
        DataAccess.ForwardingImports.BLDetails obj_da_bldet = new DataAccess.ForwardingImports.BLDetails();
        DataAccess.Masters.MasterPackages obj_da_pack = new DataAccess.Masters.MasterPackages();
        DataAccess.Masters.MasterPort obj_da_port = new DataAccess.Masters.MasterPort();
        DataAccess.ForwardingImports.BLDetails obj_da_fib = new DataAccess.ForwardingImports.BLDetails();
        DataAccess.HR.FrontPage obj_da_hr = new DataAccess.HR.FrontPage();
        DataAccess.ForwardingImports.CargoManifest obj_da_cargo = new DataAccess.ForwardingImports.CargoManifest();
        DataAccess.Accounts.CostingDt obj_da_cost = new DataAccess.Accounts.CostingDt();
        DataAccess.ForwardingImports.JobInfo FIJobobj = new DataAccess.ForwardingImports.JobInfo();
        DataAccess.Masters.MasterCustomer Custobj1 = new DataAccess.Masters.MasterCustomer();
        DataAccess.Masters.MasterPort Portobj = new DataAccess.Masters.MasterPort();
        DataAccess.Masters.MasterVessel Vslobj = new DataAccess.Masters.MasterVessel();
        DataAccess.HR.FrontPage HRFrontObj = new DataAccess.HR.FrontPage();
          DataAccess.ForwardingImports.BLDetails FIBLobj = new DataAccess.ForwardingImports.BLDetails();
        DataAccess.Masters.MasterPackages Pkgsobj = new DataAccess.Masters.MasterPackages();
        Class1 objraj = new Class1();

        protected void Page_Load(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "SpanTagMoveInputBottom();MuiTextField();", true);


            string Ccode = Convert.ToString(Session["Ccode"]);

            if (Ccode != "")
            {

                obj_da_log.GetDataBase(Ccode);
                obj_da_jinfo.GetDataBase(Ccode);
                obj_da_mp.GetDataBase(Ccode);
                obj_da_bldet.GetDataBase(Ccode);
                obj_da_pack.GetDataBase(Ccode);
                obj_da_port.GetDataBase(Ccode);
                obj_da_fib.GetDataBase(Ccode);


                obj_da_hr.GetDataBase(Ccode);
                obj_da_cargo.GetDataBase(Ccode);
                obj_da_cost.GetDataBase(Ccode);
                FIJobobj.GetDataBase(Ccode);
                Custobj1.GetDataBase(Ccode);


                Vslobj.GetDataBase(Ccode);
                HRFrontObj.GetDataBase(Ccode);
                FIBLobj.GetDataBase(Ccode);
                Portobj.GetDataBase(Ccode);
                Pkgsobj.GetDataBase(Ccode);



            }

            try
            {
                ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(btn_cancel);
                ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(btn_cedi);
                ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(btn_igm);
                ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(btn_ligm);
                if (Session["LoginUserName"] == null || Session["LoginEmpId"] == null || Session["LoginDivisionId"] == null || Session["LoginBranchid"] == null)
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alertify.alert('Session TimeOut');window.open('"+ Session["Site"].ToString() + "/','_top');", true);
                }
                else if (Session["StrTranType"] == null)
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alertify.alert('Session TimeOut');window.open('"+ Session["Site"].ToString() + "/FormMain.aspx','_top');", true);
                }
                int_branchid = Convert.ToInt32(Session["LoginBranchid"].ToString());
                int_empid = Convert.ToInt32(Session["LoginEmpId"].ToString());
                int_divisionid = Convert.ToInt32(Session["LoginDivisionId"].ToString());
                str_Trantype = Session["StrTranType"].ToString();
                if (!IsPostBack)
                {
                    try
                    {
                        txt_job.Attributes.Add("OnKeypress", "return IntegerCheck(event);");

                        mdl_cust.Hide();
                        btn_cancel.Text = "Cancel";

                        btn_cancel.ToolTip = "Cancel";
                        btn_cancel1.Attributes["class"] = "btn ico-cancel";

                        txt_job.Focus();
                        int_branchid = Convert.ToInt32(Session["LoginBranchid"].ToString());
                        int_empid = Convert.ToInt32(Session["LoginEmpId"].ToString());
                        int_divisionid = Convert.ToInt32(Session["LoginDivisionId"].ToString());
                        str_Trantype = Session["StrTranType"].ToString();
                    }
                    catch (Exception ex)
                    {
                        string message = ex.Message.ToString();
                        ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
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
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
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


        private void GetVesselInfo()
        {
            try
            {
                int_branchid = Convert.ToInt32(Session["LoginBranchid"].ToString());
                int_empid = Convert.ToInt32(Session["LoginEmpId"].ToString());
                int_divisionid = Convert.ToInt32(Session["LoginDivisionId"].ToString());
                //int_jobno = Convert.ToInt32(hf_jobno.Value);

                str_VesInfo = "";
                str_VesInfo = str_VesInfo + "<manifest>2.0";
                str_VesInfo = str_VesInfo + System.Environment.NewLine;
                str_VesInfo = str_VesInfo + "<consoligm>";
                str_VesInfo = str_VesInfo + System.Environment.NewLine;
                str_VesInfo = str_VesInfo + "<conscargo>";
                TW.WriteLine(str_VesInfo);
                TW.Flush();
                DataTable obj_dt_cedi = new DataTable();
               // DataAccess.ForwardingImports.JobInfo obj_da_jinfo = new DataAccess.ForwardingImports.JobInfo();
                obj_dt_cedi = obj_da_jinfo.ShowJobDetails(int_jobno, int_branchid, int_divisionid);
                if (obj_dt_cedi.Rows.Count > 0)
                {
                    if (obj_dt_cedi.Rows[0]["cvslcode"].ToString() != "")
                    {
                        str_CVslcode = obj_dt_cedi.Rows[0]["cvslcode"].ToString();
                    }

                    if (obj_dt_cedi.Rows[0]["voyage"].ToString() != "")
                    {
                        str_Voyage = obj_dt_cedi.Rows[0]["voyage"].ToString();
                    }

                    str_imocode = obj_dt_cedi.Rows[0]["imocode"].ToString();
                    str_mblno = obj_dt_cedi.Rows[0]["mblno"].ToString();
                    dt_mbldate = Convert.ToDateTime(obj_dt_cedi.Rows[0]["mbldate"].ToString());
                    str_imno = obj_dt_cedi.Rows[0]["imno"].ToString();
                    dt_imdate = Convert.ToDateTime(obj_dt_cedi.Rows[0]["imdate"].ToString());
                    str_cfscode = obj_dt_cedi.Rows[0]["cfscode"].ToString();
                    str_linecode = obj_dt_cedi.Rows[0]["clinecode"].ToString();
                    if (obj_dt_cedi.Rows[0]["jobtype"].ToString() == "3")
                    {
                        str_jobtype = "FCL";
                    }
                    else
                    {
                        str_jobtype = "LCL";
                    }

                    int_imdateyear = dt_imdate.Year;
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);

            }
        }

        private void GetCargoInfo()
        {
            try
            {
                int_branchid = Convert.ToInt32(Session["LoginBranchid"].ToString());
                int_empid = Convert.ToInt32(Session["LoginEmpId"].ToString());
                int_divisionid = Convert.ToInt32(Session["LoginDivisionId"].ToString());
                //int_jobno = Convert.ToInt32(hf_jobno.Value);

                //DataAccess.Masters.MasterPort obj_da_mp = new DataAccess.Masters.MasterPort();
                //DataAccess.ForwardingImports.BLDetails obj_da_bldet = new DataAccess.ForwardingImports.BLDetails();
                //DataAccess.Masters.MasterPackages obj_da_pack = new DataAccess.Masters.MasterPackages();
                DataTable obj_dt_bldet = new DataTable();
                obj_dt_bldet = obj_da_bldet.GetBLDetailJobno(int_jobno, int_branchid, int_divisionid);
                if (obj_dt_bldet.Rows.Count > 0)
                {
                    for (int i = 0; i < obj_dt_bldet.Rows.Count; i++)
                    {
                        str_CargoInfo = "";
                        str_CargoInfo = str_CargoInfo + "F";
                        str_CargoInfo = str_CargoInfo + Convert.ToChar(29);
                        str_CargoInfo = str_CargoInfo + "AACCP2294GCNMAA1" + Convert.ToChar(29) + Convert.ToChar(29) + Convert.ToChar(29);
                        str_CargoInfo = str_CargoInfo + str_CVslcode.Trim().Replace(System.Environment.NewLine, "");
                        str_CargoInfo = str_CargoInfo + Convert.ToChar(29);
                        str_CargoInfo = str_CargoInfo + str_Voyage.Replace(System.Environment.NewLine, "");
                        str_CargoInfo = str_CargoInfo + Convert.ToChar(29);
                        str_Lineno = obj_dt_bldet.Rows[i]["linenumber"].ToString().Replace(System.Environment.NewLine, "");
                        str_CargoInfo = str_CargoInfo + str_Lineno;
                        str_sublineno = obj_dt_bldet.Rows[i]["sublineno"].ToString().Replace(System.Environment.NewLine, "");
                        str_CargoInfo = str_CargoInfo + Convert.ToChar(29);
                        str_CargoInfo = str_CargoInfo + str_sublineno.Replace(System.Environment.NewLine, "");
                        str_CargoInfo = str_CargoInfo + Convert.ToChar(29);
                        str_CargoInfo = str_CargoInfo + str_mblno.Replace(System.Environment.NewLine, "");
                        str_CargoInfo = str_CargoInfo + Convert.ToChar(29);
                        str_CargoInfo = str_CargoInfo + dt_mbldate.ToString("ddMMyyyy");
                        int_pol = Convert.ToInt32(obj_dt_bldet.Rows[i]["pol"].ToString());
                        int_pod = Convert.ToInt32(obj_dt_bldet.Rows[i]["pod"].ToString());
                        str_pol = obj_da_mp.GetPortcode(obj_da_mp.GetPortname(int_pol)).Replace(System.Environment.NewLine, "");
                        str_CargoInfo = str_CargoInfo + Convert.ToChar(29);
                        str_CargoInfo = str_CargoInfo + str_pol.Replace("<br/>", "");
                        int_fd = Convert.ToInt32(obj_dt_bldet.Rows[i]["fd"].ToString());
                        str_fd = obj_da_mp.GetPortcode(obj_da_mp.GetPortname(int_fd)).Replace(System.Environment.NewLine, "");
                        str_CargoInfo = str_CargoInfo + Convert.ToChar(29);
                        str_CargoInfo = str_CargoInfo + str_fd.Replace(System.Environment.NewLine, "");
                        str_blno = obj_dt_bldet.Rows[i]["blno"].ToString().Replace(System.Environment.NewLine, "");
                        str_CargoInfo = str_CargoInfo + Convert.ToChar(29);
                        str_CargoInfo = str_CargoInfo + str_blno.Replace(System.Environment.NewLine, "");
                        dt_bldate = Convert.ToDateTime(obj_dt_bldet.Rows[i]["bldate"].ToString().Replace(System.Environment.NewLine, ""));
                        str_CargoInfo = str_CargoInfo + Convert.ToChar(29);
                        str_CargoInfo = str_CargoInfo + dt_bldate.ToString("ddMMyyyy");
                        str_CargoInfo = str_CargoInfo + Convert.ToChar(29);
                        int_consigneeid = Convert.ToInt32(obj_dt_bldet.Rows[i]["consigneeid"].ToString());
                        str_consignee = "";
                        str_consignee = obj_dt_bldet.Rows[i]["consignee"].ToString().Replace(System.Environment.NewLine, "").Trim();
                        str_consignee = obj_dt_bldet.Rows[i]["caddress"].ToString().Replace(System.Environment.NewLine, "").Trim();

                        str_cons = str_consignee.Replace("\r", " ");
                        str_cons = str_cons.Replace("\n", " ");

                        if (str_cons.Length > 105)
                        {
                            str_CargoInfo = str_CargoInfo + str_cons.Substring(0, 35).Replace("<br/>", "");
                            str_CargoInfo = str_CargoInfo + Convert.ToChar(29);
                            str_CargoInfo = str_CargoInfo + str_cons.Substring(36, 35).Replace("<br/>", "");
                            str_CargoInfo = str_CargoInfo + Convert.ToChar(29);
                            str_CargoInfo = str_CargoInfo + str_cons.Substring(71, 35).Replace("<br/>", "");
                            str_CargoInfo = str_CargoInfo + Convert.ToChar(29);
                            str_CargoInfo = str_CargoInfo + str_cons.Substring(106, (str_cons.Length - 106)).Replace("<br/>", "");
                            //str_CargoInfo = str_CargoInfo + str_cons.Substring(106, 35).Replace("<br/>", "");
                        }
                        else if (str_cons.Length > 70 && str_cons.Length <= 105)
                        {
                            str_CargoInfo = str_CargoInfo + str_cons.Substring(0, 20).Replace("<br/>", "");
                            str_CargoInfo = str_CargoInfo + Convert.ToChar(29);
                            str_CargoInfo = str_CargoInfo + str_cons.Substring(21, 20).Replace("<br/>", "");
                            str_CargoInfo = str_CargoInfo + Convert.ToChar(29);
                            str_CargoInfo = str_CargoInfo + str_cons.Substring(41, 30).Replace("<br/>", "");
                            str_CargoInfo = str_CargoInfo + Convert.ToChar(29);
                            str_CargoInfo = str_CargoInfo + str_cons.Substring(71, (str_cons.Length - 71)).Replace("<br/>", "");
                            //str_CargoInfo = str_CargoInfo + str_cons.Substring(71, 35).Replace("<br/>", "");
                        }
                        else if (str_cons.Length > 35 && str_cons.Length <= 70)
                        {
                            str_CargoInfo = str_CargoInfo + str_cons.Substring(0, 10).Replace("<br/>", "");
                            str_CargoInfo = str_CargoInfo + Convert.ToChar(29);
                            str_CargoInfo = str_CargoInfo + str_cons.Substring(11, 10).Replace("<br/>", "");
                            str_CargoInfo = str_CargoInfo + Convert.ToChar(29);
                            str_CargoInfo = str_CargoInfo + str_cons.Substring(21, 15).Replace("<br/>", "");
                            str_CargoInfo = str_CargoInfo + Convert.ToChar(29);
                            str_CargoInfo = str_CargoInfo + str_cons.Substring(36, (str_cons.Length - 36)).Replace("<br/>", "");
                            //str_CargoInfo = str_CargoInfo + str_cons.Substring(36, 35).Replace("<br/>", "");
                        }
                        else if (str_cons.Length <= 35)
                        {
                            if (str_cons.Length > 10)
                            {
                                str_CargoInfo = str_CargoInfo + str_cons.Substring(0, 10);
                                str_CargoInfo = str_CargoInfo + Convert.ToChar(29);
                                str_CargoInfo = str_CargoInfo + str_cons.Substring(11, 10).Replace("<br/>", "");
                                str_CargoInfo = str_CargoInfo + Convert.ToChar(29);
                                str_CargoInfo = str_CargoInfo + str_cons.Substring(21, 10).Replace("<br/>", "");
                                str_CargoInfo = str_CargoInfo + Convert.ToChar(29);
                                str_CargoInfo = str_CargoInfo + str_cons.Substring(31, (str_cons.Length - 31)).Replace("<br/>", "");
                                //str_CargoInfo = str_CargoInfo + str_cons.Substring(31, 5).Replace("<br/>", "");
                            }
                            else
                            {
                                str_CargoInfo = str_CargoInfo + str_cons;
                                str_CargoInfo = str_CargoInfo + Convert.ToChar(29);
                                str_CargoInfo = str_CargoInfo + ".";
                                str_CargoInfo = str_CargoInfo + Convert.ToChar(29);
                                str_CargoInfo = str_CargoInfo + ".";
                                str_CargoInfo = str_CargoInfo + Convert.ToChar(29);
                                str_CargoInfo = str_CargoInfo + ".";
                            }
                        }

                        str_CargoInfo = str_CargoInfo + Convert.ToChar(29);
                        str_CargoInfo = str_CargoInfo + Convert.ToChar(29);
                        str_CargoInfo = str_CargoInfo + Convert.ToChar(29);
                        str_CargoInfo = str_CargoInfo + Convert.ToChar(29);
                        str_CargoInfo = str_CargoInfo + Convert.ToChar(29);

                        str_cargo = obj_dt_bldet.Rows[i]["cargo"].ToString().Replace("<br/>", "");
                        str_CargoInfo = str_CargoInfo + "C";
                        str_itemtype = obj_dt_bldet.Rows[i]["itemtype"].ToString().Replace("<br/>", "");
                        str_CargoInfo = str_CargoInfo + Convert.ToChar(29);
                        if (str_itemtype == "")
                        {
                            str_CargoInfo = str_CargoInfo + "OT";
                        }
                        else
                        {
                            str_CargoInfo = str_CargoInfo + str_itemtype;
                        }

                        str_type = obj_dt_bldet.Rows[i]["cargommt"].ToString();
                        str_CargoInfo = str_CargoInfo + Convert.ToChar(29);
                        if (str_type == "")
                        {
                            str_CargoInfo = str_CargoInfo + "LC";
                        }
                        else
                        {
                            str_CargoInfo = str_CargoInfo + str_type;
                        }

                        str_CargoInfo = str_CargoInfo + Convert.ToChar(29);
                        str_CargoInfo = str_CargoInfo + str_cfscode;
                        int_noofpkgs = Convert.ToInt32(obj_dt_bldet.Rows[i]["noofpkgs"].ToString().Replace("<br/>", "").Trim());
                        str_CargoInfo = str_CargoInfo + Convert.ToChar(29);
                        str_CargoInfo = str_CargoInfo + (int_noofpkgs.ToString().Replace("<br/>", ""));
                        int_pkg = Convert.ToInt32(obj_dt_bldet.Rows[i]["packageid"].ToString().Replace("<br/>", "").Trim());
                        str_pkgtype = obj_da_pack.GetPackageCodePkgID(int_pkg);
                        str_CargoInfo = str_CargoInfo + Convert.ToChar(29);
                        str_CargoInfo = str_CargoInfo + str_pkgtype.Trim().Replace("<br/>", "");
                        int_weight =Math.Round(Convert.ToDouble(obj_dt_bldet.Rows[i]["grweight"].ToString().Replace("<br/>", "").Trim()),2);
                     
                        str_CargoInfo = str_CargoInfo + Convert.ToChar(29);
                        str_CargoInfo = str_CargoInfo + Convert.ToDouble((int_weight).ToString("#0.000").Replace("<br/>", ""));
                        str_CargoInfo = str_CargoInfo + Convert.ToChar(29);
                        str_CargoInfo = str_CargoInfo + "KGS";
                        str_CargoInfo = str_CargoInfo + Convert.ToChar(29);
                        str_CargoInfo = str_CargoInfo + Convert.ToChar(29);

                        str_marks = obj_dt_bldet.Rows[i]["marks"].ToString().Replace("<br/>", "").Trim();
                        str_CargoInfo = str_CargoInfo + Convert.ToChar(29);
                        str_CargoInfo = str_CargoInfo + str_marks;
                        str_desc = obj_dt_bldet.Rows[i]["descn"].ToString().Replace("<br/>", "").Trim();
                        str_CargoInfo = str_CargoInfo + Convert.ToChar(29);
                        str_CargoInfo = str_CargoInfo + str_desc;
                        imocode = obj_dt_bldet.Rows[i]["imocode"].ToString().Replace("<br/>", "").Trim();
                        str_CargoInfo = str_CargoInfo + Convert.ToChar(29);
                        str_CargoInfo = str_CargoInfo + imocode;
                        str_unicode = obj_dt_bldet.Rows[i]["unocode"].ToString().Replace("<br/>", "").Trim();
                        str_CargoInfo = str_CargoInfo + Convert.ToChar(29);
                        str_CargoInfo = str_CargoInfo + str_unicode.Replace("<br/>", "").Trim();
                        str_CargoInfo = str_CargoInfo + Convert.ToChar(29);
                        str_CargoInfo = str_CargoInfo + Convert.ToChar(29);
                        str_CargoInfo = str_CargoInfo + Convert.ToChar(29);
                        str_CargoInfo = str_CargoInfo + Convert.ToChar(29);
                        str_CargoInfo = str_CargoInfo + Convert.ToChar(29);

                        TW.WriteLine(str_CargoInfo);
                        TW.Flush();
                    }
                }
                str_CargoInfo = "";
                str_CargoInfo = str_CargoInfo + "<END-conscargo>";
                TW.WriteLine(str_CargoInfo);
                TW.Flush();
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);

            }
        }

        private void GetContainerInfo()
        {
            try
            {
                int_branchid = Convert.ToInt32(Session["LoginBranchid"].ToString());
                int_empid = Convert.ToInt32(Session["LoginEmpId"].ToString());
                int_divisionid = Convert.ToInt32(Session["LoginDivisionId"].ToString());
                //int_jobno = Convert.ToInt32(hf_jobno.Value);

                str_ContainerInfo = "";
                str_ContainerInfo = str_ContainerInfo + "<conscont>";
                TW.WriteLine(str_ContainerInfo);
                TW.Flush();
                DataTable obj_dt_bldet = new DataTable();
                //DataAccess.ForwardingImports.BLDetails obj_da_bldet = new DataAccess.ForwardingImports.BLDetails();
                obj_dt_bldet = obj_da_bldet.GetBLContDtJobno(int_jobno, int_branchid, int_divisionid);
                if (obj_dt_bldet.Rows.Count > 0)
                {
                    for (int i = 0; i < obj_dt_bldet.Rows.Count; i++)
                    {
                        str_ContainerInfo = "";
                        str_ContainerInfo = "F" + Convert.ToChar(29);
                        str_ContainerInfo = str_ContainerInfo + "AACCP2294GCNMAA1" + Convert.ToChar(29) + Convert.ToChar(29) + Convert.ToChar(29);
                        str_ContainerInfo = str_ContainerInfo + str_CVslcode.Replace("<br/>", "") + Convert.ToChar(29);
                        str_ContainerInfo = str_ContainerInfo + str_Voyage.Replace("<br/>", "");
                        str_ContainerInfo = str_ContainerInfo + Convert.ToChar(29);
                        str_ContainerInfo = str_ContainerInfo + obj_dt_bldet.Rows[i]["linenumber"].ToString().Replace("<br/>", "");
                        str_ContainerInfo = str_ContainerInfo + Convert.ToChar(29);
                        str_ContainerInfo = str_ContainerInfo + obj_dt_bldet.Rows[i]["sublineno"].ToString().Replace("<br/>", "");
                        str_ContainerInfo = str_ContainerInfo + Convert.ToChar(29);
                        str_ContainerInfo = str_ContainerInfo + obj_dt_bldet.Rows[i]["containerno"].ToString().Replace("<br/>", "");
                        str_ContainerInfo = str_ContainerInfo + Convert.ToChar(29);
                        str_ContainerInfo = str_ContainerInfo + obj_dt_bldet.Rows[i]["sealno"].ToString().Replace("<br/>", "");
                        str_ContainerInfo = str_ContainerInfo + Convert.ToChar(29);
                        str_ContainerInfo = str_ContainerInfo + str_linecode.Replace("<br/>", "");
                        str_ContainerInfo = str_ContainerInfo + Convert.ToChar(29);
                        str_ContainerInfo = str_ContainerInfo + str_jobtype + Convert.ToChar(29);
                        str_ContainerInfo = str_ContainerInfo + obj_dt_bldet.Rows[i]["noofpkgs"].ToString().Replace("<br/>", "");
                        str_ContainerInfo = str_ContainerInfo + Convert.ToChar(29);
                        if (obj_dt_bldet.Rows[i]["grweight"].ToString() != "")
                        {
                            //str_ContainerInfo = str_ContainerInfo + Convert.ToDouble(string.Format("{0:0.000}", (Convert.ToDouble(obj_dt_bldet.Rows[i]["grweight"]) / 1000)).ToString());    
                            str_ContainerInfo = str_ContainerInfo +Convert.ToDouble(obj_dt_bldet.Rows[i]["grweight"]).ToString("#0.000");        
                        }
                        str_ContainerInfo = str_ContainerInfo + Convert.ToChar(29);
                        str_ContainerInfo = str_ContainerInfo + obj_dt_bldet.Rows[i]["isocode"].ToString().Replace("<br/>", "");
                        str_ContainerInfo = str_ContainerInfo + Convert.ToChar(29);
                        str_ContainerInfo = str_ContainerInfo + obj_dt_bldet.Rows[i]["socflag"].ToString().Replace("<br/>", "");
                        str_ContainerInfo = str_ContainerInfo + Convert.ToChar(29);
                        TW.WriteLine(str_ContainerInfo);
                        TW.Flush();
                    }
                }
                str_ContainerInfo = "";
                str_ContainerInfo = str_ContainerInfo + "<END-conscont>";
                str_ContainerInfo = str_ContainerInfo + System.Environment.NewLine;
                str_ContainerInfo = str_ContainerInfo + "<END-manifest>";
                TW.WriteLine(str_ContainerInfo);
                TW.Flush();
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);

            }
        }

        private void GetMumbaiVesselInfo()
        {
            try
            {
                int_branchid = Convert.ToInt32(Session["LoginBranchid"].ToString());
                int_empid = Convert.ToInt32(Session["LoginEmpId"].ToString());
                int_divisionid = Convert.ToInt32(Session["LoginDivisionId"].ToString());
                //int_jobno = Convert.ToInt32(hf_jobno.Value);

                str_VesInfo = "";
                str_VesInfo = str_VesInfo + "<consoligm>";
                str_VesInfo = str_VesInfo + System.Environment.NewLine;
                str_VesInfo = str_VesInfo + "<conscargo>";
                TW.WriteLine(str_VesInfo);
                TW.Flush();

                DataTable obj_dt_jinfo = new DataTable();
                //DataAccess.ForwardingImports.JobInfo obj_da_jinfo = new DataAccess.ForwardingImports.JobInfo();

                obj_dt_jinfo = obj_da_jinfo.ShowJobDetails(int_jobno, int_branchid, int_divisionid);
                if (obj_dt_jinfo.Rows.Count > 0)
                {
                    str_callsign = "";
                    str_CVslcode = obj_dt_jinfo.Rows[0]["callsign"].ToString().Replace("<br/>", "");
                    if (obj_dt_jinfo.Rows[0]["voyage"].ToString() != "")
                    {
                        str_Voyage = obj_dt_jinfo.Rows[0]["voyage"].ToString().Replace("<br/>", "");
                    }
                    str_mblno = obj_dt_jinfo.Rows[0]["mblno"].ToString().Replace("<br/>", "");
                    dt_mbldate = Convert.ToDateTime(obj_dt_jinfo.Rows[0]["mbldate"].ToString().Replace("<br/>", ""));
                    str_imno = obj_dt_jinfo.Rows[0]["imno"].ToString().Replace("<br/>", "");
                    dt_imdate = Convert.ToDateTime(obj_dt_jinfo.Rows[0]["imdate"].ToString().Replace("<br/>", ""));
                    str_cfscode = obj_dt_jinfo.Rows[0]["cfscode"].ToString().Replace("<br/>", "");
                    str_linecode = obj_dt_jinfo.Rows[0]["clinecode"].ToString().Replace("<br/>", "");
                    if (obj_dt_jinfo.Rows[0]["jobtype"].ToString() == "3")
                    {
                        str_jobtype = "FCL";
                    }
                    else
                    {
                        str_jobtype = "LCL";
                    }
                    int_imdateyear = dt_imdate.Year;
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);

            }
        }

        private void GetMumbaiCargoInfo()
        {
            try
            {
                int_branchid = Convert.ToInt32(Session["LoginBranchid"].ToString());
                int_empid = Convert.ToInt32(Session["LoginEmpId"].ToString());
                int_divisionid = Convert.ToInt32(Session["LoginDivisionId"].ToString());
                //int_jobno = Convert.ToInt32(hf_jobno.Value);

                DataTable obj_dt_bldet = new DataTable();
                //DataAccess.ForwardingImports.BLDetails obj_da_bldet = new DataAccess.ForwardingImports.BLDetails();
                //DataAccess.Masters.MasterPort obj_da_port = new DataAccess.Masters.MasterPort();
                //DataAccess.Masters.MasterPackages obj_da_pack = new DataAccess.Masters.MasterPackages();
                obj_dt_bldet = obj_da_bldet.GetBLDetailJobno(int_jobno, int_branchid, int_divisionid);
                if (obj_dt_bldet.Rows.Count > 0)
                {
                    for (int i = 0; i < obj_dt_bldet.Rows.Count; i++)
                    {
                        str_CargoInfo = "";
                        str_CargoInfo = str_CargoInfo + "F";
                        str_CargoInfo = str_CargoInfo + Convert.ToChar(29);
                        int_pod = Convert.ToInt32(obj_dt_bldet.Rows[i]["pod"].ToString());

                        if (int_pod == 11316)
                        {
                            if (int_branchid == 5)
                            {
                                str_CargoInfo = str_CargoInfo + "AAICS2726ECNNSA1" + Convert.ToChar(29) + str_imno + Convert.ToChar(29) + int_imdateyear + Convert.ToChar(29);
                            }
                            else
                            {
                                str_CargoInfo = str_CargoInfo + str_cardno + Convert.ToChar(29) + str_imno + Convert.ToChar(29) + int_imdateyear + Convert.ToChar(29);
                            }
                        }
                        else
                        {
                            str_CargoInfo = str_CargoInfo + str_cardno + Convert.ToChar(29) + str_imno + Convert.ToChar(29) + int_imdateyear + Convert.ToChar(29);
                        }


                        str_CargoInfo = str_CargoInfo + str_CVslcode.Replace("<br/>", "");
                        str_CargoInfo = str_CargoInfo + Convert.ToChar(29);
                        str_CargoInfo = str_CargoInfo + str_Voyage.Replace("<br/>", "");
                        str_CargoInfo = str_CargoInfo + Convert.ToChar(29);
                        str_Lineno = obj_dt_bldet.Rows[i]["linenumber"].ToString().Replace("<br/>", "");
                        str_CargoInfo = str_CargoInfo + str_Lineno;
                        str_sublineno = obj_dt_bldet.Rows[i]["sublineno"].ToString().Replace("<br/>", "");
                        str_CargoInfo = str_CargoInfo + Convert.ToChar(29);
                        str_CargoInfo = str_CargoInfo + str_sublineno.Replace("<br/>", "");
                        str_CargoInfo = str_CargoInfo + Convert.ToChar(29);
                        str_CargoInfo = str_CargoInfo + str_mblno.Replace("<br/>", "");
                        str_CargoInfo = str_CargoInfo + Convert.ToChar(29);
                        str_CargoInfo = str_CargoInfo + dt_mbldate.ToString("ddmmyyyy");
                        int_pol = Convert.ToInt32(obj_dt_bldet.Rows[i]["transhipedat"].ToString());
                        str_pol = obj_da_port.GetPortcode(obj_da_port.GetPortname(int_pol)).Replace("<br/>", "");
                        str_CargoInfo = str_CargoInfo + Convert.ToChar(29);
                        str_CargoInfo = str_CargoInfo + str_pol.Replace("<br/>", "");
                        int_fd = Convert.ToInt32(obj_dt_bldet.Rows[i]["pod"].ToString());
                        str_fd = obj_da_port.GetPortcode(obj_da_port.GetPortname(int_fd)).Replace("<br/>", "");
                        str_CargoInfo = str_CargoInfo + Convert.ToChar(29);
                        str_CargoInfo = str_CargoInfo + str_fd;
                        str_blno = obj_dt_bldet.Rows[i]["blno"].ToString().Replace("<br/>", "");
                        str_CargoInfo = str_CargoInfo + Convert.ToChar(29);
                        str_CargoInfo = str_CargoInfo + str_blno;
                        dt_bldate = Convert.ToDateTime(obj_dt_bldet.Rows[i]["bldate"].ToString());
                        str_CargoInfo = str_CargoInfo + Convert.ToChar(29);
                        str_CargoInfo = str_CargoInfo + dt_bldate.ToString("ddMMyyyy");
                        str_CargoInfo = str_CargoInfo + Convert.ToChar(29);
                        int_consigneeid = Convert.ToInt32(obj_dt_bldet.Rows[i]["consigneeid"].ToString());
                        str_consignee = "";
                        str_consignee = obj_dt_bldet.Rows[i]["consignee"].ToString().Replace("<br/>", "").Trim();
                        str_consignee = obj_dt_bldet.Rows[i]["caddress"].ToString().Replace("<br/>", "").Trim();

                        str_cons = str_consignee.Replace("\r", " ");
                        str_cons = str_cons.Replace("\n", " ");
                        if (str_cons.Length > 105)
                        {
                            str_CargoInfo = str_CargoInfo + str_cons.Substring(0, 35).Replace("<br/>", "");
                            str_CargoInfo = str_CargoInfo + Convert.ToChar(29);
                            str_CargoInfo = str_CargoInfo + str_cons.Substring(36, 35).Replace("<br/>", "");
                            str_CargoInfo = str_CargoInfo + Convert.ToChar(29);
                            str_CargoInfo = str_CargoInfo + str_cons.Substring(71, 35).Replace("<br/>", "");
                            str_CargoInfo = str_CargoInfo + Convert.ToChar(29);
                            str_CargoInfo = str_CargoInfo + str_cons.Substring(106, (str_cons.Length - 106)).Replace("<br/>", "");
                            //str_CargoInfo = str_CargoInfo + str_cons.Substring(106, 35).Replace("<br/>", "");
                        }
                        else if (str_cons.Length > 70 && str_cons.Length <= 105)
                        {
                            str_CargoInfo = str_CargoInfo + str_cons.Substring(1, 20).Trim().Replace("<br/>", "");
                            str_CargoInfo = str_CargoInfo + Convert.ToChar(29);
                            str_CargoInfo = str_CargoInfo + str_cons.Substring(21, 20).Trim().Replace("<br/>", "");
                            str_CargoInfo = str_CargoInfo + Convert.ToChar(29);
                            str_CargoInfo = str_CargoInfo + str_cons.Substring(41, 30).Trim().Replace("<br/>", "");
                            str_CargoInfo = str_CargoInfo + Convert.ToChar(29);
                            str_CargoInfo = str_CargoInfo + str_cons.Substring(71, (str_cons.Length - 71)).Trim().Replace("<br/>", "");
                            //str_CargoInfo = str_CargoInfo + str_cons.Substring(71, 35).Replace("<br/>", "");
                        }
                        else if (str_cons.Length > 35 && str_cons.Length <= 70)
                        {
                            str_CargoInfo = str_CargoInfo + str_cons.Substring(0, 10).Replace("<br/>", "");
                            str_CargoInfo = str_CargoInfo + Convert.ToChar(29);
                            str_CargoInfo = str_CargoInfo + str_cons.Substring(11, 10).Replace("<br/>", "");
                            str_CargoInfo = str_CargoInfo + Convert.ToChar(29);
                            str_CargoInfo = str_CargoInfo + str_cons.Substring(21, 15).Replace("<br/>", "");
                            str_CargoInfo = str_CargoInfo + Convert.ToChar(29);
                            str_CargoInfo = str_CargoInfo + str_cons.Substring(36, (str_cons.Length - 36)).Replace("<br/>", "");
                            //str_CargoInfo = str_CargoInfo + str_cons.Substring(36, 35).Replace("<br/>", "");
                        }
                        else if (str_cons.Length <= 35)
                        {
                            if (str_cons.Length > 10)
                            {
                                str_CargoInfo = str_CargoInfo + str_cons.Substring(0, 10).Replace("<br/>", "");
                                str_CargoInfo = str_CargoInfo + Convert.ToChar(29);
                                str_CargoInfo = str_CargoInfo + str_cons.Substring(11, 10).Replace("<br/>", "");
                                str_CargoInfo = str_CargoInfo + Convert.ToChar(29);
                                str_CargoInfo = str_CargoInfo + str_cons.Substring(21, 10).Replace("<br/>", "");
                                str_CargoInfo = str_CargoInfo + Convert.ToChar(29);
                                str_CargoInfo = str_CargoInfo + str_cons.Substring(31, (str_cons.Length - 31)).Replace("<br/>", "");
                                //str_CargoInfo = str_CargoInfo + str_cons.Substring(31, 5).Replace("<br/>", "");
                            }
                            else
                            {
                                str_CargoInfo = str_CargoInfo + str_cons;
                                str_CargoInfo = str_CargoInfo + Convert.ToChar(29);
                                str_CargoInfo = str_CargoInfo + ".";
                                str_CargoInfo = str_CargoInfo + Convert.ToChar(29);
                                str_CargoInfo = str_CargoInfo + ".";
                                str_CargoInfo = str_CargoInfo + Convert.ToChar(29);
                                str_CargoInfo = str_CargoInfo + ".";
                            }
                        }

                        str_CargoInfo = str_CargoInfo + Convert.ToChar(29);

                        str_notify = "";
                        str_notify = obj_dt_bldet.Rows[i]["notifyparty"].ToString().Replace("<br/>", "").Trim();
                        str_notify = obj_dt_bldet.Rows[i]["naddress"].ToString().Replace("<br/>", "").Trim();
                        str_noti = str_notify.Replace("\r", " ");
                        str_noti = str_noti.Replace("\n", " ");

                        if (str_noti.Length > 105)
                        {
                            str_CargoInfo = str_CargoInfo + str_noti.Substring(0, 35).Replace("<br/>", "");
                            str_CargoInfo = str_CargoInfo + Convert.ToChar(29);
                            str_CargoInfo = str_CargoInfo + str_noti.Substring(36, 35).Replace("<br/>", "");
                            str_CargoInfo = str_CargoInfo + Convert.ToChar(29);
                            str_CargoInfo = str_CargoInfo + str_noti.Substring(71, 35).Replace("<br/>", "");
                            str_CargoInfo = str_CargoInfo + Convert.ToChar(29);
                            str_CargoInfo = str_CargoInfo + str_noti.Substring(106, (str_noti.Length - 106)).Replace("<br/>", "");
                            //str_CargoInfo = str_CargoInfo + str_noti.Substring(106, 35).Replace("<br/>", "");
                        }
                        else if (str_noti.Length > 70 && str_cons.Length <= 105)
                        {
                            str_CargoInfo = str_CargoInfo + str_noti.Substring(1, 20).Trim().Replace("<br/>", "");
                            str_CargoInfo = str_CargoInfo + Convert.ToChar(29);
                            str_CargoInfo = str_CargoInfo + str_noti.Substring(21, 20).Trim().Replace("<br/>", "");
                            str_CargoInfo = str_CargoInfo + Convert.ToChar(29);
                            str_CargoInfo = str_CargoInfo + str_noti.Substring(41, 30).Trim().Replace("<br/>", "");
                            str_CargoInfo = str_CargoInfo + Convert.ToChar(29);
                            str_CargoInfo = str_CargoInfo + str_noti.Substring(71, (str_noti.Length - 71)).Trim().Replace("<br/>", "");
                            //str_CargoInfo = str_CargoInfo + str_noti.Substring(71, 35).Replace("<br/>", "");
                        }
                        else if (str_noti.Length > 35 && str_cons.Length <= 70)
                        {
                            str_CargoInfo = str_CargoInfo + str_noti.Substring(0, 10).Replace("<br/>", "");
                            str_CargoInfo = str_CargoInfo + Convert.ToChar(29);
                            str_CargoInfo = str_CargoInfo + str_noti.Substring(11, 10).Replace("<br/>", "");
                            str_CargoInfo = str_CargoInfo + Convert.ToChar(29);
                            str_CargoInfo = str_CargoInfo + str_noti.Substring(21, 15).Replace("<br/>", "");
                            str_CargoInfo = str_CargoInfo + Convert.ToChar(29);
                            str_CargoInfo = str_CargoInfo + str_noti.Substring(36, (str_noti.Length - 36)).Replace("<br/>", "");
                            //str_CargoInfo = str_CargoInfo + str_noti.Substring(36, 35).Replace("<br/>", "");
                        }
                        else if (str_noti.Length <= 35)
                        {
                            if (str_noti.Length > 10)
                            {
                                str_CargoInfo = str_CargoInfo + str_noti.Substring(0, 10).Replace("<br/>", "");
                                str_CargoInfo = str_CargoInfo + Convert.ToChar(29);
                                str_CargoInfo = str_CargoInfo + str_noti.Substring(11, 10).Replace("<br/>", "");
                                str_CargoInfo = str_CargoInfo + Convert.ToChar(29);
                                str_CargoInfo = str_CargoInfo + str_noti.Substring(21, 10).Replace("<br/>", "");
                                str_CargoInfo = str_CargoInfo + Convert.ToChar(29);
                                str_CargoInfo = str_CargoInfo + str_noti.Substring(31, (str_noti.Length - 31)).Replace("<br/>", "");
                                //str_CargoInfo = str_CargoInfo + str_noti.Substring(31, 5).Replace("<br/>", "");
                            }
                            else
                            {
                                str_CargoInfo = str_CargoInfo + str_noti;
                                str_CargoInfo = str_CargoInfo + Convert.ToChar(29);
                                str_CargoInfo = str_CargoInfo + ".";
                                str_CargoInfo = str_CargoInfo + Convert.ToChar(29);
                                str_CargoInfo = str_CargoInfo + ".";
                                str_CargoInfo = str_CargoInfo + Convert.ToChar(29);
                                str_CargoInfo = str_CargoInfo + ".";
                            }
                        }

                        str_CargoInfo = str_CargoInfo + Convert.ToChar(29);

                        str_cargo = obj_dt_bldet.Rows[i]["cargo"].ToString().Replace("<br/>", "");
                        str_CargoInfo = str_CargoInfo + "C";
                        str_itemtype = obj_dt_bldet.Rows[i]["itemtype"].ToString().Replace("<br/>", "");
                        str_CargoInfo = str_CargoInfo + Convert.ToChar(29);

                        if (str_itemtype == "")
                        {
                            str_CargoInfo = str_CargoInfo + "OT";
                        }
                        else if (str_itemtype == "UB")
                        {
                            str_CargoInfo = str_CargoInfo + str_itemtype;
                        }
                        else
                        {
                            str_CargoInfo = str_CargoInfo + str_itemtype;
                        }

                        str_type = obj_dt_bldet.Rows[i]["cargommt"].ToString();
                        str_CargoInfo = str_CargoInfo + Convert.ToChar(29);

                        if (str_type == "")
                        {
                            str_CargoInfo = str_CargoInfo + "LC";
                        }
                        else if (str_type == "TI")
                        {
                            str_CargoInfo = str_CargoInfo + "TI";
                        }
                        else if (str_type == "TC")
                        {
                            str_CargoInfo = str_CargoInfo + "TC";
                        }
                        else
                        {
                            str_CargoInfo = str_CargoInfo + str_type;
                        }

                        str_CargoInfo = str_CargoInfo + Convert.ToChar(29);
                        str_CargoInfo = str_CargoInfo + str_cfscode.Replace("<br/>", "");
                        int_noofpkgs = Convert.ToInt32(obj_dt_bldet.Rows[i]["noofpkgs"].ToString().Replace("<br/>", ""));
                        str_CargoInfo = str_CargoInfo + Convert.ToChar(29);
                        str_CargoInfo = str_CargoInfo + int_noofpkgs.ToString().Replace("<br/>", "");
                        int_pkg = Convert.ToInt32(obj_dt_bldet.Rows[i]["packageid"].ToString());
                        str_pkgtype = obj_da_pack.GetPackageCodePkgID(int_pkg);
                        str_CargoInfo = str_CargoInfo + Convert.ToChar(29);
                        str_CargoInfo = str_CargoInfo + str_pkgtype.Replace("<br/>", "");
                        int_weight = Math.Round(Convert.ToDouble(obj_dt_bldet.Rows[i]["grweight"].ToString().Replace("<br/>", "")),2);
                        str_CargoInfo = str_CargoInfo + Convert.ToChar(29);
                        str_CargoInfo = str_CargoInfo + (int_weight).ToString("#0.000"); 
                        str_CargoInfo = str_CargoInfo + Convert.ToChar(29);
                        str_CargoInfo = str_CargoInfo + "KGS";
                        str_CargoInfo = str_CargoInfo + Convert.ToChar(29);
                        str_CargoInfo = str_CargoInfo + Convert.ToChar(29);

                        str_marks = obj_dt_bldet.Rows[i]["marks"].ToString().Replace("<br/>", "");
                        str_CargoInfo = str_CargoInfo + Convert.ToChar(29);
                        if (str_marks.Length > 300)
                        {
                            str_CargoInfo = str_CargoInfo + str_marks.Substring(0, 300);
                        }
                        else
                        {
                            str_CargoInfo = str_CargoInfo + str_marks;
                        }

                        str_desc = obj_dt_bldet.Rows[i]["descn"].ToString().Replace("<br/>", "");
                        str_CargoInfo = str_CargoInfo + Convert.ToChar(29);
                        if (str_desc.Length > 300)
                        {
                            str_CargoInfo = str_CargoInfo + str_desc.Substring(0, 300);
                        }
                        else
                        {
                            str_CargoInfo = str_CargoInfo + str_desc;
                        }
                        imocode = obj_dt_bldet.Rows[i]["imocode"].ToString().Replace("<br/>", "");
                        str_CargoInfo = str_CargoInfo + Convert.ToChar(29);
                        str_CargoInfo = str_CargoInfo + imocode;
                        str_unicode = obj_dt_bldet.Rows[i]["unocode"].ToString().Replace("<br/>", "").Trim();
                        str_CargoInfo = str_CargoInfo + Convert.ToChar(29);
                        str_CargoInfo = str_CargoInfo + str_unicode;
                        str_CargoInfo = str_CargoInfo + Convert.ToChar(29);
                        str_CargoInfo = str_CargoInfo + Convert.ToChar(29);
                        str_CargoInfo = str_CargoInfo + Convert.ToChar(29);
                        str_CargoInfo = str_CargoInfo + Convert.ToChar(29);
                        str_CargoInfo = str_CargoInfo + Convert.ToChar(29);

                        TW.WriteLine(str_CargoInfo);
                        TW.Flush();
                    }
                }
                str_CargoInfo = "";
                str_CargoInfo = str_CargoInfo + "<END-conscargo>";

                TW.WriteLine(str_CargoInfo);
                TW.Flush();





            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);

            }
        }

        private void GetMumbaiContainerInfo()
        {
            int_branchid = Convert.ToInt32(Session["LoginBranchid"].ToString());
            int_empid = Convert.ToInt32(Session["LoginEmpId"].ToString());
            int_divisionid = Convert.ToInt32(Session["LoginDivisionId"].ToString());
            int_jobno = Convert.ToInt32(hf_jobno.Value);

            str_ContainerInfo = "";
            str_ContainerInfo = str_ContainerInfo + "<conscont>";
            TW.WriteLine(str_ContainerInfo);
            TW.Flush();
            DataTable obj_dt_fib = new DataTable();
            //DataAccess.ForwardingImports.BLDetails obj_da_fib = new DataAccess.ForwardingImports.BLDetails();
            obj_dt_fib = obj_da_fib.GetBLContDtJobno(int_jobno, int_branchid, int_divisionid);

            if (obj_dt_fib.Rows.Count > 0)
            {
                for (int i = 0; i < obj_dt_fib.Rows.Count; i++)
                {
                    str_ContainerInfo = "";
                    str_ContainerInfo = "F" + Convert.ToChar(29);
                    if (int_pod == 11316)
                    {
                        if (int_branchid == 5)
                        {
                            str_ContainerInfo = str_ContainerInfo + "AAICS2726ECNNSA1" + Convert.ToChar(29);
                        }
                        else
                        {
                            str_ContainerInfo = str_ContainerInfo + str_cardno + Convert.ToChar(29);
                        }
                    }
                    else
                    {
                        str_ContainerInfo = str_ContainerInfo + str_cardno + Convert.ToChar(29);
                    }

                    str_ContainerInfo = str_ContainerInfo + str_imno.Replace("<br/>", "");
                    str_ContainerInfo = str_ContainerInfo + Convert.ToChar(29);
                    str_ContainerInfo = str_ContainerInfo + dt_imdate.Year.ToString().Replace("<br/>", "");
                    str_ContainerInfo = str_ContainerInfo + Convert.ToChar(29);
                    str_ContainerInfo = str_ContainerInfo + str_CVslcode.Replace("<br/>", "") + Convert.ToChar(29);
                    str_ContainerInfo = str_ContainerInfo + str_Voyage.Replace("<br/>", "");
                    str_ContainerInfo = str_ContainerInfo + Convert.ToChar(29);
                    str_ContainerInfo = str_ContainerInfo + obj_dt_fib.Rows[i]["linenumber"].ToString().Replace("<br/>", "");
                    str_ContainerInfo = str_ContainerInfo + Convert.ToChar(29);
                    str_ContainerInfo = str_ContainerInfo + obj_dt_fib.Rows[i]["sublineno"].ToString().Replace("<br/>", "");
                    str_ContainerInfo = str_ContainerInfo + Convert.ToChar(29);
                    str_ContainerInfo = str_ContainerInfo + obj_dt_fib.Rows[i]["containerno"].ToString().Replace("<br/>", "");
                    str_ContainerInfo = str_ContainerInfo + Convert.ToChar(29);
                    str_ContainerInfo = str_ContainerInfo + obj_dt_fib.Rows[i]["sealno"].ToString().Replace("<br/>", "");
                    str_ContainerInfo = str_ContainerInfo + Convert.ToChar(29);
                    str_ContainerInfo = str_ContainerInfo + str_linecode.Replace("<br/>", "");
                    str_ContainerInfo = str_ContainerInfo + Convert.ToChar(29);
                    str_ContainerInfo = str_ContainerInfo + str_jobtype + Convert.ToChar(29);
                    str_ContainerInfo = str_ContainerInfo + obj_dt_fib.Rows[i]["noofpkgs"].ToString().Replace("<br/>", "");
                    str_ContainerInfo = str_ContainerInfo + Convert.ToChar(29);
                    //str_ContainerInfo = str_ContainerInfo + (Convert.ToInt32(obj_dt_fib.Rows[i]["grweight"]) / 1000) + "Fixed".ToString().Replace("<br/>", "");              
                    str_ContainerInfo = str_ContainerInfo + Convert.ToDouble(string.Format("{0:0.000}", (Convert.ToDouble(obj_dt_fib.Rows[i]["grweight"]) / 1000)).ToString());    
                    str_ContainerInfo = str_ContainerInfo + Convert.ToChar(29);
                    str_ContainerInfo = str_ContainerInfo + obj_dt_fib.Rows[i]["isocode"].ToString().Replace("<br/>", "");
                    str_ContainerInfo = str_ContainerInfo + Convert.ToChar(29);
                    str_ContainerInfo = str_ContainerInfo + obj_dt_fib.Rows[i]["socflag"].ToString().Replace("<br/>", "");
                    str_ContainerInfo = str_ContainerInfo + Convert.ToChar(29);
                    TW.WriteLine(str_ContainerInfo);
                    TW.Flush();
                }
            }
            str_ContainerInfo = "";
            str_ContainerInfo = str_ContainerInfo + "<END-conscont>";
            TW.WriteLine(str_ContainerInfo);
            TW.Flush();
        }

        private void GetKolKattaVesselInfo()
        {
            try
            {
                int_branchid = Convert.ToInt32(Session["LoginBranchid"].ToString());
                int_empid = Convert.ToInt32(Session["LoginEmpId"].ToString());
                int_divisionid = Convert.ToInt32(Session["LoginDivisionId"].ToString());
                int_jobno = Convert.ToInt32(hf_jobno.Value);

                str_VesInfo = "";
                str_VesInfo = str_VesInfo + "HREC";
                str_VesInfo = str_VesInfo + Convert.ToChar(29);
                str_VesInfo = str_VesInfo + "ZZ";
                str_VesInfo = str_VesInfo + Convert.ToChar(29);
                str_VesInfo = str_VesInfo + "CSS";
                str_VesInfo = str_VesInfo + Convert.ToChar(29);
                str_VesInfo = str_VesInfo + "ZZ";
                str_VesInfo = str_VesInfo + Convert.ToChar(29);
                str_VesInfo = str_VesInfo + "INCCU1";
                str_VesInfo = str_VesInfo + Convert.ToChar(29);
                str_VesInfo = str_VesInfo + "ICES1_5";
                str_VesInfo = str_VesInfo + Convert.ToChar(29);
                str_VesInfo = str_VesInfo + "P";
                str_VesInfo = str_VesInfo + Convert.ToChar(29);
                str_VesInfo = str_VesInfo + Convert.ToChar(29);
                str_VesInfo = str_VesInfo + txt_job.Text;
                str_VesInfo = str_VesInfo + Convert.ToChar(29);
                str_VesInfo = str_VesInfo + "0001";
                str_VesInfo = str_VesInfo + Convert.ToChar(29);
                today = DateTime.Now;
                str_VesInfo = str_VesInfo + today;
                str_VesInfo = str_VesInfo + Convert.ToChar(29);
                str_VesInfo = str_VesInfo + DateTime.Now.TimeOfDay;
                str_VesInfo = str_VesInfo + System.Environment.NewLine;
                str_VesInfo = str_VesInfo + "<manifest>";
                str_VesInfo = str_VesInfo + System.Environment.NewLine;
                str_VesInfo = str_VesInfo + "<vesinfo>";
                str_VesInfo = str_VesInfo + System.Environment.NewLine;
                str_VesInfo = str_VesInfo + "F" + Convert.ToChar(29);

                DataTable obj_dt_jinfo = new DataTable();
                //DataAccess.ForwardingImports.JobInfo obj_da_jinfo = new DataAccess.ForwardingImports.JobInfo();
                //DataAccess.Masters.MasterPort obj_da_port = new DataAccess.Masters.MasterPort();

                obj_dt_jinfo = obj_da_jinfo.ShowJobDetails(int_jobno, int_branchid, int_divisionid);
                if (obj_dt_jinfo.Rows.Count > 0)
                {
                    str_imocode = obj_dt_jinfo.Rows[0]["imocode"].ToString();
                    str_VesInfo = str_VesInfo + "INCCU1";
                    str_VesInfo = str_VesInfo + Convert.ToChar(29);
                    str_VesInfo = str_VesInfo + Convert.ToChar(29);
                    str_VesInfo = str_VesInfo + Convert.ToChar(29);
                    str_VesInfo = str_VesInfo + str_imocode;
                    str_VesInfo = str_VesInfo + Convert.ToChar(29);
                    if (obj_dt_jinfo.Rows[0]["cvslcode"].ToString() != "")
                    {
                        str_CVslcode = obj_dt_jinfo.Rows[0]["cvslcode"].ToString();
                    }
                    str_VesInfo = str_VesInfo + str_CVslcode;
                    str_VesInfo = str_VesInfo + Convert.ToChar(29);
                    if (obj_dt_jinfo.Rows[0]["voyage"].ToString() != "")
                    {
                        str_Voyage = obj_dt_jinfo.Rows[0]["voyage"].ToString();
                    }

                    str_VesInfo = str_VesInfo + str_Voyage;
                    str_VesInfo = str_VesInfo + Convert.ToChar(29);

                    str_VesInfo = str_VesInfo + obj_dt_jinfo.Rows[0]["clinecode"].ToString();
                    str_VesInfo = str_VesInfo + Convert.ToChar(29);
                    str_VesInfo = str_VesInfo + obj_dt_jinfo.Rows[0]["cagent"].ToString();
                    str_VesInfo = str_VesInfo + Convert.ToChar(29);
                    int_pol = Convert.ToInt32(obj_dt_jinfo.Rows[0]["pol"].ToString());
                    str_pol = obj_da_port.GetPortname(int_pol);
                    str_polcode = obj_da_port.GetPortcode(str_pol);
                    str_VesInfo = str_VesInfo + obj_dt_jinfo.Rows[0]["cmaster"].ToString();
                    str_VesInfo = str_VesInfo + Convert.ToChar(29);
                    int_pod = Convert.ToInt32(obj_dt_jinfo.Rows[0]["pod"].ToString());
                    str_pod = obj_da_port.GetPortname(int_pod);
                    str_podcode = obj_da_port.GetPortcode(str_pod);
                    str_VesInfo = str_VesInfo + str_polcode;
                    str_VesInfo = str_VesInfo + Convert.ToChar(29);
                    str_VesInfo = str_VesInfo + str_podcode;
                    str_VesInfo = str_VesInfo + Convert.ToChar(29);
                    str_VesInfo = str_VesInfo + Convert.ToChar(29);
                    str_VesInfo = str_VesInfo + Convert.ToChar(29);
                    str_VesInfo = str_VesInfo + "C";
                    str_VesInfo = str_VesInfo + Convert.ToChar(29);
                    str_VesInfo = str_VesInfo + Convert.ToChar(29);
                    str_VesInfo = str_VesInfo + "GENERAL CARGO";
                    str_VesInfo = str_VesInfo + Convert.ToChar(29);
                    str_VesInfo = str_VesInfo + Convert.ToChar(29);
                    str_VesInfo = str_VesInfo + Convert.ToChar(29);
                    str_VesInfo = str_VesInfo + "Y";
                    str_VesInfo = str_VesInfo + Convert.ToChar(29);
                    str_VesInfo = str_VesInfo + "Y";
                    str_VesInfo = str_VesInfo + Convert.ToChar(29);
                    str_VesInfo = str_VesInfo + "Y";
                    str_VesInfo = str_VesInfo + Convert.ToChar(29);
                    str_VesInfo = str_VesInfo + "Y";
                    str_VesInfo = str_VesInfo + Convert.ToChar(29);
                    str_VesInfo = str_VesInfo + "Y";
                    str_VesInfo = str_VesInfo + Convert.ToChar(29);
                    str_VesInfo = str_VesInfo + "Y";
                    str_VesInfo = str_VesInfo + Convert.ToChar(29);
                    str_VesInfo = str_VesInfo + str_podcode + "KKP1".TrimStart();
                    TW.WriteLine(str_VesInfo);
                    TW.Flush();
                    str_VesInfo = "";
                    str_VesInfo = str_VesInfo + "<END-vesinfo>";
                    TW.WriteLine(str_VesInfo);
                    TW.Flush();
                }
                else
                {
                    str_VesInfo = "";
                    str_VesInfo = str_VesInfo + "<END-vesinfo>";
                    TW.WriteLine(str_VesInfo);
                    TW.Flush();
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);

            }
        }

        private void GetKolKattaCargoInfo()
        {
            int_branchid = Convert.ToInt32(Session["LoginBranchid"].ToString());
            int_empid = Convert.ToInt32(Session["LoginEmpId"].ToString());
            int_divisionid = Convert.ToInt32(Session["LoginDivisionId"].ToString());
            int_jobno = Convert.ToInt32(hf_jobno.Value);

            DataTable obj_dt_jinfo = new DataTable();
           // DataAccess.ForwardingImports.JobInfo obj_da_jinfo = new DataAccess.ForwardingImports.JobInfo();
            obj_dt_jinfo = obj_da_jinfo.ShowJobDetails(int_jobno, int_branchid, int_divisionid);
            if (obj_dt_jinfo.Rows.Count > 0)
            {
                if (obj_dt_jinfo.Rows[0]["cvslcode"].ToString() != "")
                {
                    str_CVslcode = obj_dt_jinfo.Rows[0]["cvslcode"].ToString();
                }
                if (obj_dt_jinfo.Rows[0]["voyage"].ToString() != "")
                {
                    str_Voyage = obj_dt_jinfo.Rows[0]["voyage"].ToString();
                }
            }

            str_CargoInfo = "";
            str_CargoInfo = str_CargoInfo + "<cargo>";
            TW.WriteLine(str_CargoInfo);
            TW.Flush();
            str_CargoInfo = "";

            DataTable obj_dt_bldet = new DataTable();
            //DataAccess.ForwardingImports.BLDetails obj_da_bldet = new DataAccess.ForwardingImports.BLDetails();
            //DataAccess.Masters.MasterPort obj_da_port = new DataAccess.Masters.MasterPort();
            //DataAccess.Masters.MasterPackages obj_da_pack = new DataAccess.Masters.MasterPackages();
            obj_dt_bldet = obj_da_bldet.GetBLDetailJobno(int_jobno, int_branchid, int_divisionid);
            if (obj_dt_bldet.Rows.Count > 0)
            {
                for (int i = 0; i < obj_dt_bldet.Rows.Count; i++)
                {
                    str_CargoInfo = "";
                    str_CargoInfo = str_CargoInfo + "F" + Convert.ToChar(29);
                    str_CargoInfo = str_CargoInfo + "INCCU1";
                    str_CargoInfo = str_CargoInfo + Convert.ToChar(29);
                    str_CargoInfo = str_CargoInfo + str_imocode;
                    str_CargoInfo = str_CargoInfo + Convert.ToChar(29);
                    str_CargoInfo = str_CargoInfo + str_CVslcode;
                    str_CargoInfo = str_CargoInfo + Convert.ToChar(29);
                    str_CargoInfo = str_CargoInfo + str_Voyage;
                    str_CargoInfo = str_CargoInfo + Convert.ToChar(29);
                    str_CargoInfo = str_CargoInfo + Convert.ToChar(29);
                    str_CargoInfo = str_CargoInfo + Convert.ToChar(29);
                    str_Lineno = obj_dt_bldet.Rows[i]["linenumber"].ToString();
                    str_CargoInfo = str_CargoInfo + str_Lineno;
                    str_CargoInfo = str_CargoInfo + Convert.ToChar(29);
                    str_sublineno = obj_dt_bldet.Rows[i]["sublineno"].ToString();
                    str_CargoInfo = str_CargoInfo + str_sublineno;
                    str_CargoInfo = str_CargoInfo + Convert.ToChar(29);
                    str_blno = obj_dt_bldet.Rows[i]["blno"].ToString();
                    str_CargoInfo = str_CargoInfo + str_blno;
                    str_CargoInfo = str_CargoInfo + Convert.ToChar(29);
                    dt_bldate = Convert.ToDateTime(obj_dt_bldet.Rows[i]["bldate"].ToString());
                    str_CargoInfo = str_CargoInfo + dt_bldate;
                    str_CargoInfo = str_CargoInfo + Convert.ToChar(29);
                    int_pol = Convert.ToInt32(obj_dt_bldet.Rows[i]["pol"].ToString());
                    str_pol = obj_da_port.GetPortname(int_pol);
                    str_polcode = obj_da_port.GetPortcode(str_pol);
                    str_CargoInfo = str_CargoInfo + str_polcode.TrimEnd();
                    int_pod = Convert.ToInt32(obj_dt_jinfo.Rows[0]["pod"].ToString());
                    str_pod = obj_da_port.GetPortname(int_pod);
                    str_podcode = obj_da_port.GetPortcode(str_pod);
                    str_CargoInfo = str_CargoInfo + Convert.ToChar(29);
                    str_CargoInfo = str_CargoInfo + str_podcode.TrimEnd();
                    str_CargoInfo = str_CargoInfo + Convert.ToChar(29) + Convert.ToChar(29) + Convert.ToChar(29);
                    int_consigneeid = Convert.ToInt32(obj_dt_bldet.Rows[i]["consigneeid"].ToString());
                    str_consignee = "";
                    str_consignee = obj_dt_bldet.Rows[i]["consignee"].ToString();
                    str_consignee = obj_dt_bldet.Rows[i]["caddress"].ToString().Replace("<br/>", "");

                    str_cons = str_consignee.Replace("\r", " ");
                    str_cons = str_cons.Replace("\n", " ");
                    if (str_cons.Length > 105)
                    {
                        str_CargoInfo = str_CargoInfo + str_cons.Substring(0, 35).Replace("<br/>", "");
                        str_CargoInfo = str_CargoInfo + Convert.ToChar(29);
                        str_CargoInfo = str_CargoInfo + str_cons.Substring(36, 35).Replace("<br/>", "");
                        str_CargoInfo = str_CargoInfo + Convert.ToChar(29);
                        str_CargoInfo = str_CargoInfo + str_cons.Substring(71, 35).Replace("<br/>", "");
                        str_CargoInfo = str_CargoInfo + Convert.ToChar(29);
                        str_CargoInfo = str_CargoInfo + str_cons.Substring(106, (str_cons.Length - 106)).Replace("<br/>", "");
                        //str_CargoInfo = str_CargoInfo + str_cons.Substring(106, 35).Replace("<br/>", "");
                    }
                    else if (str_cons.Length > 70 && str_cons.Length <= 105)
                    {
                        str_CargoInfo = str_CargoInfo + str_cons.Substring(0, 20).Replace("<br/>", "");
                        str_CargoInfo = str_CargoInfo + Convert.ToChar(29);
                        str_CargoInfo = str_CargoInfo + str_cons.Substring(21, 20).Replace("<br/>", "");
                        str_CargoInfo = str_CargoInfo + Convert.ToChar(29);
                        str_CargoInfo = str_CargoInfo + str_cons.Substring(41, 30).Replace("<br/>", "");
                        str_CargoInfo = str_CargoInfo + Convert.ToChar(29);
                        str_CargoInfo = str_CargoInfo + str_cons.Substring(71, (str_cons.Length - 71)).Replace("<br/>", "");
                        //str_CargoInfo = str_CargoInfo + str_cons.Substring(71, 35).Replace("<br/>", "");
                    }
                    else if (str_cons.Length > 35 && str_cons.Length <= 70)
                    {
                        str_CargoInfo = str_CargoInfo + str_cons.Substring(0, 10).Replace("<br/>", "");
                        str_CargoInfo = str_CargoInfo + Convert.ToChar(29);
                        str_CargoInfo = str_CargoInfo + str_cons.Substring(11, 10).Replace("<br/>", "");
                        str_CargoInfo = str_CargoInfo + Convert.ToChar(29);
                        str_CargoInfo = str_CargoInfo + str_cons.Substring(21, 15).Replace("<br/>", "");
                        str_CargoInfo = str_CargoInfo + Convert.ToChar(29);
                        str_CargoInfo = str_CargoInfo + str_cons.Substring(36, (str_cons.Length - 36)).Replace("<br/>", "");
                        //str_CargoInfo = str_CargoInfo + str_cons.Substring(36, 35).Replace("<br/>", "");
                    }
                    else if (str_cons.Length <= 35)
                    {
                        if (str_cons.Length > 10)
                        {
                            str_CargoInfo = str_CargoInfo + str_cons.Substring(0, 10).Replace("<br/>", "");
                            str_CargoInfo = str_CargoInfo + Convert.ToChar(29);
                            str_CargoInfo = str_CargoInfo + str_cons.Substring(11, 10).Replace("<br/>", "");
                            str_CargoInfo = str_CargoInfo + Convert.ToChar(29);
                            str_CargoInfo = str_CargoInfo + str_cons.Substring(21, 10).Replace("<br/>", "");
                            str_CargoInfo = str_CargoInfo + Convert.ToChar(29);
                            str_CargoInfo = str_CargoInfo + str_cons.Substring(31, (str_cons.Length - 31)).Replace("<br/>", "");
                            //str_CargoInfo = str_CargoInfo + str_cons.Substring(31, 5).Replace("<br/>", "");
                        }
                        else
                        {
                            str_CargoInfo = str_CargoInfo + str_cons.Replace("<br/>", "");
                            str_CargoInfo = str_CargoInfo + Convert.ToChar(29);
                            str_CargoInfo = str_CargoInfo + ".";
                            str_CargoInfo = str_CargoInfo + Convert.ToChar(29);
                            str_CargoInfo = str_CargoInfo + ".";
                            str_CargoInfo = str_CargoInfo + Convert.ToChar(29);
                            str_CargoInfo = str_CargoInfo + ".";
                        }
                    }

                    str_CargoInfo = str_CargoInfo + Convert.ToChar(29);
                    str_notify = "";
                    str_notify = obj_dt_bldet.Rows[i]["notifyparty"].ToString();
                    str_notify = obj_dt_bldet.Rows[i]["naddress"].ToString().Replace("<br/>", "");

                    str_noti = str_notify.Replace("\r", " ");
                    str_noti = str_noti.Replace("\n", " ");
                    if (str_noti.Length > 105)
                    {
                        str_CargoInfo = str_CargoInfo + str_noti.Substring(0, 35);
                        str_CargoInfo = str_CargoInfo + Convert.ToChar(29);
                        str_CargoInfo = str_CargoInfo + str_noti.Substring(36, 35);
                        str_CargoInfo = str_CargoInfo + Convert.ToChar(29);
                        str_CargoInfo = str_CargoInfo + str_noti.Substring(71, 35);
                        str_CargoInfo = str_CargoInfo + Convert.ToChar(29);
                        str_CargoInfo = str_CargoInfo + str_noti.Substring(106, (str_noti.Length - 106));
                        //str_CargoInfo = str_CargoInfo + str_noti.Substring(106, 35);
                    }
                    else if (str_noti.Length > 70 && str_cons.Length <= 105)
                    {
                        str_CargoInfo = str_CargoInfo + str_noti.Substring(0, 20);
                        str_CargoInfo = str_CargoInfo + Convert.ToChar(29);
                        str_CargoInfo = str_CargoInfo + str_noti.Substring(21, 20);
                        str_CargoInfo = str_CargoInfo + Convert.ToChar(29);
                        str_CargoInfo = str_CargoInfo + str_noti.Substring(41, 30);
                        str_CargoInfo = str_CargoInfo + Convert.ToChar(29);
                        str_CargoInfo = str_CargoInfo + str_noti.Substring(71, (str_noti.Length - 71));
                        //str_CargoInfo = str_CargoInfo + str_noti.Substring(71, 35);
                    }
                    else if (str_noti.Length > 35 && str_cons.Length <= 70)
                    {
                        str_CargoInfo = str_CargoInfo + str_noti.Substring(0, 10);
                        str_CargoInfo = str_CargoInfo + Convert.ToChar(29);
                        str_CargoInfo = str_CargoInfo + str_noti.Substring(11, 10);
                        str_CargoInfo = str_CargoInfo + Convert.ToChar(29);
                        str_CargoInfo = str_CargoInfo + str_noti.Substring(21, 15);
                        str_CargoInfo = str_CargoInfo + Convert.ToChar(29);
                        str_CargoInfo = str_CargoInfo + str_noti.Substring(36, (str_noti.Length - 36));
                        //str_CargoInfo = str_CargoInfo + str_noti.Substring(36, 35);
                    }
                    else if (str_noti.Length <= 35)
                    {
                        if (str_noti.Length > 10)
                        {
                            str_CargoInfo = str_CargoInfo + str_noti.Substring(0, 10);
                            str_CargoInfo = str_CargoInfo + Convert.ToChar(29);
                            str_CargoInfo = str_CargoInfo + str_noti.Substring(11, 10);
                            str_CargoInfo = str_CargoInfo + Convert.ToChar(29);
                            str_CargoInfo = str_CargoInfo + str_noti.Substring(21, 10);
                            str_CargoInfo = str_CargoInfo + Convert.ToChar(29);
                            str_CargoInfo = str_CargoInfo + str_noti.Substring(31, (str_noti.Length - 31));
                            //str_CargoInfo = str_CargoInfo + str_noti.Substring(31, 5);
                        }
                        else
                        {
                            str_CargoInfo = str_CargoInfo + str_noti;
                            str_CargoInfo = str_CargoInfo + Convert.ToChar(29);
                            str_CargoInfo = str_CargoInfo + ".";
                            str_CargoInfo = str_CargoInfo + Convert.ToChar(29);
                            str_CargoInfo = str_CargoInfo + ".";
                            str_CargoInfo = str_CargoInfo + Convert.ToChar(29);
                            str_CargoInfo = str_CargoInfo + ".";
                        }
                    }

                    str_CargoInfo = str_CargoInfo + Convert.ToChar(29);
                    str_CargoInfo = str_CargoInfo + "C";
                    str_CargoInfo = str_CargoInfo + Convert.ToChar(29);
                    str_itemtype = obj_dt_bldet.Rows[i]["itemtype"].ToString();

                    if (str_itemtype == "")
                    {
                        str_CargoInfo = str_CargoInfo + "OT";
                    }
                    else
                    {
                        str_CargoInfo = str_CargoInfo + str_itemtype;
                    }

                    str_type = obj_dt_bldet.Rows[i]["cargommt"].ToString();
                    str_CargoInfo = str_CargoInfo + Convert.ToChar(29);
                    if (str_type == "")
                    {
                        str_CargoInfo = str_CargoInfo + "LC";
                    }
                    else
                    {
                        str_CargoInfo = str_CargoInfo + str_type;
                    }

                    str_CargoInfo = str_CargoInfo + Convert.ToChar(29) + Convert.ToChar(29);
                    int_noofpkgs = Convert.ToInt32(obj_dt_bldet.Rows[i]["noofpkgs"].ToString());
                    str_CargoInfo = str_CargoInfo + int_noofpkgs;
                    int_pkg = Convert.ToInt32(obj_dt_bldet.Rows[i]["packageid"].ToString());
                    str_pkgtype = obj_da_pack.GetPackageCodePkgID(int_pkg);
                    str_CargoInfo = str_CargoInfo + Convert.ToChar(29);
                    str_CargoInfo = str_CargoInfo + str_pkgtype;
                    int_weight = Convert.ToDouble(obj_dt_bldet.Rows[i]["grweight"].ToString());
                    str_CargoInfo = str_CargoInfo + Convert.ToChar(29);
                    str_CargoInfo = str_CargoInfo + (int_weight ).ToString("#0.000"); 
                    str_CargoInfo = str_CargoInfo + Convert.ToChar(29);
                    str_CargoInfo = str_CargoInfo + "KGS";
                    str_CargoInfo = str_CargoInfo + Convert.ToChar(29);
                    str_CargoInfo = str_CargoInfo + Convert.ToChar(29);
                    str_CargoInfo = str_CargoInfo + Convert.ToChar(29);
                    str_marks = obj_dt_bldet.Rows[i]["marks"].ToString().Replace("<br/>", "");
                    str_CargoInfo = str_CargoInfo + str_marks;
                    str_desc = obj_dt_bldet.Rows[i]["descn"].ToString().Replace("<br/>", "");
                    str_CargoInfo = str_CargoInfo + Convert.ToChar(29);
                    str_CargoInfo = str_CargoInfo + str_desc;
                    imocode = obj_dt_bldet.Rows[i]["imocode"].ToString();
                    str_CargoInfo = str_CargoInfo + Convert.ToChar(29);
                    str_CargoInfo = str_CargoInfo + imocode;
                    str_unicode = obj_dt_bldet.Rows[i]["unocode"].ToString().Trim();
                    str_CargoInfo = str_CargoInfo + Convert.ToChar(29);
                    str_CargoInfo = str_CargoInfo + str_unicode;
                    str_CargoInfo = str_CargoInfo + Convert.ToChar(29);
                    str_CargoInfo = str_CargoInfo + Convert.ToChar(29);
                    str_CargoInfo = str_CargoInfo + Convert.ToChar(29);
                    str_CargoInfo = str_CargoInfo + Convert.ToChar(29);
                    str_CargoInfo = str_CargoInfo.Replace("<br/>", "");
                    TW.WriteLine(str_CargoInfo);
                    TW.Flush();
                }
            }
            str_CargoInfo = "";
            str_CargoInfo = str_CargoInfo + "<END-cargo>";
            TW.WriteLine(str_CargoInfo);
            TW.Flush();
        }

        protected void btn_igm_Click(object sender, EventArgs e)
        {
            //try
            //{
            int_branchid = Convert.ToInt32(Session["LoginBranchid"].ToString());
            int_empid = Convert.ToInt32(Session["LoginEmpId"].ToString());
            int_divisionid = Convert.ToInt32(Session["LoginDivisionId"].ToString());

            //object objFSO = null;
            //objFSO = Server.CreateObject("Scripting.FileSystemObject");

            //object FullPath = null;
            //FullPath = "C:\\CustomEDI";

            //string str_fullpath = "";
            //str_fullpath = "C:\\CustomEDI";

            //If Not objFSO.FolderExists(FullPath) Then
            //objFSO.CreateFolder(FullPath)
            //Else
            //End If

            //if (!File.Exists(str_fullpath))
            //{
            //    System.IO.Directory.CreateDirectory(str_fullpath);
            //}
            //else
            //{

            //}

            //if (!objFSO.FolderExists(FullPath))
            //{
            //    objFSO.CreateFolder(FullPath);
            //}
            //else
            //{
            //}
            string str_fullpath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            str_fullpath = Server.MapPath("~/CustomEDI/");

            if (Directory.Exists(str_fullpath))
            {
                //Directory.CreateDirectory(filePath);
                foreach (string file in Directory.GetFiles(str_fullpath))
                {
                    File.Delete(file);
                }
            }
            //objFSO = "";

            DataTable obj_dt_hr = new DataTable();
          //  DataAccess.HR.FrontPage obj_da_hr = new DataAccess.HR.FrontPage();

            obj_dt_hr = obj_da_hr.GetBranchInfo(int_branchid);
            if (obj_dt_hr.Rows.Count > 0)
            {
                if (!string.IsNullOrEmpty(obj_dt_hr.Rows[0]["carrno"].ToString()))
                {
                    str_cardno = obj_dt_hr.Rows[0]["carrno"].ToString().Trim();
                    str_cardno = str_cardno.Substring(0, 10).Trim();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(btn_igm, typeof(Button), "DataFound", "alertify.alert('Carrno not update in Masterbranch');", true);
                    return;
                }
                
            }


            int_jobno = Convert.ToInt32(txt_job.Text);
            hf_jobno.Value = int_jobno.ToString();

            //DataAccess.ForwardingImports.BLDetails obj_da_bldet = new DataAccess.ForwardingImports.BLDetails();
            DataTable obj_dt_bldet = new DataTable();

            DataTable obj_dt_BL = new DataTable();

            obj_dt_bldet = obj_da_bldet.GetContWtPkgCustomEdi(int_jobno, int_branchid, int_divisionid);

            if (obj_dt_bldet.Rows.Count > 0)
            {
                if (obj_dt_bldet.Rows[0][0].ToString() == "")
                {
                    int_Contpkg = 0;
                }
                else
                {
                    int_Contpkg = Convert.ToInt32(obj_dt_bldet.Rows[0][0].ToString());
                }

                if (obj_dt_bldet.Rows[0][1].ToString() == "")
                {
                    int_ContWt = 0;
                }
                else
                {
                    int_ContWt = Convert.ToDouble(obj_dt_bldet.Rows[0][1].ToString());
                }
            }


            obj_dt_BL = obj_da_bldet.GetBLWtPkgCustomEdi(int_jobno, int_branchid, int_divisionid);

            if (obj_dt_BL.Rows.Count > 0)
            {
                //if (!(System.Convert.IsDBNull(obj_dt_BL.Rows[0][0].ToString())))
                //{
                //    int_Blpkg = Convert.ToInt32(obj_dt_BL.Rows[0][0].ToString());
                //}
                //if (!(System.Convert.IsDBNull(obj_dt_BL.Rows[0][0].ToString())))
                //{
                //    int_BlWt = Convert.ToDouble(obj_dt_BL.Rows[0][1].ToString());
                //}
                if (obj_dt_BL.Rows[0][0].ToString() == "")
                {
                    int_Blpkg = 0;
                }
                else
                {
                    int_Blpkg = Convert.ToInt32(obj_dt_BL.Rows[0][0].ToString());
                }

                if (obj_dt_BL.Rows[0][1].ToString() == "")
                {
                    int_BlWt = 0;
                }
                else
                {
                    int_BlWt = Convert.ToDouble(obj_dt_BL.Rows[0][1].ToString());
                }
            }


            if (int_Blpkg != int_Contpkg)
            {
                ScriptManager.RegisterStartupScript(btn_igm, typeof(Button), "DataFound", "alertify.alert('Check Number of Packages');", true);
                return;
            }

            if (int_BlWt != int_ContWt)
            {
                ScriptManager.RegisterStartupScript(btn_igm, typeof(Button), "DataFound", "alertify.alert('Check Weight');", true);
                return;
            }
            DataTable obj_dt_pan = new DataTable();
            //DataAccess.ForwardingImports.CargoManifest obj_da_cargo = new DataAccess.ForwardingImports.CargoManifest();
            obj_dt_pan = obj_da_cargo.Getpanno4igm(int_branchid);
            if (obj_dt_pan.Rows.Count > 0)
            {
                str_panno = obj_dt_pan.Rows[0]["panno"].ToString();
            }

            str_jobno = txt_job.Text.ToString();
            str_igmjob = str_jobno;
            if (str_igmjob.Length < 2)
            {
                str_igmjob = "00" + str_igmjob;
            }
            else if (str_igmjob.Length > 1 && str_igmjob.Length < 3)
            {
                str_igmjob = "0" + str_igmjob;
            }
            else
            {
                str_igmjob = str_igmjob.Substring(str_igmjob.Length-3, 3);
            }

            DataTable obj_dt_jinfo = new DataTable();
            //DataAccess.ForwardingImports.JobInfo obj_da_jinfo = new DataAccess.ForwardingImports.JobInfo();
            //DataAccess.Masters.MasterPort obj_da_port = new DataAccess.Masters.MasterPort();


            obj_dt_jinfo = obj_da_jinfo.ShowJobDetails(int_jobno, int_branchid, int_divisionid);

            if (obj_dt_jinfo.Rows.Count > 0)
            {
                str_imno = obj_dt_jinfo.Rows[0]["imno"].ToString();
                dt_imdate = Convert.ToDateTime(obj_dt_jinfo.Rows[0]["imdate"].ToString());
                dt_mbldate = Convert.ToDateTime(obj_dt_jinfo.Rows[0]["mbldate"].ToString());
                str_intjobtype = obj_dt_jinfo.Rows[0]["jobtype"].ToString();
                str_clinecode = obj_dt_jinfo.Rows[0]["clinecode"].ToString();
                str_imocode = obj_dt_jinfo.Rows[0]["imocode"].ToString();
                str_mblno = obj_dt_jinfo.Rows[0]["mblno"].ToString();
                str_cfscode = obj_dt_jinfo.Rows[0]["cfscode"].ToString();
                str_cfspanno = obj_dt_jinfo.Rows[0]["cfspan"].ToString();
                str_mlopano = obj_dt_jinfo.Rows[0]["mlopan"].ToString();
                str_bondno = obj_dt_jinfo.Rows[0]["bondno"].ToString();

                str_cfspanno = str_cfspanno.Replace("<br/>", "");
                str_mlopano = str_mlopano.Replace("<br/>", "");
                str_bondno = str_bondno.Replace("<br/>", "");

                int_logpodid = Convert.ToInt32(obj_dt_jinfo.Rows[0]["pod"].ToString());
                str_podjob = obj_da_port.GetPortname(int_logpodid);
                str_loginpcode = obj_da_port.GetPortcode(str_podjob); // added on 18Feb2022 //nambi

               // str_loginpcode = Convert.ToString(obj_dt_jinfo.Rows[0]["Shippod"].ToString());     //Newly added 4/22/2022
               // //str_podjob = obj_da_port.GetPortname(int_logpodid);
               // //str_loginpcode = obj_da_port.GetPortcode(str_podjob);
               //// str_loginpcode = string.Empty;
            }


            str_ediuser = obj_da_log.GetBranchEDIUserID(int_branchid);

            // TW = System.IO.File.CreateText("C:\\CustomEDI\\" + str_cardno + str_igmjob + ".CGM");
            filename = str_cardno + str_igmjob + ".CGM";
            string strvsl;
            TW = System.IO.File.CreateText(str_fullpath + filename);
            strvsl = objraj.GetIGM1point5VesselInfo(str_ediuser, str_loginpcode, str_igmjob);
            TW.WriteLine(strvsl);
            TW.Flush();
            //GetIGM1point5VesselInfo();
            GetIGM1point5CargoInfo();
            GetIGM1point5ContainerInfo();
            TW.Close();


            DataTable obj_dt_BLD = new DataTable();
            obj_da_log.InsLogDetail(int_empid, 118, 3, int_branchid, Convert.ToString(int_jobno));

            Response.Clear();
            Response.ContentType = ContentType;
            Response.AppendHeader("Content-Disposition", "attachment; filename=" + System.IO.Path.GetFileName(str_fullpath + filename));
            Response.WriteFile(str_fullpath + filename);
            Response.Flush();
            System.IO.File.Delete(str_fullpath + filename);
            Response.End();
            //}
            //catch (Exception ex)
            //{
            //    string message = ex.Message.ToString();
            //    ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            //}
        }

        private void GetIGM1point5VesselInfo()
        {
            str_VesInfo = "";
            str_VesInfo = str_VesInfo + "HREC";
            str_VesInfo = str_VesInfo + Convert.ToChar(29);
            str_VesInfo = str_VesInfo + "ZZ";
            str_VesInfo = str_VesInfo + Convert.ToChar(29);
            str_VesInfo = str_VesInfo + str_ediuser.Trim();
            str_VesInfo = str_VesInfo + Convert.ToChar(29);
            str_VesInfo = str_VesInfo + "ZZ";
            str_VesInfo = str_VesInfo + Convert.ToChar(29);
            str_VesInfo = str_VesInfo + str_loginpcode.Trim();
            str_VesInfo = str_VesInfo + Convert.ToChar(29);
            str_VesInfo = str_VesInfo + "ICES1_5";
            str_VesInfo = str_VesInfo + Convert.ToChar(29);
            str_VesInfo = str_VesInfo + "P";
            str_VesInfo = str_VesInfo + Convert.ToChar(29);
            str_VesInfo = str_VesInfo + Convert.ToChar(29);
            str_VesInfo = str_VesInfo + "CMCHI21";
            str_VesInfo = str_VesInfo + Convert.ToChar(29);
            str_VesInfo = str_VesInfo + str_igmjob.Trim();
            str_VesInfo = str_VesInfo + Convert.ToChar(29);
            today = DateTime.Now;
            str_VesInfo = str_VesInfo + today.ToString("yyyyMMdd");
            str_VesInfo = str_VesInfo + Convert.ToChar(29);
            str_VesInfo = str_VesInfo + today.TimeOfDay.ToString("hhmm");
            str_VesInfo = str_VesInfo + "\r\n";
            str_VesInfo = str_VesInfo + "<consoligm>";
            str_VesInfo = str_VesInfo + "\r\n";
            str_VesInfo = str_VesInfo + "<conscargo>";
            TW.WriteLine(str_VesInfo);
            TW.Flush();
        }

        private void GetIGM1point5CargoInfo()
        {
            //DataAccess.ForwardingImports.JobInfo obj_da_jinfo = new DataAccess.ForwardingImports.JobInfo();
            //DataAccess.ForwardingImports.BLDetails obj_da_bldet = new DataAccess.ForwardingImports.BLDetails();
            //DataAccess.Masters.MasterPort obj_da_port = new DataAccess.Masters.MasterPort();
            //DataAccess.Masters.MasterPackages obj_da_pack = new DataAccess.Masters.MasterPackages();
            DataTable obj_dt_jinfo = new DataTable();
            obj_dt_jinfo = obj_da_jinfo.ShowJobDetails(int_jobno, int_branchid, int_divisionid);
            if (obj_dt_jinfo.Rows.Count > 0)
            {
                if (obj_dt_jinfo.Rows[0]["cvslcode"].ToString() != "")
                {
                    str_CVslcode = obj_dt_jinfo.Rows[0]["cvslcode"].ToString();
                }
                if (obj_dt_jinfo.Rows[0]["voyage"].ToString() != "")
                {
                    str_Voyage = obj_dt_jinfo.Rows[0]["voyage"].ToString();
                }
            }

         
            DataTable obj_dt_bldet = new DataTable();
            obj_dt_bldet = obj_da_bldet.GetBLDetailJobno(int_jobno, int_branchid, int_divisionid);
            if (obj_dt_bldet.Rows.Count > 0)
            {
                for (int i = 0; i < obj_dt_bldet.Rows.Count; i++)
                {

                    string str_consgpcode = "";

                        //str_loginpcode = Convert.ToString(obj_dt_bldet.Rows[i]["Shippod"].ToString());
                        // if (str_loginpcode == string.Empty)
                        // {
                        //     str_pol = Convert.ToString(obj_dt_bldet.Rows[i]["pod"].ToString());
                        //     str_loginpcode = obj_da_port.GetPortCodefrmPort(Convert.ToInt32(str_pol));
                        // }


                   
                   
                        str_pol = Convert.ToString(obj_dt_bldet.Rows[i]["pod"].ToString());
                        str_loginpcode = obj_da_port.GetPortCodefrmPort(Convert.ToInt32(str_pol));
                        str_consgpcode = Convert.ToString(obj_dt_bldet.Rows[i]["Shippod"].ToString());
                        if (str_consgpcode == "")
                        {
                            str_consgpcode = str_loginpcode;
                        }
                       


                    str_CargoInfo = "";
                    str_CargoInfo = str_CargoInfo + "F".Trim() + Convert.ToChar(29);
                    str_CargoInfo = str_CargoInfo + str_loginpcode.Trim();
                    str_CargoInfo = str_CargoInfo + Convert.ToChar(29);
                    str_CargoInfo = str_CargoInfo + str_cardno;
                    str_CargoInfo = str_CargoInfo + Convert.ToChar(29);
                    str_CargoInfo = str_CargoInfo + str_imno.Trim();
                    str_CargoInfo = str_CargoInfo + Convert.ToChar(29);
                    //str_CargoInfo = str_CargoInfo + dt_imdate.ToString("ddMMyyyy");
                    //str_CargoInfo = str_CargoInfo + Format(imdate.tostring(), "ddMMyyyy");
                    str_CargoInfo = str_CargoInfo + dt_imdate.ToString("ddMMyyyy");
                    str_CargoInfo = str_CargoInfo + Convert.ToChar(29);
                    str_CargoInfo = str_CargoInfo + str_imocode.Trim();
                    str_CargoInfo = str_CargoInfo + Convert.ToChar(29);
                    str_CargoInfo = str_CargoInfo + str_CVslcode.Trim();
                    str_CargoInfo = str_CargoInfo + Convert.ToChar(29);
                    str_CargoInfo = str_CargoInfo + str_Voyage.Trim();
                    str_CargoInfo = str_CargoInfo + Convert.ToChar(29);
                    str_Lineno = obj_dt_bldet.Rows[i]["linenumber"].ToString();
                    str_CargoInfo = str_CargoInfo + str_Lineno.Trim();
                    str_CargoInfo = str_CargoInfo + Convert.ToChar(29);
                    str_sublineno = obj_dt_bldet.Rows[i]["sublineno"].ToString();
                    str_CargoInfo = str_CargoInfo + str_sublineno.Trim();
                    str_CargoInfo = str_CargoInfo + Convert.ToChar(29);
                    str_CargoInfo = str_CargoInfo + str_mblno.Trim();
                    str_CargoInfo = str_CargoInfo + Convert.ToChar(29);
                    str_CargoInfo = str_CargoInfo + dt_mbldate.ToString("ddMMyyyy");
                    str_CargoInfo = str_CargoInfo + Convert.ToChar(29);
                    int_pol = Convert.ToInt32(obj_dt_bldet.Rows[i]["pol"].ToString());
                    str_pol = obj_da_port.GetPortname(int_pol);
                    str_polcode = obj_da_port.GetPortcode(str_pol);
                    str_CargoInfo = str_CargoInfo + str_polcode.TrimEnd();
                    int_pod = Convert.ToInt32(obj_dt_bldet.Rows[i]["fd"].ToString());
                    str_pod = obj_da_port.GetPortname(int_pod);
                    
                    // changed for bang del hyd branch portcode as per nambi instruction
                    str_podcode = obj_da_port.GetPortcode4BlrDelHyd(str_pod.ToUpper());
                    //end
                  //  str_loginpcode = Convert.ToString(obj_dt_jinfo.Rows[0]["Shippod"].ToString());
                    //str_podcode = obj_da_port.GetPortcode(str_pod);
                    str_CargoInfo = str_CargoInfo + Convert.ToChar(29);
                    //str_CargoInfo = str_CargoInfo + str_loginpcode.TrimEnd();  //Hide on 13May2022 
                    str_CargoInfo = str_CargoInfo + str_consgpcode.TrimEnd();  //New Added on 13May2022
                    str_CargoInfo = str_CargoInfo + Convert.ToChar(29);
                    str_blno = obj_dt_bldet.Rows[i]["blno"].ToString();
                    str_CargoInfo = str_CargoInfo + str_blno.Trim();
                    str_CargoInfo = str_CargoInfo + Convert.ToChar(29);
                    dt_bldate = Convert.ToDateTime(obj_dt_bldet.Rows[i]["bldate"].ToString());
                    str_CargoInfo = str_CargoInfo + dt_bldate.ToString("ddMMyyyy");
                    str_CargoInfo = str_CargoInfo + Convert.ToChar(29);
                    int_consigneeid = Convert.ToInt32(obj_dt_bldet.Rows[i]["consigneeid"].ToString());
                    str_consignee = "";
                    str_consignee = obj_dt_bldet.Rows[i]["consignee"].ToString().Trim();
                    //str_CargoInfo = str_CargoInfo + objraj.GetIGM1point5CargoInfoCons(int_consigneeid, str_consignee, obj_dt_bldet.Rows[i]["caddress"].ToString().Trim()); // hide on 13Feb2023 //nambi
                    str_CargoInfo = str_CargoInfo + objraj.GetIGM1point5CargoInfoConsName(int_consigneeid, str_consignee, obj_dt_bldet.Rows[i]["caddressWOSpace"].ToString().Trim());
                    //str_CargoInfo = str_CargoInfo + objraj.GetIGM1point5CargoInfoCons(int_consigneeid, str_consignee, obj_dt_bldet.Rows[i]["caddressWOSpace"].ToString().Trim());// hide on 17Feb2023 //nambi
                    //str_consignee = obj_dt_bldet.Rows[i]["caddress"].ToString().Trim().Replace("<br/>"," ");
                    str_CargoInfo = str_CargoInfo + Convert.ToChar(29);
                    str_CargoInfo = str_CargoInfo + Convert.ToChar(29);// added nambi
                    str_CargoInfo = str_CargoInfo + Convert.ToChar(29);
                    str_CargoInfo.ToString().Replace("      ", " ");
                    str_CargoInfo.ToString().Replace("     ", " ");
                    str_CargoInfo.ToString().Replace("    ", " ");
                    str_CargoInfo.ToString().Replace("   ", " ");
                    str_CargoInfo.ToString().Replace("  ", " ");
                    str_CargoInfo = RemoveSpecialChars(str_CargoInfo);
                    //hide on 07Feb2023 //nambi //nofity not needed std
                    //str_CargoInfo = str_CargoInfo + objraj.GetIGM1point5CargoInfonotify(Convert.ToInt32(obj_dt_bldet.Rows[i]["notifypartyid"].ToString()), obj_dt_bldet.Rows[i]["notifyparty"].ToString().Trim(), obj_dt_bldet.Rows[i]["naddress"].ToString().Trim(), obj_dt_bldet.Rows[i]["caddress"].ToString().Trim());
             //end
                    //str_cons = str_consignee.Replace("\r", " ");
                    //str_cons = str_consignee.Replace(",", " ");
                    //str_cons = str_cons.Replace("\n", " ");

                    //if (str_cons.Length > 140)
                    //{
                    //    str_cons = str_cons.Substring(0, 140).Trim().Replace("<br/>", "");
                    //}

                    //int sep_count,incrmnt;
                    //sep_count = 0;
                    //incrmnt=0;
                    //sep_count = str_cons.Length / 4;

                    //str_CargoInfo = str_CargoInfo + str_cons.Substring(0, sep_count).Trim().Replace("<br/>", "");
                    //incrmnt = sep_count  ;
                    //str_CargoInfo = str_CargoInfo + Convert.ToChar(29);
                    //str_CargoInfo = str_CargoInfo + str_cons.Substring(incrmnt, sep_count).Trim().Replace("<br/>", "");
                    //incrmnt = incrmnt + sep_count;
                    //str_CargoInfo = str_CargoInfo + Convert.ToChar(29);
                    //str_CargoInfo = str_CargoInfo + str_cons.Substring(incrmnt, sep_count).Trim().Replace("<br/>", "");
                    //incrmnt = incrmnt + sep_count;
                    //str_CargoInfo = str_CargoInfo + Convert.ToChar(29);
                    //str_CargoInfo = str_CargoInfo + str_cons.Substring(incrmnt, str_cons.Length - incrmnt).Trim().Replace("<br/>", "");


                    ////if (str_cons.Length > 0)
                    ////{

                    ////    if (str_cons.Length > 140)
                    ////    {
                    ////        str_cons = str_cons.Substring(0, 140).Trim().Replace("<br/>", "");
                    ////    }

                    ////    if (str_cons.Length <= 35)
                    ////    {
                    ////        str_CargoInfo = str_CargoInfo + str_cons.Trim().Replace("<br/>", "");
                    ////        str_CargoInfo = str_CargoInfo + ".";
                    ////        str_CargoInfo = str_CargoInfo + Convert.ToChar(29);
                    ////        str_CargoInfo = str_CargoInfo + ".";
                    ////        str_CargoInfo = str_CargoInfo + Convert.ToChar(29);
                    ////        str_CargoInfo = str_CargoInfo + ".";
                    ////    }
                    ////    else if (str_cons.Length > 35 && str_cons.Length <=70)
                    ////    {
                    ////        str_CargoInfo = str_CargoInfo + str_cons.Substring(0, 35).Trim().Replace("<br/>", "");
                    ////        str_CargoInfo = str_CargoInfo + Convert.ToChar(29);
                    ////        str_CargoInfo = str_CargoInfo + str_cons.Substring(36, str_cons.Length - 36).Trim().Replace("<br/>", "");
                    ////        str_CargoInfo = str_CargoInfo + Convert.ToChar(29);
                    ////        str_CargoInfo = str_CargoInfo + ".";
                    ////        str_CargoInfo = str_CargoInfo + Convert.ToChar(29);
                    ////        str_CargoInfo = str_CargoInfo + ".";
                    ////    }
                    ////    else if (str_cons.Length > 70 && str_cons.Length <= 105)
                    ////    {
                    ////        str_CargoInfo = str_CargoInfo + str_cons.Substring(0, 35).Trim().Replace("<br/>", "");
                    ////        str_CargoInfo = str_CargoInfo + Convert.ToChar(29);
                    ////        str_CargoInfo = str_CargoInfo + str_cons.Substring(36, 35).Trim().Replace("<br/>", "");
                    ////        str_CargoInfo = str_CargoInfo + Convert.ToChar(29);
                    ////        str_CargoInfo = str_CargoInfo + str_cons.Substring(71, str_cons.Length - 71).Trim().Replace("<br/>", "");
                    ////        str_CargoInfo = str_CargoInfo + Convert.ToChar(29);
                    ////        str_CargoInfo = str_CargoInfo + ".";
                    ////    }
                    ////    else if (str_cons.Length <= 140)
                    ////    {
                    ////        str_CargoInfo = str_CargoInfo + str_cons.Substring(0, 35).Trim().Replace("<br/>", "");
                    ////        str_CargoInfo = str_CargoInfo + Convert.ToChar(29);
                    ////        str_CargoInfo = str_CargoInfo + str_cons.Substring(36, 35).Trim().Replace("<br/>", "");
                    ////        str_CargoInfo = str_CargoInfo + Convert.ToChar(29);
                    ////        str_CargoInfo = str_CargoInfo + str_cons.Substring(71,35).Trim().Replace("<br/>", "");
                    ////        str_CargoInfo = str_CargoInfo + Convert.ToChar(29);
                    ////        str_CargoInfo = str_CargoInfo + str_cons.Substring(106, str_cons.Length - 106).Trim().Replace("<br/>", "");
                    ////    }

                    ////}


           

                    //str_CargoInfo = str_CargoInfo + Convert.ToChar(29);
                    //int_notifyid = Convert.ToInt32(obj_dt_bldet.Rows[i]["notifypartyid"].ToString());
                    //str_notify = "";
                    //str_notify = obj_dt_bldet.Rows[i]["notifyparty"].ToString().Trim();
                    //str_notify = obj_dt_bldet.Rows[i]["naddress"].ToString().Replace("\r\n", "");

                    //str_noti = str_notify.ToString().Replace("\r", " ");
                    //str_noti = str_notify.ToString().Replace(",", " ");
                    //str_noti = str_noti.ToString().Replace("\n", " ");

                    //if (str_noti.Length > 0)
                    //{

                    //    if (str_noti.Length > 140)
                    //    {
                    //        str_noti = str_noti.Substring(0, 140).Replace("<br/>", "");
                    //    }
                    //    sep_count = 0;
                    //    incrmnt = 0;
                    //    sep_count = str_noti.Length / 4;

                    //    str_CargoInfo = str_CargoInfo + str_noti.Substring(0, sep_count).Trim().Replace("<br/>", "");
                    //    incrmnt = sep_count;
                    //    str_CargoInfo = str_CargoInfo + Convert.ToChar(29);
                    //    str_CargoInfo = str_CargoInfo + str_noti.Substring(incrmnt, sep_count).Trim().Replace("<br/>", "");
                    //    incrmnt = incrmnt + sep_count;
                    //    str_CargoInfo = str_CargoInfo + Convert.ToChar(29);
                    //    str_CargoInfo = str_CargoInfo + str_noti.Substring(incrmnt, sep_count).Trim().Replace("<br/>", "");
                    //    incrmnt = incrmnt + sep_count;
                    //    str_CargoInfo = str_CargoInfo + Convert.ToChar(29);
                    //    str_CargoInfo = str_CargoInfo + str_noti.Substring(incrmnt, str_noti.Length - incrmnt).Trim().Replace("<br/>", "");
                        
                        


                    //    /*if (str_noti.Length <= 35)
                    //    {
                    //        str_CargoInfo = str_CargoInfo + str_noti.Trim().Replace("<br/>", "");
                    //        str_CargoInfo = str_CargoInfo + ".";
                    //        str_CargoInfo = str_CargoInfo + Convert.ToChar(29);
                    //        str_CargoInfo = str_CargoInfo + ".";
                    //        str_CargoInfo = str_CargoInfo + Convert.ToChar(29);
                    //        str_CargoInfo = str_CargoInfo + ".";
                    //    }
                    //    else if (str_noti.Length > 35 && str_noti.Length <= 70)
                    //    {
                    //        str_CargoInfo = str_CargoInfo + str_noti.Substring(0, 35).Trim().Replace("<br/>", "");
                    //        str_CargoInfo = str_CargoInfo + Convert.ToChar(29);
                    //        str_CargoInfo = str_CargoInfo + str_noti.Substring(36, str_noti.Length - 36).Trim().Replace("<br/>", "");
                    //        str_CargoInfo = str_CargoInfo + Convert.ToChar(29);
                    //        str_CargoInfo = str_CargoInfo + ".";
                    //        str_CargoInfo = str_CargoInfo + Convert.ToChar(29);
                    //        str_CargoInfo = str_CargoInfo + ".";
                    //    }
                    //    else if (str_noti.Length > 70 && str_noti.Length <= 105)
                    //    {
                    //        str_CargoInfo = str_CargoInfo + str_noti.Substring(0, 35).Trim().Replace("<br/>", "");
                    //        str_CargoInfo = str_CargoInfo + Convert.ToChar(29);
                    //        str_CargoInfo = str_CargoInfo + str_noti.Substring(36, 35).Trim().Replace("<br/>", "");
                    //        str_CargoInfo = str_CargoInfo + Convert.ToChar(29);
                    //        str_CargoInfo = str_CargoInfo + str_noti.Substring(71, str_noti.Length - 71).Trim().Replace("<br/>", "");
                    //        str_CargoInfo = str_CargoInfo + Convert.ToChar(29);
                    //        str_CargoInfo = str_CargoInfo + ".";
                    //    }
                    //    else if (str_noti.Length <= 140)
                    //    {
                    //        str_CargoInfo = str_CargoInfo + str_noti.Substring(0, 35).Trim().Replace("<br/>", "");
                    //        str_CargoInfo = str_CargoInfo + Convert.ToChar(29);
                    //        str_CargoInfo = str_CargoInfo + str_noti.Substring(36, 35).Trim().Replace("<br/>", "");
                    //        str_CargoInfo = str_CargoInfo + Convert.ToChar(29);
                    //        str_CargoInfo = str_CargoInfo + str_noti.Substring(71, 35).Trim().Replace("<br/>", "");
                    //        str_CargoInfo = str_CargoInfo + Convert.ToChar(29);
                    //        str_CargoInfo = str_CargoInfo + str_noti.Substring(106, str_noti.Length - 106).Trim().Replace("<br/>", "");
                    //    }
                    //    */
                    //}
                  

                    str_CargoInfo = str_CargoInfo + Convert.ToChar(29);

                    str_CargoInfo = str_CargoInfo + "C";
                    str_CargoInfo = str_CargoInfo + Convert.ToChar(29);
                    srt_itemtype = obj_dt_bldet.Rows[i]["itemtype"].ToString();

                    if (srt_itemtype == null)
                    {
                        str_CargoInfo = str_CargoInfo + "OT";
                    }
                    else
                    {
                        str_CargoInfo = str_CargoInfo + srt_itemtype;
                    }

                    str_type = obj_dt_bldet.Rows[i]["cargommt"].ToString();
                    str_CargoInfo = str_CargoInfo + Convert.ToChar(29);
                    if (str_type == "")
                    {
                        str_CargoInfo = str_CargoInfo + "LC";
                    }
                    else
                    {
                        str_CargoInfo = str_CargoInfo + str_type.Trim();
                    }

                    str_CargoInfo = str_CargoInfo + Convert.ToChar(29);
                    if ((obj_dt_bldet.Rows[i]["pod"].ToString() == obj_dt_bldet.Rows[i]["fd"].ToString()) || ((obj_dt_bldet.Rows[i]["pod"].ToString() == "15632") && (obj_dt_bldet.Rows[i]["fd"].ToString() == "11315"))) //(obj_dt_bldet.Rows[i]["pod"].ToString() == obj_dt_bldet.Rows[i]["fd"].ToString())
                    {
                        str_CargoInfo = str_CargoInfo + str_cfscode;
                    }

                    str_CargoInfo = str_CargoInfo + Convert.ToChar(29);
                    int_noofpkgs = Convert.ToInt32(obj_dt_bldet.Rows[i]["noofpkgs"].ToString().Trim());
                    str_CargoInfo = str_CargoInfo + int_noofpkgs.ToString().Trim();/**/
                    int_pkg = Convert.ToInt32(obj_dt_bldet.Rows[i]["packageid"].ToString().Trim());
                    str_pkgtype = obj_da_pack.GetPackageCodePkgID(int_pkg).Trim();
                    str_CargoInfo = str_CargoInfo + Convert.ToChar(29);
                    str_CargoInfo = str_CargoInfo + str_pkgtype.Trim();
                  //  weight = obj_dt_bldet.Rows[i]["grweight"].ToString();
                   int_weight = ((Convert.ToDouble( obj_dt_bldet.Rows[i]["grweight"])));    
                 
                    str_CargoInfo = str_CargoInfo + Convert.ToChar(29);
                    str_CargoInfo = str_CargoInfo + Convert.ToDouble(int_weight).ToString("#0.000");/**/
                    str_CargoInfo = str_CargoInfo + Convert.ToChar(29);
                    str_CargoInfo = str_CargoInfo + "KGS";
                    str_CargoInfo = str_CargoInfo + Convert.ToChar(29);
                    str_CargoInfo = str_CargoInfo + Convert.ToChar(29);
                    str_CargoInfo = str_CargoInfo + Convert.ToChar(29);
                    str_marks = obj_dt_bldet.Rows[i]["marks"].ToString().Trim().Replace("<br/>", "");
                    str_CargoInfo = str_CargoInfo + str_marks.Trim();
                    //str_desc = obj_dt_bldet.Rows[i]["descn"].ToString().Trim().Replace("<br/>", "");
                    str_desc = objraj.GetIGMDesc(obj_dt_bldet.Rows[i]["descn"].ToString()); 

                    

                   str_CargoInfo = str_CargoInfo + Convert.ToChar(29);
              //  str_CargoInfo = str_CargoInfo + str_desc.Substring(0, (str_desc.Length -30)).Trim().Replace("<br/>", "");
                   //str_CargoInfo = str_CargoInfo + str_desc.ToString(); //str_desc.Substring(0, 30).ToString().Trim().Replace("<br/>", "").Replace("  "," ");//hode on 07Feb2023 //nambi

                   if (str_desc.Length > 30)
                   {
                       str_CargoInfo = str_CargoInfo + str_desc.Substring(0, 30).ToString().Trim().Replace("<br/>", "").Replace("  ", " ");
                   }
                   else
                   {
                       str_CargoInfo = str_CargoInfo + str_desc.ToString();
                   }
                    
                    imocode = obj_dt_bldet.Rows[i]["imocode"].ToString().Trim();
                    str_CargoInfo = str_CargoInfo + Convert.ToChar(29);
                    str_CargoInfo = str_CargoInfo + imocode.Trim();
                    str_unicode = obj_dt_bldet.Rows[i]["unocode"].ToString().Trim();
                    str_CargoInfo = str_CargoInfo + Convert.ToChar(29);
                    str_CargoInfo = str_CargoInfo + str_unicode.Trim();
                    str_CargoInfo = str_CargoInfo + Convert.ToChar(29);

                    if ((obj_dt_bldet.Rows[i]["pod"].ToString() == obj_dt_bldet.Rows[i]["fd"].ToString()) || ((obj_dt_bldet.Rows[i]["pod"].ToString() == "15632") && (obj_dt_bldet.Rows[i]["fd"].ToString() == "11315"))) //(obj_dt_bldet.Rows[i]["pod"].ToString() == obj_dt_bldet.Rows[i]["fd"].ToString())
                    {
                        str_CargoInfo = str_CargoInfo + str_bondno.Trim();
                    }

                    str_CargoInfo = str_CargoInfo + Convert.ToChar(29);
                    //str_CargoInfo = str_CargoInfo + Convert.ToChar(29);   //Newly removed M+R Chennai  PRATHIBA

                    //if (obj_dt_bldet.Rows[i]["pod"].ToString() != obj_dt_bldet.Rows[i]["fd"].ToString())
                    //{
                    //    str_CargoInfo = str_CargoInfo + "R";
                    //}

                    //Added on 17Feb2023
                    str_CargoInfo = str_CargoInfo + Convert.ToChar(29);
                    //str_CargoInfo = str_CargoInfo + "R";
                    if ((obj_dt_bldet.Rows[i]["pod"].ToString() != obj_dt_bldet.Rows[i]["fd"].ToString()))
                    {
                        str_CargoInfo = str_CargoInfo + "R";
                    }

                    //str_CargoInfo = str_CargoInfo + Convert.ToChar(29);  //Newly removed M+R Chennai  PRATHIBA

                   

                    if (int_branchid == 5 || int_branchid == 42 || int_branchid == 58)
                    {
                    }
                    else
                    {

                       // str_CargoInfo = str_CargoInfo.Trim() + str_cfspanno.Trim()  + Convert.ToChar(29) + str_mlopano.Trim();/**/ 
                        str_cfspanno = ""; // added on 07Feb2023 //nambi
                        // hide on 17Feb2023
                        //str_CargoInfo = str_CargoInfo.Trim() + str_cfspanno.Trim().Replace("<br/>", "") + Convert.ToChar(29) + Convert.ToChar(29) + str_mlopano.Trim();/**/    //Newly removed M+R Chennai  PRATHIBA
                        //Added on 17Feb2023
                        str_CargoInfo = str_CargoInfo.Trim() + str_cfspanno.Trim().Replace("<br/>", "") + Convert.ToChar(29) + str_mlopano.Trim();/**/    //Newly removed M+R Chennai  PRATHIBA

                      
                    }
                    str_CargoInfo.ToString().Replace("   ", " ");
                    str_CargoInfo = str_CargoInfo.Replace("<br/>", "");
                    TW.WriteLine(str_CargoInfo);
                    TW.Flush();
                
                }
            }

            str_CargoInfo = "";
            str_CargoInfo = str_CargoInfo + "<END-conscargo>";
            TW.WriteLine(str_CargoInfo);
            TW.Flush();
        }

        private void GetIGM1point5ContainerInfo()
        {
            str_ContainerInfo = "";
            str_ContainerInfo = str_ContainerInfo + "<conscont>";
            TW.WriteLine(str_ContainerInfo);
            TW.Flush();

          //  DataAccess.ForwardingImports.JobInfo obj_da_jinfo = new DataAccess.ForwardingImports.JobInfo();
            DataTable obj_dt_jinfo = new DataTable();

            obj_dt_jinfo = obj_da_jinfo.ShowJobDetails(int_jobno, int_branchid, int_divisionid);

            if (obj_dt_jinfo.Rows.Count > 0)
            {
                if (obj_dt_jinfo.Rows[0]["cvslcode"].ToString() != "")
                {
                    str_CVslcode = obj_dt_jinfo.Rows[0]["cvslcode"].ToString();
                }
                if (obj_dt_jinfo.Rows[0]["voyage"].ToString() != "")
                {
                    str_Voyage = obj_dt_jinfo.Rows[0]["voyage"].ToString();
                }
            }

            DataTable obj_dt_bldet = new DataTable();
            int_branchid = Convert.ToInt32(Session["LoginBranchid"].ToString());
          //  DataAccess.ForwardingImports.BLDetails obj_da_bldet = new DataAccess.ForwardingImports.BLDetails();

            obj_dt_bldet = obj_da_bldet.GetBLContDtJobno(int_jobno, int_branchid, int_divisionid);
            if (obj_dt_bldet.Rows.Count > 0)
            {
                for (int i = 0; i < obj_dt_bldet.Rows.Count; i++)
                {
                    str_ContainerInfo = "";
                    str_ContainerInfo = "F".Trim() + Convert.ToChar(29);
                    str_ContainerInfo = str_ContainerInfo + str_loginpcode.Trim();
                    str_ContainerInfo = str_ContainerInfo + Convert.ToChar(29);
                    str_ContainerInfo = str_ContainerInfo + str_cardno.Trim();
                    str_ContainerInfo = str_ContainerInfo + Convert.ToChar(29);
                    str_ContainerInfo = str_ContainerInfo + str_imno.Trim();
                    str_ContainerInfo = str_ContainerInfo + Convert.ToChar(29);
                    str_ContainerInfo = str_ContainerInfo + dt_imdate.ToString("ddMMyyyy");
                    str_ContainerInfo = str_ContainerInfo + Convert.ToChar(29);
                    str_ContainerInfo = str_ContainerInfo + str_imocode.Trim();
                    str_ContainerInfo = str_ContainerInfo + Convert.ToChar(29);
                    str_ContainerInfo = str_ContainerInfo + str_CVslcode.Trim();
                    str_ContainerInfo = str_ContainerInfo + Convert.ToChar(29);
                    str_ContainerInfo = str_ContainerInfo + str_Voyage.Trim();
                    str_ContainerInfo = str_ContainerInfo + Convert.ToChar(29);
                    str_ContainerInfo = str_ContainerInfo + obj_dt_bldet.Rows[i]["linenumber"].ToString().Trim().Replace("<br/>", "");
                    str_ContainerInfo = str_ContainerInfo + Convert.ToChar(29);
                    str_ContainerInfo = str_ContainerInfo + obj_dt_bldet.Rows[i]["sublineno"].ToString().Trim().Replace("<br/>", "");
                    str_ContainerInfo = str_ContainerInfo + Convert.ToChar(29);
                    str_ContainerInfo = str_ContainerInfo + obj_dt_bldet.Rows[i]["containerno"].ToString().Trim().Replace("<br/>", "");
                    str_ContainerInfo = str_ContainerInfo + Convert.ToChar(29);
                    str_ContainerInfo = str_ContainerInfo + obj_dt_bldet.Rows[i]["sealno"].ToString().Trim().Replace("<br/>", "");
                    str_ContainerInfo = str_ContainerInfo + Convert.ToChar(29);

                    if(int_branchid==5||int_branchid==42||int_branchid==58)
                        
                    {
                        str_ContainerInfo = str_ContainerInfo + str_clinecode.Trim();
                    }
                    else
                    {
                            str_ContainerInfo = str_ContainerInfo +str_mlopano.Trim();
                    }
                
                    str_ContainerInfo = str_ContainerInfo + Convert.ToChar(29);

                    if (str_intjobtype == "1")
                    {
                        str_ContainerInfo = str_ContainerInfo + "LCL";
                    }
                    else if (str_intjobtype == "3")
                    {
                        str_ContainerInfo = str_ContainerInfo + "FCL";
                    }

                    str_ContainerInfo = str_ContainerInfo + Convert.ToChar(29);
                    str_ContainerInfo = str_ContainerInfo + obj_dt_bldet.Rows[i]["noofpkgs"].ToString().Trim().Replace("<br/>", "");
                    str_ContainerInfo = str_ContainerInfo + Convert.ToChar(29);
                    //str_ContainerInfo = str_ContainerInfo + Convert.ToDouble(obj_dt_bldet.Rows[i]["grweight"]).ToString().Trim();
                    //str_ContainerInfo = str_ContainerInfo + Convert.ToDouble(Convert.ToInt32(obj_dt_bldet.Rows[i]["grweight"]).ToString("#0.000"));/**/

                   /* str_ContainerInfo = str_ContainerInfo + Math.Round(Convert.ToDouble(string.Format("{0:0.000}", (Convert.ToDouble(obj_dt_bldet.Rows[i]["grweight"]) / 1000)).ToString()),2);    */
                    Double dm=Convert.ToDouble(string.Format("{0:0.000}", (Convert.ToDouble(obj_dt_bldet.Rows[i]["grweight"]) / 1000)).ToString());

                    str_ContainerInfo = str_ContainerInfo + dm.ToString("F");


                    str_ContainerInfo = str_ContainerInfo + Convert.ToChar(29);

                    str_ContainerInfo = str_ContainerInfo + obj_dt_bldet.Rows[i]["isocode"].ToString().Trim().Replace("<br/>", "") + Convert.ToChar(29);
                    str_ContainerInfo = str_ContainerInfo + obj_dt_bldet.Rows[i]["socflag"].ToString().Trim().Replace("<br/>", "");

                    TW.WriteLine(str_ContainerInfo);
                    TW.Flush();
                }
            }

            str_ContainerInfo = "";
            str_ContainerInfo = str_ContainerInfo + "<END-conscont>";
            str_ContainerInfo = str_ContainerInfo + "\r\n";
            str_ContainerInfo = str_ContainerInfo + "<END-consoligm>";
            str_ContainerInfo = str_ContainerInfo + "\r\n";
            str_ContainerInfo = str_ContainerInfo + "TREC";
            str_ContainerInfo = str_ContainerInfo + Convert.ToChar(29);
            str_ContainerInfo = str_ContainerInfo + str_igmjob;
            TW.WriteLine(str_ContainerInfo);
            TW.Flush();
        }

        protected void lnk_job_Click(object sender, EventArgs e)
        {
            //str_Trantype = "FI";
            try
            {
                str_Trantype = "FI";
              //  DataAccess.Accounts.CostingDt obj_da_cost = new DataAccess.Accounts.CostingDt();
                DataTable obj_dt_cost = new DataTable();
                int_branchid = Convert.ToInt32(Session["LoginBranchid"].ToString());
                obj_dt_cost = obj_da_cost.GridFillJobdtls(str_Trantype, int_branchid);
                if (obj_dt_cost.Rows.Count > 0)
                {
                    mdl_cust.Show();
                    grd_cust.Visible = true;
                    grd_cust.DataSource = obj_dt_cost;
                    grd_cust.DataBind();


                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        protected void grd_cust_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (grd_cust.Rows.Count > 0)
            {
                index = Convert.ToInt32(grd_cust.SelectedRow.RowIndex.ToString());
                txt_job.Text = ((Label)grd_cust.Rows[index].Cells[1].FindControl("Job")).Text;
                hf_jobno.Value = txt_job.Text;
                txt_vessel.Text = ((Label)grd_cust.Rows[index].Cells[1].FindControl("VesselName")).Text;
                txt_mbl.Text = ((Label)grd_cust.Rows[index].Cells[2].FindControl("MBL")).Text;
                txt_pod.Text = ((Label)grd_cust.Rows[index].Cells[7].FindControl("POD")).Text;
                txt_eta.Text = ((Label)grd_cust.Rows[index].Cells[4].FindControl("ETA")).Text;
                txt_mlo.Text = ((Label)grd_cust.Rows[index].Cells[6].FindControl("MLO")).Text;
                txt_agent.Text = ((Label)grd_cust.Rows[index].Cells[5].FindControl("Agent")).Text;
                txt_pol.Text = ((Label)grd_cust.Rows[index].Cells[3].FindControl("POL")).Text;
                btn_cancel.Text = "Cancel";

                btn_cancel.ToolTip = "Cancel";
                btn_cancel1.Attributes["class"] = "btn ico-cancel";
                grd_cust.Visible = false;
                btn_igm.Focus();
            }
        }

        protected void btn_cancel_Click(object sender, EventArgs e)
        {
            if (btn_cancel.ToolTip == "Cancel")
            {
                txt_agent.Text = "";
                txt_eta.Text = "";
                txt_job.Text = "";
                txt_mbl.Text = "";
                txt_mlo.Text = "";
                txt_pod.Text = "";
                txt_pol.Text = "";
                txt_vessel.Text = "";
                btn_cancel.Text = "Back";

                btn_cancel.ToolTip = "Back";
                btn_cancel1.Attributes["class"] = "btn ico-back";
                txt_job.Focus();
            }
            else
            {
                this.Response.End();
            }
        }

        protected void txt_job_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txt_job.Text != "")
                {
                    str_Trantype = "FI";
                    int_branchid = Convert.ToInt32(Session["LoginBranchid"].ToString());
                    int_empid = Convert.ToInt32(Session["LoginEmpId"].ToString());
                    int_divisionid = Convert.ToInt32(Session["LoginDivisionId"].ToString());
                    //DataAccess.ForwardingImports.JobInfo FIJobobj = new DataAccess.ForwardingImports.JobInfo();
                    //DataAccess.Masters.MasterCustomer Custobj1 = new DataAccess.Masters.MasterCustomer();
                    //DataAccess.Accounts.CostingDt obj_da_cost = new DataAccess.Accounts.CostingDt();
                    //DataAccess.Masters.MasterVessel Vslobj = new DataAccess.Masters.MasterVessel();
                    DataTable obj_dt_cost = new DataTable();
                    string strvesselname;
                    int vslid;
                    string agent;
                  //  DataAccess.Masters.MasterPort Portobj = new DataAccess.Masters.MasterPort();
                    int_branchid = Convert.ToInt32(Session["LoginBranchid"].ToString());
                    // obj_dt_cost = obj_da_cost.GridFillJobdtls(str_Trantype, int_branchid);
                    obj_dt_cost = FIJobobj.ShowJobDetails(Convert.ToInt32(txt_job.Text), int_branchid, int_divisionid);

                    if (obj_dt_cost.Rows.Count > 0)
                    {

                        //txt_eta.Text = obj_dt_cost.Rows[0]["eta"].ToString();
                        //txt_vessel.Text = obj_dt_cost.Rows[0]["vslvoy"].ToString();
                        //txt_mbl.Text = obj_dt_cost.Rows[0]["mblno"].ToString();
                        //txt_agent.Text = obj_dt_cost.Rows[0]["agent"].ToString();
                        //txt_mlo.Text = obj_dt_cost.Rows[0]["mlo"].ToString();
                        //txt_pol.Text = obj_dt_cost.Rows[0]["pol"].ToString();
                        //txt_pod.Text = obj_dt_cost.Rows[0]["pod"].ToString();

                        vslid = Convert.ToInt32(obj_dt_cost.Rows[0]["vesselid"].ToString());
                        strvesselname = Vslobj.GetVesselname(vslid);

                        txt_vessel.Text = strvesselname + " V. " + obj_dt_cost.Rows[0]["voyage"].ToString();

                        txt_mbl.Text = obj_dt_cost.Rows[0]["mblno"].ToString();
                        txt_pod.Text = Portobj.GetPortname(Convert.ToInt32(obj_dt_cost.Rows[0]["pod"].ToString()));
                        DateTime eta = Convert.ToDateTime(obj_dt_cost.Rows[0]["eta"]);
                        txt_eta.Text = Convert.ToDateTime(eta.ToShortDateString()).ToString("MM/dd/yyyy");
                        txt_mlo.Text = Custobj1.GetCustomername(Convert.ToInt32(obj_dt_cost.Rows[0]["mlo"].ToString()));
                        int agentid = Convert.ToInt32(obj_dt_cost.Rows[0]["agent"].ToString());
                        txt_agent.Text = Custobj1.GetCustomername(agentid);

                        txt_pol.Text = Portobj.GetPortname(Convert.ToInt32(obj_dt_cost.Rows[0]["pol"].ToString()));
                        btn_cancel.Text = "Cancel";

                        btn_cancel.ToolTip = "Cancel";
                        btn_cancel1.Attributes["class"] = "btn ico-cancel";

                        txt_job.Focus();
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this.Page, typeof(Button), "DataFound", "alertify.alert('BL Already assigned for another Booking');", true);
                        txt_eta.Text = "";
                        txt_vessel.Text = "";
                        txt_mbl.Text = "";
                        txt_agent.Text = "";
                        txt_mlo.Text = "";
                        txt_pol.Text = "";
                        txt_pod.Text = "";
                    }
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);

            }
        }

        protected void grd_cust_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lblVesselName = (Label)e.Row.FindControl("VesselName");
                string tooltip = lblVesselName.Text;
                e.Row.Cells[1].Attributes.Add("title", tooltip);

                Label lblMBL = (Label)e.Row.FindControl("MBL");
                string tooltip1 = lblMBL.Text;
                e.Row.Cells[2].Attributes.Add("title", tooltip1);

                Label lblPoL = (Label)e.Row.FindControl("PoL");
                string tooltip2 = lblPoL.Text;
                e.Row.Cells[3].Attributes.Add("title", tooltip2);

                Label lblAgent = (Label)e.Row.FindControl("Agent");
                string tooltip3 = lblAgent.Text;
                e.Row.Cells[5].Attributes.Add("title", tooltip3);

                Label lblMLO = (Label)e.Row.FindControl("MLO");
                string tooltip4 = lblMLO.Text;
                e.Row.Cells[6].Attributes.Add("title", tooltip4);

                Label lblPOD = (Label)e.Row.FindControl("POD");
                string tooltip5 = lblPOD.Text;
                e.Row.Cells[7].Attributes.Add("title", tooltip5);
            }

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes.Add("onmouseover", "this.originalcolor=this.style.backgroundColor;" + " this.style.backgroundColor='#FDCB0A';");
                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalcolor;");

                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(grd_cust, "Select$" + e.Row.RowIndex);
                e.Row.Attributes["style"] = "cursor:pointer";
            }
        }

        protected void btn_ligm_Click(object sender, EventArgs e)
        {
            //try
            //{
            int_branchid = Convert.ToInt32(Session["LoginBranchid"].ToString());
            int_empid = Convert.ToInt32(Session["LoginEmpId"].ToString());
            int_divisionid = Convert.ToInt32(Session["LoginDivisionId"].ToString());
          //  DataAccess.HR.FrontPage HRFrontObj = new DataAccess.HR.FrontPage();
         //   DataAccess.ForwardingImports.BLDetails FIBLobj = new DataAccess.ForwardingImports.BLDetails();

            //object objFSO = null;
            //objFSO = Server.CreateObject("Scripting.FileSystemObject");

            //object FullPath = null;
            //FullPath = "C:\\CustomEDI";

            //string str_fullpath = "";
            //str_fullpath = "C:\\CustomEDI";

            //if (!File.Exists(str_fullpath))
            //{
            //    System.IO.Directory.CreateDirectory(str_fullpath);
            //}
            //else
            //{

            //}
            //objFSO = "";

            string str_fullpath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            str_fullpath = Server.MapPath("~/CustomEDI/");

            if (Directory.Exists(str_fullpath))
            {
                //Directory.CreateDirectory(filePath);
                foreach (string file in Directory.GetFiles(str_fullpath))
                {
                    File.Delete(file);
                }
            }
            DataTable dt = new DataTable();
            dt = HRFrontObj.GetBranchInfo(int_branchid);
            if (dt.Rows.Count > 0)
            {
                //str_cardno = dt.Rows[0]["carrno"].ToString();

                if (!string.IsNullOrEmpty(dt.Rows[0]["carrno"].ToString()))
                {
                    str_cardno = dt.Rows[0]["carrno"].ToString();
                    
                }
                else
                {
                    ScriptManager.RegisterStartupScript(btn_igm, typeof(Button), "DataFound", "alertify.alert('Carrno not update in Masterbranch');", true);
                    return;
                }
            }
            int_jobno = Convert.ToInt32(txt_job.Text);
            DataTable DTJob = new DataTable();
            DataTable DTBl = new DataTable();
            int Contpkg = 0, Blpkg = 0;
            double ContWt = 0, BlWt = 0;
            DTJob = FIBLobj.GetContWtPkgCustomEdi(int_jobno, int_branchid, int_divisionid);
            if (DTJob.Rows.Count > 0)
            {
                if (DTJob.Rows[0][0].ToString() == "")
                {
                    Contpkg = 0;
                }
                else
                {
                    Contpkg = int.Parse(DTJob.Rows[0][0].ToString());
                }
                if (DTJob.Rows[0][1].ToString() == "")
                {
                    ContWt = 0;
                }
                else
                {
                    ContWt = double.Parse(DTJob.Rows[0][1].ToString());
                }
            }
            DTBl = FIBLobj.GetBLWtPkgCustomEdi(int_jobno, int_branchid, int_divisionid);
            if (DTBl.Rows.Count > 0)
            {
                //Blpkg = int.Parse(DTBl.Rows[0][0].ToString());
                //BlWt = double.Parse(DTBl.Rows[0][1].ToString());
                if (DTBl.Rows[0][0].ToString() == "")
                {
                    Blpkg = 0;
                }
                else
                {
                    Blpkg = Convert.ToInt32(DTBl.Rows[0][0].ToString());
                }

                if (DTBl.Rows[0][1].ToString() == "")
                {
                    BlWt = 0;
                }
                else
                {
                    BlWt = Convert.ToDouble(DTBl.Rows[0][1].ToString());
                }


            }
            if (Blpkg != Contpkg)
            {
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Check Number of Packages');", true);
                return;
            }
            if (BlWt != ContWt)
            {
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Check Weight');", true);
                return;
            }
            //  TW = System.IO.File.CreateText("C:\\CustomEDI\\" + int_jobno + ".IGM");
            filename = int_jobno + ".IGM";
            TW = System.IO.File.CreateText(str_fullpath + filename);


            if (Session["LoginBranchName"].ToString().ToUpper() == "MUMBAI")
            {
                //GetMumbaiVesselInfo();
                //GetMumbaiCargoInfo();
                //GetMumbaiContainerInfo();
                GetMumbaiVesselInfonNew();
            }
            else if (Session["LoginBranchName"].ToString().ToUpper() == "CALCUTTA")
            {
                GetKolKattaVesselInfo();
                GetKolKattaCargoInfo();
                GetKolkattaContainerInfo();
            }
            else
            {
                GetVesselInfo();
                GetCargoInfo();
                GetContainerInfo();
            }
            TW.Close();

            obj_da_log.InsLogDetail(int_empid, 118, 3, int_branchid, Convert.ToString(int_jobno));
            Response.Clear();
            Response.ContentType = ContentType;
            Response.AppendHeader("Content-Disposition", "attachment; filename=" + System.IO.Path.GetFileName(str_fullpath + filename));
            Response.WriteFile(str_fullpath + filename);
            Response.Flush();
            System.IO.File.Delete(str_fullpath + filename);
            Response.End();
            //Logobj.InsLogDetail(Login.logempid, 118, 3, Login.branchid, intjobno)
            //obj_da_Log.InsLogDetail(int.Parse(Session["LoginEmpId"].ToString()), 1, 4, int.Parse(Session["LoginBranchid"].ToString()), txt_job.Text + " FE-JobRegVew");
            //}
            //catch (Exception ex)
            //{
            //    string message = ex.Message.ToString();
            //    ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            //}
        }

        public void GetMumbaiVesselInfonNew()
        {
            int_branchid = Convert.ToInt32(Session["LoginBranchid"].ToString());
            int_empid = Convert.ToInt32(Session["LoginEmpId"].ToString());
            //int_divisionid = Convert.ToInt32(Session["LoginDivisionId"].ToString());
            //DataAccess.Masters.MasterVessel Vslobj = new DataAccess.Masters.MasterVessel();
            //DataAccess.ForwardingImports.JobInfo FIJobobj = new DataAccess.ForwardingImports.JobInfo();
            //DataAccess.Masters.MasterPort Portobj = new DataAccess.Masters.MasterPort();

            string freight = "", cvsltype = "", transportmode = "", linecode = "", agentcode = "", strvesselname = "";
            int_jobno = Convert.ToInt32(txt_job.Text);
            int vslid;
            dtCustomEDI = FIJobobj.ShowJobDetails(int_jobno, int_branchid, int_divisionid);
            if (dtCustomEDI.Rows.Count > 0)
            {
                vslid = Convert.ToInt32(dtCustomEDI.Rows[0]["vesselid"].ToString());
                strvesselname = Vslobj.GetVesselname(vslid);
                str_CVslcode = dtCustomEDI.Rows[0]["cvslcode"].ToString();
                str_callsign = dtCustomEDI.Rows[0]["callsign"].ToString();
                if (dtCustomEDI.Rows[0]["voyage"].ToString() != "")
                {
                    str_Voyage = dtCustomEDI.Rows[0]["voyage"].ToString();
                }
                if (dtCustomEDI.Rows[0]["pol"].ToString() != "")
                {
                    int_pol = Convert.ToInt32(dtCustomEDI.Rows[0]["pol"].ToString());
                }
                str_pol = Portobj.GetPortname(int_pol);
                str_polcode = Portobj.GetPortcode(str_pol);
                if (dtCustomEDI.Rows[0]["pod"].ToString() != "")
                {
                    int_pod = Convert.ToInt32(dtCustomEDI.Rows[0]["pod"].ToString());
                }
                str_pod = Portobj.GetPortname(int_pod);
                str_podcode = Portobj.GetPortcode(str_pod);
                str_clinecode = dtCustomEDI.Rows[0]["clinecode"].ToString();
                cvsltype = dtCustomEDI.Rows[0]["cvsltype"].ToString();
                if (Convert.ToInt32(dtCustomEDI.Rows[0]["jobtype"].ToString()) == 3)
                {
                    str_jobtype = "FCL";
                }
                else { str_jobtype = "LCL"; }
                str_bondno = dtCustomEDI.Rows[0]["bondno"].ToString();
                transportmode = dtCustomEDI.Rows[0]["mmtdetails"].ToString();
                linecode = dtCustomEDI.Rows[0]["clinecode"].ToString();
                agentcode = dtCustomEDI.Rows[0]["cagent"].ToString();
            }
            str_VesInfo = str_VesInfo + "<manifest>2.0" + System.Environment.NewLine;
            str_VesInfo = str_VesInfo + "<vesinfo>" + System.Environment.NewLine;
            str_VesInfo = str_VesInfo + "V" + Convert.ToChar(29) + Convert.ToChar(29) + Convert.ToChar(29);
            str_VesInfo = str_VesInfo + strvesselname.Trim() + Convert.ToChar(29);
            str_VesInfo = str_VesInfo + str_callsign.Trim() + Convert.ToChar(29);
            str_VesInfo = str_VesInfo + str_Voyage.Substring(str_Voyage.Length - 3, 3).Trim() + Convert.ToChar(29);
            str_VesInfo = str_VesInfo + str_clinecode.Trim() + Convert.ToChar(29) + Convert.ToChar(29) + Convert.ToChar(29);
            str_VesInfo = str_VesInfo + "SI" + Convert.ToChar(29);
            str_VesInfo = str_VesInfo + str_podcode.Trim() + Convert.ToChar(29) + Convert.ToChar(29) + Convert.ToChar(29) + Convert.ToChar(29) + Convert.ToChar(29) + Convert.ToChar(29) + Convert.ToChar(29) + Convert.ToChar(29) + Convert.ToChar(29) + Convert.ToChar(29) + Convert.ToChar(29) + Convert.ToChar(29) + Convert.ToChar(29) + Convert.ToChar(29) + Convert.ToChar(29) + Convert.ToChar(29) + Convert.ToChar(29) + Convert.ToChar(29);
            str_VesInfo = str_VesInfo + str_podcode.Trim() + Convert.ToChar(29) + System.Environment.NewLine;
            str_VesInfo = str_VesInfo + "<END-vesinfo>" + System.Environment.NewLine;
            getMumbaiCargoDetailsIGM(int_jobno);
            GetMumbaiContainerInfoIGM();
            TW.WriteLine(str_VesInfo);
            TW.Flush();
        }

        public void getMumbaiCargoDetailsIGM(int int_jobno)
        {
            int_branchid = Convert.ToInt32(Session["LoginBranchid"].ToString());
            int_empid = Convert.ToInt32(Session["LoginEmpId"].ToString());
            int_divisionid = Convert.ToInt32(Session["LoginDivisionId"].ToString());
            //DataAccess.ForwardingImports.BLDetails FIBLobj = new DataAccess.ForwardingImports.BLDetails();
            //DataAccess.Masters.MasterPort Portobj = new DataAccess.Masters.MasterPort();
            //DataAccess.Masters.MasterPackages Pkgsobj = new DataAccess.Masters.MasterPackages();

            string freight = "", notifyAddr = "", consigneeAddr = "", marks = "", descn = "";
            dtCustomEDI1 = FIBLobj.GetBLDetailJobno(int_jobno, int_branchid, int_divisionid);
            if (dtCustomEDI1.Rows.Count > 0)
            {
                str_VesInfo = str_VesInfo + "<cargo>" + System.Environment.NewLine;
                for (int i = 0; i < dtCustomEDI1.Rows.Count; i++)
                {
                    str_Lineno = dtCustomEDI1.Rows[i]["linenumber"].ToString().Replace("<br/>", "");
                    str_blno = dtCustomEDI1.Rows[i]["blno"].ToString().Replace("<br/>", "");
                    dt_bldate = Convert.ToDateTime(dtCustomEDI1.Rows[i]["bldate"].ToString());
                    str_consignee = dtCustomEDI1.Rows[i]["consignee"].ToString().Trim().Replace("<br/>", "");
                    consigneeAddr = dtCustomEDI1.Rows[i]["caddress"].ToString().Trim().Replace("<br/>", "");//.Replace(str_consignee,"");
                    str_notify = dtCustomEDI1.Rows[i]["notifyparty"].ToString().Trim().Replace("<br/>", "");
                    notifyAddr = dtCustomEDI1.Rows[i]["naddress"].ToString().Trim().Replace("<br/>", "");//.Replace(str_notify,"");
                    freight = dtCustomEDI1.Rows[i]["freight"].ToString().Replace("<br/>", "");

                    if (dtCustomEDI1.Rows[i]["itemtype"].ToString().Replace("<br/>", "") == "")
                    {
                        str_itemtype = "OT";
                    }
                    else
                    {
                        dtCustomEDI1.Rows[i]["itemtype"].ToString().Replace("<br/>","");
                    }
                   // int_weight = Convert.ToDouble(dtCustomEDI1.Rows[i]["grweight"].ToString().Replace("<br/>",""));
                    int_weight = Convert.ToDouble(Convert.ToInt32(dtCustomEDI1.Rows[i]["grweight"]).ToString("#0.000"));
                    marks = dtCustomEDI1.Rows[i]["marks"].ToString().Replace("<br/>","");
                    descn = dtCustomEDI1.Rows[i]["descn"].ToString().Replace("<br/>","");
                    imocode = dtCustomEDI1.Rows[i]["imocode"].ToString().Replace("<br/>","");
                    str_unicode = dtCustomEDI1.Rows[i]["unocode"].ToString().Replace("<br/>","").Trim();
                    string TransportMode = "", bondno = "", agentcode = "";
                    if (dtCustomEDI1.Rows[i]["pod"].ToString() != "")
                    {
                        int_pod = Convert.ToInt32(dtCustomEDI1.Rows[i]["pod"].ToString());
                    }
                    str_sublineno = dtCustomEDI1.Rows[i]["sublineno"].ToString().Replace("<br/>","");

                    if (dtCustomEDI1.Rows[i]["transhipedat"].ToString() != "")
                    {
                        int_pol = Convert.ToInt32(dtCustomEDI1.Rows[i]["transhipedat"].ToString());
                    }
                    str_pol = Portobj.GetPortcode(Portobj.GetPortname(int_pol)).Replace("<br/>","");

                    if (dtCustomEDI1.Rows[i]["pod"].ToString() != "")
                    {
                        int_fd = Convert.ToInt32(dtCustomEDI1.Rows[i]["pod"].ToString());
                    }
                    str_fd = Portobj.GetPortcode(Portobj.GetPortname(int_fd)).Replace("<br/>","");

                    if (dtCustomEDI1.Rows[i]["consigneeid"].ToString() != "")
                    {
                        int_consigneeid = Convert.ToInt32(dtCustomEDI1.Rows[i]["consigneeid"].ToString());
                    }

                    if (dtCustomEDI1.Rows[i]["notifypartyid"].ToString() != "")
                    {
                        //int_notifyid = Convert.ToInt32(dtCustomEDI1.Rows[i]["notifypartyid"].ToString());
                    }
                    str_cargo = dtCustomEDI1.Rows[i]["cargo"].ToString().Replace("<br/>", "");

                    if (dtCustomEDI1.Rows[i]["cargommt"].ToString() == "")
                    {
                        str_type = "LC";
                    }
                    else
                    {
                        str_type = dtCustomEDI1.Rows[i]["cargommt"].ToString();
                    }

                    if (dtCustomEDI1.Rows[i]["noofpkgs"].ToString() != "")
                    {
                        int_noofpkgs = Convert.ToInt32(dtCustomEDI1.Rows[i]["noofpkgs"].ToString().Replace("<br/>", ""));
                    }

                    if (dtCustomEDI1.Rows[i]["packageid"].ToString() != "")
                    {
                        int_pkg = Convert.ToInt32(dtCustomEDI1.Rows[i]["packageid"].ToString().Replace("<br/>", ""));
                    }

                    str_pkgtype = Pkgsobj.GetPackageCodePkgID(int_pkg);
                    str_VesInfo = str_VesInfo + "V" + Convert.ToChar(29) + str_callsign.Trim() + Convert.ToChar(29);
                    str_VesInfo = str_VesInfo + str_Voyage.Substring(str_Voyage.Length - 3, 3).Trim() + Convert.ToChar(29) + Convert.ToChar(29) + Convert.ToChar(29);
                    str_VesInfo = str_VesInfo + i + 1 + Convert.ToChar(29) + Convert.ToChar(29);
                    str_VesInfo = str_VesInfo + str_blno.Trim() + Convert.ToChar(29);
                    str_VesInfo = str_VesInfo + dt_bldate.ToString("ddMMyyyy") + Convert.ToChar(29);
                    //str_VesInfo = str_VesInfo + Utility.fn_ConvertDate(dt_bldate.ToShortDateString()) + Convert.ToChar(29);
                    str_VesInfo = str_VesInfo + str_polcode.Trim() + Convert.ToChar(29);
                    str_VesInfo = str_VesInfo + str_podcode.Trim() + Convert.ToChar(29) + Convert.ToChar(29) + Convert.ToChar(29);
                    str_VesInfo = str_VesInfo + str_consignee.Trim() + Convert.ToChar(29);

                    str_cons = str_consignee.Replace("\r", " ");
                    str_cons = str_cons.Replace("\n", " ");


                    if (str_cons.Length > 140)
                    {
                        str_cons = str_cons.Substring(0, 140).Replace("<br/>", "");
                    }

                    int sep_count, incrmnt;
                    sep_count = 0;
                    incrmnt = 0;
                    sep_count = str_cons.Length / 4;

                    str_CargoInfo = str_CargoInfo + str_cons.Substring(0, sep_count).Replace("<br/>", "");
                    incrmnt = sep_count;
                    str_CargoInfo = str_CargoInfo + Convert.ToChar(29);
                    str_CargoInfo = str_CargoInfo + str_cons.Substring(incrmnt, sep_count).Replace("<br/>", "");
                    incrmnt = incrmnt + sep_count;
                    str_CargoInfo = str_CargoInfo + Convert.ToChar(29);
                    str_CargoInfo = str_CargoInfo + str_cons.Substring(incrmnt, sep_count).Replace("<br/>", "");
                    incrmnt = incrmnt + sep_count;
                    str_CargoInfo = str_CargoInfo + Convert.ToChar(29);
                    str_CargoInfo = str_CargoInfo + str_cons.Substring(incrmnt, str_cons.Length - incrmnt).Replace("<br/>", "");


                 
                    str_VesInfo = str_VesInfo + Convert.ToChar(29);
                    str_VesInfo = str_VesInfo + str_notify.Trim() + Convert.ToChar(29);
                    str_noti = notifyAddr.Replace("\r", " ");
                    str_noti = str_noti.Replace("\n", " ");

                    if (str_noti.Length > 140)
                    {
                        str_noti = str_noti.Substring(0, 140).Replace("<br/>", "");
                    }
                    sep_count = 0;
                    incrmnt = 0;
                    sep_count = str_noti.Length / 4;

                    str_CargoInfo = str_CargoInfo + str_noti.Substring(0, sep_count).Replace("<br/>", "");
                    incrmnt = sep_count;
                    str_CargoInfo = str_CargoInfo + Convert.ToChar(29);
                    str_CargoInfo = str_CargoInfo + str_noti.Substring(incrmnt, sep_count).Replace("<br/>", "");
                    incrmnt = incrmnt + sep_count;
                    str_CargoInfo = str_CargoInfo + Convert.ToChar(29);
                    str_CargoInfo = str_CargoInfo + str_noti.Substring(incrmnt, sep_count).Replace("<br/>", "");
                    incrmnt = incrmnt + sep_count;
                    str_CargoInfo = str_CargoInfo + Convert.ToChar(29);
                    str_CargoInfo = str_CargoInfo + str_noti.Substring(incrmnt, str_noti.Length - incrmnt).Replace("<br/>", "");
                        




                    str_VesInfo = str_VesInfo + Convert.ToChar(29);
                    str_VesInfo = str_VesInfo + freight.Trim() + Convert.ToChar(29);
                    str_VesInfo = str_VesInfo + str_itemtype.Trim() + Convert.ToChar(29);
                    str_VesInfo = str_VesInfo + str_type.Trim() + Convert.ToChar(29) + Convert.ToChar(29);
                    str_VesInfo = str_VesInfo + int_noofpkgs + Convert.ToChar(29);
                    str_VesInfo = str_VesInfo + str_pkgtype.Trim() + Convert.ToChar(29);
                    str_VesInfo = str_VesInfo + Convert.ToDouble(int_weight).ToString("#0.000")+ Convert.ToChar(29);
                    str_VesInfo = str_VesInfo + "KGS" + Convert.ToChar(29) + Convert.ToChar(29) + Convert.ToChar(29);
                    if (marks.Length > 300)
                    {
                        str_VesInfo = str_VesInfo + marks.Substring(0, 300).Trim();
                    }
                    else
                    {
                        str_VesInfo = str_VesInfo + marks.Trim();
                    }
                    str_VesInfo = str_VesInfo + Convert.ToChar(29);

                    if (descn.Length > 300)
                    {
                        str_VesInfo = str_VesInfo + descn.Substring(0, 300).Trim() + Convert.ToChar(29);
                    }
                    else
                    {
                        str_VesInfo = str_VesInfo + descn.Trim() + Convert.ToChar(29);
                    }
                    str_VesInfo = str_VesInfo + imocode.Trim() + Convert.ToChar(29);
                    str_VesInfo = str_VesInfo + str_unicode.Trim() + Convert.ToChar(29) + Convert.ToChar(29) + Convert.ToChar(29) + Convert.ToChar(29) + Convert.ToChar(29);
                    if (bondno != "")
                    {
                        str_VesInfo = str_VesInfo + bondno.Trim() + Convert.ToChar(29);
                    }
                    if (TransportMode != "")
                    {
                        str_VesInfo = str_VesInfo + TransportMode.Trim() + Convert.ToChar(29);
                    }
                    if (str_linecode != "")
                    {
                        str_VesInfo = str_VesInfo + str_linecode.Trim() + Convert.ToChar(29);
                    }
                    if (agentcode != "")
                    {
                        str_VesInfo = str_VesInfo + agentcode.Trim() + Convert.ToChar(29);
                    }
                    str_VesInfo = str_VesInfo + System.Environment.NewLine;
                }
                str_VesInfo = str_VesInfo + "<END-cargo>";
            }
        }

        public void GetMumbaiContainerInfoIGM()
        {
            int_branchid = Convert.ToInt32(Session["LoginBranchid"].ToString());
            int_empid = Convert.ToInt32(Session["LoginEmpId"].ToString());
            int_divisionid = Convert.ToInt32(Session["LoginDivisionId"].ToString());
         //   DataAccess.ForwardingImports.BLDetails FIBLobj = new DataAccess.ForwardingImports.BLDetails();

            string linenumber = "", sublineno = "", containerno = "", sealno = "", linecode = "", noofpkgs = "", grweight = "", isocode = "", socflag = "";
            dtCustomEDI2 = FIBLobj.GetBLContDtJobno(int_jobno, int_branchid, int_divisionid);
            if (dtCustomEDI2.Rows.Count > 0)
            {
                str_VesInfo = str_VesInfo + System.Environment.NewLine;
                str_VesInfo = str_VesInfo + "<contain>" + System.Environment.NewLine;
                for (int i = 0; i < dtCustomEDI2.Rows.Count; i++)
                {
                    linenumber = dtCustomEDI2.Rows[i]["linenumber"].ToString().Trim().Replace("<br/>", "");
                    containerno = dtCustomEDI2.Rows[i]["containerno"].ToString().Trim().Replace("<br/>", "");
                    sealno = dtCustomEDI2.Rows[i]["sealno"].ToString().Trim().Replace("<br/>", "");
                    noofpkgs = dtCustomEDI2.Rows[i]["noofpkgs"].ToString().Trim().Replace("<br/>", "");
                    isocode = dtCustomEDI2.Rows[i]["isocode"].ToString().Trim().Replace("<br/>", "");
                    socflag = dtCustomEDI2.Rows[i]["socflag"].ToString().Trim().Replace("<br/>", "");
                    sublineno = dtCustomEDI2.Rows[i]["sublineno"].ToString().Trim().Replace("<br/>", "");
                    //linecode = dtCustomEDI2.Rows[i]["clinecode"].ToString().Trim().Replace("<br/>", "");
                    linecode = linecode.Trim().Replace("<br/>", "");

                    str_VesInfo = str_VesInfo + "V" + Convert.ToChar(29);
                    str_VesInfo = str_VesInfo + str_callsign.Trim() + Convert.ToChar(29);
                    str_VesInfo = str_VesInfo + str_Voyage.Substring(str_Voyage.Length - 3, 3).Trim() + Convert.ToChar(29) + Convert.ToChar(29) + Convert.ToChar(29);
                    str_VesInfo = str_VesInfo + i + 1 + Convert.ToChar(29) + Convert.ToChar(29);
                    str_VesInfo = str_VesInfo + containerno.Trim() + Convert.ToChar(29);
                    str_VesInfo = str_VesInfo + sealno.Trim() + Convert.ToChar(29) + Convert.ToChar(29);
                    str_VesInfo = str_VesInfo + str_jobtype.Trim() + Convert.ToChar(29);
                    str_VesInfo = str_VesInfo + noofpkgs.Trim() + Convert.ToChar(29);
                    //str_VesInfo = str_VesInfo + (Convert.ToDouble(dtCustomEDI2.Rows[i]["grweight"]) / 1000) + "Fixed".ToString().Replace("<br/>", "") + Convert.ToChar(29);Convert.ToDouble(Convert.ToInt32(dtCustomEDI2.Rows[i]["grweight"]).ToString("#0.000"));
                    str_VesInfo = str_VesInfo + str_ContainerInfo + Convert.ToDouble(int_weight).ToString("#0.000");
                    str_VesInfo = str_VesInfo + isocode.Trim() + Convert.ToChar(29);
                    str_VesInfo = str_VesInfo + socflag.Trim() + Convert.ToChar(29) + System.Environment.NewLine;
                }
                str_VesInfo = str_VesInfo + "<END-contain>" + System.Environment.NewLine;
                str_VesInfo = str_VesInfo + "<END-manifest>";
            }
        }

        protected void btn_cedi_Click(object sender, EventArgs e)
        {
            //try
            //{
            int_branchid = Convert.ToInt32(Session["LoginBranchid"].ToString());
            int_empid = Convert.ToInt32(Session["LoginEmpId"].ToString());
            int_divisionid = Convert.ToInt32(Session["LoginDivisionId"].ToString());
            //DataAccess.HR.FrontPage HRFrontObj = new DataAccess.HR.FrontPage();
            //DataAccess.ForwardingImports.BLDetails FIBLobj = new DataAccess.ForwardingImports.BLDetails();

            //object objFSO = null;
            //objFSO = Server.CreateObject("Scripting.FileSystemObject");

            //object FullPath = null;
            //FullPath = "C:\\CustomEDI";

            //string str_fullpath = "";
            //str_fullpath = "C:\\CustomEDI";

            //if (!File.Exists(str_fullpath))
            //{
            //    System.IO.Directory.CreateDirectory(str_fullpath);
            //}
            //else
            //{

            //}

            string str_fullpath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            str_fullpath = Server.MapPath("~/CustomEDI/");

            if (Directory.Exists(str_fullpath))
            {
                //Directory.CreateDirectory(filePath);
                foreach (string file in Directory.GetFiles(str_fullpath))
                {
                    File.Delete(file);
                }
            }
            //objFSO = "";
            DataTable dt = new DataTable();
            dt = HRFrontObj.GetBranchInfo(int_branchid);
            if (dt.Rows.Count > 0)
            {
               // str_cardno = dt.Rows[0]["carrno"].ToString();

                if (!string.IsNullOrEmpty(dt.Rows[0]["carrno"].ToString()))
                {
                    str_cardno = dt.Rows[0]["carrno"].ToString();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(btn_igm, typeof(Button), "DataFound", "alertify.alert('Carrno not update in Masterbranch');", true);
                    return;
                }
            }
            int_jobno = Convert.ToInt32(txt_job.Text);
            DataTable DTJob = new DataTable();
            DataTable DTBl = new DataTable();
            int Contpkg = 0, Blpkg = 0;
            double ContWt = 0, BlWt = 0;
            DTJob = FIBLobj.GetContWtPkgCustomEdi(int_jobno, int_branchid, int_divisionid);
            if (DTJob.Rows.Count > 0)
            {
                if (DTJob.Rows[0][0].ToString() == "")
                {
                    Contpkg = 0;
                }
                else
                {
                    Contpkg = int.Parse(DTJob.Rows[0][0].ToString());
                }
                if (DTJob.Rows[0][1].ToString() == "")
                {
                    ContWt = 0;
                }
                else
                {
                    ContWt = double.Parse(DTJob.Rows[0][1].ToString());
                }
            }
            DTBl = FIBLobj.GetBLWtPkgCustomEdi(int_jobno, int_branchid, int_divisionid);
            if (DTBl.Rows.Count > 0)
            {
                //  Blpkg = int.Parse(DTBl.Rows[0][0].ToString());
                //  BlWt = double.Parse(DTBl.Rows[0][1].ToString());
                if (DTBl.Rows[0][0].ToString() == "")
                {
                    Blpkg = 0;
                }
                else
                {
                    Blpkg = Convert.ToInt32(DTBl.Rows[0][0].ToString());
                }

                if (DTBl.Rows[0][1].ToString() == "")
                {
                    BlWt = 0;
                }
                else
                {
                    BlWt = Convert.ToDouble(DTBl.Rows[0][1].ToString());
                }

            }
            if (Blpkg != Contpkg)
            {
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Check Number of Packages');", true);
                return;
            }
            if (BlWt != ContWt)
            {
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Check Weight');", true);
                return;
            }
            if (Session["LoginBranchName"].ToString().ToUpper() == "CALCUTTA")
            {
                //TW = System.IO.File.CreateText("C:\\CustomEDI\\" + int_jobno + ".IGM");
                filename = int_jobno + ".IGM";
                TW = System.IO.File.CreateText(str_fullpath + filename);
            }
            else
            {
                //   TW = System.IO.File.CreateText("C:\\CustomEDI\\" + int_jobno + ".CGM");
                filename = int_jobno + ".CGM";
                TW = System.IO.File.CreateText(str_fullpath + filename);
            }
            hf_jobno.Value = int_jobno.ToString();
            if (Session["LoginBranchName"].ToString().ToUpper() == "MUMBAI")
            {
                GetMumbaiVesselInfo();
                GetMumbaiCargoInfo();
                GetMumbaiContainerInfo();
            }
            else if (Session["LoginBranchName"].ToString().ToUpper() == "CALCUTTA")
            {
                GetKolKattaVesselInfo();
                GetKolKattaCargoInfo();
                GetKolkattaContainerInfo();
            }
            else
            {
                GetVesselInfo();
                GetCargoInfo();
                GetContainerInfo();
            }
            TW.Close();



            obj_da_log.InsLogDetail(int_empid, 118, 3, int_branchid, Convert.ToString(int_jobno));

            Response.Clear();
            Response.ContentType = ContentType;
            Response.AppendHeader("Content-Disposition", "attachment; filename=" + System.IO.Path.GetFileName(str_fullpath + filename));
            Response.WriteFile(str_fullpath + filename);
            Response.Flush();
            System.IO.File.Delete(str_fullpath + filename);
            Response.End();

            ScriptManager.RegisterStartupScript(btn_cedi, typeof(Button), "DataFound", "alertify.alert('EDI File Created for Job# " + txt_job.Text + " Has Been Created');", true);
            //Logobj.InsLogDetail(Login.logempid, 118, 3, Login.branchid, intjobno)
            //obj_da_Log.InsLogDetail(int.Parse(Session["LoginEmpId"].ToString()), 1, 4, int.Parse(Session["LoginBranchid"].ToString()), txt_job.Text + " FE-JobRegVew");
            //}
            //catch (Exception ex)
            //{
            //    string message = ex.Message.ToString();
            //    ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            //}
        }

        public void GetKolkattaContainerInfo()
        {
            int_branchid = Convert.ToInt32(Session["LoginBranchid"].ToString());
            int_empid = Convert.ToInt32(Session["LoginEmpId"].ToString());
            int_divisionid = Convert.ToInt32(Session["LoginDivisionId"].ToString());
            int_jobno = Convert.ToInt32(hf_jobno.Value);
            //DataAccess.ForwardingImports.JobInfo FIJobobj = new DataAccess.ForwardingImports.JobInfo();
            //DataAccess.ForwardingImports.BLDetails FIBLobj = new DataAccess.ForwardingImports.BLDetails();

            str_ContainerInfo = "";
            str_ContainerInfo = str_ContainerInfo + "<contain>";
            TW.WriteLine(str_ContainerInfo);
            TW.Flush();
            dtCustomEDI = FIJobobj.ShowJobDetails(int_jobno, int_branchid, int_divisionid);
            if (dtCustomEDI.Rows.Count > 0)
            {
                if (dtCustomEDI.Rows[0]["cvslcode"].ToString() != "")
                {
                    str_CVslcode = dtCustomEDI.Rows[0]["cvslcode"].ToString();
                }
                if (dtCustomEDI.Rows[0]["voyage"].ToString() != "")
                {
                    str_Voyage = dtCustomEDI.Rows[0]["voyage"].ToString();
                }
            }
            dtCustomEDI2 = FIBLobj.GetBLContDtJobno(int_jobno, int_branchid, int_divisionid);
            if (dtCustomEDI2.Rows.Count > 0)
            {
                for (int i = 0; i < dtCustomEDI2.Rows.Count; i++)
                {
                    str_ContainerInfo = "";
                    str_ContainerInfo = "V".Trim() + Convert.ToChar(29);

                    str_ContainerInfo = str_ContainerInfo + "INCCU1";
                    str_ContainerInfo = str_ContainerInfo + Convert.ToChar(29);
                    str_ContainerInfo = str_ContainerInfo + str_imocode;
                    str_ContainerInfo = str_ContainerInfo + Convert.ToChar(29);
                    str_ContainerInfo = str_ContainerInfo + str_CVslcode;
                    str_ContainerInfo = str_ContainerInfo + Convert.ToChar(29);
                    str_ContainerInfo = str_ContainerInfo + str_Voyage;
                    str_ContainerInfo = str_ContainerInfo + Convert.ToChar(29);
                    str_ContainerInfo = str_ContainerInfo + Convert.ToChar(29);
                    str_ContainerInfo = str_ContainerInfo + Convert.ToChar(29);

                    str_ContainerInfo = str_ContainerInfo + dtCustomEDI2.Rows[i]["linenumber"].ToString().Trim().Replace("<br/>", "");
                    str_ContainerInfo = str_ContainerInfo + Convert.ToChar(29);
                    str_ContainerInfo = str_ContainerInfo + dtCustomEDI2.Rows[i]["sublineno"].ToString().Trim().Replace("<br/>", "");
                    str_ContainerInfo = str_ContainerInfo + Convert.ToChar(29);
                    str_ContainerInfo = str_ContainerInfo + dtCustomEDI2.Rows[i]["containerno"].ToString().Trim().Replace("<br/>", "");
                    str_ContainerInfo = str_ContainerInfo + Convert.ToChar(29);
                    str_ContainerInfo = str_ContainerInfo + dtCustomEDI2.Rows[i]["sealno"].ToString().Trim().Replace("<br/>", "");
                    str_ContainerInfo = str_ContainerInfo + Convert.ToChar(29);
                    str_ContainerInfo = str_ContainerInfo + Convert.ToChar(29);

                    str_ContainerInfo = str_ContainerInfo + "LCL";
                    str_ContainerInfo = str_ContainerInfo + Convert.ToChar(29);
                    str_ContainerInfo = str_ContainerInfo + dtCustomEDI2.Rows[i]["noofpkgs"].ToString().Trim().Replace("<br/>", "");
                    str_ContainerInfo = str_ContainerInfo + Convert.ToChar(29);
                    //int_weight = Convert.ToDouble(dtCustomEDI2.Rows[i]["grweight"].ToString().Trim().Replace("<br/>", ""));

                    int_weight = Convert.ToDouble(Convert.ToInt32(dtCustomEDI2.Rows[i]["grweight"]).ToString("#0.000"));
                    str_ContainerInfo = str_ContainerInfo + (int_weight).ToString("#0.000");
                    str_ContainerInfo = str_ContainerInfo + Convert.ToChar(29);

                    str_ContainerInfo = str_ContainerInfo + dtCustomEDI2.Rows[i]["isocode"].ToString().Trim().Replace("<br/>", "") + Convert.ToChar(29);
                    str_ContainerInfo = str_ContainerInfo + dtCustomEDI2.Rows[i]["socflag"].ToString().Trim().Replace("<br/>", "");

                    TW.WriteLine(str_ContainerInfo);
                    TW.Flush();
                }
            }
            str_ContainerInfo = "";
            str_ContainerInfo = str_ContainerInfo + "<END-contain>";
            str_ContainerInfo = str_ContainerInfo + System.Environment.NewLine;
            str_ContainerInfo = str_ContainerInfo + "<END-manifest>";
            str_ContainerInfo = str_ContainerInfo + System.Environment.NewLine;
            str_ContainerInfo = str_ContainerInfo + "TREC";
            str_ContainerInfo = str_ContainerInfo + Convert.ToChar(29);
            str_ContainerInfo = str_ContainerInfo + "0001";
            TW.WriteLine(str_ContainerInfo);
            TW.Flush();
        }

        protected void grd_cust_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                grd_cust.PageIndex = e.NewPageIndex;
                str_Trantype = Session["StrTranType"].ToString();
              //  DataAccess.Accounts.CostingDt obj_da_cost = new DataAccess.Accounts.CostingDt();
                DataTable obj_dt_cost = new DataTable();
                int_branchid = Convert.ToInt32(Session["LoginBranchid"].ToString());
                obj_dt_cost = obj_da_cost.GridFillJobdtls(str_Trantype, int_branchid);
                if (obj_dt_cost.Rows.Count > 0)
                {
                    grd_cust.DataSource = obj_dt_cost;
                    grd_cust.DataBind();
                    grd_cust.Visible = true;
                    mdl_cust.Show();
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        protected void btn_igmrpt_Click(object sender, EventArgs e)
        {
            int_branchid = Convert.ToInt32(Session["LoginBranchid"].ToString());
            int_empid = Convert.ToInt32(Session["LoginEmpId"].ToString());
            int_divisionid = Convert.ToInt32(Session["LoginDivisionId"].ToString());
            int_jobno = Convert.ToInt32(txt_job.Text);
          //  DataAccess.ForwardingImports.BLDetails obj_da_bldet = new DataAccess.ForwardingImports.BLDetails();
            DataTable obj_dt_BLD = new DataTable();
            obj_dt_BLD = obj_da_bldet.GetBLDetailJobno(int_jobno, int_branchid, int_divisionid);

            if (obj_dt_BLD.Rows.Count > 0)
            {
                string str_sp = "";
                string str_sf = "";
                string str_RptName = "";
                string str_Script = "";
                Session["str_sfs"] = "";
                Session["str_sp"] = "";

                str_RptName = "CustomEDI.rpt";
                Session["str_sfs"] = "{FIBLDetails.jobno}=" + int_jobno + " and {FIBLDetails.bid}=" + int_branchid;
                str_sf = "{FIBLDetails.jobno}=" + int_jobno + " and {FIBLDetails.bid}=" + int_branchid;
                //str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                str_Script = "window.open('../Reportasp/CustomEDIrpt.aspx?jobno=" + int_jobno + "&bid=" + int_branchid + "&" + this.Page.ClientQueryString + "','','');";
                ScriptManager.RegisterStartupScript(btn_cedi, typeof(Button), "CustomEDI", str_Script, true);




               // ScriptManager.RegisterStartupScript(btn_igm, typeof(Button), "DataFound", "alertify.alert('EDI File Created for Job# " + int_jobno + " Has Been Created');", true);

                //        Dim report As New CrysReport;
                //        Dim sf As String;
                //        Dim SP As String = "";
                //        report.strfrmname = "CustomEDI";
                //        report.strRptName = "Reports" + "\CustomEDI.rpt" ' "REPORTS" + "\EmpDetails.rpt";
                //        sf = "{FIBLDetails.jobno}=" + intjobno + " and {FIBLDetails.bid}=" + Login.branchid;
                //        SP = "";
                
            }
            else
            {
                ScriptManager.RegisterStartupScript(btn_igm, typeof(Button), "DataFound", "alertify.alert('EDI File NOT  Created for Job# " + int_jobno + "');", true);
                return;
            }
            obj_da_log.InsLogDetail(int_empid, 118, 3, int_branchid, Convert.ToString(int_jobno));

        }

        protected void btn_ligmrpt_Click(object sender, EventArgs e)
        {
            int_branchid = Convert.ToInt32(Session["LoginBranchid"].ToString());
            int_empid = Convert.ToInt32(Session["LoginEmpId"].ToString());
            int_divisionid = Convert.ToInt32(Session["LoginDivisionId"].ToString());
            int_jobno = Convert.ToInt32(txt_job.Text);
            DataTable dtCustomEDI1 = new DataTable();
         //   DataAccess.ForwardingImports.BLDetails FIBLobj = new DataAccess.ForwardingImports.BLDetails();
            dtCustomEDI1 = FIBLobj.GetBLDetailJobno(int_jobno, int_branchid, int_divisionid);
            if (dtCustomEDI1.Rows.Count > 0)
            {
                string str_sp = "";
                string str_sf = "";
                string str_RptName = "";
                string str_Script = "";
                Session["str_sfs"] = "";
                Session["str_sp"] = "";

                str_RptName = "CustomEDI.rpt";
                Session["str_sfs"] = "{FIBLDetails.jobno}=" + int_jobno + " and {FIBLDetails.bid}=" + int_branchid;
                str_sf = "{FIBLDetails.jobno}=" + int_jobno + " and {FIBLDetails.bid}=" + int_branchid;
                str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                ScriptManager.RegisterStartupScript(btn_cedi, typeof(Button), "CustomEDI", str_Script, true);

                //Session["str_sp"] = "";
             //   ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('EDI File Created for Job# " + int_jobno + " - " + str_CVslcode.Trim() + " V. " + str_Voyage.Trim() + " Has Been Created');", true);
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('EDI File Not Created for Job# " + int_jobno + "');", true);
            }
            obj_da_log.InsLogDetail(int_empid, 118, 3, int_branchid, Convert.ToString(int_jobno));
        }

        protected void btn_cedirpt_Click(object sender, EventArgs e)
        {
            int_branchid = Convert.ToInt32(Session["LoginBranchid"].ToString());
            int_empid = Convert.ToInt32(Session["LoginEmpId"].ToString());
            int_divisionid = Convert.ToInt32(Session["LoginDivisionId"].ToString());

          //  DataAccess.ForwardingImports.BLDetails FIBLobj = new DataAccess.ForwardingImports.BLDetails();
            int_jobno = Convert.ToInt32(txt_job.Text);

            dtCustomEDI1 = FIBLobj.GetBLDetailJobno(int_jobno, int_branchid, int_divisionid);
            if (dtCustomEDI1.Rows.Count > 0)
            {
                string str_sp = "";
                string str_sf = "";
                string str_RptName = "";
                string str_Script = "";
                Session["str_sfs"] = "";
                Session["str_sp"] = "";

                str_RptName = "CustomEDI.rpt";
                Session["str_sfs"] = "{FIBLDetails.jobno}=" + int_jobno + " and {FIBLDetails.bid}=" + int_branchid;
                str_sf = "{FIBLDetails.jobno}=" + int_jobno + " and {FIBLDetails.bid}=" + int_branchid;
                str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                ScriptManager.RegisterStartupScript(btn_cedi, typeof(Button), "CustomEDI", str_Script, true);

                //ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('EDI File Created for Job# " + int_jobno + " - " + str_CVslcode.Trim() + " V. " + str_Voyage.Trim() + " Has Been Created');", true);
                // ScriptManager.RegisterStartupScript(btn_cedi, typeof(Button), "CustomEDI", "alertify.alert('EDI File Created for Job# " + int_jobno + " - " + str_CVslcode.Trim() + " V. " + str_Voyage.Trim() + " Has Been Created');", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(btn_igm, typeof(Button), "DataFound", "alertify.alert('EDI File NOT  Created for Job# " + int_jobno + "');", true);
                return;
            }
            obj_da_log.InsLogDetail(int_empid, 118, 3, int_branchid, Convert.ToString(int_jobno));
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


        public string RemoveSpecialChars(string str)
        {
            // Create  a string array and add the special characters you want to remove
            string[] chars = new string[] {  "-", ",", ".", "/", "!", "@", "#", "$", "%", "^", "&", "*", "'", "\"", ";", "_", "(", ")", ":", "|", "[", "]" };
            //Iterate the number of times based on the String array length.
            for (int i = 0; i < chars.Length; i++)
            {
                if (str.Contains(chars[i]))
                {
                    str = str.Replace(chars[i], " ");
                }
            }
            return str;
        }
        protected void loadgridlog()
        {
            GridViewlog.Visible = true;
            Panel1.Visible = true;
            DataTable obj_dtlogdetails = new DataTable();

            obj_dtlogdetails = obj_da_log.InsTempGrpLogdtlsGet(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), 118, "Job", txt_job.Text, txt_job.Text, Session["StrTranType"].ToString());

            if (txt_job.Text != "")
            {
                JobInput.Text = txt_job.Text;
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