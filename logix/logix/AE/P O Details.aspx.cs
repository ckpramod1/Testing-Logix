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
using System.Runtime.Remoting;

namespace logix.AE
{
    public partial class P_O_Details : System.Web.UI.Page
    {
        string str_trantype;
        string str_pono;
        string str_style;
        int int_pieces;
        int int_cartons;
        int int_weight;
        string str_dimension;
        int int_bookno;

        string Ctrl_List;
        string Msg_List;
        string Dtype_List;
        string Ctrl_List1;
        string Msg_List1;
        string Dtype_List1;
        string str_Uiid = "", str_FornName;
        DataAccess.LogDetails Logobj = new DataAccess.LogDetails();
        DataAccess.ForwardingExports.PODetails FEPOobj = new DataAccess.ForwardingExports.PODetails();
        DataAccess.LogDetails da_obj_Logobj = new DataAccess.LogDetails();

        DataAccess.ForwardingImports.BLDetails da_obj_FIBLObj = new DataAccess.ForwardingImports.BLDetails();
        DataAccess.ForwardingExports.PODetails da_obj_FEPOobj = new DataAccess.ForwardingExports.PODetails();
        protected void Page_Load(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "SpanTagMoveInputBottom();MuiTextField();", true);

            string Ccode = Convert.ToString(Session["Ccode"]);

            if (Ccode != "")
            {

                FEPOobj.GetDataBase(Ccode);
                da_obj_Logobj.GetDataBase(Ccode);
                da_obj_FIBLObj.GetDataBase(Ccode);
                da_obj_FEPOobj.GetDataBase(Ccode);               
                Logobj.GetDataBase(Ccode);

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
                str_trantype = Session["StrTranType"].ToString();
                //if (Request.QueryString.ToString().Contains("str"))
                //{
                //    str_trantype = Request.QueryString["str_trantype"].ToString();
                //}
                txt_custname.Enabled = false;
                //DataAccess.LogDetails da_obj_Logobj = new DataAccess.LogDetails();
                btn_back.Text = "Cancel";
                btn_back.ToolTip = "Cancel";
                btn_cancel1.Attributes["class"] = "btn ico-cancel";
                txt_dtinvdate.Text = Utility.fn_ConvertDate(da_obj_Logobj.GetDate().ToString());
                Ctrl_List = "txt_bookno~txt_pono~txt_style~txt_pieces~txt_cartons~txt_weight~txt_dimension";
                Msg_List = "Booking #~PO#~Style / SKU #~Pieces~Cartons~Weight~Dimensions";
                Dtype_List = "int~string~string~int~int~int~string";
                btn_save.Attributes.Add("OnClick", "return IsValid('" + Ctrl_List + "','" + Msg_List + "','" + Dtype_List + "')");
                txt_cartons.Attributes.Add("onkeypress", "return IntegerCheck(event);");
                //txt_weight.Attributes.Add("onkeypress", "return validateFloatKeyPress(this,event,'Weights')");
                txt_weight.Attributes.Add("onkeypress", "return IntegerCheck(event);");
                txt_pieces.Attributes.Add("onkeypress", "return IntegerCheck(event);");

                UserRights();
                txt_bookno.Focus();

                if (Session["StrTranType"].ToString() == "AE")
                {
                    HeaderLabel1.InnerText = "Air Exports";
                }
            }
                       
        }

