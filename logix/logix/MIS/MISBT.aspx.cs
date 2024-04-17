using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.Services;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html;
using iTextSharp.text.html.simpleparser;
using System.Web.UI.DataVisualization.Charting;
using System.Globalization;

namespace logix.MIS
{
    public partial class MISBT : System.Web.UI.Page
    {
        DataAccess.Masters.MasterCustomer customerobj = new DataAccess.Masters.MasterCustomer();
        DataAccess.Masters.MasterEmployee employeeobj = new DataAccess.Masters.MasterEmployee();
        DataAccess.CostingTemp costtempobj = new DataAccess.CostingTemp();
        DataAccess.LogDetails Logobj = new DataAccess.LogDetails();
        DataAccess.Masters.MasterPort Portobj = new DataAccess.Masters.MasterPort();
        DataAccess.MIS misobj = new DataAccess.MIS();
        public DataTable DtInv, DtInv1, DtPA, DtBL, DtJob, DtCT, DtPABL, Dtaddr, dtrev, dtNVF;
        double inamt, examt, reamt,blamount, mblamount, totalcbm, blcbm, volume, mblexpense, blexpense, jobchargewt, blchargewt, mblDebit, blDebit, mblCredit, blCredit ;
        string strname, strloc, StrTranType="", dbName, blno, strHTML, sendqry, filename;
        int loguserid, branchid, j, jobtype, totaltues, bltues, jobno, cont20, cont40, salesperson, shipper, consignee, notify, agent, mlo, pol, pod, RC, intcustid, empid,back=0;
        int intDivID, intBranchID, vouyear,i;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["LoginUserName"] == null || Session["LoginEmpId"] == null || Session["LoginDivisionId"] == null || Session["LoginBranchid"] == null)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alertify.alert('Session TimeOut');window.open('"+ Session["Site"].ToString() + "/','_top');", true);
            }
            else if (Session["StrTranType"] == null)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alertify.alert('Session TimeOut');window.open('"+ Session["Site"].ToString() + "/FormMain.aspx','_top');", true);
            }
            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(btn_back);
            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(btn_export);
            StrTranType = Session["StrTranType"].ToString();
            intDivID = Convert.ToInt32(Session["LoginDivisionId"].ToString());
            intBranchID = Convert.ToInt32(Session["LoginBranchid"].ToString());
            empid = Convert.ToInt32(Session["LoginEmpId"].ToString());
            if(!IsPostBack)
            {
                txt_from.Text = Utility.fn_ConvertDate(Logobj.GetDate().ToShortDateString());
                txt_to.Text = txt_from.Text;
                if (Logobj.GetDate().Month < 4)
                {
                    vouyear = Convert.ToInt32( (Logobj.GetDate().Year - 1).ToString());
                }
                else
                {
                    vouyear = Convert.ToInt32( Logobj.GetDate().Year.ToString());
                }
                dbName = "iFCAT" + intBranchID.ToString();
                if(StrTranType == "CH")
                {
                    rd_sales.Enabled = false;
                    rd_nomination.Enabled = false;
                    rd_freehand.Enabled = false;
                    rd_agent.Enabled = false;
                    rd_retention.Enabled = false;
                }
                if(StrTranType == "FI")
                {
                    rd_frwdwise.Enabled = true;
                    rd_doreg.Enabled = true;
                    rd_revenue.Enabled = true;
                }
                else
                {
                    rd_frwdwise.Enabled = false;
                    rd_doreg.Enabled = false;
                    rd_revenue.Enabled = false;
                }
                if(StrTranType == "BT")
                {
                    rd_sales.Enabled = false; rd_nomination.Enabled = false; rd_freehand.Enabled = false; rd_agent.Enabled = false;
                    rd_noVSF.Enabled = false; rd_shipper.Enabled = false; rd_consignee.Enabled = false; rd_pol.Enabled = false;
                    rd_pod.Enabled = false; rd_frwdwise.Enabled = false; rd_shipment.Enabled = false; rd_top50ship.Enabled = false;
                    rd_revenue.Enabled = false; rd_retention.Enabled = false;
                }
                if (StrTranType == "AC")
                {
                    rd_lossJob.Enabled = true;
                }
                else
                {
                    rd_lossJob.Enabled = true;
                }
            }
        }

        protected void Check_checkBox()
        {
            
        }

        [WebMethod]

        public static List<string> GetCustomers(string prefix, string FType)
        {
            List<string> customers = new List<string>();
            DataTable obj_dt = new DataTable();

            if (FType == "Name")
            {
                DataAccess.Masters.MasterEmployee da_obj_Employee = new DataAccess.Masters.MasterEmployee();
                obj_dt = da_obj_Employee.GetLikeEmployee(prefix.ToUpper());
                HttpContext.Current.Session["DataTable"] = obj_dt;
                customers = Utility.Fn_DatatableToList(obj_dt, "empname", "employeeid");
            }
            else if (FType == "Port")
            {
                DataAccess.Masters.MasterPort da_obj_Port = new DataAccess.Masters.MasterPort();
                obj_dt = da_obj_Port.GetLikePort(prefix.ToUpper());
                HttpContext.Current.Session["DataTable"] = obj_dt;
                customers = Utility.Fn_DatatableToList(obj_dt, "portname", "portid");
            }
            else if (FType == "Customer")
            {
                DataAccess.Masters.MasterCustomer da_obj_Customer = new DataAccess.Masters.MasterCustomer();
                obj_dt = da_obj_Customer.GetLikeCustomer(prefix.ToUpper(), "C");
                HttpContext.Current.Session["DataTable"] = obj_dt;
                customers = Utility.Fn_TableToList(obj_dt, "customer", "customerid");
            }
            else if (FType == "Agent")
            {
                DataAccess.Masters.MasterCustomer da_obj_Customer = new DataAccess.Masters.MasterCustomer();
                obj_dt = da_obj_Customer.GetLikeCustomer(prefix.ToUpper(), "P");
                HttpContext.Current.Session["DataTable"] = obj_dt;
                customers = Utility.Fn_TableToList(obj_dt, "customer", "customerid");
            }
            return customers;
        }

        protected void btn_print_Click(object sender, EventArgs e)
        {
            if (rd_agent.Checked == false && rd_canaudit.Checked == false && rd_canauditAI.Checked == false && rd_consignee.Checked == false && rd_doreg.Checked == false
                && rd_freehand.Checked == false && rd_frwdwise.Checked == false && rd_jobwise.Checked == false && rd_lossJob.Checked == false && rd_mis.Checked == false
                && rd_nomination.Checked == false && rd_noVSF.Checked == false && rd_oppprofit.Checked == false && rd_pod.Checked == false && rd_pol.Checked == false
                && rd_regaudit.Checked == false && rd_retention.Checked == false && rd_revenue.Checked == false && rd_sales.Checked == false && rd_shipment.Checked == false
                && rd_shipper.Checked == false && rd_top50ship.Checked == false && rd_yearmis.Checked == false)
            {
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Select Any One Option');", true);
                return;
            }
            string str_sp = "", bus = "", str_sp1 = "";
            string str_sf = "", str_sf1 = "";
            string str_RptName = "", str_RptName1 = "";
            string str_Script = "";
            Session["str_sfs"] = "";
            Session["str_sp"] = "";
            int intport=0;
            DateTime dtfrom = Convert.ToDateTime(Utility.fn_ConvertDate(txt_from.Text.ToString()));
            DateTime dtto = Convert.ToDateTime(Utility.fn_ConvertDate(txt_to.Text.ToString()));
            if(StrTranType == "")
            {
                StrTranType = "AC";
            }
            if(StrTranType == "FE")
            {
                str_sp = "Title=Ocean Exports Shipment Details from  " + txt_from.Text + "  to  " + txt_to.Text;
            }
            else if (StrTranType == "FI")
            {
                str_sp = "Title=Ocean Imports Shipment Details from  " + txt_from.Text + "  to  " + txt_to.Text;
            }
            else if (StrTranType == "AE")
            {
                str_sp = "Title=Air Exports Shipment Details from  " + txt_from.Text + "  to  " + txt_to.Text;
            }
            else if (StrTranType == "AI")
            {
                str_sp = "Title=Air Imports Shipment Details from  " + txt_from.Text + "  to  " + txt_to.Text;
            }
            
            if(StrTranType == "FE" || StrTranType == "FI" || StrTranType == "AE" || StrTranType == "AI")
            {
                if(rd_shipment.Checked == true)
                {
                    str_RptName = "ShipmentDetailsTemp.rpt";
                    Session["str_sfs"] = "{CostingDetails.closeddate}>=date('" + dtfrom.Year + "," + dtfrom.Month + "," + dtfrom.Day + "') and {CostingDetails.closeddate}<=date('" + dtto.Year + "," + dtto.Month + "," + dtto.Day + "') and {CostingDetails.trantype}='" + StrTranType + "' and {CostingDetails.branchid}=" + intBranchID;
                    str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                    ScriptManager.RegisterStartupScript(btn_print, typeof(Button), "logix", str_Script, true);
                    Session["str_sp"] = str_sp;
                }else if(rd_frwdwise.Checked == true)
                {
                    str_RptName = "AllforwarderTemp.rpt";
                    Session["str_sfs"] = "{CostingDetails.closeddate}>=date('" + dtfrom.Year + "," + dtfrom.Month + "," + dtfrom.Day + "') and {CostingDetails.closeddate}<=date('" + dtto.Year + "," + dtto.Month + "," + dtto.Day + "') and {CostingDetails.trantype}='" + StrTranType + "' and {CostingDetails.branchid}=" + intBranchID;
                    str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                    ScriptManager.RegisterStartupScript(btn_print, typeof(Button), "logix", str_Script, true);
                    Session["str_sp"] = str_sp;
                }
                else if (rd_doreg.Checked == true)
                {
                    str_RptName = "FIDORegister.rpt";
                    Session["str_sfs"] = "{FIBLDetails.bid}=" + intBranchID + " and {FIBLDetails.doissuedon}>=date('" + dtfrom.Year + "," + dtfrom.Month + "," + dtfrom.Day + "') and {FIBLDetails.doissuedon}<=date('" + dtto.Year + "," + dtto.Month + "," + dtto.Day + "')";
                    str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                    ScriptManager.RegisterStartupScript(btn_print, typeof(Button), "logix", str_Script, true);
                    Session["str_sp"] = str_sp;
                }else if(rd_noVSF.Checked == true)
                {
                    Session["From"] = txt_from.Text;
                    Session["To"] = txt_to.Text;
                    this.popuprate.Show();
                }else if(rd_pol.Checked == true)
                {
                    str_RptName = "MISPoLWise.rpt";
                    if(txt_name.Text =="")
                    {
                        Session["str_sfs"] = "{CostingDetails.closeddate}>=date('" + dtfrom.Year + "," + dtfrom.Month + "," + dtfrom.Day + "') and {CostingDetails.closeddate}<=date('" + dtto.Year + "," + dtto.Month + "," + dtto.Day + "') and {CostingDetails.trantype}='" + StrTranType + "' and {CostingDetails.branchid}=" + intBranchID;
                        
                    }
                    else
                    {
                        intport = Portobj.GetNPortid(txt_name.Text);
                        Session["str_sfs"] = "{CostingDetails.closeddate}>=date('" + dtfrom.Year + "," + dtfrom.Month + "," + dtfrom.Day + "') and {CostingDetails.closeddate}<=date('" + dtto.Year + "," + dtto.Month + "," + dtto.Day + "') and {CostingDetails.trantype}='" + StrTranType + "' and {CostingDetails.branchid}=" + intBranchID + " and {CostingDetails.pol}=" + intport;
                    }
                    str_sp = "Title=Shipment Details - Port Of Loading for the Period from " + txt_from.Text + " To " + txt_to.Text;
                    str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                    ScriptManager.RegisterStartupScript(btn_print, typeof(Button), "logix", str_Script, true);
                    Session["str_sp"] = str_sp;
                }
                else if (rd_pod.Checked == true)
                {
                    str_RptName = "MISPoDWise.rpt";
                    if (txt_name.Text == "")
                    {
                        Session["str_sfs"] = "{CostingDetails.closeddate}>=date('" + dtfrom.Year + "," + dtfrom.Month + "," + dtfrom.Day + "') and {CostingDetails.closeddate}<=date('" + dtto.Year + "," + dtto.Month + "," + dtto.Day + "') and {CostingDetails.trantype}='" + StrTranType + "' and {CostingDetails.branchid}=" + intBranchID;
                    }
                    else
                    {
                        intport = Portobj.GetNPortid(txt_name.Text);
                        Session["str_sfs"] = "{CostingDetails.closeddate}>=date('" + dtfrom.Year + "," + dtfrom.Month + "," + dtfrom.Day + "') and {CostingDetails.closeddate}<=date('" + dtto.Year + "," + dtto.Month + "," + dtto.Day + "') and {CostingDetails.trantype}='" + StrTranType + "' and {CostingDetails.branchid}=" + intBranchID + " and {CostingDetails.pod}=" + intport;
                    }
                    str_sp = "Title=Shipment Details - Port Of Discharging for the Period from " + txt_from.Text + " To " + txt_to.Text;
                    str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                    ScriptManager.RegisterStartupScript(btn_print, typeof(Button), "logix", str_Script, true);
                    Session["str_sp"] = str_sp;
                }else if(rd_shipper.Checked == true)
                {
                    str_RptName = "ShipperwiseTemp.rpt";
                    if (txt_name.Text == "")
                    {
                        Session["str_sfs"] = "{CostingDetails.closeddate}>=date('" + dtfrom.Year + "," + dtfrom.Month + "," + dtfrom.Day + "') and {CostingDetails.closeddate}<=date('" + dtto.Year + "," + dtto.Month + "," + dtto.Day + "') and {CostingDetails.trantype}='" + StrTranType + "' and {CostingDetails.branchid}=" + intBranchID;
                        str_sp = "Title= Shipper Wise Shipment Details from " + txt_from.Text + " To " + txt_to.Text;
                    }
                    else
                    {
                        intport = Portobj.GetNPortid(txt_name.Text);
                        Session["str_sfs"] = "{CostingDetails.closeddate}>=date('" + dtfrom.Year + "," + dtfrom.Month + "," + dtfrom.Day + "') and {CostingDetails.closeddate}<=date('" + dtto.Year + "," + dtto.Month + "," + dtto.Day + "') and {CostingDetails.trantype}='" + StrTranType + "' and {CostingDetails.branchid}=" + intBranchID + " and {CostingDetails.shipper}=" + hd_cust.Value;
                        str_sp = "Title='" + txt_name.Text + "' Shipment Details from " + txt_from.Text + " To " + txt_to.Text;
                    }
                    str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                    ScriptManager.RegisterStartupScript(btn_print, typeof(Button), "logix", str_Script, true);
                    Session["str_sp"] = str_sp;
                }
                else if (rd_consignee.Checked == true)
                {
                    str_RptName = "ConsigneewiseTemp.rpt";
                    if (txt_name.Text == "")
                    {
                        Session["str_sfs"] = "{CostingDetails.closeddate}>=date('" + dtfrom.Year + "," + dtfrom.Month + "," + dtfrom.Day + "') and {CostingDetails.closeddate}<=date('" + dtto.Year + "," + dtto.Month + "," + dtto.Day + "') and {CostingDetails.trantype}='" + StrTranType + "' and {CostingDetails.branchid}=" + intBranchID;
                        str_sp = "Title= Consignee Wise Shipment Details from " + txt_from.Text + " To " + txt_to.Text;
                    }
                    else
                    {
                        intport = Portobj.GetNPortid(txt_name.Text);
                        Session["str_sfs"] = "{CostingDetails.closeddate}>=date('" + dtfrom.Year + "," + dtfrom.Month + "," + dtfrom.Day + "') and {CostingDetails.closeddate}<=date('" + dtto.Year + "," + dtto.Month + "," + dtto.Day + "') and {CostingDetails.trantype}='" + StrTranType + "' and {CostingDetails.branchid}=" + intBranchID + " and {CostingDetails.consignee}=" + hd_cust.Value;
                        str_sp = "Title='" + txt_name.Text + "' Shipment Details from " + txt_from.Text + " To " + txt_to.Text;
                    }
                    str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                    ScriptManager.RegisterStartupScript(btn_print, typeof(Button), "logix", str_Script, true);
                    Session["str_sp"] = str_sp;
                }
                else if (rd_agent.Checked == true)
                {
                    str_RptName = "AgentwiseTemp.rpt";
                    if (txt_name.Text == "")
                    {
                        Session["str_sfs"] = "{CostingDetails.closeddate}>=date('" + dtfrom.Year + "," + dtfrom.Month + "," + dtfrom.Day + "') and {CostingDetails.closeddate}<=date('" + dtto.Year + "," + dtto.Month + "," + dtto.Day + "') and {CostingDetails.trantype}='" + StrTranType + "' and {CostingDetails.branchid}=" + intBranchID;
                        str_sp = "Title= Agent Wise Shipment Details from " + txt_from.Text + " To " + txt_to.Text;
                    }
                    else
                    {
                        intport = Portobj.GetNPortid(txt_name.Text);
                        Session["str_sfs"] = "{CostingDetails.closeddate}>=date('" + dtfrom.Year + "," + dtfrom.Month + "," + dtfrom.Day + "') and {CostingDetails.closeddate}<=date('" + dtto.Year + "," + dtto.Month + "," + dtto.Day + "') and {CostingDetails.trantype}='" + StrTranType + "' and {CostingDetails.branchid}=" + intBranchID + " and {CostingDetails.agent}=" + hd_cust.Value;
                        str_sp = "Title='" + txt_name.Text + "' Shipment Details from " + txt_from.Text + " To " + txt_to.Text;
                    }
                    str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                    ScriptManager.RegisterStartupScript(btn_print, typeof(Button), "logix", str_Script, true);
                    Session["str_sp"] = str_sp;
                }
                else if (rd_sales.Checked == true)
                {
                    str_RptName = "SalesPersonWiseTemp.rpt";
                    if (txt_name.Text == "")
                    {
                        Session["str_sfs"] = "{CostingDetails.closeddate}>=date('" + dtfrom.Year + "," + dtfrom.Month + "," + dtfrom.Day + "') and {CostingDetails.closeddate}<=date('" + dtto.Year + "," + dtto.Month + "," + dtto.Day + "') and {CostingDetails.trantype}='" + StrTranType + "' and {CostingDetails.business}='" + "O" + "' and {CostingDetails.salesperson}<>0" + " and {CostingDetails.branchid}=" + intBranchID;
                        str_sp = "Title= SalesPesons Wise Shipment Details from " + txt_from.Text + " To " + txt_to.Text;
                    }
                    else
                    {
                        intport = Portobj.GetNPortid(txt_name.Text);
                        Session["str_sfs"] = "{CostingDetails.closeddate}>=date('" + dtfrom.Year + "," + dtfrom.Month + "," + dtfrom.Day + "') and {CostingDetails.closeddate}<=date('" + dtto.Year + "," + dtto.Month + "," + dtto.Day + "') and {CostingDetails.trantype}='" + StrTranType + "' and {CostingDetails.business}='" + "O" + "' and {CostingDetails.branchid}=" + intBranchID + " and {CostingDetails.salesperson}=" + empid;
                        str_sp = "Title='" + txt_name.Text + "' Revenue from " + txt_from.Text + " To " + txt_to.Text;
                    }
                    str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                    ScriptManager.RegisterStartupScript(btn_print, typeof(Button), "logix", str_Script, true);
                    Session["str_sp"] = str_sp;
                }else if(rd_oppprofit.Checked == true)
                {
                    str_RptName = "OperatingProfit.rpt";
                    Session["str_sfs"] = "{CostingDetails.closeddate}>=date('" + dtfrom.Year + "," + dtfrom.Month + "," + dtfrom.Day + "') and {CostingDetails.closeddate}<=date('" + dtto.Year + "," + dtto.Month + "," + dtto.Day + "') and {CostingDetails.trantype}='" + StrTranType + "' and {CostingDetails.branchid}=" + intBranchID;
                    str_sp = "Header=Operating Profit Details from" + txt_from.Text + " To " + txt_to.Text;
                    str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                    ScriptManager.RegisterStartupScript(btn_print, typeof(Button), "logix", str_Script, true);
                    Session["str_sp"] = str_sp;
                }else if(rd_jobwise.Checked == true)
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Ifcat Touch", "alertify.alert('Please use Shipment Details/Operating Profit for Weekly/Monthly MIS.Do not submit Jobwise Costing as MIS report.For further classification please contact to Mr.Padmanabhan');", true);
                    str_RptName = "JobWiseCosting.rpt";
                    Session["str_sfs"] = "{JobDetails.closeddate}>=date('" + dtfrom.Year + "," + dtfrom.Month + "," + dtfrom.Day + "') and {JobDetails.closeddate}<=date('" + dtto.Year + "," + dtto.Month + "," + dtto.Day + "') and {JobDetails.trantype}='" + StrTranType + "' and {JobDetails.branchid}=" + intBranchID;
                    str_sp = "Header=Jobwise Costing Details from" + txt_from.Text + " To " + txt_to.Text;
                    str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                    ScriptManager.RegisterStartupScript(btn_print, typeof(Button), "logix", str_Script, true);
                    Session["str_sp"] = str_sp;
                }else if(rd_lossJob.Checked == true)
                {
                    str_RptName = "JobWiseCosting.rpt";
                    Session["str_sfs"] = "{JobDetails.closeddate}>=date('" + dtfrom.Year + "," + dtfrom.Month + "," + dtfrom.Day + "') and {JobDetails.closeddate}<=date('" + dtto.Year + "," + dtto.Month + "," + dtto.Day + "') and {JobDetails.trantype}='" + StrTranType + "'  and {JobDetails.retention}<0 and {JobDetails.branchid}=" + intBranchID;
                    str_sp = "Header=Loss Jobwise Costing Details from" + txt_from.Text + " To " + txt_to.Text;
                    str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                    ScriptManager.RegisterStartupScript(btn_print, typeof(Button), "logix", str_Script, true);
                    Session["str_sp"] = str_sp;
                }else if(rd_nomination.Checked ==  true)
                {
                    if(StrTranType =="FE" || StrTranType =="AE")
                    {
                        bus = "A";
                    }else{
                        bus = "O";
                    }
                    str_RptName = "ShipmentDetailsTemp.rpt";
                    Session["str_sfs"] = "{CostingDetails.closeddate}>=date('" + dtfrom.Year + "," + dtfrom.Month + "," + dtfrom.Day + "') and {CostingDetails.closeddate}<=date('" + dtto.Year + "," + dtto.Month + "," + dtto.Day + "') and {CostingDetails.trantype}='" + StrTranType + "' and {CostingDetails.branchid}=" + intBranchID + " and CostingDetails.nomination}='N'";
                    str_sp = "Header=Nomination Shipment Details from" + txt_from.Text + " To " + txt_to.Text;
                    Session["str_sfs1"] = "{CostingDetails.closeddate}>=date('" + dtfrom.Year + "," + dtfrom.Month + "," + dtfrom.Day + "') and {CostingDetails.closeddate}<=date('" + dtto.Year + "," + dtto.Month + "," + dtto.Day + "') and {CostingDetails.trantype}='" + StrTranType + "' and {CostingDetails.branchid}=" + intBranchID ;
                    Session["str_sp"] = str_sp;
                    Session["str_sp1"] = str_sp;
                    str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');window.open('../Tools/ReportView.aspx?SFormula=" + str_sf1 + "&Parameter=" + str_sp1 + "&RFName=" + str_RptName1 + "&" + this.Page.ClientQueryString + "','','');";
                    ScriptManager.RegisterStartupScript(btn_print, typeof(Button), "logix", str_Script, true);
                   
                }
                else if (rd_freehand.Checked == true)
                {
                    if (StrTranType == "FE" || StrTranType == "AE")
                    {
                        bus = "A";
                    }
                    else
                    {
                        bus = "O";
                    }
                    str_RptName = "ShipmentDetailsTemp.rpt";
                    Session["str_sfs"] = "{CostingDetails.closeddate}>=date('" + dtfrom.Year + "," + dtfrom.Month + "," + dtfrom.Day + "') and {CostingDetails.closeddate}<=date('" + dtto.Year + "," + dtto.Month + "," + dtto.Day + "') and {CostingDetails.trantype}='" + StrTranType + "' and {CostingDetails.branchid}=" + intBranchID + " and CostingDetails.nomination}='F'";
                    str_sp = "Title=Free-Hand Shipment Details from" + txt_from.Text + " To " + txt_to.Text;
                    str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                    ScriptManager.RegisterStartupScript(btn_print, typeof(Button), "logix", str_Script, true);
                    Session["str_sp"] = str_sp;
                    
                }
            }else if(StrTranType == "AC" )
            {
                if (rd_shipment.Checked == true)
                {
                    str_RptName = "ShipmentDetailsTemp.rpt";
                    Session["str_sfs"] = "{CostingDetails.closeddate}>=date('" + dtfrom.Year + "," + dtfrom.Month + "," + dtfrom.Day + "') and {CostingDetails.closeddate}<=date('" + dtto.Year + "," + dtto.Month + "," + dtto.Day + "') and {CostingDetails.branchid}=" + intBranchID;
                    Session["str_sfs1"] = "{CostingDetails.closeddate}>=date('" + dtfrom.Year + "," + dtfrom.Month + "," + dtfrom.Day + "') and {CostingDetails.closeddate}<=date('" + dtto.Year + "," + dtto.Month + "," + dtto.Day + "') and {CostingDetails.branchid}=" + intBranchID + "and {CostingDetails.trantype}<>'" + "AD" + "'";
                    str_sp = "Title=Shipment Details from" + txt_from.Text + " To " + txt_to.Text;
                    Session["str_sp"] = str_sp;
                    Session["str_sp1"] = str_sp;
                    str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');window.open('../Tools/ReportView.aspx?SFormula=" + str_sf1 + "&Parameter=" + str_sp1 + "&RFName=" + str_RptName1 + "&" + this.Page.ClientQueryString + "','','');";
                    ScriptManager.RegisterStartupScript(btn_print, typeof(Button), "logix", str_Script, true);

                }
                else if (rd_noVSF.Checked == true)
                {
                    Session["From"] = txt_from.Text;
                    Session["To"] = txt_to.Text;
                    this.popuprate.Show();
                }
                else if (rd_lossJob.Checked == true)
                {
                    str_RptName = "JobWiseCosting.rpt";
                    Session["str_sfs"] = "{JobDetails.closeddate}>=date('" + dtfrom.Year + "," + dtfrom.Month + "," + dtfrom.Day + "') and {JobDetails.closeddate}<=date('" + dtto.Year + "," + dtto.Month + "," + dtto.Day + "')   and {JobDetails.retention}<0 and {JobDetails.branchid}=" + intBranchID;
                    str_sp = "Header=Loss Jobwise Costing Details from" + txt_from.Text + " To " + txt_to.Text;
                    str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                    ScriptManager.RegisterStartupScript(btn_print, typeof(Button), "logix", str_Script, true);
                    Session["str_sp"] = str_sp;
                }
                else if (rd_pol.Checked == true)
                {
                    str_RptName = "MISPoLWise.rpt";
                    if (txt_name.Text == "")
                    {
                        Session["str_sfs"] = "{CostingDetails.closeddate}>=date('" + dtfrom.Year + "," + dtfrom.Month + "," + dtfrom.Day + "') and {CostingDetails.closeddate}<=date('" + dtto.Year + "," + dtto.Month + "," + dtto.Day + "')  and {CostingDetails.branchid}=" + intBranchID;
                    }
                    else
                    {
                        intport = Portobj.GetNPortid(txt_name.Text);
                        Session["str_sfs"] = "{CostingDetails.closeddate}>=date('" + dtfrom.Year + "," + dtfrom.Month + "," + dtfrom.Day + "') and {CostingDetails.closeddate}<=date('" + dtto.Year + "," + dtto.Month + "," + dtto.Day + "')  and {CostingDetails.branchid}=" + intBranchID + " and {CostingDetails.pol}=" + intport;
                    }
                    str_sp = "Title=Shipment Details - Port Of Loading for the Period from " + txt_from.Text + " To " + txt_to.Text;
                    str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                    ScriptManager.RegisterStartupScript(btn_print, typeof(Button), "logix", str_Script, true);
                    Session["str_sp"] = str_sp;
                }
                else if (rd_pod.Checked == true)
                {
                    str_RptName = "MISPoDWise.rpt";
                    if (txt_name.Text == "")
                    {
                        Session["str_sfs"] = "{CostingDetails.closeddate}>=date('" + dtfrom.Year + "," + dtfrom.Month + "," + dtfrom.Day + "') and {CostingDetails.closeddate}<=date('" + dtto.Year + "," + dtto.Month + "," + dtto.Day + "')  and {CostingDetails.branchid}=" + intBranchID;
                    }
                    else
                    {
                        intport = Portobj.GetNPortid(txt_name.Text);
                        Session["str_sfs"] = "{CostingDetails.closeddate}>=date('" + dtfrom.Year + "," + dtfrom.Month + "," + dtfrom.Day + "') and {CostingDetails.closeddate}<=date('" + dtto.Year + "," + dtto.Month + "," + dtto.Day + "')  and {CostingDetails.branchid}=" + intBranchID + " and {CostingDetails.pod}=" + intport;
                    }
                    str_sp = "Title=Shipment Details - Port Of Discharging for the Period from " + txt_from.Text + " To " + txt_to.Text;
                    str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                    ScriptManager.RegisterStartupScript(btn_print, typeof(Button), "logix", str_Script, true);
                    Session["str_sp"] = str_sp;
                }
                else if (rd_shipper.Checked == true)
                {
                    str_RptName = "ShipperwiseTemp.rpt";
                    if (txt_name.Text == "")
                    {
                        Session["str_sfs"] = "{CostingDetails.closeddate}>=date('" + dtfrom.Year + "," + dtfrom.Month + "," + dtfrom.Day + "') and {CostingDetails.closeddate}<=date('" + dtto.Year + "," + dtto.Month + "," + dtto.Day + "')  and {CostingDetails.branchid}=" + intBranchID;
                        str_sp = "Title=" + txt_from.Text + " To " + txt_to.Text;
                    }
                    else
                    {
                        Session["str_sfs"] = "{CostingDetails.closeddate}>=date('" + dtfrom.Year + "," + dtfrom.Month + "," + dtfrom.Day + "') and {CostingDetails.closeddate}<=date('" + dtto.Year + "," + dtto.Month + "," + dtto.Day + "')  and {CostingDetails.branchid}=" + intBranchID + " and {CostingDetails.shipper}=" + hd_cust.Value;
                        str_sp = "Title='" + txt_name.Text + "' Shipment Details from " + txt_from.Text + " To " + txt_to.Text;
                    }
                    str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                    ScriptManager.RegisterStartupScript(btn_print, typeof(Button), "logix", str_Script, true);
                    Session["str_sp"] = str_sp;
                }
                else if (rd_consignee.Checked == true)
                {
                    str_RptName = "ConsigneewiseTemp.rpt";
                    if (txt_name.Text == "")
                    {
                        Session["str_sfs"] = "{CostingDetails.closeddate}>=date('" + dtfrom.Year + "," + dtfrom.Month + "," + dtfrom.Day + "') and {CostingDetails.closeddate}<=date('" + dtto.Year + "," + dtto.Month + "," + dtto.Day + "') and {CostingDetails.branchid}=" + intBranchID;
                        str_sp = "Title= Consignee Wise Shipment Details from " + txt_from.Text + " To " + txt_to.Text;
                    }
                    else
                    {
                        Session["str_sfs"] = "{CostingDetails.closeddate}>=date('" + dtfrom.Year + "," + dtfrom.Month + "," + dtfrom.Day + "') and {CostingDetails.closeddate}<=date('" + dtto.Year + "," + dtto.Month + "," + dtto.Day + "') and {CostingDetails.branchid}=" + intBranchID + " and {CostingDetails.consignee}=" + hd_cust.Value;
                        str_sp = "Title='" + txt_name.Text + "' Shipment Details from " + txt_from.Text + " To " + txt_to.Text;
                    }
                    str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                    ScriptManager.RegisterStartupScript(btn_print, typeof(Button), "logix", str_Script, true);
                    Session["str_sp"] = str_sp;
                }
                else if (rd_agent.Checked == true)
                {
                    str_RptName = "AgentwiseTemp.rpt";
                    if (txt_name.Text == "")
                    {
                        Session["str_sfs"] = "{CostingDetails.closeddate}>=date('" + dtfrom.Year + "," + dtfrom.Month + "," + dtfrom.Day + "') and {CostingDetails.closeddate}<=date('" + dtto.Year + "," + dtto.Month + "," + dtto.Day + "')  and {CostingDetails.branchid}=" + intBranchID;
                        str_sp = "Title= Agent Wise Shipment Details from " + txt_from.Text + " To " + txt_to.Text;
                    }
                    else
                    {
                        intport = Portobj.GetNPortid(txt_name.Text);
                        Session["str_sfs"] = "{CostingDetails.closeddate}>=date('" + dtfrom.Year + "," + dtfrom.Month + "," + dtfrom.Day + "') and {CostingDetails.closeddate}<=date('" + dtto.Year + "," + dtto.Month + "," + dtto.Day + "') and {CostingDetails.branchid}=" + intBranchID + " and {CostingDetails.agent}=" + intport;
                        str_sp = "Title='" + txt_name.Text + "' Shipment Details from " + txt_from.Text + " To " + txt_to.Text;
                    }
                    str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                    ScriptManager.RegisterStartupScript(btn_print, typeof(Button), "logix", str_Script, true);
                    Session["str_sp"] = str_sp;
                }
                else if (rd_oppprofit.Checked == true)
                {
                    str_RptName = "OperatingProfit.rpt";
                    Session["str_sfs"] = "{CostingDetails.closeddate}>=date('" + dtfrom.Year + "," + dtfrom.Month + "," + dtfrom.Day + "') and {CostingDetails.closeddate}<=date('" + dtto.Year + "," + dtto.Month + "," + dtto.Day + "')and {CostingDetails.branchid}=" + intBranchID + " and {CostingDetails.trantype}<>'AD'";
                    str_sp = "Header=Operating Profit Details from" + txt_from.Text + " To " + txt_to.Text;
                    str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                    ScriptManager.RegisterStartupScript(btn_print, typeof(Button), "logix", str_Script, true);
                    Session["str_sp"] = str_sp;
                }
                else if (rd_jobwise.Checked == true)
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Ifcat Touch", "alertify.alert('Please use Shipment Details/Operating Profit for Weekly/Monthly MIS.Do not submit Jobwise Costing as MIS report.For further classification please contact to Mr.Padmanabhan');", true);
                    str_RptName = "JobWiseCosting.rpt";
                    Session["str_sfs"] = "{JobDetails.closeddate}>=date('" + dtfrom.Year + "," + dtfrom.Month + "," + dtfrom.Day + "') and {JobDetails.closeddate}<=date('" + dtto.Year + "," + dtto.Month + "," + dtto.Day + "') and {JobDetails.branchid}=" + intBranchID;
                    str_sp = "Header=Jobwise Costing Details from" + txt_from.Text + " To " + txt_to.Text;
                    str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                    ScriptManager.RegisterStartupScript(btn_print, typeof(Button), "logix", str_Script, true);
                    Session["str_sp"] = str_sp;
                }
                else if (rd_sales.Checked == true)
                {
                    str_RptName = "SalesPersonWiseTemp.rpt";
                    if (txt_name.Text == "")
                    {
                        Session["str_sfs"] = "{CostingDetails.closeddate}>=date('" + dtfrom.Year + "," + dtfrom.Month + "," + dtfrom.Day + "') and {CostingDetails.closeddate}<=date('" + dtto.Year + "," + dtto.Month + "," + dtto.Day + "') and {CostingDetails.business}='" + "O" + "' and {CostingDetails.salesperson}<>0" + " and {CostingDetails.salesperson} <> 0";
                        str_sp = "Title= SalesPesons Wise Shipment Details from " + txt_from.Text + " To " + txt_to.Text;
                    }
                    else
                    {
                        Session["str_sfs"] = "{CostingDetails.closeddate}>=date('" + dtfrom.Year + "," + dtfrom.Month + "," + dtfrom.Day + "') and {CostingDetails.closeddate}<=date('" + dtto.Year + "," + dtto.Month + "," + dtto.Day + "') and {CostingDetails.business}='" + "O" + "' and {CostingDetails.branchid}=" + intBranchID + " and {CostingDetails.salesperson}=" + empid;
                        str_sp = "Title='" + txt_name.Text + "' Revenue from " + txt_from.Text + " To " + txt_to.Text;
                    }
                    str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                    ScriptManager.RegisterStartupScript(btn_print, typeof(Button), "logix", str_Script, true);
                    Session["str_sp"] = str_sp;
                }
                else if (rd_nomination.Checked == true)
                {
                  
                    str_RptName = "ShipmentDetailsTemp.rpt";
                    Session["str_sfs"] = "{CostingDetails.closeddate}>=date('" + dtfrom.Year + "," + dtfrom.Month + "," + dtfrom.Day + "') and {CostingDetails.closeddate}<=date('" + dtto.Year + "," + dtto.Month + "," + dtto.Day + "') and {CostingDetails.branchid}=" + intBranchID + " and CostingDetails.nomination}='N'";
                    str_sp = "Header=Nomination Shipment Details from" + txt_from.Text + " To " + txt_to.Text;
                   
                    str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                    ScriptManager.RegisterStartupScript(btn_print, typeof(Button), "logix", str_Script, true);
                    Session["str_sp"] = str_sp;
                    
                }
                else if (rd_freehand.Checked == true)
                {
                    
                    str_RptName = "ShipmentDetailsTemp.rpt";
                    Session["str_sfs"] = "{CostingDetails.closeddate}>=date('" + dtfrom.Year + "," + dtfrom.Month + "," + dtfrom.Day + "') and {CostingDetails.closeddate}<=date('" + dtto.Year + "," + dtto.Month + "," + dtto.Day + "') and {CostingDetails.branchid}=" + intBranchID + " and CostingDetails.nomination}='F'";
                    str_sp = "Title=Free-Hand Shipment Details from" + txt_from.Text + " To " + txt_to.Text;
                    
                    str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                    ScriptManager.RegisterStartupScript(btn_print, typeof(Button), "logix", str_Script, true);
                    Session["str_sp"] = str_sp;
                }else if(rd_yearmis.Checked == true)
                {
                  int a = dtfrom.Year;
                  misobj.InsTempY2D("", Convert.ToDateTime(Utility.fn_ConvertDate(txt_from.Text)), Convert.ToDateTime(Utility.fn_ConvertDate(txt_to.Text)), int.Parse(Session["LoginEmpId"].ToString()), int.Parse(Session["LoginBranchid"].ToString()), 0);
                  misobj.InsTempY2D("", Convert.ToDateTime(Utility.fn_ConvertDate(txt_from.Text)), Convert.ToDateTime(Utility.fn_ConvertDate(txt_to.Text)), int.Parse(Session["LoginEmpId"].ToString()), int.Parse(Session["LoginBranchid"].ToString()), 0);
                  misobj.InsTempY2D("", Convert.ToDateTime(Utility.fn_ConvertDate(txt_from.Text)), Convert.ToDateTime(Utility.fn_ConvertDate(txt_to.Text)), int.Parse(Session["LoginEmpId"].ToString()), int.Parse(Session["LoginBranchid"].ToString()), 0);
                  misobj.InsTempY2D("", Convert.ToDateTime(Utility.fn_ConvertDate(txt_from.Text)), Convert.ToDateTime(Utility.fn_ConvertDate(txt_to.Text)), int.Parse(Session["LoginEmpId"].ToString()), int.Parse(Session["LoginBranchid"].ToString()), 0);
                  misobj.InsTempY2D("", Convert.ToDateTime(Utility.fn_ConvertDate(txt_from.Text)), Convert.ToDateTime(Utility.fn_ConvertDate(txt_to.Text)), int.Parse(Session["LoginEmpId"].ToString()), int.Parse(Session["LoginBranchid"].ToString()), 0);
                  misobj.InsTempY2D("", Convert.ToDateTime(Utility.fn_ConvertDate(txt_from.Text)), Convert.ToDateTime(Utility.fn_ConvertDate(txt_to.Text)), int.Parse(Session["LoginEmpId"].ToString()), int.Parse(Session["LoginBranchid"].ToString()), 0);
                   str_RptName="year2date.rpt";
                   str_sf = "{TempY2D.empid}=" + empid + " and {TempY2D.bid}=" + intBranchID;
                   str_sp = "mon=" + dtfrom.Month + " ~cid= " + "" + "~year=" + dtfrom.Year;
                   str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                   ScriptManager.RegisterStartupScript(btn_print, typeof(Button), "logix", str_Script, true);
                   Session["str_sp"] = str_sp;
                   Session["str_sfs"] = str_sf;
                }
            } else if(StrTranType == "BT")
            {
                if(rd_oppprofit.Checked == true)
                {
                    str_RptName = "OperatingProfit.rpt";
                    Session["str_sfs"] = "{CostingDetails.closeddate}>=date('" + dtfrom.Year + "," + dtfrom.Month + "," + dtfrom.Day + "') and {CostingDetails.closeddate}<=date('" + dtto.Year + "," + dtto.Month + "," + dtto.Day + "') and {CostingDetails.trantype}='" + StrTranType + "' and {CostingDetails.branchid}=" + intBranchID;
                    str_sp = "Header=Operating Profit Details from" + txt_from.Text + " To " + txt_to.Text;
                    str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                    ScriptManager.RegisterStartupScript(btn_print, typeof(Button), "logix", str_Script, true);
                    Session["str_sp"] = str_sp;
                }
                else if (rd_jobwise.Checked == true)
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Ifcat Touch", "alertify.alert('Please use Shipment Details/Operating Profit for Weekly/Monthly MIS.Do not submit Jobwise Costing as MIS report.For further classification please contact to Mr.Padmanabhan');", true);
                    str_RptName = "JobWiseCosting.rpt";
                    Session["str_sfs"] = "{JobDetails.closeddate}>=date('" + dtfrom.Year + "," + dtfrom.Month + "," + dtfrom.Day + "') and {JobDetails.closeddate}<=date('" + dtto.Year + "," + dtto.Month + "," + dtto.Day + "') and {JobDetails.trantype}='" + StrTranType + "' and {JobDetails.branchid}=" + intBranchID;
                    str_sp = "Header=Jobwise Costing Details from" + txt_from.Text + " To " + txt_to.Text;
                    str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                    ScriptManager.RegisterStartupScript(btn_print, typeof(Button), "logix", str_Script, true);
                    Session["str_sp"] = str_sp;
                }
                else if (rd_lossJob.Checked == true)
                {
                    str_RptName = "JobWiseCosting.rpt";
                    Session["str_sfs"] = "{JobDetails.closeddate}>=date('" + dtfrom.Year + "," + dtfrom.Month + "," + dtfrom.Day + "') and {JobDetails.closeddate}<=date('" + dtto.Year + "," + dtto.Month + "," + dtto.Day + "') and {JobDetails.trantype}='" + StrTranType + "'  and {JobDetails.retention}<0 and {JobDetails.branchid}=" + intBranchID;
                    str_sp = "Header=Loss Jobwise Costing Details from" + txt_from.Text + " To " + txt_to.Text;
                    str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                    ScriptManager.RegisterStartupScript(btn_print, typeof(Button), "logix", str_Script, true);
                    Session["str_sp"] = str_sp;
                }
            }else if(StrTranType == "CH")
            {
                if (rd_shipment.Checked == true)
                {
                    str_RptName = "CHShipmentDetailsTemp.rpt";
                    Session["str_sfs"] = "{CostingDetails.closeddate}>=date('" + dtfrom.Year + "," + dtfrom.Month + "," + dtfrom.Day + "') and {CostingDetails.closeddate}<=date('" + dtto.Year + "," + dtto.Month + "," + dtto.Day + "') and {CostingDetails.trantype}='" + StrTranType + "' and {CostingDetails.branchid}=" + intBranchID;
                    str_sp = "Title= Custom House Shipment Details from " + txt_from.Text + " To " + txt_to.Text;
                    str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                    ScriptManager.RegisterStartupScript(btn_print, typeof(Button), "logix", str_Script, true);
                    Session["str_sp"] = str_sp;
                }
                else if (rd_oppprofit.Checked == true)
                {
                    str_RptName = "OperatingProfit.rpt";
                    Session["str_sfs"] = "{CostingDetails.closeddate}>=date('" + dtfrom.Year + "," + dtfrom.Month + "," + dtfrom.Day + "') and {CostingDetails.closeddate}<=date('" + dtto.Year + "," + dtto.Month + "," + dtto.Day + "') and {CostingDetails.trantype}='" + StrTranType + "' and {CostingDetails.branchid}=" + intBranchID;
                    str_sp = "Header=Operating Profit Details from" + txt_from.Text + " To " + txt_to.Text;
                    str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                    ScriptManager.RegisterStartupScript(btn_print, typeof(Button), "logix", str_Script, true);
                    Session["str_sp"] = str_sp;
                }
                else if (rd_jobwise.Checked == true)
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Ifcat Touch", "alertify.alert('Please use Shipment Details/Operating Profit for Weekly/Monthly MIS.Do not submit Jobwise Costing as MIS report.For further classification please contact to Mr.Padmanabhan');", true);
                    str_RptName = "JobWiseCosting.rpt";
                    Session["str_sfs"] = "{JobDetails.closeddate}>=date('" + dtfrom.Year + "," + dtfrom.Month + "," + dtfrom.Day + "') and {JobDetails.closeddate}<=date('" + dtto.Year + "," + dtto.Month + "," + dtto.Day + "') and {JobDetails.trantype}='" + StrTranType + "' and {JobDetails.branchid}=" + intBranchID;
                    str_sp = "Header=Jobwise Costing Details from" + txt_from.Text + " To " + txt_to.Text;
                    str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                    ScriptManager.RegisterStartupScript(btn_print, typeof(Button), "logix", str_Script, true);
                    Session["str_sp"] = str_sp;
                }
                else if (rd_shipper.Checked == true)
                {
                    
                    if (txt_name.Text == "")
                    {
                        str_RptName = "CHShipperwiseTemp.rpt";
                        Session["str_sfs"] = "{CostingDetails.closeddate}>=date('" + dtfrom.Year + "," + dtfrom.Month + "," + dtfrom.Day + "') and {CostingDetails.closeddate}<=date('" + dtto.Year + "," + dtto.Month + "," + dtto.Day + "')  and {CostingDetails.branchid}=" + intBranchID;
                        str_sp = "Title= Custom House Shipper Wise Shipment Details from " + txt_from.Text + " To " + txt_to.Text;
                    }
                    else
                    {
                        str_RptName = "CHShipmentDetailsTemp.rpt";
                        Session["str_sfs"] = "{CostingDetails.closeddate}>=date('" + dtfrom.Year + "," + dtfrom.Month + "," + dtfrom.Day + "') and {CostingDetails.closeddate}<=date('" + dtto.Year + "," + dtto.Month + "," + dtto.Day + "')  and {CostingDetails.branchid}=" + intBranchID + " and {CostingDetails.shipper}=" + hd_cust.Value;
                        str_sp = "Title='" + txt_name.Text + "' Shipment Details from " + txt_from.Text + " To " + txt_to.Text;
                    }
                    str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                    ScriptManager.RegisterStartupScript(btn_print, typeof(Button), "logix", str_Script, true);
                    Session["str_sp"] = str_sp;
                }
                else if (rd_consignee.Checked == true)
                {
                    
                    if (txt_name.Text == "")
                    {
                        str_RptName = "CHConsigneewiseTemp.rpt";
                        Session["str_sfs"] = "{CostingDetails.closeddate}>=date('" + dtfrom.Year + "," + dtfrom.Month + "," + dtfrom.Day + "') and {CostingDetails.closeddate}<=date('" + dtto.Year + "," + dtto.Month + "," + dtto.Day + "') and {CostingDetails.branchid}=" + intBranchID;
                        str_sp = "Title= Custom House Consignee Wise Shipment Details from " + txt_from.Text + " To " + txt_to.Text;
                    }
                    else
                    {
                        str_RptName = "CHShipmentDetailsTemp.rpt";
                        Session["str_sfs"] = "{CostingDetails.closeddate}>=date('" + dtfrom.Year + "," + dtfrom.Month + "," + dtfrom.Day + "') and {CostingDetails.closeddate}<=date('" + dtto.Year + "," + dtto.Month + "," + dtto.Day + "') and {CostingDetails.branchid}=" + intBranchID + " and {CostingDetails.consignee}=" + hd_cust.Value;
                        str_sp = "Title='" + txt_name.Text + "' Shipment Details from " + txt_from.Text + " To " + txt_to.Text;
                    }
                    str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                    ScriptManager.RegisterStartupScript(btn_print, typeof(Button), "logix", str_Script, true);
                    Session["str_sp"] = str_sp;
                }
            }

            string rptname = "";
            if(str_RptName != "")
            {
                if(str_RptName.IndexOf("Temp") != -1)
                {
                    rptname = str_RptName.Substring(0, str_RptName.IndexOf("Temp"));
                }else
                {
                    rptname = str_RptName.Substring(0, str_RptName.IndexOf("."));
                }
            }
                
            if(rd_shipper.Checked==true || rd_consignee.Checked == true || rd_agent.Checked == true || rd_sales.Checked == true)
            {
                if (rd_shipper.Checked == true)
                {
                    str_RptName = "Shipperwisesummary.rpt";
                    if (txt_name.Text == "")
                    {
                        if(StrTranType != "AC")
                        {
                            Session["str_sfs2"] = "{CostingDetails.closeddate}>=date('" + dtfrom.Year + "," + dtfrom.Month + "," + dtfrom.Day + "') and {CostingDetails.closeddate}<=date('" + dtto.Year + "," + dtto.Month + "," + dtto.Day + "') and {CostingDetails.trantype}='" + StrTranType + "' and {CostingDetails.branchid}=" + intBranchID;
                        }
                        else
                        {
                            Session["str_sfs2"] = "{CostingDetails.closeddate}>=date('" + dtfrom.Year + "," + dtfrom.Month + "," + dtfrom.Day + "') and {CostingDetails.closeddate}<=date('" + dtto.Year + "," + dtto.Month + "," + dtto.Day + "') and {CostingDetails.branchid}=" + intBranchID;
                        }
                        str_sp = "Title=Shipper Wise Shipment Details from" + txt_from.Text + " To " + txt_to.Text;
                    }
                    else
                    {
                        if (StrTranType != "AC")
                        {
                            Session["str_sfs2"] = "{CostingDetails.closeddate}>=date('" + dtfrom.Year + "," + dtfrom.Month + "," + dtfrom.Day + "') and {CostingDetails.closeddate}<=date('" + dtto.Year + "," + dtto.Month + "," + dtto.Day + "') and {CostingDetails.trantype}='" + StrTranType + "' and {CostingDetails.branchid}=" + intBranchID +" and {CostingDetails.shipper}=" + hd_cust.Value;
                        }
                        else
                        {
                            Session["str_sfs2"] = "{CostingDetails.closeddate}>=date('" + dtfrom.Year + "," + dtfrom.Month + "," + dtfrom.Day + "') and {CostingDetails.closeddate}<=date('" + dtto.Year + "," + dtto.Month + "," + dtto.Day + "') and {CostingDetails.branchid}=" + intBranchID + " and {CostingDetails.shipper}=" + hd_cust.Value;
                        } 
                        str_sp = "Title='" + txt_name.Text + "' Shipment Details from " + txt_from.Text + " To " + txt_to.Text;
                    }
                    str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                    ScriptManager.RegisterStartupScript(btn_print, typeof(Button), "logix", str_Script, true);
                    Session["str_sp2"] = str_sp;
                }
                else if (rd_consignee.Checked == true)
                {
                    str_RptName = "Consigneewisesummary.rpt";
                    if (txt_name.Text == "")
                    {
                        if (StrTranType != "AC")
                        {
                            Session["str_sfs2"] = "{CostingDetails.closeddate}>=date('" + dtfrom.Year + "," + dtfrom.Month + "," + dtfrom.Day + "') and {CostingDetails.closeddate}<=date('" + dtto.Year + "," + dtto.Month + "," + dtto.Day + "') and {CostingDetails.trantype}='" + StrTranType + "' and {CostingDetails.branchid}=" + intBranchID;
                        }
                        else
                        {
                            Session["str_sfs2"] = "{CostingDetails.closeddate}>=date('" + dtfrom.Year + "," + dtfrom.Month + "," + dtfrom.Day + "') and {CostingDetails.closeddate}<=date('" + dtto.Year + "," + dtto.Month + "," + dtto.Day + "') and {CostingDetails.branchid}=" + intBranchID;
                        }
                        str_sp = "Title=Consignee Wise Shipment Details from" + txt_from.Text + " To " + txt_to.Text;
                    }
                    else
                    {
                        if (StrTranType != "AC")
                        {
                            Session["str_sfs2"] = "{CostingDetails.closeddate}>=date('" + dtfrom.Year + "," + dtfrom.Month + "," + dtfrom.Day + "') and {CostingDetails.closeddate}<=date('" + dtto.Year + "," + dtto.Month + "," + dtto.Day + "') and {CostingDetails.trantype}='" + StrTranType + "' and {CostingDetails.branchid}=" + intBranchID + " and {CostingDetails.shipper}=" + hd_cust.Value;
                        }
                        else
                        {
                            Session["str_sfs2"] = "{CostingDetails.closeddate}>=date('" + dtfrom.Year + "," + dtfrom.Month + "," + dtfrom.Day + "') and {CostingDetails.closeddate}<=date('" + dtto.Year + "," + dtto.Month + "," + dtto.Day + "') and {CostingDetails.branchid}=" + intBranchID + " and {CostingDetails.shipper}=" + hd_cust.Value;
                        }
                        str_sp = "Title='" + txt_name.Text + "' Shipment Details from " + txt_from.Text + " To " + txt_to.Text;
                    }
                    str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                    ScriptManager.RegisterStartupScript(btn_print, typeof(Button), "logix", str_Script, true);
                    Session["str_sp2"] = str_sp;
                }
                else if (rd_agent.Checked == true)
                {
                    str_RptName = "Agentwisesummary.rpt";
                    if (txt_name.Text == "")
                    {
                        if (StrTranType != "AC")
                        {
                            Session["str_sfs2"] = "{CostingDetails.closeddate}>=date('" + dtfrom.Year + "," + dtfrom.Month + "," + dtfrom.Day + "') and {CostingDetails.closeddate}<=date('" + dtto.Year + "," + dtto.Month + "," + dtto.Day + "') and {CostingDetails.trantype}='" + StrTranType + "' and {CostingDetails.branchid}=" + intBranchID;
                        }
                        else
                        {
                            Session["str_sfs2"] = "{CostingDetails.closeddate}>=date('" + dtfrom.Year + "," + dtfrom.Month + "," + dtfrom.Day + "') and {CostingDetails.closeddate}<=date('" + dtto.Year + "," + dtto.Month + "," + dtto.Day + "') and {CostingDetails.branchid}=" + intBranchID;
                        }
                        str_sp = "Title=Agent Wise Shipment Details from" + txt_from.Text + " To " + txt_to.Text;
                    }
                    else
                    {
                        if (StrTranType != "AC")
                        {
                            Session["str_sfs2"] = "{CostingDetails.closeddate}>=date('" + dtfrom.Year + "," + dtfrom.Month + "," + dtfrom.Day + "') and {CostingDetails.closeddate}<=date('" + dtto.Year + "," + dtto.Month + "," + dtto.Day + "') and {CostingDetails.trantype}='" + StrTranType + "' and {CostingDetails.branchid}=" + intBranchID + " and {CostingDetails.shipper}=" + hd_cust.Value;
                        }
                        else
                        {
                            Session["str_sfs2"] = "{CostingDetails.closeddate}>=date('" + dtfrom.Year + "," + dtfrom.Month + "," + dtfrom.Day + "') and {CostingDetails.closeddate}<=date('" + dtto.Year + "," + dtto.Month + "," + dtto.Day + "') and {CostingDetails.branchid}=" + intBranchID + " and {CostingDetails.shipper}=" + hd_cust.Value;
                        }
                        str_sp = "Title='" + txt_name.Text + "' Shipment Details from " + txt_from.Text + " To " + txt_to.Text;
                    }
                    str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                    ScriptManager.RegisterStartupScript(btn_print, typeof(Button), "logix", str_Script, true);
                    Session["str_sp2"] = str_sp;
                }
                else if (rd_sales.Checked == true)
                {
                    str_RptName = "Agentwisesummary.rpt";
                    if (txt_name.Text == "")
                    {
                        if (StrTranType != "AC")
                        {
                            Session["str_sfs2"] = "{CostingDetails.closeddate}>=date('" + dtfrom.Year + "," + dtfrom.Month + "," + dtfrom.Day + "') and {CostingDetails.closeddate}<=date('" + dtto.Year + "," + dtto.Month + "," + dtto.Day + "') and {CostingDetails.trantype}='" + StrTranType + "' and {CostingDetails.business}='" + "O" + "' and {CostingDetails.salesperson}<>0" + " and {CostingDetails.branchid}=" + intBranchID;
                        }
                        else
                        {
                            Session["str_sfs2"] = "{CostingDetails.closeddate}>=date('" + dtfrom.Year + "," + dtfrom.Month + "," + dtfrom.Day + "') and {CostingDetails.closeddate}<=date('" + dtto.Year + "," + dtto.Month + "," + dtto.Day + "') and {CostingDetails.business}='" + "O" + "' and {CostingDetails.salesperson}<>0" + " and {CostingDetails.branchid}=" + intBranchID;
                        }
                        str_sp = "Title=SalesPerson Wise Shipment Details from" + txt_from.Text + " To " + txt_to.Text;
                    }
                    else
                    {
                        if (StrTranType != "AC")
                        {
                            Session["str_sfs2"] = "{CostingDetails.closeddate}>=date('" + dtfrom.Year + "," + dtfrom.Month + "," + dtfrom.Day + "') and {CostingDetails.closeddate}<=date('" + dtto.Year + "," + dtto.Month + "," + dtto.Day + "') and {CostingDetails.business}='" + "O" + "' and {CostingDetails.branchid}=" + intBranchID + " and {CostingDetails.salesperson}=" + empid + " and {CostingDetails.trantype} ='" + StrTranType + "'";
                        }
                        else
                        {
                            Session["str_sfs2"] = "{CostingDetails.closeddate}>=date('" + dtfrom.Year + "," + dtfrom.Month + "," + dtfrom.Day + "') and {CostingDetails.closeddate}<=date('" + dtto.Year + "," + dtto.Month + "," + dtto.Day + "') and {CostingDetails.business}='" + "O" + "' and {CostingDetails.branchid}=" + intBranchID + " and {CostingDetails.salesperson}=" + empid + "";
                        }
                        str_sp = "Title='" + txt_name.Text + "' Revenue Details from " + txt_from.Text + " To " + txt_to.Text;
                    }
                    str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                    ScriptManager.RegisterStartupScript(btn_print, typeof(Button), "logix", str_Script, true);
                    Session["str_sp2"] = str_sp;
                }
            }

            switch (StrTranType)
            {
                case "FE":
                    Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 105, 3, intBranchID, rptname+" View ");
                    break;
                case "FI":
                    Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 106, 3, intBranchID, rptname + " View ");
                    break;
                case "AE":
                    Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 107, 3, intBranchID, rptname + " View ");
                    break;
                case "AI":
                    Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 108, 3, intBranchID, rptname + " View ");
                    break;
                case "CH":
                    Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 109, 3, intBranchID, rptname + " View ");
                    break;
                case "AC":
                    Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 262, 3, intBranchID, rptname + " View ");
                    break;
            }
            txt_name.Text = "";
            
        }

        protected void btn_back_Click(object sender, EventArgs e)
        {
            if(btn_back.ToolTip=="Back")
            {
                this.Response.End();
            }
            else
            {
                rd_agent.Checked = false; 
                rd_canaudit.Checked = false;
                rd_canauditAI.Checked = false;  rd_consignee.Checked = false; rd_doreg.Checked = false;
                rd_freehand.Checked = false; rd_frwdwise.Checked = false; rd_jobwise.Checked = false; rd_lossJob.Checked = false; rd_mis.Checked = false;
                rd_nomination.Checked = false; rd_noVSF.Checked = false; rd_oppprofit.Checked = false; rd_pod.Checked = false; rd_pol.Checked = false;
                rd_regaudit.Checked = false; rd_retention.Checked = false; rd_revenue.Checked = false; rd_sales.Checked = false; rd_shipment.Checked = false;
                rd_shipper.Checked = false; rd_top50ship.Checked = false; rd_yearmis.Checked = false;
                txt_name.Text = "";
                //btn_back.Text = "Cancel";

                btn_back.ToolTip = "Cancel";
                btn_back1.Attributes["class"] = "btn ico-cancel";

                txt_from.Text = Utility.fn_ConvertDate(Logobj.GetDate().ToShortDateString());
                txt_to.Text = txt_from.Text;
            }
        }

        protected void btn_export_Click(object sender, EventArgs e)
        {
            if (rd_agent.Checked == false && rd_canaudit.Checked == false && rd_canauditAI.Checked == false && rd_consignee.Checked == false && rd_doreg.Checked == false
                && rd_freehand.Checked == false && rd_frwdwise.Checked == false && rd_jobwise.Checked == false && rd_lossJob.Checked == false && rd_mis.Checked == false
                && rd_nomination.Checked == false && rd_noVSF.Checked == false && rd_oppprofit.Checked == false && rd_pod.Checked == false && rd_pol.Checked == false
                && rd_regaudit.Checked == false && rd_retention.Checked == false && rd_revenue.Checked == false && rd_sales.Checked == false && rd_shipment.Checked == false
                && rd_shipper.Checked == false && rd_top50ship.Checked == false && rd_yearmis.Checked == false)
            {
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Select Any One Option');", true);
                return;
            }
            DataTable DtTemp = new DataTable();
            //DataRow dr = new DataRow();
            costtempobj.DelCostingTemp(empid);
            //StrTranType = Session["StrTranType"].ToString();
            string STR = StrTranType;
            string str_sp = ""; int intport=0;
            int intcustid;
            if (hd_cust.Value !="")
            {
                intcustid = Convert.ToInt32(hd_cust.Value);
            }
            //if(StrTranType =="FE")
            //{

            //}
            
            if(StrTranType =="FE" || StrTranType =="FI" || StrTranType =="AE" || StrTranType =="AI")
            {
                if(rd_shipment.Checked==true)
                {
                    DtTemp = costtempobj.SelExcelShipmentFCostingDts(intBranchID, StrTranType, "shipment", "0", Convert.ToDateTime(Utility.fn_ConvertDatetime( txt_from.Text)), Convert.ToDateTime(Utility.fn_ConvertDatetime( txt_to.Text)), intDivID);
                    Temp_Grid.DataSource = DtTemp;
                    Temp_Grid.DataBind();
                    str_sp = "Shipment Details for the period of " + txt_from.Text + " to " + txt_to.Text;
                }else if(rd_top50ship.Checked == true)
                {
                    //DataTable Dt1 = new DataTable();
                    //Dt1.Columns.Add("Customer");
                    //Dt1.Columns.Add("Retention");
                    DtTemp = costtempobj.SelTop50ShipperConsignee4BranchTantype(empid, intBranchID, StrTranType, Convert.ToDateTime(Utility.fn_ConvertDatetime(txt_from.Text)), Convert.ToDateTime(Utility.fn_ConvertDatetime(txt_to.Text)));
                    Temp_Grid.DataSource = DtTemp;
                    Temp_Grid.DataBind();
                    str_sp = "Top 50 Customer Details for the period from " + txt_from.Text + " to " + txt_to.Text;
                }else if(rd_pol.Checked==true)
                {
                    if(txt_name.Text=="")
                    {
                        DtTemp = costtempobj.SelExcelShipmentFCostingDts(intBranchID, StrTranType, "pol", "0", Convert.ToDateTime(Utility.fn_ConvertDatetime(txt_from.Text)), Convert.ToDateTime(Utility.fn_ConvertDatetime(txt_to.Text)), intDivID);
                        Temp_Grid.DataSource = DtTemp;
                        Temp_Grid.DataBind();
                        str_sp = "Port of Loadingwise Shipment for the period of " + txt_from.Text + " to " + txt_to.Text;
                    }else
                    {
                        intport = Portobj.GetNPortid(txt_name.Text);
                        DtTemp = costtempobj.SelExcelShipmentFCostingDts(intBranchID, StrTranType, "pol", intport.ToString(), Convert.ToDateTime(Utility.fn_ConvertDatetime(txt_from.Text)), Convert.ToDateTime(Utility.fn_ConvertDatetime(txt_to.Text)), intDivID);
                        Temp_Grid.DataSource = DtTemp;
                        Temp_Grid.DataBind();
                        str_sp = "Port of Loadingwise Shipment for the period of " + txt_from.Text + " to " + txt_to.Text;
                    }
                }
                else if (rd_pod.Checked == true)
                {
                    if (txt_name.Text == "")
                    {
                        DtTemp = costtempobj.SelExcelShipmentFCostingDts(intBranchID, StrTranType, "pod", "0", Convert.ToDateTime(Utility.fn_ConvertDatetime(txt_from.Text)), Convert.ToDateTime(Utility.fn_ConvertDatetime(txt_to.Text)), intDivID);
                        Temp_Grid.DataSource = DtTemp;
                        Temp_Grid.DataBind();
                        str_sp = "Port of Distinationwise Shipment for the period of " + txt_from.Text + " to " + txt_to.Text;
                    }
                    else
                    {
                        intport = Portobj.GetNPortid(txt_name.Text);
                        DtTemp = costtempobj.SelExcelShipmentFCostingDts(intBranchID, StrTranType, "pod", intport.ToString(), Convert.ToDateTime(Utility.fn_ConvertDatetime(txt_from.Text)), Convert.ToDateTime(Utility.fn_ConvertDatetime(txt_to.Text)), intDivID);
                        Temp_Grid.DataSource = DtTemp;
                        Temp_Grid.DataBind();
                        str_sp = "Port of Distinationwise Shipment for the period of " + txt_from.Text + " to " + txt_to.Text;
                    }
                }
                else if (rd_shipper.Checked == true)
                {
                    if (txt_name.Text == "")
                    {
                        DtTemp = costtempobj.SelExcelShipmentFCostingDts(intBranchID, StrTranType, "shipper", "0", Convert.ToDateTime(Utility.fn_ConvertDatetime(txt_from.Text)), Convert.ToDateTime(Utility.fn_ConvertDatetime(txt_to.Text)), intDivID);
                        Temp_Grid.DataSource = DtTemp;
                        Temp_Grid.DataBind();
                        str_sp = "Shipperwise Shipment for the period of " + txt_from.Text + " to " + txt_to.Text;
                    }
                    else
                    {
                        DtTemp = costtempobj.SelExcelShipmentFCostingDts(intBranchID, StrTranType, "shipper", hd_cust.Value, Convert.ToDateTime(Utility.fn_ConvertDatetime(txt_from.Text)), Convert.ToDateTime(Utility.fn_ConvertDatetime(txt_to.Text)), intDivID);
                        Temp_Grid.DataSource = DtTemp;
                        Temp_Grid.DataBind();
                        str_sp = "Shipperwise Shipment for the period of " + txt_from.Text + " to " + txt_to.Text;
                    }
                }
                else if (rd_consignee.Checked == true)
                {
                    if (txt_name.Text == "")
                    {
                        DtTemp = costtempobj.SelExcelShipmentFCostingDts(intBranchID, StrTranType, "consignee", "0", Convert.ToDateTime(Utility.fn_ConvertDatetime(txt_from.Text)), Convert.ToDateTime(Utility.fn_ConvertDatetime(txt_to.Text)), intDivID);
                        Temp_Grid.DataSource = DtTemp;
                        Temp_Grid.DataBind();
                        str_sp = "Consigneewise Shipment for the period of " + txt_from.Text + " to " + txt_to.Text;
                    }
                    else
                    {
                        DtTemp = costtempobj.SelExcelShipmentFCostingDts(intBranchID, StrTranType, "consignee", hd_cust.Value, Convert.ToDateTime(Utility.fn_ConvertDatetime(txt_from.Text)), Convert.ToDateTime(Utility.fn_ConvertDatetime(txt_to.Text)), intDivID);
                        Temp_Grid.DataSource = DtTemp;
                        Temp_Grid.DataBind();
                        str_sp = "Consigneewise Shipment for the period of " + txt_from.Text + " to " + txt_to.Text;
                    }
                }
                else if (rd_agent.Checked == true)
                {
                    if (txt_name.Text == "")
                    {
                        DtTemp = costtempobj.SelExcelShipmentFCostingDts(intBranchID, StrTranType, "agent", "0", Convert.ToDateTime(Utility.fn_ConvertDatetime(txt_from.Text)), Convert.ToDateTime(Utility.fn_ConvertDatetime(txt_to.Text)), intDivID);
                        Temp_Grid.DataSource = DtTemp;
                        Temp_Grid.DataBind();
                        str_sp = "Agentwise Shipment for the period of " + txt_from.Text + " to " + txt_to.Text;
                    }
                    else
                    {
                        DtTemp = costtempobj.SelExcelShipmentFCostingDts(intBranchID, StrTranType, "agent", hd_cust.Value, Convert.ToDateTime(Utility.fn_ConvertDatetime(txt_from.Text)), Convert.ToDateTime(Utility.fn_ConvertDatetime(txt_to.Text)), intDivID);
                        Temp_Grid.DataSource = DtTemp;
                        Temp_Grid.DataBind();
                        str_sp = "Agentwise Shipment for the period of " + txt_from.Text + " to " + txt_to.Text;
                    }
                }
                else if (rd_sales.Checked == true)
                {
                    if (txt_name.Text == "")
                    {
                        DtTemp = costtempobj.SelExcelShipmentFCostingDts(intBranchID, StrTranType, "salesperson", "0", Convert.ToDateTime(Utility.fn_ConvertDatetime(txt_from.Text)), Convert.ToDateTime(Utility.fn_ConvertDatetime(txt_to.Text)), intDivID);
                        Temp_Grid.DataSource = DtTemp;
                        Temp_Grid.DataBind();
                        str_sp = "Shipment Details for the period of " + txt_from.Text + " to " + txt_to.Text;
                    }
                    else
                    {
                        DtTemp = costtempobj.SelExcelShipmentFCostingDts(intBranchID, StrTranType, "salesperson", hd_cust.Value, Convert.ToDateTime(Utility.fn_ConvertDatetime(txt_from.Text)), Convert.ToDateTime(Utility.fn_ConvertDatetime(txt_to.Text)), intDivID);
                        Temp_Grid.DataSource = DtTemp;
                        Temp_Grid.DataBind();
                        str_sp = "Shipment Details for the period of " + txt_from.Text + " to " + txt_to.Text;
                    }
                }
                else if (rd_nomination.Checked == true)
                {
                    DtTemp = costtempobj.SelExcelShipmentFCostingDts(intBranchID, StrTranType, "nomination", "N", Convert.ToDateTime(Utility.fn_ConvertDatetime(txt_from.Text)), Convert.ToDateTime(Utility.fn_ConvertDatetime(txt_to.Text)), intDivID);
                        Temp_Grid.DataSource = DtTemp;
                        Temp_Grid.DataBind();
                        str_sp = "Nominationwise Shipment Details for the period of " + txt_from.Text + " to " + txt_to.Text;
                }
                else if (rd_freehand.Checked == true)
                {
                    DtTemp = costtempobj.SelExcelShipmentFCostingDts(intBranchID, StrTranType, "nomination", "F", Convert.ToDateTime(Utility.fn_ConvertDatetime(txt_from.Text)), Convert.ToDateTime(Utility.fn_ConvertDatetime(txt_to.Text)), intDivID);
                    Temp_Grid.DataSource = DtTemp;
                    Temp_Grid.DataBind();
                    str_sp = "Freehandwise Shipment Details for the period of " + txt_from.Text + " to " + txt_to.Text;
                }
                else if (rd_noVSF.Checked == true)
                {
                    Session["From"] = txt_from.Text;
                    Session["To"] = txt_to.Text;
                    this.popuprate.Show();
                }
                else if (rd_lossJob.Checked == true)
                {
                    DtTemp = costtempobj.SelLossJobs(Convert.ToDateTime(Convert.ToDateTime(txt_from.Text).ToString("dd/MMM/yyyy")), Convert.ToDateTime(Convert.ToDateTime(txt_to.Text).ToString("dd/MMM/yyyy")), StrTranType, intBranchID);
                    Temp_Grid.DataSource = DtTemp;
                    Temp_Grid.DataBind();
                    str_sp = "Loss Jobs Details Details for the period of " + txt_from.Text + " to " + txt_to.Text;
                }else if(rd_retention.Checked==true)
                {
                    AgentSummary();
                }else if(rd_canauditAI.Checked==true)
                {
                    DtTemp = costtempobj.GetCanRegister4AuditAI(intBranchID, Convert.ToDateTime(Utility.fn_ConvertDatetime(txt_from.Text)), Convert.ToDateTime(Utility.fn_ConvertDatetime(txt_to.Text)));
                    Temp_Grid.DataSource=DtTemp;
                    Temp_Grid.DataBind();
                    str_sp = "CAN Audit Report AI for the period of " + txt_from.Text + " to " + txt_to.Text;
                    if(Temp_Grid.Rows.Count > 0)
                    {
                        Temp_Grid.Visible=true;
                        Response.Clear();
                        Response.AddHeader("content-disposition", "attachment;filename=ExportData.xls");
                        Response.Charset = "";
                        Response.ContentType = "application/vnd.xls";
                        StringWriter StringWriter = new System.IO.StringWriter();
                        HtmlTextWriter HtmlTextWriter = new HtmlTextWriter(StringWriter);
                        Temp_Grid.GridLines = GridLines.Both;
                        Temp_Grid.HeaderStyle.Font.Bold = true;
                        Temp_Grid.RenderControl(HtmlTextWriter);
                        Response.Write(StringWriter.ToString());
                        Temp_Grid.Visible=false;
                        Response.End();
                    }else
                    {
                        ScriptManager.RegisterStartupScript(btn_export, typeof(Button), "logix", "alertify.alert('Data not available');", true);
                    }
                }
                else if (rd_canaudit.Checked == true)
                {
                    DtTemp = costtempobj.GetCanRegister4Audit(intBranchID, Convert.ToDateTime(Utility.fn_ConvertDatetime(txt_from.Text)), Convert.ToDateTime(Utility.fn_ConvertDatetime(txt_to.Text)));
                    Temp_Grid.DataSource = DtTemp;
                    Temp_Grid.DataBind();
                    str_sp = "CAN Audit Report for the period of " + txt_from.Text + " to " + txt_to.Text;
                    if (Temp_Grid.Rows.Count > 0)
                    {
                        Temp_Grid.Visible=true;
                        Response.Clear();
                        Response.AddHeader("content-disposition", "attachment;filename=ExportData.xls");
                        Response.Charset = "";
                        Response.ContentType = "application/vnd.xls";
                        StringWriter StringWriter = new System.IO.StringWriter();
                        HtmlTextWriter HtmlTextWriter = new HtmlTextWriter(StringWriter);
                        Temp_Grid.GridLines = GridLines.Both;
                        Temp_Grid.HeaderStyle.Font.Bold = true;
                        Temp_Grid.RenderControl(HtmlTextWriter);
                        Response.Write(StringWriter.ToString());
                        Temp_Grid.Visible=false;
                        Response.End();
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(btn_export, typeof(Button), "logix", "alertify.alert('Data not available');", true);
                    }
                }else if(rd_doreg.Checked ==true)
                {
                    DtTemp = costtempobj.GetDoRegister4Audit(intBranchID, Convert.ToDateTime(Utility.fn_ConvertDatetime(txt_from.Text)), Convert.ToDateTime(Utility.fn_ConvertDatetime(txt_to.Text)));
                    Temp_Grid.DataSource = DtTemp;
                    Temp_Grid.DataBind();
                    str_sp = "DO Audit Report for the period of " + txt_from.Text + " to " + txt_to.Text;
                    if (Temp_Grid.Rows.Count > 0)
                    {
                        Temp_Grid.Visible = true;
                        Response.Clear();
                        Response.AddHeader("content-disposition", "attachment;filename=ExportData.xls");
                        Response.Charset = "";
                        Response.ContentType = "application/vnd.xls";
                        StringWriter StringWriter = new System.IO.StringWriter();
                        HtmlTextWriter HtmlTextWriter = new HtmlTextWriter(StringWriter);
                        Temp_Grid.GridLines = GridLines.Both;
                        Temp_Grid.HeaderStyle.Font.Bold = true;
                        Temp_Grid.RenderControl(HtmlTextWriter);
                        Response.Write(StringWriter.ToString());
                        Temp_Grid.Visible = false;
                        Response.End();
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(btn_export, typeof(Button), "logix", "alertify.alert('Data not available');", true);
                    }
                }
            }
            else if (StrTranType == "AC")
            {
                if (rd_shipment.Checked == true)
                {
                    DtTemp = costtempobj.SelExcelShipmentFCostingDts(intBranchID, StrTranType, "shipment", "0", Convert.ToDateTime(Utility.fn_ConvertDatetime(txt_from.Text)), Convert.ToDateTime(Utility.fn_ConvertDatetime(txt_to.Text)), intDivID);
                    Temp_Grid.DataSource = DtTemp;
                    Temp_Grid.DataBind();
                    str_sp = "Shipment Details for the period of " + txt_from.Text + " to " + txt_to.Text;
                }
                else if (rd_top50ship.Checked == true)
                {
                    DataSet ds = new DataSet();
                    DataTable Dt1 = new DataTable();
                    DataTable Dt2 = new DataTable();
                   //DataRow = new DataRow();
                    Dt1.Columns.Add("Shipper");
                    Dt1.Columns.Add("Retention4Shipper");
                    Dt1.Columns.Add("Consignee");
                    Dt1.Columns.Add("Retention4Consignee");
                    DataRow dr = Dt1.NewRow();
                    ds = costtempobj.SelTop50ShipperConsignee4Branch(empid, intBranchID, Convert.ToDateTime(Utility.fn_ConvertDatetime(txt_from.Text)), Convert.ToDateTime(Utility.fn_ConvertDatetime(txt_to.Text)));
                    DtTemp = ds.Tables[0];
                    Dt2 = ds.Tables[1];
                    if (DtTemp.Rows.Count > 0)
                    {
                        int n = Dt1.Rows.Count;
                        for (int j = 0; j <= DtTemp.Rows.Count - 1; j++)
                        {
                            if (j == 0)
                            {
                                dr = Dt1.NewRow();
                                Dt1.Rows.Add();
                                if(i==1)
                                {
                                    Dt1.Rows[n][0] = "";
                                }
                                else if (i == 2)
                                {
                                    Dt1.Rows[n][0] = "";
                                }
                                else if (i == 3)
                                {
                                    Dt1.Rows[n][0] = "";
                                }
                                else
                                {
                                    Dt1.Rows[n][0] = "";
                                }
                                Dt1.Rows[n][1] = "";
                                Dt1.Rows[n][2] = "";
                                Dt1.Rows[n][3] = "";
                                n = n + 1;
                                dr = Dt1.NewRow();
                                Dt1.Rows.Add();
                                Dt1.Rows[n][0] = DtTemp.Rows[j][0];
                                Dt1.Rows[n][1] = DtTemp.Rows[j][1];
                                if(Dt2.Rows.Count > j)
                                {
                                    Dt1.Rows[n][2] = Dt2.Rows[j][1];
                                    Dt1.Rows[n][3] = Dt2.Rows[j][1];
                                }else
                                {
                                    Dt1.Rows[n][2] ="";
                                    Dt1.Rows[n][3] = "";
                                }
                            }else
                            {
                                dr = Dt1.NewRow();
                                Dt1.Rows.Add();
                                Dt1.Rows[n][0] = DtTemp.Rows[j][0];
                                Dt1.Rows[n][1] = DtTemp.Rows[j][1];
                                if (Dt2.Rows.Count > j)
                                {
                                    Dt1.Rows[n][2] = Dt2.Rows[j][1];
                                    Dt1.Rows[n][3] = Dt2.Rows[j][1];
                                }
                                else
                                {
                                    Dt1.Rows[n][2] = "";
                                    Dt1.Rows[n][3] = "";
                                }
                            }
                        }
                    }
                    Temp_Grid.DataSource = Dt1;
                    Temp_Grid.DataBind();
                    str_sp = "Top 50 Shipper / Consignee Details for the period from " + txt_from.Text + " to " + txt_to.Text;
                }
                else if (rd_lossJob.Checked == true)
                {
                    DtTemp = costtempobj.SelLossJobs(Convert.ToDateTime(Convert.ToDateTime(txt_from.Text).ToString("dd/MMM/yyyy")), Convert.ToDateTime(Convert.ToDateTime(txt_to.Text).ToString("dd/MMM/yyyy")), "AC", intBranchID);
                    Temp_Grid.DataSource = DtTemp;
                    Temp_Grid.DataBind();
                    str_sp = "Loss Jobs Details Details for the period of " + txt_from.Text + " to " + txt_to.Text;
                }
                else if (rd_pol.Checked == true)
                {
                    if (txt_name.Text == "")
                    {
                        DtTemp = costtempobj.SelExcelShipmentFCostingDts(intBranchID, StrTranType, "pol", "0", Convert.ToDateTime(Utility.fn_ConvertDatetime(txt_from.Text)), Convert.ToDateTime(Utility.fn_ConvertDatetime(txt_to.Text)), intDivID);
                        Temp_Grid.DataSource = DtTemp;
                        Temp_Grid.DataBind();
                        str_sp = "Port of Loadingwise Shipment for the period of " + txt_from.Text + " to " + txt_to.Text;
                    }
                    else
                    {
                        intport = Portobj.GetNPortid(txt_name.Text);
                        DtTemp = costtempobj.SelExcelShipmentFCostingDts(intBranchID, StrTranType, "pol", intport.ToString(), Convert.ToDateTime(Utility.fn_ConvertDatetime(txt_from.Text)), Convert.ToDateTime(Utility.fn_ConvertDatetime(txt_to.Text)), intDivID);
                        Temp_Grid.DataSource = DtTemp;
                        Temp_Grid.DataBind();
                        str_sp = "Port of Loadingwise Shipment for the period of " + txt_from.Text + " to " + txt_to.Text;
                    }
                }
                else if (rd_pod.Checked == true)
                {
                    if (txt_name.Text == "")
                    {
                        DtTemp = costtempobj.SelExcelShipmentFCostingDts(intBranchID, StrTranType, "pod", "0", Convert.ToDateTime(Utility.fn_ConvertDatetime(txt_from.Text)), Convert.ToDateTime(Utility.fn_ConvertDatetime(txt_to.Text)), intDivID);
                        Temp_Grid.DataSource = DtTemp;
                        Temp_Grid.DataBind();
                        str_sp = "Port of Distinationwise Shipment for the period of " + txt_from.Text + " to " + txt_to.Text;
                    }
                    else
                    {
                        intport = Portobj.GetNPortid(txt_name.Text);
                        DtTemp = costtempobj.SelExcelShipmentFCostingDts(intBranchID, StrTranType, "pod", intport.ToString(), Convert.ToDateTime(Utility.fn_ConvertDatetime(txt_from.Text)), Convert.ToDateTime(Utility.fn_ConvertDatetime(txt_to.Text)), intDivID);
                        Temp_Grid.DataSource = DtTemp;
                        Temp_Grid.DataBind();
                        str_sp = "Port of Distinationwise Shipment for the period of " + txt_from.Text + " to " + txt_to.Text;
                    }
                }
                else if (rd_shipper.Checked == true)
                {
                    if (txt_name.Text == "")
                    {
                        DtTemp = costtempobj.SelExcelShipmentFCostingDts(intBranchID, StrTranType, "shipper", "0", Convert.ToDateTime(Utility.fn_ConvertDatetime(txt_from.Text)), Convert.ToDateTime(Utility.fn_ConvertDatetime(txt_to.Text)), intDivID);
                        Temp_Grid.DataSource = DtTemp;
                        Temp_Grid.DataBind();
                        str_sp = "Shipperwise Shipment for the period of " + txt_from.Text + " to " + txt_to.Text;
                    }
                    else
                    {
                        DtTemp = costtempobj.SelExcelShipmentFCostingDts(intBranchID, StrTranType, "shipper", hd_cust.Value, Convert.ToDateTime(Utility.fn_ConvertDatetime(txt_from.Text)), Convert.ToDateTime(Utility.fn_ConvertDatetime(txt_to.Text)), intDivID);
                        Temp_Grid.DataSource = DtTemp;
                        Temp_Grid.DataBind();
                        str_sp = "Shipperwise Shipment for the period of " + txt_from.Text + " to " + txt_to.Text;
                    }
                }
                else if (rd_consignee.Checked == true)
                {
                    if (txt_name.Text == "")
                    {
                        DtTemp = costtempobj.SelExcelShipmentFCostingDts(intBranchID, StrTranType, "consignee", "0", Convert.ToDateTime(Utility.fn_ConvertDatetime(txt_from.Text)), Convert.ToDateTime(Utility.fn_ConvertDatetime(txt_to.Text)), intDivID);
                        Temp_Grid.DataSource = DtTemp;
                        Temp_Grid.DataBind();
                        str_sp = "Consigneewise Shipment for the period of " + txt_from.Text + " to " + txt_to.Text;
                    }
                    else
                    {
                        DtTemp = costtempobj.SelExcelShipmentFCostingDts(intBranchID, StrTranType, "consignee", hd_cust.Value, Convert.ToDateTime(Utility.fn_ConvertDatetime(txt_from.Text)), Convert.ToDateTime(Utility.fn_ConvertDatetime(txt_to.Text)), intDivID);
                        Temp_Grid.DataSource = DtTemp;
                        Temp_Grid.DataBind();
                        str_sp = "Consigneewise Shipment for the period of " + txt_from.Text + " to " + txt_to.Text;
                    }
                }
                else if (rd_agent.Checked == true)
                {
                    if (txt_name.Text == "")
                    {
                        DtTemp = costtempobj.SelExcelShipmentFCostingDts(intBranchID, StrTranType, "agent", "0", Convert.ToDateTime(Utility.fn_ConvertDatetime(txt_from.Text)), Convert.ToDateTime(Utility.fn_ConvertDatetime(txt_to.Text)), intDivID);
                        Temp_Grid.DataSource = DtTemp;
                        Temp_Grid.DataBind();
                        str_sp = "Agentwise Shipment for the period of " + txt_from.Text + " to " + txt_to.Text;
                    }
                    else
                    {
                        DtTemp = costtempobj.SelExcelShipmentFCostingDts(intBranchID, StrTranType, "agent", hd_cust.Value, Convert.ToDateTime(Utility.fn_ConvertDatetime(txt_from.Text)), Convert.ToDateTime(Utility.fn_ConvertDatetime(txt_to.Text)), intDivID);
                        Temp_Grid.DataSource = DtTemp;
                        Temp_Grid.DataBind();
                        str_sp = "Agentwise Shipment for the period of " + txt_from.Text + " to " + txt_to.Text;
                    }
                }
                else if (rd_sales.Checked == true)
                {
                    if (txt_name.Text == "")
                    {
                        DtTemp = costtempobj.SelExcelShipmentFCostingDts(intBranchID, StrTranType, "salesperson", "0", Convert.ToDateTime(Utility.fn_ConvertDatetime(txt_from.Text)), Convert.ToDateTime(Utility.fn_ConvertDatetime(txt_to.Text)), intDivID);
                        Temp_Grid.DataSource = DtTemp;
                        Temp_Grid.DataBind();
                        str_sp = "Shipment Details for the period of " + txt_from.Text + " to " + txt_to.Text;
                    }
                    else
                    {
                        DtTemp = costtempobj.SelExcelShipmentFCostingDts(intBranchID, StrTranType, "salesperson", hd_cust.Value, Convert.ToDateTime(Utility.fn_ConvertDatetime(txt_from.Text)), Convert.ToDateTime(Utility.fn_ConvertDatetime(txt_to.Text)), intDivID);
                        Temp_Grid.DataSource = DtTemp;
                        Temp_Grid.DataBind();
                        str_sp = "Shipment Details for the period of " + txt_from.Text + " to " + txt_to.Text;
                    }
                }
                else if (rd_nomination.Checked == true)
                {
                    DtTemp = costtempobj.SelExcelShipmentFCostingDts(intBranchID, StrTranType, "nomination", "N", Convert.ToDateTime(Utility.fn_ConvertDatetime(txt_from.Text)), Convert.ToDateTime(Utility.fn_ConvertDatetime(txt_to.Text)), intDivID);
                    Temp_Grid.DataSource = DtTemp;
                    Temp_Grid.DataBind();
                    str_sp = "Nominationwise Shipment Details for the period of " + txt_from.Text + " to " + txt_to.Text;
                }
                else if (rd_freehand.Checked == true)
                {
                    DtTemp = costtempobj.SelExcelShipmentFCostingDts(intBranchID, StrTranType, "nomination", "F", Convert.ToDateTime(Utility.fn_ConvertDatetime(txt_from.Text)), Convert.ToDateTime(Utility.fn_ConvertDatetime(txt_to.Text)), intDivID);
                    Temp_Grid.DataSource = DtTemp;
                    Temp_Grid.DataBind();
                    str_sp = "Freehandwise Shipment Details for the period of " + txt_from.Text + " to " + txt_to.Text;
                }
                else if (rd_noVSF.Checked == true)
                {
                    Session["From"] = txt_from.Text;
                    Session["To"] = txt_to.Text;
                    this.popuprate.Show();
                }
            }

            txt_name.Text = "";
            if(rd_jobwise.Checked ==true || rd_oppprofit.Checked ==true)
            {
                if(StrTranType =="FE" || StrTranType =="FI" || StrTranType =="AE" || StrTranType =="AI" || StrTranType=="CH")
                {
                    if(rd_oppprofit.Checked == true)
                    {
                        DtTemp = costtempobj.SelExcelOperatingProfit(intBranchID, StrTranType, Convert.ToDateTime(Utility.fn_ConvertDatetime(txt_from.Text)), Convert.ToDateTime(Utility.fn_ConvertDatetime(txt_to.Text)), intDivID);
                        Temp_Grid.DataSource = DtTemp;
                        Temp_Grid.DataBind();
                        str_sp = "Operating Profit for the period of " + txt_from.Text + " to " + txt_to.Text;
                    }else  if (rd_oppprofit.Checked == true)
                    {
                        DtTemp = costtempobj.SelExcelJobWise(intBranchID, StrTranType, Convert.ToDateTime(Utility.fn_ConvertDatetime(txt_from.Text)), Convert.ToDateTime(Utility.fn_ConvertDatetime(txt_to.Text)), intDivID);
                        Temp_Grid.DataSource = DtTemp;
                        Temp_Grid.DataBind();
                        str_sp = "JobWise Costing for the period of " + txt_from.Text + " to " + txt_to.Text;
                    }
                }else
                {
                    if (rd_oppprofit.Checked == true)
                    {
                        DtTemp = costtempobj.SelExcelOperatingProfit(intBranchID, StrTranType, Convert.ToDateTime(Utility.fn_ConvertDatetime(txt_from.Text)), Convert.ToDateTime(Utility.fn_ConvertDatetime(txt_to.Text)), intDivID);
                        Temp_Grid.DataSource = DtTemp;
                        Temp_Grid.DataBind();
                        str_sp = "Operating Profit for the period of " + txt_from.Text + " to " + txt_to.Text;
                        if (Temp_Grid.Rows.Count > 0)
                        {
                            Temp_Grid.Visible = true;
                            Response.Clear();
                            Response.AddHeader("content-disposition", "attachment;filename=ExportData.xls");
                            Response.Charset = "";
                            Response.ContentType = "application/vnd.xls";
                            StringWriter StringWriter = new System.IO.StringWriter();
                            HtmlTextWriter HtmlTextWriter = new HtmlTextWriter(StringWriter);
                            Temp_Grid.GridLines = GridLines.Both;
                            Temp_Grid.HeaderStyle.Font.Bold = true;
                            Temp_Grid.RenderControl(HtmlTextWriter);
                            Response.Write(StringWriter.ToString());
                            Temp_Grid.Visible = false;
                            Response.End();
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(btn_export, typeof(Button), "logix", "alertify.alert('Data not available');", true);
                        }
                    }
                    else if (rd_jobwise.Checked == true)
                    {
                        DtTemp = costtempobj.SelExcelJobWise(intBranchID, StrTranType, Convert.ToDateTime(Utility.fn_ConvertDatetime(txt_from.Text)), Convert.ToDateTime(Utility.fn_ConvertDatetime(txt_to.Text)), intDivID);
                        Temp_Grid.DataSource = DtTemp;
                        Temp_Grid.DataBind();
                        str_sp = "JobWise Costing for the period of " + txt_from.Text + " to " + txt_to.Text;
                    }
                }
            }
            if(StrTranType=="CH")
            {
                if(rd_shipment.Checked==true)
                {
                    DtTemp = costtempobj.SelExcelShipmentFCostingDts(intBranchID, StrTranType, "shipment", "0", Convert.ToDateTime(Utility.fn_ConvertDatetime(txt_from.Text)), Convert.ToDateTime(Utility.fn_ConvertDatetime(txt_to.Text)), intDivID);
                        Temp_Grid.DataSource = DtTemp;
                        Temp_Grid.DataBind();
                        str_sp = "Shipment Details for the period of " + txt_from.Text + " to " + txt_to.Text;
                    
                }else if(rd_top50ship.Checked == true)
                {
                    DtTemp = costtempobj.SelTop50ShipperConsignee4BranchTantype(empid, intBranchID, StrTranType, Convert.ToDateTime(Utility.fn_ConvertDatetime(txt_from.Text)), Convert.ToDateTime(Utility.fn_ConvertDatetime(txt_to.Text)));
                    Temp_Grid.DataSource = DtTemp;
                    Temp_Grid.DataBind();
                    str_sp = "Top 50 Customer  Details for the period of " + txt_from.Text + " to " + txt_to.Text;
                }else if(rd_shipper.Checked==true)
                {
                    DtTemp = costtempobj.SelExcelShipmentFCostingDts(intBranchID, StrTranType, "shipper", "0", Convert.ToDateTime(Utility.fn_ConvertDatetime(txt_from.Text)), Convert.ToDateTime(Utility.fn_ConvertDatetime(txt_to.Text)), intDivID);
                    Temp_Grid.DataSource = DtTemp;
                    Temp_Grid.DataBind();
                    str_sp = "Shipperwise Shipment Details for the period of " + txt_from.Text + " to " + txt_to.Text;
                }
                else if (rd_consignee.Checked == true)
                {
                    DtTemp = costtempobj.SelExcelShipmentFCostingDts(intBranchID, StrTranType, "consignee", "0", Convert.ToDateTime(Utility.fn_ConvertDatetime(txt_from.Text)), Convert.ToDateTime(Utility.fn_ConvertDatetime(txt_to.Text)), intDivID);
                    Temp_Grid.DataSource = DtTemp;
                    Temp_Grid.DataBind();
                    str_sp = "Shipperwise Shipment Details for the period of " + txt_from.Text + " to " + txt_to.Text;
                }
            }
            if(rd_retention.Checked == false &&  rd_revenue.Checked == false)
            {
                inamt = 0;
                examt = 0;
                reamt = 0;
                //BindingSource bs = (BindingSource)Temp_Grid.DataSource; // Se convierte el DataSource 
                //DataTable tCxC = (DataTable)bs.DataSource;
                DataRow dr;
                DataTable tbl = new DataTable();
                //for (int j = 0; j < Temp_Grid.Rows.Count; j++)
                //{
                    
                //    GridViewRow row = Temp_Grid.Rows[j];
                //    dr = tbl.NewRow();
                //    for (int i = 0; i < row.Cells.Count; i++)
                //    {
                //        dr[i] = row.Cells[i].Text;
                //    }

                //    tbl.Rows.Add(dr);
                //}
                //dr = tbl.NewRow();
                if(rd_lossJob.Checked==false && rd_top50ship.Checked==false )
                {
                    //Temp_Grid.Visible = true;
                    if (Temp_Grid.Rows.Count > 0)
                    {
                        for (int i = 0; i <= DtTemp.Rows.Count - 1; i++)
                        {
                            inamt = inamt + Convert.ToDouble(DtTemp.Rows[i]["Income"]);
                            examt = examt + Convert.ToDouble(DtTemp.Rows[i]["Expense"]);
                            reamt = reamt + Convert.ToDouble(DtTemp.Rows[i]["Retention"]);
                        }
                        dr = DtTemp.NewRow();
                        DtTemp.Rows.Add();
                        DtTemp.Rows[DtTemp.Rows.Count - 1]["Income"] = inamt.ToString("#0.00");
                        DtTemp.Rows[DtTemp.Rows.Count - 1]["Expense"] = examt.ToString("#0.00");
                        DtTemp.Rows[DtTemp.Rows.Count - 1]["Retention"] = reamt.ToString("#0.00");
                        Temp_Grid.DataSource = DtTemp;
                        Temp_Grid.DataBind();
                    }
                    
                    
                }

                if (Temp_Grid.Rows.Count > 0)
                {
                    Temp_Grid.Visible = true;
                    Response.Clear();
                    Response.AddHeader("content-disposition", "attachment;filename=ExportData.xls");
                    Response.Charset = "";
                    Response.ContentType = "application/vnd.xls";
                    StringWriter StringWriter = new System.IO.StringWriter();
                    HtmlTextWriter HtmlTextWriter = new HtmlTextWriter(StringWriter);
                    Temp_Grid.GridLines = GridLines.Both;
                    Temp_Grid.HeaderStyle.Font.Bold = true;
                    Temp_Grid.RenderControl(HtmlTextWriter);
                    Response.Write(StringWriter.ToString());
                    Temp_Grid.Visible = false;
                    Response.End();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(btn_export, typeof(Button), "logix", "alertify.alert('Data not available');", true);
                }
            }

            if(StrTranType  == "FI")
            {
                if(rd_revenue.Checked==true)
                {
                    RevenueRpt();
                }
            }

        }
        public override void VerifyRenderingInServerForm(Control control)
        {
            //required to avoid the run time error "  
            //Control 'GridView1' of type 'Grid View' must be placed inside a form tag with runat=server."  
        }
        protected void RevenueRpt()
        {
            string  sendqry = "";
            String desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            String strdate = DateTime.Now.ToString("dd-MMM-yyyy");
            DataTable Dtaddr= new DataTable();
            DataTable dtrev= new DataTable();
            filename = "Revenue Report as on " + strdate;
            Response.Clear();
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.AddHeader("content-disposition", "attachment;filename="+filename+".xls");
            Response.Charset = "";
            Response.ContentType = "application/vnd.xls";
            StringWriter StringWriter = new System.IO.StringWriter();
            HtmlTextWriter HtmlTextWriter = new HtmlTextWriter(StringWriter);
        //TW = System.IO.File.CreateText(desktopPath + "\" + filename + ".xls")
         sendqry = sendqry + "<html  xmlns:v=\"urn:schemas-microsoft-com:vml\"xmlns:o=\"urn:schemas-microsoft-com:office:office\" xmlns:x=\"urn:schemas-microsoft-com:office:excel\"xmlns=\"http://www.w3.org/TR/REC-html40\">";
         Dtaddr = Logobj.GetCompanyNameAdd(intBranchID);
            if(Dtaddr.Rows.Count > 0)
            {
                sendqry += "<body>";
                sendqry += "<table  BORDER=1 BORDERCOLOR=Black  style=font-family:sans-serif;font-size:9pt>";
                sendqry += "<tr><td align=center colspan=21>";
                sendqry += "<FONT FACE=Arial SIZE=4 align=center>" + Dtaddr.Rows[0][0].ToString() + "</FONT><br><FONT FACE=Arial SIZE=2>" + Dtaddr.Rows[0][1].ToString() + " <br> Phone : " + Dtaddr.Rows[0][2].ToString() + " Fax : " + Dtaddr.Rows[0][3].ToString() + "</Font>";
                sendqry += "</td></tr>";
                sendqry += "<tr><td align=center colspan=2><b>Job #</b></td><td align=center colspan=2><b>VslVoy</b></td><td align=center><b>ETA</b></td><td align=center colspan=2><b>MBL #</b></td><td colspan=4 align=center><b>Free Hand<b></td><td colspan=4 align=center><b>Nomination</b></td><td align=center><b>Teus</b></td><td colspan=4 align=center><b>Container #</b></td><td align=center><b>Income</b></td></tr>";
                sendqry += "<tr><td colspan=2></td><td colspan=2></td><td></td><td colspan=2></td><td colspan=3  align=center><b>BL #</b></td><td colspan=1 align=center><b>CBM</b></td><td colspan=3 align=center><b>BL #</b></td><td colspan=1 align=center><b>CBM</b></td><td></td><td colspan=4></td><td></td></tr>";
            }

            dtrev = costtempobj.GetRevenueRpt(intBranchID, Convert.ToDateTime(Utility.fn_ConvertDatetime(txt_from.Text)), Convert.ToDateTime(Utility.fn_ConvertDatetime(txt_to.Text)));
            if(dtrev.Rows.Count > 0)
            {
                for (int i = 0; i <=dtrev.Rows.Count -1 ; i++)
			    {
                     sendqry += "<tr><td colspan=2>" + dtrev.Rows[i]["jobtype"].ToString() + " - " + dtrev.Rows[i]["jobno"].ToString() + "</td><td colspan=2> " + dtrev.Rows[i]["vslvoy"].ToString() + "</td><td>" + dtrev.Rows[i]["eta"].ToString() + "</td><td colspan=2 align=left>" + dtrev.Rows[i]["mblno"].ToString() + "</td><td colspan=3 align=left>" + dtrev.Rows[i]["freebl"].ToString() + "</td><td colspan=1>" + dtrev.Rows[i]["freecbm"].ToString() + "</td><td colspan=3 align=left>" + dtrev.Rows[i]["nombl"].ToString() + "</td><td colspan=1>" + dtrev.Rows[i]["nomcbm"].ToString() + "</td><td>" + dtrev.Rows[i]["tues"].ToString() + "</td><td colspan=4 align=left>" + dtrev.Rows[i]["cntrdtls"].ToString() + "</td><td>" + dtrev.Rows[i]["income"].ToString() + "</td></tr>";
			    }
                sendqry += "</body></table></html>";
            }
            Response.Buffer = true;
            Response.Charset = "UTF-8";
            Response.ContentType = "application/vnd.ms-excel";
            Response.Write(strHTML);
            //string message = "File Saved on Your Desktop. File Name is " + filename + "";
            //System.Text.StringBuilder sb = new System.Text.StringBuilder();
            //sb.Append("alertify.alert('");
            //sb.Append(message);
            //sb.Append("');");
            //ClientScript.RegisterOnSubmitStatement(this.GetType(), "alert", sb.ToString());
            //ScriptManager.RegisterStartupScript(btn_export, typeof(Button), "logix", "alertify.alert('File Saved on Your Desktop. File Name is "+filename+"');", true);
            ScriptManager.RegisterStartupScript(btn_export, typeof(Button), "logix", "alertify.alert('File Downloaded. File Name is " + filename + "');", true);
            Response.End();
        
        }
        protected void AgentSummary()
        {
            
            string filename="",tran="",strHTML = "",StrTranType="";
            string branch=Session["LoginBranchName"].ToString();
            string division = Session["LoginDivisionName"].ToString();
            double totalm1c=0,totalm2c=0,totalmc=0,totalamt1c=0,totalamt2c=0,totalamtc=0,totalm1l=0,totalm2l=0,totalml=0,totalamt1l=0,
            totalamt2l=0,totalamtl=0,totalm1f=0,totalm2f=0,totalmf=0,totalamt1f=0,totalamt2f=0,totalamtf=0;
            int totaltuesc=0,totaltuesl=0,totaltuesf=0;
            DataSet Ds= new DataSet();
            DataTable dtn= new DataTable();
            DataTable dtf= new DataTable();
            DataTable dta=new DataTable();
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            filename = branch + " - " + StrTranType;
            Response.Clear();
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.AddHeader("content-disposition", "attachment;filename="+filename+".xls");
            Response.Charset = "";
            Response.ContentType = "application/vnd.xls";
            StringWriter StringWriter = new System.IO.StringWriter();
            HtmlTextWriter HtmlTextWriter = new HtmlTextWriter(StringWriter);
            if(StrTranType=="FE")
            {
                tran = "Ocean Exports";
            }else if(StrTranType=="FI")
            {
                tran = "Ocean Imports";
            }else if(StrTranType=="AI")
            {
                tran = "Air Imports";
            }else if(StrTranType=="AI")
            {
                tran = "Air Exports";
            }

            
            strHTML = strHTML + "<html  xmlns:v=\"urn:schemas-microsoft-com:vml\"xmlns:o=\"urn:schemas-microsoft-com:office:office\" xmlns:x=\"urn:schemas-microsoft-com:office:excel\"xmlns=\"http://www.w3.org/TR/REC-html40\">";
                //strHTML = strHTML + "<html  xmlns:v=""urn:schemas-microsoft-com:vml""xmlns:o=""urn:schemas-microsoft-com:office:office"" xmlns:x=""urn:schemas-microsoft-com:office:excel""xmlns=""http://www.w3.org/TR/REC-html40"">";
        strHTML = strHTML + "<table BORDER=1 BORDERCOLOR=darkblue><tr><td  align=center colspan=5><B>" + division + " - " + branch + "</B></td></tr>";
        strHTML = strHTML + "<tr><td  align=center colspan=5><B>" + "Retention For N/F for the period of " + txt_from.Text + " to " + txt_to.Text + "</B></td></tr>";
        
            if(StrTranType == "FE" || StrTranType == "FI")
            {
                strHTML = strHTML + "<tr><td  align=center colspan=5><B>" + tran + " - Consol</B></td></tr>";
            strHTML = strHTML + "<tr><td><FONT FACE=tahoma size=2></td><td  align=center colspan=2><B>Controlled By Us</B></td><td  align=center colspan=2><B>Agent Controlled</B></td></tr>";
            strHTML = strHTML + "<tr><td  align=center ><B>Agent</B></td><td  align=center ><B>M3</B></td><td  align=center ><B>Retention</B></td><td  align=center ><B>M3</B></td><td  align=center ><B>Retention</B></td><td  align=center ><B>Total M3</B></td><td  align=center ><B>Total Retention</B></td><td  align=center ><B>Tues</B></td></tr>";
            Ds = costtempobj.SelAgentwiseVolume(Convert.ToDateTime(Utility.fn_ConvertDatetime(txt_from.Text)), Convert.ToDateTime(Utility.fn_ConvertDatetime(txt_to.Text)), "Consol", intBranchID, StrTranType);
            dtn = Ds.Tables[0];
            
            if(dtn.Rows.Count > 0)
            {
                for (int i = 0; i <=dtn.Rows.Count -1; i++)
			    {                    
                    //strHTML = strHTML & "<tr><td><FONT FACE=tahoma size=2>" & dtn.Rows(i).Item(0).ToString & "</td><td><FONT FACE=tahoma size=2>" & Format(dtn.Rows(i).Item(1), "0.000") & "</td><td><FONT FACE=tahoma size=2>" & Format(dtn.Rows(i).Item(2), "0.00") & "</td><td><FONT FACE=tahoma size=2>" & Format(dtn.Rows(i).Item(3), "0.000") & "</td><td><FONT FACE=tahoma size=2>" & Format(dtn.Rows(i).Item(4), "0.00") & "</td><td><FONT FACE=tahoma size=2>" & Format(dtn.Rows(i).Item(1) + dtn.Rows(i).Item(3), "0.000") & "</td><td><FONT FACE=tahoma size=2>" & Format(dtn.Rows(i).Item(2) + dtn.Rows(i).Item(4), "0.00") & "</td><td><FONT FACE=tahoma size=2>" & dtn.Rows(i).Item(5) & "</td></tr>"
                    strHTML = strHTML + "<tr><td><FONT FACE=tahoma size=2>" + dtn.Rows[i][0] + "</td><td><FONT FACE=tahoma size=2>" + Convert.ToDouble(dtn.Rows[i][1]).ToString("#0.000") + "</td><td><FONT FACE=tahoma size=2>" + Convert.ToDouble(dtn.Rows[i][2]).ToString("#0.00") + "</td><td><FONT FACE=tahoma size=2>" + Convert.ToDouble(dtn.Rows[i][3]).ToString("#0.000") + "</td><td><FONT FACE=tahoma size=2>" + Convert.ToDouble(dtn.Rows[i][4]).ToString("#0.00") + "</td><td><FONT FACE=tahoma size=2>" + (Convert.ToDouble(dtn.Rows[i][1]) + Convert.ToDouble(dtn.Rows[i][3])).ToString("#0.00") + "</td><td><FONT FACE=tahoma size=2>" + (Convert.ToDouble(dtn.Rows[i][2]) + Convert.ToDouble(dtn.Rows[i][4])).ToString("#0.00") + "</td><td><FONT FACE=tahoma size=2>" + dtn.Rows[i][5] + "</td></tr>";
                    totalm1c = totalm1c + Convert.ToDouble( dtn.Rows[i][1]);
                    totalamt1c = totalamt1c + Convert.ToDouble( dtn.Rows[i][2]);
                    totalm2c = totalm2c + Convert.ToDouble( dtn.Rows[i][3]);
                    totalamt2c = totalamt2c + Convert.ToDouble( dtn.Rows[i][4]);
                    totalmc = totalmc + Convert.ToDouble( dtn.Rows[i][1]) + Convert.ToDouble( dtn.Rows[i][3]);
                    totalamtc = totalamtc + Convert.ToDouble( dtn.Rows[i][2]) + Convert.ToDouble( dtn.Rows[i][4]);
                    totaltuesc = totaltuesc + Convert.ToInt32( dtn.Rows[i][5]);
			    }
                strHTML = strHTML + "<tr><td align=right><B>Total</B></td><td  align=center ><B>" + totalm1c.ToString("#0.000") + "</B></td><td  align=center ><B>" + totalamt1c.ToString("#0.00")  + "</B></td><td  align=center ><B>" + totalm2c.ToString("#0.000")  + "</B></td><td  align=center ><B>" + totalamt2c.ToString("#0.00")   + "</B></td><td  align=center ><B>" + totalmc.ToString("#0.00") + "</B></td><td  align=center ><B>" + totalamtc.ToString("#0.00") + "</B></td><td  align=center ><B>" + totaltuesc + "</B></td></tr>";
            }
            strHTML = strHTML + "<tr><td><FONT FACE=tahoma size=2></td><td><FONT FACE=tahoma size=2></td><td><FONT FACE=tahoma size=2></td><td><FONT FACE=tahoma size=2></td><td><FONT FACE=tahoma size=2></td></tr>";
            strHTML = strHTML + "<tr><td><FONT FACE=tahoma size=2></td><td><FONT FACE=tahoma size=2></td><td><FONT FACE=tahoma size=2></td><td><FONT FACE=tahoma size=2></td><td><FONT FACE=tahoma size=2></td></tr>";
            strHTML = strHTML + "<tr><td><FONT FACE=tahoma size=2></td><td><FONT FACE=tahoma size=2></td><td><FONT FACE=tahoma size=2></td><td><FONT FACE=tahoma size=2></td><td><FONT FACE=tahoma size=2></td></tr>";

            strHTML = strHTML + "<tr><td  align=center colspan=5><B>" + tran + " - LCL</B></td></tr>";
            strHTML = strHTML + "<tr><td><FONT FACE=tahoma size=2></td><td  align=center colspan=2><B>Controlled By Us</B></td><td  align=center colspan=2><B>Agent Controlled</B></td></tr>";
            strHTML = strHTML + "<tr><td  align=center ><B>Agent</B></td><td  align=center ><B>M3</B></td><td  align=center ><B>Retention</B></td><td  align=center ><B>M3</B></td><td  align=center ><B>Retention</B></td><td  align=center ><B>Total M3</B></td><td  align=center ><B>Total Retention</B><td><FONT FACE=tahoma size=2></tr>";
            Ds = costtempobj.SelAgentwiseVolume(Convert.ToDateTime(Utility.fn_ConvertDatetime(txt_from.Text)), Convert.ToDateTime(Utility.fn_ConvertDatetime(txt_to.Text)), "LCL", intBranchID, StrTranType);
            totalm1l = 0;
            totalamt1l = 0;
            totalm2l = 0;
            totalamt2l = 0;
            totalml = 0;
            totalamtl = 0;
            dtn = Ds.Tables[0];
            if(dtn.Rows.Count > 0)
            {
                for (int i = 0; i <=dtn.Rows.Count -1; i++)
			    {
                    strHTML = strHTML + "<tr><td><FONT FACE=tahoma size=2>" + dtn.Rows[i][0] + "</td><td><FONT FACE=tahoma size=2>" + Convert.ToDouble( dtn.Rows[i][1]).ToString("#0.000") + "</td><td><FONT FACE=tahoma size=2>" + Convert.ToDouble( dtn.Rows[i][2]).ToString("#0.000")  + "</td><td><FONT FACE=tahoma size=2>" + Convert.ToDouble( dtn.Rows[i][3]).ToString("#0.000")  + "</td><td><FONT FACE=tahoma size=2>" + Convert.ToDouble( dtn.Rows[i][4]).ToString("#0.00")  + "</td><td><FONT FACE=tahoma size=2>" + Convert.ToDouble(dtn.Rows[i][1].ToString() + dtn.Rows[i][3].ToString()).ToString("#0.00") + "</td><td><FONT FACE=tahoma size=2>" + Convert.ToDouble(dtn.Rows[i][2].ToString() + dtn.Rows[i][3].ToString()).ToString("#0.00") + "</td></tr>";
                    totalm1l = totalm1l + Convert.ToDouble(dtn.Rows[i][1]);
                    totalamt1l = totalamt1l + Convert.ToDouble(dtn.Rows[i][2]);
                    totalm2l = totalm2l + Convert.ToDouble(dtn.Rows[i][3]);
                    totalamt2l = totalamt2l + Convert.ToDouble(dtn.Rows[i][4]);
                    totalml = totalml + Convert.ToDouble(dtn.Rows[i][1]) + Convert.ToDouble(dtn.Rows[i][3]);
                    totalamtl = totalamtl + Convert.ToDouble(dtn.Rows[i][2]) + Convert.ToDouble(dtn.Rows[i][4]);
                }
                strHTML = strHTML + "<tr><td align=right><B>Total</B></td><td  align=center ><B>" + totalm1l.ToString("#0.000") + "</B></td><td  align=center ><B>" + totalamt1l.ToString("#0.00") + "</B></td><td  align=center ><B>" + totalm2l.ToString("#0.000") + "</B></td><td  align=center ><B>" + totalamt2l.ToString("#0.00") + "</B></td><td  align=center ><B>" + totalml.ToString("#0.000") + "</B></td><td  align=center ><B>" + totalamtl.ToString("#0.000") + "</B></td></tr>";
            }
            strHTML = strHTML + "<tr><td><FONT FACE=tahoma size=2></td><td><FONT FACE=tahoma size=2></td><td><FONT FACE=tahoma size=2></td><td><FONT FACE=tahoma size=2></td><td><FONT FACE=tahoma size=2></td></tr>";
            strHTML = strHTML + "<tr><td><FONT FACE=tahoma size=2></td><td><FONT FACE=tahoma size=2></td><td><FONT FACE=tahoma size=2></td><td><FONT FACE=tahoma size=2></td><td><FONT FACE=tahoma size=2></td></tr>";
            strHTML = strHTML + "<tr><td><FONT FACE=tahoma size=2></td><td><FONT FACE=tahoma size=2></td><td><FONT FACE=tahoma size=2></td><td><FONT FACE=tahoma size=2></td><td><FONT FACE=tahoma size=2></td></tr>";

            strHTML = strHTML + "<tr><td  align=center colspan=5><B>" + tran + " - FCL</B></td></tr>";
            strHTML = strHTML + "<tr><td><FONT FACE=tahoma size=2></td><td  align=center colspan=2><B>Controlled By Us</B></td><td  align=center colspan=2><B>Agent Controlled</B></td></tr>";
            strHTML = strHTML + "<tr><td  align=center ><B>Agent</B></td><td  align=center ><B>Tues</B></td><td  align=center ><B>Retention</B></td><td  align=center ><B>Tues</B></td><td  align=center ><B>Retention</B></td><td  align=center ><B>Total Tues</B></td><td  align=center ><B>Total Retention</B></td></tr>";
            Ds = costtempobj.SelAgentwiseVolume(Convert.ToDateTime(Utility.fn_ConvertDatetime(txt_from.Text)), Convert.ToDateTime(Utility.fn_ConvertDatetime(txt_to.Text)), "FCL", intBranchID, StrTranType);
            totalm1f = 0;
            totalamt1f = 0;
            totalm2f = 0;
            totalamt2f = 0;
            totalmf = 0;
            totalamtf = 0;
            dtn = Ds.Tables[0];

            if(dtn.Rows.Count > 0)
            {
                for (int i = 0; i <=dtn.Rows.Count -1; i++)
			    {
                    strHTML = strHTML + "<tr><td><FONT FACE=tahoma size=2>" + dtn.Rows[i][0] + "</td><td><FONT FACE=tahoma size=2>" + Convert.ToDouble( dtn.Rows[i][1]).ToString("#0") + "</td><td><FONT FACE=tahoma size=2>" + Convert.ToDouble( dtn.Rows[i][2]).ToString("#0.00")  + "</td><td><FONT FACE=tahoma size=2>" + Convert.ToDouble( dtn.Rows[i][3]).ToString("#0")  + "</td><td><FONT FACE=tahoma size=2>" + Convert.ToDouble( dtn.Rows[i][4]).ToString("#0.00")  + "</td><td><FONT FACE=tahoma size=2>" + (Convert.ToDouble(dtn.Rows[i][1].ToString()) + Convert.ToDouble(dtn.Rows[i][3].ToString())).ToString("#0.000") + "</td><td><FONT FACE=tahoma size=2>" + (Convert.ToDouble(dtn.Rows[i][2].ToString()) + Convert.ToDouble(dtn.Rows[i][3].ToString())).ToString("#0.00") + "</td></tr>";
                    totalm1f = totalm1f + Convert.ToDouble(dtn.Rows[i][1]);
                    totalamt1f = totalamt1f + Convert.ToDouble(dtn.Rows[i][2]);
                    totalm2f = totalm2f + Convert.ToDouble(dtn.Rows[i][3]);
                    totalamt2f = totalamt2f + Convert.ToDouble(dtn.Rows[i][4]);
                    totalmf = totalmf + Convert.ToDouble(dtn.Rows[i][1]) + Convert.ToDouble(dtn.Rows[i][3]);
                    totaltuesf = totaltuesf + Convert.ToInt32(dtn.Rows[i][1]) + Convert.ToInt32(dtn.Rows[i][3]);
                    totalamtf = totalamtf + Convert.ToDouble(dtn.Rows[i][2]) + Convert.ToDouble(dtn.Rows[i][4]);
                }
                strHTML = strHTML + "<tr><td align=right><B>Total</B></td><td  align=center ><B>" + totalm1f.ToString("#0.000") + "</B></td><td  align=center ><B>" + totalamt1f.ToString("#0.00") + "</B></td><td  align=center ><B>" + totalm2f.ToString("#0.000") + "</B></td><td  align=center ><B>" + totalamt2f.ToString("#0.00") + "</B></td><td  align=center ><B>" + totalmf.ToString("#0.000") + "</B></td><td  align=center ><B>" + totalamtf.ToString("#0.00") + "</B></td></tr>";
            }

            strHTML = strHTML + "<tr><td><FONT FACE=tahoma size=2></td><td><FONT FACE=tahoma size=2></td><td><FONT FACE=tahoma size=2></td><td><FONT FACE=tahoma size=2></td><td><FONT FACE=tahoma size=2></td></tr>";
            strHTML = strHTML + "<tr><td  align=center ><FONT FACE=tahoma size=2 color=darkblue><B>SUMMARY</B></td><td><FONT FACE=tahoma size=2></td><td><FONT FACE=tahoma size=2></td><td><FONT FACE=tahoma size=2></td><td><FONT FACE=tahoma size=2></td></tr>";
            strHTML = strHTML + "<tr><td  align=center ><FONT FACE=tahoma size=2 color=darkblue><B>Rentention ( Consol + LCL + FCL )</B></td><td  align=center ><FONT FACE=tahoma size=2 color=darkblue><B>" + (totalamtc + totalamtl + totalamtf).ToString("#0.00") + "</B></td><td><FONT FACE=tahoma size=2></td><td><FONT FACE=tahoma size=2></td><td><FONT FACE=tahoma size=2></td></tr>";
            strHTML = strHTML + "<tr><td  align=center ><FONT FACE=tahoma size=2 color=darkblue><B>Tues ( Consol + FCL )</B></td><td  align=center ><FONT FACE=tahoma size=2 color=darkblue><B>" + totaltuesc + totaltuesf + "</B></td><td><FONT FACE=tahoma size=2></td><td><FONT FACE=tahoma size=2></td><td><FONT FACE=tahoma size=2></td></tr>";
            strHTML = strHTML + "<tr><td  align=center ><FONT FACE=tahoma size=2 color=darkblue><B>CBM ( Consol + LCL )</B></td><td  align=center ><FONT FACE=tahoma size=2 color=darkblue><B>" + (totalmc + totalml).ToString("#0.00") + "</B></td><td><FONT FACE=tahoma size=2></td><td><FONT FACE=tahoma size=2></td><td><FONT FACE=tahoma size=2></td></tr>";

            strHTML = strHTML + "<tr><td><FONT FACE=tahoma size=2></td><td><FONT FACE=tahoma size=2></td><td><FONT FACE=tahoma size=2></td><td><FONT FACE=tahoma size=2></td><td><FONT FACE=tahoma size=2></td></tr>";
            strHTML = strHTML + "<tr><td><FONT FACE=tahoma size=2></td><td><FONT FACE=tahoma size=2></td><td><FONT FACE=tahoma size=2></td><td><FONT FACE=tahoma size=2></td><td><FONT FACE=tahoma size=2></td></tr>";
            strHTML = strHTML + "<tr><td><FONT FACE=tahoma size=2></td><td><FONT FACE=tahoma size=2></td><td><FONT FACE=tahoma size=2></td><td><FONT FACE=tahoma size=2></td><td><FONT FACE=tahoma size=2></td></tr>";

            strHTML = strHTML + "<tr><td  align=center colspan=5><B>" + tran + " - Consol</B></td></tr>";
            strHTML = strHTML + "<tr><td  align=center ><B>Agent</B></td><td  align=center ><B>Tues</B></td><td  align=center ><B>Retention</B></td><td><FONT FACE=tahoma size=2></td><td><FONT FACE=tahoma size=2></td></tr>";
            Ds = costtempobj.SelAgentwiseVolume(Convert.ToDateTime(Utility.fn_ConvertDatetime(txt_from.Text)), Convert.ToDateTime(Utility.fn_ConvertDatetime(txt_to.Text)), "Consol", intBranchID, StrTranType);
            dtn = Ds.Tables[1];
            if(dtn.Rows.Count > 0)
            {
                for (int i = 0; i <=dtn.Rows.Count -1 ; i++)
			    {
                    strHTML = strHTML + "<tr><td><FONT FACE=tahoma size=2>" + dtn.Rows[i][0] + "</td><td><FONT FACE=tahoma size=2>" + Convert.ToDouble(dtn.Rows[i][1]).ToString("#0.000") + "</td><td><FONT FACE=tahoma size=2>" + Convert.ToDouble(dtn.Rows[i][2]).ToString("#0.00") + "</td><td><FONT FACE=tahoma size=2></td><td><FONT FACE=tahoma size=2></td></tr>";
			    }
            }

            strHTML = strHTML + "<tr><td><FONT FACE=tahoma size=2></td><td><FONT FACE=tahoma size=2></td><td><FONT FACE=tahoma size=2></td><td><FONT FACE=tahoma size=2></td><td><FONT FACE=tahoma size=2></td></tr>";
            strHTML = strHTML + "<tr><td><FONT FACE=tahoma size=2></td><td><FONT FACE=tahoma size=2></td><td><FONT FACE=tahoma size=2></td><td><FONT FACE=tahoma size=2></td><td><FONT FACE=tahoma size=2></td></tr>";
            strHTML = strHTML + "<tr><td><FONT FACE=tahoma size=2></td><td><FONT FACE=tahoma size=2></td><td><FONT FACE=tahoma size=2></td><td><FONT FACE=tahoma size=2></td><td><FONT FACE=tahoma size=2></td></tr>";

            strHTML = strHTML + "<tr><td  align=center colspan=5><B>" + tran + " - LCL</B></td></tr>";
            strHTML = strHTML + "<tr><td  align=center ><B>Agent</B></td><td  align=center ><B>M3</B></td><td  align=center ><B>Retention</B></td><td><FONT FACE=tahoma size=2></td><td><FONT FACE=tahoma size=2></td></tr>";
            Ds = costtempobj.SelAgentwiseVolume(Convert.ToDateTime(Utility.fn_ConvertDatetime(txt_from.Text)), Convert.ToDateTime(Utility.fn_ConvertDatetime(txt_to.Text)), "LCL", intBranchID, StrTranType);
            dtn = Ds.Tables[1];
            if(dtn.Rows.Count > 0)
            {
                for (int i = 0; i <=dtn.Rows.Count -1 ; i++)
			    {
                    strHTML = strHTML + "<tr><td><FONT FACE=tahoma size=2>" + dtn.Rows[i][0] + "</td><td><FONT FACE=tahoma size=2>" + Convert.ToDouble(dtn.Rows[i][1]).ToString("#0.000") + "</td><td><FONT FACE=tahoma size=2>" + Convert.ToDouble(dtn.Rows[i][2]).ToString("#0.00") + "</td><td><FONT FACE=tahoma size=2></td><td><FONT FACE=tahoma size=2></td></tr>";
			    }
            }

            strHTML = strHTML + "<tr><td><FONT FACE=tahoma size=2></td><td><FONT FACE=tahoma size=2></td><td><FONT FACE=tahoma size=2></td><td><FONT FACE=tahoma size=2></td><td><FONT FACE=tahoma size=2></td></tr>";
            strHTML = strHTML + "<tr><td><FONT FACE=tahoma size=2></td><td><FONT FACE=tahoma size=2></td><td><FONT FACE=tahoma size=2></td><td><FONT FACE=tahoma size=2></td><td><FONT FACE=tahoma size=2></td></tr>";
            strHTML = strHTML + "<tr><td><FONT FACE=tahoma size=2></td><td><FONT FACE=tahoma size=2></td><td><FONT FACE=tahoma size=2></td><td><FONT FACE=tahoma size=2></td><td><FONT FACE=tahoma size=2></td></tr>";

            strHTML = strHTML + "<tr><td  align=center colspan=5><B>" + tran + " - FCL</B></td></tr>";
            strHTML = strHTML + "<tr><td  align=center ><B>Agent</B></td><td  align=center ><B>Tues</B></td><td  align=center ><B>Retention</B></td><td><FONT FACE=tahoma size=2></td><td><FONT FACE=tahoma size=2></td></tr>";
            Ds = costtempobj.SelAgentwiseVolume(Convert.ToDateTime(Utility.fn_ConvertDatetime(txt_from.Text)), Convert.ToDateTime(Utility.fn_ConvertDatetime(txt_to.Text)), "FCL", intBranchID, StrTranType);
            dtn = Ds.Tables[1];
            if(dtn.Rows.Count > 0)
            {
                for (int i = 0; i <=dtn.Rows.Count -1 ; i++)
			    {
                    strHTML = strHTML + "<tr><td><FONT FACE=tahoma size=2>" + dtn.Rows[i][0] + "</td><td><FONT FACE=tahoma size=2>" + Convert.ToDouble(dtn.Rows[i][1]).ToString("#0.000") + "</td><td><FONT FACE=tahoma size=2>" + Convert.ToDouble(dtn.Rows[i][2]).ToString("#0.00") + "</td><td><FONT FACE=tahoma size=2></td><td><FONT FACE=tahoma size=2></td></tr>";
			    }
            }
            strHTML = strHTML + "<tr><td><FONT FACE=tahoma size=2></td><td><FONT FACE=tahoma size=2></td><td><FONT FACE=tahoma size=2></td><td><FONT FACE=tahoma size=2></td><td><FONT FACE=tahoma size=2></td></tr>";
            strHTML = strHTML + "<tr><td><FONT FACE=tahoma size=2></td><td><FONT FACE=tahoma size=2></td><td><FONT FACE=tahoma size=2></td><td><FONT FACE=tahoma size=2></td><td><FONT FACE=tahoma size=2></td></tr>";
            strHTML = strHTML + "<tr><td><FONT FACE=tahoma size=2></td><td><FONT FACE=tahoma size=2></td><td><FONT FACE=tahoma size=2></td><td><FONT FACE=tahoma size=2></td><td><FONT FACE=tahoma size=2></td></tr>";
            }else if(StrTranType == "AE" || StrTranType == "AI")
            {
                 strHTML = strHTML + "<tr><td  align=center colspan=5>" + tran + " - " + StrTranType + "</td></tr>";
            strHTML = strHTML + "<tr><td><FONT FACE=tahoma size=2></td><td  align=center colspan=2>Controlled By Us</td><td  align=center colspan=2>Agent Controlled</td></tr>";
            strHTML = strHTML + "<tr><td><FONT FACE=tahoma size=2>Agent</td><td><FONT FACE=tahoma size=2>M3</td><td><FONT FACE=tahoma size=2>Retention</td><td><FONT FACE=tahoma size=2>M3</td><td><FONT FACE=tahoma size=2>Retention</td></tr>";
            Ds = costtempobj.SelAgentwiseVolume(Convert.ToDateTime(Utility.fn_ConvertDatetime(txt_from.Text)), Convert.ToDateTime(Utility.fn_ConvertDatetime(txt_to.Text)), StrTranType, intBranchID, StrTranType);
            dtn = Ds.Tables[1];
            if(dtn.Rows.Count > 0)
            {
                for (int i = 0; i <=dtn.Rows.Count -1 ; i++)
			    {
                    strHTML = strHTML + "<tr><td><FONT FACE=tahoma size=2>" + dtn.Rows[i][0] + "</td><td><FONT FACE=tahoma size=2>" + Convert.ToDouble(dtn.Rows[i][1]).ToString("#0.000") + "</td><td><FONT FACE=tahoma size=2>" + Convert.ToDouble(dtn.Rows[i][2]).ToString("#0.00") + "</td><td><FONT FACE=tahoma size=2></td><td><FONT FACE=tahoma size=2></td><td><FONT FACE=tahoma size=2>" + Convert.ToDouble(dtn.Rows[i][2]).ToString("#0.00")  + "</td></tr>";
			    }
            }
            strHTML = strHTML + "<tr><td><FONT FACE=tahoma size=2></td><td><FONT FACE=tahoma size=2></td><td><FONT FACE=tahoma size=2></td><td><FONT FACE=tahoma size=2></td><td><FONT FACE=tahoma size=2></td></tr>";
            strHTML = strHTML + "<tr><td><FONT FACE=tahoma size=2></td><td><FONT FACE=tahoma size=2></td><td><FONT FACE=tahoma size=2></td><td><FONT FACE=tahoma size=2></td><td><FONT FACE=tahoma size=2></td></tr>";
            strHTML = strHTML + "<tr><td><FONT FACE=tahoma size=2></td><td><FONT FACE=tahoma size=2></td><td><FONT FACE=tahoma size=2></td><td><FONT FACE=tahoma size=2></td><td><FONT FACE=tahoma size=2></td></tr>";

            strHTML = strHTML + "<tr><td  align=center colspan=5>" + tran + " - " + StrTranType + "</td></tr>";
            strHTML = strHTML + "<tr><td><FONT FACE=tahoma size=2>Agent</td><td><FONT FACE=tahoma size=2>M3</td><td><FONT FACE=tahoma size=2>Retention</td><td><FONT FACE=tahoma size=2></td><td><FONT FACE=tahoma size=2></td></tr>";
            Ds = costtempobj.SelAgentwiseVolume(Convert.ToDateTime(Utility.fn_ConvertDatetime(txt_from.Text)), Convert.ToDateTime(Utility.fn_ConvertDatetime(txt_to.Text)), StrTranType, intBranchID, StrTranType);
            dtn = Ds.Tables[1];
            if(dtn.Rows.Count > 0)
            {
                for (int i = 0; i <=dtn.Rows.Count -1 ; i++)
			    {
                    strHTML = strHTML + "<tr><td><FONT FACE=tahoma size=2>" + dtn.Rows[i][0] + "</td><td><FONT FACE=tahoma size=2>" + Convert.ToDouble(dtn.Rows[i][1]).ToString("#0.000") + "</td><td><FONT FACE=tahoma size=2>" + Convert.ToDouble(dtn.Rows[i][2]).ToString("#0.00") + "</td><td><FONT FACE=tahoma size=2></td><td><FONT FACE=tahoma size=2></td><td><FONT FACE=tahoma size=2>" + Convert.ToDouble(dtn.Rows[i][3]).ToString("#0.000")  + "</td><td><FONT FACE=tahoma size=2>" + Convert.ToDouble(dtn.Rows[i][4]).ToString("#0.00")  + "</td></tr>";
			    }
            }
            dtn = Ds.Tables[1];
            if(dtn.Rows.Count > 0)
            {
                for (int i = 0; i <=dtn.Rows.Count -1 ; i++)
			    {
                    strHTML = strHTML + "<tr><td><FONT FACE=tahoma size=2>" + dtn.Rows[i][0] + "</td><td><FONT FACE=tahoma size=2>" + Convert.ToDouble(dtn.Rows[i][1]).ToString("#0.000") + "</td><td><FONT FACE=tahoma size=2>" + Convert.ToDouble(dtn.Rows[i][2]).ToString("#0.00") + "</td><td><FONT FACE=tahoma size=2></td></tr>";
			    }
            }
            strHTML = strHTML + "<tr><td><FONT FACE=tahoma size=2></td><td><FONT FACE=tahoma size=2></td><td><FONT FACE=tahoma size=2></td><td><FONT FACE=tahoma size=2></td><td><FONT FACE=tahoma size=2></td></tr>";
            strHTML = strHTML + "<tr><td><FONT FACE=tahoma size=2></td><td><FONT FACE=tahoma size=2></td><td><FONT FACE=tahoma size=2></td><td><FONT FACE=tahoma size=2></td><td><FONT FACE=tahoma size=2></td></tr>";
            strHTML = strHTML + "<tr><td><FONT FACE=tahoma size=2></td><td><FONT FACE=tahoma size=2></td><td><FONT FACE=tahoma size=2></td><td><FONT FACE=tahoma size=2></td><td><FONT FACE=tahoma size=2></td></tr>";
        
            }
            strHTML = strHTML + "</FONT></table></html>";
            //Response.Clear();
            //Response.AddHeader("Content-Disposition", "Attachment;Filename=" + Filename + ".xls");
            Response.Buffer = true;
            Response.Charset = "UTF-8";
            Response.ContentType = "application/vnd.ms-excel";
            Response.Write(strHTML);
            //string message = "File Saved on Your Desktop. File Name is " + filename + "";
            //System.Text.StringBuilder sb = new System.Text.StringBuilder();
            //sb.Append("alertify.alert('");
            //sb.Append(message);
            //sb.Append("');");
            //ClientScript.RegisterOnSubmitStatement(this.GetType(), "alert", sb.ToString());
            //ScriptManager.RegisterStartupScript(btn_export, typeof(Button), "logix", "alertify.alert('File Saved on Your Desktop. File Name is "+filename+"');", true);
            ScriptManager.RegisterStartupScript(btn_export, typeof(Button), "logix", "alertify.alert('File Downloaded. File Name is " + filename + "');", true);
            Response.End();
        }

        protected void rd_mis_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                Session["From"] = txt_from.Text;
                Session["To"] = txt_to.Text;
                Response.Redirect("../MIS/JMIS2.aspx", true);
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }
    }
}