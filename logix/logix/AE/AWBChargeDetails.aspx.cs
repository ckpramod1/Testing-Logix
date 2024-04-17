using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Diagnostics;
using System.Web.UI.WebControls.WebParts;
using System.Web.Services;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.Script.Services;

namespace logix.AE
{
    public partial class AWBChargeDetails : System.Web.UI.Page
    {
        DataAccess.AirImportExports.AIEBLDetails AEBLobj = new DataAccess.AirImportExports.AIEBLDetails();
        DataTable dt = new DataTable();
        DataTable DtAIEDetails = new DataTable();
        DataTable dtchrg = new DataTable();
        DataAccess.LogDetails LogObj = new DataAccess.LogDetails();
        int jobno, chargeid, chargeid2;
        string charge, charge1, ppcc;
        Double amount, amount1;
        int chargeid1;
        int count, i;

        string Ctrl_List;
        string Msg_List;
        string Dtype_List;
        string str_Uiid = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "SpanTagMoveInputBottom();MuiTextField();", true);

            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(btn_back);
            if (Session["LoginUserName"] == null || Session["LoginEmpId"] == null || Session["LoginDivisionId"] == null || Session["LoginBranchid"] == null)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alertify.alert('Session TimeOut');window.open('"+ Session["Site"].ToString() + "/','_top');", true);
            }
            else if (Session["StrTranType"] == null)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alertify.alert('Session TimeOut');window.open('"+ Session["Site"].ToString() + "/FormMain.aspx','_top');", true);
            }
            if(!IsPostBack)
            {
                try
                {
                    Ctrl_List = txt_hawb.ID + "~" + txt_job.ID;
                    Msg_List = "BLNO~JobNo";
                    Dtype_List = "string~string";
                    btn_save.Attributes.Add("onclick", "return IsValid('" + Ctrl_List + "','" + Msg_List + "','" + Dtype_List + "')");
                    Ctrl_List = txt_amt.ID;
                    Msg_List = "Amount";
                    Dtype_List = "string~string";
                    btn_add.Attributes.Add("OnClick", "return IsValid('" + Ctrl_List + "','" + Msg_List + "','" + Dtype_List + "')");
                    Utility.Fn_CheckUserRights(str_Uiid, btn_add, null, null);
                    txt_hawb.Focus();
                    btn_back.Text = "Cancel";

                    btn_back.ToolTip = "Cancel";
                    btn_back1.Attributes["class"] = "btn ico-cancel";

                    ChargeDetailsLoad();
                   // EmptyGrid_Charge();

                    if (Session["StrTranType"].ToString() == "AE")
                    {
                        HeaderLabel1.InnerText = "Air Exports";
                    }
                    else if (Session["StrTranType"].ToString() == "AI")
                    {
                        HeaderLabel1.InnerText = "Air Imports";
                    }
                }
                catch (Exception ex)
                {
                    string message = ex.Message.ToString();
                    ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
                }               
            }
            txt_amt.Attributes.Add("onkeypress", "return validateFloatKeyPress(this,event,'Amount')");
           // ChargeDetailsLoad();           
        }

        [WebMethod]
        public static List<string> GetAIEBLDetails(string prefix)
        {
            List<string> List_Result = new List<string>();
            string trantype = HttpContext.Current.Session["StrTranType"].ToString();
            int bid = Convert.ToInt32(HttpContext.Current.Session["LoginBranchid"].ToString());
            int did = Convert.ToInt32(HttpContext.Current.Session["LoginDivisionid"].ToString());
            DataAccess.AirImportExports.AIEBLDetails AEBLobj = new DataAccess.AirImportExports.AIEBLDetails();
            DataTable dt = new DataTable();
          //  dt = AEBLobj.GetLikeOTHERAIEBLDetails(prefix, trantype, bid, did);
            dt = AEBLobj.GetLikeAIEBLDetails(prefix, trantype, bid, did);
            List_Result = Utility.Fn_TableToList(dt, "hawblno", "hawblno");
            return List_Result;
        }

        private void EmptyGrid_Charge()
        {
            DataTable dtempty = new DataTable();
            //dtempty.Columns.Add();
            dtempty.Columns.Add("charges");
            dtempty.Columns.Add("amount");
            dtempty.Columns.Add("ppcc");
            dtempty.Columns.Add("chargeid");
            dtempty.Rows.Add(dtempty.NewRow());
            //Grd_sb.RowStyle.Width = 20;
            Grd_Charge.DataSource = dtempty;
            Grd_Charge.DataBind();
            Grd_Charge.Rows[0].Visible = false;
        }

        private void ChargeDetailsLoad()
        {
            //ddl_charge.Items.Add("");
            ddl_charge.Items.Add("Valuation Charge");
            ddl_charge.Items.Add("Total Other Charges Due Agent");
            ddl_charge.Items.Add("Total Other Charges Due Carrier");
            ddl_pc.Items.Add("Prepaid");
            //ddl_pc.Items.Add("To-Collect");
            ddl_pc.Items.Add("Collect");
        }

        protected void txt_hawb_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string trantype = HttpContext.Current.Session["StrTranType"].ToString();
                int bid = Convert.ToInt32(HttpContext.Current.Session["LoginBranchid"].ToString());
                int did = Convert.ToInt32(HttpContext.Current.Session["LoginDivisionid"].ToString());
                DtAIEDetails = AEBLobj.GetAIEDetail(txt_hawb.Text, trantype, bid, did);
                if (txt_hawb.Text != "")
                {
                    if (DtAIEDetails.Rows.Count > 0)
                    {
                        txt_bldate.Text = Utility.fn_ConvertDate(DtAIEDetails.Rows[0]["issuedon"].ToString());
                        txt_job.Text = DtAIEDetails.Rows[0]["jobno"].ToString();
                        jobno = Convert.ToInt32(txt_job.Text);

                        if (DtAIEDetails.Rows[0]["accinfo"].ToString() != "")
                        {
                            txt_acc.Text = DtAIEDetails.Rows[0]["accinfo"].ToString();
                        }
                    }

                    dtchrg = AEBLobj.SelAEBLChargeDtls(jobno, txt_hawb.Text, bid);


                    if (dtchrg.Rows.Count > 0)
                    {
                        string Cname = "";
                        double strAmount;
                        string PPCcVal;


                        

                        EmptyGrid_Charge();
                        DataTable dttemp2 = new DataTable();
                        dttemp2.Columns.Add("charges");
                        dttemp2.Columns.Add("amount");
                        dttemp2.Columns.Add("ppcc");
                        dttemp2.Columns.Add("chargeid");

                        DataRow dr1;
                        for (int i = 0; i <= dtchrg.Rows.Count-1; i++)
                        {
                            chargeid1 = Convert.ToInt32(dtchrg.Rows[i]["chargeid"]);
                            if (chargeid1 == 1)
                            {
                                Cname = "Valuation Charge";
                            }
                            else if (chargeid1 == 2)
                            {
                                Cname = "Total Other Charges Due Agent";
                            }
                            else if (chargeid1 == 3)
                            {
                                Cname = "Total Other Charges Due Carrier";
                            }

                            strAmount = Convert.ToDouble( dtchrg.Rows[i]["amount"].ToString());
                            ppcc = dtchrg.Rows[i]["ppcc"].ToString();

                            if (ppcc == "P")
                            {
                                PPCcVal = "Prepaid";

                            }
                            else
                            {
                                PPCcVal = "To-Collect";
                            } 
                            dr1 = dttemp2.NewRow();
                            dr1[0] = Cname;
                            dr1[1] = strAmount.ToString("#,0.00");
                            dr1[2] = PPCcVal;
                            dr1[3] = chargeid1;

                            dttemp2.Rows.Add(dr1);
                        }
                        
                        Grd_Charge.DataSource = dttemp2;
                        Grd_Charge.DataBind();

                        ViewState["CurrentData"] = dttemp2;
                        btn_save.Text = "Update";

                        btn_save.ToolTip = "Update";
                        btn_save1.Attributes["class"] = "btn ico-update";
                       

                    }


                }
                btn_back.Text = "Cancel";
                btn_back.ToolTip = "Cancel";
                btn_back1.Attributes["class"] = "btn ico-cancel";
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        protected void btn_save_Click(object sender, EventArgs e)
        {
            try
            {
                //if (ddl_charge.SelectedIndex == 0)
                //{
                //    ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "DataFound", "alertify.alert('Select Charge');", true);
                //    ddl_charge.Focus();
                //    return;
                //}
                //if (ddl_pc.SelectedIndex == 0)
                //{
                //    ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "DataFound", "alertify.alert('Select Pc');", true);
                //    ddl_pc.Focus();
                //    return;
                //}


               
                if (txt_acc.Text == "")
                {
                    ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "DataFound", "alertify.alert('Enter Acc');", true);
                    txt_acc.Focus();
                    return;
                }
                string trantype = HttpContext.Current.Session["StrTranType"].ToString();
                int bid = Convert.ToInt32(HttpContext.Current.Session["LoginBranchid"].ToString());
                int did = Convert.ToInt32(HttpContext.Current.Session["LoginDivisionid"].ToString());
                int empid = Convert.ToInt32(HttpContext.Current.Session["LoginEmpId"].ToString());
                if (txt_hawb.Text != "" && txt_job.Text != "")
                {
                    jobno = Convert.ToInt32(txt_job.Text);
                    if (txt_acc.Text != "")
                    {
                        AEBLobj.UpdAccInfo4febl(jobno, txt_hawb.Text, bid, txt_acc.Text);
                    }
                    if (btn_save.ToolTip == "Save")
                    {
                        if (Grd_Charge.Rows.Count > 0)
                        {
                            for (int i = 0; i < Grd_Charge.Rows.Count; i++)
                            {
                                if (Grd_Charge.Rows[i].Cells[2].Text == "Prepaid")
                                {
                                    ppcc = "P";
                                }
                                else
                                {
                                    ppcc = "C";
                                }
                                chargeid1 = Convert.ToInt32(Grd_Charge.Rows[i].Cells[3].Text);
                                amount1 = Convert.ToDouble(Grd_Charge.Rows[i].Cells[1].Text);
                                AEBLobj.InsAEBLChargeDtls(jobno, chargeid1, amount1, ppcc, txt_hawb.Text, bid);
                                LogObj.InsLogDetail(empid, 1262, 1, bid, "AWBChrg-" + txt_job.Text + "/" + txt_hawb.Text + "/" + Grd_Charge.Rows[i].Cells[3].Text + "/" + Grd_Charge.Rows[i].Cells[1].Text + "/" + ppcc);
                            }
                            ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "DataFound", "alertify.alert('Details Saved');", true);

                            btn_save.Text = "Update";
                            btn_back.Text = "Cancel";

                            btn_save.ToolTip = "Update";
                            btn_save1.Attributes["class"] = "btn ico-update";
                            btn_back.ToolTip = "Cancel";
                            btn_back1.Attributes["class"] = "btn ico-cancel";

                        }
                        ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "DataFound", "alertify.alert('Some Details are misssing');", true);

                    }
                    else if (btn_save.ToolTip == "Update")
                    {
                        AEBLobj.DelAEBLChargeDtls(jobno, txt_hawb.Text, bid);
                        if (Grd_Charge.Rows.Count > 0)
                        {
                            for (int i = 0; i < Grd_Charge.Rows.Count; i++)
                            {
                                if (Grd_Charge.Rows[i].Cells[2].Text == "Prepaid")
                                {
                                    ppcc = "P";
                                }
                                else
                                {
                                    ppcc = "C";
                                }

                                chargeid1 = Convert.ToInt32(Grd_Charge.Rows[i].Cells[3].Text);
                                amount1 = Convert.ToDouble(Grd_Charge.Rows[i].Cells[1].Text);
                                AEBLobj.InsAEBLChargeDtls(jobno, chargeid1, amount1, ppcc, txt_hawb.Text, bid);
                                LogObj.InsLogDetail(empid, 1262, 2, bid, "AWBChrg-" + txt_job.Text + "/" + txt_hawb.Text + "/" + Grd_Charge.Rows[i].Cells[3].Text + "/" + Grd_Charge.Rows[i].Cells[1].Text + "/" + ppcc);

                            }
                            ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "DataFound", "alertify.alert('Details Updated');", true);
                            btn_save.Text = "Update";
                            btn_back.Text = "Cancel";
                            btn_save.ToolTip = "Update";
                            btn_save1.Attributes["class"] = "btn ico-update";

                            btn_back.ToolTip = "Cancel";
                            btn_back1.Attributes["class"] = "btn ico-cancel";


                        }
                        ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "DataFound", "alertify.alert('Some Details are misssing');", true);
                    }
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }


        private void BindGrid(int rowcount, string Chgnameame, string cuAmount,string ppccval,int chargeid)
        {
            
            DataTable dt = new DataTable();
            DataRow dr;
            dt.Columns.Add(new System.Data.DataColumn("charges", typeof(String)));
            dt.Columns.Add(new System.Data.DataColumn("amount", typeof(String)));
            dt.Columns.Add(new System.Data.DataColumn("ppcc", typeof(String)));
            dt.Columns.Add(new System.Data.DataColumn("chargeid", typeof(String)));

            if (ViewState["CurrentData"] != null)
            {

                ImageButton btndelete = new ImageButton();
                foreach (GridViewRow row in Grd_Charge.Rows)
                {
                    btndelete = (ImageButton)row.FindControl("imgdelete");
                    btndelete.Visible = true;

                }
                
                    dt = (DataTable)ViewState["CurrentData"];
                    
                    if (dt.Rows.Count > 0)
                    {
                        dr = dt.NewRow();
                        dr[0] = dt.Rows[0][0].ToString();
                    }
                


                dr = dt.NewRow();
                dr[0] = ddl_charge.SelectedValue;
                double temp = Convert.ToDouble(txt_amt.Text);
                dr[1] = temp.ToString("#,0.00");
               // dr[1] =Convert.t (txt_amt.Text.ToString("#,0.00"));
                dr[2] = ddl_pc.SelectedValue;
                dr[3] = chargeid;

                dt.Rows.Add(dr);
                ViewState["CurrentData"] = dt;
            }
            else
            {
                dr = dt.NewRow();
                dr[0] = ddl_charge.SelectedValue;
                double temp=Convert.ToDouble(txt_amt.Text);
                dr[1] = temp.ToString("#,0.00");
                dr[2] = ddl_pc.SelectedValue;
                dr[3] = chargeid;

                dt.Rows.Add(dr);
                ViewState["CurrentData"] = dt;
            }

            if (ViewState["CurrentData"] != null)
            {
                Grd_Charge.DataSource = (DataTable)ViewState["CurrentData"];
                Grd_Charge.DataBind();
            }
            else
            {
                Grd_Charge.DataSource = dt;
                Grd_Charge.DataBind();

            }

            ViewState["CurrentData"] = dt;

        }

        protected void btn_add_Click(object sender, EventArgs e)
        {
            string a, b;
            if (ddl_charge.SelectedIndex != -1 && txt_amt.Text != "" && ddl_pc.SelectedIndex != -1 && txt_amt.Text!="0")
            {
                    if (ddl_charge.SelectedValue == "Valuation Charge")
                    {
                        chargeid = 1;
                    }
                    else if (ddl_charge.SelectedValue == "Total Other Charges Due Agent")
                    {
                        chargeid = 2;
                    }
                    else if (ddl_charge.SelectedValue == "Total Other Charges Due Carrier")
                    {
                        chargeid = 3;
                    }

                if (btn_add.ToolTip == "Add")
                {
                    if(Grd_Charge.Rows.Count >0)
                    {
                        count = 0;
                        for(i=0;i<=Grd_Charge.Rows.Count-1;i++)
                        {
                            a = Grd_Charge.Rows[i].Cells[0].Text.ToString();
                            b = Grd_Charge.Rows[i].Cells[2].Text.ToString();
                            if (ddl_charge.SelectedValue == Grd_Charge.Rows[i].Cells[0].Text .ToString()  && ddl_pc.SelectedValue == Grd_Charge.Rows[i].Cells[2].Text .ToString())
                            {
                                count = count + 1;
                            }
                        }
                    }

                    if(count >= 1)
                    {
                        ScriptManager.RegisterStartupScript(btn_add, typeof(Button), "DataFound", "alertify.alert('Details already exist');", true);
                        txt_amt.Text = "";
                        ddl_charge.SelectedValue = "Valuation Charge";
                        ddl_pc.SelectedValue = "Prepaid";
                        return;
                    }


                    if (ViewState["CurrentData"] != null)
                    {
                        DataTable dt = (DataTable)ViewState["CurrentData"];
                        int countval = dt.Rows.Count;
                        BindGrid(countval, ddl_charge.SelectedValue, txt_amt.Text.ToUpper().Trim(), ddl_pc.SelectedValue, chargeid);
                        txt_amt.Text = "";
                        ddl_charge.SelectedValue = "Valuation Charge";
                        ddl_pc.SelectedValue = "Prepaid";
                        btn_back.Text = "Cancel";

                        btn_back.ToolTip = "Cancel";
                        btn_back1.Attributes["class"] = "btn ico-cancel";

                    }

                    else
                    {
                        BindGrid(1, ddl_charge.SelectedValue, txt_amt.Text.ToUpper().Trim(), ddl_pc.SelectedValue, chargeid);
                        txt_amt.Text = "";
                        ddl_charge.SelectedValue = "Valuation Charge";
                        ddl_pc.SelectedValue = "Prepaid";
                        btn_add.Text = "Add";
                        btn_back.Text = "Cancel";
                        btn_add.ToolTip = "Add";
                        btn_addn1.Attributes["class"] = "btn ico-add";
                        btn_back.ToolTip = "Cancel";
                        btn_back1.Attributes["class"] = "btn ico-cancel";

                    }
                }
                else
                {
                    if (btn_add.ToolTip == "Update")
                    {
                        
                        int  rowval =Convert.ToInt32(Session["Rowindex"].ToString());
                        Grd_Charge.Rows[rowval].Cells[0].Text = ddl_charge.SelectedValue;
                        Grd_Charge.Rows[rowval].Cells[1].Text = txt_amt.Text;
                        Grd_Charge.Rows[rowval].Cells[2].Text = ddl_pc.SelectedValue;

                        if (Grd_Charge.Rows[rowval].Cells[0].Text == "Valuation Charge")
                        {
                            chargeid = 1;
                        }
                        else if (Grd_Charge.Rows[rowval].Cells[0].Text == "Total Other Charges Due Agent")
                        {
                            chargeid = 2;
                        }
                        else if (Grd_Charge.Rows[rowval].Cells[0].Text == "Total Other Charges Due Carrier")
                        {
                            chargeid = 3;
                        }
                        //BindGrid(rowval, ddl_charge.SelectedValue, txt_amt.Text.ToUpper().Trim(), ddl_pc.SelectedValue, chargeid);
                        Grd_Charge.Rows[rowval].Cells[3].Text = chargeid.ToString(); ;
                        btn_add.Text = "Add";
                        btn_back.Text = "Cancel";


                        btn_add.ToolTip = "Add";
                        btn_addn1.Attributes["class"] = "btn ico-add";
                        btn_back.ToolTip = "Cancel";
                        btn_back1.Attributes["class"] = "btn ico-cancel";

                    }
                
                }

            }

            txt_amt.Text = "";
            ddl_charge.SelectedValue = "Valuation Charge";
            ddl_pc.SelectedValue = "Prepaid";


        }


        protected void btn_back_Click(object sender, EventArgs e)
        {
            if(btn_back.ToolTip=="Cancel")
            {
                JobInput.Text = "";

            Load_text();
            btn_add.Text = "Add";
            btn_save.Text = "Save";
            btn_back.Text = "Back";

            btn_add.ToolTip = "Add";
            btn_addn1.Attributes["class"] = "btn ico-add";

            btn_save.ToolTip = "Save";
            btn_save1.Attributes["class"] = "btn ico-save";

            btn_back.ToolTip = "Back";
            btn_back1.Attributes["class"] = "btn ico-back";


            ViewState["CurrentData"] = null;
            Grd_Charge.DataSource = new DataTable();
            Grd_Charge.DataBind();
            }
            else
            {
               // this.Response.End();
                if (Session["home"] != null)
                {
                    if (Session["home"].ToString() == "OPS&DOC")
                    {
                        Response.Redirect("../Home/OEOpsAndDocs.aspx");

                    }
                    else
                    {
                        this.Response.End();
                    }
                }
                else
                {
                    this.Response.End();
                }
            }

        }
        private void Load_text()
        {
            txt_hawb.Text = "";
            txt_bldate.Text = "";
            txt_job.Text = "";
            txt_acc.Text = "";
            ddl_charge.SelectedIndex = -1;
            txt_amt.Text = "";
            ddl_pc.SelectedIndex = -1;
            //if (Grd_Charge.Rows.Count > 0) EmptyGrid_Charge();

            Grd_Charge.DataSource = Utility.Fn_GetEmptyDataTable();
            Grd_Charge.DataBind();
                }      

       

        protected void Grd_Charge_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(Grd_Charge, "Select$" + e.Row.RowIndex);\
                e.Row.Attributes.Add("onmouseover", "this.originalcolor=this.style.backgroundColor;" + " this.style.backgroundColor='#FDCB0A';");
                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalcolor;");
                e.Row.Attributes["style"] = "cursor:pointer";
            }
        }


        protected void imgdelete_Click(object sender, ImageClickEventArgs e)
        {
            ImageButton lb = (ImageButton)sender;
            GridViewRow gvRow = (GridViewRow)lb.NamingContainer;
            int rowID = gvRow.RowIndex;
            Session["Rowindex"] = rowID;
            if (hfWasConfirmed.Value == "true")
            {
                if (ViewState["CurrentData"] != null)
                {
                    DataTable dt = (DataTable)ViewState["CurrentData"];
                    if (dt.Rows.Count > 0)
                    {
                        if (gvRow.RowIndex < dt.Rows.Count)
                        {

                            dt.Rows.Remove(dt.Rows[rowID]);
                            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "logix", "alertify.alert('Details Deleted from Grid ,Plz click again updated Button...');", true);
                        }
                        ddl_charge.SelectedIndex = -1;
                        ddl_pc.SelectedIndex = -1;
                        txt_amt.Text = "";
                        btn_add.Text = "Add";
                        btn_add.ToolTip = "Add";
                        btn_addn1.Attributes["class"] = "btn ico-add";

                    }

                    ViewState["CurrentData"] = dt;
                    Grd_Charge.DataSource = dt;
                    Grd_Charge.DataBind();
                    if (Grd_Charge.Rows.Count == 0)
                    {
                        EmptyGrid_Charge();
                    }
                    if(Grd_Charge.Rows.Count>0)
                    {
                       
                        btn_save.Text = "Save";

                        btn_save.ToolTip = "Save";
                        btn_save1.Attributes["class"] = "btn ico-save";
                    }
                }
            }
            else
            {
                if (Grd_Charge.Rows.Count > 0)
                {
                    ddl_charge.SelectedValue = Grd_Charge.Rows[rowID].Cells[0].Text;
                    txt_amt.Text = Grd_Charge.Rows[rowID].Cells[1].Text;
                    ddl_pc.SelectedValue = Grd_Charge.Rows[rowID].Cells[2].Text;
                    btn_add.Text = "Update";
                    btn_back.Text = "Cancel";
                    btn_add.ToolTip = "Update";
                    btn_addn1.Attributes["class"] = "btn ico-Update";

                    btn_back.ToolTip = "Cancel";
                    btn_back1.Attributes["class"] = "btn ico-cancel";
                }
            }
            btn_save.Text = "Update";
            btn_save.ToolTip = "Update";
            btn_save1.Attributes["class"] = "btn ico-update";
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

            obj_dtlogdetails = LogObj.InsTempGrpLogdtlsGet(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), 1262, "AWBCHRG", txt_hawb.Text, txt_hawb.Text, "");  //"/Rate ID: " +
            if (txt_hawb.Text != "")
            {
                JobInput.Text = txt_hawb.Text;
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