using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Data;
using System.Web.Script.Services;

namespace logix.FAForm
{
    public partial class Ledgers : System.Web.UI.Page
    {
        DataAccess.FAMaster.MasterGroup obj = new DataAccess.FAMaster.MasterGroup();
        DataAccess.FAMaster.MasterSubGroup sobj = new DataAccess.FAMaster.MasterSubGroup();
        DataAccess.FAMaster.MasterLedger ledgerobj = new DataAccess.FAMaster.MasterLedger();
        DataAccess.Masters.MasterCustomer customerobj = new DataAccess.Masters.MasterCustomer();
        DataAccess.Masters.MasterCharges chrgobj = new DataAccess.Masters.MasterCharges();

        DataAccess.Masters.MasterTDSType TDSobj = new DataAccess.Masters.MasterTDSType();
        DataAccess.FAMaster.MasterLedger Obj_Ledger = new DataAccess.FAMaster.MasterLedger();
        DataAccess.LogDetails Logobj = new DataAccess.LogDetails();
        int i;
        DataTable dt = new DataTable();
        DataTable dt1 = new DataTable();
        DataTable sdt = new DataTable();
        DataTable sdt1 = new DataTable();
        DataTable dtl = new DataTable();
        DataTable dtl1 = new DataTable();
        int groupid, ledgerid, sgroupid;

        string gname;
        string sgname;
        string lt;
        string pbtype;
        string obtype;
        string ObtypeUSD;
        string OcolumnameUSD;


        string ledgername;
        string acctype;
        string pcolumname, ocolumname, strslab;
        string strdesc;
        bool blnErr = false;

        DataTable dtgrd = new DataTable();
        int j;
        int k;
        int intcid;
        string type;
        bool blnops = false;
        int opsid;
        string opstype;
        //RPT rptclass = new RPT();

        char ccapp;
        char tdsType;
        DataAccess.LogDetails logobj = new DataAccess.LogDetails();
        public string submenuname;
        public string strtrantype;
        DataTable dtTDS = new DataTable();
        DataTable dtTDSType = new DataTable();
        double dblpre;
        int TDSid;
        string lstve;
        int Emp_Id, BranchId, Div_Id;
        string FaDbName;

        protected void Page_Load(object sender, EventArgs e)
        {

            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "SpanTagMoveInputBottom();MuiTextField();", true);


            string Ccode = Convert.ToString(Session["Ccode"]);

            if (Ccode != "")
            {

                obj.GetDataBase(Ccode);
                sobj.GetDataBase(Ccode);
                ledgerobj.GetDataBase(Ccode);
                customerobj.GetDataBase(Ccode);
                chrgobj.GetDataBase(Ccode);
                TDSobj.GetDataBase(Ccode);
                logobj.GetDataBase(Ccode);


                Obj_Ledger.GetDataBase(Ccode);
                Logobj.GetDataBase(Ccode);
               

            }

            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(btncancel);
            
            if (Session["LoginUserName"] == null || Session["LoginEmpId"] == null || Session["LoginDivisionId"] == null || Session["LoginBranchid"] == null)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alertify.alert('Session TimeOut');window.open('"+ Session["Site"].ToString() + "/','_top');", true);
            }

            if (Request.QueryString.ToString().Contains("FormName"))
            {
                lbl_head.Text = Request.QueryString["FormName"].ToString();
            }

            Emp_Id = Convert.ToInt32(Session["LoginEmpId"].ToString());
            FaDbName = HttpContext.Current.Session["FADbname"].ToString();
            BranchId = Convert.ToInt32(Session["LoginBranchid"].ToString());
            Div_Id = Convert.ToInt32(Session["LoginDivisionId"].ToString());
            strtrantype = Session["str_ModuleName"].ToString();

