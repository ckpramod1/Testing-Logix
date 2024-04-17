using System;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Data.Sql;
using System.Web.Services;

namespace logix.FAForms
{
    public partial class OPBalance_BreakUp : System.Web.UI.Page
    {
        int Emp_Id, BranchId, Div_Id;
        string FaDbName;
        public string strtrantype;
        DateTime vdate;
        Boolean blnerr;
        string basecurr, path;
        DataAccess.LogDetails Logobj = new DataAccess.LogDetails();
        DataAccess.Accounts.Recipts recobj = new DataAccess.Accounts.Recipts();
        DataAccess.Masters.MasterCharges chargeobj = new DataAccess.Masters.MasterCharges();

        protected void Page_Load(object sender, EventArgs e)
        {

            string Ccode = Convert.ToString(Session["Ccode"]);

            if (Ccode != "")
            {

                Logobj.GetDataBase(Ccode);
                recobj.GetDataBase(Ccode);
                chargeobj.GetDataBase(Ccode);
               


            }

            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "SpanTagMoveInputBottom();MuiTextField();", true);
            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(btncancel);
            // ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(btnadd);

            if (Session["LoginUserName"] == null || Session["LoginEmpId"] == null || Session["LoginDivisionId"] == null || Session["LoginBranchid"] == null)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alertify.alert('Session TimeOut');window.open('"+ Session["Site"].ToString() + "/','_top');", true);
            }

            if (Request.QueryString.ToString().Contains("FormName"))
            {
                lbl_head.Text = Request.QueryString["FormName"].ToString();
            }
            if (Session["LoginEmpId"] != null)
            {
                Emp_Id = Convert.ToInt32(Session["LoginEmpId"].ToString());
            }
            FaDbName = HttpContext.Current.Session["FADbname"].ToString();
            BranchId = Convert.ToInt32(Session["LoginBranchid"].ToString());
            Div_Id = Convert.ToInt32(Session["LoginDivisionId"].ToString());
            strtrantype = Session["str_ModuleName"].ToString();
            basecurr = Session["Basecurr"].ToString();
            if (!IsPostBack)
            {
                txtamount.Attributes.Add("onkeypress", "return validateFloatKeyPress(this,event,'Amount')");
                txtFCamt.Attributes.Add("onkeypress", "return validateFloatKeyPress(this,event,'Amount')");

                btndelete.Attributes["onClick"] = "return confirm('Are you sure you want to delete this Details?');";

                vdate = Logobj.GetDate();
                txtdate.Text = Utility.fn_ConvertDate(vdate.ToString());

                grdINVRec.DataSource = new DataTable();
                grdINVRec.DataBind();

                cmbvoutype.SelectedIndex = -1;


                hid_date.Value = Utility.fn_ConvertDate(Logobj.GetDate().ToShortDateString());

                txtVendorRefnodate.Text = hid_date.Value.ToString();
                 btncancel.Text = "Back";

                btncancel.ToolTip = "Back";
                btncancel1.Attributes["class"] = "btn ico-back";
                Session["dt_Dtls"] = null;
            }
            else if (Page.IsPostBack)
            {

                WebControl wcICausedPostBack = (WebControl)GetControlThatCausedPostBack(sender as Page);
                int indx = wcICausedPostBack.TabIndex;
                var ctrl = from control in wcICausedPostBack.Parent.Controls.OfType<WebControl>()
                           where control.TabIndex > indx
                           select control;
                ctrl.DefaultIfEmpty(wcICausedPostBack).First().Focus();
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "test", "TxtFocus();", true);

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

