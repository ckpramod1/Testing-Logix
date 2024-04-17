using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace logix.HRM
{
    public partial class ProfessionalTax : System.Web.UI.Page
    {
        DataAccess.LogDetails obj_da_Log = new DataAccess.LogDetails();
        DataAccess.payroll.ProfessionalTax obj_da_ProfTax = new DataAccess.payroll.ProfessionalTax();
        DataAccess.Payroll.Details obj_da_Detail = new DataAccess.Payroll.Details();
        Char catgy;
        DataTable obj_dt = new DataTable();
        int tid, i,  dtdiff;
        double dtFrom, dtTo, sFrom, sTo;
        DateTime vFrom, vTo, vf, vt;
        bool flag;
        int tid1=0;
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
                Utility.Fn_CheckUserRights(str_Uiid, btn_Save, btn_view, null);
            }
            if (!IsPostBack)
            {
                Fn_LoadDate();
                Grd_Tax.DataSource = new DataTable();
                Grd_Tax.DataBind();
                txt_Branch.Focus();
             //   btn_Clear.Text = "Cancel";
                btn_Clear.ToolTip = "Cancel";
                btn_Clear1.Attributes["class"] = "btn ico-cancel";
                string str_CtrlLists, str_MsgLists, str_DataType;
                str_CtrlLists = "txt_Branch~hid_bid~txt_Tax~txt_Slabfrom~txt_SlabTo";
                str_MsgLists = "Branch~Branch~Professional Tax Amount~SlabFrom Amount~SlabTo Amount";
                str_DataType = "String~AutoComplete~Double~Double~Double";
                btn_Save.Attributes.Add("OnClick", "return IsValid('" + str_CtrlLists + "','" + str_MsgLists + "','" + str_DataType + "') && IsDate('txt_ValidFrom~txt_ValidTo');");
                btn_view.Attributes.Add("OnClick", "return IsDate('txt_ValidFrom~txt_ValidTo');");
                //txt_Slabfrom.Attributes.Add("OnKeyUp", "return IsDoubleCheck('txt_Slabfrom');");
                //txt_SlabTo.Attributes.Add("OnKeyUp", "return IsDoubleCheck('txt_SlabTo');");

            }
            txt_Tax.Attributes.Add("onkeypress", "return validateFloatKeyPress(this,event,'txt_Tax')");
            txt_Slabfrom.Attributes.Add("onkeypress", "return validateFloatKeyPress(this,event,'txt_Slabfrom')");
            txt_SlabTo.Attributes.Add("onkeypress", "return validateFloatKeyPress(this,event,'txt_SlabTo')");
          
        }

        private void Fn_LoadDate()
        {
            DateTime Dt_Date = obj_da_Log.GetDate();

            if (Dt_Date.Month > 4)
            {
                txt_ValidFrom.Text = "01/04/" + Dt_Date.Year.ToString();
                txt_ValidTo.Text = "31/03/" + Dt_Date.AddYears(1).Year.ToString();
            }
            else
            {
                txt_ValidFrom.Text = "01/04/" + Dt_Date.AddYears(-1).Year.ToString();
                txt_ValidTo.Text = "31/03/" + Dt_Date.Year.ToString();
            }
        }
        private void Fn_LoadGrid()
        {
            DataTable obj_dt = new DataTable();
            if (txt_Branch.Text.TrimEnd().Length > 0)
            {
                obj_dt = obj_da_ProfTax.SelProfTax(int.Parse(hid_bid.Value.ToString()));
                Grd_Tax.DataSource = obj_dt;
                Grd_Tax.DataBind();
            }

        }

        protected void txt_Branch_TextChanged(object sender, EventArgs e)
        {
            Fn_LoadGrid();
         //   btn_Clear.Text = "Cancel";

            btn_Clear.ToolTip = "Cancel";
            btn_Clear1.Attributes["class"] = "btn ico-cancel";
        }
        //private DataTable Fn_LoadGrid1()
        //{
        //    //DataTable obj_dt = new DataTable();
        //    //if (ddl_Category.SelectedIndex != 0)
        //    //{
        //    //    obj_dt = obj_da_Detail.SelTaxslab(char.Parse(ddl_Category.SelectedValue.ToString()));
        //    //}
        //    //return obj_dt;
        //}

        protected void ddl_Category_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Grd_Tax.DataSource = Fn_LoadGrid1();
            //Grd_Tax.DataBind();
            if (ddl_Category.Text == "Male")
            {
                catgy = 'M';
            }
            else if (ddl_Category.Text == "Both")
            {
                catgy = 'B';
            }
            else
            {
                catgy = 'F';
            }

            //btn_Clear.Text = "Cancel";

            btn_Clear.ToolTip = "Cancel";
            btn_Clear1.Attributes["class"] = "btn ico-cancel";
        }
        protected void Grd_Tax_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = Convert.ToInt32(Grd_Tax.SelectedRow.RowIndex);
            if (hid_confirm.Value.ToString() == "N")
            {
                if (Grd_Tax.Rows.Count > 0)
                {
                    hid_Taxid.Value = Grd_Tax.SelectedDataKey.Values[0].ToString();

                    //if (hid_confirm.Value.ToString() == "N")
                    //{
                    //ddl_Category.SelectedIndex = ddl_Category.Items.IndexOf(ddl_Category.Items.FindByValue(Grd_Tax.SelectedDataKey.Values[1].ToString()));
                    txt_ValidFrom.Text = Grd_Tax.SelectedRow.Cells[0].Text;
                    txt_ValidTo.Text = Grd_Tax.SelectedRow.Cells[1].Text;
                    txt_Slabfrom.Text = Grd_Tax.SelectedRow.Cells[2].Text;
                    txt_SlabTo.Text = Grd_Tax.SelectedRow.Cells[3].Text;
                    txt_Tax.Text = Grd_Tax.SelectedRow.Cells[4].Text;
                    string ddl = Grd_Tax.SelectedRow.Cells[5].Text;

                    if (ddl == "B")
                    {
                        ddl_Category.SelectedValue = ddl;
                        // ddl_Category.Text = "Both";

                    }
                    else if (ddl == "M")
                    {

                        ddl_Category.SelectedValue = ddl;
                        //ddl_Category.Text = "Male";

                    }
                    else if (ddl == "F")
                    {
                        ddl_Category.SelectedValue = ddl;
                        // ddl_Category.Text = "FeMale";
                    }
                    else
                    {
                        ddl_Category.SelectedValue = "0";
                        // ddl_Category.Text = "";
                    }

                    //btn_Save.Text = "Update";

                    btn_Save.ToolTip = "Update";
                    btn_Save1.Attributes["class"] = "btn btn-update1";
                    txt_Tax.Focus();
                    Chk_All.Checked = false;
                    Chk_Month.ClearSelection();
                    DataTable obj_dt = new DataTable();
                    obj_dt = obj_da_ProfTax.SelProfTaxDet(int.Parse(hid_Taxid.Value.ToString()));
                    for (int i = 0; i <= obj_dt.Rows.Count - 1; i++)
                    {
                        Chk_Month.Items.FindByValue(obj_dt.Rows[i]["MonthNo"].ToString().TrimEnd()).Selected = true;
                    }
                    if (obj_dt.Rows.Count == 12)
                    {
                        Chk_All.Checked = true;
                    }
                }
            }

            else if (hid_confirm.Value.ToString() == "Y")
            {

                //}
                //else if (hid_confirm.Value.ToString() == "Y")
                //{
                obj_da_ProfTax.DelProfTax(int.Parse(Grd_Tax.SelectedDataKey.Values["tid"].ToString()));
                Fn_Clear();
                Fn_LoadGrid();

            }
           // btn_Clear.Text = "Cancel";
            btn_Clear.ToolTip = "Cancel";
            btn_Clear1.Attributes["class"] = "btn ico-cancel";
        }
        private void Fn_Clear()
        {

            Chk_Month.ClearSelection();
            Chk_All.Checked = false;
            txt_Tax.Text = "";
            txt_Slabfrom.Text = "";
            txt_SlabTo.Text = "";
          //  btn_Save.Text = "Save";

            btn_Save.ToolTip = "Save";
            btn_Save1.Attributes["class"] = "btn ico-save";
            ddl_Category.SelectedIndex = -1;
            
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
           // btn_Clear.Text = "Cancel";

            btn_Clear.ToolTip = "Cancel";
            btn_Clear1.Attributes["class"] = "btn ico-cancel";
        }

        protected void btn_view_Click(object sender, EventArgs e)
        {
            DateTime dt_From, dt_To;
            dt_From = DateTime.Parse(Utility.fn_ConvertDate(txt_ValidFrom.Text));
            dt_To = DateTime.Parse(Utility.fn_ConvertDate(txt_ValidTo.Text));
            string Str_sp = "", Str_sf = "", Str_RptName = "", Str_Script = "";
            Session["str_sfs"] = "";
            Session["str_sp"] = "";
            Str_RptName = "/Payroll/" + "Rpthrproftax.rpt";
            Str_sp = "Frm=" + txt_ValidFrom.Text + "~to=" + txt_ValidTo.Text;
            if (txt_Branch.Text.TrimEnd().Length > 0)
            {
                Str_sf = " {HRMasterProfTax.validfrom}>=date(\"" + dt_From.Year + "," + dt_From.Month + "," + dt_From.Day + "\") and {HRMasterProfTax.validto}<=date(\"" + dt_To.Year + "," + dt_To.Month + "," + dt_To.Day + "\")and {HRMasterProfTax.bid}=" + hid_bid.Value.ToString();
            }
            else
            {
                Str_sf = " {HRMasterProfTax.validfrom}>=date(\"" + dt_From.Year + "," + dt_From.Month + "," + dt_From.Day + "\") and {HRMasterProfTax.validto}<=date(\"" + dt_To.Year + "," + dt_To.Month + "," + dt_To.Day + "\")";
            }
            Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_sf + "&Parameter=" + Str_sp + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
            ScriptManager.RegisterStartupScript(btn_view, typeof(Button), "HRM", Str_Script, true);
            Session["str_sfs"] = Str_sf;
            Session["str_sp"] = Str_sp;
        //    btn_Clear.Text = "Cancel";
            btn_Clear.ToolTip = "Cancel";
            btn_Clear1.Attributes["class"] = "btn ico-cancel";
        }

        protected void btn_Clear_Click(object sender, EventArgs e)
        {
            if (btn_Clear.ToolTip == "Cancel")
            {
                txt_Branch.Text = "";
                Fn_LoadDate();
                Grd_Tax.DataSource = new DataTable();
                Grd_Tax.DataBind();
                txt_Branch.Focus();
                Fn_Clear();
              //  btn_Clear.Text = "Back";
                btn_Clear.ToolTip = "Cancel";
                btn_Clear1.Attributes["class"] = "btn ico-back";
            }
            else
            {
                this.Response.End();
            }
        }
        private bool Fn_DateCheck(DateTime dt_From, DateTime dt_To, decimal SlabFrom, decimal SlabTo)
        {
            bool Check = false;
            DataTable obj_dt = new DataTable();
            obj_dt = obj_da_ProfTax.SelProfTax(int.Parse(hid_bid.Value.ToString()));
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
                    //int_Count =Convert.ToInt32( Resultset.AsEnumerable().Count(row => int.Parse(row.Field<byte>("tid").ToString()) == int_Taxid
                    //    && (DateTime.Parse(Utility.fn_ConvertDate(row.Field<string>("validfrom"))) < dt_From) && (DateTime.Parse(Utility.fn_ConvertDate(row.Field<string>("validto"))) > dt_From)
                    //    || (DateTime.Parse(Utility.fn_ConvertDate(row.Field<string>("validfrom"))) < dt_To) && (DateTime.Parse(Utility.fn_ConvertDate(row.Field<string>("validto"))) > dt_To)
                    //    || (DateTime.Parse(Utility.fn_ConvertDate(row.Field<string>("validfrom"))) > dt_From) && (DateTime.Parse(Utility.fn_ConvertDate(row.Field<string>("validto"))) < dt_To)
                    //    || (DateTime.Parse(Utility.fn_ConvertDate(row.Field<string>("validfrom"))) < dt_From) && (DateTime.Parse(Utility.fn_ConvertDate(row.Field<string>("validto"))) > dt_To)
                    //    || (DateTime.Parse(Utility.fn_ConvertDate(row.Field<string>("validfrom"))) == dt_From)
                    //    || (DateTime.Parse(Utility.fn_ConvertDate(row.Field<string>("validto"))) == dt_From)
                    //    || (DateTime.Parse(Utility.fn_ConvertDate(row.Field<string>("validfrom"))) == dt_To)
                    //    || (DateTime.Parse(Utility.fn_ConvertDate(row.Field<string>("validto"))) == dt_To)
                    //                           ));
                    int_Count = Convert.ToInt32(Resultset.AsEnumerable().Count(row => (DateTime.Parse(Utility.fn_ConvertDate(row.Field<string>("validfrom"))) < dt_From) && (DateTime.Parse(Utility.fn_ConvertDate(row.Field<string>("validto"))) > dt_From)
                      || (DateTime.Parse(Utility.fn_ConvertDate(row.Field<string>("validfrom"))) < dt_To) && (DateTime.Parse(Utility.fn_ConvertDate(row.Field<string>("validto"))) > dt_To)
                      || (DateTime.Parse(Utility.fn_ConvertDate(row.Field<string>("validfrom"))) > dt_From) && (DateTime.Parse(Utility.fn_ConvertDate(row.Field<string>("validto"))) < dt_To)
                      || (DateTime.Parse(Utility.fn_ConvertDate(row.Field<string>("validfrom"))) < dt_From) && (DateTime.Parse(Utility.fn_ConvertDate(row.Field<string>("validto"))) > dt_To)
                      || (DateTime.Parse(Utility.fn_ConvertDate(row.Field<string>("validfrom"))) == dt_From)
                      || (DateTime.Parse(Utility.fn_ConvertDate(row.Field<string>("validto"))) == dt_From)
                      || (DateTime.Parse(Utility.fn_ConvertDate(row.Field<string>("validfrom"))) == dt_To)
                      || (DateTime.Parse(Utility.fn_ConvertDate(row.Field<string>("validto"))) == dt_To)
                      ));

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
            obj_dt = obj_da_Detail.SelTaxslab(char.Parse(ddl_Category.SelectedValue.ToString()));
            if (obj_dt.Rows.Count > 0)
            {
                for (int i = 0; i <= obj_dt.Rows.Count - 1; i++)
                {
                    dtFrom = Convert.ToDouble(obj_dt.Rows[i]["slabfrom"].ToString());
                    //dtFrom = Convert.ToInt32(amt);
                    dtTo = Convert.ToDouble(obj_dt.Rows[i]["slabto"].ToString());
                   // dtTo = Convert.ToInt32(amt1);
                    DateTime dd;
                    dd = DateTime.Parse(Utility.fn_ConvertDate(obj_dt.Rows[i]["validfrom"].ToString()));
                    vf = DateTime.Parse(Utility.fn_ConvertDate(obj_dt.Rows[i]["validfrom"].ToString()));
                    vt = DateTime.Parse(Utility.fn_ConvertDate(obj_dt.Rows[i]["validto"].ToString()));

                    if ((vFrom > vf && vFrom < vt) || (vTo > vf && vTo < vt) || (vf > vFrom && vf < vTo) || (vt > vFrom && vt < vTo))
                    {
                        if ((sFrom >= dtFrom && sFrom <= dtTo) || (sTo >= dtFrom && sTo <= dtTo) || (dtFrom >= sFrom && dtFrom <= sTo) || (dtTo >= sFrom && dtTo <= sTo))
                        {
                            int val = Convert.ToInt32(Grd_Tax.SelectedDataKey.Values["tid"].ToString());
                            if (btn_Save.ToolTip == "Update" && val != tid1)
                            {
                                flag = true;
                            }

                            else
                            {
                                flag = false;
                            }

                        }
                    }
                }
            }

        }


        protected void btn_Save_Click(object sender, EventArgs e)
        {
            //List<ListItem> Month_items = Chk_Month.Items.Cast<ListItem>().Where(row => row.Selected).ToList();
            if (ddl_Category.Text == "Male")
            {
                catgy = 'M';
            }
            else if (ddl_Category.Text == "Both")
            {
                catgy = 'B';
            }
            else
            {
                catgy = 'F';
            }
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
            valid();

            if (flag == true)
            {
                ScriptManager.RegisterStartupScript(btn_Save, typeof(Button), "HRM", "alertify.alert('Err.Occur. Not Able to Insert');", true);
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
                // obj_da_ProfTax.SveProfTaxWeb(int.Parse(hid_bid.Value.ToString()), double.Parse(txt_Slabfrom.Text), double.Parse(txt_SlabTo.Text), double.Parse(txt_Tax.Text), Month_items, dt_From, dt_To);
                // profobj.SveProfTax(bid, txtSlabfrm.Text, txtSlabto.Text, txtProfTax.Text, lvMonthNames, DtValidFrom.Value, DtValidTo.Value, catgy)
                //obj_da_ProfTax.SveProfTax(Convert.ToInt32(hid_bid.Value.ToString()), Double.Parse(txt_Slabfrom.Text), Double.Parse(txt_SlabTo.Text), Double.Parse(txt_Tax.Text), Month_items, dt_From, dt_To, catgy);
                obj_da_ProfTax.SveProfTax(Convert.ToInt32(hid_bid.Value.ToString()), double.Parse(txt_Slabfrom.Text), double.Parse(txt_SlabTo.Text), double.Parse(txt_Tax.Text), Month_items, dt_From, dt_To, catgy);
                ScriptManager.RegisterStartupScript(btn_Save, typeof(Button), "HRM", "alertify.alert('Details Inserted');", true);
                obj_da_Log.InsLogDetail(int.Parse(Session["LoginEmpId"].ToString()), 809, 1, int.Parse(Session["LoginBranchid"].ToString()), dt_From + "/" + dt_To + "/" + hid_bid.Value.ToString() + "/S");
            }
            else if (btn_Save.ToolTip == "Update")
            {
                //obj_da_ProfTax.UpdateProfTaxWeb(int.Parse(hid_Taxid.Value.ToString()),int.Parse(hid_bid.Value.ToString()), double.Parse(txt_Slabfrom.Text), double.Parse(txt_SlabTo.Text), double.Parse(txt_Tax.Text), Month_items, dt_From, dt_To);
                obj_da_ProfTax.UpdateProfTax(int.Parse(hid_Taxid.Value.ToString()), int.Parse(hid_bid.Value.ToString()), double.Parse(txt_Slabfrom.Text), double.Parse(txt_SlabTo.Text), double.Parse(txt_Tax.Text), Month_items, dt_From, dt_To, catgy);
                ScriptManager.RegisterStartupScript(btn_Save, typeof(Button), "HRM", "alertify.alert('Details Updated');", true);
                obj_da_Log.InsLogDetail(int.Parse(Session["LoginEmpId"].ToString()), 809, 2, int.Parse(Session["LoginBranchid"].ToString()), dt_From + "/" + dt_To + "/" + hid_bid.Value.ToString() + "/U");
            }
            Fn_Clear();
            Fn_LoadGrid();
          //  btn_Clear.Text = "Cancel";

            btn_Clear.ToolTip = "Cancel";
            btn_Clear1.Attributes["class"] = "btn ico-cancel";
        }

        protected void Grd_Tax_RowDataBound(object sender, GridViewRowEventArgs e)
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

                //e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(Grd_Tax, "Select$" + e.Row.RowIndex);
                //e.Row.Attributes["style"] = "cursor:pointer";
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

            obj_dtlogdetails = Logobj.InsTempGrpLogdtlsGet(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), 809, "Job", "", "", Session["StrTranType"].ToString());

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