            if (!IsPostBack)
            {
                lbnl_logyear.Text = Session["LYEAR"].ToString();
                grd.DataSource = new DataTable();
                grd.DataBind();
                btncancel.ToolTip = "Back";
                btncancel.Text = "Back";
                btncancel1.Attributes["class"] = "btn ico-back";

            }
            else if (Page.IsPostBack)
            {

                //WebControl wcICausedPostBack = (WebControl)GetControlThatCausedPostBack(sender as Page);
                //int indx = wcICausedPostBack.TabIndex;
                //var ctrl = from control in wcICausedPostBack.Parent.Controls.OfType<WebControl>()
                //            where control.TabIndex > indx
                //            select control;
                //ctrl.DefaultIfEmpty(wcICausedPostBack).First().Focus();
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "test", "TxtFocus();", true);

            }
        }                

        [WebMethod]
        public static List<string> GetLedgername(string prefix)
        {
            DataAccess.FAMaster.MasterLedger lgerobj = new DataAccess.FAMaster.MasterLedger();
            string Ccode = HttpContext.Current.Session["Ccode"].ToString();
            lgerobj.GetDataBase(Ccode);
            DataTable obj_Dt = new DataTable();
            List<string> LedgerList = new List<string>();
            obj_Dt = lgerobj.GetLikeLedgername(prefix.ToUpper(), Convert.ToInt32(HttpContext.Current.Session["LoginDivisionid"].ToString()), Convert.ToInt32(HttpContext.Current.Session["LoginBranchid"].ToString()), HttpContext.Current.Session["FADbname"].ToString());
            LedgerList = Utility.Fn_DatatableToList_stringnew(obj_Dt, "LNandPort", "ledgerid");
            return LedgerList;
        }

        [WebMethod]
        public static List<string> GetSubgroupname(string prefix)
        {
            DataAccess.FAMaster.MasterSubGroup subobj = new DataAccess.FAMaster.MasterSubGroup();
            string Ccode = HttpContext.Current.Session["Ccode"].ToString();
            subobj.GetDataBase(Ccode);
            DataTable obj_Dt = new DataTable();
            List<string> LedgerList = new List<string>();
            obj_Dt = subobj.GetLikesubGroupname(prefix.ToUpper(), HttpContext.Current.Session["FADbname"].ToString());
            LedgerList = Utility.Fn_DatatableToList_stringnew(obj_Dt, "subgroupname", "subgroupid");
            return LedgerList;
        }


        [WebMethod]
        public static void GetLedgerNameNew(string Prefix)
        {

            DataTable obj_dtEmp = new DataTable();

            if (Prefix.Length > 0)
            {
                DataAccess.Masters.MasterCustomer customerobj = new DataAccess.Masters.MasterCustomer();
                string Ccode = HttpContext.Current.Session["Ccode"].ToString();
                customerobj.GetDataBase(Ccode);
                DataTable obj_dt = new DataTable();
                obj_dt = customerobj.GetLikeCustomerAll4Grd(Prefix);
                obj_dtEmp.Columns.Add("cname");
                obj_dtEmp.Columns.Add("cid");
                obj_dtEmp.Columns.Add("type");
                obj_dtEmp.Columns.Add("Chk_Grd");
                DataRow dr;

                for (int i = 0; i <= obj_dt.Rows.Count - 1; i++)
                {
                    dr = obj_dtEmp.NewRow();
                    obj_dtEmp.Rows.Add(dr);
                    dr["cname"] = obj_dt.Rows[i]["cname"].ToString();
                    dr["cid"] = obj_dt.Rows[i]["cid"].ToString();
                    dr["type"] = obj_dt.Rows[i]["type"].ToString();

                }
                HttpContext.Current.Session["Date"] = obj_dtEmp;

            }

        }
        protected void btn_search_Click(object sender, EventArgs e)
        {
            DataTable obj_dtEmp = new DataTable();
            if (txtSearch.Text != "")
            {

                if (Session["Date"] != null)
                {
                    obj_dtEmp = (DataTable)Session["Date"];
                    ViewState["Bak"] = obj_dtEmp;
                    grd.DataSource = obj_dtEmp;
                    grd.DataBind();

                }
                else
                {
                    grd.DataSource = null;
                    grd.DataBind();
                }
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "test", "TxtFocus();", true);
            }
            
        }


        private void fillTDSType()
        {
            dtTDSType = TDSobj.SelAllTDSDtls();
            for (i = 0; i <= dtTDSType.Rows.Count - 1; i++)
            {
                CmbType.SelectedItem.Text = dtTDSType.Rows[i]["tdsdesc"].ToString();
                if (CmbType.SelectedValue == "false")
                {
                    CmbType.Items.Add(dtTDSType.Rows[i]["tdsdesc"].ToString());
                }
            }
        }
        
        protected void txtsubgroupname_TextChanged(object sender, EventArgs e)
        {
            if (txtsubgroupname.Text != "")
            {
                DataTable dtSub = new DataTable();
                dtSub = sobj.SelMastersubGroup(Convert.ToInt32(hid_SubGroupid.Value), Session["FADbname"].ToString());
                if (dtSub.Rows.Count > 0)
                {
                    hid_GroupID.Value = dtSub.Rows[0][0].ToString();
                    txtGroupname.Text = dtSub.Rows[0][1].ToString();
                    txtgroupetype.Text = dtSub.Rows[0][3].ToString();
                }           
            }
        }

        protected void cmbLedgerType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbLedgerType.SelectedItem.Text == "CASH")
            {
                cmbminmaxamt.SelectedValue = "D";
                cmbminmaxamt.Enabled = false;
            }
            else
            {
                cmbminmaxamt.Enabled = true;
            }

            if (cmbLedgerType.SelectedItem.Text == "GL - NF")
            {               
                grd.Visible = true;
                Label8.Visible = true;
                txtSearch.Visible = true;
            }
            else
            {               
                grd.Visible = false;
                Label8.Visible = false;
                txtSearch.Visible = false;
            }
        }          

        public override void VerifyRenderingInServerForm(Control control)
        {
            //required to avoid the run time error "  
            //Control 'GridView1' of type 'Grid View' must be placed inside a form tag with runat=server."  
        }


        protected void cmbopbal_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (cmbopbal.SelectedItem.Text == "Debit")
            {
                obtype = "";
                obtype = "D";
                pcolumname = "";
                pcolumname = "opbaldb";
                cmbopbal.SelectedValue = "D";
            }
            else if (cmbopbal.SelectedItem.Text == "Credit")
            {
                obtype = "";
                obtype = "C";
                pcolumname = "";
                pcolumname = "opbalcr";
                cmbopbal.SelectedValue = "C";
            }
        }

        protected void cmbCostApp_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCostApp.SelectedItem.Text == "Yes")
            {
                ccapp = 'Y';
            }
            else
            {
                ccapp = 'N';
            }
        }

        protected void btnsave_Click(object sender, EventArgs e)
        {
            FaDbName = HttpContext.Current.Session["FADbname"].ToString();
            Emp_Id = Convert.ToInt32(Session["LoginEmpId"].ToString());
            Collectdata();
            CheckData();           

            if (blnErr == true)
            {
                return;
            }

            if (blnops == true)
            {

            }
            else
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), "alertify.alert('You Must select the Operation Name');", true);
                blnops = false;
                txtSearch.Focus();
                return;
            }

            Collectdata();

            double minbaldr = 0;
            double maxbaldr = 0;
            double minbalcr = 0;
            double maxbalcr = 0;

            if (cmbminmaxamt.SelectedItem.Text == "Credit")
            {
                minbalcr = Convert.ToDouble(txtMinAmt.Text);
                maxbalcr = Convert.ToDouble(txtMaxAmt.Text);
            }
            else
            {
                minbaldr = Convert.ToDouble(txtMinAmt.Text);
                maxbaldr = Convert.ToDouble(txtMaxAmt.Text);
            }

            if (txt_OpBalUSD.Text == "")
            {
                txt_OpBalUSD.Text = "0.00";
            }
            if (ObtypeUSD == null)
            {
                char ObtypeUSD1;
                ObtypeUSD1 = '\0';

                ObtypeUSD = ObtypeUSD1.ToString();
            }

            if (pcolumname == null || ocolumname == null)
            {
                pcolumname = "";
                ocolumname = "";
            }
            DataTable dtnew = new DataTable();
          //  hid_Ledgername.Value;
            


            if (btnsave.ToolTip == "Save")
            {                
                cmbopbal_SelectedIndexChanged(sender, e);
                cmbpvybal_SelectedIndexChanged(sender, e);
                ddl_Curr_SelectedIndexChanged(sender, e);
                cmbCostApp_SelectedIndexChanged(sender, e);
                data();
                get();
                debt();
                
                if (txtpybl.Value == "")
                {
                    txtpybl.Value = "0.00";
                }

                if (txt_OpBalUSD.Text == "")
                {
                    txt_OpBalUSD.Text = "0.00";
                }

                if (txtOpbal.Text == "")
                {
                    txtOpbal.Text = "0.00";
                }

                



                ledgerid = ledgerobj.InsLedgerHead(txtLedgerName.Text.ToUpper(), Convert.ToInt32(hid_SubGroupid.Value), Convert.ToInt32(hid_GroupID.Value), Convert.ToChar(lt), FaDbName);

                ledgerobj.InsLedgerDetails(ledgerid, Div_Id, BranchId, Convert.ToChar(cmbopbal.SelectedValue), Convert.ToChar(obtype), Convert.ToDouble(txtpybl.Value.ToString()), Convert.ToDouble(txtOpbal.Text), FaDbName);
                ledgerobj.UpdateLedgerDetails4USD(ledgerid, BranchId, Convert.ToDouble(txt_OpBalUSD.Text), Convert.ToChar(ObtypeUSD), FaDbName, txt_Curr.Text);
                ledgerobj.UpdLedgerDetails(ledgerid, Div_Id, BranchId, 'P', Convert.ToDouble(txtpybl.Value.ToString()), Convert.ToDouble(txtOpbal.Text), pcolumname, FaDbName, minbaldr, maxbaldr, minbalcr, maxbalcr, ccapp);
                ledgerobj.UpdLedgerDetails(ledgerid, Div_Id, BranchId, 'O', Convert.ToDouble(txtpybl.Value.ToString()), Convert.ToDouble(txtOpbal.Text), ocolumname, FaDbName, minbaldr, maxbaldr, minbalcr, maxbalcr, ccapp);
                updledggername();
                ledgerobj.UpdSerTaxandPan4Ldgr(ledgerid, txtSerTaxno.Text, txtPanno.Text, FaDbName, BranchId);

                


                if (Session["str_ModuleName"].ToString() == "FA")
                {
                    logobj.InsLogDetail(Emp_Id, 1086, 1, BranchId, txtLedgerName.Text + " " + ledgerid + "/ S");
                }
                else
                {
                    logobj.InsLogDetail(Emp_Id, 1176, 1, BranchId, txtLedgerName.Text + " " + ledgerid + "/ S");
                }

                ledgerobj.UpdAliasName4Ledger(FaDbName, ledgerid, txt_AliasName.Text.Trim());

                if (Session["str_ModuleName"].ToString() == "FA")
                {
                    logobj.InsLogDetail(Emp_Id, 1086, 1, BranchId, "Alias/" + txt_AliasName.Text + "/" + ledgerid + "/S - " + cmbminmaxamt.SelectedItem.Text + " : Min amt - " + txtMinAmt.Text + ", Max amt - " + txtMaxAmt.Text);
                }
                else
                {
                    logobj.InsLogDetail(Emp_Id, 1176, 1, BranchId, "Alias/" + txt_AliasName.Text + "/" + ledgerid + "/S - " + cmbminmaxamt.SelectedItem.Text + " : Min amt - " + txtMinAmt.Text + ", Max amt - " + txtMaxAmt.Text);
                }

                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), "alertify.alert('Details Saved');", true);
            }

            else if (btnsave.ToolTip == "Update")
            {
                



                cmbopbal_SelectedIndexChanged(sender, e);
                cmbpvybal_SelectedIndexChanged(sender, e);
                ddl_Curr_SelectedIndexChanged(sender, e);
                cmbCostApp_SelectedIndexChanged(sender, e);
                data();
                get();
                debt();



                /***********************************  For Every FA Year Updation  *******************************************/
                int vyear, vyear1;
                int curryear;
                string FAYear1;

                vyear = Convert.ToInt32(Session["Vouyear"].ToString());

                int currmon = DateTime.Today.Month;
                if (currmon < 4 )
                {
                    curryear = DateTime.Today.Year - 1;
                }
                else
                {
                    curryear = DateTime.Today.Year;
                }
                
                //curryear = DateTime.Today.Year;

                if (vyear <= curryear)
                {
                    for (int i = vyear; i <= curryear; i++)
                    {
                        vyear1 = i;
                        FAYear1 = vyear1.ToString();
                        FAYear1 = FAYear1.Substring(2, 2);
                        vyear1 = vyear1 + 1;
                        FAYear1 = Convert.ToInt32(FAYear1) + Convert.ToString(vyear1).Substring(2, 2);
                        string Str_DBname = "FA" + FAYear1;

                        dtnew = ledgerobj.Getledgerviewcheck(Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()), Convert.ToInt32(Session["ledgid"]), Str_DBname);

                        if (dtnew.Rows.Count > 0 && (Convert.ToInt32(hid_GroupID.Value) != 12 || Convert.ToInt32(hid_GroupID.Value) != 13))
                        {
                            ScriptManager.RegisterStartupScript(btnsave, typeof(Button), "FA", "alertify.alert('Journal vouchers are there, you are not allowed to change the sub group name as '" + txtsubgroupname.Text + "');", true);
                            return;
                        }

                        ledgerobj.UpdLedgerHead(txtLedgerName.Text.ToUpper(), Convert.ToInt32(hid_SubGroupid.Value), Convert.ToInt32(Convert.ToInt32(hid_GroupID.Value)), Convert.ToChar(lt), Convert.ToInt32(Session["ledgid"]), Str_DBname);
                        ledgerobj.UpdateLedgerDetails4USD(Convert.ToInt32(Session["ledgid"]), BranchId, Convert.ToDouble(txt_OpBalUSD.Text), Convert.ToChar(ObtypeUSD), Str_DBname, txt_Curr.Text);
                        ledgerobj.UpdLedgerDetails(Convert.ToInt32(Session["ledgid"]), Div_Id, BranchId, 'P', Convert.ToDouble(txtpybl.Value.ToString()), Convert.ToDouble(txtOpbal.Text), pcolumname.ToString(), Str_DBname, minbaldr, maxbaldr, minbalcr, maxbalcr, ccapp);
                        ledgerobj.UpdLedgerDetails(Convert.ToInt32(Session["ledgid"]), Div_Id, BranchId, 'O', Convert.ToDouble(txtpybl.Value.ToString()), Convert.ToDouble(txtOpbal.Text), ocolumname.ToString(), Str_DBname, minbaldr, maxbaldr, minbalcr, maxbalcr, ccapp);
                        updledggername();

                        ledgerobj.UpdSerTaxandPan4Ldgr(Convert.ToInt32(Session["ledgid"]), txtSerTaxno.Text, txtPanno.Text, Str_DBname, BranchId);

                        ledgerobj.UpdAliasName4Ledger(Str_DBname, Convert.ToInt32(Session["ledgid"]), txt_AliasName.Text.Trim());
                    }
                }

                /************************************************************************************************************/



                //dtnew = ledgerobj.Getledgerviewcheck(Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()), Convert.ToInt32(Session["ledgid"]), Session["FADbname"].ToString());

                //if (dtnew.Rows.Count > 0 && (Convert.ToInt32(hid_GroupID.Value) != 12 || Convert.ToInt32(hid_GroupID.Value) != 13))
                //{
                //    ScriptManager.RegisterStartupScript(btnsave, typeof(Button), "FA", "alertify.alert('Journal vouchers are there, you are not allowed to change the sub group name as '" +txtsubgroupname.Text+"');", true);
                //    return;
                //}

                //ledgerobj.UpdLedgerHead(txtLedgerName.Text.ToUpper(), Convert.ToInt32(hid_SubGroupid.Value), Convert.ToInt32(Convert.ToInt32(hid_GroupID.Value)), Convert.ToChar(lt), Convert.ToInt32(Session["ledgid"]), FaDbName);
                //ledgerobj.UpdateLedgerDetails4USD(Convert.ToInt32(Session["ledgid"]), BranchId, Convert.ToDouble(txt_OpBalUSD.Text), Convert.ToChar(ObtypeUSD), FaDbName, txt_Curr.Text);
                //ledgerobj.UpdLedgerDetails(Convert.ToInt32(Session["ledgid"]), Div_Id, BranchId, 'P', Convert.ToDouble(txtpybl.Value.ToString()), Convert.ToDouble(txtOpbal.Text), pcolumname.ToString(), FaDbName, minbaldr, maxbaldr, minbalcr, maxbalcr, ccapp);
                //ledgerobj.UpdLedgerDetails(Convert.ToInt32(Session["ledgid"]), Div_Id, BranchId, 'O', Convert.ToDouble(txtpybl.Value.ToString()), Convert.ToDouble(txtOpbal.Text), ocolumname.ToString(), FaDbName, minbaldr, maxbaldr, minbalcr, maxbalcr, ccapp);
                //updledggername();

                //ledgerobj.UpdSerTaxandPan4Ldgr(Convert.ToInt32(Session["ledgid"]), txtSerTaxno.Text, txtPanno.Text, FaDbName, BranchId);



                if (Session["str_ModuleName"].ToString() == "FA")
                {
                    logobj.InsLogDetail(Emp_Id, 1086, 2, BranchId, txtLedgerName.Text + " " + Convert.ToInt32(hid_Ledgername.Value) + "/ U");
                }
                else
                {
                    logobj.InsLogDetail(Emp_Id, 1176, 2, BranchId, txtLedgerName.Text + " " + Convert.ToInt32(hid_Ledgername.Value) + "/ U");
                }

                //ledgerobj.UpdAliasName4Ledger(FaDbName, Convert.ToInt32(Session["ledgid"]), txt_AliasName.Text.Trim());

                if (Session["str_ModuleName"].ToString() == "FA")
                {
                    logobj.InsLogDetail(Emp_Id, 1086, 1, BranchId, "Alias/" + txt_AliasName.Text + "/" + ledgerid + "/U - " + cmbminmaxamt.SelectedItem.Text + " : Min amt - " + txtMinAmt.Text + ", Max amt - " + txtMaxAmt.Text);
                }
                else
                {
                    logobj.InsLogDetail(Emp_Id, 1176, 1, BranchId, "Alias/" + txt_AliasName.Text + "/" + ledgerid + "/U - " + cmbminmaxamt.SelectedItem.Text + " : Min amt - " + txtMinAmt.Text + ", Max amt - " + txtMaxAmt.Text);
                }

                if (CmbType.SelectedValue == "I")
                {
                    tdsType = 'I';
                }
                else if (CmbType.SelectedValue == "C")
                {
                    tdsType = 'C';
                }

                TDSid = TDSobj.GetTDSid(Session["strdes"].ToString(), tdsType, Session["strlab"].ToString(), dblpre);
                if (TDSid > 0)
                {
                    if (opsid > 0)
                    {
                        TDSobj.UpdTDSid(TDSid, opsid);
                    }
                }
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), "alertify.alert('Details Updated');", true);
            }
            btnsave.Enabled = false;
            Clear_All();
        }        

        public void Collectdata()
        {
            if (cmbLedgerType.SelectedValue == "C")
            {
                lt = "C";
            }
            else if (cmbLedgerType.SelectedValue == "B")
            {
                lt = "B";
            }
            else if (cmbLedgerType.SelectedValue == "G")
            {
                lt = "G";
            }

            else if (cmbLedgerType.SelectedValue == "F")
            {
                lt = "F";
            }
            acctype = lt;
        }

        public void updledggername()
        {
            //for (j = 0; j <= grd.Rows.Count - 1; j++)
            //{
            //    CheckBox Grd_Chk = (CheckBox)grd.Rows[j].FindControl("Chk_Grd");
            //    if (Grd_Chk.Checked == true)
            //    {
            //        //int_fileextn = int.Parse(grdFileExtn.DataKeys[f].Value.ToString());
            //        intcid = int.Parse(grd.DataKeys[j].Value.ToString());
            //        //type = grd.Rows(j).Cells("cshtype").Value;

            //        ledgerobj.UpdLedgerid(Session["FADbname"].ToString(), Convert.ToInt32(Session["LoginBranchid"].ToString()), ledgerid, intcid, Convert.ToChar(type));
            //        logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"].ToString()), 1135, 2, Convert.ToInt32(Session["LoginBranchid"].ToString()),ledgerid + "-" + type);
            //    }
            //}

            DataTable dtGrid=new DataTable();
            dtGrid = (DataTable)ViewState["grd_Det"];
            if (ledgerid==0)
            {
                if (hid_Ledgername.Value!="" && hid_Ledgername.Value!="0")
                {
                    ledgerid = Convert.ToInt32(hid_Ledgername.Value);
                }else
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), "alertify.alert('Invalid Ledger');", true);
                
                    return;

                }
            }
            
            for (int i = 0; i <= grd.Rows.Count - 1; i++)
            {
                CheckBox Grd_Chk = (CheckBox)grd.Rows[i].FindControl("Chk_Grd");
                if (Grd_Chk.Checked == true)
                {
                    intcid = Convert.ToInt32(grd.Rows[i].Cells[1].Text);
                    type = grd.Rows[i].Cells[2].Text;
                    ledgerobj.UpdLedgerid(FaDbName, BranchId, ledgerid, intcid, Convert.ToChar(type));
                    logobj.InsLogDetail(Emp_Id, 1135, 2, BranchId, ledgerid + "-" + type);
                }
            }
        }
              
        public void fill()
        {
            if (acctype == "C")
            {
                cmbLedgerType.SelectedValue = "C";            
            }
            else if (acctype == "B")
            {
                cmbLedgerType.SelectedValue = "B";                
            }
            else if (acctype == "G")
            {
                cmbLedgerType.SelectedValue = "G";                
            }
            else if (acctype == "F")
            {
                cmbLedgerType.SelectedValue = "F";               
            }
        }

        private void Clear_All()
        {
            btnsave.Enabled = true;
            txtclear();
            btncancel.ToolTip = "Back";
            btncancel.Text = "Back";
            btncancel1.Attributes["class"] = "btn ico-back";

            btnsave.Text = "Save";

            btnsave.ToolTip = "Save";
            btnsave1.Attributes["class"] = "btn ico-save";

            ledgerid = 0;
            sgroupid = 0;
            groupid = 0;            
            cmbCostApp.SelectedIndex = 0;
            txtMinAmt.Text = "";
            txtMaxAmt.Text = "";
            txtSerTaxno.Text = "";
            txtPanno.Text = "";
            grd.DataSource = new DataTable();
            grd.DataBind();
            grd.Visible = true;          
            CmbType.SelectedIndex = 0;
            txt_AliasName.Text = "";
            txt_OpBalUSD.Text = "";
            ddl_Curr.SelectedValue = "0";
            hid_Ledgername.Value = "";
        }
        
        public void txtclear()
        {
            txtGroupname.Text = "";
            txtgroupetype.Text = "";
            txtSearch.Text = "";
            txtLedgerName.Text = "";
            txtsubgroupname.Text = "";
            cmbLedgerType.SelectedIndex = 0;
            cmbopbal.SelectedIndex = 0;
            cmbpvybal.SelectedIndex = 0;
            txtpybl.Value = "";
            CmbType.SelectedIndex = 0;
            cmbminmaxamt.SelectedIndex = 0;
            chkfrom.Checked = false;
        }


        protected void Clear()
        {
            txt_OpBalUSD.Text = "";
            txt_Curr.Text = "";
            txt_AliasName.Text = "";  
            
            DataTable dtEmpty = new DataTable();
            grd.DataSource = dtEmpty;
            grd.DataBind();
        }

        protected void txtLedgerName_TextChanged(object sender, EventArgs e)
        {
            if (txtLedgerName.Text != "")
            {
                string str_ledgername;
                string[] str_temp = txtLedgerName.Text.Split(',');

                if (str_temp.Length > 0)
                {
                    str_ledgername = str_temp[0].ToString();
                }
                else
                {
                    str_ledgername = txtLedgerName.Text;
                }

                if (chkfrom.Checked == true)
                {
                    dtl = customerobj.GetLikeCustomerAll(str_ledgername.TrimEnd());
                }
                else
                {
                    dtl = ledgerobj.GetLikeLedgername(str_ledgername.TrimEnd(), Convert.ToInt32(Session["LoginDivisionId"].ToString()), Convert.ToInt32(Session["LoginBranchid"].ToString()), Session["FADbname"].ToString());
                }

                //if (dtl.Rows.Count == 1)
                //{
                //    ledgerid = Convert.ToInt32(dtl.Rows[0]["ledgerid"].ToString());
                //    Session["ledgid"] = ledgerid;
                //    hid_Ledgername.Value = ledgerid.ToString();
                //    ledgername = dtl.Rows[0]["ledgername"].ToString();
                //    txtLedgerName.Text = ledgername;
                //}

                if (hid_Ledgername.Value != "")
                {
                   // Session["ledgid"] = hid_Ledgername.Value;
                    dtl1 = ledgerobj.SelMasterLedger(Convert.ToInt32(hid_Ledgername.Value), Session["FADbname"].ToString(), Convert.ToInt32(Session["LoginBranchid"].ToString()));
                   
                    if (dtl1.Rows.Count > 0)
                    {
                        Session["ledgid"] = hid_Ledgername.Value;
                        acctype = dtl1.Rows[0]["acctype"].ToString();
                        if (acctype == "G")
                        {
                            grd.Visible = true;
                            Label8.Visible = true;
                            txtSearch.Visible = true;
                        }
                        else
                        {
                            grd.Visible = false;
                            Label8.Visible = false;
                            txtSearch.Visible = false;
                        }

                        lt = acctype;
                        fill();
                        sgroupid = Convert.ToInt32(dtl1.Rows[0]["subgroupid"].ToString());
                        hid_SubGroupid.Value = sgroupid.ToString();
                        Session["sgpid"] = sgroupid;
                        groupid = Convert.ToInt32(dtl1.Rows[0]["groupid"].ToString());
                        Session["gpid"] = groupid;
                        hid_GroupID.Value = groupid.ToString();

                        txtsubgroupname.Text = dtl1.Rows[0]["subgroupname"].ToString();
                        txtGroupname.Text = dtl1.Rows[0]["groupname"].ToString();
                        txtgroupetype.Text = dtl1.Rows[0]["grouptype"].ToString();
                        if ((!string.IsNullOrEmpty(dtl1.Rows[0]["minamt"].ToString())) || (!string.IsNullOrEmpty(dtl1.Rows[0]["maxamt"].ToString())))
                        {
                            if (Convert.ToDouble(dtl1.Rows[0]["minamt"].ToString()) == 0 && Convert.ToDouble(dtl1.Rows[0]["maxamt"].ToString()) == 0)
                            {
                                cmbminmaxamt.SelectedValue = "C";
                                txtMinAmt.Text = string.Format("{0:0.00}", dtl1.Rows[0]["minamtcr"]);
                                txtMaxAmt.Text = string.Format("{0:0.00}", dtl1.Rows[0]["maxamtcr"]);
                            }
                            else
                            {
                                cmbminmaxamt.SelectedValue = "D";
                                txtMinAmt.Text = string.Format("{0:0.00}", dtl1.Rows[0]["minamt"]);
                                txtMaxAmt.Text = string.Format("{0:0.00}", dtl1.Rows[0]["maxamt"]);
                            }
                        }
                        else
                        {
                            cmbminmaxamt.SelectedValue = "C";
                            txtMinAmt.Text = "0.00";
                            txtMaxAmt.Text = "0.00";
                        }

                        

                        //-------------------------------------

                        if (dtl1.Rows.Count > 0)
                        {
                            if (!DBNull.Value.Equals(dtl1.Rows[0]["servicetaxno"]))
                            {
                                txtSerTaxno.Text = (dtl1.Rows[0]["servicetaxno"].ToString());
                            }
                            else
                            {
                                txtSerTaxno.Text = "";
                            }
                        }

                        if (dtl1.Rows.Count > 0)
                        {
                            if (!DBNull.Value.Equals(dtl1.Rows[0]["panno"]))
                            {
                                txtPanno.Text = (dtl1.Rows[0]["panno"].ToString());
                            }
                            else
                            {
                                txtPanno.Text = "";
                            }
                        }


                        if (dtl1.Rows.Count > 0)
                        {
                            if (!DBNull.Value.Equals(dtl1.Rows[0]["alias"]))
                            {
                                txt_AliasName.Text = (dtl1.Rows[0]["alias"].ToString());
                            }
                            else
                            {
                                txt_AliasName.Text = "";
                            }
                        }

                        if (dtl1.Rows.Count > 0)
                        {
                            if (!DBNull.Value.Equals(dtl1.Rows[0]["opbalcurr"]))
                            {
                                txt_Curr.Text = (dtl1.Rows[0]["opbalcurr"].ToString());
                            }
                            else
                            {
                                txt_Curr.Text = "";
                            }
                        }

                        //-----------------------------------------------------------------------------

                        if (dtl1.Rows[0]["costcenterapp"].ToString() == "N")
                        {
                            cmbCostApp.SelectedValue = "N";
                            ccapp = 'N';
                        }
                        else
                        {
                            cmbCostApp.SelectedValue = "Y";
                            ccapp = 'Y';
                        }

                        cmbpvybal.SelectedItem.Text = "Debit";
                        txtpybl.Value = "0";
                        cmbopbal.SelectedValue = "D";
                        txtOpbal.Text = "0";
                        if (!string.IsNullOrEmpty(dtl1.Rows[0]["pvsyrbaldb"].ToString()))
                        {
                           if (Convert.ToDouble(dtl1.Rows[0]["pvsyrbaldb"].ToString()) > 0)
                           {
                            cmbpvybal.SelectedItem.Text = "Debit";
                            txtpybl.Value = (string.Format("{0:0.00}", dtl1.Rows[0]["pvsyrbaldb"]));
                            pcolumname = "";
                            pcolumname = "pvsyrbaldb";
                            }

                        }
                        else
                        {
                            cmbpvybal.SelectedItem.Text = "Debit";
                            txtpybl.Value = "0.00";
                            pcolumname = "";
                            pcolumname = "pvsyrbaldb";
                        }
                        if (!string.IsNullOrEmpty(dtl1.Rows[0]["pvsyrbalcr"].ToString()))
                        {
                            if (Convert.ToDouble(dtl1.Rows[0]["pvsyrbalcr"].ToString()) > 0)
                            {
                                cmbpvybal.SelectedItem.Text = "Credit";
                                txtpybl.Value = (string.Format("{0:0.00}", dtl1.Rows[0]["pvsyrbalcr"]));
                                pcolumname = "";
                                pcolumname = "pvsyrbalcr";
                            }
                        }
                        else
                        {
                            cmbpvybal.SelectedItem.Text = "Credit";
                            txtpybl.Value = "0.00";
                            pcolumname = "";
                            pcolumname = "pvsyrbalcr";
                        }
                        if (!string.IsNullOrEmpty(dtl1.Rows[0]["opbaldb"].ToString()))
                        {
                            if (Convert.ToDouble(dtl1.Rows[0]["opbaldb"].ToString()) > 0)
                            {
                                //cmbopbal.SelectedItem.Text = "Debit";
                                cmbopbal.SelectedValue = "D";
                                txtOpbal.Text = string.Format("{0:0.00}", dtl1.Rows[0]["opbaldb"]);
                                ocolumname = "";
                                ocolumname = "opbaldb";
                            }
                        }
                        else
                        {
                            cmbopbal.SelectedValue = "D";
                            txtOpbal.Text = "0.00";
                            ocolumname = "";
                            ocolumname = "opbaldb";
                        }
                        if (!string.IsNullOrEmpty(dtl1.Rows[0]["opbalcr"].ToString()))
                        {
                            if (Convert.ToDouble(dtl1.Rows[0]["opbalcr"].ToString()) > 0)
                            {
                                cmbopbal.SelectedValue = "C";
                                //cmbopbal.SelectedItem.Text = "Credit";
                                txtOpbal.Text = string.Format("{0:0.00}", dtl1.Rows[0]["opbalcr"]);
                                ocolumname = "";
                                ocolumname = "opbalcr";
                            }
                        }
                        else
                        {
                            cmbopbal.SelectedValue = "C";
                            //cmbopbal.SelectedItem.Text = "Credit";
                            txtOpbal.Text = "0.00";
                            ocolumname = "";
                            ocolumname = "opbalcr";
                        }


                        txt_OpBalUSD.Text = "";
                        OcolumnameUSD = "";

                        if (!DBNull.Value.Equals(dtl1.Rows[0]["opbaldbusd"]))
                        {
                            if (Convert.ToDouble(dtl1.Rows[0]["opbaldbusd"].ToString()) > 0)
                            {
                                ddl_Curr.SelectedItem.Text = "Debit";
                                txt_OpBalUSD.Text = string.Format("{0:0.00}", dtl1.Rows[0]["opbaldbusd"]);
                                OcolumnameUSD = "opbaldbusd";
                            }
                        }
                        else
                        {
                            OcolumnameUSD = "";
                        }

                        if (!DBNull.Value.Equals(dtl1.Rows[0]["opbalcrusd"]))
                        {
                            if (Convert.ToDouble(dtl1.Rows[0]["opbalcrusd"].ToString()) > 0)
                            {
                                ddl_Curr.SelectedValue = "C";
                                txt_OpBalUSD.Text = string.Format("{0:0.00}", dtl1.Rows[0]["opbalcrusd"]);
                                OcolumnameUSD = "opbalcrusd";
                            }
                        }
                        else
                        {
                            OcolumnameUSD = "";
                        }
                        //------------------------------------------------------------------------------------------------

                        opsid = Convert.ToInt32(dtl1.Rows[0]["opsid"].ToString());
                        opstype = dtl1.Rows[0]["opstype"].ToString();
                        DataTable dtlg = new DataTable();
                        dtlg = ledgerobj.Getdtls4ledgrd(Convert.ToInt32(dtl1.Rows[0]["opsid"].ToString()), dtl1.Rows[0]["opstype"].ToString());


                        if (dtlg.Rows.Count > 0)
                        {
                            grd.DataSource = dtlg;
                            grd.DataBind();
                            ViewState["grd_Det"] = dtlg;
                            grd.Visible = true;
                            pnl_lg.Visible = true;
                            for (i = 0; i <= grd.Rows.Count - 1; i++)
                            {
                                CheckBox chkRow = (grd.Rows[i].Cells[3].FindControl("Chk_Grd") as CheckBox);
                                chkRow.Checked = true;
                            }
                            //for (i = 0; i <= dtlg.Rows.Count - 1; i++)
                            //{
                            //    grd.DataSource = dtlg;
                            //    grd.DataBind();
                            //    ViewState["grd_Det"] = dtlg;
                            //}
                        }

                        dtTDS = TDSobj.GetTDSDtlsForCustomer(opsid);
                        if (dtTDS.Rows.Count > 0)
                        {
                            strdesc = dtTDS.Rows[0]["tdsdesc"].ToString();
                            Session["strdes"] = strdesc.ToString();
                            tdsType = Convert.ToChar(dtTDS.Rows[0]["tdstype"].ToString());
                            if (tdsType == 'C')
                            {
                                CmbType.SelectedValue = "C";
                            }
                            else if (tdsType == 'I')
                            {
                                CmbType.SelectedValue = "I";
                            }
                            strslab = dtTDS.Rows[0]["tdsslab"].ToString();
                            Session["strlab"] = strslab.ToString();
                            dblpre = Convert.ToDouble(dtTDS.Rows[0]["tdspercentage"].ToString());
                        }
                        else
                        {
                            CmbType.SelectedIndex = 0;
                            strdesc = string.Empty;
                            Session["strdes"] = strdesc;
                            strslab = string.Empty;
                            Session["strlab"] = strslab;
                            dblpre = 0;
                        }

                        btnsave.Text = "Update";

                        btnsave.ToolTip = "Update";
                        btnsave1.Attributes["class"] = "btn ico-update";
                        btnsave.Enabled = true;
                    }
                }

                btncancel.ToolTip = "Cancel";
                btncancel1.Attributes["class"] = "btn ico-cancel";


                if (dt1.Rows.Count > 0)
                {
                    
                }
                else
                {
                    txt_AliasName.Text = txtLedgerName.Text;
                }
            }           

            if (cmbLedgerType.Text == "CASH")
            {
                cmbminmaxamt.SelectedItem.Text = "Debit";
                cmbminmaxamt.Enabled = false;
            }
            else
            {
                cmbminmaxamt.Enabled = true;
            }
            btncancel.ToolTip = "Cancel";
            btncancel1.Attributes["class"] = "btn ico-cancel";
        }

        public void debt()
        {
            if (cmbopbal.SelectedValue == "D")
            {
                ocolumname = "";
                ocolumname = "opbaldb";
            }
            else if (cmbopbal.SelectedValue == "C")
            {
                ocolumname = "";
                ocolumname = "opbalcr";
            }
        }

        public void get()
        {
            txtpybl.Value = "0";           
            if (cmbpvybal.SelectedItem.Text == "Debit")
            {
                pbtype = "";
                pbtype = "B";
                pcolumname = "";
                pcolumname = "pvsyrbaldb";
            }
            else if (cmbpvybal.SelectedItem.Text == "Credit")
            {
                pbtype = "";
                pbtype = "A";
                pcolumname = "";
                pcolumname = "pvsyrbalcr";
            }
        }

        public void data()
        {
            if (cmbopbal.SelectedItem.Text == "Debit")
            {
                obtype = "";
                obtype = "D";
                pcolumname = "";
                pcolumname = "opbaldb";
            }
            else if (cmbopbal.SelectedItem.Text == "Credit")
            {
                obtype = "";
                obtype = "C";
                pcolumname = "";
                pcolumname = "opbalcr";
            }
        }

        protected void cmbpvybal_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbpvybal.SelectedItem.Text == "Debit")
            {
                pbtype = "";
                pbtype = "B";
                pcolumname = "";
                pcolumname = "pvsyrbaldb";
            }
            else if (cmbpvybal.SelectedItem.Text == "Credit")
            {
                pbtype = "";
                pbtype = "A";
                pcolumname = "";
                pcolumname = "pvsyrbalcr";
            }
        }

        //protected void txtSearch_TextChanged(object sender, EventArgs e)
        //{
        //    DataTable dtgrd = new DataTable();
        //    if (txtSearch.Text != "")
        //    {
        //        dtgrd = customerobj.GetLikeCustomerAll4Grd(txtSearch.Text);
        //        if (dtgrd.Rows.Count > 0)
        //        {
        //            grd.DataSource = dtgrd;
        //            grd.DataBind();
        //        }
        //    }
        //}

        protected void btncancel_Click(object sender, EventArgs e)
        {
            if (btncancel.ToolTip == "Cancel")
            {
                Clear_All();
                txtclear();
                Clear();
            }
            else
            {
              //  this.Response.End();

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

        protected void btnview_Click(object sender, EventArgs e)
        {
            //DataAccess.FAMaster.MasterLedger Obj_Ledger = new DataAccess.FAMaster.MasterLedger();
            Session["str_sfs"] = ""; Session["str_sp"] = "";
            string str_sp = "", str_sf = "", str_RptName = "", str_RptName1 = "", str_Script = "";

            Obj_Ledger.GetLedgerDetails(Convert.ToInt32(Session["ledgid"]), Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(Session["LoginEmpId"].ToString()), Session["FADbname"].ToString());
            
            str_RptName = "rptFALedgers.rpt";

            if (txtsubgroupname.Text.Trim().Length > 0)
            {                
                Session["str_sfs"] = "{temp_Ledger.subgroupid} =" + hid_SubGroupid.Value.ToString() + " and {temp_Ledger.branchid}=" + Session["LoginBranchid"].ToString();
            }
            else
            {
                str_sf = "{temp_Ledger.acctype}=" + cmbLedgerType.SelectedItem.Text;
            }

            //Session["str_sfs"] = Session["str_sfs"] + " and {temp_Ledger.acctype} =\"" + cmbLedgerType.SelectedValue + "\"";

            string Ccode = Convert.ToString(Session["Ccode"]);

            str_Script = "window.open('../Tools/ReportViewFA.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&Ccode=" + Ccode + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
            ScriptManager.RegisterStartupScript(btnview, typeof(Button), "MasterGroup", str_Script, true);

            if (Session["str_ModuleName"] == "FA")
            {
                //logobj.InsLogDetail(Emp_Id, 1086, 1, BranchId, txtLedgerName.Text + "/ V");
                logobj.InsLogDetail(Emp_Id, 1086, 3, BranchId, txtLedgerName.Text + "/ V");
            }
            else
            {
                //logobj.InsLogDetail(Emp_Id, 1176, 1, BranchId, txtLedgerName.Text + "/ V");
                logobj.InsLogDetail(Emp_Id, 1176, 3, BranchId, txtLedgerName.Text + "/ V");
            }
        }
                
        
        protected void txt_Curr_TextChanged(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = chrgobj.GetLikeCurrency(txt_Curr.Text);

        }

        protected void CheckData()
        {
            if (cmbLedgerType.SelectedIndex == -1)
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), "alertify.alert('Ledger Type cannot be Blank');", true);
                blnErr = true;
                cmbLedgerType.Focus();
                return;
            }

            if (txtLedgerName.Text == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), "alertify.alert('LedgerName cannot be Blank');", true);
                blnErr = true;
                txtLedgerName.Focus();
                return;
            }

            if (txtsubgroupname.Text == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), "alertify.alert('SubGroupName cannot be Blank');", true);
                blnErr = true;
                txtsubgroupname.Focus();
                return;
            }

            if (cmbopbal.SelectedValue == "0")
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), "alertify.alert('Opening Balance Type cannot be Blank');", true);
                blnErr = true;
                cmbopbal.Focus();
                return;
            }

            if (txtOpbal.Text == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), "alertify.alert('Opening Balance cannot be Blank');", true);
                blnErr = true;
                txtOpbal.Focus();
                return;
            }

            if ((txtMinAmt.Text == "") || (txtMinAmt.Text.ToString().Length == 0))
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), "alertify.alert('Minimum amount cannot be Blank');", true);
                blnErr = true;
                txtMinAmt.Focus();
                return;
            }

            if ((txtMaxAmt.Text == "") || (txtMaxAmt.Text.ToString().Length == 0))
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), "alertify.alert('Maximum amount cannot be Blank');", true);
                blnErr = true;
                txtMaxAmt.Focus();
                return;
            }

            intcid = 0;
            DataTable dt = new DataTable();
            dt = (DataTable)ViewState["grd_Det"];
            if (acctype == "G")
            {
                if (opstype == "C" || opstype == "A")
                {
                    for (int i = 0; i <= grd.Rows.Count - 1; i++)
                    {
                        intcid = Convert.ToInt32(dt.Rows[i]["cid"].ToString());
                        type = dt.Rows[i]["cshtype"].ToString();
                    }
                }
                else
                {
                    blnops = true;
                }
            }
            else
            {
                blnops = true;
            }

            if (intcid != 0)
            {
                int ChkOpsId = 0;
                string OpLedgerName = "";
                DataTable dtOps = new DataTable();

                dtOps = ledgerobj.FACkhopsid(FaDbName, intcid, type);
                if (dtOps.Rows.Count > 0)
                {
                    ChkOpsId = Convert.ToInt32(dtOps.Rows[0]["ledgerid"].ToString());
                    OpLedgerName = dtOps.Rows[0]["ledgername"].ToString();

                    if (btnsave.ToolTip == "Save")
                    {
                        if (ChkOpsId != 0)
                        {
                            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), "alertify.alert('Operation Name Already assiged to Ledger " + OpLedgerName + "');", true);
                            blnErr = true;
                            return;
                        }
                    }
                    else if (btnsave.ToolTip == "Update")
                    {
                        if (ChkOpsId != ledgerid)
                        {
                            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), "alertify.alert('Operation Name Already assiged to Ledger " + OpLedgerName + "');", true);
                            blnErr = true;
                            return;
                        }
                    }
                }
            }

            if (txt_AliasName.Text == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), "alertify.alert('AliasName cannot be Blank');", true);
                blnErr = true;
                txt_AliasName.Focus();
                return;
            }

            if (txt_Curr.Text != "")
            {
                if (chrgobj.GetCurrID(txt_Curr.Text) == 0)
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), "alertify.alert('Invalid Currency Name');", true);
                    txt_Curr.Focus();
                    txt_Curr.Text = "";
                    blnErr = true;
                    return;
                }
            }
        }

        protected void btndelete_Click(object sender, EventArgs e)
        {

        }

        protected void ddl_Curr_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddl_Curr.SelectedItem.Text == "Debit")
            {
                ObtypeUSD = "";
                ObtypeUSD = "D";
                OcolumnameUSD = "";
                OcolumnameUSD = "opbaldbusd";
            }
            else if (ddl_Curr.SelectedItem.Text == "Credit")
            {
                ObtypeUSD = "";
                ObtypeUSD = "C";
                OcolumnameUSD = "";
                OcolumnameUSD = "opbalcrusd";
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
            //DataAccess.LogDetails Logobj = new DataAccess.LogDetails();

            if (Session["str_ModuleName"].ToString() == "FA")
            {
                obj_dtlogdetails = Logobj.InsTempGrpLogdtlsGet(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), 1086, "", "", "", Session["StrTranType"].ToString());
            }
            else
            {
                obj_dtlogdetails = Logobj.InsTempGrpLogdtlsGet(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), 1176, "", "", "", Session["StrTranType"].ToString());
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

        protected void grd_PreRender(object sender, EventArgs e)
        {
            if (grd.Rows.Count > 0)
            {
                grd.UseAccessibleHeader = true;
                grd.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }

        protected void cmbopbal_SelectedIndexChanged1(object sender, EventArgs e)
        {
            if (cmbopbal.SelectedItem.Text == "Debit")
            {
                obtype = "";
                obtype = "D";
                pcolumname = "";
                pcolumname = "opbaldb";
              
            }
            else if (cmbopbal.SelectedItem.Text == "Credit")
            {
                obtype = "";
                obtype = "C";
                pcolumname = "";
                pcolumname = "opbalcr";
              
            }
        }


    }
}