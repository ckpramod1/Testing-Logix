using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace logix.HRM
{
    public partial class InvestmentPlanProf : System.Web.UI.Page
    {
        DataAccess.LogDetails obj_da_Log = new DataAccess.LogDetails();
        DataAccess.PAYROLL.RentDetailss obj_da_Rent = new DataAccess.PAYROLL.RentDetailss();
        DataAccess.Payroll.Details obj_detai = new DataAccess.Payroll.Details();
        public static double Basic = 0, RentPaid = 0, RP = 0, ARP = 0;
        int min;
        protected void Page_Load(object sender, EventArgs e)
        {

            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(btn_cancel);
            if (Request.QueryString.ToString().Contains("FormName"))
            {
                string str_Uiid = "";
                str_Uiid = Request.QueryString["UIID"].ToString();
                Utility.Fn_CheckUserRights(str_Uiid, btn_Save, btn_View,null);
            }
            if (!IsPostBack)
            {

                btn_Save.Attributes.Add("OnClick", "return IsDate('txt_ReceivedOn');");
                txt_Amount.Attributes.Add("OnKeyUp", "return IsDoubleCheck('txt_Amount');");
                txt_ReceivedAnmt.Attributes.Add("OnKeyUp", "return IsDoubleCheck('txt_ReceivedAnmt');");
                txt_HouseProofReceived.Attributes.Add("OnKeyUp", "return IsDoubleCheck('txt_HouseProofReceived');");
                txt_IncomeProofReceived.Attributes.Add("OnKeyUp", "return IsDoubleCheck('txt_IncomeProofReceived');");
                txt_MedicalProofReceived.Attributes.Add("OnKeyUp", "return IsDoubleCheck('txt_MedicalProofReceived');");
                txt_ReceivedOn.Text = Utility.fn_ConvertDate(obj_da_Log.GetDate().ToShortDateString());
                Fn_LoadDYear();
                Fn_LoadDivision();
                //btn_cancel.Text = "Cancel";
                btn_cancel.ToolTip = "Cancel";
                btn_cancel1.Attributes["class"] = "btn ico-cancel";
                Grd.DataSource = new DataTable();
                Grd.DataBind();
                Session["InvestmentPlanProfReceived"] = lbl_Header.Text;
                Session["Packages"] = lbl_Header.Text;
                txt_Empcode.Focus();
            }

            if (Session["empcode"]!=null)
            {
                txt_Empcode.Text = Session["empcode"].ToString();
                txt_Empcode_TextChanged(sender, e);
                Session["empcode"] = null;
            }
        }
        private void Fn_LoadDYear()
        {
            DateTime Dt_Date = obj_da_Log.GetDate();
            ddl_Year.Items.Clear();
            for (int i = Dt_Date.AddYears(-1).Year; i <= Dt_Date.Year; i++)
            {
                ddl_Year.Items.Add(new ListItem(i.ToString() + "-" + (i + 1).ToString(), i.ToString()));
            }
            if (Dt_Date.Month > 4)
            {
                ddl_Year.SelectedIndex = ddl_Year.Items.IndexOf(ddl_Year.Items.FindByValue(Dt_Date.Year.ToString()));
            }
            else
            {
                ddl_Year.SelectedIndex = ddl_Year.Items.IndexOf(ddl_Year.Items.FindByValue(Dt_Date.AddYears(-1).Year.ToString()));
            }
        }
        public void Fn_LoadDivision()
        {
            ddl_company.Items.Clear();
            ddl_company.Items.Add("");
            DataAccess.HR.Employee obj_da_HrEmp = new DataAccess.HR.Employee();
            DataTable obj_dt = new DataTable();
            obj_dt = obj_da_HrEmp.GetDivision();
            ddl_company.DataSource = obj_dt;
            ddl_company.DataTextField = "divisionname";
            ddl_company.DataValueField = "divisionid";
            ddl_company.DataBind();
        }
        private void Fn_GetDetail()
        {
            DataTable obj_dt = new DataTable();
            DataAccess.HR.Employee obj_da_Employee = new DataAccess.HR.Employee();
            DataAccess.Payroll.Details obj_da_detail = new DataAccess.Payroll.Details();

            int int_Empid = obj_da_Employee.GetEmpId(txt_Empcode.Text);
            hid_Empid.Value = int_Empid.ToString();
            obj_dt = obj_da_detail.GetEmpDetails(int_Empid);
            if (obj_dt.Rows.Count > 0)
            {
                txt_Name.Text = obj_dt.Rows[0]["empname"].ToString();
             //  ddl_company.SelectedIndex = ddl_company.Items.IndexOf(ddl_company.Items.FindByText(obj_dt.Rows[0]["divisionname"].ToString().TrimEnd()));
                ddl_company.Items.Add(obj_dt.Rows[0]["divisionname"].ToString());
                ddl_company.Text = obj_dt.Rows[0]["divisionname"].ToString();
                txt_Dept.Text = obj_dt.Rows[0]["deptname"].ToString();
                txt_Desg.Text = obj_dt.Rows[0]["designame"].ToString();
                txt_Grade.Text = obj_dt.Rows[0]["grade"].ToString();
                txt_DOJ.Text = Utility.fn_ConvertDate(obj_dt.Rows[0]["doj"].ToString());

                var Result = obj_dt.AsEnumerable().Where(row => row.Field<Int16>("branch") == int.Parse("11315") ||
                    row.Field<Int16>("branch") == int.Parse("11288") ||
                    row.Field<Int16>("branch") == int.Parse("11312") ||
                    row.Field<Int16>("branch") == int.Parse("11289") ||
                    row.Field<Int16>("branch") == int.Parse("13906")).ToList();
                if (Result.Count > 0)
                {
                    hid_Amount.Value = "50";
                }
                else
                {
                    hid_Amount.Value = "40";
                }
                Fn_GetAmountDetail();
                Fn_GetIncomeDetail();
                Fn_FillGrd();
                Fn_GetMedicalDetail("M");
                //btn_Save.Text = "Update";
                btn_Save.ToolTip = "Update";
                btn_save1.Attributes["class"] = "btn btn-update1";
                txt_Medical.Text = "15000.00";
            }
            else
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "HRM", "alertify.alert('Enter The Correct EmployeeCode');", true);
                txt_Empcode.Text = "";
                txt_Empcode.Focus();
            }
            //btn_cancel.Text = "Cancel";
            btn_cancel.ToolTip = "Cancel";
            btn_cancel1.Attributes["class"] = "btn ico-cancel";
        }
        private void Fn_GetAmountDetail()
        {
            if (txt_Empcode.Text.TrimEnd().Length > 0 && ddl_Year.SelectedItem.Text != "")
            {
                DataAccess.PayrollProcess obj_da_PayRoll = new DataAccess.PayrollProcess();
                DataAccess.PAYROLL.RentDetailss obj_da_Rent = new DataAccess.PAYROLL.RentDetailss();
                DataTable obj_dt = new DataTable();
                DateTime dt_date = DateTime.Parse("11/1/" + ddl_Year.SelectedValue.ToString());
                if (Session["StrTranType"].ToString() == "HR")
                {
                    obj_dt = obj_da_PayRoll.GetEmpSalaryDetails(int.Parse(hid_Empid.Value.ToString()), dt_date);
                }
                else
                {
                    obj_dt = obj_da_PayRoll.GetEmpSalaryDetails(int.Parse(Session["LoginEmpId"].ToString()), dt_date);
                }
                if (obj_dt.Rows.Count > 0)
                {
                    double HRA = 0;
                    Basic = double.Parse(obj_dt.Rows[0]["basic"].ToString());
                    HRA = double.Parse(obj_dt.Rows[0]["hra"].ToString()) * 12;

                    txt_HRA.Text = string.Format("{0:0.00}", HRA);
                    txt_Basic50.Text = string.Format("{0:0.00}", (((Basic * int.Parse(hid_Amount.Value.ToString())) / 100) * 12));
                    if (Session["StrTranType"].ToString() == "HR")
                    {
                        obj_dt = obj_da_Rent.HRGetRentDetails(int.Parse(hid_Empid.Value.ToString()), int.Parse(ddl_Year.SelectedValue.ToString()));
                    }
                    else
                    {
                        obj_dt = obj_da_Rent.HRGetRentDetails(int.Parse(Session["LoginEmpId"].ToString()), int.Parse(ddl_Year.SelectedValue.ToString()));
                    }
                    if (obj_dt.Rows.Count > 0)
                    {
                        RP = double.Parse(obj_dt.Rows[0]["rp"].ToString());
                        ARP = double.Parse(obj_dt.Rows[0]["arp"].ToString());

                        txt_ActualRent.Text = string.Format("{0:0.00}", obj_dt.Rows[0]["rp"]);
                        txt_HRA.Text = string.Format("{0:0.00}", obj_dt.Rows[0]["rr"]);
                        txt_RentExp.Text = string.Format("{0:0.00}", obj_dt.Rows[0]["taxrebate"]);
                        if (obj_dt.Rows[0]["rb"].ToString().TrimEnd().Length > 0)
                        {
                            txt_RentPaid.Text = string.Format("{0:0.00}", obj_dt.Rows[0]["rb"]);
                        }
                        if (obj_dt.Rows[0]["arp"].ToString().TrimEnd().Length > 0)
                        {
                            txt_HouseProofReceived.Text = string.Format("{0:0.00}", obj_dt.Rows[0]["arp"]);
                        }
                    }
                    else
                    {
                        txt_ActualRent.Text = "0";
                        txt_HRA.Text = "0";
                    }
                }
                else
                {
                    txt_HRA.Text = "";
                    txt_Basic50.Text = "";
                    txt_ActualRent.Text = "";
                    txt_HRA.Text = "";
                }
            }
            //btn_cancel.Text = "Cancel";
            btn_cancel.ToolTip = "Cancel";
            btn_cancel1.Attributes["class"] = "btn ico-cancel";
        }
        private void Fn_GetIncomeDetail()
        {
            DataAccess.PAYROLL.RentDetailss obj_da_Rent = new DataAccess.PAYROLL.RentDetailss();
            DataTable obj_dt = new DataTable();
            obj_dt = obj_da_Rent.GetHouseRent(int.Parse(hid_Empid.Value.ToString()), int.Parse(ddl_Year.SelectedValue.ToString()));
            if (obj_dt.Rows.Count > 0)
            {
                txt_IncomeHouseRent.Text = DBNull.Value.Equals(obj_dt.Rows[0]["income"]) ? "0" : string.Format("{0:0.00}", obj_dt.Rows[0]["income"]);

                txt_IncomeProofReceived.Text = DBNull.Value.Equals(obj_dt.Rows[0]["amount"]) ? "0" : string.Format("{0:0.00}", obj_dt.Rows[0]["amount"]);
            }
            //btn_cancel.Text = "Cancel";
            btn_cancel.ToolTip = "Cancel";
            btn_cancel1.Attributes["class"] = "btn ico-cancel";
        }
        private void Fn_FillGrd()
        {
            if (ddl_Year.SelectedItem.Text != "" && txt_Empcode.Text.TrimEnd().Length > 0)
            {
                DataAccess.Payroll.Details obj_da_detail = new DataAccess.Payroll.Details();
                DataTable obj_dt = new DataTable();
                obj_dt = obj_da_detail.SelInvestPlan(int.Parse(hid_Empid.Value.ToString()), int.Parse(ddl_Year.SelectedValue.ToString()));
                foreach (DataRow dr in obj_dt.Rows)
                {
                    if (dr["cancel"].ToString() == "yes")
                    {
                        dr["proofreceivedon"] = obj_da_Log.GetDate();
                    }
                }
                Grd.DataSource = obj_dt;
                Grd.DataBind();
                string str_dt = string.Format("{0:dd/MM/yyyy}", obj_da_Log.GetDate());
                for (int i = 0; i <= Grd.Rows.Count - 1; i++)
                {
                    if (Grd.DataKeys[i].Values[1].ToString() == "yes")
                    {
                        CheckBox Chk = (CheckBox)Grd.Rows[i].FindControl("Chk_Cancel");
                        Chk.Checked = true;
                        Grd.Rows[i].Cells[5].Text = str_dt;
                    }
                }



            }
            //btn_cancel.Text = "Cancel";
            btn_cancel.ToolTip = "Cancel";
            btn_cancel1.Attributes["class"] = "btn ico-cancel";
        }

        protected void txt_Empcode_TextChanged(object sender, EventArgs e)
        {
            if (txt_Empcode.Text.TrimEnd().Length > 0)
            {
                Fn_GetDetail();
            }
        }
        public void Fn_RentDetail(string Str_Type = "")
        {
            double Amount = 0;
            if (Str_Type == "A")
            {
                Amount = double.Parse(txt_ActualRent.Text) - (((Basic / 100) * 10) * 12);
            }
            else
            {
                Amount = double.Parse(txt_HouseProofReceived.Text) - (((Basic / 100) * 10) * 12);
            }
            if (Amount > 0)
            {
                txt_RentPaid.Text = string.Format("{0:0.00}", Amount);
            }
            else
            {
                txt_RentPaid.Text = "0";
            }

            RentPaid = double.Parse(txt_HouseProofReceived.Text);
        }
        private void Fn_GetMedicalDetail(string Str_Type = "")
        {
            DataAccess.Payroll.Details obj_da_Detail = new DataAccess.Payroll.Details();
            DataTable obj_dt = new DataTable();
            if (Str_Type == "M")
            {
                obj_dt = obj_da_Detail.UpdInsHrMedAmtRecvd(int.Parse(hid_Empid.Value.ToString()), int.Parse(ddl_Year.SelectedValue.ToString()), 0, 0);
                if (obj_dt.Rows.Count > 0)
                {
                    txt_MedicalProofReceived.Text = string.Format("{0:0.00}", obj_dt.Rows[0]["amount"]);
                }
            }
            else
            {
                obj_dt = obj_da_Detail.UpdInsHrMedAmtRecvd(int.Parse(hid_Empid.Value.ToString()), int.Parse(ddl_Year.SelectedValue.ToString()), double.Parse(txt_MedicalProofReceived.Text), double.Parse(txt_Medical.Text));
                string Str_Msg = lbl_Medical.Text + "-" + txt_MedicalProofReceived.ToolTip;
                if (obj_dt.Rows.Count > 0)
                {
                    txt_MedicalProofReceived.Text = string.Format("{0:0.00}", obj_dt.Rows[0]["amount"]);
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "HRM", "alertify.alert('" + Str_Msg + "Updated');", true);
                    obj_da_Log.InsLogDetail(int.Parse(Session["LoginEmpId"].ToString()), 808, 2, int.Parse(Session["LoginBranchid"].ToString()), lbl_Medical.Text + "-" + txt_MedicalProofReceived.Text + "/U");
                }
                else
                {
                    txt_MedicalProofReceived.Text = "";
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "HRM", "alertify.alert('" + Str_Msg + "inserted');", true);
                    obj_da_Log.InsLogDetail(int.Parse(Session["LoginEmpId"].ToString()), 808, 2, int.Parse(Session["LoginBranchid"].ToString()), lbl_Medical.Text + "-" + txt_MedicalProofReceived.Text + "/U");
                }
            }
            //btn_cancel.Text = "Cancel";
            btn_cancel.ToolTip = "Cancel";
            btn_cancel1.Attributes["class"] = "btn ico-cancel";
        }

        private void Fn_Clear()
        {
            txt_ActualRent.Text = "";
            txt_Basic50.Text = "";
            txt_Dept.Text = "";
            txt_Desg.Text = "";
            txt_Detail.Text = "";
            txt_DOJ.Text = "";
            txt_Empcode.Text = "";
            txt_Grade.Text = "";
            txt_HRA.Text = "";
            txt_Name.Text = "";
            txt_RentExp.Text = "";
            txt_RentPaid.Text = "";
            txt_HouseProofReceived.Text = "";
            txt_IncomeHouseRent.Text = ""; txt_IncomeProofReceived.Text = "";
            txt_Medical.Text = "";
            txt_MedicalProofReceived.Text = "";
            Grd.DataSource = new DataTable();
            Grd.DataBind();
            ddl_Year.SelectedIndex = 0;
            ddl_company.SelectedIndex = 0;
        }

        private void Fn_SaveClear()
        {
            txt_Section.Text = "";
            txt_ReceivedAnmt.Text = "";
            txt_Detail.Text = "";
            txt_PlanDetail.Text = "";
            txt_Amount.Text = "";
            //btn_Save.Text = "Save";
            btn_Save.ToolTip = "Save";
            btn_save1.Attributes["class"] = "btn ico-save";
            txt_ReceivedOn.Text = Utility.fn_ConvertDate(obj_da_Log.GetDate().ToShortDateString());
        }
        protected void Grd_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Grd.SelectedRow.Cells[2].Text.TrimEnd() != "PF")
            {
                txt_Section.Text = Grd.SelectedRow.Cells[0].Text.TrimEnd();
                txt_Detail.Text = Grd.SelectedRow.Cells[1].Text.TrimEnd();
                txt_PlanDetail.Text = Grd.SelectedRow.Cells[2].Text.TrimEnd();
                hid_Secid.Value = Grd.SelectedDataKey.Values[0].ToString();
                hid_Cancel.Value = Grd.SelectedDataKey.Values[1].ToString();
                txt_Amount.Text = Grd.SelectedRow.Cells[3].Text.ToString().Replace(",", "");
                txt_ReceivedOn.Text = Grd.SelectedRow.Cells[5].Text.ToString();
                txt_ReceivedAnmt.Text = Grd.SelectedRow.Cells[6].Text.ToString().Replace(",", "");
                //btn_Save.Text = "Update";
                btn_Save.ToolTip = "Update";
                btn_save1.Attributes["class"] = "btn btn-update1";

                CheckBox Chk = (CheckBox)Grd.SelectedRow.FindControl("Chk_Cancel");
                if (Chk.Checked == true)
                {
                    hid_Cancel.Value = "yes";
                }
                else
                {
                    hid_Cancel.Value = "No";
                }

            }
        }

        protected void btn_cancel_Click(object sender, EventArgs e)
        {
           
            if( btn_cancel.ToolTip == "Cancel")
            {
                //btn_cancel.Text = "Back";
                btn_cancel.ToolTip = "Back";
                btn_cancel1.Attributes["class"] = "btn ico-back";
                Fn_Clear();
            }
            else
            {
                this.Response.End();
            }
           
        }

        protected void btn_Save_Click(object sender, EventArgs e)
        {
            if (btn_Save.ToolTip == "Update")
            {
                if (hid_Secid.Value.ToString() == "")
                {
                    hid_Secid.Value = "0";
                }
                if (txt_Amount.Text == "")
                {
                    txt_Amount.Text = "0";
                }
                if (txt_PlanDetail.Text == "")
                {
                    txt_PlanDetail.Text = "0";
                }
                if (txt_ReceivedAnmt.Text.TrimEnd().Length != 0)
                {
                    DataAccess.Payroll.Details obj_da_Detail = new DataAccess.Payroll.Details();
                    int int_Empid = int.Parse(hid_Empid.Value.ToString());
                    int int_Year = int.Parse(ddl_Year.SelectedValue.ToString());
                    int int_Secid = int.Parse(hid_Secid.Value.ToString());
                    if (hid_Cancel.Value == "yes")
                    {
                        obj_da_Detail.UpdInvestPlanNew(int_Empid, txt_PlanDetail.Text, double.Parse(txt_Amount.Text), int_Secid, txt_PlanDetail.Text, int_Year, DateTime.Parse("01/01/9999"), 0, int_Secid);
                        obj_da_Log.InsLogDetail(int.Parse(Session["LoginEmpId"].ToString()), 808, 2, int.Parse(Session["LoginBranchid"].ToString()), int_Secid + "/CANCEL/U");
                    }
                    else
                    {
                        obj_da_Detail.UpdInvestPlanNew(int_Empid, txt_PlanDetail.Text, double.Parse(txt_Amount.Text), int_Secid, txt_PlanDetail.Text, int_Year, DateTime.Parse(Utility.fn_ConvertDate(txt_ReceivedOn.Text)), double.Parse(txt_ReceivedAnmt.Text), int_Secid);
                        obj_da_Log.InsLogDetail(int.Parse(Session["LoginEmpId"].ToString()), 808, 2, int.Parse(Session["LoginBranchid"].ToString()), int_Secid + "/U");
                    }

                    Fn_FillGrd();
                    Fn_SaveClear();
                    ScriptManager.RegisterStartupScript(btn_Save, typeof(Button), "HRM", "alertify.alert('Details Updated');", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(btn_Save, typeof(Button), "HRM", "alertify.alert('Enter Recived on Amount');", true);
                    txt_ReceivedAnmt.Focus();
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(btn_Save, typeof(Button), "HRM", "alertify.alert('House Rent Proof Received  cannot belonged');", true);
            }
            //btn_cancel.Text = "Cancel";
            btn_cancel.ToolTip = "Cancel";
            btn_cancel1.Attributes["class"] = "btn ico-cancel";

        }

        protected void txt_HouseProofReceived_TextChanged(object sender, EventArgs e)
        {
           
            if (txt_Empcode.Text.TrimEnd().Length != 0)
            {
                string Str_Msg = "";
                if (txt_HouseProofReceived.Text.TrimEnd().ToString().Length>0)
                {
                    if (txt_ActualRent.Text =="")
                    {
                        txt_ActualRent.Text = "0";
                    }
                    if (double.Parse(txt_HouseProofReceived.Text)> double.Parse(txt_ActualRent.Text))
                    {
                        Fn_RentDetail("R");
                        Fn_Update();
                    }
                    else
                    {
                        Str_Msg = lbl_HouseRent.Text + "-" + txt_HouseProofReceived.ToolTip + "Should be less than" + txt_ActualRent.ToolTip;
                        ScriptManager.RegisterStartupScript(txt_HouseProofReceived, typeof(TextBox), "HRM", "alertify.alert('" + Str_Msg + "');", true);
                    }
                }
                else
                {
                    Str_Msg = lbl_HouseRent.Text + "-" + txt_HouseProofReceived.ToolTip + "Cannot Be Blank";
                    ScriptManager.RegisterStartupScript(txt_HouseProofReceived, typeof(TextBox), "HRM", "alertify.alert('" + Str_Msg + "');", true);
                }
            }
            //btn_cancel.Text = "Cancel";
            btn_cancel.ToolTip = "Cancel";
            btn_cancel1.Attributes["class"] = "btn ico-cancel";
        }  

        private void Fn_Update()
        {
            if(txt_HouseProofReceived.Text=="")
            {
                txt_HouseProofReceived.Text = "0";
            }
            if (txt_HRA.Text=="")
            {
                txt_HRA.Text = "0";
            }
             if (txt_RentPaid.Text=="")
            {
                txt_RentPaid.Text = "0";
            }
             if (txt_Basic50.Text == "")
             {
                 txt_Basic50.Text = "0";
             }
            if (double.Parse(txt_HouseProofReceived.Text) < double.Parse(txt_HRA.Text) && double.Parse(txt_HouseProofReceived.Text) < double.Parse(txt_RentPaid.Text) && double.Parse(txt_HouseProofReceived.Text) < double.Parse(txt_Basic50.Text))
            {
                min = Convert.ToInt32(txt_HouseProofReceived.Text);
            }
            else if (double.Parse(txt_HRA.Text) < double.Parse(txt_HouseProofReceived.Text) && double.Parse(txt_HRA.Text) < double.Parse(txt_RentPaid.Text) && double.Parse(txt_HRA.Text) < double.Parse(txt_Basic50.Text))
            {
                min = Convert.ToInt32(txt_HRA.Text);
            }

            else if (double.Parse(txt_RentPaid.Text) < double.Parse(txt_HouseProofReceived.Text) && double.Parse(txt_RentPaid.Text) < double.Parse(txt_HRA.Text) && double.Parse(txt_RentPaid.Text) < double.Parse(txt_Basic50.Text))
            {
                min = Convert.ToInt32(txt_RentPaid.Text);
            }

            else if (double.Parse(txt_Basic50.Text) < double.Parse(txt_HouseProofReceived.Text) && double.Parse(txt_Basic50.Text) < double.Parse(txt_HRA.Text) && double.Parse(txt_Basic50.Text) < double.Parse(txt_RentPaid.Text))
            {
                min = Convert.ToInt32(txt_Basic50.Text);
            }

            else if (double.Parse(txt_HouseProofReceived.Text) == 0)
            {
                txt_RentPaid.Text = "0";
                txt_Basic50.Text = "0";
            }
            if (double.Parse(txt_HouseProofReceived.Text) < double.Parse(txt_HRA.Text))
            {
                min = Convert.ToInt32(txt_HouseProofReceived.Text);
            } 
            else
            {
                min = Convert.ToInt32(txt_HRA.Text);
            }
            if (min < double.Parse(txt_RentPaid.Text))
            {

            } 
            else
            {
                min = Convert.ToInt32(txt_RentPaid.Text);
            }
            if (min < double.Parse(txt_Basic50.Text))
            {
               
            }
            else
            {
                min = Convert.ToInt32(txt_Basic50.Text);
            }
            obj_da_Rent.UpdHrRentDtls(int.Parse(hid_Empid.Value.ToString()), int.Parse(ddl_Year.SelectedValue.ToString()),Convert.ToDouble(txt_HouseProofReceived.Text),Convert.ToDouble(min));
            ScriptManager.RegisterStartupScript(txt_ActualRent, typeof(TextBox), "HRM", "alertify.alert('Details Updated');", true);
            obj_da_Log.InsLogDetail(int.Parse(Session["LoginEmpId"].ToString()), 808, 2, int.Parse(Session["LoginBranchid"].ToString()), lbl_HouseRent.Text + "-" + txt_ReceivedAnmt.Text + "/U");
            txt_RentExp.Text =Convert.ToInt32(min).ToString();
        } 
        //private void Fn_Update()
        //{
        //    double ActualAmount = 0, Rentreceived = 0, RentPaidAmount = 0, Basic50 = 0, TotAmount = 0;
        //    ActualAmount = double.Parse(txt_HouseProofReceived.Text);
        //    Rentreceived = double.Parse(txt_HRA.Text);
        //    RentPaidAmount = double.Parse(txt_RentPaid.Text);
        //    Basic50 = double.Parse(txt_Basic50.Text);
        //    double[] RentAmount = { ActualAmount, Rentreceived, RentPaidAmount, Basic50 };
        //    TotAmount = RentAmount.Min();

        //    DataAccess.PAYROLL.RentDetailss obj_da_Rent = new DataAccess.PAYROLL.RentDetailss();
        //    obj_da_Rent.UpdHrRentDtls(int.Parse(hid_Empid.Value.ToString()), int.Parse(ddl_Year.SelectedValue.ToString()), Rentreceived, TotAmount);
        //    obj_da_Log.InsLogDetail(int.Parse(Session["LoginEmpId"].ToString()), 808, 2, int.Parse(Session["LoginBranchid"].ToString()), lbl_HouseRent.Text + "-" + txt_ReceivedAnmt.Text + "/U");
        //    ScriptManager.RegisterStartupScript(txt_ActualRent, typeof(TextBox), "HRM", "alertify.alert('Updated Successfully');", true);
        //}
        protected void ChkCancel_Click(object sender, EventArgs e)
        {

            CheckBox Chk = sender as CheckBox;
            GridViewRow row = (GridViewRow)Chk.NamingContainer;
            if (Chk.Checked == true)
            {
                hid_Cancel.Value = "yes";
            }
            {
                hid_Cancel.Value = "No";
            }

        }

        protected void txt_MedicalProofReceived_TextChanged(object sender, EventArgs e)
        {
            if (txt_Empcode.Text.TrimEnd().Length > 0)
            {
                string Str_Msg = "";
                if (txt_MedicalProofReceived.Text.TrimEnd().Length > 0)
                {
                    if (double.Parse(txt_MedicalProofReceived.Text) <= double.Parse(txt_Medical.Text))
                    {
                        Fn_GetMedicalDetail();
                    }
                    else
                    {
                        Str_Msg = lbl_Medical.Text + "-" + txt_MedicalProofReceived.ToolTip + "Should be less than Yearly Amount";
                        ScriptManager.RegisterStartupScript(txt_HouseProofReceived, typeof(TextBox), "HRM", "alertify.alert('" + Str_Msg + "');", true);
                    }
                }

            }
            //btn_cancel.Text = "Cancel";
            btn_cancel.ToolTip = "Cancel";
            btn_cancel1.Attributes["class"] = "btn ico-cancel";
        }

        protected void Grd_RowDataBound(object sender, GridViewRowEventArgs e)
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

                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(Grd, "Select$" + e.Row.RowIndex);
                e.Row.Attributes["style"] = "cursor:pointer";
            }
        }

        protected void txt_IncomeProofReceived_TextChanged(object sender, EventArgs e)
        {
            if(txt_Empcode.Text!="")
            {
                if (txt_IncomeProofReceived.Text.Trim()!="")
                {
                    if ( Convert.ToDouble (txt_IncomeProofReceived.Text)  <= Convert.ToDouble (txt_IncomeHouseRent.Text))
                    {
                        obj_da_Rent.UpdHouseRentDlsNew(Convert.ToInt32(hid_Empid.Value), Convert.ToInt32( txt_IncomeProofReceived.Text), int.Parse(ddl_Year.SelectedValue.ToString()));
                        ScriptManager.RegisterStartupScript(txt_IncomeProofReceived, typeof(TextBox), "HRM", "alertify.alert('" + lbl_income.Text + "-" + txt_IncomeProofReceived.ToolTip + "Details Updated');", true);
                        obj_da_Log.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"].ToString()), 808, 2, Convert.ToInt32(Session["LoginBranchid"].ToString()), lbl_income.Text + " - " + txt_IncomeProofReceived.Text + "/U");
                    }


                    else
                    {
                        ScriptManager.RegisterStartupScript(txt_IncomeProofReceived, typeof(TextBox), "HRM", "alertify.alert('" + lbl_income.Text + "-" + txt_HouseProofReceived.ToolTip + "Should be less than "+txt_IncomeHouseRent.ToolTip+"');", true);
                        txt_IncomeProofReceived.Focus();
                    }
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
            DataAccess.LogDetails Logobj = new DataAccess.LogDetails();

            obj_dtlogdetails = Logobj.InsTempGrpLogdtlsGet(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), 808, "Job", "", "", Session["StrTranType"].ToString());

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