        protected void btnsave_Click(object sender, EventArgs e)
        {
            double sumopbalamt = 0;
            double fcamt = 0,exrate=0;
            string curr = "";
            string vendorno="", vendordate="";
            Boolean insstatus = false;
            //DataAccess.Accounts.Recipts recobj = new DataAccess.Accounts.Recipts();
            try
            {
                if (grdINVRec.Rows.Count > 0)
                {

                    if (txtOpbal.Text == "")
                    {
                        txtOpbal.Text = "0.00";
                    }



                    sumopbalamt = Convert.ToDouble(txt_total.Text);
                    if (sumopbalamt == Convert.ToDouble(txtOpbal.Text))
                    {
                        if (btnsave.ToolTip == "Update")
                        {
                            recobj.DelFARectPmt(Convert.ToInt32(hid_Ledgername.Value), Convert.ToInt32(HttpContext.Current.Session["LoginBranchid"].ToString()));
                        }

                        for (int i = 0; i <= grdINVRec.Rows.Count - 1; i++)
                        {
                            if (recobj.ChkVouNoExistsinFARectPmt(Convert.ToInt32(grdINVRec.Rows[i].Cells[0].Text.Trim()), Convert.ToInt32(grdINVRec.Rows[i].Cells[3].Text.Trim()), Convert.ToInt32(grdINVRec.Rows[i].Cells[7].Text.Trim()), grdINVRec.Rows[i].Cells[8].Text.Trim()) >= 1)
                            {
                                ScriptManager.RegisterClientScriptBlock(btnsave, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Voucher # " + grdINVRec.Rows[i].Cells[0].Text.Trim() + " Already Exists.');", true);
                                return;
                            }
                        }

                        for (int i = 0; i <= grdINVRec.Rows.Count - 1; i++)
                        {
                            if (Convert.ToInt32(grdINVRec.Rows[i].Cells[0].Text.Trim()) > 0)
                            {
                                if (grdINVRec.Rows[i].Cells[6].Text.Trim().ToString() == "")
                                {
                                    fcamt = 0;
                                }
                                else
                                {
                                    fcamt = Convert.ToDouble(grdINVRec.Rows[i].Cells[6].Text.Trim());
                                }

                                if (grdINVRec.Rows[i].Cells[5].Text.Trim().ToString() == "")
                                {
                                    curr = "";
                                }
                                else
                                {
                                    curr = grdINVRec.Rows[i].Cells[5].Text.Trim();
                                }
                                if (grdINVRec.Rows[i].Cells[9].Text.Trim().ToString() == "")
                                {
                                    exrate = 0;
                                }
                                else
                                {
                                    exrate = Convert.ToDouble(grdINVRec.Rows[i].Cells[9].Text.Trim());
                                }

                                if (grdINVRec.Rows[i].Cells[10].Text.Trim().ToString() == "")
                                {
                                    vendorno = "";
                                }
                                else
                                {
                                    vendorno = grdINVRec.Rows[i].Cells[10].Text.Trim();
                                }

                                if (grdINVRec.Rows[i].Cells[11].Text.Trim().ToString() == "")
                                {
                                    vendordate = "";
                                }
                                else
                                {
                                    vendordate= grdINVRec.Rows[i].Cells[11].Text.Trim();
                                }


                                //recobj.InsFARectPmtnew(Convert.ToInt32(hid_Ledgername.Value), Convert.ToInt32(grdINVRec.Rows[i].Cells[0].Text.Trim()), Convert.ToDateTime(Utility.fn_ConvertDate(txtdate.Text)), grdINVRec.Rows[i].Cells[8].Text.Trim(), Convert.ToInt32(grdINVRec.Rows[i].Cells[3].Text.Trim()), Convert.ToInt32(grdINVRec.Rows[i].Cells[7].Text.Trim()), Convert.ToDouble(grdINVRec.Rows[i].Cells[4].Text.Trim()), curr, fcamt, Convert.ToInt32(Session["LogYear"].ToString()), Convert.ToDouble(grdINVRec.Rows[i].Cells[4].Text.Trim()), "", 0, "N", Convert.ToInt32(hid_custid.Value), exrate);
                                //recobj.InsFARectPmttemp(Convert.ToInt32(hid_Ledgername.Value), Convert.ToInt32(grdINVRec.Rows[i].Cells[0].Text.Trim()), Convert.ToDateTime(Utility.fn_ConvertDate(txtdate.Text)), grdINVRec.Rows[i].Cells[8].Text.Trim(), Convert.ToInt32(grdINVRec.Rows[i].Cells[3].Text.Trim()), Convert.ToInt32(grdINVRec.Rows[i].Cells[7].Text.Trim()), Convert.ToDouble(grdINVRec.Rows[i].Cells[4].Text.Trim()), curr, fcamt, Convert.ToInt32(Session["LogYear"].ToString()), Convert.ToDouble(grdINVRec.Rows[i].Cells[4].Text.Trim()), "", 0, "N", Convert.ToInt32(hid_custid.Value), exrate);
                                if (vendorno == "")
                                {
                                    recobj.InsFARectPmtnew(Convert.ToInt32(hid_Ledgername.Value), Convert.ToInt32(grdINVRec.Rows[i].Cells[0].Text.Trim()), Convert.ToDateTime(Utility.fn_ConvertDate(txtdate.Text)), grdINVRec.Rows[i].Cells[8].Text.Trim(), Convert.ToInt32(grdINVRec.Rows[i].Cells[3].Text.Trim()), Convert.ToInt32(grdINVRec.Rows[i].Cells[7].Text.Trim()), Convert.ToDouble(grdINVRec.Rows[i].Cells[4].Text.Trim()), curr, fcamt, Convert.ToInt32(Session["LogYear"].ToString()), Convert.ToDouble(grdINVRec.Rows[i].Cells[4].Text.Trim()), "", 0, "N", Convert.ToInt32(hid_custid.Value), exrate);
                                    recobj.InsFARectPmttemp(Convert.ToInt32(hid_Ledgername.Value), Convert.ToInt32(grdINVRec.Rows[i].Cells[0].Text.Trim()), Convert.ToDateTime(Utility.fn_ConvertDate(txtdate.Text)), grdINVRec.Rows[i].Cells[8].Text.Trim(), Convert.ToInt32(grdINVRec.Rows[i].Cells[3].Text.Trim()), Convert.ToInt32(grdINVRec.Rows[i].Cells[7].Text.Trim()), Convert.ToDouble(grdINVRec.Rows[i].Cells[4].Text.Trim()), curr, fcamt, Convert.ToInt32(Session["LogYear"].ToString()), Convert.ToDouble(grdINVRec.Rows[i].Cells[4].Text.Trim()), "", 0, "N", Convert.ToInt32(hid_custid.Value), exrate);
                                }
                                else
                                {
                                    recobj.InsFARectPmtnewvendor(Convert.ToInt32(hid_Ledgername.Value), Convert.ToInt32(grdINVRec.Rows[i].Cells[0].Text.Trim()), Convert.ToDateTime(Utility.fn_ConvertDate(txtdate.Text)), grdINVRec.Rows[i].Cells[8].Text.Trim(), Convert.ToInt32(grdINVRec.Rows[i].Cells[3].Text.Trim()), Convert.ToInt32(grdINVRec.Rows[i].Cells[7].Text.Trim()), Convert.ToDouble(grdINVRec.Rows[i].Cells[4].Text.Trim()), curr, fcamt, Convert.ToInt32(Session["LogYear"].ToString()), Convert.ToDouble(grdINVRec.Rows[i].Cells[4].Text.Trim()), "", 0, "N", Convert.ToInt32(hid_custid.Value), exrate, vendorno.ToString(), DateTime.Parse(Utility.fn_ConvertDatetime(vendordate).ToString()));
                                    recobj.InsFARectPmttempvendor(Convert.ToInt32(hid_Ledgername.Value), Convert.ToInt32(grdINVRec.Rows[i].Cells[0].Text.Trim()), Convert.ToDateTime(Utility.fn_ConvertDate(txtdate.Text)), grdINVRec.Rows[i].Cells[8].Text.Trim(), Convert.ToInt32(grdINVRec.Rows[i].Cells[3].Text.Trim()), Convert.ToInt32(grdINVRec.Rows[i].Cells[7].Text.Trim()), Convert.ToDouble(grdINVRec.Rows[i].Cells[4].Text.Trim()), curr, fcamt, Convert.ToInt32(Session["LogYear"].ToString()), Convert.ToDouble(grdINVRec.Rows[i].Cells[4].Text.Trim()), "", 0, "N", Convert.ToInt32(hid_custid.Value), exrate, vendorno.ToString(), DateTime.Parse(Utility.fn_ConvertDatetime(vendordate).ToString()));
                                }
                                


                                if (btnsave.ToolTip == "Save")
                                {
                                    if (Convert.ToInt32(Session["LoginBranchid"].ToString()) != 3)
                                    {
                                        Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1902, 1, Convert.ToInt32(Session["LoginBranchid"]), hid_Ledgername.Value + "/" + grdINVRec.Rows[i].Cells[0].Text.Trim() + "/" + grdINVRec.Rows[i].Cells[8].Text.Trim() + "/" + grdINVRec.Rows[i].Cells[3].Text.Trim() + "/" + grdINVRec.Rows[i].Cells[4].Text.Trim() + "/S");
                                    }
                                    else
                                    {
                                        Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1902, 1, Convert.ToInt32(Session["LoginBranchid"]), hid_Ledgername.Value + "/" + grdINVRec.Rows[i].Cells[0].Text.Trim() + "/" + grdINVRec.Rows[i].Cells[8].Text.Trim() + "/" + grdINVRec.Rows[i].Cells[3].Text.Trim() + "/" + grdINVRec.Rows[i].Cells[4].Text.Trim() + "/S");
                                    }
                                   // Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1848, 1, Convert.ToInt32(Session["LoginBranchid"]), hid_Ledgername.Value + "/" + grdINVRec.Rows[i].Cells[0].Text.Trim() + "/" + grdINVRec.Rows[i].Cells[8].Text.Trim() + "/" + grdINVRec.Rows[i].Cells[3].Text.Trim() + "/" + grdINVRec.Rows[i].Cells[4].Text.Trim() + "/S");

                                }
                                else
                                {
                                    if (Convert.ToInt32(Session["LoginBranchid"].ToString()) != 3)
                                    {
                                        //Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1902, 1, Convert.ToInt32(Session["LoginBranchid"]), hid_Ledgername.Value + "/" + grdINVRec.Rows[i].Cells[0].Text.Trim() + "/" + grdINVRec.Rows[i].Cells[8].Text.Trim() + "/" + grdINVRec.Rows[i].Cells[3].Text.Trim() + "/" + grdINVRec.Rows[i].Cells[4].Text.Trim() + "/U");
                                        Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1902, 2, Convert.ToInt32(Session["LoginBranchid"]), hid_Ledgername.Value + "/" + grdINVRec.Rows[i].Cells[0].Text.Trim() + "/" + grdINVRec.Rows[i].Cells[8].Text.Trim() + "/" + grdINVRec.Rows[i].Cells[3].Text.Trim() + "/" + grdINVRec.Rows[i].Cells[4].Text.Trim() + "/U");
                                    }
                                    else
                                    {
                                       // Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1902, 1, Convert.ToInt32(Session["LoginBranchid"]), hid_Ledgername.Value + "/" + grdINVRec.Rows[i].Cells[0].Text.Trim() + "/" + grdINVRec.Rows[i].Cells[8].Text.Trim() + "/" + grdINVRec.Rows[i].Cells[3].Text.Trim() + "/" + grdINVRec.Rows[i].Cells[4].Text.Trim() + "/U");
                                        Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1902, 2, Convert.ToInt32(Session["LoginBranchid"]), hid_Ledgername.Value + "/" + grdINVRec.Rows[i].Cells[0].Text.Trim() + "/" + grdINVRec.Rows[i].Cells[8].Text.Trim() + "/" + grdINVRec.Rows[i].Cells[3].Text.Trim() + "/" + grdINVRec.Rows[i].Cells[4].Text.Trim() + "/U");
                                    }
                                   // Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1848, 1, Convert.ToInt32(Session["LoginBranchid"]), hid_Ledgername.Value + "/" + grdINVRec.Rows[i].Cells[0].Text.Trim() + "/" + grdINVRec.Rows[i].Cells[8].Text.Trim() + "/" + grdINVRec.Rows[i].Cells[3].Text.Trim() + "/" + grdINVRec.Rows[i].Cells[4].Text.Trim() + "/U");

                                }
                                insstatus = true;
                            }
                        }

                        if ((insstatus == true) && (btnsave.ToolTip == "Save"))
                        {
                           
                            if (Convert.ToInt32( Session["LoginBranchid"].ToString())!=5)
                            {
                                Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1902, 1, Convert.ToInt32(Session["LoginBranchid"]), hid_Ledgername.Value + "/S");
                            }
                            else
                            {
                                Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1903, 1, Convert.ToInt32(Session["LoginBranchid"]), hid_Ledgername.Value + "/S");
                            }
                         //   Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1848, 1, Convert.ToInt32(Session["LoginBranchid"]), hid_Ledgername.Value + "/S");

                            ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Details saved ');", true);
                             btnsave.Text = "Update";
                            btnsave.ToolTip = "Update";
                            btnsave1.Attributes["class"] = "btn ico-update";
                        }       
                        else if ((insstatus == true) && (btnsave.ToolTip == "Update"))
                        {
                            if (Convert.ToInt32(Session["LoginBranchid"].ToString()) != 5)
                            {
                                //Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1902, 1, Convert.ToInt32(Session["LoginBranchid"]), hid_Ledgername.Value + "/U");
                                Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1902, 2, Convert.ToInt32(Session["LoginBranchid"]), hid_Ledgername.Value + "/U");
                            }
                            else
                            {
                               // Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1903, 1, Convert.ToInt32(Session["LoginBranchid"]), hid_Ledgername.Value + "/U");
                                Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1903, 2, Convert.ToInt32(Session["LoginBranchid"]), hid_Ledgername.Value + "/U");
                            }
                            //Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1848, 1, Convert.ToInt32(Session["LoginBranchid"]), hid_Ledgername.Value + "/S");

                            ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Details Updated ');", true);

                        }

                    }
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(btnsave, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Both Voucher Amount and Opening Balance Does not Match');", true);
                        return;
                    }

                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        protected void btncancel_Click(object sender, EventArgs e)
        {
            if (btncancel.ToolTip == "Cancel")
            {
                vdate = Logobj.GetDate();
                txtdate.Text = Utility.fn_ConvertDate(vdate.ToString());
                txt_total.Text = "";
                grdINVRec.DataSource = new DataTable();
                grdINVRec.DataBind();
                txtOpbal.Text = "";
                txtLedgerName.Text = "";
                fn_clearVou();
                btnsave.Text = "Save";
                btnsave.ToolTip = "Save";
                btnsave1.Attributes["class"] = "btn ico-save";
                 btncancel.Text = "Back";
                btncancel.ToolTip = "Back";
                btncancel1.Attributes["class"] = "btn ico-back";
                txtVendorRefno.Text = "";

                hid_date.Value = Utility.fn_ConvertDate(Logobj.GetDate().ToShortDateString());
                txtVendorRefnodate.Text = hid_date.Value.ToString();
                Session["dt_Dtls"] = null;
            }
            else
            {
                this.Response.End();
            }
        }

        protected void btnadd_Click(object sender, EventArgs e)
        {

           // DataAccess.Accounts.Recipts recobj = new DataAccess.Accounts.Recipts();
            CheckData();
            if (blnerr == true)
            {
                blnerr = false;
                return;
            }


            DataTable dt_cnt = new DataTable();
            if (Session["dt_Dtls"] != null && !Session["dt_Dtls"].Equals("-1"))
            {
                dt_cnt = (DataTable)Session["dt_Dtls"];
            }
            else
            {
                dt_cnt.Columns.Add("vouno", typeof(string));
                dt_cnt.Columns.Add("voudate", typeof(string));
                dt_cnt.Columns.Add("voutype", typeof(string));
                dt_cnt.Columns.Add("vouyear", typeof(string));
                dt_cnt.Columns.Add("vouamount", typeof(string));
                dt_cnt.Columns.Add("fcurr", typeof(string));
                dt_cnt.Columns.Add("famount", typeof(string));
                dt_cnt.Columns.Add("exrate", typeof(string));
                dt_cnt.Columns.Add("vid", typeof(string));
                dt_cnt.Columns.Add("bid", typeof(string));
                dt_cnt.Columns.Add("vendorrefno", typeof(string));
                dt_cnt.Columns.Add("vendorrefdate", typeof(string));
            }



            if (btnadd.ToolTip == "Add")
            {
                if (dt_cnt.Rows.Count > 0)
                {
                    DataView obj_dtview = new DataView(dt_cnt);
                    obj_dtview.RowFilter = "vouno=" + Convert.ToInt32(txtvouno.Text) + " and vid='" + cmbvoutype.SelectedValue + "' and vouyear=" + Convert.ToInt32(txtvouyear.Text) + " and bid=" + BranchId;
                    if (obj_dtview.Count > 0)
                    {
                        ScriptManager.RegisterStartupScript(btnadd, typeof(Button), "Valid text", "alertify.alert('Vou # " + txtvouno.Text + " Already Exists');", true);
                        return;
                    }
                }

                DataRow dtrow = dt_cnt.NewRow();
                dtrow["vouno"] = txtvouno.Text;
                dtrow["voudate"] = txtdate.Text;
                dtrow["voutype"] = cmbvoutype.SelectedItem;
                dtrow["vouyear"] = txtvouyear.Text;
                dtrow["vouamount"] = txtamount.Text;
                dtrow["fcurr"] = txtFCurr.Text;
                dtrow["famount"] = txtFCamt.Text;
                dtrow["exrate"] = txt_exrate.Text;
                dtrow["vid"] = cmbvoutype.SelectedValue;
                dtrow["bid"] = BranchId;
                dtrow["vendorrefno"] = txtVendorRefno.Text;
                dtrow["vendorrefdate"] = txtVendorRefnodate.Text;
                dt_cnt.Rows.Add(dtrow);
            }
            else if (btnadd.ToolTip == "Upd")
            {
                if (dt_cnt.Rows.Count > 0)
                {
                    //linq update
                    dt_cnt.Select(string.Format("[vouno]='{0}' and [vid]>='{1}' and [vouyear]>='{2}' ", Convert.ToInt32(txtvouno.Text), cmbvoutype.SelectedValue, Convert.ToInt32(txtvouyear.Text))).ToList<DataRow>().ForEach(r => { r["vouamount"] = txtamount.Text; r["fcurr"] = txtFCurr.Text; r["famount"] = txtFCamt.Text; });

                }
               btnadd.Text = "Add";
                btnadd.ToolTip = "Add";
                btnadd1.Attributes["class"] = "btn ico-add";
            }
            grdINVRec.DataSource = dt_cnt;
            grdINVRec.DataBind();

            Double fcamt,exrate;
            if (grdINVRec.Rows.Count > 0)
            {
                for (int i = 0; i <= grdINVRec.Rows.Count - 1; i++)
                {
                    if (grdINVRec.Rows[i].Cells[6].Text.Trim().ToString() == "")
                    {
                        fcamt = 0;
                    }
                    else
                    {
                        fcamt = Convert.ToDouble(grdINVRec.Rows[i].Cells[6].Text.Trim());
                    }

                    if (grdINVRec.Rows[i].Cells[9].Text.Trim().ToString() == "")
                    {
                        exrate = 0;
                    }
                    else
                    {
                        exrate = Convert.ToDouble(grdINVRec.Rows[i].Cells[9].Text.Trim());
                    }
                    //recobj.InsFARectPmttemp(Convert.ToInt32(hid_Ledgername.Value), Convert.ToInt32(grdINVRec.Rows[i].Cells[0].Text.Trim()), Convert.ToDateTime(Utility.fn_ConvertDate(txtdate.Text)), grdINVRec.Rows[i].Cells[8].Text.Trim(), Convert.ToInt32(grdINVRec.Rows[i].Cells[3].Text.Trim()), Convert.ToInt32(grdINVRec.Rows[i].Cells[7].Text.Trim()), Convert.ToDouble(grdINVRec.Rows[i].Cells[4].Text.Trim()), grdINVRec.Rows[i].Cells[5].Text.Trim(), fcamt, Convert.ToInt32(Session["LogYear"].ToString()), Convert.ToDouble(grdINVRec.Rows[i].Cells[4].Text.Trim()), "", 0, "N", Convert.ToInt32(hid_custid.Value), Convert.ToDouble(grdINVRec.Rows[i].Cells[9].Text.Trim()));

                //  recobj.InsFARectPmttempvendor(Convert.ToInt32(hid_Ledgername.Value), Convert.ToInt32(grdINVRec.Rows[i].Cells[0].Text.Trim()), Convert.ToDateTime(Utility.fn_ConvertDate(txtdate.Text)), grdINVRec.Rows[i].Cells[8].Text.Trim(), Convert.ToInt32(grdINVRec.Rows[i].Cells[3].Text.Trim()), Convert.ToInt32(grdINVRec.Rows[i].Cells[7].Text.Trim()), Convert.ToDouble(grdINVRec.Rows[i].Cells[4].Text.Trim()), grdINVRec.Rows[i].Cells[5].Text.Trim(), fcamt, Convert.ToInt32(Session["LogYear"].ToString()), Convert.ToDouble(grdINVRec.Rows[i].Cells[4].Text.Trim()), "", 0, "N", Convert.ToInt32(hid_custid.Value), exrate, txtVendorRefno.Text, DateTime.Parse(Utility.fn_ConvertDatetime(txtVendorRefnodate.Text).ToString()));


                }
            }
            Session["dt_Dtls"] = dt_cnt;

            fn_caltotal();
            fn_clearVou();

        }

        //[WebMethod]
        //public static List<string> GetLedgername(string prefix)
        //{
        //    DataAccess.FAMaster.MasterLedger lgerobj = new DataAccess.FAMaster.MasterLedger();
        //    DataAccess.Masters.MasterCustomer customerobj = new DataAccess.Masters.MasterCustomer();
        //    DataTable obj_Dt = new DataTable();
        //    List<string> LedgerList = new List<string>();
        //    obj_Dt = lgerobj.GetLikeLedgername(prefix.ToUpper(), Convert.ToInt32(HttpContext.Current.Session["LoginDivisionid"].ToString()), Convert.ToInt32(HttpContext.Current.Session["LoginBranchid"].ToString()), HttpContext.Current.Session["FADbname"].ToString());
        //    LedgerList = Utility.Fn_TableToList(obj_Dt, "LNandPort", "ledgerid", "opsid");
        //    return LedgerList;
        //}

        [WebMethod]
        public static List<string> GetLedgername(string prefix)
        {
            DataAccess.FAMaster.MasterLedger lgerobj = new DataAccess.FAMaster.MasterLedger();
            DataAccess.Masters.MasterCustomer customerobj = new DataAccess.Masters.MasterCustomer();
            string Ccode = HttpContext.Current.Session["Ccode"].ToString();
            lgerobj.GetDataBase(Ccode);
            customerobj.GetDataBase(Ccode);
            DataTable obj_Dt = new DataTable();
            List<string> LedgerList = new List<string>();
            obj_Dt = lgerobj.GetLikeLedgername(prefix.ToUpper(), Convert.ToInt32(HttpContext.Current.Session["LoginDivisionid"].ToString()), Convert.ToInt32(HttpContext.Current.Session["LoginBranchid"].ToString()), HttpContext.Current.Session["FADbname"].ToString());
            LedgerList = Utility.Fn_TableToList(obj_Dt, "LNandPort", "ledgerid", "opsid");
            return LedgerList;
        }



        [WebMethod]
        public static List<string> GetLikeCurrency(string prefix)
        {
            List<string> List_Result = new List<string>();
            DataAccess.Masters.MasterCharges chargeobj = new DataAccess.Masters.MasterCharges();
            string Ccode = HttpContext.Current.Session["Ccode"].ToString();
            chargeobj.GetDataBase(Ccode);
           
            DataTable dtCharge = new DataTable();
            dtCharge = chargeobj.GetLikeCurrency(prefix);
            List_Result = Utility.Fn_TableToList(dtCharge, "currency", "currency");
            return List_Result;
        }

        /*protected void txtLedgerName_TextChanged(object sender, EventArgs e)
        {
            DataAccess.Accounts.Recipts recobj = new DataAccess.Accounts.Recipts();
            DataTable dtopbal = new DataTable();
            double opbalamt = 0;
            
            int custid;
            if (hid_custid.Value != "")
            {
                custid = Convert.ToInt32(hid_custid.Value);
            }
            else
            {
                custid = 0;
            }
            if (hid_Ledgername.Value != "" && hid_Ledgername.Value != "0")
            {
                dtopbal = recobj.SelOPBal4Ledger(Session["FADbname"].ToString(), Convert.ToInt32(hid_Ledgername.Value), Convert.ToInt32(Session["LoginBranchid"].ToString()));
                if (dtopbal.Rows.Count > 0)
                {
                    if (dtopbal.Rows[0]["OP_Bal"].ToString() != "")
                    {
                        opbalamt = Convert.ToDouble(dtopbal.Rows[0]["OP_Bal"].ToString());
                        txtOpbal.Text = (string.Format("{0:0.00}", opbalamt));
                    }
                    else
                    {
                        txtOpbal.Text = "0.00";
                    }


                }

                DataTable dtcount = new DataTable();

                dtcount = recobj.ChkLedgIDInFARcptPmt(Convert.ToInt32(hid_Ledgername.Value), Convert.ToInt32(Session["LoginBranchid"].ToString()));
                if (dtcount.Rows.Count > 0)
                {
                    DataTable dt_cnt = new DataTable();
                    dt_cnt.Columns.Add("vouno", typeof(string));
                    dt_cnt.Columns.Add("voudate", typeof(string));
                    dt_cnt.Columns.Add("voutype", typeof(string));
                    dt_cnt.Columns.Add("vouyear", typeof(string));
                    dt_cnt.Columns.Add("vouamount", typeof(string));
                    dt_cnt.Columns.Add("fcurr", typeof(string));
                    dt_cnt.Columns.Add("famount", typeof(string));
                    dt_cnt.Columns.Add("vid", typeof(string));
                    dt_cnt.Columns.Add("bid", typeof(string));
                    dt_cnt.Columns.Add("exrate", typeof(string));

                    for (int i = 0; i < dtcount.Rows.Count; i++)
                    {
                        DataRow dtrow = dt_cnt.NewRow();
                        dtrow["vouno"] = dtcount.Rows[i]["vouno"].ToString();
                        dtrow["voudate"] = dtcount.Rows[i]["voudate"].ToString();
                        if (dtcount.Rows[i]["voutype"].ToString() == "OI")
                        {
                            dtrow["voutype"] = "Invoice";

                        }
                        else if (dtcount.Rows[i]["voutype"].ToString() == "OD")
                        {
                            dtrow["voutype"] = "OSSI";

                        }
                        else if (dtcount.Rows[i]["voutype"].ToString() == "OV")
                        {
                            dtrow["voutype"] = "Debit Note - Others";

                        }
                        else if (dtcount.Rows[i]["voutype"].ToString() == "OX")
                        {
                            dtrow["voutype"] = "Admin Sales Invoice";

                        }
                        else if (dtcount.Rows[i]["voutype"].ToString() == "OP")
                        {
                            dtrow["voutype"] = "Credit Note - Operations";

                        }
                        else if (dtcount.Rows[i]["voutype"].ToString() == "OC")
                        {
                            dtrow["voutype"] = "OSPI";

                        }
                        else if (dtcount.Rows[i]["voutype"].ToString() == "OE")
                        {
                            dtrow["voutype"] = "Credit Note - Others";

                        }
                        else if (dtcount.Rows[i]["voutype"].ToString() == "OS")
                        {
                            dtrow["voutype"] = "Admin Purchase Invoice";

                        }
                        dtrow["vouyear"] = dtcount.Rows[i]["vouyear"].ToString();
                        dtrow["vouamount"] = dtcount.Rows[i]["vouamount"].ToString();
                        dtrow["fcurr"] = dtcount.Rows[i]["fcurr"].ToString();
                        dtrow["famount"] = dtcount.Rows[i]["famount"].ToString();
                        dtrow["vid"] = dtcount.Rows[i]["voutype"].ToString();
                        dtrow["bid"] = dtcount.Rows[i]["bid"].ToString();
                        dtrow["exrate"] = dtcount.Rows[i]["exrate"].ToString();
                        dt_cnt.Rows.Add(dtrow);
                    }
                    grdINVRec.DataSource = dt_cnt;
                    grdINVRec.DataBind();
                    Session["dt_Dtls"] = dt_cnt;

                    fn_caltotal();
                    if (dt_cnt.Rows.Count > 0)
                    {
                        // btnsave.Text = "Update";
                        btnsave.ToolTip = "Update";
                        btnsave1.Attributes["class"] = "btn ico-update";
                    }
                    //btncancel.Text = "Cancel";
                    btncancel.ToolTip = "Cancel";
                    btncancel1.Attributes["class"] = "btn ico-cancel";
                }
                //else
                //{
                //    if(customerobj.GetCustomerType(intcustid)=="P")
                //    {

                //    }
                //}
            }
        }
        */



        protected void txtLedgerName_TextChanged(object sender, EventArgs e)
        {
           // DataAccess.Accounts.Recipts recobj = new DataAccess.Accounts.Recipts();
            DataTable dtopbal = new DataTable();
            double opbalamt = 0;

            int custid=0;
            if (hid_custid.Value != "")
            {
                custid = Convert.ToInt32(hid_custid.Value);
            }
            else
            {
                custid = 0;
            }
           
            if (hid_Ledgername.Value != "" && hid_Ledgername.Value != "0")
            {
                dtopbal = recobj.SelOPBal4Ledger(Session["FADbname"].ToString(), Convert.ToInt32(hid_Ledgername.Value), Convert.ToInt32(Session["LoginBranchid"].ToString()));
                if (dtopbal.Rows.Count > 0)
                {
                    opbalamt = Convert.ToDouble(dtopbal.Rows[0]["OP_Bal"].ToString());
                    txtOpbal.Text = (string.Format("{0:0.00}", opbalamt));
                }

                DataTable dtcount = new DataTable();

                dtcount = recobj.ChkLedgIDInFARcptPmt(Convert.ToInt32(hid_Ledgername.Value), Convert.ToInt32(Session["LoginBranchid"].ToString()));
                if (dtcount.Rows.Count > 0)
                {
                    DataTable dt_cnt = new DataTable();
                    dt_cnt.Columns.Add("vouno", typeof(string));
                    dt_cnt.Columns.Add("voudate", typeof(string));
                    dt_cnt.Columns.Add("voutype", typeof(string));
                    dt_cnt.Columns.Add("vouyear", typeof(string));
                    dt_cnt.Columns.Add("vouamount", typeof(string));
                    dt_cnt.Columns.Add("fcurr", typeof(string));
                    dt_cnt.Columns.Add("famount", typeof(string));
                    dt_cnt.Columns.Add("vid", typeof(string));
                    dt_cnt.Columns.Add("bid", typeof(string));
                    dt_cnt.Columns.Add("exrate", typeof(string));
                    dt_cnt.Columns.Add("vendorrefno", typeof(string));
                    dt_cnt.Columns.Add("vendorrefdate", typeof(string));
                    for (int i = 0; i < dtcount.Rows.Count; i++)
                    {
                        DataRow dtrow = dt_cnt.NewRow();
                        dtrow["vouno"] = dtcount.Rows[i]["vouno"].ToString();
                        dtrow["voudate"] = dtcount.Rows[i]["voudate"].ToString();
                        if (dtcount.Rows[i]["voutype"].ToString() == "OI")
                        {
                            dtrow["voutype"] = "Invoice";

                        }
                        else if (dtcount.Rows[i]["voutype"].ToString() == "OD")
                        {
                            dtrow["voutype"] = "OSSI";

                        }
                        else if (dtcount.Rows[i]["voutype"].ToString() == "OV")
                        {
                            dtrow["voutype"] = "Debit Note - Others";

                        }
                        else if (dtcount.Rows[i]["voutype"].ToString() == "OX")
                        {
                            dtrow["voutype"] = "Admin Sales Invoice";

                        }
                        else if (dtcount.Rows[i]["voutype"].ToString() == "OP")
                        {
                            dtrow["voutype"] = "Credit Note - Operations";

                        }
                        else if (dtcount.Rows[i]["voutype"].ToString() == "OC")
                        {
                            dtrow["voutype"] = "OSPI";

                        }
                        else if (dtcount.Rows[i]["voutype"].ToString() == "OE")
                        {
                            dtrow["voutype"] = "Credit Note - Others";

                        }
                        else if (dtcount.Rows[i]["voutype"].ToString() == "OS")
                        {
                            dtrow["voutype"] = "Admin Purchase Invoice";

                        }
                        dtrow["vouyear"] = dtcount.Rows[i]["vouyear"].ToString();
                        dtrow["vouamount"] = dtcount.Rows[i]["vouamount"].ToString();
                        dtrow["fcurr"] = dtcount.Rows[i]["fcurr"].ToString();
                        dtrow["famount"] = dtcount.Rows[i]["famount"].ToString();
                        dtrow["vid"] = dtcount.Rows[i]["voutype"].ToString();
                        dtrow["bid"] = dtcount.Rows[i]["bid"].ToString();
                        dtrow["exrate"] = dtcount.Rows[i]["exrate"].ToString();
                        dtrow["vendorrefno"] = dtcount.Rows[i]["vendorrefno"].ToString();
                         if (dtcount.Rows[0]["vendorrefdate"] != System.DBNull.Value)
                                {
                                    dtrow["vendorrefdate"] = dtcount.Rows[i]["vendorrefdate"].ToString();
                                }
                                else
                                {
                                   dtrow["vendorrefdate"] = "";
                                }
                        
                        dt_cnt.Rows.Add(dtrow);
                    }
                    grdINVRec.DataSource = dt_cnt;
                    grdINVRec.DataBind();
                    Session["dt_Dtls"] = dt_cnt;

                    fn_caltotal();
                    if (dt_cnt.Rows.Count > 0)
                    {
                      btnsave.Text = "Update";
                        btnsave.ToolTip = "Update";
                        btnsave1.Attributes["class"] = "btn ico-update";
                    }
                    btncancel.Text = "Cancel";
                    btncancel.ToolTip = "Cancel";
                    btncancel1.Attributes["class"] = "btn ico-cancel";
                }
                //else
                //{
                //    if(customerobj.GetCustomerType(intcustid)=="P")
                //    {

                //    }
                //}
            }
        }
        private void fn_caltotal()
        {
            double Total_Amount = 0.0;
            double Total_Inc = 0.0;
            double Total_Exp = 0.0;
            string vtype = "";
            for (int i = 0; i <= grdINVRec.Rows.Count - 1; i++)
            {
                vtype = grdINVRec.Rows[i].Cells[8].Text;
                if (vtype == "OI" || vtype == "OD" || vtype == "OV" || vtype == "OX")
                {
                    Total_Inc = Total_Inc + Convert.ToDouble(grdINVRec.Rows[i].Cells[4].Text);
                }
                else if (vtype == "OP" || vtype == "OC" || vtype == "OE" || vtype == "OS")
                {
                    Total_Exp = Total_Exp + Convert.ToDouble(grdINVRec.Rows[i].Cells[4].Text);
                }

                Total_Amount = Math.Abs(Total_Inc - Total_Exp);
            }
            txt_total.Text = string.Format("{0:0.00}", Total_Amount);

            if(txt_total.Text==txtOpbal.Text)
            {  
                btnsave1.Visible = true;
                btnsave.Visible = true;
        
            }
            else
            {   btnsave1.Visible = false;
                btnsave.Visible = false;
             
            }
        }

        private void fn_clearVou()
        {
            txtvouno.Text = "";
            vdate = Logobj.GetDate();
            btnadd.ToolTip = "Add";
            btnadd1.Attributes["class"] = "btn ico-add";
            txtdate.Text = Utility.fn_ConvertDate(vdate.ToString());
            cmbvoutype.SelectedIndex = 0;
            txtvouyear.Text = "";
            txtamount.Text = "";
            txtFCurr.Text = "";
            txtFCamt.Text = "";
            txt_exrate.Text = "";
           
        }

        protected void btndelete_Click(object sender, EventArgs e)
        {
            DataTable dt_cnt = new DataTable();
            if (Session["dt_Dtls"] != null && !Session["dt_Dtls"].Equals("-1"))
            {
                dt_cnt = (DataTable)Session["dt_Dtls"];
            }
            if (dt_cnt.Rows.Count > 0)
            {
                dt_cnt.Select(string.Format("[vouno]='{0}' and [vid]>='{1}' and [vouyear]>='{2}' ", Convert.ToInt32(txtvouno.Text), cmbvoutype.SelectedValue, Convert.ToInt32(txtvouyear.Text))).ToList<DataRow>().ForEach(row => row.Delete());

                // dt_cnt.AsEnumerable().Where(r => r.Field<string>("col1") == "ali").ToList().ForEach(row => row.Delete());
                grdINVRec.DataSource = dt_cnt;
                grdINVRec.DataBind();
                Session["dt_Dtls"] = dt_cnt;
                fn_caltotal();
                fn_clearVou();
            }
        }

        protected void grdINVRec_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                for (int i = 0; i < e.Row.Cells.Count; i++)
                {
                    if (e.Row.Cells[i].Text == "&nbsp;")
                    {
                        e.Row.Cells[i].Text = "";
                    }
                    e.Row.Cells[i].ToolTip = e.Row.Cells[i].Text;
                }
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(grdINVRec, "Select$" + e.Row.RowIndex);
                e.Row.Attributes["style"] = "cursor:pointer";
            }
        }

        protected void grdINVRec_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (grdINVRec.Rows.Count > 0)
            {
                int index = grdINVRec.SelectedRow.RowIndex;
                btnadd.Text = "Update";
                btnadd.ToolTip = "Update";
                btnadd1.Attributes["class"] = "btn ico-update";
                txtvouno.Text = grdINVRec.SelectedRow.Cells[0].Text;
                txtdate.Text = grdINVRec.SelectedRow.Cells[1].Text;
                cmbvoutype.SelectedValue = grdINVRec.SelectedRow.Cells[8].Text;
                txtvouyear.Text = grdINVRec.SelectedRow.Cells[3].Text;
                txtamount.Text = grdINVRec.SelectedRow.Cells[4].Text;
                txtFCurr.Text = grdINVRec.SelectedRow.Cells[5].Text;
                txtFCamt.Text = grdINVRec.SelectedRow.Cells[6].Text;
                if (grdINVRec.SelectedRow.Cells[10].Text != "")
                {
                    txtVendorRefno.Text = grdINVRec.SelectedRow.Cells[10].Text;
                }
                else
                {
                    txtVendorRefno.Text = "";
                }
                if (grdINVRec.SelectedRow.Cells[11].Text != "")
                {
                    txtVendorRefnodate.Text = grdINVRec.SelectedRow.Cells[11].Text;
                }
                else
                {
                    hid_date.Value = Utility.fn_ConvertDate(Logobj.GetDate().ToShortDateString());

                    txtVendorRefnodate.Text = hid_date.Value.ToString();
                }
            }
        }

        public void CheckData()
        {
            if (txtLedgerName.Text.Trim() == "")
            {
                ScriptManager.RegisterStartupScript(btnadd, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Ledger Name cannot be blank');", true);

                txtLedgerName.Focus();
                blnerr = true;
                return;
            }

            else
            {
                int cust = 0;
                //cust = customerobj.GetCustomerid(txtto.Text);
                cust = Convert.ToInt32(hid_Ledgername.Value);
                if (hid_Ledgername.Value == "0")
                {
                    ScriptManager.RegisterStartupScript(btnadd, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Ledger cannot be blank');", true);

                    txtLedgerName.Focus();
                    blnerr = true;
                    return;
                }
            }

            if (txtvouno.Text.Trim() == "")
            {
                ScriptManager.RegisterStartupScript(btnadd, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Kindly Enter the  Vou #');", true);
                txtvouno.Focus();
                blnerr = true;
                return;
            }
            if(txtvouno.Text.Trim()!="")
            {
                if(txtvouno.Text.Length>6)
                {
                    ScriptManager.RegisterStartupScript(btnadd, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Kindly Enter the Vou # lessthan 6 Digits only');", true);
                    txtvouno.Text = "";
                    txtvouno.Focus();
                    blnerr = true;
                    return;
                }
            }
            if (cmbvoutype.SelectedItem.Text == "Credit Note - Operations" || cmbvoutype.SelectedItem.Text == "Credit Note - Others" || cmbvoutype.SelectedItem.Text == "Admin Purchase Invoice" || cmbvoutype.SelectedItem.Text == "OSPI")
            {
                if (txtVendorRefno.Text == "")
                {
                    ScriptManager.RegisterStartupScript(btnadd, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Kindly Enter the VendorRef #');", true);
                    txtVendorRefno.Focus();
                    blnerr = true;
                    return;
                }
            } 
            if (txtdate.Text.Trim() == "")
            {
                ScriptManager.RegisterStartupScript(btnadd, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Kindly Enter the Vou Dates');", true);
                txtvouno.Focus();
                blnerr = true;
                return;
            }
            if (cmbvoutype.SelectedIndex == 0)
            {
                ScriptManager.RegisterStartupScript(btnadd, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Vou type cannot be blank');", true);

                cmbvoutype.Focus();
                blnerr = true;
                return;
            }
            if (txtvouyear.Text.Trim() == "")
            {
                ScriptManager.RegisterStartupScript(btnadd, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Kindly Enter the Vou Year');", true);
                txtvouyear.Focus();
                blnerr = true;
                return;
            }
            if (txtamount.Text.Trim() == "")
            {
                ScriptManager.RegisterStartupScript(btnadd, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Kindly Enter the Vou Amount');", true);
                txtamount.Focus();
                blnerr = true;
                return;
            }

            if (cmbvoutype.SelectedValue == "OSSI" || cmbvoutype.SelectedValue == "OSPI")
            {
                if (txtFCurr.Text.Trim() == "")
                {
                    ScriptManager.RegisterStartupScript(btnadd, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Kindly Enter the FCurr');", true);
                    txtFCurr.Focus();
                    blnerr = true;
                    return;
                }
                else if (txtFCamt.Text.Trim() == "")
                {
                    ScriptManager.RegisterStartupScript(btnadd, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Kindly Enter the FC Amount');", true);
                    txtFCamt.Focus();
                    blnerr = true;
                    return;
                }
            }

            if (txtFCurr.Text.Trim() != "")
            {
                if (cmbvoutype.SelectedValue == "Invoice" || cmbvoutype.SelectedValue == "Credit Note - Operations")
                {
                    if (basecurr != txtFCurr.Text.Trim())
                    {
                        ScriptManager.RegisterStartupScript(btnadd, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Currency " + txtFCurr.Text.Trim() + " Not Accepted');", true);
                        txtFCamt.Focus();
                        blnerr = true;
                        return;
                    }
                }
                else if (basecurr != txtFCurr.Text.Trim())
                {
                    if (Convert.ToDouble(txtFCamt.Text) >= Convert.ToDouble(txtamount.Text))
                    {
                        ScriptManager.RegisterStartupScript(btnadd, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('FC Amount does not greater than or equal to local curr amount');", true);
                        txtFCamt.Focus();
                        blnerr = true;
                        return;
                    }

                }
            }
        }

        protected void txtFCurr_TextChanged(object sender, EventArgs e)
        {

            try
            {
                //DataAccess.Masters.MasterCharges chargeobj = new DataAccess.Masters.MasterCharges();
                int currid = chargeobj.GetCurrID(txtFCurr.Text.Trim().ToUpper());
                if (txtFCurr.Text.Trim().ToUpper() == "INR" && cmbvoutype.SelectedValue == "OD" || cmbvoutype.SelectedValue == "OC")
                {
                    ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Currency INR Not Accepted');", true);
                    txtFCurr.Text = "";
                    txtFCurr.Focus();
                    //blrr = true;
                    return;
                }
                else if (currid == 0)
                {
                    txtFCurr.Text = "";
                    txtFCurr.Focus();
                    ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Enter the Valid Currency');", true);
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }

        }

        protected void txt_exrate_TextChanged(object sender, EventArgs e)
        {
            if (txt_exrate.Text != "")
            {
                if (txtFCamt.Text != "")
                {
                    Double amount = Convert.ToDouble(txtFCamt.Text) * Convert.ToDouble(txt_exrate.Text);
                    txtamount.Text = amount.ToString("#,0.00");
                }
                if (txtamount.Text != "")
                {
                    Double fcamount = Convert.ToDouble(txtamount.Text) / Convert.ToDouble(txt_exrate.Text);
                    txtFCamt.Text = fcamount.ToString("#,0.00");
                }


            }
        }

        //Ruban



        protected void btn_upload_Click(object sender, EventArgs e)
        {

            if (txtLedgerName.Text.Trim() == "")
            {
                ScriptManager.RegisterStartupScript(btnadd, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Ledger Name cannot be blank');", true);

                txtLedgerName.Focus();
                blnerr = true;
                return;
            }
            string filename = System.IO.Path.GetFileName(fileuploadExcel.FileName);

            string[] strTempArray;
            int intlen;
            strTempArray = filename.Split('.');
            intlen = strTempArray.Length - 1;
            if (strTempArray[intlen] != "xlsx" || strTempArray[intlen] == "xlsm" || strTempArray[intlen] == "xls")
            {
                ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Select Excel File...');", true);
                //grdINVRec.DataSource = Utility.Fn_GetEmptyDataTable();
                //grdINVRec.DataBind();
                return;
            }
            if (filename != "" && filename != null)
            {
                path = Server.MapPath("~/OpeningBalanceBreakUP/" + filename);
                if (Directory.Exists(path))
                {
                    foreach (string file in Directory.GetFiles(path))
                    {
                        File.Delete(file);
                    }
                }
                fileuploadExcel.PostedFile.SaveAs(Server.MapPath("~/OpeningBalanceBreakUp/" + filename.ToString()));
                path = Server.MapPath("~/OpeningBalanceBreakUP/" + filename);
                ImportAttendence(path);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "logix", "alertify.alert('Kindly Select File');", true);
                return;
            }

        }
        public void ImportAttendence(string PrmPathExcelFile)
        {
            try
            {

                System.Data.OleDb.OleDbConnection MyConnection = new System.Data.OleDb.OleDbConnection();
                DataSet DtSet = new DataSet();
                System.Data.OleDb.OleDbDataAdapter MyCommand = new System.Data.OleDb.OleDbDataAdapter();
                string[] strTempArray;
                int intlen;
                double famount = 0, exrate = 0;

                strTempArray = PrmPathExcelFile.Split('.');
                intlen = strTempArray.Length - 1;
                if (strTempArray[intlen] == "xlsx")
                {
                    MyConnection = new System.Data.OleDb.OleDbConnection("provider=Microsoft.ACE.OLEDB.12.0; " + "data source='" + PrmPathExcelFile + " '; " + "Extended Properties=Excel 8.0;");
                }
                else if (strTempArray[intlen] == "xlsm")
                {
                    MyConnection = new System.Data.OleDb.OleDbConnection("provider=Microsoft.ACE.OLEDB.12.0; " + "data source='" + PrmPathExcelFile + " '; " + "Extended Properties=Excel 12.0;");
                }
                else if (strTempArray[intlen] == "xls")
                {
                    MyConnection = new System.Data.OleDb.OleDbConnection("provider=Microsoft.ACE.OLEDB.12.0; " + "data source='" + PrmPathExcelFile + " '; " + "Extended Properties=Excel 8.0;");
                }

                MyCommand = new System.Data.OleDb.OleDbDataAdapter("select * from [sheet1$]", MyConnection);
                //MyCommand.TableMappings.Add("Table", "Attendence");
                //  MyCommand.TableMappings.Add("Table", "container no");
                DtSet = new System.Data.DataSet();
                DataTable newdt = new DataTable();
                MyCommand.Fill(newdt);

                for (int i = newdt.Rows.Count - 1; i >= 0; i--)
                {
                    if (newdt.Rows[i][1] == DBNull.Value)
                        newdt.Rows[i].Delete();
                }
                newdt.AcceptChanges();

                grdINVRec.Visible = true;

                newdt.Columns.Add("bid");
                newdt.Columns.Add("vid");

                for (int i = 0; i < newdt.Rows.Count; i++)
                {


                    newdt.Rows[i]["bid"] = Convert.ToInt32(Session["LoginBranchid"].ToString());

                    if (newdt.Rows[i]["voutype"].ToString() == "Invoice")
                    {
                        newdt.Rows[i]["vid"] = "OI";
                    }
                    else if (newdt.Rows[i]["voutype"].ToString() == "Credit Note - Operations")
                    {
                        newdt.Rows[i]["vid"] = "OP";
                    }
                    else if (newdt.Rows[i]["voutype"].ToString() == "OSSI")
                    {
                        newdt.Rows[i]["vid"] = "OD";
                    }
                    else if (newdt.Rows[i]["voutype"].ToString() == "OSPI")
                    {
                        newdt.Rows[i]["vid"] = "OC";
                    }
                    else if (newdt.Rows[i]["voutype"].ToString() == "Debit Note - Others")
                    {
                        newdt.Rows[i]["vid"] = "OV";
                    }
                    else if (newdt.Rows[i]["voutype"].ToString() == "Credit Note - Others")
                    {
                        newdt.Rows[i]["vid"] = "OE";
                    }
                    else if (newdt.Rows[i]["voutype"].ToString() == "Admin Purchase Invoice")
                    {
                        newdt.Rows[i]["vid"] = "OS";
                    }
                    else if (newdt.Rows[i]["voutype"].ToString() == "Admin Sales Invoice")
                    {
                        newdt.Rows[i]["vid"] = "OX";
                    }

                    if (!string.IsNullOrEmpty(newdt.Rows[i]["famount"].ToString()) && !string.IsNullOrEmpty(newdt.Rows[i]["exrate"].ToString()))
                    {
                        double amount = 0;
                        amount = Convert.ToDouble(newdt.Rows[i]["famount"]) * Convert.ToDouble(newdt.Rows[i]["exrate"]);
                        newdt.Rows[i]["vouamount"] = amount.ToString("#,0.00");

                    }
                    else
                    {

                    }



                }
                grdINVRec.DataSource = newdt;
                grdINVRec.DataBind();
                fn_caltotal();
                fn_clearVou();
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "logix", "alertify.alert('Kindly check the Excel Format');", true);
                return;
            }
        }

        protected void txtvouno_TextChanged(object sender, EventArgs e)
        {
            if (txtvouno.Text.Trim() != "")
            {
                if (txtvouno.Text.Length > 6)
                {
                    ScriptManager.RegisterStartupScript(btnadd, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Kindly Enter the Vou # lessthan 6 Digits only');", true);
                    txtvouno.Text = "";
                    txtvouno.Focus();
                    blnerr = true;
                    return;
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
            Panel1.Visible = true;
            DataTable obj_dtlogdetails = new DataTable();
            //DataAccess.LogDetails Logobj = new DataAccess.LogDetails();

            if (Session["str_ModuleName"].ToString() == "FA")
            {
                obj_dtlogdetails = Logobj.InsTempGrpLogdtlsGet(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), 1902, "", "", "", Session["StrTranType"].ToString());
            }
            else
            {
                obj_dtlogdetails = Logobj.InsTempGrpLogdtlsGet(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), 1903, "", "", "", Session["StrTranType"].ToString());
            }

        

            if (obj_dtlogdetails.Rows.Count >= 0)
            {
                ModalPopupExtenderlog.Show();
                GridViewlog.DataSource = obj_dtlogdetails;
                GridViewlog.DataBind();
            }
        }

        protected void grdINVRec_PreRender(object sender, EventArgs e)
        {
            if (grdINVRec.Rows.Count > 0)
            {
                grdINVRec.UseAccessibleHeader = true;
                grdINVRec.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }




    }
}