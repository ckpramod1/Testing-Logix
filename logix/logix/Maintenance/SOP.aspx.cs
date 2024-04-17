using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Web.Services;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;


namespace logix.Maintenance
{
   
    public partial class SOP : System.Web.UI.Page
    {
        DataAccess.Masters.MasterPort portobj = new DataAccess.Masters.MasterPort();
        DataAccess.Masters.MasterCustomer customerobj = new DataAccess.Masters.MasterCustomer();
        DataAccess.LogDetails obj_da_Log = new DataAccess.LogDetails();
        DataAccess.Masters.MasterCustomer objtele = new DataAccess.Masters.MasterCustomer();
             DataTable dt_cusname = new DataTable();
             DataTable obj_dt = new DataTable();
             DataTable dtid = new DataTable();
             int id;
        protected void Page_Load(object sender, EventArgs e)
        {
            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(btn_back);
            if (Session["LoginUserName"] == null)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alertify.alert('Session TimeOut');window.open('"+ Session["Site"].ToString() + "/','_top');", true);
            }
            if (!IsPostBack)
            {
                grdcustomer.DataSource = Utility.Fn_GetEmptyDataTable();
                grdcustomer.DataBind();
                grd.DataSource = Utility.Fn_GetEmptyDataTable();
                grd.DataBind();
             //   btn_back.Text = "Cancel";
                btn_back.ToolTip = "Cancel";
                btn_back1.Attributes["class"] = "btn ico-cancel";
                sop();
                txt_Customer.Focus();
            }
           // btn_add.Text = "Add";
            btn_add.ToolTip = "Add";
            btn_add1.Attributes["class"] = "btn btn-add1";

        }

