using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace logix.HRM
{
    public partial class TaxSlab : System.Web.UI.Page
    {
        DataAccess.LogDetails obj_da_Log = new DataAccess.LogDetails();
        DataAccess.Payroll.Details obj_da_Detail = new DataAccess.Payroll.Details();
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
                Utility.Fn_CheckUserRights(str_Uiid, btn_Save, btn_View, null);
            }
            if (!IsPostBack)
            {
                Fn_LoadDate();
                Grd_Tax.DataSource = new DataTable();
                Grd_Tax.DataBind();
            //    btn_Clear.Text = "Cancel";

                btn_Clear.ToolTip = "Cancel";
                btn_Clear1.Attributes["class"] = "btn ico-cancel";
                string str_CtrlLists, str_MsgLists, str_DataType;
                str_CtrlLists = "ddl_Category~txt_Tax~txt_SlabFrom~txt_SlabTo~txt_charge~txt_chess";
                str_MsgLists = "Category~Tax Percentage~SlabFrom~SlabTo~SurCharges~Edu.Chess";
                str_DataType = "DropDown~Integer~Double~Double~Double~Double";
                btn_Save.Attributes.Add("OnClick", "return IsValid('" + str_CtrlLists + "','" + str_MsgLists + "','" + str_DataType + "') && IsDate('txt_ValidFrom~txt_ValidTo');");
                btn_View.Attributes.Add("OnClick", "return IsDate('txt_ValidFrom~txt_ValidTo');");
                txt_SlabFrom.Attributes.Add("onkeypress", "return validateFloatKeyPress(this,event,'txt_SlabFrom')");
                txt_SlabTo.Attributes.Add("onkeypress", "return validateFloatKeyPress(this,event,'txt_SlabTo')");
                txt_charge.Attributes.Add("onkeypress", "return validateFloatKeyPress(this,event,'txt_charge')");
                txt_chess.Attributes.Add("onkeypress", "return validateFloatKeyPress(this,event,'txt_chess')");
                txt_Tax.Attributes.Add("onkeypress", "return validateFloatKeyPress(this,event,'txt_Tax')");
            }
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
        private DataTable Fn_LoadGrid()
        {

            if (ddl_Category.SelectedIndex != 0)
            {
                obj_dt = obj_da_Detail.SelTaxslab(char.Parse(ddl_Category.SelectedValue.ToString()));
            }
            return obj_dt;
        }

        protected void ddl_Category_SelectedIndexChanged(object sender, EventArgs e)
        {
            Grd_Tax.DataSource = Fn_LoadGrid();
            Grd_Tax.DataBind();
            txt_Tax.Focus();
        }

        protected void valid()
        {
            double amt = 0, amt1 = 0;
            DateTime dt_From, dt_To;
            decimal SlabFrom, SlabTo;
            vFrom = DateTime.Parse(Utility.fn_ConvertDate(txt_ValidFrom.Text));
            vTo = DateTime.Parse(Utility.fn_ConvertDate(txt_ValidTo.Text));
            sFrom = Convert.ToDouble(txt_SlabFrom.Text);
            sTo = Convert.ToDouble(txt_SlabTo.Text);
            obj_dt = obj_da_Detail.SelTaxslab(char.Parse(ddl_Category.SelectedValue.ToString()));
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
            DateTime dt_From, dt_To;
            decimal SlabFrom, SlabTo;
            dt_From = DateTime.Parse(Utility.fn_ConvertDate(txt_ValidFrom.Text));
            dt_To = DateTime.Parse(Utility.fn_ConvertDate(txt_ValidTo.Text));
            SlabFrom = decimal.Parse(txt_SlabFrom.Text);
            SlabTo = decimal.Parse(txt_SlabTo.Text);
            valid();
            if (flag == true)
            {
                ScriptManager.RegisterStartupScript(btn_Save, typeof(Button), "HRM", "alertify.alert('Not Able To Insert');", true);
                return;
            }
            else
            {
                if (btn_Save.ToolTip == "Save")
                {
                    DataTable obj_dt = new DataTable();
                    obj_dt = obj_da_Detail.InsTaxSlab(char.Parse(ddl_Category.SelectedValue.ToString()), double.Parse(txt_SlabFrom.Text), double.Parse(txt_SlabTo.Text), int.Parse(txt_Tax.Text), dt_From, dt_To, double.Parse(txt_charge.Text), double.Parse(txt_chess.Text));
                    if (obj_dt.Rows.Count > 0)
                    {
                        ScriptManager.RegisterStartupScript(btn_Save, typeof(Button), "HRM", "alertify.alert('Record Already Exist');", true);
                        return;
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(btn_Save, typeof(Button), "HRM", "alertify.alert('Details Saved');", true);
                        obj_da_Log.InsLogDetail(int.Parse(Session["LoginEmpId"].ToString()), 805, 1, int.Parse(Session["LoginBranchid"].ToString()), dt_From + "/" + dt_To + "/" + ddl_Category.SelectedValue.ToString() + "/S");
                    }
                }
                else if (btn_Save.ToolTip == "Update")
                {
                    obj_da_Detail.UpadTaxSlab(char.Parse(ddl_Category.SelectedValue.ToString()), double.Parse(txt_SlabFrom.Text), double.Parse(txt_SlabTo.Text), int.Parse(txt_Tax.Text), int.Parse(hid_Taxid.Value.ToString()), dt_From, dt_To, double.Parse(txt_charge.Text), double.Parse(txt_chess.Text));
                    ScriptManager.RegisterStartupScript(btn_Save, typeof(Button), "HRM", "alertify.alert('Details Updated');", true);
                    obj_da_Log.InsLogDetail(int.Parse(Session["LoginEmpId"].ToString()), 805, 2, int.Parse(Session["LoginBranchid"].ToString()), dt_From + "/" + dt_To + "/" + ddl_Category.SelectedValue.ToString() + "/U");
                }
                Fn_Clear();
                Grd_Tax.DataSource = Fn_LoadGrid();
                Grd_Tax.DataBind();
            }
           // btn_Clear.Text = "Cancel";

            btn_Clear.ToolTip = "Cancel";
            btn_Clear1.Attributes["class"] = "btn ico-cancel";

        }
        //private bool Fn_DateCheck(DateTime dt_From, DateTime dt_To, decimal SlabFrom, decimal SlabTo)
        //{
        //    bool Check = false;
        //    DataTable obj_dt = new DataTable();
        //    obj_dt = Fn_LoadGrid();
        //    int int_Count;
        //    var Result = obj_dt.AsEnumerable().Where(row => (DateTime.Parse(Utility.fn_ConvertDate(row.Field<string>("validfrom"))) == dt_From) && (DateTime.Parse(Utility.fn_ConvertDate(row.Field<string>("validto"))) == dt_To)).ToList();
        //    if (Result.Count > 0)
        //    {
        //       int_Count = obj_dt.AsEnumerable().Count(row => (DateTime.Parse(Utility.fn_ConvertDate(row.Field<string>("validfrom"))) == dt_From) && (DateTime.Parse(Utility.fn_ConvertDate(row.Field<string>("validto"))) == dt_To)
        //            && ((row.Field<decimal>("slabfrom") < SlabFrom && row.Field<decimal>("slabto") > SlabTo)
        //            || (row.Field<decimal>("slabfrom") > SlabFrom && row.Field<decimal>("slabto") < SlabTo)
        //            || (row.Field<decimal>("slabfrom") < SlabFrom && row.Field<decimal>("slabto") > SlabFrom)
        //            || (row.Field<decimal>("slabfrom") < SlabTo && row.Field<decimal>("slabto") > SlabTo)
        //            || (row.Field<decimal>("slabfrom") == SlabTo || row.Field<decimal>("slabto") == SlabTo)
        //            || (row.Field<decimal>("slabfrom") == SlabFrom || row.Field<decimal>("slabto") == SlabFrom))
        //            );
        //    }
        //    else
        //    {

        //        int_Count = obj_dt.AsEnumerable().Count(row => (DateTime.Parse(Utility.fn_ConvertDate(row.Field<string>("validfrom"))) < dt_From) && (DateTime.Parse(Utility.fn_ConvertDate(row.Field<string>("validto"))) > dt_From)
        //                || (DateTime.Parse(Utility.fn_ConvertDate(row.Field<string>("validfrom"))) < dt_To) && (DateTime.Parse(Utility.fn_ConvertDate(row.Field<string>("validto"))) > dt_To)
        //                || (DateTime.Parse(Utility.fn_ConvertDate(row.Field<string>("validfrom"))) > dt_From) && (DateTime.Parse(Utility.fn_ConvertDate(row.Field<string>("validto"))) < dt_To)
        //                || (DateTime.Parse(Utility.fn_ConvertDate(row.Field<string>("validfrom"))) < dt_From) && (DateTime.Parse(Utility.fn_ConvertDate(row.Field<string>("validto"))) > dt_To)
        //                || (DateTime.Parse(Utility.fn_ConvertDate(row.Field<string>("validfrom"))) == dt_From)
        //                || (DateTime.Parse(Utility.fn_ConvertDate(row.Field<string>("validto"))) == dt_From)
        //                || (DateTime.Parse(Utility.fn_ConvertDate(row.Field<string>("validfrom"))) == dt_To)
        //                || (DateTime.Parse(Utility.fn_ConvertDate(row.Field<string>("validto"))) == dt_To)
        //                );
        //    }

        //    if (int_Count > 0)
        //    {
        //        Check = false;
        //    }
        //    else
        //    {
        //        Check = true;
        //    }
        //    return Check;
        //}
        private bool Fn_DateCheck(DateTime dt_From, DateTime dt_To, decimal SlabFrom, decimal SlabTo)
        {
            bool Check = false;
            DataTable obj_dt = new DataTable();
            obj_dt = Fn_LoadGrid();
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
                    int_Count = Resultset.AsEnumerable().Count(row => int.Parse(row.Field<Int32>("taxid").ToString()) == int_Taxid
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
        protected void btn_Clear_Click(object sender, EventArgs e)
        {
            if (btn_Clear.ToolTip == "Cancel")
            {
              //  btn_Clear.Text = "Back";
                btn_Clear.ToolTip = "Back";
                btn_Clear1.Attributes["class"] = "btn ico-back";

                ddl_Category.SelectedIndex = 0;
                Fn_Clear();
            }
            else
            {
                this.Response.End();
            }
        }
        private void Fn_Clear()
        {
            Fn_LoadDate();
            txt_Tax.Text = "";
            txt_SlabFrom.Text = "";
            txt_SlabTo.Text = "";
            txt_charge.Text = "";
            txt_chess.Text = "";
            //btn_Save.Text = "Save";

            btn_Save.ToolTip = "Save";
            btn_Save1.Attributes["class"] = "btn ico-save";
            Grd_Tax.DataSource = new DataTable();
            Grd_Tax.DataBind();
            
        }

        protected void Grd_Tax_SelectedIndexChanged(object sender, EventArgs e)
        {
            hid_Taxid.Value = Grd_Tax.SelectedDataKey.Values[0].ToString();
            if (hid_confirm.Value.ToString() == "N")
            {
                ddl_Category.SelectedIndex = ddl_Category.Items.IndexOf(ddl_Category.Items.FindByValue(Grd_Tax.SelectedDataKey.Values[1].ToString()));
                txt_ValidFrom.Text = Grd_Tax.SelectedRow.Cells[0].Text;
                txt_ValidTo.Text = Grd_Tax.SelectedRow.Cells[1].Text;
                txt_SlabFrom.Text = Grd_Tax.SelectedRow.Cells[2].Text;
                txt_SlabTo.Text = Grd_Tax.SelectedRow.Cells[3].Text;
                txt_Tax.Text = Grd_Tax.SelectedRow.Cells[4].Text;
                txt_charge.Text = Grd_Tax.SelectedRow.Cells[5].Text;
                txt_chess.Text = Grd_Tax.SelectedRow.Cells[6].Text;
                //btn_Save.Text = "Update";

                btn_Save.ToolTip = "Update";
                btn_Save1.Attributes["class"] = "btn btn-update1";
                txt_Tax.Focus();
            }
            else if (hid_confirm.Value.ToString() == "Y")
            {
                obj_da_Detail.DelTaxSlab(int.Parse(hid_Taxid.Value.ToString()));
                string Str_Temp = txt_SlabFrom.Text + "-" + txt_SlabTo.Text + "-" + txt_Tax.Text + "-" + txt_charge.Text + "-" + txt_chess.Text + "/D";
                Fn_Clear();
                Grd_Tax.DataSource = Fn_LoadGrid();
                Grd_Tax.DataBind();
            }
           // btn_Clear.Text = "Cancel";


            btn_Clear.ToolTip = "Cancel";
            btn_Clear1.Attributes["class"] = "btn ico-cancel";
        }

        protected void btn_View_Click(object sender, EventArgs e)
        {
            string Str_sp = "", Str_sf = "", Str_RptName = "", Str_Script = "";
            Session["str_sfs"] = "";
            Session["str_sp"] = "";
            Str_RptName = "/Payroll/" + "RptTaxslab.rpt";
            if (ddl_Category.SelectedIndex == 0)
            {
                Str_sf = "{HREmpTaxSlab.validfrom}>=date(\"" + txt_ValidFrom.Text.Replace("/", ",") + "\") and {HREmpTaxSlab.validto}<=date(\"" + txt_ValidTo.Text.Replace("/", ",") + "\")";
            }
            else
            {
                Str_sf = "{HREmpTaxSlab.category} = \"" + ddl_Category.SelectedValue.ToString() + "\"";
            }
            Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_sf + "&Parameter=" + Str_sp + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
            ScriptManager.RegisterStartupScript(btn_View, typeof(Button), "HRM", Str_Script, true);
            Session["str_sfs"] = Str_sf;
            Session["str_sp"] = Str_sp;
           // btn_Clear.Text = "Cancel";


            btn_Clear.ToolTip = "Cancel";
            btn_Clear1.Attributes["class"] = "btn ico-cancel";
        }

        protected void Grd_Tax_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            for (int i = 0; i < e.Row.Cells.Count; i++)
            {
                if (e.Row.Cells[i].Text == "&nbsp;")
                {
                    e.Row.Cells[i].Text = "";
                }
                e.Row.Cells[i].ToolTip = e.Row.Cells[i].Text;
            }
            //e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(Grd_Tax, "Select$" + e.Row.RowIndex);
            //e.Row.Attributes["style"] = "cursor:pointer";
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

            obj_dtlogdetails = Logobj.InsTempGrpLogdtlsGet(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), 805, "Job", "", "", Session["StrTranType"].ToString());

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