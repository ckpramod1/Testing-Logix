using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace logix.Reportasp
{
    public partial class Outstanding_online_rpt : System.Web.UI.Page
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
                //if (Session["LoginUserName"] == null || Session["LoginEmpId"] == null || Session["LoginDivisionId"] == null || Session["LoginBranchid"] == null)
                //{
                //    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alertify.alert('Session TimeOut');window.open('','_top');", true);
                //}

                //DataAccess.Masters.MasterDivision masterObj = new DataAccess.Masters.MasterDivision();
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
                        lbl_no.InnerText = dtadd.Rows[0]["phone"].ToString().ToUpper();
                    }
                }
                if (Request.QueryString.ToString().Contains("SubgroupID"))
                {
                    if (!string.IsNullOrEmpty(Request.QueryString["SubgroupID"]))
                    {
                        SubgroupID = Convert.ToInt32(Request.QueryString["SubgroupID"]);
                    }
                    else
                    {
                        SubgroupID = 0;
                    }
                    // SubgroupID = Convert.ToInt32(Request.QueryString["SubgroupID"]);
                }
                if (Request.QueryString.ToString().Contains("Ledger"))
                {
                    if (!string.IsNullOrEmpty(Request.QueryString["Ledger"]))
                    {
                        LedgerID = Convert.ToInt32(Request.QueryString["Ledger"]);
                    }
                    else
                    {
                        LedgerID = 0;
                    }

                }
                if (Request.QueryString.ToString().Contains("Date"))
                {
                    label_currentdate.InnerText = Request.QueryString["Date"].ToString().ToUpper().Trim();
                }
                else
                {
                    label_currentdate.InnerText = DateTime.Now.ToString("dd/MM/yyyy");
                }
                if (Request.QueryString.ToString().Contains("fcurr"))
                {
                    fcurr = Request.QueryString["fcurr"].ToString().ToUpper().Trim();
                }
                if (fcurr == "NO")
                {
                    th_fcurr.Visible = false;
                }
                if (Session["DT_out_print"] != null)
                {
                    DT_out_print = (DataTable)Session["DT_out_print"];

                    for (int i = 0; i < DT_out_print.Rows.Count; i++)
                    {

                        if (i == DT_out_print.Rows.Count - 1)
                        {
                            tr_outdetails.Text += "<tr><td style='padding:5px; border-left:1px solid #000; border-right:1px solid #000;'>&nbsp;</td>";
                        }
                        else
                        {
                            tr_outdetails.Text += "<tr><td style='padding:5px; border-left:1px solid #000; border-right:1px solid #000;'>" + (i + 1) + "</td>";
                        }
                        if (!string.IsNullOrEmpty(DT_out_print.Rows[i]["shortname"].ToString()))
                        {
                            string[] branch_inv = DT_out_print.Rows[i]["shortname"].ToString().Split('-');
                            if (branch_inv.Length > 0)
                            {
                                branch_invoice = branch_inv[1].ToString();
                            }
                        }

                        //tr_outdetails.Text += "<td style='padding:5px; border-right:1px solid #000;'>" + branch_invoice + "</td>";
                        tr_outdetails.Text += "<td style='padding:5px; border-right:1px solid #000;'>" + DT_out_print.Rows[i]["voudate"].ToString().ToUpper().Trim() + "</td>";
                        tr_outdetails.Text += "<td style='padding:5px; border-right:1px solid #000; white-space:nowrap;'>" + DT_out_print.Rows[i]["vouno"].ToString().ToUpper().Trim() + "</td>";
                        if (fcurr == "YES")
                        {
                            tr_outdetails.Text += "<td style='padding:5px; border-right:1px solid #000;'>" + DT_out_print.Rows[i]["fcurr"].ToString() + "</td>";
                            tr_outdetails.Text += " <td style='padding:5px; border-right:1px solid #000; text-align:right;'>" + Convert.ToDouble(DT_out_print.Rows[i]["famount"]).ToString("#,0.00") + "</td>";
                            tr_outdetails.Text += " <td style='padding:5px; border-right:1px solid #000; text-align:right;'>" + Convert.ToDouble(DT_out_print.Rows[i]["recefamount"]).ToString("#,0.00").ToUpper() + "</td>";
                            tr_outdetails.Text += " <td style='padding:5px; border-right:1px solid #000; text-align:right;'>" + Convert.ToDouble(DT_out_print.Rows[i]["foverdue"]).ToString("#,0.00") + "</td>";
                           /* if (i == 0)
                            {

                                tr_outdetails.Text += " <td style='padding:5px; border-right:1px solid #000; text-align:right;'>" + DT_out_print.Rows[i]["foverdue"].ToString() + "</td>";
                                DT_out_print.Rows[i]["Cummulative"] = Convert.ToDouble(DT_out_print.Rows[i]["foverdue"].ToString());
                            }
                            else
                            {
                                if (i == DT_out_print.Rows.Count - 1)
                                {
                                    tr_outdetails.Text += " <td style='padding:5px; border-right:1px solid #000; text-align:right;'>&nbsp;</td>";
                                }
                                else
                                {
                                    DT_out_print.Rows[i]["Cummulative"] = Convert.ToDouble(Convert.ToDouble(DT_out_print.Rows[i]["foverdue"].ToString()) + Convert.ToDouble(DT_out_print.Rows[i - 1]["Cummulative"].ToString()));
                                    tr_outdetails.Text += " <td style='padding:5px; border-right:1px solid #000; text-align:right;'>" + Convert.ToDouble(DT_out_print.Rows[i]["Cummulative"]).ToString("#,0.00") + "</td>";
                                }
                            }*/

                        }
                        else
                        {
                            tr_outdetails.Text += " <td style='padding:5px; border-right:1px solid #000; text-align:right;'>" + Convert.ToDouble(DT_out_print.Rows[i]["vamount"]).ToString("#,0.00").ToUpper() + "</td>";
                            tr_outdetails.Text += " <td style='padding:5px; border-right:1px solid #000; text-align:right;'>" + Convert.ToDouble(DT_out_print.Rows[i]["Receivedamount"]).ToString("#,0.00").ToUpper() + "</td>";
                            tr_outdetails.Text += " <td style='padding:5px; border-right:1px solid #000; text-align:right;'>" + Convert.ToDouble(DT_out_print.Rows[i]["amount"]).ToString("#,0.00").ToUpper() + "</td>";
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
                        }
                        tr_outdetails.Text += "<td style='padding:5px; border-right:1px solid #000;'>" + DT_out_print.Rows[i]["trantype"].ToString().ToUpper().Trim() + "</td>";
                        tr_outdetails.Text += "<td style='padding:5px; border-right:1px solid #000; word-break:break-word;'>" + DT_out_print.Rows[i]["mblno"].ToString().ToUpper().Trim() + "</td>";
                        tr_outdetails.Text += "<td style='padding:5px; border-right:1px solid #000; word-break:break-word;'>" + DT_out_print.Rows[i]["refno"].ToString().ToUpper().Trim() + "</td>";
                        tr_outdetails.Text += "<td style='padding:5px; border-right:1px solid #000; word-break:break-word;'>" + DT_out_print.Rows[i]["shipper"].ToString().ToUpper().Trim() + "</td>";
                        tr_outdetails.Text += "<td style='padding:5px; border-right:1px solid #000; word-break:break-word;'>" + DT_out_print.Rows[i]["consignee"].ToString().ToUpper().Trim() + "</td>";
                        tr_outdetails.Text += "<td style='padding:5px; border-right:1px solid #000;'>" + DT_out_print.Rows[i]["polcountry"].ToString().ToUpper().Trim() + "</td>";
                        tr_outdetails.Text += "<td style='padding:5px; border-right:1px solid #000;'>" + DT_out_print.Rows[i]["podcountry"].ToString().ToUpper().Trim() + "</td>";

                        if (DT_out_print.Rows[i]["containerno"].ToString().ToUpper().Trim().Length > 20)
                        {
                            //tr_outdetails.Text += "<td style='padding:5px; border-right:1px solid #000;'>" + DT_out_print.Rows[i]["containerno"].ToString().ToUpper().Trim().Substring(0, 20) + "</td>";
                        }
                        else
                        {
                            //tr_outdetails.Text += "<td style='padding:5px; border-right:1px solid #000;'>" + DT_out_print.Rows[i]["containerno"].ToString().ToUpper().Trim() + "</td>";
                        }

                        //tr_outdetails.Text += "<td style='padding:5px; border-right:1px solid #000;'>" + DT_out_print.Rows[i]["vendorrefno"].ToString().ToUpper().Trim() + "</td>";


                        tr_outdetails.Text += " <td style='padding:5px; border-right:1px solid #000; text-align:right;'>" + DT_out_print.Rows[i]["nodays"].ToString().ToUpper().Trim() + "</td>";
                        tr_outdetails.Text += "</tr>";
                    }
                    if (LedgerID != 0)
                    {
                       //keerthi DT_Ledgerageing = outsobj.OutStdageingNew(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginDivisionId"].ToString()), 0, SubgroupID, Session["FADbname"].ToString(), LedgerID,fcurr);

                        DT_Ledgerageing = outsobj.OutStdageingNew_new(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginDivisionId"].ToString()), 0, SubgroupID, Session["FADbname"].ToString(), LedgerID, fcurr);
                        tr_Ledgerageing.Text = "";
                        if (DT_Ledgerageing.Rows.Count > 0)
                        {
                            /*
                            tr_Ledgerageing.Text += "<tr><td style='font-size:12px; padding:5px; font-family:sans-serif, Geneva, sans-serif; border-left:1px solid #000;  border-bottom:1px solid #000;  border-right:1px solid #000;'>" + DT_Ledgerageing.Rows[0]["customer"].ToString().ToUpper() + "</td>";
                            tr_Ledgerageing.Text += "<td style='font-size:12px; padding:5px; font-family:sans-serif, Geneva, sans-serif; border-bottom:1px solid #000;  border-right:1px solid #000; text-align:right;'>" + (Convert.ToDouble(DT_Ledgerageing.Rows[0]["grt15"].ToString()) + Convert.ToDouble(DT_Ledgerageing.Rows[0]["grt1630"].ToString())).ToString("#,0.00").ToUpper() + "</td>";
                            tr_Ledgerageing.Text += "<td style='font-size:12px; padding:5px; font-family:sans-serif, Geneva, sans-serif; border-bottom:1px solid #000;  border-right:1px solid #000; text-align:right; white-space:nowrap;'>" + (Convert.ToDouble(DT_Ledgerageing.Rows[0]["grt3145"].ToString()) + Convert.ToDouble(DT_Ledgerageing.Rows[0]["grt4660"].ToString())).ToString("#,0.00").ToUpper() + "</td>";
                            tr_Ledgerageing.Text += "<td style='font-size:12px; padding:5px; font-family:sans-serif, Geneva, sans-serif; border-bottom:1px solid #000;  border-right:1px solid #000; text-align:right;'>" + Convert.ToDouble(DT_Ledgerageing.Rows[0]["grt6190"]).ToString("#,0.00").ToUpper() + "</td>";
                            tr_Ledgerageing.Text += "<td style='font-size:12px; padding:5px; font-family:sans-serif, Geneva, sans-serif; border-bottom:1px solid #000;  border-right:1px solid #000; text-align:right;'>" + Convert.ToDouble(DT_Ledgerageing.Rows[0]["grt91120"]).ToString("#,0.00").ToUpper() + "</td>";
                            tr_Ledgerageing.Text += "<td style='font-size:12px; padding:5px; font-family:sans-serif, Geneva, sans-serif; border-bottom:1px solid #000;  border-right:1px solid #000; text-align:right;'>" + Convert.ToDouble(DT_Ledgerageing.Rows[0]["grt121180"]).ToString("#,0.00").ToUpper() + "</td>";
                            tr_Ledgerageing.Text += "<td style='font-size:12px; padding:5px; font-family:sans-serif, Geneva, sans-serif; border-bottom:1px solid #000;  border-right:1px solid #000; text-align:right;'>" + Convert.ToDouble(DT_Ledgerageing.Rows[0]["grt181365"]).ToString("#,0.00").ToUpper() + "</td>";
                            tr_Ledgerageing.Text += "<td style='font-size:12px; padding:5px; font-family:sans-serif, Geneva, sans-serif; border-bottom:1px solid #000;  border-right:1px solid #000; text-align:right;'>" + Convert.ToDouble(DT_Ledgerageing.Rows[0]["grt366"]).ToString("#,0.00").ToUpper() + "</td>";
                            tr_Ledgerageing.Text += "<td style='font-size:12px; padding:5px; font-family:sans-serif, Geneva, sans-serif; border-bottom:1px solid #000;  border-right:1px solid #000; text-align:right;'>" + Convert.ToDouble(DT_Ledgerageing.Rows[0]["grttot"]).ToString("#,0.00").ToUpper() + "</td>";//DT_Ledgerageing.Rows[0]["grttot"].ToString().ToUpper()
                            //tr_Ledgerageing.Text += "<td style='font-size:12px; padding:5px; font-family:sans-serif, Geneva, sans-serif; border-bottom:1px solid #000;  border-right:1px solid #000;'>" + DT_Ledgerageing.Rows[0]["Ledger Balance"].ToString().ToUpper() + "</td></tr>";
                            */

                            //keerthi
                            tr_Ledgerageing.Text += "<tr><td style='font-size:12px; padding:5px; font-family:sans-serif, Geneva, sans-serif; border-left:1px solid #000;  border-bottom:1px solid #000;  border-right:1px solid #000;'>" + DT_Ledgerageing.Rows[0]["customer"].ToString().ToUpper() + "</td>";
                            tr_Ledgerageing.Text += "<td style='font-size:12px; padding:5px; font-family:sans-serif, Geneva, sans-serif; border-bottom:1px solid #000;  border-right:1px solid #000; text-align:right;'>" + Convert.ToDouble(DT_Ledgerageing.Rows[0]["less30"]).ToString("#,0.00").ToUpper() + "</td>";
                            tr_Ledgerageing.Text += "<td style='font-size:12px; padding:5px; font-family:sans-serif, Geneva, sans-serif; border-bottom:1px solid #000;  border-right:1px solid #000; text-align:right; white-space:nowrap;'>" + Convert.ToDouble(DT_Ledgerageing.Rows[0]["grt30"]).ToString("#,0.00").ToUpper() + "</td>";
                            tr_Ledgerageing.Text += "<td style='font-size:12px; padding:5px; font-family:sans-serif, Geneva, sans-serif; border-bottom:1px solid #000;  border-right:1px solid #000; text-align:right;'>" + Convert.ToDouble(DT_Ledgerageing.Rows[0]["grt45"]).ToString("#,0.00").ToUpper() + "</td>";
                            tr_Ledgerageing.Text += "<td style='font-size:12px; padding:5px; font-family:sans-serif, Geneva, sans-serif; border-bottom:1px solid #000;  border-right:1px solid #000; text-align:right;'>" + Convert.ToDouble(DT_Ledgerageing.Rows[0]["grt60"]).ToString("#,0.00").ToUpper() + "</td>";
                            tr_Ledgerageing.Text += "<td style='font-size:12px; padding:5px; font-family:sans-serif, Geneva, sans-serif; border-bottom:1px solid #000;  border-right:1px solid #000; text-align:right;'>" + Convert.ToDouble(DT_Ledgerageing.Rows[0]["grt75"]).ToString("#,0.00").ToUpper() + "</td>";
                            tr_Ledgerageing.Text += "<td style='font-size:12px; padding:5px; font-family:sans-serif, Geneva, sans-serif; border-bottom:1px solid #000;  border-right:1px solid #000; text-align:right;'>" + Convert.ToDouble(DT_Ledgerageing.Rows[0]["grt90"]).ToString("#,0.00").ToUpper() + "</td>";
                            tr_Ledgerageing.Text += "<td style='font-size:12px; padding:5px; font-family:sans-serif, Geneva, sans-serif; border-bottom:1px solid #000;  border-right:1px solid #000; text-align:right;'>" + Convert.ToDouble(DT_Ledgerageing.Rows[0]["grt120"]).ToString("#,0.00").ToUpper() + "</td>";
                            tr_Ledgerageing.Text += "<td style='font-size:12px; padding:5px; font-family:sans-serif, Geneva, sans-serif; border-bottom:1px solid #000;  border-right:1px solid #000; text-align:right;'>" + Convert.ToDouble(DT_Ledgerageing.Rows[0]["grttot"]).ToString("#,0.00").ToUpper() + "</td>";//DT_Ledgerageing.Rows[0]["grttot"].ToString().ToUpper()
                            //tr_Ledgerageing.Text += "<td style='font-size:12px; padding:5px; font-family:sans-serif, Geneva, sans-serif; border-bottom:1px solid #000;  border-right:1px solid #000;'>" + DT_Ledgerageing.Rows[0]["Ledger Balance"].ToString().ToUpper() + "</td></tr>";


                        }
                    }
                }
                if (LedgerID != 0)
                {
                    DT_Ledgerageing = master_ledger.GetLedgernamebyID(LedgerID, Session["FADbname"].ToString());
                    if (DT_Ledgerageing.Rows.Count > 0)
                    {
                        if (!string.IsNullOrEmpty(DT_Ledgerageing.Rows[0]["opsid"].ToString()))
                        {
                            CustomerID = Convert.ToInt32(DT_Ledgerageing.Rows[0]["opsid"].ToString());
                        }

                        Opstype = DT_Ledgerageing.Rows[0]["opstype"].ToString();
                        label_ledgername.Text = DT_Ledgerageing.Rows[0]["LNandPort"].ToString();
                        if (Opstype == "C" && CustomerID != 0)
                        {
                            DataTable DT_cust = master_cust.SPSelGetCustomerDetails(CustomerID);
                            if (DT_cust.Rows.Count > 0)
                            {
                                label_ledgername.Text = DT_cust.Rows[0]["customername"].ToString() + "<br />";
                                label_ledgername.Text += DT_cust.Rows[0]["address"].ToString() + ", ";
                                if (string.IsNullOrEmpty(DT_cust.Rows[0]["zip"].ToString()))
                                {
                                    label_ledgername.Text += DT_cust.Rows[0]["portname"].ToString() + "<br />";
                                }
                                else
                                {
                                    label_ledgername.Text += DT_cust.Rows[0]["portname"].ToString() + " - " + DT_cust.Rows[0]["zip"].ToString() + ", ";
                                }
                                label_contact_person.InnerText = DT_cust.Rows[0]["ptc"].ToString();
                                p_contact_mail.InnerText = DT_cust.Rows[0]["email"].ToString();
                                label_creditdays.InnerText = DT_cust.Rows[0]["creditdays"].ToString();
                                label_creditamt.InnerText = Convert.ToDouble(DT_cust.Rows[0]["creditamt"]).ToString("#,0.00");
                            }
                        }
                    }
                }

                DT_bank = master_branch.GetBankDetails(branchid);
                if (DT_bank.Rows.Count > 0)
                {
                    label_Bene_bank.InnerText = DT_bank.Rows[0]["bankname"].ToString();
                    label_bank_add.InnerText = DT_bank.Rows[0]["bankaddress"].ToString();
                    label_bankacno.InnerText = DT_bank.Rows[0]["acnos"].ToString();
                    label_ind_swiftcode.InnerText = DT_bank.Rows[0]["swiftcode"].ToString();

                    label_Beneficiary.InnerText = DT_bank.Rows[0]["favouring"].ToString();
                    label_USD_swiftcode.InnerText = DT_bank.Rows[0]["USDswiftcode"].ToString();
                }

            }
            catch (Exception ex)
            {
                System.Diagnostics.StackTrace trace = new System.Diagnostics.StackTrace(ex, true);
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + ex.Message.ToString() + " " + trace.GetFrame(0).GetFileLineNumber() + "');", true);
            }
        }
    }
}