        protected void UserRights()
        {
            try
            {
                if (Request.QueryString.ToString().Contains("type"))
                {
                    str_FornName = Request.QueryString["type"].ToString();
                    str_Uiid = Request.QueryString["uiid"].ToString();
                    Utility.Fn_CheckUserRights(str_Uiid, btn_save, btn_view, null);
                    DataTable obj_Dtuser = new DataTable();
                    obj_Dtuser = (DataTable)Session["dt_UserRights"];
                    DataView obj_dtview = new DataView(obj_Dtuser);
                    obj_dtview.RowFilter = "uiid=" + str_Uiid + " and submenuname='" + str_FornName + "'";
                    obj_Dtuser = obj_dtview.ToTable();
                    Boolean btn_delete;
                    btn_delete = Boolean.Parse(obj_Dtuser.Rows[0]["btndelete"].ToString());
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }


        [WebMethod]
        public static List<string> Getsagentid(string prefix)
        {
            DataTable obj_Dt = new DataTable();
            DataAccess.ForwardingExports.PODetails da_obj_FEPOobj = new DataAccess.ForwardingExports.PODetails();
            string Ccode = HttpContext.Current.Session["Ccode"].ToString();
            da_obj_FEPOobj.GetDataBase(Ccode);
            List<string> agent = new List<string>();
            obj_Dt = da_obj_FEPOobj.GetLikePODetails(prefix, Convert.ToString(HttpContext.Current.Session["StrTranType"].ToString()), Convert.ToInt32(HttpContext.Current.Session["LoginBranchid"].ToString()), Convert.ToInt32(HttpContext.Current.Session["LoginDivisionId"].ToString()));
            agent = Utility.Fn_DatatableToList_Text(obj_Dt, "pono");
            return agent;
        }

        protected void lbl_lnkrate_Click(object sender, EventArgs e)
        {
            bind();
        }

        public void bind()
        {
            grd.Visible = true;
            str_trantype = Session["StrTranType"].ToString();
            //DataAccess.ForwardingImports.BLDetails da_obj_FIBLObj = new DataAccess.ForwardingImports.BLDetails();
            DataTable Dt = new DataTable();
            Dt = da_obj_FIBLObj.Bookingdetails(Convert.ToString(str_trantype), Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()));
            if (Dt.Rows.Count == 0)
            {
                ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "DataFound", "alertify.alert('Booking Not Available');", true);
                return;
            }
            else
            {
                Grd_buying_popup.Show();
                grd.DataSource = Dt;
                grd.DataBind();
                ViewState["GRD"] = Dt;
            }
            btn_back.Text = "Cancel";
            btn_back.ToolTip = "Cancel";
            btn_cancel1.Attributes["class"] = "btn ico-cancel";
        }

