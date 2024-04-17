using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Runtime.Remoting;


namespace logix.FAForm
{
    public partial class VoucherCount : System.Web.UI.Page
    {
        DataAccess.Masters.MasterBranch da_obj_Branch = new DataAccess.Masters.MasterBranch();
        DataAccess.checkvouchercount da_chkvcobj = new DataAccess.checkvouchercount();
        DataAccess.Accounts.Invoice Invobj = new DataAccess.Accounts.Invoice();
        DataAccess.FAVoucher Faobj = new DataAccess.FAVoucher();
        DataAccess.Accounts.Reversal RevObj = new DataAccess.Accounts.Reversal();
        DataAccess.HR.Employee Emp_Obj = new DataAccess.HR.Employee();
        DataAccess.LogDetails Log_Det = new DataAccess.LogDetails();
        DataAccess.FAMaster.ReportView da_obj_rv = new DataAccess.FAMaster.ReportView();
        DataAccess.LogDetails Logobj = new DataAccess.LogDetails();
        string rvtype;
        DataTable obj_dtTemp, obj_Dt;
        string status = "", Str_CurrrentDate;
        int Branch_Id;

        protected void Page_Load(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "SpanTagMoveInputBottom();MuiTextField();", true);


            string Ccode = Convert.ToString(Session["Ccode"]);

            if (Ccode != "")
            {

                da_obj_Branch.GetDataBase(Ccode);
                da_chkvcobj.GetDataBase(Ccode);
                Invobj.GetDataBase(Ccode);
                Faobj.GetDataBase(Ccode);
                RevObj.GetDataBase(Ccode);
                Emp_Obj.GetDataBase(Ccode);
                Log_Det.GetDataBase(Ccode);
                da_obj_rv.GetDataBase(Ccode);
                Logobj.GetDataBase(Ccode);
               

            }

            if (Session["LoginUserName"] == null || Session["LoginEmpId"] == null || Session["LoginDivisionId"] == null || Session["LoginBranchid"] == null)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alertify.alert('Session TimeOut');window.open('"+ Session["Site"].ToString() + "/','_top');", true);
            }

            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(btn_back);
            //((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(grd);


            if (Request.QueryString.ToString().Contains("FormName"))
            {
                LblHead.Text = Request.QueryString["FormName"].ToString();
            }

            Str_CurrrentDate = DateTime.Now.ToString("dd/MM/yyyy");

            if (!IsPostBack)
            {
                lbnl_logyear.Text = Session["LYEAR"].ToString();
                int stryear = Convert.ToInt32(DateTime.Now.Year.ToString());
                int vouyeartext = Convert.ToInt32(Session["Vouyear"].ToString());
                int Vouyear = Convert.ToInt32(Session["LogYear"].ToString());
                // string Str_CurrrentDate = DateTime.Now.ToString("dd/MM/yyyy");
                DateTime Date = da_obj_rv.MaxVouGetDate(Session["FADbname"].ToString());

                if ((Vouyear == (DateTime.Now).Year - 1 && (DateTime.Now).Month <=3) || Vouyear == (DateTime.Now).Year)
                {
                    Txtfrom.Text = "01/04/" + vouyeartext;
                    Txtto.Text = Str_CurrrentDate.ToString();

                }
                else
                {
                    Txtfrom.Text = "01/04/" + vouyeartext;
                    Txtto.Text = "31/03/" + (vouyeartext + 1);
                }
                //Txtfrom.Text = Str_CurrrentDate;
                //Txtto.Text = Str_CurrrentDate;
                //BindBranchDLL();
                status = Faobj.getfinalize(Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()), Convert.ToInt32(Session["LoginEmpId"].ToString()), Session["FADbname"].ToString());

                string Branch_Name = Convert.ToString(HttpContext.Current.Session["LoginBranchName"].ToString());
                DataTable dtTable = new DataTable();
                //DataAccess.HR.Employee Emp_Obj = new DataAccess.HR.Employee();

                //if (Branch_Name == "CORPORATE")
                //{
                //    dtTable = Emp_Obj.selBranchList(Session["LoginDivisionName"].ToString());
                //    if (dtTable.Rows.Count > 0)
                //    {
                //        ddlbranch.Items.Add("ALL");
                //        for (int i = 0; i <= dtTable.Rows.Count - 1; i++)
                //        {
                //            ddlbranch.Items.Add(dtTable.Rows[i]["branchname"].ToString());
                //        }
                //    }
                //    ddlbranch.Enabled = true;
                //    Branch_Id = Convert.ToInt32(Session["LoginBranchid"].ToString());
                //}
                //else
                //{

