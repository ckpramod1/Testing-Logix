using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Runtime.Remoting;

namespace logix.FI
{
    public partial class ContainerDestuff : System.Web.UI.Page
    {
        int int_divisionid;
        string str_closedjob;
        int int_branchid;
        DataAccess.LogDetails Logobj = new DataAccess.LogDetails();
        DataAccess.ForwardingImports.JobInfo obj_da_jinfo = new DataAccess.ForwardingImports.JobInfo();
        DateTime date;
        protected void Page_Load(object sender, EventArgs e)
        {


            string Ccode = Convert.ToString(Session["Ccode"]);

            if (Ccode != "")
            {

                Logobj.GetDataBase(Ccode);
                obj_da_jinfo.GetDataBase(Ccode);
               


            }
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "SpanTagMoveInputBottom();MuiTextField();", true);

            if (Session["LoginUserName"] == null || Session["LoginEmpId"] == null || Session["LoginDivisionId"] == null || Session["LoginBranchid"] == null)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alertify.alert('Session TimeOut');window.open('"+ Session["Site"].ToString() + "/','_top');", true);
            }
            else if (Session["StrTranType"] == null)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alertify.alert('Session TimeOut');window.open('"+ Session["Site"].ToString() + "/FormMain.aspx','_top');", true);
            }

            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(btn_cancel);
            if (!IsPostBack)
            {
                //date=;
                txt_eta.Text = Convert.ToDateTime(Logobj.GetDate().ToShortDateString()).ToString("dd/MM/yyyy");
                txt_dstuff.Text = Convert.ToDateTime(Logobj.GetDate().ToShortDateString()).ToString("dd/MM/yyyy");
                btn_cancel.Text = "Cancel";
                btn_cancel.ToolTip = "Cancel";
                btn_cancel1.Attributes["class"] = "btn ico-cancel";
            }

            int_divisionid = Convert.ToInt32(Session["LoginDivisionId"].ToString());
            int_branchid = Convert.ToInt32(Session["LoginBranchid"].ToString());
        }
        protected void btn_cancel_Click(object sender, EventArgs e)
        {
           if(btn_cancel.ToolTip =="Cancel")
           {
               JobInput.Text = "";
               pnl_dstuff.Visible = false;
            txt_job.Text = "";
            txt_vvoy.Text = "";
            txt_agent.Text = "";
            txt_mlo.Text = "";
            txt_con.Text = "";
            txt_size.Text = "";
            txt_seal.Text = "";
            txt_eta.Text = Convert.ToDateTime(Logobj.GetDate().ToShortDateString()).ToString("dd/MM/yyyy");
            txt_dstuff.Text = Convert.ToDateTime(Logobj.GetDate().ToShortDateString()).ToString("dd/MM/yyyy");
            txt_job.Focus();
            grd_dstuff.DataSource = null;
            grd_dstuff.DataBind();
            txt_job.Enabled = true;
            txt_vvoy.Enabled = true;
            txt_agent.Enabled = true;
            txt_mlo.Enabled = true;
            txt_eta.Enabled = true;
            btn_update.Enabled = true;
            txt_con.Enabled = true;
            txt_size.Enabled = true;
            txt_seal.Enabled = true;
            grd_dstuff.Enabled = true;
            btn_cancel.Text = "Back";
            btn_cancel.ToolTip = "Back";
            btn_cancel1.Attributes["class"] = "btn ico-back";
            }
           else
           {
               //this.Response.End();
               if (Session["home"] != null)
               {
                   if (Session["home"].ToString() == "OPS&DOC")
                   {
                       if (Session["StrTranType"].ToString() == "FI")
                       {

                           Response.Redirect("../Home/OEOpsAndDocs.aspx");

                       }
                       else
                       {
                           this.Response.End();

                       }
                   }
               }
               else
               {
                   this.Response.End();

               }
           }
        }

        protected void txt_job_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int_divisionid = Convert.ToInt32(Session["LoginDivisionId"].ToString());
                int_branchid = Convert.ToInt32(Session["LoginBranchid"].ToString());

                DataTable obj_dt_jinfo = new DataTable();
                DataAccess.ForwardingImports.JobInfo obj_da_jinfo = new DataAccess.ForwardingImports.JobInfo();
                string Ccode = HttpContext.Current.Session["Ccode"].ToString();
                obj_da_jinfo.GetDataBase(Ccode);

                if (txt_job.Text != "")
                {
                    obj_dt_jinfo = obj_da_jinfo.GetJobInfoforDestuff(Convert.ToInt32(txt_job.Text), int_branchid, int_divisionid);
                    if (obj_dt_jinfo.Rows.Count > 0)
                    {

                        str_closedjob = obj_dt_jinfo.Rows[0]["closedjob"].ToString();
                        txt_vvoy.Text = obj_dt_jinfo.Rows[0]["vslvoy"].ToString();
                        txt_agent.Text = obj_dt_jinfo.Rows[0]["agent"].ToString();
                        txt_mlo.Text = obj_dt_jinfo.Rows[0]["mlo"].ToString();
                      //  txt_eta.Text=Utility.fn_ConvertDate(obj_dt_jinfo.Rows[0]["eta"].ToString());
                         //DateTime dtime= Convert.ToDateTime(Utility.fn_ConvertDate(obj_dt_jinfo.Rows[0]["eta"].ToString()).ToString());
                        txt_eta.Text = Convert.ToDateTime(obj_dt_jinfo.Rows[0]["eta"].ToString()).ToString("dd/MM/yyyy");

                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(btn_update, typeof(Button), "DataFound", "alertify.alert('Invalid Job #');", true);
                    }

                    DataTable obj_dt_dstuff = new DataTable();
                    obj_dt_dstuff = obj_da_jinfo.GetContforDestuff(Convert.ToInt32(txt_job.Text), int_branchid, int_divisionid);
                    if (obj_dt_dstuff.Rows.Count > 0)
                    {
                        pnl_dstuff.Visible = true;
                        grd_dstuff.DataSource = obj_dt_dstuff;
                        grd_dstuff.DataBind();
                    }
                    if (str_closedjob == "True")
                    {
                        txt_job.Enabled = false;
                        txt_vvoy.Enabled = false;
                        txt_agent.Enabled = false;
                        txt_mlo.Enabled = false;
                        txt_eta.Enabled = false;
                        btn_update.Enabled = false;
                        txt_con.Enabled = false;
                        txt_size.Enabled = false;
                        txt_seal.Enabled = false;
                        grd_dstuff.Enabled = false;
                        ScriptManager.RegisterStartupScript(btn_update, typeof(Button), "DataFound", "alertify.alert('Job is Closed');", true);
                    }
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }

        }

        protected void grd_dstuff_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int index;

                if (grd_dstuff.Rows.Count > 0)
                {
                    index = Convert.ToInt32(grd_dstuff.SelectedRow.RowIndex.ToString());
                    txt_con.Text = grd_dstuff.Rows[index].Cells[0].Text;
                    txt_size.Text = grd_dstuff.Rows[index].Cells[1].Text;
                    txt_seal.Text = grd_dstuff.Rows[index].Cells[2].Text;

                    //if (!(System.Convert.IsDBNull(grd_dstuff.Rows[index].Cells[3].Text) == true))
                    if (grd_dstuff.Rows[index].Cells[3].Text=="")
                    {
                        txt_dstuff.Text = Convert.ToDateTime(Logobj.GetDate().ToShortDateString()).ToString("dd/MM/yyyy"); 
                    }
                    else
                    {
                        txt_dstuff.Text = grd_dstuff.Rows[index].Cells[3].Text;
                    }
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }


        }

        protected void btn_update_Click(object sender, EventArgs e)
        {
            DataAccess.ForwardingImports.JobInfo obj_da_jinfo = new DataAccess.ForwardingImports.JobInfo();

            string Ccode = HttpContext.Current.Session["Ccode"].ToString();
            obj_da_jinfo.GetDataBase(Ccode);
            DataTable obj_dt_jinfo = new DataTable();
            try
            {
                if (txt_con.Text != "")
                {
                    if (Convert.ToDateTime(Utility.fn_ConvertDate(txt_eta.Text)) < Convert.ToDateTime(Utility.fn_ConvertDate(txt_dstuff.Text)))
                    {
                        obj_da_jinfo.UpdFIContDtlsForDestuff(Convert.ToInt32(txt_job.Text), int_branchid, int_divisionid, Convert.ToDateTime(Utility.fn_ConvertDatetime(txt_dstuff.Text)), txt_con.Text);
                        ScriptManager.RegisterStartupScript(btn_update, typeof(Button), "DataFound", "alertify.alert('Details Updated');", true);
                        txt_con.Text = "";
                        txt_size.Text = "";
                        txt_seal.Text = "";
                        txt_dstuff.Text = Convert.ToDateTime(Logobj.GetDate().ToShortDateString()).ToString("dd/MM/yyyy");
                        obj_dt_jinfo = obj_da_jinfo.GetContforDestuff(Convert.ToInt32(txt_job.Text), int_branchid, int_divisionid);
                        if (obj_dt_jinfo.Rows.Count > 0)
                        {
                            pnl_dstuff.Visible = true;
                            grd_dstuff.DataSource = obj_dt_jinfo;
                            grd_dstuff.DataBind();
                        }
                        Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"].ToString()), 178, 2, Convert.ToInt32(Session["LoginBranchid"].ToString()), txt_job.Text + " Upd");
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(btn_update, typeof(Button), "DataFound", "alertify.alert('Destuff Date Should be Greater than ETA Date');", true);
                        txt_dstuff.Focus();
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(btn_update, typeof(Button), "DataFound", "alertify.alert('Select the Container#');", true);
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }

        }

        protected void grd_dstuff_RowDataBound(object sender, GridViewRowEventArgs e)
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

                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(grd_dstuff, "Select$" + e.Row.RowIndex);
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

            obj_dtlogdetails = Logobj.InsTempGrpLogdtlsGet(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), 178, "DESTUFF", txt_job.Text, txt_job.Text, "");  //"/Rate ID: " +
            if (txt_job.Text != "")
            {
                JobInput.Text = txt_job.Text;
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






