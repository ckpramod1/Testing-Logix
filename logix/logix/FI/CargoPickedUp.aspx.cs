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

namespace logix.FI
{
    public partial class CargoPickedUp : System.Web.UI.Page
    {
        string str_blno;
        string str_dnno;
        int i;
        double cbm, amt;
        DataTable dt_caargo = new DataTable();
        string str_CustMail;
        bool bol;
        string strdnno;
        DataAccess.LogDetails da_obj_objLog = new DataAccess.LogDetails();
        int vouyear;
        string Ctrl_List;
        string Msg_List;
        string Dtype_List;
        protected void Page_Load(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "SpanTagMoveInputBottom();MuiTextField();", true);

            if (Session["LoginUserName"] == null || Session["LoginEmpId"] == null || Session["LoginDivisionId"] == null || Session["LoginBranchid"] == null)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alertify.alert('Session TimeOut');window.open('"+ Session["Site"].ToString() + "/','_top');", true);
            }
            else if (Session["StrTranType"] == null)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alertify.alert('Session TimeOut');window.open('"+ Session["Site"].ToString() + "/FormMain.aspx','_top');", true);
            }

            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(btn_back);
            if (IsPostBack != true)
            {
                txt_cfs.Focus();
                try
                {
                    txt_dtPickOn.Text = Utility.fn_ConvertDate(da_obj_objLog.GetDate().ToString());

                    if (da_obj_objLog.GetDate().Month < 4)
                    {
                        vouyear = da_obj_objLog.GetDate().Year - 1;
                    }
                    else
                    {
                        vouyear = da_obj_objLog.GetDate().Year;
                    }

                   if (Request.QueryString.ToString().Contains("consigneename"))
                    {
                        string Conatin = Request.QueryString["consigneename"].ToString();
                        hf_cfsid.Value = Request.QueryString["conginid"].ToString();
                        txt_cfs.Text = Conatin;
                        txt_cfs_TextChanged(sender, e);
                        

                    }
                    Ctrl_List = txt_cfs.ID + "~" + hf_cfsid.ID;
                    Msg_List = "CFS~CFS";
                    Dtype_List = "string~Autocomplete";
                    btn_Update.Attributes.Add("OnClick", "return IsValid('" + Ctrl_List + "','" + Msg_List + "','" + Dtype_List + "')");
                    grd.Visible = true;
                    grd.DataSource = new DataTable();
                    grd.DataBind();
                    btn_back.Text = "Cancel";
                    btn_back.ToolTip = "Cancel";
                    btn_cancel1.Attributes["class"] = "btn ico-cancel";
                }
                catch (Exception ex)
                {
                    string message = ex.Message.ToString();
                    ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
                }


               
            }
            grd.Visible = true;
            //grd.DataSource = new DataTable();
            //grd.DataBind();
        }

        [WebMethod]
        public static List<string> Getsagentid(string prefix)
        {
            DataTable obj_Dt = new DataTable();
            DataAccess.Masters.MasterCustomer obj_da_cust = new DataAccess.Masters.MasterCustomer();
            List<string> agent = new List<string>();
            obj_Dt = obj_da_cust.GetLikeCustomer(prefix);
            agent = Utility.Fn_DatatableToList(obj_Dt, "customername", "customerid", "customer");
            return agent;
        }


        protected void btn_Update_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txt_cfs.Text))
            {
                datatable();
            }
        }

        public void datatable()
        {
            try
            {
                DataAccess.Masters.MasterCustomer da_obj_objCust = new DataAccess.Masters.MasterCustomer();
                DataAccess.ForwardingImports.CargoPickup da_obj_objcargopick = new DataAccess.ForwardingImports.CargoPickup();

                dt_caargo = (DataTable)Session["datatable"];
                if (dt_caargo.Rows.Count > 0)
                {
                    //for (i = 0; i <= dt_caargo.Rows.Count - 1; i++)
                    //{
                    foreach (GridViewRow row in grd.Rows)
                    {
                        CheckBox Chk = (CheckBox)row.FindControl("grdSelect");
                        int i = row.RowIndex;
                        if (Chk.Checked == true)
                        {
                            hf_intjobno.Value = dt_caargo.Rows[i][0].ToString();
                            str_blno = dt_caargo.Rows[i][1].ToString();
                            cbm = Convert.ToDouble(dt_caargo.Rows[i][8].ToString());
                            hf_intAgentID.Value = dt_caargo.Rows[i][9].ToString();
                            da_obj_objcargopick.Updcargopickdate(Convert.ToInt32(hf_intjobno.Value), Convert.ToString(str_blno), Convert.ToDateTime(txt_dtPickOn.Text), Convert.ToInt32(Session["LoginBranchid"].ToString()));

                            str_CustMail = da_obj_objCust.GetCusMailaddrs(Convert.ToInt32(hf_intAgentID.Value));


                            if (str_CustMail != "")
                            {
                                da_obj_objcargopick.InsTempCargoPickupConfirm(Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToString(str_blno), Convert.ToInt32(hf_intAgentID.Value), Convert.ToDateTime(txt_dtPickOn.Text));
                                str_CustMail = "";
                            }
                            else
                            {
                                str_CustMail = "";
                            }
                            genOTHDN();
                            da_obj_objLog.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"].ToString()), 1076, 2, Convert.ToInt32(Session["LoginBranchid"].ToString()), hf_intjobno.Value + " Upd");
                            bol = true;
                        }
                    }
                    //}
                }
                else
                {
                    ScriptManager.RegisterStartupScript(btn_Update, typeof(Button), "DataFound", "alertify.alert('Data Not Avaiable');", true);
                    return;

                }
                if (bol == true)
                {
                    strdnno = "";
                    if (strdnno.Length > 0)
                    {
                        strdnno = strdnno.Substring(1, strdnno.Length - 1);
                        ScriptManager.RegisterStartupScript(btn_Update, typeof(Button), "DataFound", "alertify.alert('Details Updated" + "DN # " + strdnno + " Generated');", true);
                        //Interaction.MsgBox("Details Updated" + Constants.vbCrLf + "DN # " + strdnno + " Generated");
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(btn_Update, typeof(Button), "DataFound", "alertify.alert('DN # " + strdnno + " Details Updated');", true);
                    }
                    //clear();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(btn_Update, typeof(Button), "DataFound", "alertify.alert('Select Atleast one BL #');", true);
                    return;
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        private void genOTHDN()
        {
            try
            {
                DataAccess.Accounts.OSDNCN da_obj_objOSDNCN = new DataAccess.Accounts.OSDNCN();
                DataAccess.Accounts.Invoice da_obj_objINVOICE = new DataAccess.Accounts.Invoice();
                DataAccess.Accounts.Approval da_obj_objApprove = new DataAccess.Accounts.Approval();

                if (hf_cfsid.Value == "13234")
                {
                    hf_dnno.Value = da_obj_objOSDNCN.GetOSDCNno("DN", Convert.ToInt32(Session["LoginBranchid"].ToString())).ToString();
                    da_obj_objINVOICE.InsertInvoiceHead(Convert.ToInt32(hf_dnno.Value), da_obj_objLog.GetDate(), "FI", Convert.ToInt32(hf_intjobno.Value), Convert.ToInt32(hf_cfsid.Value), Convert.ToString(str_blno), "Container Picked Up", Convert.ToInt32(Session["LoginBranchid"].ToString()), "Cash/Cheque", Convert.ToInt32(Session["LoginEmpId"].ToString()), "Debit Note", Convert.ToInt32(Session["Vouyear"].ToString()), Convert.ToChar("N"), "");
                    if (cbm < 1)
                    {
                        cbm = 1;
                    }
                    amt = cbm * 275;
                    da_obj_objINVOICE.InsertInvoiceDetails(Convert.ToInt32(hf_dnno.Value), 321, "INR", Convert.ToDouble(amt), Convert.ToDouble(1), "BL", Convert.ToDouble(amt), Convert.ToInt32(Session["LoginBranchid"].ToString()), "Debit Note", Convert.ToInt32(hf_cfsid.Value), Convert.ToInt32(Session["Vouyear"].ToString()), "C", "FI");
                    da_obj_objApprove.UpdApproval(Convert.ToInt32(hf_dnno.Value), Convert.ToString(str_blno), Convert.ToInt32(Session["LoginEmpId"].ToString()), "FI", "Debit Note", Convert.ToInt32(Session["Vouyear"].ToString()), Convert.ToInt32(Session["LoginBranchid"].ToString()));
                    //sendmail.OtherDNCNBL(Convert.ToInt32(hf_intjobno.Value), "FI", "&Approve", da_obj_objLog.GetDate(), dnno, "V");
                    str_dnno = str_dnno + "," + hf_dnno.Value.ToString();

                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }

        }

        protected void txt_cfs_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DataAccess.ForwardingImports.CargoPickup da_obj_objcargopick = new DataAccess.ForwardingImports.CargoPickup();
                if (hf_cfsid.Value != "0")
                {
                    dt_caargo = da_obj_objcargopick.getcfsDtls(Convert.ToInt32(hf_cfsid.Value), Convert.ToInt32(Session["LoginBranchid"].ToString()));
                    if (dt_caargo.Rows.Count > 0)
                    {
                        grd.DataSource = dt_caargo;
                        Session["datatable"] = dt_caargo;
                        grd.DataBind();
                        
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(btn_Update, typeof(Button), "DataFound", "alertify.alert('Data Not Available');", true);
                        txt_cfs.Text = "";
                      //  btn_Update.Enabled = false;
                        return;
                    }

                }
                else
                {
                    grd.DataSource = new DataTable();
                    grd.DataBind();
                }
                btn_back.Text = "Cancel";
                btn_back.ToolTip = "Cancel";
                btn_cancel1.Attributes["class"] = "btn ico-cancel";
                grd.Visible = true;
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        protected void btn_back_Click(object sender, EventArgs e)
        {
            if (btn_back.ToolTip == "Cancel")
           {
            clear();
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
                           if (Session["StrTranType"].ToString() == "FE")
                           {
                               Response.Redirect("../Home/OECSHome.aspx");
                           }
                           else if (Session["StrTranType"].ToString() == "FI")
                           {
                               Response.Redirect("../Home/OICSHome.aspx");
                           }
                       }
                   }
                   else
                   {
                       this.Response.End();
                   }
               }

           }
        }
        public void clear()
        {
            txt_dtPickOn.Text = Utility.fn_ConvertDate(da_obj_objLog.GetDate().ToString());
            txt_cfs.Text = "";
            grd.Visible = true;
            grd.DataSource = new DataTable();
            grd.DataBind();
            btn_back.Text = "Back";
            btn_back.ToolTip = "Back";
            btn_cancel1.Attributes["class"] = "btn ico-back";
            txt_cfs.Focus();
        }

 

        protected void grd_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grd.PageIndex = e.NewPageIndex;
            grd.DataSource = (DataTable)Session["datatable"];
            grd.DataBind();
        }

        //protected void grd_PageIndexChanging(object sender, GridViewPageEventArgs e)
        //{
        //    grd.PageIndex = e.NewPageIndex;
        //    grd.DataSource = (DataTable)Session["datatable"];
        //    grd.DataBind();
        //}

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

            obj_dtlogdetails = Logobj.InsTempGrpLogdtlsGet(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), 1076, "Job", "", "", Session["StrTranType"].ToString());
                    
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

        protected void grd_PreRender(object sender, EventArgs e)
        {
            if (grd.Rows.Count > 0)
            {
                grd.UseAccessibleHeader = true;
                grd.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }
    }
}