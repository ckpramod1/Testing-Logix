using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace logix.FAForm
{
    public partial class Journal_Proforma : System.Web.UI.Page
    {
        DataAccess.FAVoucher Obj_FAVoucher = new DataAccess.FAVoucher();        
        DataAccess.Accounts.Journal Obj_Journal = new DataAccess.Accounts.Journal();
        DataAccess.Masters.MasterEmployee Obj_Mast_Emp = new DataAccess.Masters.MasterEmployee();
        DataAccess.LogDetails da_obj_Log = new DataAccess.LogDetails();
        DataAccess.Masters.MasterBranch Master_Branch = new DataAccess.Masters.MasterBranch();
        DataAccess.FAVoucher da_obj_vou = new DataAccess.FAVoucher();
        DataAccess.LogDetails Logobj = new DataAccess.LogDetails();

        int Division_ID, Branch_Id, Emp_ID, Pro_VouNo, Pro_Vouyear, Journalno, VouYear, Vou_ID;
        string DB_Name, frmname, JournalDate, strdnno = "";
        DataTable dt = new DataTable();
        
        protected void Page_Load(object sender, EventArgs e)
        {
               
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "SpanTagMoveInputBottom();MuiTextField();", true);

            string Ccode = Convert.ToString(Session["Ccode"]);

            if (Ccode != "")
            {

                Obj_FAVoucher.GetDataBase(Ccode);
                Obj_Journal.GetDataBase(Ccode);
                Obj_Mast_Emp.GetDataBase(Ccode);
                da_obj_Log.GetDataBase(Ccode);
                Master_Branch.GetDataBase(Ccode);
                da_obj_vou.GetDataBase(Ccode);
                Logobj.GetDataBase(Ccode);
                



            }

            if (Session["LoginUserName"] == null || Session["LoginEmpId"] == null || Session["LoginDivisionId"] == null || Session["LoginBranchid"] == null)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alertify.alert('Session TimeOut');window.open('"+ Session["Site"].ToString() + "/','_top');", true);
            }
            if (Request.QueryString.ToString().Contains("FormName"))
            {
                lbl_Header.Text = Request.QueryString["FormName"].ToString();
            }

            Emp_ID = Convert.ToInt32(Session["LoginEmpId"].ToString());
            Branch_Id = Convert.ToInt32(Session["LoginBranchid"].ToString());
            Division_ID = Convert.ToInt32(Session["LoginDivisionId"].ToString());
            DB_Name = Session["FADbname"].ToString();

            if (!IsPostBack)
            {
                lbnl_logyear.Text = Session["LYEAR"].ToString();
                dt = Obj_FAVoucher.GetApproveProJou(DB_Name, Branch_Id);
                Grd_Approval.DataSource = dt;
                Grd_Approval.DataBind();                
            }         
        }

        protected void btn_Approve_Click(object sender, EventArgs e)
        {
            int current_month, Journal_month;
            string str_Pro_VouNo = "";
            current_month = da_obj_Log.GetDate().Month; 


            foreach (GridViewRow Row in Grd_Approval.Rows)
            {
                CheckBox Chk = (CheckBox)Row.FindControl("Chk_Approval");
                if (Chk.Checked == true)
                {
                    Pro_VouNo = Convert.ToInt32(Grd_Approval.Rows[Row.RowIndex].Cells[0].Text);
                    JournalDate = Utility.fn_ConvertDate(Grd_Approval.Rows[Row.RowIndex].Cells[1].Text);
                    if (str_Pro_VouNo.Trim() == "")
                    {
                        str_Pro_VouNo = Pro_VouNo.ToString();
                    }
                    else
                    {
                        str_Pro_VouNo = " , " + Pro_VouNo.ToString();
                    }
                 
                    Journal_month = Convert.ToDateTime(JournalDate).Month;
                    //if (current_month > Journal_month && Convert.ToInt32(Session["LoginDivisionId"]) == 1)
                    //{
                    //    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), "alertify.alert('You have no rights to approve Voucher # " + Pro_VouNo + " for Back Dated Journal')", true);
                    //    continue;
                    //} 
                    Pro_Vouyear = Convert.ToInt32(Grd_Approval.DataKeys[Row.RowIndex].Values[0].ToString());
                    Vou_ID = Convert.ToInt32(Grd_Approval.DataKeys[Row.RowIndex].Values[1].ToString());
                    
                    int Preparedby = Obj_Mast_Emp.GetNEmpid(Grd_Approval.Rows[Row.RowIndex].Cells[5].Text);

                    if (Preparedby == Emp_ID)
                    {
                        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), "alertify.alert('You have no rights to approve Voucher # " + Pro_VouNo + " prepared by you')", true);
                        return;
                    }
                    Journalno = Obj_Journal.GetJournalNoMONTH(Branch_Id, Convert.ToDateTime(JournalDate));
                    Obj_FAVoucher.UpdApprovalProJou(Journalno, Emp_ID, Vou_ID, DB_Name, Convert.ToDateTime(JournalDate));

                    if (Session["str_ModuleName"].ToString() == "FA")
                    {
                        da_obj_Log.InsLogDetail(Emp_ID, 1354, 1, Branch_Id, frmname + " # - " + Pro_VouNo);
                    }
                    else
                    {
                        da_obj_Log.InsLogDetail(Emp_ID, 1355, 1, Branch_Id, frmname + " # - " + Pro_VouNo);
                    }

                    strdnno = strdnno + Journalno + ",";
                }           
            }

            if (Journalno != 0)
            {
                int l;
                l = strdnno.Length;
                strdnno = strdnno.Remove(l - 1, 1);
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), "alertify.alert('Journal # " + strdnno + " Generated and Transfered')", true);
            }

            dt = Obj_FAVoucher.GetApproveProJou(DB_Name, Branch_Id);
            Grd_Approval.DataSource = dt;
            Grd_Approval.DataBind();
        }
               
        protected void btn_cancel_Click(object sender, EventArgs e)
        {
            if (btn_cancel.ToolTip == "Back")
            {
                //this.Response.End();
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


        ///Ruban
        ///

        protected void Grd_Approval_SelectedIndexChanged(object sender, EventArgs e)
        {
            approval();

        }

        public void approval()
        {

            //hide on 20/07/2022 --for  report call from dhaney backup  bhuvi


            //DataAccess.Masters.MasterBranch Master_Branch = new DataAccess.Masters.MasterBranch();
            //string Str_sp = "", Str_sf = "", Str_RptName = "", Str_Script = "";
            //int bid = Convert.ToInt32(Session["LoginBranchid"].ToString());
            //string BranchName = Master_Branch.Getbranchname(bid);


            //Str_RptName = "rptJVpro.rpt";
            //Session["str_sfs"] = "{FAMasterVoucherHead4ProVou.vouno}=" + Grd_Approval.SelectedRow.Cells[0].Text + " and {FAMasterVoucherHead4ProVou.voutype}=13 and {FAMasterVoucherHead4ProVou.branchid}=" + Convert.ToInt32(Session["LoginBranchid"]) + " and {FAMasterVoucherHead4ProVou.divisionid}= " + Convert.ToInt32(Session["LoginDivisionId"].ToString()) + " and month({FAMasterVoucherHead4ProVou.voudate})=" +Convert.ToDateTime(Utility.fn_ConvertDate( Grd_Approval.SelectedRow.Cells[1].Text)).Month;
            //Session["str_sp"] = "Title=PROFORMA JOURNAL~PeriodFrom=" + "Apr" + Session["FA_Year"].ToString().Substring(0, 2) + "~PeriodTo=" + "Mar" + Session["FA_Year"].ToString().Substring(3, 2);

            //Str_Script = "window.open('../Tools/ReportViewFA.aspx?SFormula=" + Str_sf + "&Parameter=" + Str_sp + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
            //ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), Str_Script, true);




            //hide end 20/07/2022 --for  report call from dhaney backup 


            //DataAccess.Masters.MasterBranch Master_Branch = new DataAccess.Masters.MasterBranch();
            string Str_sp = "", Str_sf = "", Str_RptName = "", Str_Script = "", ledgername = "";
            int vouid;
            int bid = Convert.ToInt32(Session["LoginBranchid"].ToString());
            string BranchName = Master_Branch.Getbranchname(bid);
         

            //contra
            dt = Obj_FAVoucher.GetApproveProJou(DB_Name, Branch_Id);
            //if (dt.Rows.Count > 0)
            //{
            //    int i;
            //    for (i = 0; i <= dt.Rows.Count; i++)
            //    {     double 
            //vouid = Convert.ToInt32(Grd_Approval.SelectedRow.Cells[7].Text.ToString());
            
                  double  amount = Convert.ToDouble(Grd_Approval.SelectedRow.Cells[4].Text.ToString());

                  vouid = Convert.ToInt32(Grd_Approval.SelectedRow.Cells[8].Text.ToString());
               //     vouid = Convert.ToInt32(dt.Rows[0]["vouid"].ToString());

                    
                    ledgername = dt.Rows[0]["customer"].ToString();
                    //DataAccess.FAVoucher da_obj_vou = new DataAccess.FAVoucher();
                    da_obj_vou.SelFAAllVoucherNew(Convert.ToInt32(vouid), Convert.ToInt32(Session["LoginEmpId"].ToString()), Session["FADbname"].ToString());
                    //Str_RptName = "rptContra1.rpt";
                    Str_RptName = "rptJournal.rpt";
                    //Session["str_sfs"] = "{MasterVoucherHead.vouno}=" + txt_contra.Text + " and {MasterVoucherHead.voutype}=14 and {MasterVoucherHead.branchid}=" + Convert.ToInt32(Session["LoginBranchid"]) + " and {MasterVoucherHead.divisionid}= " + Convert.ToInt32(Session["LoginDivisionId"]);
                    Session["str_sfs"] = " {Tempvoucher.vouid}=" + vouid + "And {Tempvoucher.empid} = " + Session["LoginEmpId"].ToString();
                    Session["str_sp"] = "PeriodFrom=" + "Apr" + Session["FA_Year"].ToString().Substring(0, 2) + "~PeriodTo=" + "Mar" + Session["FA_Year"].ToString().Substring(3, 2);
                    Str_Script = "window.open('../Tools/ReportViewFA.aspx?SFormula=" + Str_sf + "&Parameter=" + Str_sp + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), Str_Script, true);
            //    }
            //}
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
            //DataAccess.LogDetails Logobj = new DataAccess.LogDetails();

            if (Session["str_ModuleName"].ToString() == "FA")
            {
                obj_dtlogdetails = Logobj.InsTempGrpLogdtlsGet(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), 1354, "", "", "", Session["StrTranType"].ToString());
            }
            else
            {
                obj_dtlogdetails = Logobj.InsTempGrpLogdtlsGet(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), 1355, "", "", "", Session["StrTranType"].ToString());
            }



            if (obj_dtlogdetails.Rows.Count >= 0)
            {
                ModalPopupExtenderlog.Show();
                GridViewlog.DataSource = obj_dtlogdetails;
                GridViewlog.DataBind();
            }
        }

        protected void Grd_Approval_PreRender(object sender, EventArgs e)
        {
            if (Grd_Approval.Rows.Count > 0)
            {
                Grd_Approval.UseAccessibleHeader = true;
                Grd_Approval.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }

        protected void GridViewlog_PreRender(object sender, EventArgs e)
        {
            if (GridViewlog.Rows.Count > 0)
            {
                GridViewlog.UseAccessibleHeader = true;
                GridViewlog.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }
    }
}