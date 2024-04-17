using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace logix.ForwardExports
{
    public partial class MBLDraft : System.Web.UI.Page
    {
        DataAccess.ForwardingExports.AmendBL objAmend = new DataAccess.ForwardingExports.AmendBL();
        DataTable Dt = new DataTable();
        DataAccess.ForwardingExports.BLDetails bldetails = new DataAccess.ForwardingExports.BLDetails();
        DataTable dt_cont = new DataTable();
        DataAccess.LogDetails obj_da_Log1 = new DataAccess.LogDetails();
        DataAccess.ForwardingExports.JobInfo obj_da_Job = new DataAccess.ForwardingExports.JobInfo();
        string blno; double cbm, grwght, ntwght;
        DataTable obj_dt = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "SpanTagMoveInputBottom();MuiTextField();", true);
            if (Session["LoginUserName"] == null || Session["LoginEmpId"] == null || Session["LoginDivisionId"] == null || Session["LoginBranchid"] == null)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alertify.alert('Session TimeOut');window.open('" + Session["Site"].ToString() + "/','_top');", true);
            }
            else if (Session["StrTranType"] == null)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alertify.alert('Session TimeOut');window.open('" + Session["Site"].ToString() + "/FormMain.aspx','_top');", true);
            }
            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(btnClear);
            if (!IsPostBack)
            {
                txtJob.Attributes.Add("OnKeypress", "return IntegerCheck(event);");
                txtJob.Focus();
                //btnClear.Text = "Cancel";

                btnClear.ToolTip = "Cancel";
                btnClear1.Attributes["class"] = "btn ico-cancel";
                if (Request.QueryString.ToString().Contains("job"))
                {
                    txtJob.Text = Request.QueryString["job"].ToString();
                    txtJob_TextChanged(sender, e);
                }
            }
        }

        protected void txtJob_TextChanged(object sender, EventArgs e)
        {
            DataTable DT1 = new DataTable();
            
            if (txtJob.Text == "")
            {
                ScriptManager.RegisterStartupScript(btnSave, typeof(Button), "BLDetails", "alert('Job # Cannot be blank');", true);
                txtJob.Focus();
                return;
            }
            Dt = objAmend.GetReriveDetailsForMBLDraft(Convert.ToInt32(txtJob.Text), Convert.ToInt32(Session["LoginBranchid"]));
            if (Dt.Rows.Count > 0)
            {
                txtJob.Text = Dt.Rows[0]["jobno"].ToString();
                txt_voyageandvessel.Text = Dt.Rows[0]["vslvoy"].ToString();
                if (!string.IsNullOrEmpty(Dt.Rows[0]["shipperaddress"].ToString()))
                {
                    txt_shipperaddress.Text = Dt.Rows[0]["shipperaddress"].ToString();
                }



                if (!string.IsNullOrEmpty(Dt.Rows[0]["consigneeaddress"].ToString()))
                {
                    txt_consigneeaddress.Text = Dt.Rows[0]["consigneeaddress"].ToString();
                }
                if (!string.IsNullOrEmpty(Dt.Rows[0]["notifyaddress"].ToString()))
                {
                    txt_notify.Text = Dt.Rows[0]["notifyaddress"].ToString();
                }
                else
                {
                    txt_notify.Text = "SAME AS CONSIGNEE";
                }
                txt_receipt.Text = Dt.Rows[0]["poa"].ToString();
                txt_loading.Text = Dt.Rows[0]["pol"].ToString();
                txt_discharge.Text = Dt.Rows[0]["pod"].ToString();
                txt_destination.Text = Dt.Rows[0]["fd"].ToString();
                ddl_freight.SelectedValue = Dt.Rows[0]["freight"].ToString();

                txt_grwt.Text = Dt.Rows[0]["grweight"].ToString();
                txt_ntwt.Text = Dt.Rows[0]["ntweight"].ToString();
                txt_descn.Text = Dt.Rows[0]["descn"].ToString().ToUpper();
                txt_marks.Text = Dt.Rows[0]["marks"].ToString();
                txt_container.Text = Dt.Rows[0]["cntrdetails"].ToString();
                ddl_freight.SelectedValue = Dt.Rows[0]["freight"].ToString();
                txt_cbm.Text = Dt.Rows[0]["cbm"].ToString();
                //btnSave.Text = "Update";
                btnSave.ToolTip = "Update";
                btnSave1.Attributes["class"] = "btn ico-update";
                txtJob.Focus();
            }
            else
            {
                DT1 = objAmend.GetReriveDetailsForMBLDraftNew(Convert.ToInt32(txtJob.Text), Convert.ToInt32(Session["LoginBranchid"]));
                if (DT1.Rows.Count > 0)
                {
                    txtJob.Text = DT1.Rows[0]["jobno"].ToString();
                    txt_voyageandvessel.Text = DT1.Rows[0]["vslvoy"].ToString();

                    txt_shipperaddress.Text = DT1.Rows[0]["branchname"].ToString() + "," + System.Environment.NewLine + DT1.Rows[0]["addres"].ToString();


                    txt_consigneeaddress.Text = DT1.Rows[0]["customername"].ToString() + "," + System.Environment.NewLine + DT1.Rows[0]["address"].ToString();
                    if (!string.IsNullOrEmpty(DT1.Rows[0]["portname"].ToString()))
                    {
                        txt_consigneeaddress.Text += System.Environment.NewLine + DT1.Rows[0]["portname"].ToString();
                    }
                    if (!string.IsNullOrEmpty(DT1.Rows[0]["zip"].ToString()))
                    {
                        txt_consigneeaddress.Text += " - " + DT1.Rows[0]["zip"].ToString();
                    }
                    if (!string.IsNullOrEmpty(DT1.Rows[0]["phone"].ToString()))
                    {
                        txt_consigneeaddress.Text += System.Environment.NewLine + "Ph :" + DT1.Rows[0]["phone"].ToString() + " ;";
                    }
                    if (!string.IsNullOrEmpty(DT1.Rows[0]["fax"].ToString()))
                    {
                        txt_consigneeaddress.Text += "Fax :" + DT1.Rows[0]["fax"].ToString();
                    }
                    txt_notify.Text = "SAME AS CONSIGNEE";
                    obj_dt = obj_da_Job.GetContainerDetails(int.Parse(txtJob.Text), txtJob.Text, Convert.ToInt32(Session["LoginBranchId"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()));

                    for (int i = 0; i < obj_dt.Rows.Count; i++)
                    {
                        txt_container.Text += obj_dt.Rows[i]["containerno"].ToString() + "/" + obj_dt.Rows[i]["sizetype"].ToString() + "/" + obj_dt.Rows[i]["sealno"].ToString() + "/" + obj_dt.Rows[i]["pkgs"].ToString() + "/" + obj_dt.Rows[i]["wt"].ToString() + "\n";
                    }

                    txt_receipt.Text = DT1.Rows[0]["poa"].ToString();
                    txt_loading.Text = DT1.Rows[0]["pol"].ToString();
                    txt_discharge.Text = DT1.Rows[0]["pod"].ToString();
                    txt_destination.Text = DT1.Rows[0]["fd"].ToString();
                    ddl_freight.SelectedValue = DT1.Rows[0]["freight"].ToString();


                    cbm = 0; grwght = 0; ntwght = 0;
                    for (int i = 0; i < DT1.Rows.Count; i++)
                    {
                        txt_descn.Text += DT1.Rows[i]["descn"].ToString().ToUpper() + System.Environment.NewLine + System.Environment.NewLine;
                        txt_marks.Text += DT1.Rows[i]["marks"].ToString().ToUpper() + System.Environment.NewLine + System.Environment.NewLine;
                        if (!string.IsNullOrEmpty(DT1.Rows[i]["cbm"].ToString()))
                        {
                            cbm += Convert.ToDouble(DT1.Rows[i]["cbm"].ToString());
                        }
                        if (!string.IsNullOrEmpty(DT1.Rows[i]["grweight"].ToString()))
                        {
                            grwght += Convert.ToDouble(DT1.Rows[i]["grweight"].ToString());
                        }
                        if (!string.IsNullOrEmpty(DT1.Rows[i]["ntweight"].ToString()))
                        {
                            ntwght += Convert.ToDouble(DT1.Rows[i]["ntweight"].ToString());
                        }

                    }
                    txt_cbm.Text = cbm.ToString("#0.000");
                    txt_grwt.Text = grwght.ToString("#0.000");
                    txt_ntwt.Text = ntwght.ToString("#0.000");
                    txtJob.Focus();
                    //  btnSave.Text = "Save";
                    btnSave.ToolTip = "Save";
                    btnSave1.Attributes["class"] = "btn ico-save";
                }

            }

            // btnClear.Text = "Cancel";

            btnClear.ToolTip = "Cancel";
            btnClear1.Attributes["class"] = "btn ico-cancel";
            if (Dt.Rows.Count == 0 && DT1.Rows.Count == 0)
            {
                ScriptManager.RegisterStartupScript(btnSave, typeof(Button), "BLDetails", "alert('Invalid Job #');", true);
            }

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (btnSave.ToolTip == "Save")
            {
                objAmend.InsertForMblDraft(Convert.ToInt32(txtJob.Text), Convert.ToInt32(Session["LoginBranchid"]), txt_voyageandvessel.Text.ToUpper(), txt_shipperaddress.Text.ToUpper(), txt_consigneeaddress.Text.ToUpper(), txt_marks.Text.ToUpper(), txt_descn.Text.ToUpper(), (txt_grwt.Text.ToUpper()), (txt_ntwt.Text.ToUpper()), ddl_freight.SelectedValue, txt_container.Text.ToUpper(), txt_receipt.Text.ToUpper(), txt_loading.Text.ToUpper(), txt_discharge.Text.ToUpper(), txt_destination.Text.ToUpper(), txt_cbm.Text.ToUpper(), txt_notify.Text.ToUpper());
                //btnSave.Text = "Update";
                btnSave.ToolTip = "Update";
                btnSave1.Attributes["class"] = "btn ico-update";
                ScriptManager.RegisterStartupScript(btnSave, typeof(Button), "BLDetails", "alert('Details Saved');", true);
            }
            else if (btnSave.ToolTip == "Update")
            {
                objAmend.UpdateMblDraft(Convert.ToInt32(txtJob.Text), Convert.ToInt32(Session["LoginBranchid"]), txt_voyageandvessel.Text.ToUpper(), txt_shipperaddress.Text.ToUpper(), txt_consigneeaddress.Text.ToUpper(), txt_marks.Text.ToUpper(), txt_descn.Text.ToUpper(), (txt_grwt.Text.ToUpper()), (txt_ntwt.Text.ToUpper()), ddl_freight.SelectedValue, txt_container.Text.ToUpper(), txt_receipt.Text.ToUpper(), txt_loading.Text.ToUpper(), txt_discharge.Text.ToUpper(), txt_destination.Text.ToUpper(), txt_cbm.Text.ToUpper(), txt_notify.Text.ToUpper());
                //btnSave.Text = "Update";
                btnSave.ToolTip = "Update";
                btnSave1.Attributes["class"] = "btn ico-update";
                ScriptManager.RegisterStartupScript(btnSave, typeof(Button), "BLDetails", "alert('Details Updated');", true);
            }
            // btnClear.Text = "Cancel";
            //btnSave.ToolTip = "Cancel";
            //btnSave1.Attributes["class"] = "btn ico-cancel";
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            if (btnClear.ToolTip == "Cancel")
            {
                txtJob.Text = "";
                txt_voyageandvessel.Text = "";
                txt_shipperaddress.Text = "";
                txt_consigneeaddress.Text = "";
                //btnClear.Text = "Back";
                //btnSave.Text = "Save";

                btnClear.ToolTip = "Back";
                btnSave.ToolTip = "Save";

                btnSave1.Attributes["class"] = "btn ico-save";
                btnClear1.Attributes["class"] = "btn ico-back";
                ddl_freight.SelectedValue = "0";
                txt_marks.Text = "";
                txt_descn.Text = "";
                txt_container.Text = "";
                txt_receipt.Text = "";
                txt_loading.Text = "";
                txt_discharge.Text = "";
                txt_destination.Text = "";
                txt_grwt.Text = "";
                txt_ntwt.Text = "";
                txt_cbm.Text = "";
                txtJob.Focus();
                txt_notify.Text = "";
            }
            else if (btnClear.ToolTip == "Back")
            {
                if (Session["home"] != null)
                {
                    if (Session["home"] == "OPS&DOC")
                    {
                        if (Session["StrTranType"] == "FE")
                        {
                            Response.Redirect("../Home/OEOpsAndDocs.aspx");
                        }
                        else if (Session["StrTranType"] == "FI")
                        {
                            Response.Redirect("../Home/OEOpsAndDocs.aspx");
                        }
                        else if (Session["StrTranType"] == "AE")
                        {
                            Response.Redirect("../Home/OEOpsAndDocs.aspx");
                        }
                        else if (Session["StrTranType"] == "AI")
                        {
                            Response.Redirect("../Home/OEOpsAndDocs.aspx");
                        }
                    }
                }
            }
        }

        protected void btnview_Click(object sender, EventArgs e)
        {
            string str_sp = "", str_sp1 = "";
            string str_sf = "", str_sf1 = "";

            string str_RptName = "";
            string str_Script = "";
            Session["str_sfs"] = "";
            Session["str_sp"] = "";
            Session["str_sfsnew1"] = "";
            Session["str_spnew1"] = "";
            string container = "";
            string blno = "";
            if (txtJob.Text != "")
            {
                if (btnSave.ToolTip == "Update")
                {
                    objAmend.UpdateMblDraft(Convert.ToInt32(txtJob.Text), Convert.ToInt32(Session["LoginBranchid"]), txt_voyageandvessel.Text.ToUpper(), txt_shipperaddress.Text.ToUpper(), txt_consigneeaddress.Text.ToUpper(), txt_marks.Text.ToUpper(), txt_descn.Text.ToUpper(), (txt_grwt.Text.ToUpper()), (txt_ntwt.Text.ToUpper()), ddl_freight.SelectedValue, txt_container.Text.ToUpper(), txt_receipt.Text.ToUpper(), txt_loading.Text.ToUpper(), txt_discharge.Text.ToUpper(), txt_destination.Text.ToUpper(), txt_cbm.Text.ToUpper(), txt_notify.Text.ToUpper());
                }
                dt_cont = bldetails.get_containeronly(Convert.ToInt32(txtJob.Text), Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(Session["LoginDivisionId"]));
                if (dt_cont.Rows.Count > 0)
                {
                    container = dt_cont.Rows[0]["cntrdetails"].ToString();
                    blno = dt_cont.Rows[0]["blno"].ToString();
                    hid_marks.Value = dt_cont.Rows[0]["marks"].ToString();
                    //hid_desc.Value = dt_cont.Rows[0]["descn"].ToString();  
                }


                hid_desc.Value = txt_descn.Text;     //Customer  desc taken by MBLdraft


                container = container.TrimStart().TrimEnd().Trim().Replace(System.Environment.NewLine, " ");
                hid_marks.Value = hid_marks.Value.ToString().TrimStart().TrimEnd().Trim().Replace(System.Environment.NewLine, " ");
                //hid_desc.Value = hid_desc.Value.ToString().TrimStart().TrimEnd().Trim().Replace(System.Environment.NewLine, " ");

                //hid_desc.Value = hid_desc.Value.Replace(System.Environment.NewLine, "  ").Replace("\n", "  ");

                hid_desc.Value = hid_desc.Value;

                str_RptName = "MBLDraft4MG.rpt";
                str_sp = "location=" + Session["LoginBranchName"].ToString() + "~agent=" + "";
                str_sf = "{FEjobinfo.jobno}= " + txtJob.Text + "  and {FEBLDetails.bid}=" + Convert.ToInt32(Session["LoginBranchid"]);
                //str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                str_Script = "window.open('../Reportasp/MBLDraftRpt.aspx?jobno=" + txtJob.Text + "&Bid=" + Session["LoginBranchid"].ToString() + "&location=" + Session["LoginBranchName"].ToString() + "&agent=" + ""+ "&type=" + "D" + "','','');";



                obj_da_Log1.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1849, 3, Convert.ToInt32(Session["LoginBranchid"]), "MBL #: " + txtJob.Text + "/ Draft");
                Session["str_sfs"] = str_sf;
                Session["str_sp"] = str_sp;

                int int_containerlength = 0, int_marklength = 0, int_desclength = 0;
                int_containerlength = container.ToString().Length;
                int_marklength = hid_marks.Value.ToString().Length;
                int_desclength = hid_desc.Value.ToString().Length;
                // string str_sp = "", str_sf = "", str_RptName = "", str_Script = "";

                //if (int_containerlength > 290 && int_marklength > 250 && int_desclength > 600)
                //{
                //    int_containerlength = 0; int_marklength = 0; int_desclength = 0;
                //    str_RptName = "BlRAnexMBLDraft.rpt";
                //    Session["str_sfsnew1"] = "{fembldraft.jobno}='" + txtJob.Text + "' and {fembldraft.branchid}=" + Session["LoginBranchid"].ToString();
                //    str_sp1 = "descn=" + "";
                //    str_Script += "window.open('../Tools/ReportView1.aspx?SFormula=" + str_sf1 + "&Parameter=" + str_sp1 + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                //    //ScriptManager.RegisterStartupScript(btnDraft, typeof(Button), "BLRelease", str_Script, true);
                //}
                //if (int_containerlength > 290 && int_desclength > 600)
                //{
                //    int_containerlength = 0; int_marklength = 0; int_desclength = 0;
                //    str_RptName = "BLRContDescMBLDraft.rpt";
                //    Session["str_sfsnew1"] = "{fembldraft.jobno}='" + txtJob.Text + "' and {fembldraft.branchid}=" + Session["LoginBranchid"].ToString();
                //    str_sp1 = "descn=" + "";
                //    str_Script += "window.open('../Tools/ReportView1.aspx?SFormula=" + str_sf1 + "&Parameter=" + str_sp1 + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                //    //ScriptManager.RegisterStartupScript(btnDraft, typeof(Button), "BLRelease", str_Script, true);

                //}
                //if (int_marklength > 250 && int_desclength > 600)
                //{
                //    int_containerlength = 0; int_marklength = 0; int_desclength = 0;
                //    str_RptName = "BLRMarksDescMBLDraft.rpt";
                //    Session["str_sfsnew1"] = "{fembldraft.jobno}='" + txtJob.Text + "' and {fembldraft.branchid}=" + Session["LoginBranchid"].ToString();
                //    str_sp1 = "descn=" + "";
                //    str_Script += "window.open('../Tools/ReportView1.aspx?SFormula=" + str_sf1 + "&Parameter=" + str_sp1 + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                //    //ScriptManager.RegisterStartupScript(btnDraft, typeof(Button), "BLRelease", str_Script, true);
                //}
                //if (int_marklength > 250 && int_containerlength > 290)
                //{
                //    int_containerlength = 0; int_marklength = 0; int_desclength = 0;
                //    str_RptName = "BlRContMarksMBLDraft.rpt";
                //    Session["str_sfsnew1"] = "{fembldraft.jobno}='" + txtJob.Text + "'and {fembldraft.branchid}=" + Session["LoginBranchid"].ToString();
                //    str_sp1 = "descn=" + "";
                //    str_Script += "window.open('../Tools/ReportView1.aspx?SFormula=" + str_sf1 + "&Parameter=" + str_sp1 + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                //    //ScriptManager.RegisterStartupScript(btnDraft, typeof(Button), "BLRelease", str_Script, true);
                //}
                //if (int_containerlength > 290)
                //{
                //    int_containerlength = 0; int_marklength = 0; int_desclength = 0;
                //    str_RptName = "BlRContainerMBLDraft.rpt";
                //    Session["str_sfsnew1"] = "{fembldraft.jobno}='" + txtJob.Text + "'and {fembldraft.branchid}=" + Session["LoginBranchid"].ToString();
                //    str_sp1 = "descn=" + "";
                //    str_Script += "window.open('../Tools/ReportView1.aspx?SFormula=" + str_sf1 + "&Parameter=" + str_sp1 + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                //    //ScriptManager.RegisterStartupScript(btnDraft, typeof(Button), "BLRelease", str_Script, true);
                //}
                //if (int_marklength > 250)
                //{
                //    int_containerlength = 0; int_marklength = 0; int_desclength = 0;
                //    str_RptName = "BlRMarksMBLDraft.rpt";
                //    Session["str_sfsnew1"] = "{fembldraft.jobno}='" + txtJob.Text + "'and {fembldraft.branchid}=" + Session["LoginBranchid"].ToString();
                //    str_sp1 = "descn=" + "";
                //    str_Script += "window.open('../Tools/ReportView1.aspx?SFormula=" + str_sf1 + "&Parameter=" + str_sp1 + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                //    //ScriptManager.RegisterStartupScript(btnDraft, typeof(Button), "BLRelease", str_Script, true);
                //}
                if (int_desclength > 600)
                {
                    int_containerlength = 0; int_marklength = 0; int_desclength = 0;
                    str_RptName = "BlRDescMBLDraft.rpt";

                    Session["str_sfsnew1"] = "{fembldraft.jobno}=" + txtJob.Text + "and {fembldraft.branchid}=" + Session["LoginBranchid"].ToString();
                    //str_sf1 = Session["str_sfsnew1"].ToString();
                    str_sf1 = Session["str_sfsnew1"].ToString();
                    str_sp1 = "descn=" + "";

                    str_Script += "window.open('../Tools/ReportView1.aspx?SFormula=" + str_sf1 + "&Parameter=" + str_sp1 + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                    //ScriptManager.RegisterStartupScript(btnDraft, typeof(Button), "BLRelease", str_Script, true);
                }
                Session["str_spnew1"] = str_sp1;

                ScriptManager.RegisterStartupScript(btnview, typeof(Button), "JobInfo", str_Script, true);
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "iFact Touch", "alert('Enter the Job#');", true);
                txtJob.Text = "";
                txtJob.Focus();
                return;
            }
        }
    }
}