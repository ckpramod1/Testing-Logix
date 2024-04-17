using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.Services;
using System.Configuration;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace logix.AI
{
    public partial class AICAN : System.Web.UI.Page
    {
        string str_Uiid = "";

        DataAccess.AirImportExports.AICAN da_obj_AiCanObj = new DataAccess.AirImportExports.AICAN();
        DataAccess.LogDetails da_obj_logobj = new DataAccess.LogDetails();
        DataAccess.LogDetails obj_da_log = new DataAccess.LogDetails();
        DataAccess.ForwardingImports.JobInfo obj_da_fijob = new DataAccess.ForwardingImports.JobInfo();
        DataAccess.ForwardingImports.CAN obj_da_can = new DataAccess.ForwardingImports.CAN();

       
        DataAccess.ForwardingImports.BLDetails obj_da_bldetails = new DataAccess.ForwardingImports.BLDetails();
        DataAccess.ForwardingImports.BLDetails bldetailsobj = new DataAccess.ForwardingImports.BLDetails();
        DataAccess.Masters.MasterCustomer CustObj = new DataAccess.Masters.MasterCustomer();
        DataAccess.Message4Booking obj_da_msg = new DataAccess.Message4Booking();
        DataAccess.ForwardingExports.BLDetails obj_da_BL = new DataAccess.ForwardingExports.BLDetails();
        protected void Page_Load(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "SpanTagMoveInputBottom();MuiTextField();", true);

            string Ccode = Convert.ToString(Session["Ccode"]);

            if (Ccode != "")
            {

                da_obj_AiCanObj.GetDataBase(Ccode);
                da_obj_logobj.GetDataBase(Ccode);
                obj_da_fijob.GetDataBase(Ccode);
                obj_da_can.GetDataBase(Ccode);
                obj_da_bldetails.GetDataBase(Ccode);
                bldetailsobj.GetDataBase(Ccode);


                CustObj.GetDataBase(Ccode);
                obj_da_msg.GetDataBase(Ccode);
                obj_da_BL.GetDataBase(Ccode);


            }

            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(btn_back);
            if (Session["LoginUserName"] == null || Session["LoginEmpId"] == null || Session["LoginDivisionId"] == null || Session["LoginBranchid"] == null)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alertify.alert('Session TimeOut');window.open('"+ Session["Site"].ToString() + "/','_top');", true);
            }
            else if (Session["StrTranType"] == null)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alertify.alert('Session TimeOut');window.open('"+ Session["Site"].ToString() + "/FormMain.aspx','_top');", true);
            }

            if (IsPostBack != true)
            {
               txt_Jobno.Focus(); 
                txtclear();
                //lblheader.Text = Request.QueryString["type"].ToString();

                btn_back.Text = "Cancel";
                btn_back.ToolTip = "Cancel";
                btn_back2.Attributes["class"] = "btn ico-cancel";
                // Utility.Fn_CheckUserRights(str_Uiid, null, btn_print, null);
                grd_bLdtls.DataSource = new DataTable();
                grd_bLdtls.DataBind();
                if (Session["StrTranType"].ToString() == "AI")
                {
                    HeaderLabel1.InnerText = "Air Imports";
                }
            }
            txt_Jobno.Attributes.Add("OnKeypress", "return IntegerCheck(event);");
        }
        protected void lbl_lnkrate_Click(object sender, EventArgs e)
        {
            try
            {
                //DataAccess.AirImportExports.AICAN da_obj_AiCanObj = new DataAccess.AirImportExports.AICAN();
                DataTable Dt_new = new DataTable();
                Dt_new = da_obj_AiCanObj.GetDetails(Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()));
                if (Dt_new.Rows.Count > 0)
                {
                    Grd_buying_popup.Show();
                    grd_CAN.DataSource = Dt_new;
                    grd_CAN.DataBind();

                }
                else
                {
                    ScriptManager.RegisterStartupScript(lbl_lnkrate, typeof(LinkButton), "JobInfo", "alertify.alert('Job Not Available');", true);
                    return;
                }
                btn_back.Text = "Cancel";
                btn_back.ToolTip = "Cancel";
                btn_back2.Attributes["class"] = "btn ico-cancel";
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }


        }

        protected void grd_CAN_SelectedIndexChanged(object sender, EventArgs e)
        {
            int int_index;
            int_index = grd_CAN.SelectedRow.RowIndex;
            //hf_rateid.Value = grd_CAN.Rows[int_index].Cells[0].Text.ToString();
            txt_Flight.Text = grd_CAN.Rows[int_index].Cells[1].Text.ToString();
            txt_Jobno.Text = grd_CAN.Rows[int_index].Cells[0].Text.ToString();
            txt_dtFDate.Text = grd_CAN.Rows[int_index].Cells[2].Text.ToString();
            txt_Agent.Text = grd_CAN.Rows[int_index].Cells[3].Text.ToString();
            txt_AirLine.Text = grd_CAN.Rows[int_index].Cells[4].Text.ToString();
            txt_PoL.Text = grd_CAN.Rows[int_index].Cells[5].Text.ToString();
            txt_PoD.Text = grd_CAN.Rows[int_index].Cells[6].Text.ToString();
            //grdCollapse()
        }

        protected void btn_print_Click(object sender, EventArgs e)
        {
            //DataAccess.AirImportExports.AICAN da_obj_AiCanObj = new DataAccess.AirImportExports.AICAN();
            //DataAccess.LogDetails da_obj_logobj = new DataAccess.LogDetails();
            string str_sf = "";
            string str_RptName = "";
            string str_frmname = "";
            string str_Script = "";
            string str_BL;
            Session["str_sfs"] = "";
            Session["str_sp"] = "";
            string str_sp = "";
            string direct="N";
            if (!string.IsNullOrEmpty(txt_Jobno.Text))
            {
                try
                {
                    DataTable Dt = new DataTable();
                    if (chk_directbl.Checked == true)
                    {
                        direct = "Y";
                    }
                    else
                    {
                          direct = "N";
                    }
                    
                    str_sp = "IGM=" + direct;
                    da_obj_AiCanObj.UpdateCANDate(Convert.ToDateTime(Utility.fn_ConvertDate(txt_dtCANDate.Text)), Convert.ToInt32(txt_Jobno.Text), Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()));
                    Dt = da_obj_AiCanObj.GetBLDetails(Convert.ToInt32(txt_Jobno.Text), "AI", Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()));
                    if (Dt.Rows.Count > 0)
                    {
                        for (int i = 0; i <= Dt.Rows.Count - 1; i++)
                        {                            
                            str_BL = Dt.Rows[i][1].ToString();
                            str_frmname = "Cargo Arrival Notice";
                            str_RptName = "AICAN.rpt";
                           // str_sf = "{AIBLDetails.hawblno}=" + str_BL + " and " + "{AIBLDetails.bid}=" + Convert.ToInt32(Session["LoginBranchid"].ToString());
                           // Session["str_sfs"] = "{AIBLDetails.hawblno}='" + str_BL + "' and " + "{AIBLDetails.bid}=" + Convert.ToInt32(Session["LoginBranchid"].ToString());
                           // Session["str_sfs"] = "{AIBLDetails.hawblno}='" + str_BL + "' and " + "{AIBLDetails.bid}=" + Convert.ToInt32(Session["LoginBranchid"].ToString());
                            str_sf = "{AIBLDetails.hawblno}=\"" + str_BL + "\" and " + "{AIBLDetails.bid}=" + Convert.ToInt32(Session["LoginBranchid"].ToString());
                            //str_Script += "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                            str_Script += "window.open('../Reportasp/AICANRpt.aspx?hawblno=" + str_BL + "&bid=" + Convert.ToInt32(Session["LoginBranchid"].ToString()) + "&directbl=" + direct + "&" + this.Page.ClientQueryString + "','','');";

                            da_obj_logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"].ToString()), 125, 3, Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToString(str_BL) + "&View");
                           // Session["str_sfs"] = "{AIBLDetails.hawblno}='" + str_BL + "' and " + "{AIBLDetails.bid}=" + Convert.ToInt32(Session["LoginBranchid"].ToString());
                            Session["str_sp"] = str_sp;
                        }
                        
                        ScriptManager.RegisterStartupScript(btn_print, typeof(Button), "AICAN", str_Script, true);    
                    }
                    btn_back.Text = "Cancel";
                    btn_back.ToolTip = "Cancel";
                    btn_back2.Attributes["class"] = "btn ico-cancel";
                }
                catch (Exception ex)
                {
                    string message = ex.Message.ToString();
                    ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
                }
            }
        }

        public void txtclear()
        {
          //  DataAccess.LogDetails da_obj_logobj = new DataAccess.LogDetails();
            txt_Flight.Text = "";
            txt_Jobno.Text = "";
            txt_dtFDate.Text = Utility.fn_ConvertDate(da_obj_logobj.GetDate().ToString());
            txt_dtCANDate.Text = Utility.fn_ConvertDate(da_obj_logobj.GetDate().ToString());
            txt_Agent.Text = "";
            txt_AirLine.Text = "";
            txt_PoL.Text = "";
            txt_PoD.Text = "";
            btn_back.Text = "Back";
            btn_back.ToolTip = "Back";
            btn_back2.Attributes["class"] = "btn ico-back";

        }

        protected void btn_back_Click(object sender, EventArgs e)
        {
            if (btn_back.ToolTip == "Cancel")
            {
                txtclear();
                txt_Jobno.Focus(); 
            }
               
            else
            {
               // this.Response.End();

                if (Session["home"] != null)
                {
                    if (Session["home"].ToString() == "CS")
                    {
                        if (Session["StrTranType"] != null)
                        {
                            if (Session["StrTranType"].ToString() == "AI")
                            {
                                Response.Redirect("../Home/AICSHome.aspx");
                            }

                        }
                    }
                }
                else
                {
                    this.Response.End();
                }
            }
        }

        protected void grd_CAN_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes.Add("onmouseover", "this.originalcolor=this.style.backgroundColor;" + " this.style.backgroundColor='#FDCB0A';");
                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalcolor;");

                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(grd_CAN, "Select$" + e.Row.RowIndex);
                e.Row.Attributes["style"] = "cursor:pointer";
            }
        }

        protected void btn_canprfrma_Click(object sender, EventArgs e)
        {
            fn_btncanprfrma_Click();
        }

        public void fn_btncanprfrma_Click()
        {
            DataTable obj_dtcan = new DataTable();
            DataTable obj_dt = new DataTable();

            DataTable obj_dtcannew = new DataTable();
            //DataAccess.LogDetails obj_da_log = new DataAccess.LogDetails();
            //DataAccess.ForwardingImports.JobInfo obj_da_fijob = new DataAccess.ForwardingImports.JobInfo();
            //DataAccess.ForwardingImports.CAN obj_da_can = new DataAccess.ForwardingImports.CAN();

            //DataAccess.AirImportExports.AICAN da_obj_AiCanObj = new DataAccess.AirImportExports.AICAN();
            //DataAccess.ForwardingImports.BLDetails obj_da_bldetails = new DataAccess.ForwardingImports.BLDetails();
            // obj_da_can.UpdateCANDate(Convert.ToDateTime(Utility.fn_ConvertDatetime(txt_candate.Text.ToString())), Convert.ToInt32(txt_Jobno.Text.ToString()), Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(Session["LoginDivisionId"]));

            string str_Script = "";
            obj_dtcan = da_obj_AiCanObj.GetBLDetails(Convert.ToInt32(txt_Jobno.Text.ToString()), "AI", Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(Session["LoginDivisionId"]));


            if (obj_dtcan.Rows.Count > 0)
            {
                foreach (GridViewRow row in grd_bLdtls.Rows)
                {
                    string str_frmname = "";
                    string str_RptName = "";
                    string str_sp = "";
                    string str_sf = "";
                    string exp = "";

                    Session["str_sfs"] = "";
                    Session["str_sp"] = "";
                    int index = 0;
                    index = row.RowIndex;
                    CheckBox cb = (CheckBox)row.FindControl("chk_select");
                    if (cb.Checked == true)
                    {
                        hf_BL.Value = obj_dtcan.Rows[index][1].ToString();
                        obj_dtcannew = da_obj_AiCanObj.Getcanpromachek(hf_BL.Value, Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString());

                        if (obj_dtcannew.Rows.Count > 0)
                        {
                            if (rbtn_cnsg.Checked == true)
                            {
                                str_frmname = "Cargo Arrival Notice";
                                str_RptName = "FICanInvoice4ConsigneeAI.rpt";
                                //Session["str_sfs"] = "{AIBLDetails.bid}=" + Convert.ToInt32(Session["LoginBranchid"]) + " and {AIBLDetails.hawblno}=\"" + hf_BL.Value + "\"";
                                str_sf = "{AIBLDetails.bid}=" + Convert.ToInt32(Session["LoginBranchid"]) + " and {AIBLDetails.hawblno}=\"" + hf_BL.Value + "\"";
                                //Session["str_sp"] = "cont1=" + "" + "~cont2=" + "";
                               // string pageurl = "../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "";
                                str_Script += "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&exp=" + exp + "&" + this.Page.ClientQueryString + "','_blank'); ";
                                
                                obj_da_log.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 125, 3, Convert.ToInt32(Session["LoginBranchid"]), txt_Jobno.Text.ToString());
                                // Session["str_sfs"] = str_sf;
                                //  Session["str_sp"] = str_sp;
                                // btn_canprfrma.Attributes.Add("onclick", "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "', '', 'menubar=1,resizable=1,fullscreen=no, scrollbars=auto')");
                                //ScriptManager.RegisterStartupScript(Page, Page.GetType(), "popup", str_Script, true);
                            }
                            else if (rbtn_forwarder.Checked == true)
                            {
                                str_frmname = "Cargo Arrival Notice";
                                str_RptName = "FICanInvoice4ForwarderAI.rpt";
                                Session["str_sfs"] = "{AIBLDetails.bid}=" + Convert.ToInt32(Session["LoginBranchid"]) + " and {AIBLDetails.hawblno}=\"" + hf_BL.Value + "\"";
                                Session["str_sp"] = "cont1=" + "" + "~cont2=" + "";
                               // string pageurl = "../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "";
                                str_Script += "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&exp=" + exp + "&" + this.Page.ClientQueryString + "','_blank'); ";
                                
                                obj_da_log.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 125, 3, Convert.ToInt32(Session["LoginBranchid"]), txt_Jobno.Text.ToString());
                                //Session["str_sfs"] = str_sf;
                                //Session["str_sp"] = str_sp;
                                //logixTouch.CommanClass.
                            }
                            else if (rbtn_ntfyparty.Checked == true)
                            {
                                str_frmname = "Cargo Arrival Notice";
                                str_RptName = "FICanInvoice4NPAI.rpt";
                                //Session["str_sfs"] = "{AIBLDetails.bid}=" + Convert.ToInt32(Session["LoginBranchid"]) + " and {AIBLDetails.hawblno}=\"" + hf_BL.Value + "\"";

                                str_sf = "{AIBLDetails.bid}=" + Convert.ToInt32(Session["LoginBranchid"]) + " and {AIBLDetails.hawblno}=\"" + hf_BL.Value + "\"";
                                //Session["str_sp"] = "cont1=" + "" + "~cont2=" + "";
                              //  string pageurl = "../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "";
                                str_Script += "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&exp=" + exp + "&" + this.Page.ClientQueryString + "','_blank'); ";
                                //logixTouch.Tools.ReportView.
                                obj_da_log.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 125, 3, Convert.ToInt32(Session["LoginBranchid"]), txt_Jobno.Text.ToString());
                                //Session["str_sfs"] = str_sf;
                                //Session["str_sp"] = str_sp;
                                btn_canprfrma.Attributes.Add("onclick", "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "', '', '', 'height=200,width=400'");
                            }
                            else if (rbtn_dirctcnsg.Checked == true)
                            {
                                str_frmname = "Cargo Arrival Notice";
                                str_RptName = "FICanInvoice4ConsigneeAI.rpt";
                                Session["str_sfs"] = "{AIBLDetails.bid}=" + Convert.ToInt32(Session["LoginBranchid"]) + " and {AIBLDetails.hawblno}=\"" + hf_BL.Value + "\"";
                                Session["str_sp"] = "cont1=" + "" + "~cont2=" + "";
                              //  string pageurl = "../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "";
                                str_Script += "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&exp=" + exp + "&" + this.Page.ClientQueryString + "','_blank'); ";
                                
                                obj_da_log.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 125, 3, Convert.ToInt32(Session["LoginBranchid"]), txt_Jobno.Text.ToString());
                                //Session["str_sfs"] = str_sf;
                                //Session["str_sp"] = str_sp;

                            }
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(btn_canprfrma, typeof(System.Web.UI.WebControls.Button), "    ", "alertify.alert('There is no proforma vouchers');", true);
                        }
                    }
                }
                ScriptManager.RegisterStartupScript(btn_canprfrma, typeof(Button), "Cargo Arrival Notice", str_Script, true);
            }
        }

        protected void rbtn_cnsg_CheckedChanged(object sender, EventArgs e)
        {
            fn_rbtncnsg_Checked();
        }

        public void fn_rbtncnsg_Checked()
        {
            string str_mail;
            DataTable dtEmail = new DataTable();
            DataTable Dt = new DataTable();
            DataTable obj_dt1 = new DataTable();
            DataColumn dc_col1 = new DataColumn("blno", typeof(string));
            DataColumn dc_col2 = new DataColumn("linenumber", typeof(string));
            DataColumn dc_col3 = new DataColumn("consignee", typeof(string));
            DataColumn dc_col4 = new DataColumn("consigneeid", typeof(string));

            obj_dt1.Columns.Add(dc_col1);
            obj_dt1.Columns.Add(dc_col2);
            obj_dt1.Columns.Add(dc_col3);
            obj_dt1.Columns.Add(dc_col4);

            //DataAccess.ForwardingImports.BLDetails bldetailsobj = new DataAccess.ForwardingImports.BLDetails();
            //DataAccess.Masters.MasterCustomer CustObj = new DataAccess.Masters.MasterCustomer();

            if (rbtn_cnsg.Checked == true)
            {
                grd_bLdtls.Columns[2].HeaderText = "Consignee";
                if (txt_Jobno.Text != "")
                {
                    //cmbBL.Items.Clear()
                    grd_bLdtls.DataSource = null;
                    grd_bLdtls.DataBind();
                    Dt = bldetailsobj.GetBLDtJobnoNewAI(Convert.ToInt32(txt_Jobno.Text), Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(Session["LoginDivisionId"]), "");
                    if (Dt.Rows.Count > 0)
                    {
                        for (int i = 0; i <= Dt.Rows.Count - 1; i++)
                        {
                            obj_dt1.Rows.Add();
                            obj_dt1.Rows[i][0] = Dt.Rows[i]["hawblno"].ToString();
                            //if ((string.IsNullOrEmpty(Dt.Rows[i]["linenumber"].ToString()) == false) && (string.IsNullOrEmpty(Dt.Rows[i]["sublineno"].ToString()) == false))
                            //{
                            //    if (Dt.Rows[i]["sublineno"] != "")
                            //    {
                            //        obj_dt1.Rows[i][1] = Dt.Rows[i]["linenumber"].ToString() + " / " + Dt.Rows[i]["sublineno"].ToString();
                            //    }
                            //    else
                            //    {
                            //        obj_dt1.Rows[i][1] = Dt.Rows[i]["linenumber"].ToString();
                            //    }
                            //}
                            //else
                            //{
                            //    obj_dt1.Rows[i][1] = Dt.Rows[i]["linenumber"].ToString();
                            //}
                            obj_dt1.Rows[i][2] = Dt.Rows[i]["cname"].ToString();
                            hf_nomination.Value = Dt.Rows[i]["nomination"].ToString();
                            if (hf_nomination.Value == "N")
                            {
                                dtEmail = bldetailsobj.GetCustMail4BLAI(obj_dt1.Rows[i][0].ToString(), Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(Session["LoginDivisionId"]));
                                if (dtEmail.Rows.Count > 0)
                                {
                                    str_mail = dtEmail.Rows[0]["email"].ToString() + ";" + dtEmail.Rows[0]["commailid"].ToString();
                                    if (str_mail != ";")
                                    {
                                        if (CustObj.GetCusMailaddrs(Convert.ToInt32(Dt.Rows[i]["consignee"])) != "")
                                        {
                                            str_mail = CustObj.GetCusMailaddrs(Convert.ToInt32(Dt.Rows[i]["consignee"])) + ";" + str_mail;
                                        }
                                        str_mail = str_mail.Remove(str_mail.Length - 1, 1);
                                    }
                                    else
                                    {
                                        str_mail = CustObj.GetCusMailaddrs(Convert.ToInt32(Dt.Rows[i]["consignee"]));
                                    }
                                    obj_dt1.Rows[i][3] = str_mail;
                                }
                                else
                                {
                                    obj_dt1.Rows[i][3] = CustObj.GetCusMailaddrs(Convert.ToInt32(Dt.Rows[i]["consignee"]));
                                }
                            }
                            else
                            {
                                obj_dt1.Rows[i][3] = CustObj.GetCusMailaddrs(Convert.ToInt32(Dt.Rows[i]["consignee"]));
                            }
                            //obj_dt1.Rows[i][4] = true;
                        }
                        grd_bLdtls.DataSource = obj_dt1;
                        grd_bLdtls.DataBind();
                    }
                }
            }
        }

        protected void rbtn_ntfyparty_CheckedChanged(object sender, EventArgs e)
        {
            fn_rbtnntyparty_Checked();
        }
        public void fn_rbtnntyparty_Checked()
        {
            string str_mail;
            DataTable dtEmail = new DataTable();
            DataTable Dt = new DataTable();
            DataTable obj_dt1 = new DataTable();
            DataColumn dc_col1 = new DataColumn("blno", typeof(string));
            DataColumn dc_col2 = new DataColumn("linenumber", typeof(string));
            DataColumn dc_col3 = new DataColumn("consignee", typeof(string));
            DataColumn dc_col4 = new DataColumn("consigneeid", typeof(string));

            obj_dt1.Columns.Add(dc_col1);
            obj_dt1.Columns.Add(dc_col2);
            obj_dt1.Columns.Add(dc_col3);
            obj_dt1.Columns.Add(dc_col4);

            //DataAccess.ForwardingImports.BLDetails bldetailsobj = new DataAccess.ForwardingImports.BLDetails();
            //DataAccess.Masters.MasterCustomer CustObj = new DataAccess.Masters.MasterCustomer();
            if (rbtn_ntfyparty.Checked == true)
            {
                grd_bLdtls.Columns[2].HeaderText = "Notify Party";
                if (txt_Jobno.Text.ToString() != "")
                {
                    //cmbBL.Items.Clear()
                    grd_bLdtls.DataSource = null;
                    grd_bLdtls.DataBind();
                    Dt = bldetailsobj.GetBLDtJobnoNewAI(Convert.ToInt32(txt_Jobno.Text.ToString()), Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(Session["LoginDivisionId"]), "");
                    if (Dt.Rows.Count > 0)
                    {
                        for (int i = 0; i <= Dt.Rows.Count - 1; i++)
                        {
                            obj_dt1.Rows.Add();
                            obj_dt1.Rows[i][0] = Dt.Rows[i]["hawblno"].ToString();
                            //if ((string.IsNullOrEmpty(Dt.Rows[i]["linenumber"].ToString()) == false) && (string.IsNullOrEmpty(Dt.Rows[i]["sublineno"].ToString()) == false))
                            //{
                            //    if (Dt.Rows[i]["sublineno"] != "")
                            //    {
                            //        obj_dt1.Rows[i][1] = Dt.Rows[i]["linenumber"].ToString() + " / " + Dt.Rows[i]["sublineno"].ToString();
                            //    }
                            //    else
                            //    {
                            //        obj_dt1.Rows[i][1] = Dt.Rows[i]["linenumber"].ToString();
                            //    }
                            //}
                            //else
                            //{
                            //    obj_dt1.Rows[i][1] = Dt.Rows[i]["linenumber"].ToString();
                            //}
                            obj_dt1.Rows[i][2] = Dt.Rows[i]["n1name"].ToString();
                            hf_nomination.Value = Dt.Rows[i]["nomination"].ToString();
                            if (hf_nomination.Value == "N")
                            {
                                dtEmail = bldetailsobj.GetCustMail4BLAI(obj_dt1.Rows[i][0].ToString(), Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(Session["LoginDivisionId"]));
                                if (dtEmail.Rows.Count > 0)
                                {
                                    str_mail = dtEmail.Rows[0]["email"].ToString() + ";" + dtEmail.Rows[0]["commailid"].ToString();
                                    if (str_mail != ";")
                                    {
                                        if (CustObj.GetCusMailaddrs(Convert.ToInt32(Dt.Rows[i]["notifyparty1"])) != "")
                                        {
                                            str_mail = CustObj.GetCusMailaddrs(Convert.ToInt32(Dt.Rows[i]["notifyparty1"])) + ";" + str_mail;
                                        }
                                        str_mail = str_mail.Remove(str_mail.Length - 1, 1);
                                    }
                                    else
                                    {
                                        str_mail = CustObj.GetCusMailaddrs(Convert.ToInt32(Dt.Rows[i]["notifyparty1"]));
                                    }
                                    obj_dt1.Rows[i][3] = str_mail;
                                }
                                else
                                {
                                    obj_dt1.Rows[i][3] = CustObj.GetCusMailaddrs(Convert.ToInt32(Dt.Rows[i]["notifyparty1"]));
                                }
                            }
                            else
                            {
                                obj_dt1.Rows[i][3] = CustObj.GetCusMailaddrs(Convert.ToInt32(Dt.Rows[i]["notifyparty1"]));
                            }
                            //obj_dt1.Rows[i][4] = true;
                        }
                        grd_bLdtls.DataSource = obj_dt1;
                        grd_bLdtls.DataBind();
                    }
                }
            }
        }

        protected void btn_send_Click(object sender, EventArgs e)
        {
            fn_btnsend_Click();
        }
        protected void UserRights()
        {
            try
            {
                if (Request.QueryString.ToString().Contains("type"))
                {
                    Boolean btn_delete;
                    string str_FornName;
                    str_FornName = Request.QueryString["type"].ToString();
                    str_Uiid = Request.QueryString["uiid"].ToString();
                    Utility.Fn_CheckUserRights(str_Uiid, null, btn_canprfrma, null);
                    DataTable obj_Dtuser = new DataTable();
                    obj_Dtuser = (DataTable)Session["dt_UserRights"];
                    DataView obj_dtview = new DataView(obj_Dtuser);
                    obj_dtview.RowFilter = "uiid=" + str_Uiid + " and submenuname='" + str_FornName + "'";
                    //obj_Dtuser = obj_dtview.ToTable();
                    //btn_delete = Boolean.Parse(obj_Dtuser.Rows[0]["btndelete"].ToString());
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }
        public void fn_btnsend_Click()
        {
            //DataAccess.ForwardingImports.CAN obj_da_can = new DataAccess.ForwardingImports.CAN();
            //DataAccess.ForwardingExports.BLDetails obj_da_BL = new DataAccess.ForwardingExports.BLDetails();
            //DataAccess.ForwardingImports.JobInfo obj_da_fijob = new DataAccess.ForwardingImports.JobInfo();
            //DataAccess.Message4Booking obj_da_msg = new DataAccess.Message4Booking();
            //DataAccess.LogDetails obj_da_log = new DataAccess.LogDetails();
            //string str_BL;
            string str_BL4mail;
            string str_CMail;
            string str_subject;
            string str_filename;

            string str_frmname = "";
            string str_RptName = "";
            string str_sp = "";
            string str_sf = "";
            string str_Script = "";
            int index;
            if (grd_bLdtls.Rows.Count > 0)
            {
                //strcandate = Format(dteCANDate.Value, "MM/dd/yyyy")
                if (hf_candtbol.Value == "false")
                {
                    obj_da_can.UpdateCANDate(Convert.ToDateTime(txt_dtCANDate.Text), Convert.ToInt32(txt_Jobno.Text.ToString()), Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(Session["LoginDivisionId"]));
                    txt_dtCANDate.Enabled = false;
                    hf_candtbol.Value = "true";
                }
                hf_flag.Value = "false";
                foreach (GridViewRow row in grd_bLdtls.Rows)
                {
                    index = row.RowIndex;
                    CheckBox cb = (CheckBox)row.FindControl("chk_select");
                    if (cb.Checked == true)
                    {
                        hf_flag.Value = "true";
                        hf_BL.Value = grd_bLdtls.Rows[index].Cells[0].Text.ToString();
                        str_BL4mail = hf_BL.Value.Replace("/", "-");
                        str_BL4mail = str_BL4mail.Replace("/", "-");
                        if (((TextBox)grd_bLdtls.Rows[index].Cells[3].FindControl("MailId")).Text != "")
                        {
                            str_CMail = ((TextBox)grd_bLdtls.Rows[index].Cells[3].FindControl("MailId")).Text;
                        }
                        else
                        {
                            str_CMail = "";
                        }

                        string exp = "S";
                        //Session["mailfrom"] = Session["usermailid"].ToString();
                        string mailto = str_CMail;
                        string mailcontent = "Kindly find the attachment";
                        str_filename = "CAN - BL No  " + str_BL4mail;
                        str_subject = "Cargo Arrival Notice - BL # " + hf_BL.Value + " - " + grd_bLdtls.Rows[index].Cells[2].Text.ToString();
                        string mailsub = str_subject;

                        //Utility.SendMail(Session["usermailid"].ToString(), "sample", str_subject, "Kindly find the attachment", "", Session["usermailpwd"].ToString());

                        if (str_CMail != "")
                        {
                            if (rbtn_cnsg.Checked == true)
                            {
                                str_frmname = "Cargo Arrival Notice";
                                str_RptName = "FICAN4Consignee.rpt";
                                str_sf = "{FIBLDetails.bid}=" + Convert.ToInt32(Session["LoginBranchid"]) + " and {FIBLDetails.jobno}=" + txt_Jobno.Text + " and {FIBLDetails.blno}=\"" + hf_BL.Value + "\"";
                                str_sp = "";
                                str_Script += "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&exp=" + exp + "&mailto=" + mailto + "&mailcontent=" + mailcontent + "&str_filename=" + str_filename + "&mailsub=" + mailsub + "&" + this.Page.ClientQueryString + "','_blank'); ";
                                obj_da_log.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 113, 3, Convert.ToInt32(Session["LoginBranchid"]), txt_Jobno.Text);
                            }
                            else if (rbtn_forwarder.Checked == true)
                            {
                                str_frmname = "Cargo Arrival Notice";
                                str_RptName = "FICANsplit.rpt";
                                str_sf = "{FISplitBLDetails.bid}=" + Convert.ToInt32(Session["LoginBranchid"]) + " and {FISplitBLDetails.jobno}=" + txt_Jobno.Text + " and {FISplitBLDetails.blno}=\"" + hf_BL.Value + "\"";
                                str_sp = "";
                                str_Script += "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&exp=" + exp + "&mailto=" + mailto + "&mailcontent=" + mailcontent + "&str_filename=" + str_filename + "&mailsub=" + mailsub + "&" + this.Page.ClientQueryString + "','_blank'); ";
                                obj_da_log.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 113, 3, Convert.ToInt32(Session["LoginBranchid"]), txt_Jobno.Text);
                            }
                            else if (rbtn_ntfyparty.Checked == true)
                            {
                                str_frmname = "Cargo Arrival Notice";
                                str_RptName = "FICAN4Noti.rpt";
                                str_sf = "{FIBLDetails.bid}=" + Convert.ToInt32(Session["LoginBranchid"]) + " and {FIBLDetails.jobno}=" + txt_Jobno.Text + " and {FIBLDetails.blno}=\"" + hf_BL.Value + "\"";
                                str_sp = "";
                                str_Script += "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&exp=" + exp + "&mailto=" + mailto + "&mailcontent=" + mailcontent + "&str_filename=" + str_filename + "&mailsub=" + mailsub + "&" + this.Page.ClientQueryString + "','_blank'); ";
                                obj_da_log.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 113, 3, Convert.ToInt32(Session["LoginBranchid"]), txt_Jobno.Text);
                            }
                            else if (rbtn_dirctcnsg.Checked == true)
                            {
                                str_frmname = "Cargo Arrival Notice";
                                str_RptName = "FICAN4Consignee.rpt";
                                str_sf = "{FIBLDetails.bid}=" + Convert.ToInt32(Session["LoginBranchid"]) + " and {FIBLDetails.jobno}=" + txt_Jobno.Text + " and {FIBLDetails.blno}=\"" + hf_BL.Value + "\"";
                                str_sp = "";
                                str_Script += "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&exp=" + exp + "&mailto=" + mailto + "&mailcontent=" + mailcontent + "&str_filename=" + str_filename + "&mailsub=" + mailsub + "&" + this.Page.ClientQueryString + "','_blank'); ";
                                obj_da_log.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 113, 3, Convert.ToInt32(Session["LoginBranchid"]), txt_Jobno.Text);
                            }
                            hf_bookno.Value = obj_da_BL.GetBookinkNo(hf_BL.Value, Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(Session["LoginDivisionId"]));
                            obj_da_msg.InsMsg4Booking(hf_bookno.Value.ToString(), str_subject, str_CMail, "", obj_da_log.GetDate(), hf_empname.Value.ToString(), "", "", str_filename);
                            obj_da_fijob.UpdateFIEventcaninvsenton(Convert.ToInt32(txt_Jobno.Text.ToString()), obj_da_log.GetDate(), Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(Session["LoginDivisionId"]));
                        }
                    }
                }
                ScriptManager.RegisterStartupScript(btn_send, typeof(Button), "Cargo Arrival Notice", str_Script, true);

                if (hf_flag.Value == "false")
                {
                    ScriptManager.RegisterStartupScript(btn_send, typeof(Button), "Valid", "alertify.alert('Please Select atleast a BL #');", true);
                }
                UserRights();
            }
        }

        protected void grd_bLdtls_PreRender(object sender, EventArgs e)
        {
            if (grd_bLdtls.Rows.Count > 0)
            {
                grd_bLdtls.UseAccessibleHeader = true;
                grd_bLdtls.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }
    }
}