        protected void btn_search_Click(object sender, EventArgs e)
        {
            DataTable obj_dtEmp = new DataTable();
            if (Session["Date"] != null)
            {
                obj_dtEmp = (DataTable)Session["Date"];
                grdcustomer.DataSource = obj_dtEmp;
                grdcustomer.DataBind();
                //foreach (GridViewRow row in Grd_Emp.Rows)
                //{
                //    LinkButton LnkBtn = (LinkButton)row.Cells[0].Controls[1];
                //    LnkBtn.ID = LnkBtn.Text;
                //    LnkBtn.Attributes.Add("OnClick", "return Get_EmpCode('" + hid.Value.ToString() + "','" + LnkBtn.Text + "')");
                //}
            }

            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "test", "TxtFocus();", true);
          //  btn_back.Text = "Cancel";
            btn_back.ToolTip = "Cancel";
            btn_back1.Attributes["class"] = "btn ico-cancel";
        }

        [WebMethod]
        public static List<string> Getbillname(string prefix)
        {
            DataAccess.Masters.MasterCustomer objtele = new DataAccess.Masters.MasterCustomer();
            List<string> billname = new List<string>();
            DataTable dt_Billname = new DataTable();
           dt_Billname = objtele.GetLikeCustomerAll(prefix.ToUpper());
           // dt_Billname = objtele.GetLikeCustsop(prefix);
          //  dt_Billname = objtele.GetLikeCustomersop(prefix);

            billname = Utility.Fn_TableToList(dt_Billname, "customername", "customerid");
            return billname;
        }




      //  protected void 
        //[WebMethod]
        //public static void GetCustomer(string Prefix)
        //{
        //    if (Prefix.Length > 0)
        //    {
        //        DataAccess.Masters.MasterCustomer objtele = new DataAccess.Masters.MasterCustomer();
        //        DataTable dt_cusname = new DataTable();
        //        DataTable obj_dt = new DataTable();
        //        obj_dt = objtele.GetLikeCustomerAll(Prefix);            
        //        dt_cusname.Columns.Add("customerid");
        //        dt_cusname.Columns.Add("customername");
        //        dt_cusname.Columns.Add("city");
        //        DataRow dr;

        //        for (int i = 0; i <= obj_dt.Rows.Count - 1; i++)
        //        {
        //            dr = dt_cusname.NewRow();
        //            dt_cusname.Rows.Add(dr);
        //            dr["customerid"] = obj_dt.Rows[i]["customerid"].ToString();
        //            dr["customername"] = obj_dt.Rows[i]["customername"].ToString();
        //            dr["city"] = obj_dt.Rows[i]["city"].ToString();
                    

        //        }
        //        HttpContext.Current.Session["Date"] = dt_cusname;
               
        //    }
           

        //}

        protected void get_Value()
        {
            obj_dt = objtele.GetLikeCustomerAll(txt_Customer.Text.ToUpper());           
            
            dt_cusname.Columns.Add("customerid");
            dt_cusname.Columns.Add("customername");
            dt_cusname.Columns.Add("city");
            DataRow dr;

            for (int i = 0; i <= obj_dt.Rows.Count - 1; i++)
            {
                dr = dt_cusname.NewRow();
                dt_cusname.Rows.Add(dr);
                dr["customerid"] = obj_dt.Rows[i]["customerid"].ToString();
                dr["customername"] = obj_dt.Rows[i]["customername"].ToString();
                dr["city"] = portobj.GetPortname(Convert.ToInt32(obj_dt.Rows[i]["city"].ToString()));

              //  dr["city"]= portobj.GetPortname(Convert.ToInt32(dr["city"]));
            }
            grdcustomer.DataSource = (DataTable)dt_cusname;
            grdcustomer.DataBind();
            ViewState["grdcustomer"] = (DataTable)dt_cusname;
        }
             

        protected void txt_Customer_TextChanged(object sender, EventArgs e)
        {
            get_Value();
               sop();
        }

        protected void btn_add_Click(object sender, EventArgs e)
        {

            string st = null;
            int i = 0;
            int j = 0;
            int c = 0;
            int count=0;
            string status = "";
            if (txtsop.Text == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "SOP", "alertify.alert('Enter the value');", true);
                txtsop.Focus();
                return;
            }
            if (ddlStatus.SelectedIndex == 0)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "SOP", "alertify.alert('Select the status');", true);
                return;
            }
            else
            {
                st = ddlStatus.Text;
            }



            if (grdcustomer.Rows.Count > 0)
            {
                if (ddlStatus.Text == "Important")
                {
                    status = "I";
                }
                else if (ddlStatus.Text == "Mandatory")
                {
                    status = "M";
                }
                else
                {
                    status = "N";
                }

                for (j = 0; j <= grdcustomer.Rows.Count - 1; j++)
                {

                    CheckBox chkRow = (grdcustomer.Rows[j].Cells[3].FindControl("grdblselect") as CheckBox);
                    if (chkRow.Checked == true)
                    {
                        count = 1;
                        customerobj.insertsop(Convert.ToInt32(grdcustomer.Rows[j].Cells[0].Text), txtsop.Text.ToUpper(), status, txt_Customer.Text.ToUpper());                      
                        obj_da_Log.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1456, 1, int.Parse(Session["LoginBranchid"].ToString()), "C-" + grdcustomer.Rows[j].Cells[0].Text + "S-" + txtsop.Text);
                        sop();
                       // btn_add.Text = "Upd";
                      //  btn_back.Text = "Cancel";

                        btn_add.ToolTip = "Upd";
                        btn_add1.Attributes["class"] = "btn btn-UpdateAdd2";

                        btn_back.ToolTip = "Cancel";
                        btn_back1.Attributes["class"] = "btn ico-cancel";
                        
                    }
                  
                }

            }
            if (count == 0)
            {
                ScriptManager.RegisterStartupScript(btn_add, typeof(Button), "SOP", "alertify.alert('Please select the customer');", true);
                count = 0;
                return;
            }
                                     
                 

         //if (btn_add.Text == "Upd")
         //   {
         //       btn_add.Text = "Upd";
         //       btn_back.Text = "Cancel";
         //   }
          
            txtsop.Enabled = true;
            txtsop.Text = "";
            ddlStatus.SelectedIndex = -1;
           // btn_back.Text = "Cancel";
            btn_back.ToolTip = "Cancel";
            btn_back1.Attributes["class"] = "btn ico-cancel";

        }

        protected void btn_back_Click(object sender, EventArgs e)
        {
            if(btn_back.ToolTip == "Cancel")
            {
                txt_Customer.Text = "";
                ddlStatus.SelectedIndex = -1;
                txtsop.Text = "";
                txtsop.Enabled = true;
              //  btn_add.Text = "Add";
              //  btn_back.Text = "Back";

                btn_add.ToolTip = "Add";
                btn_add1.Attributes["class"] = "btn btn-add1";
                btn_back.ToolTip = "Back";
                btn_back1.Attributes["class"] = "btn ico-back";

                grdcustomer.DataSource = Utility.Fn_GetEmptyDataTable();
                grdcustomer.DataBind();
                grd.DataSource = Utility.Fn_GetEmptyDataTable();
                grd.DataBind();
                txt_Customer.Focus();
                }
            else
            {
                this.Response.End();
            }
       
        }

       

        protected void btnyes_Click(object sender, EventArgs e)
        {
            try
            {
                //cusobj.SPUpdReqCustomerReject(Convert.ToInt32(hf_customerid.Value));
               // int cid = Convert.ToInt32(hf_customerid.Value);
                //obj_da_Log.InsLogDetail(int.Parse(Session["LoginEmpId"].ToString()), 131, 1, int.Parse(Session["LoginBranchid"].ToString()), "Cid:" + cid + " /Rej");
                 
                //customerobj.Delsop(onvert.ToInt32(grdcustomer.Rows[j].Cells[0].Text, grd.Rows(index).Cells("grdsop").Value, grd.Rows(index).Cells("grdstatus").Value)
                //    Logobj.InsLogDetail(Login.logempid, 1456, 4, Login.branchid, "C-" & grdcustomer.Rows(j).Cells("grdcustomerid").Value & "S-" & txtsop.Text.Trim())
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        protected void grd_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
              
                string str_sop,str_status=null;
                string st = null;
                int i = 0;
                int j = 0;
                int c = 0;
                int l;
                int count=0;
                string status = null;
                int int_index;
              //  int_index = grd.SelectedRow.RowIndex;
                DataTable dt = new DataTable();

                dt = customerobj.Getsopnew(txt_Customer.Text);
                grd.DataSource = dt;
                grd.DataBind();
               

                for (l = 0; l <= grdcustomer.Rows.Count - 1; l++)
                {
                    CheckBox chkRow = (grdcustomer.Rows[l].Cells[3].FindControl("grdblselect") as CheckBox);
                    chkRow.Checked = false;

                }
               
             
              
                if (e.CommandName == "Delete")
                {
                    ImageButton Img_delete = (ImageButton)e.CommandSource;
                    GridViewRow grd1 = (GridViewRow)Img_delete.NamingContainer;
                  

                    str_sop = grd.Rows[grd1.RowIndex].Cells[0].Text;
                    str_status = grd.Rows[grd1.RowIndex].Cells[1].Text;
                     if (str_status == "Important")
                        {
                            status = "I";
                        }
                        else if (str_status == "Mandatory")
                        {
                            status = "M";
                        }
                        else
                        {
                            status = "N";
                        }
                    
                  dtid = customerobj.GetCustid4msop(status, grd.Rows[grd1.RowIndex].Cells[0].Text, txt_Customer.Text.ToUpper());
                    id = Convert.ToInt32(dtid.Rows[0]["customerid"].ToString());
                   
                        for (int p = 0; p <= grdcustomer.Rows.Count - 1; p++)
                        {
                            int cid = Convert.ToInt32(grdcustomer.Rows[p].Cells[0].Text);
                            CheckBox chkRows = (grdcustomer.Rows[p].Cells[2].FindControl("grdblselect") as CheckBox);
                            if (id == cid)
                            {

                                chkRows.Checked = true;
                               
                            }
                            else
                            {
                                chkRows.Checked = false;
                              
                               
                            }
                        }
                        for (int q = 0;q <= grdcustomer.Rows.Count - 1; q++)
                        {
                           
                            CheckBox chkRows = (grdcustomer.Rows[q].Cells[2].FindControl("grdblselect") as CheckBox);
                            if(chkRows.Checked==true)
                            {
                                customerobj.Delsop(id, str_sop, status);
                                DataTable obj_dt = (DataTable)(ViewState["sop"]);
                                obj_dt.Rows[grd1.RowIndex].Delete();
                                obj_dt.AcceptChanges();
                                obj_da_Log.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1456, 4, int.Parse(Session["LoginBranchid"].ToString()), "C-" + grdcustomer.Rows[j].Cells[0].Text + "S-" + txtsop.Text);
                                count = 1;                              
                            }
                           
                        }
                    if(count==0)
                    {
                        ScriptManager.RegisterStartupScript(Img_delete, typeof(ImageButton), "SOP", "alertify.alert('Error');", true);
                         return;
                    }
                    else
                    {
                        DataTable dta = new DataTable();
                        dta = customerobj.Getsopnew(txt_Customer.Text);
                        //dta.Rows[grd1.RowIndex].Delete();
                        //dta.AcceptChanges();                       
                        grd.DataSource = Utility.Fn_GetEmptyDataTable();
                        grd.DataBind();

                        grd.DataSource = dta;
                        grd.DataBind();
                        ViewState["sop"] = dta;
                    }
                   

                }
                //btn_add.Text = "Add";

                btn_add.ToolTip = "Add";
                btn_add1.Attributes["class"] = "btn btn-add1";
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        protected void grd_RowDataBound(object sender, GridViewRowEventArgs e)
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
                ImageButton lnkbtnresult = (ImageButton)e.Row.FindControl("Img_Delete");
                lnkbtnresult.Attributes.Add("onclick", "javascript:return ConfirmationBox()");
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(grd, "Select$" + e.Row.RowIndex);
                e.Row.Attributes["style"] = "cursor:pointer";
            }
        }
        public void sop()
        {
            DataTable dta = new DataTable();
            dta = customerobj.Getsopnew(txt_Customer.Text);
            grd.DataSource = Utility.Fn_GetEmptyDataTable();
            grd.DataBind();
            grd.DataSource = dta;
            grd.DataBind();
            ViewState["sop"] = dta;
            
           
        }


        protected void grd_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                txtsop.Text = grd.SelectedRow.Cells[0].Text;
                string status = "";
                if (grd.SelectedRow.Cells[1].Text == "Important")
                {
                    status = "I";
                }
                else if (grd.SelectedRow.Cells[1].Text == "Mandatory")
                {
                    status = "M";
                }
                else
                {
                    status = "N";
                }
                ddlStatus.Text = grd.SelectedRow.Cells[1].Text;
             
                DataTable dt1= (DataTable)(ViewState["grdcustomer"]);
                dtid = customerobj.GetCustid4msop(status, grd.SelectedRow.Cells[0].Text, txt_Customer.Text.ToUpper());
                id = Convert.ToInt32(dtid.Rows[0]["customerid"].ToString());

                for (int p = 0; p <= grdcustomer.Rows.Count - 1; p++)
                {
                    int cid = Convert.ToInt32(grdcustomer.Rows[p].Cells[0].Text);
                    CheckBox chkRows = (grdcustomer.Rows[p].Cells[2].FindControl("grdblselect") as CheckBox);
                    if (id == cid)
                    {

                        chkRows.Checked = true;

                    }
                    else
                    {
                        chkRows.Checked = false;


                    }
                }
                //btn_add.Text = "Upd";

                btn_add.ToolTip = "Upd";
                btn_add1.Attributes["class"] = "btn btn-UpdateAdd2";
                //this.PopUpService.Show();                   
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        protected void grd_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

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
            PanelLog1.Visible = true;
            GridViewlog.Visible = true;
            Panel2.Visible = true;
            DataAccess.LogDetails obj_da_Log = new DataAccess.LogDetails();
            DataTable obj_dtlogdetails = new DataTable();

            obj_dtlogdetails = obj_da_Log.InsTempGrpLogdtlsGet(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), 1456, "MSsop", txt_Customer.Text, txt_Customer.Text, "");  //"/Rate ID: " +
            if (txt_Customer.Text != "")
            {
                JobInput.Text = txt_Customer.Text;
             }
            else
            {
                JobInput.Text = "";
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