                //}      
                string Branch = Convert.ToString(HttpContext.Current.Session["LoginBranchName"].ToString());
                ddlbranch.Items.Add(Branch);
                ddlbranch.Enabled = false;
                Branch_Id = Convert.ToInt32(Session["LoginBranchid"].ToString());

                if (status == "Y")
                {
                    foreach (GridView Row in grdvouchers.Rows)
                    {
                        Button Btn_Transfer = (Button)Row.FindControl("btn_Transfer");
                        Btn_Transfer.Enabled = false;
                    }
                }

                grd.DataSource = new DataTable();
                grd.DataBind();
            }
        }

        protected void ddlbranch_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlbranch.SelectedItem.ToString() == "ALL")
            {
                Branch_Id = Convert.ToInt32(Session["LoginBranchid"].ToString());
            }
            else
            {
                Branch_Id = Emp_Obj.GetBranchId(Convert.ToInt32(Session["LoginDivisionId"].ToString()), ddlbranch.SelectedItem.Text);
            }
        }

        protected void btn_get_Click(object sender, EventArgs e)
        {
            int intdivisionid = 0;
            DataTable objdtc = new DataTable();
            DateTime FromDt, ToDt;

            int Div_Id = Convert.ToInt32(HttpContext.Current.Session["LoginDivisionid"].ToString());
            FromDt = Convert.ToDateTime(Utility.fn_ConvertDate(Txtfrom.Text.ToString()));
            ToDt = Convert.ToDateTime(Utility.fn_ConvertDate(Txtto.Text.ToString()));

            Branch_Id = Emp_Obj.GetBranchId(Div_Id, ddlbranch.SelectedItem.Text);

            if (FromDt > ToDt)
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), "alertify.alert('From Date Should be Lessthan To Date')", true);
                Txtfrom.Focus();
                return;
            }

            if (ddlbranch.SelectedItem.ToString() == "ALL")
            {
                intdivisionid = Convert.ToInt32(Session["LoginDivisionId"].ToString());
            }
            else
            {
                intdivisionid = 0;
            }
            objdtc = da_chkvcobj.GetvochercountNew(Branch_Id, Convert.ToInt32(Session["LogYear"].ToString()), Convert.ToDateTime(Utility.fn_ConvertDate(Txtfrom.Text.ToString())), Convert.ToDateTime(Utility.fn_ConvertDate(Txtto.Text.ToString())), intdivisionid, Session["FADbname"].ToString());

            DataTable dt_temptbl1 = new DataTable();
            DataRow dr;
            DataColumn dc_col1 = new DataColumn("voutype", typeof(string));
            DataColumn dc_col2 = new DataColumn("logix", typeof(int));
            DataColumn dc_col3 = new DataColumn("logixfa", typeof(int));
            DataColumn dc_col4 = new DataColumn("diff", typeof(int));

            dt_temptbl1.Columns.Add(dc_col1);
            dt_temptbl1.Columns.Add(dc_col2);
            dt_temptbl1.Columns.Add(dc_col3);
            dt_temptbl1.Columns.Add(dc_col4);

            for (int i = 0; i <= objdtc.Rows.Count - 1; i++)
            {
                dr = dt_temptbl1.NewRow();
                dr["voutype"] = objdtc.Rows[i]["voutype"].ToString();
                dr["logix"] = Convert.ToInt32(objdtc.Rows[i]["ops"].ToString());
                dr["logixfa"] = Convert.ToInt32(objdtc.Rows[i]["fa"].ToString());
                dr["diff"] = Convert.ToInt32(objdtc.Rows[i]["ops"].ToString()) - Convert.ToInt32(objdtc.Rows[i]["fa"].ToString());
                dt_temptbl1.Rows.Add(dr);
            }
            dr = dt_temptbl1.NewRow();

            dr["voutype"] = "Total";
            dr["logix"] = dt_temptbl1.Compute("sum(logix)", "");
            dr["logixfa"] = dt_temptbl1.Compute("sum(logixfa)", "");
            dr["diff"] = dt_temptbl1.Compute("sum(diff)", "");
            dt_temptbl1.Rows.Add(dr);

            if (dt_temptbl1.Rows.Count > 0)
            {
                grd.DataSource = dt_temptbl1;
                grd.DataBind();

                grdvouchers.DataSource = Utility.Fn_GetEmptyDataTable();
                grdvouchers.DataBind();
                pnlvouchers.Visible = true;
            }

            foreach (GridViewRow row in grd.Rows)
            {
                if (row.Cells[0].Text == "Total")
                {
                    row.ForeColor = System.Drawing.Color.Maroon;
                    row.Font.Bold = true;
                }
            }

            btn_back.ToolTip = "Cancel";
            btn_back1.Attributes["class"] = "btn ico-cancel";
            lblvou.Text = "";

            if (Session["str_ModuleName"] == "FA")
            {
                Log_Det.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"].ToString()), 1252, 3, Convert.ToInt32(Session["LoginBranchid"].ToString()), FromDt + "-" + ToDt + "-" + "/V");
            }
            else
            {
                Log_Det.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"].ToString()), 1253, 3, Convert.ToInt32(Session["LoginBranchid"].ToString()), FromDt + "-" + ToDt + "-" + "/V");
            }
        }

        public void BindBranchDLL()
        {
            obj_dtTemp = new DataTable();
            obj_dtTemp = da_obj_Branch.GetBranchByDivID(Convert.ToInt32(Session["LoginDivisionId"].ToString()));
            ddlbranch.Items.Add(new ListItem("ALL", "0"));
            ddlbranch.DataSource = obj_dtTemp;
            ddlbranch.DataTextField = "branch";
            ddlbranch.DataValueField = "branchid";
            ddlbranch.DataBind();
        }

        protected void grd_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                for (int i = 0; i <= e.Row.Cells.Count - 1; i++)
                {
                    double double_value = 0;
                    e.Row.Cells[i].Attributes.CssStyle["text-align"] = "Right";

                    if (double.TryParse(e.Row.Cells[1].Text.ToString(), out double_value))
                    {
                        //e.Row.Cells[1].Text = string.Format("{0:#,##0.00}", double_value);
                        e.Row.Cells[1].Attributes.CssStyle["text-align"] = "Right";
                    }
                    if (double.TryParse(e.Row.Cells[2].Text.ToString(), out double_value))
                    {
                        //e.Row.Cells[2].Text = string.Format("{0:#,##0.00}", double_value);
                        e.Row.Cells[2].Attributes.CssStyle["text-align"] = "Right";
                    }
                }

                for (int i = 0; i < e.Row.Cells.Count; i++)
                {
                    if (e.Row.Cells[i].Text == "&nbsp" || e.Row.Cells[i].Text == "&nbsp;")
                    {
                        e.Row.Cells[i].Text = "";
                    }
                    e.Row.Cells[i].ToolTip = e.Row.Cells[i].Text;

                    if (e.Row.Cells[i].Text == "Total")
                    {
                        return;
                    }
                    else
                    {
                        e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(grd, "Select$" + e.Row.RowIndex);
                        e.Row.Attributes["style"] = "cursor:pointer";
                    }
                }


            }
        }

        protected void grd_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index;
            index = grd.SelectedRow.RowIndex;
            lblvou.Text = grd.Rows[index].Cells[0].Text;
            lblvou.ForeColor = System.Drawing.Color.Maroon;
            DataTable dtvouchers = new DataTable();

            if (ddlbranch.SelectedItem.ToString() == "ALL")
            {
                Branch_Id = Convert.ToInt32(Session["LoginBranchid"].ToString());
            }
            else
            {
                Branch_Id = Emp_Obj.GetBranchId(Convert.ToInt32(Session["LoginDivisionId"].ToString()), ddlbranch.SelectedItem.Text);
            }

            dtvouchers = da_chkvcobj.GetvocherdiffNew(grd.Rows[index].Cells[0].Text, Convert.ToDateTime(Utility.fn_ConvertDate(Txtfrom.Text.ToString())), Convert.ToDateTime(Utility.fn_ConvertDate(Txtto.Text.ToString())), Branch_Id, Convert.ToInt32(Session["LogYear"].ToString()), Session["FADbname"].ToString());

            if (dtvouchers.Rows.Count > 0)
            {

                grdvouchers.DataSource = dtvouchers;
                grdvouchers.DataBind();
                pnlvouchers.Visible = true;


                ViewState["grdvouchers"] = dtvouchers;
            }
            else
            {
                grdvouchers.DataSource = new DataTable();
                grdvouchers.DataBind();
            }
        }

        protected void btn_Transfer_Click(object sender, ImageClickEventArgs e)
        {
            ImageButton lb = (ImageButton)sender;
            GridViewRow GvRow = (GridViewRow)lb.NamingContainer;
            int Row_ID = GvRow.RowIndex;
            int index, vouno, Int_Vou_No, Int_Vou_Year, vouyear;
            index = grd.SelectedRow.RowIndex;
            lblvou.Text = grd.Rows[index].Cells[0].Text;

            vouno = Convert.ToInt32(grdvouchers.Rows[Row_ID].Cells[1].Text);

            DataTable R_Dt = new DataTable();
            DataTable R_Dt1 = new DataTable();

            if (ddlbranch.SelectedItem.ToString() == "ALL")
            {
                Branch_Id = Convert.ToInt32(Session["LoginBranchid"].ToString());
            }
            else
            {
                Branch_Id = Emp_Obj.GetBranchId(Convert.ToInt32(Session["LoginDivisionId"].ToString()), ddlbranch.SelectedItem.Text);
            }

            vouyear = Convert.ToInt32(Session["LogYear"].ToString());

            if (lblvou.Text == "Debit Note - Others")
            {
                R_Dt1 = Invobj.FAShowTallyDt(vouno, "DNHead", Convert.ToInt32(Session["LogYear"].ToString()), Branch_Id);

                if (R_Dt1.Rows.Count == 1)
                {
                    char Reversal = 'L';
                    if (R_Dt1.Rows[0]["billtype"].ToString() == "R" && Reversal != 'L')
                    {
                        R_Dt = Faobj.GetRevVoucherDet(Branch_Id, vouno, "V", Convert.ToInt32(Session["LogYear"].ToString()));
                        if (R_Dt.Rows.Count == 1)
                        {
                            Int_Vou_No = Convert.ToInt32(R_Dt.Rows[0]["vouno"].ToString());
                            Int_Vou_Year = Convert.ToInt32(R_Dt.Rows[0]["vouyear"].ToString());
                        }
                        else
                        {
                            Int_Vou_No = 0;
                            Int_Vou_Year = 0;
                        }
                        try
                        {
                            if (Faobj.CheckFAExists4Voucher(vouno, Convert.ToInt32(Session["LogYear"].ToString()), Branch_Id, 7, Session["FADbname"].ToString()) != 0)
                            {
                                return;
                            }

                            if (Int_Vou_Year == Convert.ToInt32(Session["LogYear"].ToString()) - 1)
                            {
                                logix.CommanClass.TallyEDIFA.Fn_FATransfer("Debit Note - Others", vouno, vouno, "Vessel/Voyage/Container", "BL No", Branch_Id, "CNOps2DN", Int_Vou_No, Int_Vou_Year, "Credit Note - Operations",1);
                                ScriptManager.RegisterStartupScript(btn_get, typeof(Button), "DataFound", "alertify.alert('Transfered to FA');", true);
                                return;
                            }
                            else if (Int_Vou_Year == Convert.ToInt32(Session["LogYear"].ToString()))
                            {
                                int voucherid;
                                int revledgerid;
                                double revledgeramt;
                                string revledgertype = "";
                                DataTable dtrev = new DataTable();
                                voucherid = RevObj.InsReversalVouchers(Branch_Id, Int_Vou_Year, Int_Vou_No, vouno, Convert.ToInt32(Session["LoginEmpId"]), 2, 7, Session["FADbname"].ToString());
                                RevObj.InsReversalFAVouDetails(Session["FADbname"].ToString(), voucherid, Int_Vou_No, 2, Int_Vou_Year, Branch_Id);
                                dtrev = RevObj.GetReversalVoucherDtls(voucherid, Session["FADbname"].ToString());
                                if (dtrev.Rows.Count > 0)
                                {
                                    for (int k = 0; k <= dtrev.Rows.Count - 1; k++)
                                    {
                                        revledgerid = Convert.ToInt32(dtrev.Rows[k]["ledgerid"].ToString());
                                        revledgeramt = Convert.ToDouble(dtrev.Rows[k]["ledgeramount"].ToString());
                                        revledgertype = dtrev.Rows[k]["ledgertype"].ToString();
                                        RevObj.UpdReversalLedgerDtls(revledgerid, Branch_Id, Convert.ToInt32(Session["LoginDivisionId"].ToString()), revledgeramt, Session["FADbname"].ToString(), revledgertype, Int_Vou_Year);

                                    }
                                    ScriptManager.RegisterStartupScript(btn_get, typeof(Button), "DataFound", "alertify.alert('Transfered to FA');", true);
                                    return;
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), "alertify.alert('" + ex.Message.ToString() + "');", true);
                            return;
                        }
                    }
                    else if (R_Dt1.Rows[0]["billtype"].ToString() == "R")
                    {
                        logix.CommanClass.TallyEDIFA.Fn_FATransfer("Debit Note - Others", vouno, vouno, "Vessel/Voyage/Container", "BL No", Branch_Id, "CNOps2DN", vouno, vouyear, "Debit Note - Others",1);
                        ScriptManager.RegisterStartupScript(btn_get, typeof(Button), "DataFound", "alertify.alert('Transfered to FA');", true);
                        return;
                    }
                }
            }
            else if (lblvou.Text == "Credit Note - Others")
            {
                R_Dt1 = Invobj.FAShowTallyDt(vouno, "CNHead", Convert.ToInt32(Session["LogYear"].ToString()), Branch_Id);
                if (R_Dt1.Rows.Count == 1)
                {
                    char Reversal = 'L';
                    if (R_Dt1.Rows[0]["billtype"].ToString() == "R" && Reversal != 'L')
                    {
                        R_Dt = Faobj.GetRevVoucherDet(Branch_Id, vouno, "E", Convert.ToInt32(Session["LogYear"].ToString()));
                        if (R_Dt.Rows.Count == 1)
                        {
                            rvtype = R_Dt.Rows[0]["voutype"].ToString();
                            Int_Vou_No = Convert.ToInt32(R_Dt.Rows[0]["vouno"].ToString());
                            Int_Vou_Year = Convert.ToInt32(R_Dt.Rows[0]["vouyear"].ToString());
                        }
                        else
                        {
                            Int_Vou_No = 0;
                            Int_Vou_Year = 0;
                        }
                        try
                        {
                            if (Faobj.CheckFAExists4Voucher(vouno, Convert.ToInt32(Session["LogYear"].ToString()), Branch_Id, 8, Session["FADbname"].ToString()) != 0)
                            {
                                return;
                            }

                            if (Int_Vou_Year == Convert.ToInt32(Session["LogYear"].ToString()) - 1)
                            {
                                logix.CommanClass.TallyEDIFA.Fn_FATransfer("Credit Note - Others", vouno, vouno, "Vessel/Voyage/Container", "BL No", Branch_Id, "Inv2CN", Int_Vou_No, Int_Vou_Year, "Invoice",1);
                                ScriptManager.RegisterStartupScript(btn_get, typeof(Button), "DataFound", "alertify.alert('Transfered to FA');", true);
                                return;
                            }
                            else if (Int_Vou_Year == Convert.ToInt32(Session["LogYear"].ToString()))
                            {
                                int voucherid;
                                int revledgerid;
                                double revledgeramt;
                                string revledgertype = "";
                                DataTable dtrev = new DataTable();

                                int voutyehome = 0;
                                if (rvtype == "B")
                                {
                                    voutyehome = 20;
                                }
                                else
                                {
                                    voutyehome = 1;

                                }
                                voucherid = RevObj.InsReversalVouchers(Branch_Id, Int_Vou_Year, Int_Vou_No, vouno, Convert.ToInt32(Session["LoginEmpId"]), voutyehome, 8, Session["FADbname"].ToString());
                                RevObj.InsReversalFAVouDetails(Session["FADbname"].ToString(), voucherid, Int_Vou_No, voutyehome, Int_Vou_Year, Branch_Id);
                                dtrev = RevObj.GetReversalVoucherDtls(voucherid, Session["FADbname"].ToString());
                                if (dtrev.Rows.Count > 0)
                                {
                                    for (int k = 0; k <= dtrev.Rows.Count - 1; k++)
                                    {
                                        revledgerid = Convert.ToInt32(dtrev.Rows[k]["ledgerid"].ToString());
                                        revledgeramt = Convert.ToDouble(dtrev.Rows[k]["ledgeramount"].ToString());
                                        revledgertype = dtrev.Rows[k]["ledgertype"].ToString();
                                        RevObj.UpdReversalLedgerDtls(revledgerid, Branch_Id, Convert.ToInt32(Session["LoginDivisionId"].ToString()), revledgeramt, Session["FADbname"].ToString(), revledgertype, Int_Vou_Year);

                                    }
                                    ScriptManager.RegisterStartupScript(btn_get, typeof(Button), "DataFound", "alertify.alert('Transfered to FA');", true);
                                    return;
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), "alertify.alert('" + ex.Message.ToString() + "');", true);
                            return;
                        }
                    }
                    else if (R_Dt1.Rows[0]["billtype"].ToString() == "R")
                    {
                        logix.CommanClass.TallyEDIFA.Fn_FATransfer("Credit Note - Others", vouno, vouno, "Vessel/Voyage/Container", "BL No", Branch_Id, "Inv2CN", vouno, vouyear, "Credit Note - Others",1);
                        ScriptManager.RegisterStartupScript(btn_get, typeof(Button), "DataFound", "alertify.alert('Transfered to FA');", true);
                        return;
                    }
                }
            }

            if (lblvou.Text == "Debit Note - Others")
            {
                if (ddlbranch.Text == "WAREHOUSE")
                {
                    logix.CommanClass.TallyEDIFA.Fn_FATransfer("Debit Note - Others", vouno, vouno, "Remarks", "BL No", Branch_Id,"",0,0,"",1);
                }
                else
                {
                    logix.CommanClass.TallyEDIFA.Fn_FATransfer("Debit Note - Others", vouno, vouno, "Vessel/Voyage/Container", "BL No", Branch_Id,"",0,0,"",1);
                }

                ScriptManager.RegisterStartupScript(btn_get, typeof(Button), "DataFound", "alertify.alert('Transfered to FA');", true);
            }
            else if (lblvou.Text == "Admin Sales Invoice")
            {
                logix.CommanClass.TallyEDIFA.Fn_FATransfer("Admin Sales Invoice", vouno, vouno, "Vessel/Voyage/Container", "BL No", Branch_Id,"",0,0,"",1);
                ScriptManager.RegisterStartupScript(btn_get, typeof(Button), "DataFound", "alertify.alert('Transfered to FA');", true);
            }
            else if (lblvou.Text == "Cash Payment")
            {
                logix.CommanClass.TallyEDIFA.Fn_FATransfer("Cash Payment", vouno, vouno, "Vessel/Voyage/Container", "BL No", Branch_Id,"",0,0,"",1);
                ScriptManager.RegisterStartupScript(btn_get, typeof(Button), "DataFound", "alertify.alert('Transfered to FA');", true);
            }
            else if (lblvou.Text == "Bank Payment")
            {
                //opsTouch.CommanClass.TallyEDIFA.Fn_FATransfer("Bank Payment", vouno, vouno, "Vessel/Voyage/Container", "BL No");
                logix.CommanClass.TallyEDIFA.Fn_FATransfer("Bank Payment", vouno, vouno, "", "", Branch_Id ,"", 0, 0, "",1);
                ScriptManager.RegisterStartupScript(btn_get, typeof(Button), "DataFound", "alertify.alert('Transfered to FA');", true);
            }
            else if (lblvou.Text == "Cash Receipt")
            {
                logix.CommanClass.TallyEDIFA.Fn_FATransfer("Cash Receipt", vouno, vouno, "Vessel/Voyage/Container", "BL No", Branch_Id,"",0,0,"",1);
                ScriptManager.RegisterStartupScript(btn_get, typeof(Button), "DataFound", "alertify.alert('Transfered to FA');", true);
            }
            else if (lblvou.Text == "Bank Receipt")
            {
                logix.CommanClass.TallyEDIFA.Fn_FATransfer("Bank Receipt", vouno, vouno, "Vessel/Voyage/Container", "BL No", Branch_Id,"",0,0,"",1);
                ScriptManager.RegisterStartupScript(btn_get, typeof(Button), "DataFound", "alertify.alert('Transfered to FA');", true);
            }
            else if (lblvou.Text == "Invoices")
            {
                if (ddlbranch.Text == "WAREHOUSE")
                {
                    logix.CommanClass.TallyEDIFA.Fn_FATransfer("Invoices", vouno, vouno, "Remarks", "BL No", Branch_Id,"",0,0,"",1);
                }
                else
                {
                    logix.CommanClass.TallyEDIFA.Fn_FATransfer("Invoices", vouno, vouno, "Vessel/Voyage/Container", "BL No", Branch_Id,"",0,0,"",1);
                }

                ScriptManager.RegisterStartupScript(btn_get, typeof(Button), "DataFound", "alertify.alert('Transfered to FA');", true);
            }
            else if (lblvou.Text == "OSSI")
            {
                logix.CommanClass.TallyEDIFA.Fn_FATransfer("OSSI", vouno, vouno, "Vessel/Voyage/Container", "BL No", Branch_Id,"",0,0,"",1);
                ScriptManager.RegisterStartupScript(btn_get, typeof(Button), "DataFound", "alertify.alert('Transfered to FA');", true);
            }
            else if (lblvou.Text == "OSPI")
            {
                logix.CommanClass.TallyEDIFA.Fn_FATransfer("OSPI", vouno, vouno, "Vessel/Voyage/Container", "BL No", Branch_Id,"",0,0,"",1);
                ScriptManager.RegisterStartupScript(btn_get, typeof(Button), "DataFound", "alertify.alert('Transfered to FA');", true);
            }
            else if (lblvou.Text == "Credit Note - Operations")
            {
                DataTable dttds = new DataTable();

                dttds = da_chkvcobj.GetTDSdetails("P", vouno, Convert.ToInt32(Session["LogYear"].ToString()), Branch_Id);
                if (dttds.Rows.Count == 0)
                {
                    ScriptManager.RegisterStartupScript(btn_get, typeof(Button), "DataFound", "alertify.alert('Kindly apply Tds for  " + vouno + "');", true);
                }
                else
                {
                    if (ddlbranch.Text == "WAREHOUSE")
                    {
                        logix.CommanClass.TallyEDIFA.Fn_FATransfer("Credit Note - Operations", vouno, vouno, "Remarks", "BL No", Branch_Id,"",0,0,"",1);
                    }
                    else
                    {
                        logix.CommanClass.TallyEDIFA.Fn_FATransfer("Credit Note - Operations", vouno, vouno, "Vessel/Voyage/Container", "BL No", Branch_Id,"",0,0,"",1);
                    }
                    ScriptManager.RegisterStartupScript(btn_get, typeof(Button), "DataFound", "alertify.alert('Transfered to FA');", true);
                }
            }
            else if (lblvou.Text == "Credit Note - Others")
            {
                DataTable dttds = new DataTable();

                dttds = da_chkvcobj.GetTDSdetails("E", vouno, Convert.ToInt32(Session["LogYear"].ToString()), Branch_Id);
                if (dttds.Rows.Count == 0)
                {
                    ScriptManager.RegisterStartupScript(btn_get, typeof(Button), "DataFound", "alertify.alert('Kindly apply Tds #');", true);
                }
                else
                {
                    if (ddlbranch.Text == "WAREHOUSE")
                    {
                        logix.CommanClass.TallyEDIFA.Fn_FATransfer("Credit Note - Others", vouno, vouno, "Remarks", "BL No", Branch_Id,"",0,0,"",1);
                    }
                    else
                    {
                        logix.CommanClass.TallyEDIFA.Fn_FATransfer("Credit Note - Others", vouno, vouno, "Vessel/Voyage/Container", "BL No", Branch_Id,"",0,0,"",1);
                    }

                    ScriptManager.RegisterStartupScript(btn_get, typeof(Button), "DataFound", "alertify.alert('Transfered to FA');", true);
                }
            }
            else if (lblvou.Text == "Admin Purchase Invoice")
            {
                DataTable dttds = new DataTable();

                dttds = da_chkvcobj.GetTDSdetails("S", vouno, Convert.ToInt32(Session["LogYear"].ToString()), Branch_Id);
                if (dttds.Rows.Count == 0)
                {
                    ScriptManager.RegisterStartupScript(btn_get, typeof(Button), "DataFound", "alertify.alert('Kindly apply Tds for  " + vouno + "');", true);
                }
                else
                {
                    logix.CommanClass.TallyEDIFA.Fn_FATransfer("Admin Purchase Invoice", vouno, vouno, "Remarks", "Ref No", Branch_Id,"",0,0,"",1);
                    ScriptManager.RegisterStartupScript(btn_get, typeof(Button), "DataFound", "alertify.alert('Transfered to FA');", true);
                }
            }
            else if (lblvou.Text == "Receipt - Petty Cash")
            {
                logix.CommanClass.TallyEDIFA.Fn_FATransfer("Receipt - Petty Cash", vouno, vouno, "", "", Branch_Id,"",0,0,"",1);
                ScriptManager.RegisterStartupScript(btn_get, typeof(Button), "DataFound", "alertify.alert('Transfered to FA');", true);
            }

            //Ruban add for BOS
            else if (lblvou.Text == "BOS")
            {
                logix.CommanClass.TallyEDIFA.Fn_FATransfer("BOS", vouno, vouno, "Vessel/Voyage/Container", "BL No", Branch_Id,"",0,0,"",1);
                ScriptManager.RegisterStartupScript(btn_get, typeof(Button), "DataFound", "alertify.alert('Transfered to FA');", true);
            }
            else if (lblvou.Text == "Remittance-Receipt")
            {
                logix.CommanClass.TallyEDIFA.Fn_FATransfer("Remittance-Receipt", vouno, vouno, "Vessel/Voyage/Container", "BL No", Branch_Id, "", 0, 0, "",1);
                ScriptManager.RegisterStartupScript(btn_get, typeof(Button), "DataFound", "alertify.alert('Transfered to FA');", true);
            }
            else if (lblvou.Text == "Remittance-Payment")
            {
                logix.CommanClass.TallyEDIFA.Fn_FATransfer("Remittance-Payment", vouno, vouno, "Vessel/Voyage/Container", "BL No", Branch_Id, "", 0, 0, "",1);
                ScriptManager.RegisterStartupScript(btn_get, typeof(Button), "DataFound", "alertify.alert('Transfered to FA');", true);
            }

            if (ViewState["grdvouchers"] != null && !ViewState["grdvouchers"].Equals("-1"))
            {
                DataTable dt_GrdVoucher = new DataTable();
                dt_GrdVoucher = (DataTable)ViewState["grdvouchers"];

                if (Row_ID < dt_GrdVoucher.Rows.Count)
                {
                    dt_GrdVoucher.Rows.Remove(dt_GrdVoucher.Rows[Row_ID]);
                    dt_GrdVoucher.AcceptChanges();
                }

                grdvouchers.DataSource = dt_GrdVoucher;
                grdvouchers.DataBind();
                pnlvouchers.Visible = true;

            }
        }

        protected void grdvouchers_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Cells[0].Text = "" + ((((GridView)sender).PageIndex * ((GridView)sender).PageSize) + (e.Row.RowIndex + 1));
                if (status == "Y")
                {
                    this.grdvouchers.Columns[6].Visible = false;
                }
            }

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                for (int i = 0; i <= e.Row.Cells.Count - 1; i++)
                {
                    double double_value = 0;

                    if (double.TryParse(e.Row.Cells[4].Text.ToString(), out double_value))
                    {
                        e.Row.Cells[4].Text = string.Format("{0:#,##0.00}", double_value);
                        e.Row.Cells[4].Attributes.CssStyle["text-align"] = "Right";
                    }
                }

                for (int i = 0; i < e.Row.Cells.Count; i++)
                {
                    if (e.Row.Cells[i].Text == "&nbsp" || e.Row.Cells[i].Text == "&nbsp;")
                    {
                        e.Row.Cells[i].Text = "";
                    }
                    e.Row.Cells[i].ToolTip = e.Row.Cells[i].Text;
                }

                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(grdvouchers, "Select$" + e.Row.RowIndex);
                e.Row.Attributes["style"] = "cursor:pointer";
            }
        }

        protected void btn_back_Click(object sender, EventArgs e)
        {
            if (btn_back.ToolTip == "Cancel")
            {
                int stryear = Convert.ToInt32(DateTime.Now.Year.ToString());
                int vouyeartext = Convert.ToInt32(Session["Vouyear"].ToString());
                int Vouyear = Convert.ToInt32(Session["LogYear"].ToString());
                // string Str_CurrrentDate = DateTime.Now.ToString("dd/MM/yyyy");
                DateTime Date = da_obj_rv.MaxVouGetDate(Session["FADbname"].ToString());

                if ((Vouyear == (DateTime.Now).Year - 1 && (DateTime.Now).Month <=3) || Vouyear == (DateTime.Now).Year)
                {
                    Txtfrom.Text = "01/04/" + vouyeartext;
                    Txtto.Text = Str_CurrrentDate.ToString();

                }
                else
                {
                    Txtfrom.Text = "01/04/" + vouyeartext;
                    Txtto.Text = "31/03/" + (vouyeartext + 1);
                }
                //Txtfrom.Text = Str_CurrrentDate;
                //Txtto.Text = Str_CurrrentDate;
                lblvou.Text = "";
                grd.DataSource = Utility.Fn_GetEmptyDataTable();
                grd.DataBind();
                grdvouchers.DataSource = Utility.Fn_GetEmptyDataTable();
                grdvouchers.DataBind();
                pnlvouchers.Visible = true;
                btn_back.Text = "Back";
                btn_back.ToolTip = "Back";
                btn_back1.Attributes["class"] = "btn ico-back";
            }
            else
            {
                /// this.Response.End();
                /// 
                if (Session["StrTranType"] != null)
                {
                    if (Session["StrTranType"].ToString() == "CO")
                    {
                        Response.Redirect("../Home/CorporateHome.aspx");
                    }
                    else if (Session["StrTranType"].ToString() == "BR")
                    {
                        Response.Redirect("../Home/Branch_home.aspx");

                    }
                    else if (Session["StrTranType"].ToString() == "AC")
                    {
                        Response.Redirect("../Home/Branch_home.aspx");
                    }
                    else if (Session["home"] != null)
                    {
                        if (Session["home"].ToString() == "FABR")
                        {
                            Response.Redirect("../Home/Branch_home.aspx");
                        }
                        else if (Session["home"].ToString() == "FAFC")
                        {
                            Response.Redirect("../Home/CorporateHome.aspx");
                        }
                    }

                }
                else if (Session["home"] != null)
                {
                    if (Session["home"].ToString() == "FABR")
                    {
                        Response.Redirect("../Home/Branch_home.aspx");
                    }
                    else if (Session["home"].ToString() == "FAFC")
                    {
                        Response.Redirect("../Home/CorporateHome.aspx");
                    }
                }
                else
                {
                    this.Response.End();
                }


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
            Panel3.Visible = true;
            DataTable obj_dtlogdetails = new DataTable();
            //DataAccess.LogDetails Logobj = new DataAccess.LogDetails();
            if (Session["str_ModuleName"].ToString() == "FA")
            {
                obj_dtlogdetails = Logobj.InsTempGrpLogdtlsGet(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), 1252, "", "", "", Session["StrTranType"].ToString());
            }
            else
            {
                obj_dtlogdetails = Logobj.InsTempGrpLogdtlsGet(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), 1253, "", "", "", Session["StrTranType"].ToString());
            }


            if (obj_dtlogdetails.Rows.Count >= 0)
            {
                ModalPopupExtenderlog.Show();
                GridViewlog.DataSource = obj_dtlogdetails;
                GridViewlog.DataBind();
            }
        }

        protected void grd_PreRender(object sender, EventArgs e)
        {
            if (grd.Rows.Count > 0)
            {
                grd.UseAccessibleHeader = true;
                grd.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }

    }
}