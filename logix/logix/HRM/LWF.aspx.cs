using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace logix.HRM
{
    public partial class LWF : System.Web.UI.Page
    {
        DataAccess.LogDetails obj_da_Log = new DataAccess.LogDetails();
        DataAccess.Payroll.LWF obj_da_LWF = new DataAccess.Payroll.LWF();
        DataTable obj_dt = new DataTable();
        int tid, i, dtdiff;
        double dtFrom, dtTo, sFrom, sTo;
        DateTime vFrom, vTo, vf, vt;
        bool flag;
        protected void Page_Load(object sender, EventArgs e)
        {
            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(btn_Clear);
            if (Session["LoginUserName"] == null || Session["LoginEmpId"] == null || Session["LoginDivisionId"] == null || Session["LoginBranchid"] == null)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alertify.alert('Session TimeOut');window.open('"+ Session["Site"].ToString() + "/','_top');", true);
            }
            else if (Session["StrTranType"] == null)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alertify.alert('Session TimeOut');window.open('"+ Session["Site"].ToString() + "/FormMain.aspx','_top');", true);
            }
            if (Request.QueryString.ToString().Contains("FormName"))
            {
                string str_Uiid = "";
                str_Uiid = Request.QueryString["UIID"].ToString();
                Utility.Fn_CheckUserRights(str_Uiid, btn_Save, btn_view,null);
            }
            if (!IsPostBack)
            {
                Fn_LoadDate();
                string str_CtrlLists, str_MsgLists, str_DataType;
                str_CtrlLists = "txt_Branch~hid_bid~txt_Slabfrom~txt_SlabTo~txt_ConEmployee~txt_Emp~txt_MinEmp";
                str_MsgLists = "Branch~Branch~SlabFrom Amount~SlabTo Amount~Employee Amount~Employer Amount~No of Employee";
                str_DataType = "String~AutoComplete~Double~Double~Double~Double~Integer";
                btn_Save.Attributes.Add("OnClick", "return IsValid('" + str_CtrlLists + "','" + str_MsgLists + "','" + str_DataType + "') && IsDate('txt_ValidFrom~txt_ValidTo');");
                btn_view.Attributes.Add("OnClick", "return IsDate('txt_ValidFrom~txt_ValidTo');");
                Grd_LWF.DataSource = new DataTable();
                Grd_LWF.DataBind();
                txt_Branch.Focus();
                //btn_Clear.Text = "Cancel";
                btn_Clear.ToolTip = "Cancel";
                btn_cancel1.Attributes["class"] = "btn ico-cancel";
            }
            txt_Slabfrom.Attributes.Add("onkeypress", "return validateFloatKeyPress(this,event,'txt_Slabfrom')");
            txt_SlabTo.Attributes.Add("onkeypress", "return validateFloatKeyPress(this,event,'txt_SlabTo')");
            txt_ConEmployee.Attributes.Add("onkeypress", "return validateFloatKeyPress(this,event,'txt_ConEmployee')");
            txt_Emp.Attributes.Add("onkeypress", "return validateFloatKeyPress(this,event,'txt_Emp')");
            txt_MinEmp.Attributes.Add("onkeypress", "return validateFloatKeyPress(this,event,'txt_MinEmp')");
        }
        private void Fn_LoadDate()
        {
            DateTime Dt_Date = obj_da_Log.GetDate();
            txt_ValidFrom.Text = "01/04/" + Dt_Date.Year.ToString();
            txt_ValidTo.Text = "31/03/" + Dt_Date.AddYears(1).Year.ToString();
        }
        private void Fn_LoadGrid()
        {
            DataTable obj_dt = new DataTable();
            if (txt_Branch.Text.TrimEnd().Length > 0)
            {
                obj_dt = obj_da_LWF.SelLWF(int.Parse(hid_bid.Value.ToString()));
                Grd_LWF.DataSource = obj_dt;
                Grd_LWF.DataBind();
            }
        }

        protected void txt_Branch_TextChanged(object sender, EventArgs e)
        {
            Chk_Month.ClearSelection();
            Chk_All.Checked = false;

            Fn_LoadGrid();
        }

        protected void Grd_LWF_SelectedIndexChanged(object sender, EventArgs e)
        {
            hid_Taxid.Value = Grd_LWF.SelectedDataKey.Values[0].ToString();
            txt_ValidFrom.Text = Grd_LWF.SelectedRow.Cells[0].Text;
            txt_ValidTo.Text = Grd_LWF.SelectedRow.Cells[1].Text;
            txt_Slabfrom.Text = Grd_LWF.SelectedRow.Cells[2].Text;
            txt_SlabTo.Text = Grd_LWF.SelectedRow.Cells[3].Text;
            txt_ConEmployee.Text = Grd_LWF.SelectedRow.Cells[4].Text;
            txt_Emp.Text = Grd_LWF.SelectedRow.Cells[5].Text;
            txt_MinEmp.Text = Grd_LWF.SelectedDataKey.Values[1].ToString();
            //btn_Save.Text = "Update";
            btn_Save.ToolTip = "Update";
            btn_save1.Attributes["class"] = "btn btn-update1";

            Chk_All.Checked = false;
            Chk_Month.ClearSelection();
            DataTable obj_dt = new DataTable();
            obj_dt = obj_da_LWF.SelLWFDet(int.Parse(hid_Taxid.Value.ToString()));
            for (int i = 0; i <= obj_dt.Rows.Count - 1; i++)
            {
                Chk_Month.Items.FindByValue(obj_dt.Rows[i]["MonthNo"].ToString().TrimEnd()).Selected = true;
            }
            if (obj_dt.Rows.Count == 12)
            {
                Chk_All.Checked = true;
            }
        }

        protected void Chk_All_CheckedChanged(object sender, EventArgs e)
        {
            if (Chk_All.Checked == true)
            {
                foreach (ListItem listitem in Chk_Month.Items)
                {
                    listitem.Selected = true;
                }
            }
            else
            {
                Chk_Month.ClearSelection();
            }
        }
        private bool Fn_DateCheck(DateTime dt_From, DateTime dt_To, decimal SlabFrom, decimal SlabTo)
        {
            bool Check = false;
            DataTable obj_dt = new DataTable();
            obj_dt = obj_da_LWF.SelLWF(int.Parse(hid_bid.Value.ToString()));
            int int_Count, int_Taxid;
            int_Taxid = hid_Taxid.Value.ToString().Length == 0 ? 0 : int.Parse(hid_Taxid.Value.ToString());
            List<DataRow> Resultset = new List<DataRow>();
            var Result = obj_dt.AsEnumerable().Where(row => (DateTime.Parse(Utility.fn_ConvertDate(row.Field<string>("validfrom"))) == dt_From) && (DateTime.Parse(Utility.fn_ConvertDate(row.Field<string>("validto"))) == dt_To)).ToList();
            if (Result.Count > 0)
            {
                Resultset = obj_dt.AsEnumerable().Where(row => (DateTime.Parse(Utility.fn_ConvertDate(row.Field<string>("validfrom"))) == dt_From) && (DateTime.Parse(Utility.fn_ConvertDate(row.Field<string>("validto"))) == dt_To)
                     && ((row.Field<decimal>("slabfrom") < SlabFrom && row.Field<decimal>("slabto") > SlabTo)
                     || (row.Field<decimal>("slabfrom") > SlabFrom && row.Field<decimal>("slabto") < SlabTo)
                     || (row.Field<decimal>("slabfrom") < SlabFrom && row.Field<decimal>("slabto") > SlabFrom)
                     || (row.Field<decimal>("slabfrom") < SlabTo && row.Field<decimal>("slabto") > SlabTo)
                     || (row.Field<decimal>("slabfrom") == SlabTo || row.Field<decimal>("slabto") == SlabTo)
                     || (row.Field<decimal>("slabfrom") == SlabFrom || row.Field<decimal>("slabto") == SlabFrom))
                     ).ToList();
            }
            else
            {

                Resultset = obj_dt.AsEnumerable().Where(row => (DateTime.Parse(Utility.fn_ConvertDate(row.Field<string>("validfrom"))) < dt_From) && (DateTime.Parse(Utility.fn_ConvertDate(row.Field<string>("validto"))) > dt_From)
                        || (DateTime.Parse(Utility.fn_ConvertDate(row.Field<string>("validfrom"))) < dt_To) && (DateTime.Parse(Utility.fn_ConvertDate(row.Field<string>("validto"))) > dt_To)
                        || (DateTime.Parse(Utility.fn_ConvertDate(row.Field<string>("validfrom"))) > dt_From) && (DateTime.Parse(Utility.fn_ConvertDate(row.Field<string>("validto"))) < dt_To)
                        || (DateTime.Parse(Utility.fn_ConvertDate(row.Field<string>("validfrom"))) < dt_From) && (DateTime.Parse(Utility.fn_ConvertDate(row.Field<string>("validto"))) > dt_To)
                        || (DateTime.Parse(Utility.fn_ConvertDate(row.Field<string>("validfrom"))) == dt_From)
                        || (DateTime.Parse(Utility.fn_ConvertDate(row.Field<string>("validto"))) == dt_From)
                        || (DateTime.Parse(Utility.fn_ConvertDate(row.Field<string>("validfrom"))) == dt_To)
                        || (DateTime.Parse(Utility.fn_ConvertDate(row.Field<string>("validto"))) == dt_To)
                        ).ToList();
            }

            if (Resultset.Count > 0)
            {
                if (btn_Save.ToolTip == "Update")
                {
                    //int_Count = Resultset.AsEnumerable().Count(row => row.Field<decimal>("slabto") == SlabTo
                    //    && row.Field<decimal>("slabfrom") == SlabFrom
                    //    && DateTime.Parse(Utility.fn_ConvertDate(row.Field<string>("validfrom"))) == dt_From
                    //    && DateTime.Parse(Utility.fn_ConvertDate(row.Field<string>("validto"))) == dt_To
                    //    && int.Parse(row.Field<Int32>("tid").ToString()) == int_Taxid);
                    int_Count = Resultset.AsEnumerable().Count(row => int.Parse(row.Field<Int32>("tid").ToString()) == int_Taxid
                       && (DateTime.Parse(Utility.fn_ConvertDate(row.Field<string>("validfrom"))) < dt_From) && (DateTime.Parse(Utility.fn_ConvertDate(row.Field<string>("validto"))) > dt_From)
                       || (DateTime.Parse(Utility.fn_ConvertDate(row.Field<string>("validfrom"))) < dt_To) && (DateTime.Parse(Utility.fn_ConvertDate(row.Field<string>("validto"))) > dt_To)
                       || (DateTime.Parse(Utility.fn_ConvertDate(row.Field<string>("validfrom"))) > dt_From) && (DateTime.Parse(Utility.fn_ConvertDate(row.Field<string>("validto"))) < dt_To)
                       || (DateTime.Parse(Utility.fn_ConvertDate(row.Field<string>("validfrom"))) < dt_From) && (DateTime.Parse(Utility.fn_ConvertDate(row.Field<string>("validto"))) > dt_To)
                       || (DateTime.Parse(Utility.fn_ConvertDate(row.Field<string>("validfrom"))) == dt_From)
                       || (DateTime.Parse(Utility.fn_ConvertDate(row.Field<string>("validto"))) == dt_From)
                       || (DateTime.Parse(Utility.fn_ConvertDate(row.Field<string>("validfrom"))) == dt_To)
                       || (DateTime.Parse(Utility.fn_ConvertDate(row.Field<string>("validto"))) == dt_To)
                                              );

                    if (int_Count == 1)
                    {
                        Check = true;
                    }
                    else
                    {
                        Check = false;
                    }

                }
                else if (btn_Save.ToolTip == "Save")
                {
                    Check = false;
                }
            }
            else
            {
                Check = true;
            }
            return Check;
        }
        protected void valid()
        {
            double amt = 0, amt1 = 0;
            DateTime dt_From, dt_To;
            decimal SlabFrom, SlabTo;
            vFrom = DateTime.Parse(Utility.fn_ConvertDate(txt_ValidFrom.Text));
            vTo = DateTime.Parse(Utility.fn_ConvertDate(txt_ValidTo.Text));
            sFrom = Convert.ToDouble(txt_Slabfrom.Text);
            sTo = Convert.ToDouble(txt_SlabTo.Text);
            obj_dt = obj_da_LWF.SelLWF(int.Parse(hid_bid.Value.ToString()));
            if (obj_dt.Rows.Count > 0)
            {
                for (int i = 0; i <= obj_dt.Rows.Count - 1; i++)
                {
                    amt = Convert.ToDouble(obj_dt.Rows[i]["slabfrom"].ToString());
                    dtFrom = Convert.ToDouble(amt);
                    amt1 = Convert.ToDouble(obj_dt.Rows[i]["slabto"].ToString());
                    dtTo = Convert.ToDouble(amt1);
                    DateTime dd;
                    dd = DateTime.Parse(Utility.fn_ConvertDate(obj_dt.Rows[i]["validfrom"].ToString()));
                    vf = DateTime.Parse(Utility.fn_ConvertDate(obj_dt.Rows[i]["validfrom"].ToString()));
                    vt = DateTime.Parse(Utility.fn_ConvertDate(obj_dt.Rows[i]["validto"].ToString()));

                    if ((vFrom > vf && vFrom < vt) || (vTo > vf && vTo < vt) || (vf > vFrom && vf < vTo) || (vt > vFrom && vt < vTo))
                    {
                        if ((sFrom >= dtFrom && sFrom <= dtTo) || (sTo >= dtFrom && sTo <= dtTo) || (dtFrom >= sFrom && dtFrom <= sTo) || (dtTo >= sFrom && dtTo <= sTo))
                        {
                            flag = true;
                            return;
                        }

                    }
                    else
                    {
                        flag = false;
                    }
                }
            }

        }
        protected void btn_Save_Click(object sender, EventArgs e)
        {
            string[] Month_items;
            List<string> values = new List<string>();
            foreach (ListItem Lst in Chk_Month.Items)
            {
                if (Lst.Selected == true)
                {
                    values.Add(Lst.Value);
                }
            }
            Month_items = values.ToArray();
            valid();
            if (Month_items.Length == 0)
            {
                ScriptManager.RegisterStartupScript(btn_Save, typeof(Button), "HRM", "alertify.alert('Please Select the Month')", true);
                return;
            }

            DateTime dt_From, dt_To;
            decimal SlabFrom, SlabTo;
            dt_From = DateTime.Parse(Utility.fn_ConvertDate(txt_ValidFrom.Text));
            dt_To = DateTime.Parse(Utility.fn_ConvertDate(txt_ValidTo.Text));
            SlabFrom = decimal.Parse(txt_Slabfrom.Text);
            SlabTo = decimal.Parse(txt_SlabTo.Text);

            if (flag==true)
            {
                ScriptManager.RegisterStartupScript(btn_Save, typeof(Button), "HRM", "alertify.alert('Same Details Already Found.Not Able to Inserted');", true);
                return;
            }
            if (SlabFrom == 0 || SlabTo == 0)
            {
                ScriptManager.RegisterStartupScript(btn_Save, typeof(Button), "HRM", "alertify.alert('Slab Values must be Greater then Zero');", true);
                return;
            }
            else if (SlabFrom > SlabTo)
            {
                ScriptManager.RegisterStartupScript(btn_Save, typeof(Button), "HRM", "alertify.alert('Slab Values must be Greater then Zero');", true);
                return;
            }
            if (btn_Save.ToolTip == "Save")
            {
                obj_da_LWF.SveLWFWeb(int.Parse(hid_bid.Value.ToString()), double.Parse(txt_Slabfrom.Text), double.Parse(txt_SlabTo.Text), double.Parse(txt_ConEmployee.Text), double.Parse(txt_Emp.Text)
                   , Month_items, dt_From, dt_To, int.Parse(txt_MinEmp.Text));
                ScriptManager.RegisterStartupScript(btn_Save, typeof(Button), "HRM", "alertify.alert('Details Saved');", true);
                obj_da_Log.InsLogDetail(int.Parse(Session["LoginEmpId"].ToString()), 810, 1, int.Parse(Session["LoginBranchid"].ToString()), dt_From + "/" + dt_To + "/" + hid_bid.Value.ToString() + "/S");
            }
            else if (btn_Save.ToolTip == "Update")
            {
                obj_da_LWF.UpdateLWFWeb(int.Parse(hid_Taxid.Value.ToString()),int.Parse(hid_bid.Value.ToString()), double.Parse(txt_Slabfrom.Text), double.Parse(txt_SlabTo.Text), double.Parse(txt_ConEmployee.Text), double.Parse(txt_Emp.Text)
                    , Month_items, dt_From, dt_To, int.Parse(txt_MinEmp.Text));
                ScriptManager.RegisterStartupScript(btn_Save, typeof(Button), "HRM", "alertify.alert('Details Updated');", true);
                obj_da_Log.InsLogDetail(int.Parse(Session["LoginEmpId"].ToString()), 810, 2, int.Parse(Session["LoginBranchid"].ToString()), dt_From + "/" + dt_To + "/" + hid_bid.Value.ToString() + "/U");
            }
            Fn_Clear();
            Fn_LoadGrid();
            //btn_Clear.Text = "Cancel";
            btn_Clear.ToolTip = "Cancel";
            btn_cancel1.Attributes["class"] = "btn ico-cancel";
        }
        private void Fn_Clear()
        {

            Chk_Month.ClearSelection();
            Chk_All.Checked = false;
            txt_Slabfrom.Text = "";
            txt_SlabTo.Text = "";
            //btn_Save.Text = "Save";
            btn_Save.ToolTip = "Save";
            btn_save1.Attributes["class"] = "btn ico-save";
            txt_ConEmployee.Text = "";
            txt_Emp.Text = "";
            txt_MinEmp.Text = "";

        }

        protected void btn_view_Click(object sender, EventArgs e)
        {
            DateTime dt_From, dt_To;
            dt_From = DateTime.Parse(Utility.fn_ConvertDate(txt_ValidFrom.Text));
            dt_To = DateTime.Parse(Utility.fn_ConvertDate(txt_ValidTo.Text));
            string Str_sp = "", Str_sf = "", Str_RptName = "", Str_Script = "";
            Session["str_sfs"] = "";
            Session["str_sp"] = "";
            Str_RptName = "/Payroll/" + "rptHRLwfDetails.rpt";
            Str_sp = "Frm=" + txt_ValidFrom.Text + "~to=" + txt_ValidTo.Text;
            if (txt_Branch.Text.TrimEnd().Length > 0)
            {
                Str_sf = " {HRMasterLWF.validfrom}>=date(\"" + dt_From.Year + "," + dt_From.Month + "," + dt_From.Day + "\") and {HRMasterLWF.validto}<=date(\"" + dt_To.Year + "," + dt_To.Month + "," + dt_To.Day + "\")and {HRMasterLWF.bid}=" + hid_bid.Value.ToString();
            }
            else
            {
                Str_sf = " {HRMasterLWF.validfrom}>=date(\"" + dt_From.Year + "," + dt_From.Month + "," + dt_From.Day + "\") and {HRMasterLWF.validto}<=date(\"" + dt_To.Year + "," + dt_To.Month + "," + dt_To.Day + "\")";
            }
            Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_sf + "&Parameter=" + Str_sp + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
            obj_da_Log.InsLogDetail(int.Parse(Session["LoginEmpId"].ToString()), 810, 3, int.Parse(Session["LoginBranchid"].ToString()), "/View"); 
            ScriptManager.RegisterStartupScript(btn_view, typeof(Button), "HRM", Str_Script, true);
            Session["str_sfs"] = Str_sf;
            Session["str_sp"] = Str_sp;
            //btn_Clear.Text = "Cancel";
            btn_Clear.ToolTip = "Cancel";
            btn_cancel1.Attributes["class"] = "btn ico-cancel";
        }

        protected void btn_Clear_Click(object sender, EventArgs e)
        {
            if (btn_Clear.ToolTip == "Cancel")
            {
                Fn_Clear();
                Grd_LWF.DataSource = new DataTable();
                Grd_LWF.DataBind();
                Fn_LoadDate();
                txt_Branch.Focus();
                txt_Branch.Text = "";
                //btn_Clear.Text = "Back";
                btn_Clear.ToolTip = "Back";
                btn_cancel1.Attributes["class"] = "btn ico-back";
            }
            else
            {
                this.Response.End();
            }
        }

        protected void Grd_LWF_RowDataBound(object sender, GridViewRowEventArgs e)
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
                e.Row.Attributes.Add("onmouseover", "this.originalcolor=this.style.backgroundColor;" + " this.style.backgroundColor='#FDCB0A';");
                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalcolor;");

                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(Grd_LWF, "Select$" + e.Row.RowIndex);
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

            obj_dtlogdetails = Logobj.InsTempGrpLogdtlsGet(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), 810, "Job", "", "", Session["StrTranType"].ToString());

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