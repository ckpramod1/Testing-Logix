using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.Services;
using logix;
using System.Web.Services.Description;


namespace logix.Accounts
{
    public partial class OutstandingAdjustment : System.Web.UI.Page
    {
        int sgroupid = 0;
        int did, dy;
        string Str_Voutype;
        double Amount = 0;
        double money = 0;
        double adjustment;
        string dispyear, dy1;
        string pmtdtd = "N";
        string strtrantype;
        DateTime date1; //NewOne

        DataAccess.Accounts.Recipts Bank_Obj = new DataAccess.Accounts.Recipts();
        DataAccess.FAMaster.ReportView da_obj_rv = new DataAccess.FAMaster.ReportView();
        DataAccess.FAMaster.MasterLedger obj_mledger = new DataAccess.FAMaster.MasterLedger();
        DataAccess.Accounts.Approval Approveobj = new DataAccess.Accounts.Approval();
        DataAccess.Outstanding outsobj = new DataAccess.Outstanding();
        DataAccess.LogDetails da_obj_log = new DataAccess.LogDetails();
        DataAccess.Accounts.RcptpmtAdjustment obj_da_Adjust = new DataAccess.Accounts.RcptpmtAdjustment();
        DataAccess.LogDetails obj_da_Log = new DataAccess.LogDetails();
        DataAccess.LogDetails Logobj = new DataAccess.LogDetails();
        protected void Page_Load(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "SpanTagMoveInputBottom();MuiTextField();", true);


            string Ccode = Convert.ToString(Session["Ccode"]);

            if (Ccode != "")
            {

                Bank_Obj.GetDataBase(Ccode);
                da_obj_rv.GetDataBase(Ccode);
                obj_mledger.GetDataBase(Ccode);
                Approveobj.GetDataBase(Ccode);
                outsobj.GetDataBase(Ccode);
                da_obj_log.GetDataBase(Ccode);
                obj_da_Log.GetDataBase(Ccode);
                obj_da_Adjust.GetDataBase(Ccode);
                obj_da_Log.GetDataBase(Ccode);


                Logobj.GetDataBase(Ccode);
              
            }

