using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace logix.Reportasp
{
    public partial class OutstandingReportForAll : System.Web.UI.Page
    {
        DataAccess.Masters.MasterDivision Master_div = new DataAccess.Masters.MasterDivision();
        DataAccess.LogDetails Obj_log = new DataAccess.LogDetails();
        DataAccess.Outstanding outsobj = new DataAccess.Outstanding();
        DataAccess.Masters.MasterBranch master_branch = new DataAccess.Masters.MasterBranch();
        DataAccess.FAMaster.MasterLedger master_ledger = new DataAccess.FAMaster.MasterLedger();
        DataAccess.Masters.MasterCustomer master_cust = new DataAccess.Masters.MasterCustomer();
        DataAccess.Masters.MasterDivision masterObj = new DataAccess.Masters.MasterDivision();
        DataTable dtadd = new DataTable();
        DataTable DT_out_print = new DataTable();
        DataTable DT_Ledgerageing = new DataTable();
        DataTable DT_bank = new DataTable();
        DataTable DT_ledgerdetails = new DataTable();
        string fcurr, Opstype;
        string branch_invoice = "";
        int branchid, SubgroupID, LedgerID, CustomerID;
        string subgroupname = "", groupname = "";
        protected void Page_Load(object sender, EventArgs e)
        {

            string Ccode = Convert.ToString(Session["Ccode"]);

            if (Ccode != "")
            {

                Master_div.GetDataBase(Ccode);
                Obj_log.GetDataBase(Ccode);
                outsobj.GetDataBase(Ccode);
                master_branch.GetDataBase(Ccode);
                master_ledger.GetDataBase(Ccode);
                master_cust.GetDataBase(Ccode);
                masterObj.GetDataBase(Ccode);



            }

            try
            {

              // DataAccess.Masters.MasterDivision masterObj = new DataAccess.Masters.MasterDivision();
                DataTable dtlogo = masterObj.Getlogo(Convert.ToInt32(Session["LoginDivisionId"]));
                if (dtlogo.Rows.Count > 0)
                {
                    byte[] logoimageBytes = ((byte[])dtlogo.Rows[0]["dlogo"]);
                    string base64String = Convert.ToBase64String(logoimageBytes);
                    lbl_img.ImageUrl = "data:image/png;base64," + base64String;
                }
                id_title.Text = Master_div.GetShortName(Convert.ToInt32(Session["LoginDivisionId"])).ToUpper().Trim();
                label_branchname.InnerText = Session["LoginDivisionName"].ToString().ToUpper().Trim();
                if (Request.QueryString.ToString().Contains("Branchid"))
                {
                    branchid = Convert.ToInt32(Request.QueryString["Branchid"]);
                    dtadd = Obj_log.GetCompanyNameAdd(Convert.ToInt32(Request.QueryString["Branchid"]));
                    if (dtadd.Rows.Count > 0)
                    {
                        label_address.InnerText = dtadd.Rows[0]["address"].ToString().ToUpper();
                        label_email.InnerText = dtadd.Rows[0]["email"].ToString().ToUpper();
                    }
                }
                if (Request.QueryString.ToString().Contains("SubgroupID"))
                {
                    SubgroupID = 0;
                    //  SubgroupID = Convert.ToInt32(Request.QueryString["SubgroupID"]);
                }
                if (Request.QueryString.ToString().Contains("Title"))
                {
                    groupname = Request.QueryString["Title"];
                    subgroupname = Request.QueryString["Subgroupname"];
                }
                if (Request.QueryString.ToString().Contains("Ledger"))
                {
                    LedgerID = 0;

                    // LedgerID = Convert.ToInt32(Request.QueryString["Ledger"]);
                }
                if (Request.QueryString.ToString().Contains("Date"))
                {
                    label_currentdate.InnerText = Request.QueryString["Date"].ToString().ToUpper().Trim();
                }
                if (Session["DT_out_print"] != null)
                {
                    DT_out_print = (DataTable)Session["DT_out_print"];

                    for (int i = 0; i < DT_out_print.Rows.Count; i++)
                    {

                        if (i == DT_out_print.Rows.Count - 1)
                        {
                            tr_outdetails.Text += "<tr><td style='padding: 5px 2px 5px 2px; border-left:1px solid #000; border-right:1px solid #000;' width='50px'>&nbsp;</td>";
                        }
                        else
                        {
                            tr_outdetails.Text += "<tr><td style='padding: 5px 2px 5px 2px; border-left:1px solid #000; border-right:1px solid #000;' width='120px'>" + (i + 1) + "</td>";
                        }
                       
                        if (!string.IsNullOrEmpty(DT_out_print.Rows[i]["shortname"].ToString()))
                        {
                            string[] branch_inv = DT_out_print.Rows[i]["shortname"].ToString().Split('-');
                            if (branch_inv.Length > 0)
                            {
                                branch_invoice = branch_inv[1].ToString();
                            }
                        }
                      //  tr_outdetails.Text += "<td style='padding: 5px 2px 5px 2px; border-right:1px solid #000;' width='80px'>" + branch_invoice + "</td>";
                        tr_outdetails.Text += "<td style='padding: 5px 2px 5px 2px; border-right:1px solid #000;' width='70px'>" + DT_out_print.Rows[i]["voudate"].ToString().ToUpper().Trim() + "</td>";
                        tr_outdetails.Text += "<td style='padding: 5px 2px 5px 2px; border-right:1px solid #000;' width='70px'>" + DT_out_print.Rows[i]["vouno"].ToString().ToUpper().Trim() + "</td>";
                        //Newly Added
                        tr_outdetails.Text += " <td style='padding:5px; border-right:1px solid #000; text-align:right;'>" + DT_out_print.Rows[i]["vamount"].ToString().ToUpper() + "</td>";
                        tr_outdetails.Text += " <td style='padding:5px; border-right:1px solid #000; text-align:right;'>" + DT_out_print.Rows[i]["Receivedamount"].ToString().ToUpper() + "</td>";
                        tr_outdetails.Text += " <td style='padding:5px; border-right:1px solid #000; text-align:right;'>" + DT_out_print.Rows[i]["amount"].ToString().ToUpper() + "</td>";
                        if (i == 0)
                        {
                            //tr_outdetails.Text += " <td style='padding:5px; border-right:1px solid #000; text-align:right;'>" + DT_out_print.Rows[i]["amount"].ToString().ToUpper() + "</td>";
                            DT_out_print.Rows[i]["Cummulative"] = DT_out_print.Rows[i]["amount"].ToString();
                        }
                        else
                        {
                            if (i == DT_out_print.Rows.Count - 1)
                            {
                                //tr_outdetails.Text += " <td style='padding:5px; border-right:1px solid #000; text-align:right;' id='tbl'>&nbsp;</td>";
                            }
                            else
                            {
                                DT_out_print.Rows[i]["Cummulative"] = (Convert.ToDouble(DT_out_print.Rows[i]["amount"].ToString()) + Convert.ToDouble(DT_out_print.Rows[i - 1]["Cummulative"].ToString())).ToString();
                                //tr_outdetails.Text += " <td style='padding:5px; border-right:1px solid #000; text-align:right;'>" + Convert.ToDouble(DT_out_print.Rows[i]["Cummulative"]).ToString("#,0.00") + "</td>";
                            }
                        }
                        tr_outdetails.Text += "<td style='padding: 5px 2px 5px 2px; border-right:1px solid #000;' width='70px'>" + DT_out_print.Rows[i]["fcurr"].ToString().ToUpper().Trim() + "</td>";
                        tr_outdetails.Text += "<td style='padding: 5px 2px 5px 2px; border-right:1px solid #000;' width='60px'>" + DT_out_print.Rows[i]["trantype"].ToString().ToUpper().Trim() + "</td>";
                        tr_outdetails.Text += "<td style='padding: 5px 2px 5px 2px; border-right:1px solid #000;' width='70px'>" + DT_out_print.Rows[i]["BPJ"].ToString().ToUpper().Trim() + "</td>";
                        tr_outdetails.Text += "<td style='padding:5px 2px 5px 2px; border-right:1px solid #000;  width='86px'  >" + DT_out_print.Rows[i]["mblno"].ToString().ToUpper().Trim() + "</td>";
                        tr_outdetails.Text += "<td style='padding: 5px 2px 5px 2px; border-right:1px solid #000;' width='60px'>" + DT_out_print.Rows[i]["refno"].ToString().ToUpper().Trim() + "</td>";
                        /*tr_outdetails.Text += "<td style='padding: 5px 2px 5px 2px; border-right:1px solid #000; word-break:break-word;' width='120px'>" + DT_out_print.Rows[i]["customer"].ToString().ToUpper().Trim() + "</td>";
                        tr_outdetails.Text += "<td style='padding: 5px 2px 5px 2px; border-right:1px solid #000;' width='110px'>" + DT_out_print.Rows[i]["voutype"].ToString().ToUpper().Trim() + "</td>";
                        tr_outdetails.Text += "<td style='padding: 5px 2px 5px 2px; border-right:1px solid #000;' width='120px'>" + DT_out_print.Rows[i]["vouno"].ToString().ToUpper().Trim() + "</td>";
                        tr_outdetails.Text += "<td style='padding: 5px 2px 5px 2px; border-right:1px solid #000;' width='70px'>" + DT_out_print.Rows[i]["voudate"].ToString().ToUpper().Trim() + "</td>";
                        if (DT_out_print.Rows[i]["vendorrefno"].ToString().ToUpper().Trim().Length > 20)
                        {
                            tr_outdetails.Text += "<td style='padding: 5px 2px 5px 2px; border-right:1px solid #000;' width='30px'>" + DT_out_print.Rows[i]["vendorrefno"].ToString().ToUpper().Trim().Substring(0, 20) + "</td>";
                        }
                        else
                        {
                            tr_outdetails.Text += "<td style='padding: 5px 2px 5px 2px; border-right:1px solid #000;' width='30px'>" + DT_out_print.Rows[i]["vendorrefno"].ToString().ToUpper().Trim() + "</td>";
                        }

                        tr_outdetails.Text += " <td style='padding: 5px 2px 5px 2px; border-right:1px solid #000; text-align:right;' width='40px'>" + DT_out_print.Rows[i]["amount"].ToString().ToUpper() + "</td>";*/
                        tr_outdetails.Text += "<td style='padding:5px 2px 5px 2px; border-right:1px solid #000; word-break:break-word;'>" + DT_out_print.Rows[i]["shipper"].ToString().ToUpper().Trim() + "</td>";
                        tr_outdetails.Text += "<td style='padding:5px 2px 5px 2px; border-right:1px solid #000; word-break:break-word;'>" + DT_out_print.Rows[i]["consignee"].ToString().ToUpper().Trim() + "</td>";
                        tr_outdetails.Text += "<td style='padding:5px 2px 5px 2px; border-right:1px solid #000;'>" + DT_out_print.Rows[i]["polcountry"].ToString().ToUpper().Trim() + "</td>";
                        tr_outdetails.Text += "<td style='padding:5px 2px 5px 2px; border-right:1px solid #000;'>" + DT_out_print.Rows[i]["podcountry"].ToString().ToUpper().Trim() + "</td>";
                        tr_outdetails.Text += " <td style='padding: 5px 2px 5px 2px; border-right:1px solid #000; text-align:right;' width='40px'>" + DT_out_print.Rows[i]["nodays"].ToString().ToUpper().Trim() + "</td>";


                        tr_outdetails.Text += "</tr>";
                    }
                }
                label_ledgername.Text = "Groupname :" + groupname + System.Environment.NewLine + "Subgroupname:" + subgroupname;

            }
            catch (Exception ex)
            {
                System.Diagnostics.StackTrace trace = new System.Diagnostics.StackTrace(ex, true);
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + ex.Message.ToString() + " " + trace.GetFrame(0).GetFileLineNumber() + "');", true);
            }


        }
    }
}