        protected void btn_save_Click(object sender, EventArgs e)
        {
            //DataAccess.LogDetails da_obj_Logobj = new DataAccess.LogDetails();

            if (btn_save.ToolTip == "Save")
            {
                assign();
                // FEPOobj.InsPODetails(intbookno, strpono, strstyle, intpieces, intcartons, intweight, strdimension, strtrantype, txtinvno.Text, dtinvdate.Value, Login.branchid, Login.divisionid)
                FEPOobj.InsPODetails(Convert.ToInt32(hf_hidid1.Value), str_pono, str_style, int_pieces, int_cartons, Convert.ToSingle(int_weight), str_dimension, Session["StrTranType"].ToString(), txt_invno.Text.ToUpper(), Convert.ToDateTime(Utility.fn_ConvertDate(txt_dtinvdate.Text)), Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()));
                da_obj_Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"].ToString()), 204, 1, Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToString(str_pono) + "/S");
                ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "DataFound", "alertify.alert('Details Saved');", true);
                btn_back.Text = "Cancel";
                btn_back.ToolTip = "Cancel";
                btn_cancel1.Attributes["class"] = "btn ico-cancel";
                txtclear();
                btn_save.Text = "Save";
                btn_save.ToolTip = "Save";
                btn_save1.Attributes["class"] = "btn ico-save";
                txt_pono.Text = "";
            }
            else
            {
                assign();
                FEPOobj.UpdPODetails(str_pono, str_style, int_pieces, int_cartons, Convert.ToSingle(int_weight), str_dimension, Session["StrTranType"].ToString(), txt_invno.Text.ToUpper(), Convert.ToDateTime(Utility.fn_ConvertDate(txt_dtinvdate.Text)), Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()));
                da_obj_Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"].ToString()), 204, 2, Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToString(str_pono) + "/U");
                ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "DataFound", "alertify.alert('Details Updated');", true);
                btn_back.Text = "Cancel";
                btn_back.ToolTip = "Cancel";
                btn_cancel1.Attributes["class"] = "btn ico-cancel";
                txtclear();
                btn_save.Text = "Save";
                btn_save.ToolTip = "Save";
                btn_save1.Attributes["class"] = "btn ico-save";
                txt_pono.Text = "";
            }
            UserRights();
            txt_bookno.Focus();
        }

        public void assign()
        {
            string bookno = txt_bookno.Text.ToUpper();
            str_pono = txt_pono.Text.ToUpper();
            str_style = txt_style.Text.ToUpper();
            int_pieces = Convert.ToInt32(txt_pieces.Text);
            int_cartons = Convert.ToInt32(txt_cartons.Text);
            int_weight = Convert.ToInt32(txt_weight.Text);
            str_dimension = txt_dimension.Text.ToUpper();
        }

        protected void grd_SelectedIndexChanged(object sender, EventArgs e)
        {
            //DataAccess.ForwardingExports.PODetails da_obj_FEPOobj = new DataAccess.ForwardingExports.PODetails();
            DataTable Dt = new DataTable();

            str_trantype = Session["StrTranType"].ToString();

            if (grd.Rows.Count > 0)
            {
                int int_index;
                int_index = grd.SelectedRow.RowIndex;
                txt_bookno.Text = grd.Rows[int_index].Cells[0].Text.ToString();
                Dt = da_obj_FEPOobj.GetBookingDet(txt_bookno.Text, Convert.ToString(str_trantype), Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()));
                if (Dt.Rows.Count > 0)
                {
                    txt_custname.Text = Dt.Rows[0][2].ToString();
                    int_bookno = Convert.ToInt32(Dt.Rows[0][0].ToString());
                    hf_hidid1.Value = int_bookno.ToString();
                    txt_pono.Focus();
                    btn_back.Enabled = true;
                }
            }
        }
        public void getdata()
        {
             str_trantype = Session["StrTranType"].ToString();
             //DataAccess.ForwardingExports.PODetails da_obj_FEPOobj = new DataAccess.ForwardingExports.PODetails();
             DataTable Dt = new DataTable();
             if (!string.IsNullOrEmpty(txt_pono.Text))
             {
                 Dt = da_obj_FEPOobj.GetPODetails(Convert.ToString(txt_pono.Text), Convert.ToString(str_trantype), Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()));

                 if (Dt.Rows.Count != 0)
                 {
                     txt_bookno.Text = Dt.Rows[0]["bookingno"].ToString();
                     txt_style.Text = Dt.Rows[0]["styleno"].ToString();
                     txt_pieces.Text = Dt.Rows[0]["pieces"].ToString();
                     txt_cartons.Text = Dt.Rows[0]["cartons"].ToString();
                     txt_weight.Text = Dt.Rows[0]["weight"].ToString();
                     txt_dimension.Text = Dt.Rows[0]["dimensions"].ToString();
                     txt_invno.Text = Dt.Rows[0]["invoiceno"].ToString();
                     txt_dtinvdate.Text = Utility.fn_ConvertDate( Dt.Rows[0]["invoicedate"].ToString());
                     Dt = da_obj_FEPOobj.GetBookingDet(Convert.ToString(txt_bookno.Text), Convert.ToString(str_trantype), Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()));
                     if (Dt.Rows.Count > 0)
                     {
                         txt_custname.Text = Dt.Rows[0][2].ToString();
                         int_bookno = Convert.ToInt32(Dt.Rows[0][0].ToString());

                     }

                     btn_save.Text = "Update";
                     btn_save.ToolTip = "Update";
                     btn_save1.Attributes["class"] = "btn btn-update1";
                     //btn_back.Text = "Cancel";
                     btn_back.ToolTip = "Cancel";
                     btn_back.Attributes["class"] = "btn ico-cancel";
                     txt_style.Focus();
                 }
                 else
                 {
                 }
                
                 btn_back.Enabled = true;
             }
            
        }

        protected void btn_view_Click(object sender, EventArgs e)
        {
          //  DataAccess.LogDetails da_obj_Logobj = new DataAccess.LogDetails();
            string str_sf = "";
            string Str_P = "";
            string str_RptName = "";
            string str_frmname = "";
            string str_Script = "";
            str_trantype = Session["StrTranType"].ToString();
            Session["str_sfs"] = "";
            Session["str_sp"] = "";

            if (string.IsNullOrEmpty(txt_pono.Text))
            {
                //str_frmname = "FEPODetails";
                Str_P = "Title= UnApproved Credit Request";
                str_RptName = "FEPODetails.rpt";
                Session["str_sfs"] = "{PODetails.trantype}='" + Convert.ToString(str_trantype) + "'";
                str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + Str_P + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
               
                ScriptManager.RegisterStartupScript(btn_view, typeof(Button), "Shipment Details", str_Script, true);
            }
            else
            {
                //str_frmname = "FEPODetails";
                str_RptName = "FEPODetails.rpt";
                Session["str_sfs"] = "{PODetails.pono}='" + txt_pono.Text + "' and {PODetails.trantype}='" + Convert.ToString(str_trantype) + "'";
                str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + Str_P + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                
                ScriptManager.RegisterStartupScript(btn_view, typeof(Button), "Shipment Details", str_Script, true);
            }
            da_obj_Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"].ToString()), 204, 3, Convert.ToInt32(Session["LoginBranchid"].ToString()), "FE-POVew");
            UserRights();
        }

        protected void txt_bookno_TextChanged(object sender, EventArgs e)
        {
            //getdata();

            str_trantype = Session["StrTranType"].ToString();
          //  DataAccess.ForwardingExports.PODetails da_obj_FEPOobj = new DataAccess.ForwardingExports.PODetails();
            DataTable Dt = new DataTable();
            Dt = da_obj_FEPOobj.GetBookingDet(txt_bookno.Text, Convert.ToString(str_trantype), Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()));
            if (Dt.Rows.Count > 0)
            {
                txt_custname.Text = Dt.Rows[0][2].ToString();
                int_bookno = Convert.ToInt32(Dt.Rows[0][0].ToString());
                hf_hidid1.Value = int_bookno.ToString();
                txt_pono.Focus();
                btn_back.Enabled = true;
            }
            UserRights();
        }


        public void txtclear()
        {
           // DataAccess.LogDetails da_obj_Logobj = new DataAccess.LogDetails();
            txt_bookno.Text = "";
            txt_pono.Text = "";
            txt_style.Text = "";
            txt_pieces.Text = "";
            txt_cartons.Text = "";
            txt_weight.Text = "";
            txt_dimension.Text = "";
            txt_custname.Text = "";
            txt_invno.Text = "";
            txt_dtinvdate.Text = Utility.fn_ConvertDate(da_obj_Logobj.GetDate().ToString());
            grd.Visible = false;
        }

        protected void btn_back_Click(object sender, EventArgs e)
        {
            if (btn_back.ToolTip == "Cancel")
            {
                txtclear();
                txt_pono.Text = "";
                btn_save.Text = "Save";
                btn_save.ToolTip = "Save";
                btn_save1.Attributes["class"]="btn ico-save";
                btn_back.Enabled = true;
                btn_back.Text = "Back";
                btn_back.ToolTip = "Back";
                btn_cancel1.Attributes["class"] = "btn ico-back";
                txt_bookno.Focus();
                UserRights();
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
                            if (Session["StrTranType"].ToString() == "AE")
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

        protected void grd_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grd.PageIndex = e.NewPageIndex;
            DataTable dt=(DataTable)ViewState["GRD"];
            grd.DataSource = dt;
            grd.DataBind();
        }

        protected void grd_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(grd, "Select$" + e.Row.RowIndex);
            e.Row.Attributes["style"] = "cursor:pointer";
        }

        protected void txt_pono_TextChanged(object sender, EventArgs e)
        {

           
             getdata();
            UserRights();
           
           
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
            Panel3.Visible = true;
            DataTable obj_dtlogdetails = new DataTable();
            {
                obj_dtlogdetails = Logobj.InsTempGrpLogdtlsGet(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), 204, "Book", txt_bookno.Text, txt_bookno.Text, Session["StrTranType"].ToString());

                lbl_no.InnerText = "Booking #:";
               if (txt_bookno.Text != "")
                {
                    JobInput.Text = txt_bookno.Text;

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
}