            if (Session["LoginUserName"] == null || Session["LoginEmpId"] == null || Session["LoginDivisionId"] == null || Session["LoginBranchid"] == null)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alertify.alert('Session TimeOut');window.open('"+ Session["Site"].ToString() + "/','_top');", true);
            }
            else if (Session["StrTranType"] == null)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alertify.alert('Session TimeOut');window.open('"+ Session["Site"].ToString() + "/FormMain.aspx','_top');", true);
            }
            did = Convert.ToInt32(HttpContext.Current.Session["LoginDivisionid"].ToString());
            if (!IsPostBack)
            {
                Grd_Detail.DataSource = Utility.Fn_GetEmptyDataTable();
                Grd_Detail.DataBind();
            }
        }

        [WebMethod]
        public static List<string> GetCustomer(string prefix)
        {
            List<string> List_Result = new List<string>();
            DataAccess.Masters.MasterCustomer customerobj = new DataAccess.Masters.MasterCustomer();
            DataTable dt = new DataTable();
            dt = customerobj.GetLikeCustomer(prefix);
            List_Result = Utility.Fn_TableToList(dt, "customer", "customerid");
            return List_Result;
        }


        protected void txt_customer_TextChanged(object sender, EventArgs e)
        {
            if (txt_customer.Text.Trim().Length > 0)
            {
                if (hid_custid.Value.ToString() == "0")
                {
                    ScriptManager.RegisterStartupScript(txt_customer, typeof(TextBox), "OutStandingAdjustment", "alertify.alert('Select Correct Customer Name');", true);
                    txt_customer.Focus();
                    return;
                }
                ViewState["dtPayment"] = null;
                Fn_GetDetail();
            }
        }
        private void Fn_GetDetail()
        {
            GetYear();
            int a = 0, b = 0;
            int groupid, ledgerid = 0;
            int Vouyear = Convert.ToInt32(Session["LogYear"].ToString());
            string Str_CurrrentDate = DateTime.Now.ToString("dd/MM/yyyy");
            string dispname = "ledgername";
            DateTime FromDate;
            DateTime ToDate;
            dt1.Value = "01/04/" + Vouyear;
            dt2.Value = Str_CurrrentDate;
            //DataAccess.Masters.MasterCustomer obj_da_Customer = new DataAccess.Masters.MasterCustomer();
            FromDate = Convert.ToDateTime(Utility.fn_ConvertDate(dt1.Value.ToString()));
            ToDate = Convert.ToDateTime(Utility.fn_ConvertDate(dt2.Value.ToString()));
            DataTable obj_dt = new DataTable();
            DataTable dtj = new DataTable();
            DataTable dt_Tans = new DataTable();
            DataTable dt = new DataTable();



            Grd_Detail.DataSource = Utility.Fn_GetEmptyDataTable();
            Grd_Detail.DataBind();
            //obj_dt = obj_da_Customer.GetOutstandforCustomer(int.Parse(Session["LoginBranchid"].ToString()), int.Parse(hid_custid.Value.ToString()));
            //dt_Tans = da_obj_rv.FAselLedgergrd(Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(hid_custid.Value.ToString()), FromDate, ToDate, Session["FADbname"].ToString(),dispname);
            //dt = outsobj.OutStandingNewLedger(Convert.ToInt32(Session["LoginEmpId"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()), sgroupid,ToDate, int.Parse(hid_custid.Value.ToString()));
            DataTable dtl1 = new DataTable();
            dtl1 = obj_mledger.SelMasterLedger(int.Parse(hid_custid.Value.ToString()), Session["FADbname"].ToString(), Convert.ToInt32(Session["LoginBranchid"].ToString()));
            if (dtl1.Rows.Count > 0)
            {
                sgroupid = Convert.ToInt32(dtl1.Rows[0]["subgroupid"].ToString());
                hid_SubGroup.Value = sgroupid.ToString();
                Session["sgpid"] = sgroupid;
                groupid = Convert.ToInt32(dtl1.Rows[0]["groupid"].ToString());
                Session["gpid"] = groupid;


            }

            dt = outsobj.OutStandingNewLedger(Convert.ToInt32(Session["LoginEmpId"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()), sgroupid, ToDate, int.Parse(hid_custid.Value.ToString()));
            //if(dt.Rows.Count > 0)
            //{
            //    for (int i = 0; i < dt.Rows.Count; i++)
            //    {
            //        hid_lt.Value = dt.Rows[i]["ledgertype"].ToString();
            //    }
            //}
            //////////////////////////////////////////////
            DataTable dttemp2 = new DataTable();


            if (ViewState["dtPayment"] != null && !ViewState["dtPayment"].Equals("-1"))
            {
                dttemp2 = (DataTable)ViewState["dtPayment"];
                a = dttemp2.Rows.Count;
            }
            if (dt.Rows.Count > 0)
            {
                if (a == 0)
                {
                    dttemp2.Columns.Add("trantype", typeof(string));
                    dttemp2.Columns.Add("voutype", typeof(string));
                    dttemp2.Columns.Add("vouno", typeof(string));
                    dttemp2.Columns.Add("voudate", typeof(string));
                    dttemp2.Columns.Add("jobno", typeof(string));
                    dttemp2.Columns.Add("blno", typeof(string));
                    dttemp2.Columns.Add("osamount", typeof(string));
                    dttemp2.Columns.Add("noofdays", typeof(string));
                    dttemp2.Columns.Add("cust", typeof(string));
                    dttemp2.Columns.Add("Vouyear", typeof(string));
                    dttemp2.Columns.Add("Vouno1", typeof(string));
                    dttemp2.Columns.Add("Jrefno", typeof(string));
                    dttemp2.Columns.Add("Bid", typeof(string));
                    dttemp2.Columns.Add("Exrate", typeof(string));
                    dttemp2.Columns.Add("Fcurr", typeof(string));
                    dttemp2.Columns.Add("ledgertype", typeof(string));
                    dttemp2.Columns.Add("Refno", typeof(string));

                    // dttemp2.Columns.Add("adjustment", typeof(string));
                }

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    int rowIndex = 0;
                    DataRow dtrow = dttemp2.NewRow();
                    dtrow["trantype"] = dt.Rows[i]["trantype"].ToString();
                    dtrow["voutype"] = dt.Rows[i]["voutype"].ToString();
                    dtrow["voudate"] = dt.Rows[i]["voudate"].ToString();
                    dtrow["jobno"] = dt.Rows[i]["jobno"].ToString();
                    dtrow["blno"] = dt.Rows[i]["refno"].ToString().Trim();



                    if (dt.Rows[i][6].ToString() == "OPENING BALANCE")   //NEWLY ADDED BHUVI 
                    {
                        dtrow["blno"] = dt.Rows[i][3].ToString().Trim();
                    }

                    if (sgroupid == 65 || sgroupid == 59 || sgroupid == 44)
                    {
                        dtrow["osamount"] = dt.Rows[i]["famount"].ToString();
                        dtrow["vouno"] = dt.Rows[i]["vounoss"].ToString();
                        dtrow["Vouno1"] = dt.Rows[i]["vounoss"].ToString();
                        dtrow["exrate"] = dt.Rows[i]["exrate"].ToString();
                    }
                    else
                    {
                        dtrow["osamount"] = dt.Rows[i]["amount"].ToString();
                        dtrow["vouno"] = dt.Rows[i]["vounoss"].ToString();
                        dtrow["Vouno1"] = dt.Rows[i]["vounoss"].ToString();
                        dtrow["exrate"] = dt.Rows[i]["exrate"].ToString();
                    }
                    //  dtrow["osamount"] = dt.Rows[i][14].ToString();
                    dtrow["noofdays"] = dt.Rows[i]["nodays"].ToString();
                    dtrow["cust"] = "";
                    dtrow["Vouyear"] = dt.Rows[i]["vouyear"].ToString();
                    dtrow["Jrefno"] = dt.Rows[i]["refno"].ToString();
                    dtrow["Bid"] = dt.Rows[i]["bid"].ToString();


                    dtrow["fcurr"] = dt.Rows[i]["fcurr"].ToString();
                    dtrow["ledgertype"] = dt.Rows[i]["ledgertype"].ToString();
                    dtrow["Refno"] = dt.Rows[i]["vouno"].ToString();

                    //dtrow["adjustment"] = dt.Rows[i][8].ToString();
                    //obj_dt.Rows[i]["adjustment"] = ((TextBox)(Grd_Detail.Rows[i].FindControl("adjustment"))).Text;

                    //TextBox box1 = (TextBox)Grd_Detail.Rows[rowIndex].Cells[15].FindControl("adjustment");

                    //((TextBox)Grd_Detail.Rows[15].FindControl("adjustment")).Text = dt.Rows[i][8].ToString();
                    dttemp2.Rows.Add(dtrow);
                    //rowIndex++;
                }
                Grd_Detail.DataSource = dttemp2;
                Grd_Detail.DataBind();
                ViewState["dtPayment"] = dttemp2;
                //for (int j = 0; j < Grd_Detail.Rows.Count; j++)
                //{

                //    ((TextBox)Grd_Detail.Rows[j].FindControl("adjustment")).Text = Grd_Detail.Rows[j].Cells[6].Text.Trim();
                //    string money = ((TextBox)Grd_Detail.Rows[j].Cells[15].FindControl("adjustment")).Text;
                //}

            }

            dtj = Bank_Obj.GetRecPaymCalcjnrl_Journal(did, "R", "FA" + dispyear, int.Parse(hid_custid.Value.ToString()));
            DataTable dttemp3 = new DataTable();

            if (ViewState["dtPayment"] != null && !ViewState["dtPayment"].Equals("-1"))
            {
                dttemp3 = (DataTable)ViewState["dtPayment"];
                b = dttemp3.Rows.Count;
            }

            if (dtj.Rows.Count > 0)
            {
                if (b == 0)
                {
                    dttemp2.Columns.Add("trantype", typeof(string));
                    dttemp2.Columns.Add("voutype", typeof(string));
                    dttemp2.Columns.Add("vouno", typeof(string));
                    dttemp2.Columns.Add("voudate", typeof(string));
                    dttemp2.Columns.Add("jobno", typeof(string));
                    dttemp2.Columns.Add("blno", typeof(string));
                    dttemp2.Columns.Add("osamount", typeof(string));
                    dttemp2.Columns.Add("noofdays", typeof(string));
                    dttemp2.Columns.Add("cust", typeof(string));
                    dttemp2.Columns.Add("Vouyear", typeof(string));
                    dttemp2.Columns.Add("Vouno1", typeof(string));
                    dttemp2.Columns.Add("ledgertype", typeof(string));
                }

                for (int i = 0; i < dtj.Rows.Count; i++)
                {
                    DataRow dtrow = dttemp3.NewRow();
                    dtrow["trantype"] = dtj.Rows[i][0].ToString();
                    dtrow["voutype"] = dtj.Rows[i][1].ToString();
                    dtrow["vouno"] = "Inv - " + dtj.Rows[i][5].ToString();
                    dtrow["voudate"] = dtj.Rows[i][3].ToString();
                    dtrow["jobno"] = dtj.Rows[i][4].ToString();
                    dtrow["blno"] = "";
                    dtrow["osamount"] = dtj.Rows[i][6].ToString();
                    dtrow["noofdays"] = dtj.Rows[i][7].ToString();
                    dtrow["cust"] = dtj.Rows[i][8].ToString();
                    dtrow["Vouyear"] = dtj.Rows[i][9].ToString();
                    dtrow["Vouno1"] = "";
                    dtrow["ledgertype"] = dtj.Rows[i]["ledgertype"].ToString();
                    dttemp3.Rows.Add(dtrow);
                }
                Grd_Detail.DataSource = dttemp3;
                Grd_Detail.DataBind();
                ViewState["dtPayment"] = dttemp3;
            }
            //foreach (GridViewRow row in Grd_Detail.Rows)
            //{
            //    TextBox txtBox = (TextBox)Grd_Detail.Rows[row.RowIndex].FindControl("adjustment");
            //    CheckBox chk = (CheckBox)row.FindControl("Chk_Select");
            //    if (chk.Checked == true)
            //    {
            //        txtBox.Enabled = true;
            //    }
            //    else
            //    {
            //        txtBox.Enabled = false;
            //    }
            //}
            //Grd_Detail.DataSource = obj_dt;
            //Grd_Detail.DataBind();
        }
        protected void btn_update_Click(object sender, EventArgs e)//// 19-07-2022 hari
        {

            int refid;
            if (txt_total.Text != "0" && txt_total.Text != "0.00")
            {
                ScriptManager.RegisterStartupScript(btn_update, typeof(TextBox), "OutStandingAdjustment", "alertify.alert('Adjustment Should be equal with Debit and Credit');", true);
                return;
            }
            double amountinr = 0, fcamt, fcexrate, amt = 0;
            foreach (GridViewRow fcrow in Grd_Detail.Rows)
            {
                if (fcrow.Cells[14].Text == "&nbsp;")
                {
                    fcrow.Cells[14].Text = Session["Basecurr"].ToString();
                }
                
                if (Session["Basecurr"].ToString() != fcrow.Cells[14].Text)       //NewOne    //06/07/2023
                {
                    fcamt = double.Parse(fcrow.Cells[6].Text);       //NewOne
                    fcexrate = double.Parse(fcrow.Cells[13].Text);

                    amountinr = fcamt * fcexrate;
                    amt = amt + amountinr;
                }
            }
            if (amt != 0)
            {
                ScriptManager.RegisterStartupScript(btn_update, typeof(TextBox), "OutStandingAdjustment", "alertify.alert('Adjusted " + Session["Basecurr"].ToString() + " Amount is mismatch');", true);
                return;

            }


            if (hid_custid.Value.ToString() != "0")
            {


                int int_Empid = int.Parse(Session["LoginEmpId"].ToString());
                //int int_bid = int.Parse(Session["LoginBranchid"].ToString());
                //DataAccess.Accounts.RcptpmtAdjustment obj_da_Adjust = new DataAccess.Accounts.RcptpmtAdjustment();
                //DataAccess.LogDetails obj_da_Log = new DataAccess.LogDetails();
                bool Check = false;
                refid = obj_da_Adjust.osadjustmenthead_new(int_Empid, Convert.ToInt16(Session["LoginBranchid"]));



                foreach (GridViewRow row1 in Grd_Detail.Rows)
                {
                    CheckBox chk = (CheckBox)row1.FindControl("Chk_Select");
                    TextBox txtBox = (TextBox)Grd_Detail.Rows[row1.RowIndex].FindControl("adjustment");

                    if (txtBox.Text == "")
                    {
                        txtBox.Text = "0";

                    }
                    if (chk.Checked == true || txtBox.Text != "0")
                    {
                        Check = true;
                        string Str_Voutypenew = row1.Cells[1].Text;
                        hid_Bid.Value = row1.Cells[12].Text;
                        money = double.Parse(row1.Cells[6].Text);
                        adjustment = double.Parse(txtBox.Text);

                        if (Math.Abs(adjustment) > Math.Abs(money))
                        {
                            ScriptManager.RegisterStartupScript(btn_update, typeof(TextBox), "OutStandingAdjustment", "alertify.alert('Adjustment Amount should be less than Voucher amount');", true);
                            return;
                        }
                        string jrefno = (row1.Cells[5].Text.ToString());

                        
                        //newly altered start


                        if (jrefno == "OPENING BALANCE")
                        {
                            Str_Voutype = "Q";
                        }

                        if (Str_Voutypenew == "Invoices" || Str_Voutypenew == "Sales Invoice")
                        {
                            if ((Str_Voutypenew == "Invoices" || Str_Voutypenew == "Sales Invoice") && row1.Cells[0].Text.ToString() == "OP")
                            {
                                Str_Voutype = "OI";
                            }
                            else
                            {
                                Str_Voutype = "I";
                            }
                        }
                        else if (Str_Voutypenew == "Credit Note Operation" || Str_Voutypenew == "Credit Note - Operations" || Str_Voutypenew == "Purchase Invoice")
                        {
                            if ((Str_Voutypenew == "Credit Note Operation" || Str_Voutypenew == "Credit Note - Operations" || Str_Voutypenew == "Purchase Invoice") && row1.Cells[0].Text.ToString() == "OP")
                            {
                                Str_Voutype = "OP";
                            }
                            else
                            {
                                Str_Voutype = "P";
                            }
                        }
                        else if (Str_Voutypenew == "Admin Purchase Invoice")
                        {
                            if (Str_Voutypenew == "Admin Purchase Invoice" && row1.Cells[0].Text.ToString() == "OP")
                            {
                                Str_Voutype = "OS";
                            }
                            else
                            {
                                Str_Voutype = "S";
                            }
                        }
                        else if (Str_Voutypenew == "Admin Sales Invoice")
                        {
                            if (Str_Voutypenew == "Admin Sales Invoice" && row1.Cells[0].Text.ToString() == "OP")
                            {
                                Str_Voutype = "OX";
                            }
                            else
                            {
                                Str_Voutype = "X";
                            }
                        }
                        else if (Str_Voutypenew == "Journal")
                        {
                            Str_Voutype = "J";                      
                        }
                        else if (Str_Voutypenew == "OSSI")
                        {
                            if (Str_Voutypenew == "OSSI" && row1.Cells[0].Text.ToString() == "OP")
                            {
                                Str_Voutype = "OD";
                            }
                            else
                            {
                                Str_Voutype = "D";
                            }
                        }
                        else if (Str_Voutypenew == "OSPI")
                        {
                            if (Str_Voutypenew == "OSPI" && row1.Cells[0].Text.ToString() == "OP")
                            {
                                Str_Voutype = "OC";
                            }
                            else
                            {
                                Str_Voutype = "C";
                            }
                        }
                        else if (Str_Voutypenew == "Credit Note - Others" || Str_Voutypenew == "Credit Note")
                        {
                            if ((Str_Voutypenew == "Credit Note - Others" || Str_Voutypenew == "Credit Note") && row1.Cells[0].Text.ToString() == "OP")
                            {
                                Str_Voutype = "OE";
                            }
                            else
                            {
                                Str_Voutype = "E";
                            }
                        }
                        else if (Str_Voutypenew == "Debit Note - Others" || Str_Voutypenew == "Debit Note")
                        {
                            if ((Str_Voutypenew == "Debit Note - Others" || Str_Voutypenew == "Debit Note") && row1.Cells[0].Text.ToString() == "OP")
                            {
                                Str_Voutype = "OV";
                            }
                            else
                            {
                                Str_Voutype = "V";
                            }
                        }
                        else if (Str_Voutypenew == "BOS" || Str_Voutypenew == "Bill Of Supply")
                        {
                            if ((Str_Voutypenew == "BOS" || Str_Voutypenew == "Bill Of Supply") && row1.Cells[0].Text.ToString() == "OP")
                            {
                                Str_Voutype = "OB";
                            }
                            else
                            {
                                Str_Voutype = "B";
                            }
                        }
                        // Added For Reim and FC vouchers Vino on 26-09-2023
                        else if (Str_Voutypenew == "Reim" || Str_Voutypenew == "Reimbursement")
                        {
                            if ((Str_Voutypenew == "Reim" || Str_Voutypenew == "Reimbursement") && row1.Cells[0].Text.ToString() == "OP")
                            {
                                Str_Voutype = "OR";
                            }
                            else
                            {
                                Str_Voutype = "R";
                            }
                        }
                        else if (Str_Voutypenew == "Invoice FC" || Str_Voutypenew == "Sales Invoice OC")
                        {
                            if ((Str_Voutypenew == "Invoice FC" || Str_Voutypenew == "Sales Invoice OC") && row1.Cells[0].Text.ToString() == "OP")
                            {
                                Str_Voutype = "OF";
                            }
                            else
                            {
                                Str_Voutype = "F";
                            }
                        }
                        else if (Str_Voutypenew == "Credit Note - Operations FC" || Str_Voutypenew == "Purchase Invoice OC")
                        {
                            if ((Str_Voutypenew == "Credit Note - Operations FC" || Str_Voutypenew == "Purchase Invoice OC") && row1.Cells[0].Text.ToString() == "OP")
                            {
                                Str_Voutype = "OG";
                            }
                            else
                            {
                                Str_Voutype = "G";
                            }
                        }
                        else if (Str_Voutypenew == "BOS FC" || Str_Voutypenew == "Bill Of Supply FC" || Str_Voutypenew == "Bill Of Supply OC")
                        {
                            if ((Str_Voutypenew == "BOS FC" || Str_Voutypenew == "Bill Of Supply FC" || Str_Voutypenew == "Bill Of Supply OC") && row1.Cells[0].Text.ToString() == "OP")
                            {
                                Str_Voutype = "OH";
                            }
                            else
                            {
                                Str_Voutype = "H";
                            }
                        }
                        else if (Str_Voutypenew == "OSDN Reimbursement")
                        {
                            if ((Str_Voutypenew == "OSDN Reimbursement") && row1.Cells[0].Text.ToString() == "OP")
                            {
                                Str_Voutype = "OK";
                            }
                            else
                            {
                                Str_Voutype = "K";
                            }
                        }
                        else if (Str_Voutypenew == "OSCN Reimbursement")
                        {
                            if ((Str_Voutypenew == "OSCN Reimbursement") && row1.Cells[0].Text.ToString() == "OP")
                            {
                                Str_Voutype = "OL";
                            }
                            else
                            {
                                Str_Voutype = "L";
                            }
                        }
                        // End

                        else if (Str_Voutypenew == "Cash Payment")
                        {
                            Str_Voutype = "CP";
                            pmtdtd = "S";
                        }
                        else if (Str_Voutypenew == "Cash receipt" || Str_Voutypenew == "Cash Receipt")
                        {
                            Str_Voutype = "CR";
                            pmtdtd = "S";
                        }
                        else if (Str_Voutypenew == "Bank Payment" || Str_Voutypenew == "Direct Payment")
                        {
                            Str_Voutype = "BP";
                            pmtdtd = "S";
                        }
                        else if (Str_Voutypenew == "Bank receipt" || Str_Voutypenew == "Bank Receipt")
                        {
                            Str_Voutype = "BR";
                            pmtdtd = "S";
                        }
                        else if (Str_Voutypenew == "Receipt - Petty Cash" || Str_Voutypenew == "Petty Cash")
                        {
                            Str_Voutype = "PR";
                            pmtdtd = "S";
                        }
                        else if (Str_Voutypenew == "Remittance-Payment" || Str_Voutypenew == "Remittance Payment")
                        {
                            Str_Voutype = "RP";
                            pmtdtd = "S";
                        }
                        else if (Str_Voutypenew == "Remittance-Receipt" || Str_Voutypenew == "Remittance Receipt")
                        {
                            Str_Voutype = "RR";
                            pmtdtd = "S";
                        }
                        else if (Str_Voutypenew == "ADCN")
                        {
                            Str_Voutype = "T";
                        }



                        if (Str_Voutype == "J")
                        {
                            Amount = double.Parse(txtBox.Text.ToString());
                        }
                        else
                        {
                            //Amount = double.Parse(row.Cells[6].Text.ToString());
                            Amount = double.Parse(txtBox.Text.ToString());
                            //Amount = double.Parse(row.Cells[15].FindControl("adjustment").ToString());
                        }


                        //   double Amount = double.Parse(row.Cells[7].Text.ToString());
                        int int_vouyear = int.Parse(Grd_Detail.DataKeys[row1.RowIndex].Values[0].ToString());
                        int int_Vouno = int.Parse(row1.Cells[10].Text.ToString());
                        // string jrefno=(row.Cells[5].Text.ToString());
                        string fcurr = row1.Cells[14].Text.ToString();
                        double exrate = Convert.ToDouble(row1.Cells[13].Text.ToString());
                        string vendorref = row1.Cells[5].Text.ToString();  //newly added for bhuvi
                        string WIZvouno = row1.Cells[18].Text.ToString();
                        hid_lt.Value = row1.Cells[15].Text.ToString();

                        if (jrefno == "&nbsp;")
                        {
                            jrefno = "";
                        }

                        if (hid_lt.Value == "&nbsp;")
                        {
                            hid_lt.Value = "";
                        }
                        //if (Amount > 0)        
                        //{
                        //    if (Str_Voutype == "I" || Str_Voutype == "D" ||Str_Voutype == "V")
                        //    {
                        //        obj_da_Adjust.insertRcptPmt_new(-1, 'R', int_Vouno, char.Parse(Str_Voutype), int_vouyear, Convert.ToInt16(hid_Bid.Value), Amount, Amount, 'Y', int_vouyear, int.Parse(hid_SubGroup.Value), int.Parse(hid_custid.Value.ToString()), hid_lt.Value, jrefno);    
                        //        obj_da_Log.InsLogDetail(int_Empid, 8201, 1, Convert.ToInt16(hid_Bid.Value), Str_Voutype + int_Vouno + " Manually Adjusted");    
                        //     }
                        //    else
                        //    {
                        //        obj_da_Adjust.insertRcptPmt_new(-1, 'P', int_Vouno, char.Parse(Str_Voutype), int_vouyear, Convert.ToInt16(hid_Bid.Value), Amount, Amount, 'Y', int_vouyear, int.Parse(hid_SubGroup.Value), int.Parse(hid_custid.Value.ToString()), hid_lt.Value, jrefno);    
                        //        obj_da_Log.InsLogDetail(int_Empid, 8201, 1, Convert.ToInt16(hid_Bid.Value), Str_Voutype + int_Vouno + " Manually Adjusted");    
                        //    }
                        //}
                        //else
                        //{
                        //if (Amount > 0)
                        //{
                        //obj_da_Adjust.insertRcptPmt_new(-1, 'C', int_Vouno, char.Parse(Str_Voutype), int_vouyear, Convert.ToInt16(hid_Bid.Value), Math.Abs(Amount),Math.Abs(Amount), 'Y', int_vouyear, int.Parse(hid_SubGroup.Value), int.Parse(hid_custid.Value.ToString()), hid_lt.Value, jrefno);  
                       
                        if (pmtdtd == "S")
                        {
                            //ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.WebControls.Button), "   ", "alertify.alert('Don't Select " + Str_Voutypenew + " Amounts ');", true);
                            ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.WebControls.Button), "   ", "alertify.alert('Do Not Select " + Str_Voutypenew + " Amount ');", true);
                            return;
                        }
                        else
                        {
                            //obj_da_Adjust.insertRcptPmt_new(-1, 'C', int_Vouno, Str_Voutype.ToString(), int_vouyear, Convert.ToInt16(hid_Bid.Value), Math.Abs(money), Math.Abs(Amount), 'Y', int_vouyear, int.Parse(hid_SubGroup.Value), int.Parse(hid_custid.Value.ToString()), hid_lt.Value, jrefno, fcurr, exrate, vendorref, refid);   //NewOne //22/11/2022

                            //    //newly aded on 17 nov 2022
                            //    Approveobj.UpdLedgerOPBreakup4adjustment(int_Vouno, Str_Voutype.ToString(), int_vouyear, Convert.ToInt16(hid_Bid.Value), -1, 'C', int_vouyear, Math.Abs(Amount), "", 0.0, jrefno, "");

                            //    obj_da_Log.InsLogDetail(int_Empid, 8201, 1, Convert.ToInt16(hid_Bid.Value), Str_Voutype + int_Vouno + " Manually Adjusted");
                            ////}
                            //}
                        }
                    }
                }
                if (pmtdtd != "S")
                {
                    foreach (GridViewRow row in Grd_Detail.Rows)
                    {
                        CheckBox chk = (CheckBox)row.FindControl("Chk_Select");
                        TextBox txtBox = (TextBox)Grd_Detail.Rows[row.RowIndex].FindControl("adjustment");

                        if (txtBox.Text == "")
                        {
                            txtBox.Text = "0";

                        }
                        if (chk.Checked == true || txtBox.Text != "0")
                        {
                            Check = true;
                            string Str_Voutypenew = row.Cells[1].Text;
                            hid_Bid.Value = row.Cells[12].Text;
                            money = double.Parse(row.Cells[6].Text);
                            adjustment = double.Parse(txtBox.Text);

                            date1 = Convert.ToDateTime(row.Cells[3].Text);      //NewOne     
                            int jmonth = date1.Month;

                            if (Math.Abs(adjustment) > Math.Abs(money))
                            {
                                ScriptManager.RegisterStartupScript(btn_update, typeof(TextBox), "OutStandingAdjustment", "alertify.alert('Adjustment Amount should be less than Voucher amount');", true);
                                return;
                            }
                            string jrefno = row.Cells[5].Text.ToString();

                            
                            //newly altered start


                            if (jrefno == "OPENING BALANCE")
                            {
                                Str_Voutype = "Q";
                            }

                            if (Str_Voutypenew == "Invoices" || Str_Voutypenew == "Sales Invoice")
                            {
                                if ((Str_Voutypenew == "Invoices" || Str_Voutypenew == "Sales Invoice") && row.Cells[0].Text.ToString() == "OP")
                                {
                                    Str_Voutype = "OI";
                                }

                                else
                                {
                                    Str_Voutype = "I";
                                }

                            }
                            else if (Str_Voutypenew == "Credit Note Operation" || Str_Voutypenew == "Credit Note - Operations" || Str_Voutypenew == "Purchase Invoice")
                            {
                                if ((Str_Voutypenew == "Credit Note Operation" || Str_Voutypenew == "Credit Note - Operations" || Str_Voutypenew == "Purchase Invoice") && row.Cells[0].Text.ToString() == "OP")
                                {
                                    Str_Voutype = "OP";
                                }
                                else
                                {
                                    Str_Voutype = "P";
                                }

                            }
                            else if (Str_Voutypenew == "Admin Purchase Invoice")
                            {

                                if (Str_Voutypenew == "Admin Purchase Invoice" && row.Cells[0].Text.ToString() == "OP")
                                {
                                    Str_Voutype = "OS";
                                }
                                else
                                {
                                    Str_Voutype = "S";
                                }

                            }
                            else if (Str_Voutypenew == "Admin Sales Invoice")
                            {
                                if (Str_Voutypenew == "Admin Sales Invoice" && row.Cells[0].Text.ToString() == "OP")
                                {
                                    Str_Voutype = "OX";
                                }
                                else
                                {

                                    Str_Voutype = "X";
                                }


                            }
                            else if (Str_Voutypenew == "Journal")
                            {



                                Str_Voutype = "J";
                                // }

                            }
                            else if (Str_Voutypenew == "OSSI")
                            {
                                if (Str_Voutypenew == "OSSI" && row.Cells[0].Text.ToString() == "OP")
                                {
                                    Str_Voutype = "OD";
                                }
                                else
                                {

                                    Str_Voutype = "D";
                                }

                            }
                            else if (Str_Voutypenew == "OSPI")
                            {


                                if (Str_Voutypenew == "OSPI" && row.Cells[0].Text.ToString() == "OP")
                                {
                                    Str_Voutype = "OC";
                                }
                                else
                                {
                                    Str_Voutype = "C";
                                }

                            }
                            else if (Str_Voutypenew == "Credit Note - Others" || Str_Voutypenew == "Credit Note")
                            {

                                if ((Str_Voutypenew == "Credit Note - Others" || Str_Voutypenew == "Credit Note") && row.Cells[0].Text.ToString() == "OP")
                                {
                                    Str_Voutype = "OE";
                                }
                                else
                                {
                                    Str_Voutype = "E";
                                }

                            }
                            else if (Str_Voutypenew == "Debit Note - Others" || Str_Voutypenew == "Debit Note")
                            {

                                if (Str_Voutypenew == "Debit Note - Others" || Str_Voutypenew == "Debit Note" && row.Cells[0].Text.ToString() == "OP")
                                {
                                    Str_Voutype = "OV";
                                }
                                else
                                {
                                    Str_Voutype = "V";
                                }

                            }
                            else if (Str_Voutypenew == "BOS" || Str_Voutypenew == "Bill Of Supply")
                            {
                                if ((Str_Voutypenew == "BOS" || Str_Voutypenew == "Bill Of Supply") && row.Cells[0].Text.ToString() == "OP")
                                {
                                    Str_Voutype = "OB";
                                }
                                else
                                {
                                    Str_Voutype = "B";
                                }

                            }
                            // Added For Reim and FC vouchers Vino on 26-09-2023
                            else if (Str_Voutypenew == "Reim" || Str_Voutypenew == "Reimbursement")
                            {
                                if ((Str_Voutypenew == "Reim" || Str_Voutypenew == "Reimbursement") && row.Cells[0].Text.ToString() == "OP")
                                {
                                    Str_Voutype = "OR";
                                }
                                else
                                {
                                    Str_Voutype = "R";
                                }
                            }
                            else if (Str_Voutypenew == "Invoice FC" || Str_Voutypenew == "Sales Invoice OC")
                            {
                                if ((Str_Voutypenew == "Invoice FC" || Str_Voutypenew == "Sales Invoice OC") && row.Cells[0].Text.ToString() == "OP")
                                {
                                    Str_Voutype = "OF";
                                }
                                else
                                {
                                    Str_Voutype = "F";
                                }
                            }
                            else if (Str_Voutypenew == "Credit Note - Operations FC" || Str_Voutypenew == "Purchase Invoice OC")
                            {
                                if ((Str_Voutypenew == "Credit Note - Operations FC" || Str_Voutypenew == "Purchase Invoice OC") && row.Cells[0].Text.ToString() == "OP")
                                {
                                    Str_Voutype = "OG";
                                }
                                else
                                {
                                    Str_Voutype = "G";
                                }
                            }
                            else if (Str_Voutypenew == "BOS FC" || Str_Voutypenew == "Bill Of Supply FC" || Str_Voutypenew == "Bill Of Supply OC")
                            {
                                if ((Str_Voutypenew == "BOS FC" || Str_Voutypenew == "Bill Of Supply FC" || Str_Voutypenew == "Bill Of Supply OC") && row.Cells[0].Text.ToString() == "OP")
                                {
                                    Str_Voutype = "OH";
                                }
                                else
                                {
                                    Str_Voutype = "H";
                                }
                            }
                            else if (Str_Voutypenew == "OSDN Reimbursement")
                            {
                                if ((Str_Voutypenew == "OSDN Reimbursement") && row.Cells[0].Text.ToString() == "OP")
                                {
                                    Str_Voutype = "OK";
                                }
                                else
                                {
                                    Str_Voutype = "K";
                                }
                            }
                            else if (Str_Voutypenew == "OSCN Reimbursement")
                            {
                                if ((Str_Voutypenew == "OSCN Reimbursement") && row.Cells[0].Text.ToString() == "OP")
                                {
                                    Str_Voutype = "OL";
                                }
                                else
                                {
                                    Str_Voutype = "L";
                                }
                            }
                            // End
                            else if (Str_Voutypenew == "Cash Payment")
                            {
                                Str_Voutype = "CP";
                                pmtdtd = "S";
                            }
                            else if (Str_Voutypenew == "Cash receipt" || Str_Voutypenew == "Cash Receipt")
                            {
                                Str_Voutype = "CR";
                                pmtdtd = "S";
                            }
                            else if (Str_Voutypenew == "Bank Payment" || Str_Voutypenew == "Direct Payment")
                            {
                                Str_Voutype = "BP";
                                pmtdtd = "S";
                            }
                            else if (Str_Voutypenew == "Bank receipt" || Str_Voutypenew == "Bank Receipt")
                            {
                                Str_Voutype = "BR";
                                pmtdtd = "S";
                            }
                            else if (Str_Voutypenew == "Receipt - Petty Cash" || Str_Voutypenew == "Petty Cash")
                            {
                                Str_Voutype = "PR";
                                pmtdtd = "S";
                            }
                            else if (Str_Voutypenew == "Remittance-Payment" || Str_Voutypenew == "Remittance Payment")
                            {
                                Str_Voutype = "RP";
                                pmtdtd = "S";
                            }
                            else if (Str_Voutypenew == "Remittance-Receipt" || Str_Voutypenew == "Remittance Receipt")
                            {
                                Str_Voutype = "RR";
                                pmtdtd = "S";
                            }
                            else if (Str_Voutypenew == "ADCN")
                            {
                                Str_Voutype = "T";
                            }


                            if (Str_Voutype == "J")
                            {

                                Amount = double.Parse((txtBox.Text).ToString());
                            }
                            else
                            {

                                //Amount = double.Parse(row.Cells[6].Text.ToString());
                                Amount = double.Parse((txtBox.Text).ToString());
                                //Amount = double.Parse(row.Cells[15].FindControl("adjustment").ToString());
                            }


                            //   double Amount = double.Parse(row.Cells[7].Text.ToString());
                            int int_vouyear = int.Parse(Grd_Detail.DataKeys[row.RowIndex].Values[0].ToString());
                            int int_Vouno = int.Parse(row.Cells[10].Text.ToString());
                            // string jrefno=(row.Cells[5].Text.ToString());
                            string fcurr = row.Cells[14].Text.ToString();
                            double exrate = Convert.ToDouble(row.Cells[13].Text.ToString());
                            string vendorref = row.Cells[5].Text.ToString();  //newly added for bhuvi
                            string WIZvouno = row.Cells[18].Text.ToString();
                            hid_lt.Value = row.Cells[15].Text.ToString();

                            if (jrefno == "&nbsp;")
                            {
                                jrefno = "";
                            }

                            if (hid_lt.Value == "&nbsp;")
                            {
                                hid_lt.Value = "";
                            }
                            //if (Amount > 0)        
                            //{
                            //    if (Str_Voutype == "I" || Str_Voutype == "D" ||Str_Voutype == "V")
                            //    {
                            //        obj_da_Adjust.insertRcptPmt_new(-1, 'R', int_Vouno, char.Parse(Str_Voutype), int_vouyear, Convert.ToInt16(hid_Bid.Value), Amount, Amount, 'Y', int_vouyear, int.Parse(hid_SubGroup.Value), int.Parse(hid_custid.Value.ToString()), hid_lt.Value, jrefno);    
                            //        obj_da_Log.InsLogDetail(int_Empid, 8201, 1, Convert.ToInt16(hid_Bid.Value), Str_Voutype + int_Vouno + " Manually Adjusted");    
                            //     }
                            //    else
                            //    {
                            //        obj_da_Adjust.insertRcptPmt_new(-1, 'P', int_Vouno, char.Parse(Str_Voutype), int_vouyear, Convert.ToInt16(hid_Bid.Value), Amount, Amount, 'Y', int_vouyear, int.Parse(hid_SubGroup.Value), int.Parse(hid_custid.Value.ToString()), hid_lt.Value, jrefno);    
                            //        obj_da_Log.InsLogDetail(int_Empid, 8201, 1, Convert.ToInt16(hid_Bid.Value), Str_Voutype + int_Vouno + " Manually Adjusted");    
                            //    }
                            //}
                            //else
                            //{
                            //if (Amount > 0)
                            //{
                            //obj_da_Adjust.insertRcptPmt_new(-1, 'C', int_Vouno, char.Parse(Str_Voutype), int_vouyear, Convert.ToInt16(hid_Bid.Value), Math.Abs(Amount),Math.Abs(Amount), 'Y', int_vouyear, int.Parse(hid_SubGroup.Value), int.Parse(hid_custid.Value.ToString()), hid_lt.Value, jrefno);  
                            if (pmtdtd == "S")
                            {

                                //ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.WebControls.Button), "   ", "alertify.alert('Don't Select " + Str_Voutypenew + " Amounts ');", true);
                                ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.WebControls.Button), "   ", "alertify.alert('Do Not Select " + Str_Voutypenew + " Amount ');", true);
                                return;
                            }
                            else
                            {

                                obj_da_Adjust.insertRcptPmt_new(-1, 'C', int_Vouno, Str_Voutype.ToString(), int_vouyear, Convert.ToInt16(hid_Bid.Value), Math.Abs(money), Math.Abs(Amount), 'Y', int_vouyear, int.Parse(hid_SubGroup.Value), int.Parse(hid_custid.Value.ToString()), hid_lt.Value, jrefno, fcurr, exrate, vendorref, refid, jmonth, WIZvouno);   //NewOne //22/11/2022


                                //obj_da_Adjust.insertRcptPmt_new(-1, 'C', int_Vouno, Str_Voutype.ToString(), int_vouyear, Convert.ToInt16(hid_Bid.Value), Math.Abs(money), Math.Abs(Amount), 'Y', int_vouyear, int.Parse(hid_SubGroup.Value), int.Parse(hid_custid.Value.ToString()), hid_lt.Value, jrefno, fcurr, exrate, vendorref, refid, jmonth);   //NewOne //22/11/2022

                                //newly aded on 17 nov 2022
                                Approveobj.UpdLedgerOPBreakup4adjustment(int_Vouno, Str_Voutype.ToString(), int_vouyear, Convert.ToInt16(hid_Bid.Value), -1, 'C', int_vouyear, Math.Abs(Amount), "", 0.0, jrefno, "");

                                obj_da_Log.InsLogDetail(int_Empid, 8201, 1, Convert.ToInt16(hid_Bid.Value), Str_Voutype + int_Vouno + " Manually Adjusted");
                                //}
                                //}
                                if (strtrantype == "FC")
                                {
                                    da_obj_log.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"].ToString()), 3689, 2, Convert.ToInt32(Session["LoginBranchid"].ToString()), txt_total.Text + "/ U");
                                }
                            }
                        }
                    }
                }
                if (Check == true)
                {
                    ViewState["dtPayment"] = null;
                    Fn_GetDetail();
                    ScriptManager.RegisterStartupScript(txt_customer, typeof(TextBox), "OutStandingAdjustment", "alertify.alert('Details Saved');", true);
                }
            }
        }
        protected void btn_cancel_Click(object sender, EventArgs e)
        {
            txt_customer.Text = "";
            Grd_Detail.DataSource = Utility.Fn_GetEmptyDataTable();
            Grd_Detail.DataBind();
        }

        private void GetYear()
        {

            dispyear = HttpContext.Current.Session["Vouyear"].ToString();
            dispyear = dispyear.Substring(2, 2);
            int disp = Convert.ToInt32(dispyear);
            dy = disp + 1;
            if (dy < 10)
            {
                dy1 = dy1 + "0" + dy.ToString();
            }
            else
            {
                dy1 = dy.ToString();
            }
            dispyear = dispyear + dy1;
        }

        protected void Grd_Detail_PreRender(object sender, EventArgs e)
        {
            if (Grd_Detail.Rows.Count > 0)
            {
                Grd_Detail.UseAccessibleHeader = true;
                Grd_Detail.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }

        protected void chk_Select_CheckedChanged(object sender, EventArgs e) //// 19-07-2022 hari
        {
            double total = 0;
            bool Check = false;
            foreach (GridViewRow row in Grd_Detail.Rows)
            {
                TextBox txtBox = (TextBox)Grd_Detail.Rows[row.RowIndex].FindControl("adjustment");
                CheckBox chk = (CheckBox)row.FindControl("Chk_Select");
                double amount = 0;

                if (txtBox.Text == "")
                {
                    txtBox.Text = "0";
                }

                if (txtBox.Text != "0")
                {
                    amount = double.Parse(txtBox.Text);


                }
                else if (chk.Checked == true)
                {
                    //txtBox.Enabled = true;
                    amount = double.Parse(row.Cells[6].Text);
                    //// ((TextBox)Grd_Detail.Rows[row.RowIndex].FindControl("adjustment")).Text = Math.Abs(amount).ToString();
                    ((TextBox)Grd_Detail.Rows[row.RowIndex].FindControl("adjustment")).Text = (amount).ToString("#0.00");


                }
                else
                {
                    //txtBox.Enabled = false;
                    ((TextBox)Grd_Detail.Rows[row.RowIndex].FindControl("adjustment")).Text = double.Parse("0.0").ToString();
                }

                total += amount;
                txt_total.Text = total.ToString("#0.00");
            }
        }

        protected void txt_adjustment_TextChanged(object sender, EventArgs e) //// 19-07-2022 hari
        {
            double total = 0;
            foreach (GridViewRow row in Grd_Detail.Rows)
            {

                TextBox txtBox = (TextBox)Grd_Detail.Rows[row.RowIndex].FindControl("adjustment");
                //if (!System.Text.RegularExpressions.Regex.IsMatch(txtBox.Text, "^[0-9]"))
                //{
                CheckBox chk = (CheckBox)row.FindControl("Chk_Select");
                if (txtBox.Text != "" && txtBox.Text != "0")
                {
                    double amount = double.Parse(txtBox.Text);
                    txtBox.Text = amount.ToString("#0.00"); 
                    total += amount;
                    txt_total.Text = total.ToString("#0.00");

                    //ScriptManager.RegisterStartupScript(txtBox, typeof(TextBox), "OutStandingAdjustment", "alertify.alert('This textbox accepts only Number characters');", true);
                    //return;
                }


                //TextBox txtBox = (TextBox)Grd_Detail.Rows[row.RowIndex].FindControl("adjustment");
                //if (!System.Text.RegularExpressions.Regex.IsMatch(txtBox.Text, "^[0-9]"))
                //{

                //    double amount = double.Parse(row.Cells[6].Text);
                //    txtBox.Text = Math.Abs(amount).ToString();
                //    total += amount;
                //    txt_total.Text = total.ToString();

                //    ScriptManager.RegisterStartupScript(txtBox, typeof(TextBox), "OutStandingAdjustment", "alertify.alert('This textbox accepts only Number characters');", true);
                //    return;
                //}
            }
        }



        public void getFullName()
        {
            ////string startMonth = date1.ToString("MM");

            var firstDayOfMonth = new DateTime(date1.Year, date1.Month, 1);
            int datet1 = date1.Month;
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
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "   ", "alertify.alert('" + message + "');", true);
            }
        }

        protected void loadgridlog()
        {
            GridViewlog.Visible = true;
            Panel2.Visible = true;
            DataTable obj_dtlogdetails = new DataTable();
            //DataAccess.LogDetails Logobj = new DataAccess.LogDetails();

            if (Session["str_ModuleName"].ToString() == "FC")
            {
                obj_dtlogdetails = Logobj.InsTempGrpLogdtlsGet(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), 3689, "", "", "", Session["StrTranType"].ToString());
            }
            else
            {
                obj_dtlogdetails = Logobj.InsTempGrpLogdtlsGet(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), 1202, "PA", "", "", Session["StrTranType"].ToString());
            }

            //if (txt_jobno.Text != "")
            //{
            //    JobInput.Text = txt_jobno.Text;
            //}

            if (obj_dtlogdetails.Rows.Count >= 0)
            {
                ModalPopupExtenderlog.Show();
                GridViewlog.DataSource = obj_dtlogdetails;
                GridViewlog.DataBind();
            }
        }
    }
}