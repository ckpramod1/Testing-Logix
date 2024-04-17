using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace logix.Maintenance
{
    public partial class ServiceTaxUpdate : System.Web.UI.Page
    {
        DataAccess.Masters.MasterCharges chargesobj = new DataAccess.Masters.MasterCharges();
        DataAccess.LogDetails obj_da_Log = new DataAccess.LogDetails();
        DataTable dtcharges = new DataTable();
        int k=1;
        Double curper = 0, curedcess = 0, curhedcess = 0, proper = 0, proedcess = 0, prohedcess = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["LoginUserName"] == null)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alertify.alert('Session TimeOut');window.open('"+ Session["Site"].ToString() + "/','_top');", true);
            }
                string Ctrl_List1;
                string Msg_List1;
                string Data_List1;
                ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(btnCancel);                
                ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(btnSave);
                if (!this.IsPostBack)
                {
                    try
                    {
                        //Ctrl_List1 = txtbookno.ID + "~" + txtagent.ID + "~" + txtinvno.ID + "~" + txtunit.ID + "~" + txtpono.ID + "~" + txtstyle.ID + "~" + txtdimension.ID + "~" + txtpieces.ID + "~" + txtweight.ID + "~" + txtcartons.ID + "~" + txtdlvrypint.ID;
                        //Msg_List1 = "Booking Number~Agent~Invoice Number~Units~PO Number~Style / SKU #~Description~Quantity~Weight~Cartons~DeliveryPoint";
                        //Data_List1 = "string~string~string~string~string~string~string~int~int~int~string";
                        //btnSave.Attributes.Add("OnClick", "return IsValid('" + Ctrl_List1 + "','" + Msg_List1 + "','" + Data_List1 + "') && IsDate('dtinvdate~dtdvrydate');");

                        txtPercent.Attributes.Add("onkeypress", "return IntegerCheck(event);");
                       // txtEduPer.Attributes.Add("onkeypress", "return IntegerCheck(event);");
                      //  txtHighEduPer.Attributes.Add("onkeypress", "return IntegerCheck(event);");

                        txtcurper.Attributes.Add("onkeypress", "return IntegerCheck(event);");
                        txtcureducess.Attributes.Add("onkeypress", "return IntegerCheck(event);");
                        txtcurhighereduper.Attributes.Add("onkeypress", "return IntegerCheck(event);");

                        Session["str_sfs"] = "";
                        Session["str_sp"] = "";

                        grdTaxslab.DataSource = new DataTable();
                        grdTaxslab.DataBind();
                        txtcurper.Focus();
                    }
                    catch (Exception ex)
                    {
                        string message = ex.Message.ToString();
                        ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
                    }
                }
            btnCancel.Enabled = true;
            //btnCancel.Text = "Back";
        }

        private void collectdata()
        {
            if ((txtPercent.Text.Trim()) != "")
            {
                proper = Convert.ToDouble(txtPercent.Text);
            }
            else
            {
                proper = 0;
            }
            if ((txtEduPer.Text.Trim()) != "")
            {
                proedcess = Convert.ToDouble(txtEduPer.Text);
            }
            else
            {
                proedcess = 0;
            }
            if ((txtHighEduPer.Text.Trim()) != "")
            {
                prohedcess = Convert.ToDouble(txtHighEduPer.Text);
            }
            else
            {
                prohedcess = 0;
            }
            if ((txtcurper.Text.Trim()) != "")
            {
                curper = Convert.ToDouble(txtcurper.Text);
            }
            else
            {
                curper = 0;
            }
            if ((txtcureducess.Text.Trim()) != "")
            {
                curedcess = Convert.ToDouble(txtcureducess.Text);
            }
            else
            {
                curedcess = 0;
            }
            if ((txtcurhighereduper.Text.Trim()) != "")
            {
                curhedcess = Convert.ToDouble(txtcurhighereduper.Text);
            }
            else
            {
                curhedcess = 0;
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            //int intchgid;
            string chagre;
            if (btnSave.ToolTip == "Update")
            {
                if (grdTaxslab.Rows.Count > 0)
                {
                    Checkdata();
                    collectdata();

                    if (k != 0)
                    {
                        foreach (GridViewRow row in grdTaxslab.Rows)
                        {
                            CheckBox Chk = (CheckBox)row.FindControl("selectt");
                            if (Chk.Checked == true)
                            {
                                //intchgid = int.Parse(row.Cells[6].Text);
                                Label intchgid = (Label)row.Cells[6].FindControl("chargeid");
                                hid_chargeid.Value = intchgid.ToString();
                                chargesobj.UpdateSTbasedonstcode(Double.Parse(txtPercent.Text), Double.Parse(txtEduPer.Text), Double.Parse(txtHighEduPer.Text), int.Parse(intchgid.Text));
                                chagre = chargesobj.GetChargeName(int.Parse(intchgid.Text));
                                //Logobj.InsLogDetail(Login.logempid, 1693, 2, Login.branchid, chagre + "/" + txtPercent.Text)
                                obj_da_Log.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1693, 2, int.Parse(Session["LoginBranchid"].ToString()), chagre + "/" + txtPercent.Text);                               
                                btnCancel.Enabled = true;
                                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Details Updated');", true);
                            }
                        }
                        txtclear();
                    }
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Enter The Valid Service Tax Details');", true);
                    txtclear();
                    txtcurper.Focus();
                    return;
                }
            }
        }
        private void txtclear()
        {
            txtPercent.Text = "";
            txtEduPer.Text = "";
            txtHighEduPer.Text = "";
            txtcureducess.Text = "";
            txtcurhighereduper.Text = "";
            txtcurper.Text = "";
            curper = 0;
            curedcess = 0;
            curhedcess = 0;
            proper = 0;
            prohedcess = 0;
            proedcess = 0;
            grdTaxslab.DataSource = new DataTable();
            grdTaxslab.DataBind();
        }

        private void Checkdata()
        {
            Double high =Convert.ToDouble(txtHighEduPer.Text);
            Double Edu = Convert.ToDouble(txtEduPer.Text);
            if (txtPercent.Text == "")
            {
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Service Tax % cannot be Blank');", true);
                txtPercent.Focus();
                k = 0;
                return;
            }
            else if (int.Parse(txtPercent.Text) <= 0)
            {
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Service Tax % Should be Greater Than 0');", true);
                txtPercent.Focus();
                k = 0;
                return;
            }

            if (high.ToString() == "")
            {
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Higher Education cannot be Blank');", true);
                txtPercent.Focus();
                k = 0;
                return;
            }

            else if (high <= 0)
            {
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Higher Education Should be Greater Than 0');", true);
                txtPercent.Focus();
                k = 0;
                return;
            }

            if (Edu.ToString() == "")
            {
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Education Cess % cannot be Blank');", true);
                txtEduPer.Focus();
                k = 0;
                return;
            }
            else if (Edu <= 0)
            {
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Education Cess Should be Greater Than 0');", true);
                txtEduPer.Focus();
                k = 0;
                return;
            }
        }

        private void getdetails()
        {
            collectdata();
            //chkUpd.Checked = false;
            dtcharges = chargesobj.GetServiceTaxDtls(curper, curedcess, curhedcess);
            //double d;
            //double temp;
            //DataTable dtemp = new DataTable();
            //dtemp.Columns.Add("chargename");
            //dtemp.Columns.Add("currency");
            //dtemp.Columns.Add("percentage");
            //dtemp.Columns.Add("edcess");
            //dtemp.Columns.Add("hedcess");
            //dtemp.Columns.Add("chargeid");
            //DataRow dr = dtemp.NewRow();
            if (dtcharges.Rows.Count > 0)
            {
                 grdTaxslab.DataSource = dtcharges;
                grdTaxslab.DataBind();
               // btnCancel.Text = "Cancel";
                btnCancel.ToolTip = "Cancel";
                btnCancel1.Attributes["class"] = "btn ico-cancel";

            //   dtemp.Rows.Add(dr);
            //    for (int i = 0; dtcharges.Rows.Count - 1 >= i; i++)
            //    {
            //       // dtemp.Rows.Add(dr);
            //        dtemp.Rows[i][0] = dtcharges.Rows[i]["chargename"].ToString();
            //        dtemp.Rows[i][1] = dtcharges.Rows[i]["currency"].ToString();
            //        dtemp.Rows[i][2] = dtcharges.Rows[i]["percentage"].ToString();
            //        d = Convert.ToDouble(dtcharges.Rows[i]["sbcess"].ToString());
            //        dtemp.Rows[i][3] = d.ToString("#0.00");
            //       // grdTaxslab.Rows[i].Cells[3].Text = dtcharges.Rows[i]["edcess"].ToString();
            //        temp = Convert.ToDouble(dtcharges.Rows[i]["kkcess"].ToString());
            //        dtemp.Rows[i][4]= temp.ToString("#0.00");
            //       // grdTaxslab.Rows[i].Cells[4].Text = dtcharges.Rows[i]["hedcess"].ToString();
            //        dtemp.Rows[i][5] = dtcharges.Rows[i]["chargeid"].ToString();
            //    }
            //    grdTaxslab.DataSource = dtcharges;
            //    grdTaxslab.DataBind();
            //    btnCancel.Text = "Cancel";
            }
        }

        private void Checkdata1()
        {
            if (txtcurper.Text == "")
            {
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Current Service Tax % cannot be Blank');", true);
                txtcurper.Focus();
                k = 0;
                return;
            }
            else if (int.Parse(txtcurper.Text) <= 0)
            {
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Current Service Tax % Should be Greater than');", true);
                txtcurper.Focus();
                k = 0;
                return;
            }

            if (txtcurhighereduper.Text == "")
            {
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Current Higher Education cannot be Blank');", true);
                txtcurhighereduper.Focus();
                k = 0;
                return;
            }
            else if (int.Parse(txtcurhighereduper.Text) <= 0)
            {
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Current Higher Education Should be Greater than');", true);
                txtcurhighereduper.Focus();
                k = 0;
                return;
            }

            if (txtcureducess.Text == "")
            {
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Current Education Cess % cannot be Blank');", true);
                txtcureducess.Focus();
                k = 0;
                return;
            }
            else if (int.Parse(txtcureducess.Text) <= 0)
            {
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Current Education Cess % Should be Greater than');", true);
                txtcureducess.Focus();
                k = 0;
                return;
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            if (btnCancel.ToolTip == "Cancel")
            {
                txtclear();
                btnCancel.Enabled = true;
                txtPercent.ReadOnly = false;
              //  btnCancel.Text = "Back";
                btnCancel.ToolTip = "Back";
                btnCancel1.Attributes["class"] = "btn ico-back";
                txtcurper.Focus();
            }
            else 
            {
                this.Response.End();
            }
        }

        protected void txtcurper_TextChanged(object sender, EventArgs e)
        {
            getdetails();
        }

        protected void txtcurhighereduper_TextChanged(object sender, EventArgs e)
        {
            getdetails();
        }

        protected void txtcureducess_TextChanged(object sender, EventArgs e)
        {
            getdetails();
        }

        protected void grdTaxslab_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow && (e.Row.RowState == DataControlRowState.Normal || e.Row.RowState == DataControlRowState.Alternate))
            {
                CheckBox chkBxSelect = (CheckBox)e.Row.Cells[1].FindControl("selectt");
                CheckBox chkBxHeader = (CheckBox)this.grdTaxslab.HeaderRow.FindControl("chkBxHeader");
                chkBxSelect.Attributes["onclick"] = string.Format("javascript:ChildClick(this,'{0}');",chkBxHeader.ClientID);
            }
        }

        protected void grdTaxslab_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lblCharges = (Label)e.Row.FindControl("Charges");
                string tooltip = lblCharges.Text;
                e.Row.Cells[0].Attributes.Add("title", tooltip);
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
            PanelLog1.Visible = true;
            GridViewlog.Visible = true;
            Panel2.Visible = true;
            DataAccess.LogDetails obj_da_Log = new DataAccess.LogDetails();
            DataTable obj_dtlogdetails = new DataTable();

            obj_dtlogdetails = obj_da_Log.InsTempGrpLogdtlsGet(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), 1693, "MSServiceTax", hid_chargeid.Value, hid_chargeid.Value, "");  //"/Rate ID: " +
            if (txtcurper.Text != "")
            {
                JobInput.Text = hid_chargeid.Value;

            }
            else
            {
                JobInput.Text = "";
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