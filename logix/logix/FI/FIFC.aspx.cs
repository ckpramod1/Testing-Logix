using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using System.Data;

namespace logix.FI
{
    public partial class FIFC : System.Web.UI.Page
    {

        DataAccess.LogDetails obj_da_log = new DataAccess.LogDetails();
        DataAccess.ForwardingImports.FreightCertificate obj_da_FC = new DataAccess.ForwardingImports.FreightCertificate();
        DataAccess.CostingTemp obj_da_FIFCTemp = new DataAccess.CostingTemp();
        DataAccess.Masters.MasterCharges obj_da_charge = new DataAccess.Masters.MasterCharges();
        protected void Page_Load(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "SpanTagMoveInputBottom();MuiTextField();", true);



            string Ccode = Convert.ToString(Session["Ccode"]);

            if (Ccode != "")
            {

                obj_da_log.GetDataBase(Ccode);
                obj_da_FC.GetDataBase(Ccode);
                obj_da_FIFCTemp.GetDataBase(Ccode);
                obj_da_charge.GetDataBase(Ccode);
              



            }



            if (Session["LoginUserName"] == null || Session["LoginEmpId"] == null || Session["LoginDivisionId"] == null || Session["LoginBranchid"] == null)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alertify.alert('Session TimeOut');window.open('"+ Session["Site"].ToString() + "/','_top');", true);
            }
            else if (Session["StrTranType"] == null)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alertify.alert('Session TimeOut');window.open('"+ Session["Site"].ToString() + "/FormMain.aspx','_top');", true);
            }
            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(btn_cancel);
            if (!IsPostBack == true)
            {
                   if(Session["StrTranType"].ToString()=="FI")
                {
                    lblHead.InnerText = "Ocean Imports";
                }
                else if (Session["StrTranType"].ToString() == "AE")
                {
                    lblHead.InnerText = "Air Exports";
                }


                //DataAccess.LogDetails obj_da_log = new DataAccess.LogDetails();
                if (obj_da_log.GetDate().Month < 4)
                {
                    hf_vouyear.Value = ((obj_da_log.GetDate().Year) - 1).ToString();
                }
                else
                {
                    hf_vouyear.Value = obj_da_log.GetDate().Year.ToString();
                }
                btn_frghtcertfcte.Enabled = false;
                btn_frghtcertfcte.ForeColor = System.Drawing.Color.Gray;

                btn_cancel.Text = "Cancel";
                btn_cancel.ToolTip = "Cancel";
                btn_cancel1.Attributes["class"] = "btn ico-cancel";
                grd_fifc.DataSource = new DataTable();
                grd_fifc.DataBind();
                txt_blno.Focus();
                //txt_blno.Attributes.Add("OnKeypress", "return IntegerCheck(event);");
            }
         
        }

        [WebMethod]
        public static List<string> GetBL(string prefix)
        {

            DataAccess.ForwardingExports.BLDetails obj_da_febl = new DataAccess.ForwardingExports.BLDetails();
            DataAccess.ForwardingImports.BLDetails obj_da_bl = new DataAccess.ForwardingImports.BLDetails();
            DataAccess.AirImportExports.AIEBLDetails obj_da_aiebl = new DataAccess.AirImportExports.AIEBLDetails();

            string Ccode = HttpContext.Current.Session["Ccode"].ToString();
            obj_da_febl.GetDataBase(Ccode);
            obj_da_bl.GetDataBase(Ccode);
            obj_da_aiebl.GetDataBase(Ccode);

          

            DataTable obj_dtFC = new DataTable();
            //DataAccess.Masters.MasterCustomer obj_da_customer = new DataAccess.Masters.MasterCustomer();
            List<string> BL = new List<string>();
            if (HttpContext.Current.Session["StrTranType"] == "FE")
            {
                obj_dtFC = obj_da_febl.GetLikeOTHERBLDetails(prefix.ToUpper().ToString(), Convert.ToInt32(HttpContext.Current.Session["LoginBranchid"]), Convert.ToInt32(HttpContext.Current.Session["LoginDivisionId"]));
            }
            else if (HttpContext.Current.Session["StrTranType"] == "FI")
            {
                obj_dtFC = obj_da_bl.GetLikeOTHERIBL(prefix.ToUpper().ToString(), Convert.ToInt32(HttpContext.Current.Session["LoginBranchid"]), Convert.ToInt32(HttpContext.Current.Session["LoginDivisionId"]));
            }
            else if (HttpContext.Current.Session["StrTranType"] == "AE")
            {
                obj_dtFC = obj_da_aiebl.GetLikeOTHERAIEBLDetails(prefix.ToUpper().ToString(), "AE", Convert.ToInt32(HttpContext.Current.Session["LoginBranchid"]), Convert.ToInt32(HttpContext.Current.Session["LoginDivisionId"]));
            }
            else
            {
                obj_dtFC = obj_da_aiebl.GetLikeOTHERAIEBLDetails(prefix.ToUpper().ToString(), "AI", Convert.ToInt32(HttpContext.Current.Session["LoginBranchid"]), Convert.ToInt32(HttpContext.Current.Session["LoginDivisionId"]));
            }

            if (obj_dtFC.Rows.Count > 0)
            {
                if (HttpContext.Current.Session["StrTranType"] == "FE" || HttpContext.Current.Session["StrTranType"] == "FI")
                {

                    BL = Utility.Fn_DatatableToList_string(obj_dtFC, "blno", "blno");

                }
                else if (HttpContext.Current.Session["StrTranType"] == "AE" || HttpContext.Current.Session["StrTranType"] == "AI")
                {
                    BL = Utility.Fn_DatatableToList_string(obj_dtFC, "hawblno", "hawblno");
                }

            }
            return BL;

        }

        protected void txt_blno_TextChanged(object sender, EventArgs e)
        {
            fn_txtblno_Changed();
            btn_frghtcertfcte.Enabled = true;
            btn_frghtcertfcte.ForeColor = System.Drawing.Color.White;
        }
        public void fn_txtblno_Changed()
        {
            DataTable obj_dtFC = new DataTable();
            //DataAccess.ForwardingImports.FreightCertificate obj_da_FC = new DataAccess.ForwardingImports.FreightCertificate();
            if (txt_blno.Text != "")
            {
                obj_dtFC = obj_da_FC.GetBLDetails(txt_blno.Text.ToString(), Session["StrTranType"].ToString(), Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(Session["LoginDivisionId"]));
                if (obj_dtFC.Rows.Count > 0)
                {
                    txt_date.Text = Convert.ToDateTime(obj_dtFC.Rows[0]["bldate"]).ToString("dd/MM/yyyy");
                    txt_shipper.Text = obj_dtFC.Rows[0]["shipper"].ToString();
                    txt_consignee.Text = obj_dtFC.Rows[0]["consignee"].ToString();
                    txt_pol.Text = obj_dtFC.Rows[0]["pol"].ToString();
                    txt_vessel.Text = obj_dtFC.Rows[0]["vslvoy"].ToString();
                    hf_jobno.Value = obj_dtFC.Rows[0]["jobno"].ToString();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(txt_blno, typeof(TextBox), "Valid", "alertify.alert('No details available for this BL');", true);
                    txt_blno.Focus();
                    return;
                }
                obj_dtFC = obj_da_FC.GetInvDetails(txt_blno.Text.ToString(), Convert.ToInt32(hf_vouyear.Value), Session["StrTranType"].ToString(), Convert.ToInt32(Session["LoginBranchid"]));
                if (obj_dtFC.Rows.Count > 0)
                {
                    grd_fifc.DataSource = obj_dtFC;
                    grd_fifc.DataBind();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(txt_blno, typeof(TextBox), "Valid", "alertify.alert('No Invoice Details available for this BL');", true);
                    txt_blno.Focus();
                    return;
                }

            }
        }

        protected void grd_fifc_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void grd_fifc_RowDataBound(object sender, GridViewRowEventArgs e)
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
                e.Row.Cells[2].Text = string.Format("{0:0.00}", e.Row.Cells[2].Text.ToString());
            }
        }

        protected void btn_cancel_Click(object sender, EventArgs e)
        {
          if( btn_cancel.ToolTip=="Cancel")
          {
               fn_btncancel_Click();
               txt_blno.Focus();
          }
          else
           {
               //this.Response.End();

               if (Session["home"] != null)
               {
                   if (Session["home"].ToString() == "CS")
                   {
                       if (Session["StrTranType"] != null)
                       {
                           if (Session["StrTranType"].ToString() == "FI")
                           {
                               Response.Redirect("../Home/OICSHome.aspx");
                           }
                           else if (Session["StrTranType"].ToString() == "AE")
                           {
                               Response.Redirect("../Home/AECSHome.aspx");
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
        public void fn_btncancel_Click()
        {
            txtClear();
            grd_fifc.DataSource = new DataTable();
            grd_fifc.DataBind();
            btn_frghtcertfcte.Enabled = false;
            btn_frghtcertfcte.ForeColor = System.Drawing.Color.Gray;
            btn_cancel.Text="Back";
            btn_cancel.ToolTip = "Back";
            btn_cancel1.Attributes["class"] = "btn ico-back";
        }
        public void txtClear()
        {
            txt_blno.Text = "";
            txt_date.Text = "";
            txt_vessel.Text = "";
            txt_pol.Text = "";
            txt_shipper.Text = "";
            txt_consignee.Text = "";
        }

        protected void btn_frghtcertfcte_Click(object sender, EventArgs e)
        {
            fn_btnFC_Click();
        }
        public void fn_btnFC_Click()
        {
            string str_frmname = "";
            string str_RptName = "";
            string str_sp = "";
            string str_sf = "";
            string str_Script = "";
            int checkcount = 0;
            Session["str_sfs"] = "";
            Session["str_sp"] = "";
            int index = 0;
            //DataAccess.CostingTemp obj_da_FIFCTemp = new DataAccess.CostingTemp();
            //DataAccess.LogDetails obj_da_log = new DataAccess.LogDetails();
            //DataAccess.Masters.MasterCharges obj_da_charge = new DataAccess.Masters.MasterCharges();
            obj_da_FIFCTemp.DelFIFCTemp(Convert.ToInt32(Session["LoginEmpId"]));
            foreach (GridViewRow row in grd_fifc.Rows)
            {
                index = row.RowIndex;
                
                CheckBox cb = (CheckBox)row.FindControl("chk_select");
                if (cb.Checked == true)
                {
                    hf_invno.Value = row.Cells[0].Text.ToString();
                    obj_da_FIFCTemp.InsertFIFCTemp(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), obj_da_charge.GetChargeid(row.Cells[1].Text.ToString()), Convert.ToInt32(hf_jobno.Value), Session["StrTranType"].ToString(), txt_blno.Text.ToString(), Convert.ToInt32(hf_invno.Value), Convert.ToInt32(hf_vouyear.Value));
                    checkcount = index + 1;
                }
            }
            if (Session["StrTranType"].ToString() == "FI")
            {
                str_frmname = "FI Invoice";
                str_RptName = "FIFIFC.rpt";

                Session["str_sfs"] = "{FIFCTemp.trantype}='FI' and {FIFCTemp.blno}='" + txt_blno.Text + "' and {FIFCTemp.jobno}=" + hf_jobno.Value + " and {FIFCTemp.branch}=" + Session["LoginBranchid"];
            }
            else if (Session["StrTranType"].ToString() == "FE")
            {
                str_frmname = "FE Invoice";
                str_RptName = "FEFC.rpt";
                Session["str_sfs"] = "{FIFCTemp.trantype}='FE' and {FIFCTemp.blno}='" + txt_blno.Text + "' and {FIFCTemp.jobno}=" + hf_jobno.Value + " and {FIFCTemp.branch}=" + Session["LoginBranchid"];
            }
            else if (Session["StrTranType"].ToString() == "AE")
            {
                str_frmname = "AE Invoice";
                str_RptName = "AEFC.rpt";
                Session["str_sfs"] = "{FIFCTemp.trantype}='AE' and {FIFCTemp.blno}='" + txt_blno.Text.ToString() + "' and {FIFCTemp.jobno}=" + hf_jobno.Value + " and {FIFCTemp.branch}=" + Session["LoginBranchid"];
            }
            else if (Session["StrTranType"].ToString() == "AI")
            {
                str_frmname = "AI Invoice";
                str_RptName = "AIFC.rpt";
                Session["str_sfs"] = "{FIFCTemp.trantype}='AI' and {FIFCTemp.blno}='" + txt_blno.Text.ToString() + "' and {FIFCTemp.jobno}=" + hf_jobno.Value + " and {FIFCTemp.branch}=" + Session["LoginBranchid"];
            }

            str_sp = "Lcurr=INR";
            //ScriptManager.RegisterStartupScript(btn_frghtcertfcte, typeof(Button), "Valid", "alertify.alert('No. of Rows Clicked are :" + checkcount + "');", true);

            //str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
            str_Script = "window.open('../Reportasp/FCReport.aspx?trantype=" + Session["StrTranType"].ToString() + "&blno=" + txt_blno.Text.ToString() + "&jobno=" + hf_jobno.Value + "&bid=" + Session["LoginBranchid"] + "&" + this.Page.ClientQueryString + "','','');";
            ScriptManager.RegisterStartupScript(btn_frghtcertfcte, typeof(Button), "Freight Certificate", str_Script, true);
            

            if (Session["StrTranType"].ToString() == "FI")
            {
                obj_da_log.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 120, 3, Convert.ToInt32(Session["LoginBranchid"]), txt_blno.Text.ToString() + "/" + hf_invno.Value.ToString());
            }
            else if (Session["StrTranType"].ToString() == "AE")
            {
                obj_da_log.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 419, 3, Convert.ToInt32(Session["LoginBranchid"]), txt_blno.Text.ToString() + "/" + hf_invno.Value.ToString());
            }
            Session["str_sp"] = str_sp;
            //Session["str_sfs"] = str_sf;
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
            //DataAccess.LogDetails obj_da_log = new DataAccess.LogDetails();

            if (Session["StrTranType"].ToString() == "FI")
            {
                obj_dtlogdetails = obj_da_log.InsTempGrpLogdtlsGet(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), 120, "BL", txt_blno.Text + "/", txt_blno.Text + "/", Session["StrTranType"].ToString());
            }
            else if (Session["StrTranType"].ToString() == "AE")
            {
                obj_dtlogdetails = obj_da_log.InsTempGrpLogdtlsGet(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), 419, "BL", txt_blno.Text + "/", txt_blno.Text + "/", Session["StrTranType"].ToString());

            }

            if (txt_blno.Text != "")
            {
                JobInput.Text = txt_blno.Text;
            }

            if (obj_dtlogdetails.Rows.Count >= 0)
            {
                ModalPopupExtenderlog.Show();
                GridViewlog.DataSource = obj_dtlogdetails;
                GridViewlog.DataBind();
            }
        }

        protected void grd_fifc_PreRender(object sender, EventArgs e)
        {
            if (grd_fifc.Rows.Count > 0)
            {
                grd_fifc.UseAccessibleHeader = true;
                grd_fifc.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }
    }
}