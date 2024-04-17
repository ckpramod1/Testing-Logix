using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace logix.HRM
{
    public partial class ClaimDetail : System.Web.UI.Page
    {
        DataAccess.Masters.MasterEmployee obj_da_Employee = new DataAccess.Masters.MasterEmployee();
        DataAccess.HR.Employee obj_da_HR = new DataAccess.HR.Employee();
        DataAccess.LogDetails obj_da_log = new DataAccess.LogDetails();
        DataTable Dt = new DataTable();
        Boolean blnErr;
        int back;
        protected void Page_Load(object sender, EventArgs e)
        {
            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(btn_cancel);
            try { 
            if (Request.QueryString.ToString().Contains("FormName"))
            {
                string str_Uiid = "";
                str_Uiid = Request.QueryString["UIID"].ToString();
                Utility.Fn_CheckUserRights(str_Uiid, btn_save, btn_view,null);
            }
            if (!IsPostBack)
            {
               
                txt_claim.Text = Utility.fn_ConvertDate(obj_da_log.GetDate().ToShortDateString());
                txt_settled.Text = txt_claim.Text;
                hid_date.Value = txt_claim.Text;
                txt_Empcode.Focus();
                string str_CtrlLists, str_MsgLists, str_DataType;
                str_CtrlLists = "txt_Empcode~ddl_claim~txt_amount";
                str_MsgLists = "EmpCode~Claim Details~Amount";
                str_DataType = "String~DropDown~Double";
                btn_save.Attributes.Add("OnClick", "return IsValid('" + str_CtrlLists + "','" + str_MsgLists + "','" + str_DataType + "') && IsDate('txt_claim~txt_settled','Claimed On Date Should be Lessthan Settled On Date');");
                //btn_cancel.Text = "Cancel";
                btn_cancel.ToolTip = "Cancel";
                btn_cancel1.Attributes["class"] = "btn ico-cancel";
                Grd_Claim.DataSource = new DataTable();
                Grd_Claim.DataBind();
            }
            //txt_Empcode.Attributes.Add("OnKeypress", "return IntegerCheck(event);");
            txt_amount.Attributes.Add("onkeypress", "return validateFloatKeyPress(this,event,'Weights')");
            txtTaxableAmount.Attributes.Add("onkeypress", "return validateFloatKeyPress(this,event,'Weights')");
            txtNonTaxableAmount.Attributes.Add("onkeypress", "return validateFloatKeyPress(this,event,'Weights')");
            }

            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }       
        }

        protected void txt_Empcode_TextChanged(object sender, EventArgs e)
        {
            try
            {
            if (txt_Empcode.Text.TrimEnd().Length > 0)
            {
                ddl_claim.Enabled = true;
                DataTable obj_dt = new DataTable();
                obj_dt = obj_da_Employee.GetEmployeeDetails(txt_Empcode.Text);
                if (obj_dt.Rows.Count > 0)
                {
                    txt_EmpName.Text = obj_dt.Rows[0]["empname"].ToString();
                    obj_dt = obj_da_HR.GetBranchandDivisionempid(obj_da_HR.GetEmpId(txt_Empcode.Text));
                    txt_division.Text = obj_dt.Rows[0]["divisionname"].ToString();
                    txt_branch.Text = obj_dt.Rows[0]["branch"].ToString();

                    Fn_LoadDetail();
                    getChecked();
                    txt_amount.Focus();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "HRM", "alertify.alert('Enter the Correct Employee Code');", true);
                    txt_Empcode.Text="";
                    txt_Empcode.Focus();
                    return;
                }
            }
            //btn_cancel.Text = "Cancel";
            btn_cancel.ToolTip = "Cancel";
            btn_cancel1.Attributes["class"] = "btn ico-cancel";
            }

            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }       
        }
        private void Fn_LoadDetail()
        {
            try { 
            double temp;
            DataTable obj_dt = new DataTable();
            DataTable obj_dtClaim = new DataTable();
            obj_dtClaim.Columns.Add("claimtype");
            obj_dtClaim.Columns.Add("cdate");
            obj_dtClaim.Columns.Add("claimamt");
            obj_dtClaim.Columns.Add("seton");
            obj_dtClaim.Columns.Add("clchk");
            obj_dtClaim.Columns.Add("ctype");
            DataRow dr;
           // Dt = PIObj.GetEmpDetailsforClaim(EmpObj.GetEmpid(TxtEmpCode.Text));
            obj_dt = obj_da_HR.GetEmpDetailsforClaim(obj_da_Employee.GetEmpid(txt_Empcode.Text));
            for (int i = 0; i <= obj_dt.Rows.Count - 1; i++)
            {
              
                dr = obj_dtClaim.NewRow();
                obj_dtClaim.Rows.Add(dr);
                if (obj_dt.Rows[i]["claimtype"].ToString() == "M")
                {
                    dr[0] = "Medical";
                }
                else if (obj_dt.Rows[i]["claimtype"].ToString() == "L")
                {
                    dr[0] = "LTA";
                }
                else if (obj_dt.Rows[i]["claimtype"].ToString() == "T")
                {
                    dr[0] = "Leave Encashment";
                }
                else if (obj_dt.Rows[i]["claimtype"].ToString() == "MC")
                {
                    dr[0] = "MotorCar";
                }
                else if (obj_dt.Rows[i]["claimtype"].ToString() == "A")
                {
                    dr[0] = "Entertainment Allowance";
                }
                else if (obj_dt.Rows[i]["claimtype"].ToString() == "P")
                {
                    dr[0] = "Previous Employer Income";
                }
                else if (obj_dt.Rows[i]["claimtype"].ToString() == "O")
                {
                    dr[0] = "Other Income";
                }
                else
                {
                    dr[0] = "Leave Encashment";
                }

                dr[1] = obj_dt.Rows[i]["cdate"].ToString();
                temp =Convert.ToDouble (obj_dt.Rows[i]["claimamt"].ToString());
                dr[2] = temp.ToString("#,0.00");
                dr[3] = obj_dt.Rows[i]["seton"].ToString();
                dr[4] = obj_dt.Rows[i]["clchk"].ToString();
                dr[5] = obj_dt.Rows[i]["claimtype"].ToString();

            }
            Grd_Claim.DataSource = obj_dtClaim;
            Grd_Claim.DataBind();
            //btn_cancel.Text = "Cancel";
            btn_cancel.ToolTip = "Cancel";
            btn_cancel1.Attributes["class"] = "btn ico-cancel";
            }

            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }       
        }

        protected void Grd_Claim_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
            hid_ctype.Value = Grd_Claim.SelectedDataKey.Values[1].ToString();
            hid_amount.Value = Grd_Claim.SelectedRow.Cells[2].Text.ToString().Replace(",", "");
            if (hid_confirm.Value.ToString() == "N")
            {
                //btn_save.Text = "Update";
                ddl_claim.Enabled = false;
                ddl_claim.SelectedIndex = ddl_claim.Items.IndexOf(ddl_claim.Items.FindByText(Grd_Claim.SelectedRow.Cells[0].Text));
                txt_claim.Text = Grd_Claim.SelectedRow.Cells[1].Text;
                txt_amount.Text = hid_amount.Value.ToString();
                txt_settled.Text = Grd_Claim.SelectedRow.Cells[3].Text;
                bool Check = Grd_Claim.SelectedDataKey.Values[0].ToString() == "0" ? true : false;
                Chk_IT.Checked = Check;
                Chk_IT_CheckedChanged(sender, e);

            }
            else if (hid_confirm.Value.ToString() == "Y")
            {
                if (hid_ctype.Value == "M")
                {
                    hid_ctypes.Value = "M";
                }
                else if (hid_ctype.Value == "L")
                {
                    hid_ctypes.Value = "LT";
                }
                else if (hid_ctype.Value == "MC")
                {
                    hid_ctypes.Value = "MC";
                }
                else if (hid_ctype.Value == "A")
                {
                    hid_ctypes.Value = "AE";
                }
                else if (hid_ctype.Value == "P")
                {
                    hid_ctypes.Value = "PE";
                }
                else if (hid_ctype.Value == "O")
                {
                    hid_ctypes.Value = "OT";
                }
                else if (hid_ctype.Value == "T")
                {
                    hid_ctypes.Value = "T";
                }
                else 
                {
                   // hid_ctypes.Value = "E";
                    hid_ctypes.Value = "LC";
                }
                string claim = Grd_Claim.SelectedRow.Cells[1].Text.ToString();
                string setteled = Grd_Claim.SelectedRow.Cells[3].Text.ToString();
                
                int int_Empid = obj_da_Employee.GetEmpid(txt_Empcode.Text);
                obj_da_HR.DelEmpClaim(int_Empid, char.Parse(hid_ctype.Value.ToString()), double.Parse(Grd_Claim.SelectedRow.Cells[2].Text.ToString()), Convert.ToDateTime(Utility.fn_ConvertDate(claim)), Convert.ToDateTime(Utility.fn_ConvertDate(setteled)));
                obj_da_HR.Del4EmpClaimDtls(int_Empid, hid_ctypes.Value.ToString(), double.Parse(Grd_Claim.SelectedRow.Cells[2].Text.ToString()), Convert.ToDateTime(Utility.fn_ConvertDate(claim)), Convert.ToDateTime(Utility.fn_ConvertDate(setteled)));
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "HRM", "alertify.alert('Details Deleted');", true);
                Fn_LoadDetail();
            }
            btn_save.Enabled = false;
            //btn_cancel.Text = "Cancel";
            btn_cancel.ToolTip = "Cancel";
            btn_cancel1.Attributes["class"] = "btn ico-cancel";
            }

            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }       
        }

        protected void btn_save_Click(object sender, EventArgs e)
        {
            try { 
            if(txt_Empcode.Text!="")
            {
                int int_Empid = obj_da_Employee.GetEmpid(txt_Empcode.Text);
                checkdata();
                if (blnErr == true)
                {
                    return;
                }
                int int_Chk = Chk_IT.Checked == true ? 0 : 1;
                alreadyexist();
                if (blnErr == true)
                {
                    return;
                }
                char Char_IT = Chk_IT.Checked == true ? 'Y' : 'N';
                DateTime dt_Claim, dt_Settled;
                dt_Claim = DateTime.Parse(Utility.fn_ConvertDate(txt_claim.Text));
                dt_Settled = DateTime.Parse(Utility.fn_ConvertDate(txt_settled.Text));
                if (btn_save.ToolTip == "Save")
                {
                    obj_da_HR.InsEmpClaim(int_Empid, char.Parse(ddl_claim.SelectedItem.Value.Substring(0,1)), double.Parse(txt_amount.Text), dt_Claim, int_Chk, dt_Settled);
                    obj_da_HR.InsHRClaimDtls(int_Empid, ddl_claim.SelectedItem.Value.ToString(), dt_Settled, double.Parse(txt_amount.Text), Char_IT, dt_Claim, double.Parse(txtTaxableAmount.Text),double.Parse( txtNonTaxableAmount.Text));
                    obj_da_log.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 455, 1, Convert.ToInt32(Session["LoginBranchid"]), "/ S");
                    ScriptManager.RegisterStartupScript(btn_save, typeof(ButtonColumn), "HRM", "alertify.alert('Details Saved');", true);
                    Fn_LoadDetail();
                    Fn_Clear();
                }
                else if (btn_save.ToolTip == "Update")
                {
                    obj_da_HR.UpdEmpClaim(int_Empid, char.Parse(ddl_claim.SelectedItem.Value), double.Parse(txt_amount.Text), dt_Claim, double.Parse(hid_amount.Value.ToString()), int_Chk, dt_Settled);
                    obj_da_HR.UpdHRClaimDtls(int_Empid, ddl_claim.SelectedItem.Value.ToString(), double.Parse(txt_amount.Text), dt_Claim, double.Parse(hid_amount.Value.ToString()), dt_Settled, Char_IT, double.Parse(txtTaxableAmount.Text), double.Parse(txtNonTaxableAmount.Text));
                    obj_da_log.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 455, 2, Convert.ToInt32(Session["LoginBranchid"]), "/ U");
                    ScriptManager.RegisterStartupScript(btn_save, typeof(ButtonColumn), "HRM", "alertify.alert('Details Updated');", true);
                    Fn_LoadDetail();
                    Fn_Clear();
                }
            }

            //btn_cancel.Text = "Cancel";
            btn_cancel.ToolTip = "Cancel";
            btn_cancel1.Attributes["class"] = "btn ico-cancel";
            }

            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }       
        }

        protected  void checkdata()
        {
            if (ddl_claim.SelectedItem.Text.Trim() == "")
            {
                ScriptManager.RegisterStartupScript(btn_save, typeof(ButtonColumn), "HRM", "alertify.alert('Claim Details Can't be blank');", true);
                blnErr = true;
                ddl_claim.Focus();
            }
            if(txt_amount.Text=="")
            {
                ScriptManager.RegisterStartupScript(btn_save, typeof(ButtonColumn), "HRM", "alertify.alert('Amount Can't be blank');", true);
                blnErr = true;
                txt_claim.Focus();
            }

            if (ddl_claim.SelectedItem.Text == "")
            {
                ScriptManager.RegisterStartupScript(btn_save, typeof(ButtonColumn), "HRM", "alertify.alert('Claim Type Can't be blank');", true);
                blnErr = true;
                ddl_claim.Focus();
            }

            if (ddl_claim.SelectedItem.Text != "")
            {
                if(txtTaxableAmount.Text=="")
                {
                    if (txtTaxableAmount.Text == "LTA" && Chk_IT.Checked==false)
                    {
                         if(txtTaxableAmount.Text=="")
                         {
                             ScriptManager.RegisterStartupScript(btn_save, typeof(ButtonColumn), "HRM", "alertify.alert('Taxable Can't be blank');", true);
                             blnErr = true;
                             txtTaxableAmount.Focus();
                             return;
                         }
                    }
                    else
                    {
                        txtTaxableAmount.Text = "0";
                    }
                }
            }

            if (ddl_claim.SelectedItem.Text != "")
            {
                if (txtNonTaxableAmount.Text == "")
                {
                    if (txtNonTaxableAmount.Text == "LTA" && Chk_IT.Checked == false)
                    {
                        if (txtNonTaxableAmount.Text == "")
                        {
                            ScriptManager.RegisterStartupScript(btn_save, typeof(ButtonColumn), "HRM", "alertify.alert(' Non Taxable Can't be blank');", true);
                            blnErr = true;
                            txtNonTaxableAmount.Focus();
                            return; ;
                        }
                    }
                    else
                    {
                        txtTaxableAmount.Text = "0";
                    }
                }
            }

            if (Chk_IT.Checked == false)
            {
                if (ddl_claim.SelectedItem.Text == "LTA" || ddl_claim.SelectedItem.Text == "Medical" || ddl_claim.SelectedItem.Text == "Leave Encashment")
                {
                    txtNonTaxableAmount.Enabled = false;
                    txtTaxableAmount.Enabled = false;
                    txtTaxableAmount.Text = "0";
                    txtNonTaxableAmount.Text = txt_amount.Text;
                }
            }

            if (Convert.ToDateTime(Utility.fn_ConvertDate(txt_claim.Text)) > Convert.ToDateTime(Utility.fn_ConvertDate(txt_settled.Text)))
            {
                ScriptManager.RegisterStartupScript(btn_save, typeof(ButtonColumn), "HRM", "alertify.alert(' Claimed on Should Not Greater Setteledon');", true);
                blnErr = true;
                txt_claim.Focus();
                return;
            }

            if (txt_amount.Text == "" || txt_amount.Text == "0")
            {
                ScriptManager.RegisterStartupScript(btn_save, typeof(ButtonColumn), "HRM", "alertify.alert(' Invalid Amount');", true);
                blnErr = true;
                txt_amount.Focus();
                return;
            }

        }

        protected void alreadyexist()
        {
            try
            {
            Dt = obj_da_HR.GetEmpDetailsforClaim(obj_da_Employee.GetEmpid(txt_Empcode.Text));
            if (Dt.Rows.Count > 0)
            {
                for (int i = 0; i <= Dt.Rows.Count - 1; i++)
                {

                    string strdston, strclon;
                    string strclim = "";
                    string strctype = "";
                    strdston = txt_settled.Text;
                    strclon = txt_claim.Text;
                    
                    strctype = Dt.Rows[i]["claimtype"].ToString();

                    if (strctype == "M")
                    {
                        strclim = "Medical";
                    }

                    else if (strctype == "L")
                    {
                        strclim = "LTA";

                    }
                    else if (strctype == "MC")
                    {
                        strclim = "MotorCar";

                    }
                    else if (strctype == "AE")
                    {
                        strclim = "Entertainment Allowance";

                    }
                    else if (strctype == "OT")
                    {
                        strclim = "Other Income";

                    }
                    else if (strctype == "PE")
                    {
                        strclim = "Previous Employer Income";

                    }
                    else if (strctype == "T")
                    {
                        strclim = "Leave Encashment";
                    }
                    if (strdston == Dt.Rows[i]["seton"].ToString() && ddl_claim.SelectedItem.Text == strclim)
                    {
                        if (strclon == Dt.Rows[i]["cdate"].ToString() && ddl_claim.SelectedItem.Text == strclim)
                        {
                            ScriptManager.RegisterStartupScript(btn_save, typeof(ButtonColumn), "HRM", "alertify.alert('Already Exist');", true);
                            blnErr = true;

                            return;
                            
                        }
                    }
                }
            }
            }

            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }       
        }
        private void Fn_Clear()
        {
            txtTaxableAmount.Text = "";
            //txt_amount.Text = "";
            txtNonTaxableAmount.Text = "";
            txt_amount.Text = "";
            Chk_IT.Checked = false;
            ddl_claim.SelectedIndex = 0;
            btn_cancel.Visible = true;
            btn_save.Enabled = true;
            //btn_save.Text = "Save";
            btn_save.ToolTip = "Save";
            btn_save1.Attributes["class"] = "btn ico-save";
            txt_claim.Text = hid_date.Value.ToString();
            txt_settled.Text = hid_date.Value.ToString();
            ddl_claim.Enabled = true;
        }

        protected void btn_cancel_Click(object sender, EventArgs e)
        {
          if(btn_cancel.ToolTip=="Cancel")
          {
              txt_Empcode.Focus();
              txt_Empcode.Text = "";
              txt_EmpName.Text = "";
              txt_division.Text = "";
              txt_branch.Text = "";
              txtNonTaxableAmount.Text = "";
              txtTaxableAmount.Text = "";
              Grd_Claim.DataSource = new DataTable();
              Grd_Claim.DataBind();
              Fn_Clear();
              //btn_cancel.Text = "Back";
              btn_cancel.ToolTip = "Back";
              btn_cancel1.Attributes["class"] = "btn ico-back";
          }
          else
          {
              this.Response.End();
          }
        }

        protected void Chk_IT_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                getChecked();
                chkvliddtls();
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        protected void getChecked()
        {
            if (Chk_IT.Checked == true)
            {
                if (ddl_claim.SelectedItem.Text == "LTA" || ddl_claim.SelectedItem.Text == "Medical" || ddl_claim.SelectedItem.Text == "Leave Encashment" || ddl_claim.SelectedItem.Text == "Entertainment Allowance")
                {
                    txtNonTaxableAmount.Enabled = true;
                    txtTaxableAmount.Enabled = true;
                    txtTaxableAmount.Text = txt_amount.Text;
                    txtNonTaxableAmount.Text = " 0";
                }
            }
            else if (Chk_IT.Checked == false)
            {
                if (ddl_claim.SelectedItem.Text == "LTA" || ddl_claim.SelectedItem.Text == "Medical" || ddl_claim.SelectedItem.Text == "Leave Encashment" || ddl_claim.SelectedItem.Text == "Entertainment Allowance")
                {
                    txtNonTaxableAmount.Enabled = false;
                    txtTaxableAmount.Enabled = false;
                    txtTaxableAmount.Text = txt_amount.Text;
                    txtNonTaxableAmount.Text = " 0";
                }
            }
        }

        protected void chkvliddtls()
        {
            int i;
            Dt = obj_da_HR.GetEmpDetailsforClaim(obj_da_Employee.GetEmpid(txt_Empcode.Text));

            if (Dt.Rows.Count > 0)
            {

            }
        }

        protected void ddl_claim_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                getChecked();
                txtNonTaxableAmount.Text = "";
                txtTaxableAmount.Text = "";
            }

            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }       
        }

        protected void txtNonTaxableAmount_TextChanged(object sender, EventArgs e)
        {
            //     If txtClaimAmnt.Text <> "" Then ' And txtnonablamt.Text <> "" Then
            //    If Val(txtClaimAmnt.Text) <> 0 Then
            //        txttablamt.Text = Val(txtClaimAmnt.Text) - Val(txtnonablamt.Text)
            //    Else
            //        If cmdclaimdtls.Text = "LTA" Then
            //            MsgBox("Enter Valid Amount in " & Label5.Text, MsgBoxStyle.Information, "logix")
            //            txtnonablamt.Text = 0
            //            txttablamt.Text = 0
            //        End If
            //    End If
            //End If

            if (txt_amount.Text != "")
            {
                if (txt_amount.Text != "0")
                {
                    double amt1 = Convert.ToDouble(txt_amount.Text);
                    double amt2 = Convert.ToDouble(txtTaxableAmount.Text);
                    double amt3 = amt1 + amt2;
                    txtNonTaxableAmount.Text = amt3.ToString("#0.00");
                }
                else
                {
                    if (ddl_claim.SelectedItem.Text == "LTA")
                    {
                        ScriptManager.RegisterStartupScript(btn_save, typeof(ButtonColumn), "HRM", "alertify.alert('Enter Valid Amount in');", true);
                        txtNonTaxableAmount.Text = "";
                        txtTaxableAmount.Text = "";
                        return; 
                    }
                }
            }
        }

        protected void txtTaxableAmount_TextChanged(object sender, EventArgs e)
        {
            if (txt_amount.Text != "")
            {
                if (txt_amount.Text != "0")
                {
                    double amt1 = Convert.ToDouble(txt_amount.Text);
                    double amt2 = Convert.ToDouble(txtTaxableAmount.Text);
                    double amt3 = amt1 + amt2;
                    txtNonTaxableAmount.Text = amt3.ToString("#0.00");
                }
                else
                {
                    if (ddl_claim.SelectedItem.Text == "LTA")
                    {
                        ScriptManager.RegisterStartupScript(btn_save, typeof(ButtonColumn), "HRM", "alertify.alert('Enter Valid Amount in');", true);
                        txtNonTaxableAmount.Text = "";
                        txtTaxableAmount.Text = "";
                        return;
                    }
                }
            }
        }

        protected void Grd_Claim_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        protected void btn_view_Click(object sender, EventArgs e)
        {
            try { 
            int eid;
             eid = obj_da_HR.GetEmpId(txt_Empcode.Text);
            string Str_sp = "", Str_sf = "", Str_RptName = "", Str_Script = "";
            Str_RptName = "Payroll//" + "ClaimDetails.rpt";
            if (txt_Empcode.Text.Trim() != "" && eid!=0)
            {
                Str_sf = "{MasterEmployee.rol}=0 and {MasterEmployee.employeeid}=" +eid ;
                //" and {EmpLeaveDetails.elclaimed}<>0 and not isnull({EmpLeaveDetails.elclaimed})";
            }
            //else
            //{
            //    Str_sf = "{MasterEmployee.rol}=0 and {EmpLeaveDetails.elclaimed}<>0 and not isnull({EmpLeaveDetails.elclaimed})";
            //}
            Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_sf + "&Parameter=" + Str_sp + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
            obj_da_log.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 455, 3, Convert.ToInt32(Session["LoginBranchid"]), "View");
            ScriptManager.RegisterStartupScript(btn_view, typeof(Button), "HRM", Str_Script, true);
            Session["str_sfs"] = Str_sf;
            Session["str_sp"] = Str_sp;
            }

            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }       
        }

        protected void Grd_Claim_RowDataBound(object sender, GridViewRowEventArgs e)
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
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(Grd_Claim, "Select$" + e.Row.RowIndex);
                e.Row.Attributes["style"] = "cursor:pointer";
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
            DataAccess.LogDetails Logobj = new DataAccess.LogDetails();

            obj_dtlogdetails = Logobj.InsTempGrpLogdtlsGet(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), 455, "Job", "", "", Session["StrTranType"].ToString());

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