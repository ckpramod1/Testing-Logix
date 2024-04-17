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
using System.Globalization;
using System.IO;

namespace logix.FI
{
    public partial class FIEvenTrucking : System.Web.UI.Page
    {
        DataAccess.ForwardingImports.JobInfo FIEVobj = new DataAccess.ForwardingImports.JobInfo();
        DataAccess.ForwardingExports.JobInfo FEJobObj = new DataAccess.ForwardingExports.JobInfo();
        static DataTable Dt = new DataTable();
        static int branchid, divisionid;
        DataAccess.LogDetails obj_da_Logobj = new DataAccess.LogDetails();


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

            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(btnexport);

            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(btnclear);
            grd.Attributes.Add("style", "word-break:break-all;word-wrap:break-word");
            branchid = Convert.ToInt32(Session["LoginBranchid"].ToString());
            divisionid = Convert.ToInt32(Session["LoginDivisionId"].ToString());

            if (Request.QueryString.ToString().Contains("OICSHomeFIEvenTrucking"))
            {
                crumbslbl.Attributes["class"] = "crumbslbl";
            }

            if (!IsPostBack)
            {
                try
                {
                    grd.DataSource = new DataTable();
                    grd.DataBind();
                    dtFrom.Text = obj_da_Logobj.GetDate().ToString("dd/MM/yyyy");
                    dtTo.Text = dtFrom.Text;
                    btnclear.Text = "Cancel";
                    btnclear.ToolTip = "Cancel";
                    btn_cancel1.Attributes["class"] = "btn ico-cancel";
                }
                catch (Exception ex)
                {
                    string message = ex.Message.ToString();
                    ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
                }

            }


        }

        [WebMethod]
        public static List<string> Getcusname(string prefix)
        {
            string custtype = "C";
            List<string> customer = new List<string>();
            DataTable obj_dt = new DataTable();
            DataAccess.Masters.MasterCustomer da_obj_customerobj = new DataAccess.Masters.MasterCustomer();
            obj_dt = da_obj_customerobj.GetLikeCustomer(prefix.ToUpper(), custtype);
            customer = Utility.Fn_DatatableToList_int16Display(obj_dt, "customer", "customerid", "customername");

            return customer;
        }

        protected void btnfind_Click(object sender, EventArgs e)
        {
            if (txtJobno.Text != "")
            {
                Dt = FIEVobj.GetFIEventTracking(branchid, hdf_cus.Value, Convert.ToInt32(txtJobno.Text), divisionid);
                if (Dt.Rows.Count > 0)
                {
                    grd.DataSource = Dt;
                    grd.DataBind();
                    btnclear.Text = "Cancel";
                    btnclear.ToolTip = "Cancel";
                    btn_cancel1.Attributes["class"] = "btn ico-cancel";
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "BL", "alertify.alert('No Events Available');", true);
                    btnclear.Text = "Cancel";
                    btnclear.ToolTip = "Cancel";
                    btn_cancel1.Attributes["class"] = "btn ico-cancel";
                    return;
                }

            }

            else if (txtCustomer.Text != "")
            {
                if (hf_customerid.Value != null)
                {
                    Dt = FIEVobj.GetFIEventTracking(branchid, hdf_cus.Value, Convert.ToInt32(hf_customerid.Value), divisionid);
                    if (Dt.Rows.Count > 0)
                    {
                        grd.DataSource = Dt;
                        grd.DataBind();

                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "BL", "alertify.alert('No Events Available');", true);
                        btnclear.Text = "Cancel";
                        btnclear.ToolTip = "Cancel";
                        btn_cancel1.Attributes["class"] = "btn ico-cancel";
                        return;
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "BL", "alertify.alert('Invalid Customer');", true);
                    btnclear.Text = "Cancel";
                    btnclear.ToolTip = "Cancel";
                    btn_cancel1.Attributes["class"] = "btn ico-cancel";
                    return;


                }
            }

            else if (dtFrom.Text != "" && dtTo.Text != "")
            {
                Dt = FEJobObj.GetEventBtwJobdates(branchid, "FI", Convert.ToDateTime(Utility.fn_ConvertDate(dtFrom.Text)), Convert.ToDateTime(Utility.fn_ConvertDate(dtTo.Text)), divisionid);
                if (Dt.Rows.Count > 0)
                {
                    grd.DataSource = Dt;
                    grd.DataBind();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "BL", "alertify.alert('No Events Available');", true);
                    return;
                }

            }
            //obj_da_Logobj.InsLogDetail(int.Parse(Session["LoginEmpId"].ToString()), 334, 3, int.Parse(Session["LoginBranchid"].ToString()), "View"); 
            obj_da_Logobj.InsLogDetail(int.Parse(Session["LoginEmpId"].ToString()), 334, 3, int.Parse(Session["LoginBranchid"].ToString()), " Trantype: " + Session["StrTranType"].ToString() + "/ Job #: " + grd.Rows[0].Cells[0].Text + "/ Find");
            
            txtJobno.Enabled = true;
            txtCustomer.Enabled = true;
            dtTo.Enabled = true;
            dtFrom.Enabled = true;
            btnfind.Enabled = true;
            dtFrom.Text = obj_da_Logobj.GetDate().ToString("dd/MM/yyyy");
            dtTo.Text = dtFrom.Text;
        }

        protected void btnclear_Click(object sender, EventArgs e)
        {
            if (btnclear.ToolTip == "Cancel")
            {
                txtJobno.Text = "";
                txtCustomer.Text = "";
                grd.DataSource = new DataTable();
                grd.DataBind();
                txtJobno.Enabled = true;
                txtCustomer.Enabled = true;
                dtFrom.Enabled = true;
                dtTo.Enabled = true;
                btnfind.Enabled = true;
                dtFrom.Text = obj_da_Logobj.GetDate().ToString("dd/MM/yyyy");
                dtTo.Text = dtFrom.Text;
                btnclear.Text = "Back";
                btnclear.ToolTip = "Back";
                btn_cancel1.Attributes["class"] = "btn ico-back";
            }
            else
            {

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

                        }
                    }
                }

                else if (Request.QueryString.ToString().Contains("OICSHomeFIEvenTrucking"))
                {
                    Response.Redirect("../Home/OICSHome.aspx");
                }
                else
                {
                    this.Response.End();
                }

            }
        }

        protected void btnexport_Click(object sender, EventArgs e)
        {
            btnclear.ToolTip = "Cancel";
            if (grd.Rows.Count > 0)
            {
                ExportToExcel();
            }
            else
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "BL", "alertify.alert('Record not Found');", true);
                return;
            }


        }

        protected void ExportToExcel()
        {
            btnclear.Text = "Cancel";
            btnclear.ToolTip = "Cancel";
            btn_cancel1.Attributes["class"] = "btn ico-cancel";
            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment;filename=EventTrucking.xls");
            Response.Charset = "";
            Response.ContentType = "application/vnd.ms-excel";
            using (StringWriter sw = new StringWriter())
            {
                HtmlTextWriter hw = new HtmlTextWriter(sw);

                grd.AllowPaging = false;

                grd.DataSource = Dt;
                grd.DataBind();

                foreach (System.Web.UI.WebControls.TableCell cell in grd.HeaderRow.Cells)
                {
                    cell.BackColor = grd.HeaderStyle.BackColor;
                }
                foreach (GridViewRow row in grd.Rows)
                {
                    foreach (System.Web.UI.WebControls.TableCell cell in row.Cells)
                    {
                        if (row.RowIndex % 2 == 0)
                        {
                            cell.BackColor = grd.AlternatingRowStyle.BackColor;
                        }
                        else
                        {
                            cell.BackColor = grd.RowStyle.BackColor;
                        }
                        cell.CssClass = "textmode";
                    }
                }
                obj_da_Logobj.InsLogDetail(int.Parse(Session["LoginEmpId"].ToString()), 334, 3, int.Parse(Session["LoginBranchid"].ToString()), "Export");
                grd.RenderControl(hw);
                string style = @"<style> .textmode { } </style>";
                Response.Write(style);
                Response.Output.Write(sw.ToString());
                Response.Flush();
                Response.End();
            }
        }


        public override void VerifyRenderingInServerForm(Control control)
        {

        }

        protected void txtCustomer_TextChanged(object sender, EventArgs e)
        {
            string svalue;
            if (txtCustomer.Text != "")
            {
                svalue = "C";
                txtJobno.Enabled = false;
                hdf_cus.Value = svalue;
                dtFrom.Enabled = false;
                dtTo.Enabled = false;
                btnclear.Text = "Cancel";
                btnclear.ToolTip = "Cancel";
                btn_cancel1.Attributes["class"] = "btn ico-cancel";
            }
        }

        protected void txtJobno_TextChanged(object sender, EventArgs e)
        {
            string svalue;
            if (txtJobno.Text != "")
            {
                txtCustomer.Enabled = true;
                svalue = "J";
                hdf_cus.Value = svalue;
                dtFrom.Enabled = false;
                dtTo.Enabled = false;
               btnclear.Text = "Cancel";
                btnclear.ToolTip = "Cancel";
                btn_cancel1.Attributes["class"] = "btn ico-cancel";
            }
        }

        protected void dtFrom_TextChanged(object sender, EventArgs e)
        {
            txtCustomer.Enabled = false;
            txtJobno.Enabled = false;
            btnclear.Text = "Cancel";
            btnclear.ToolTip = "Cancel";
            btn_cancel1.Attributes["class"] = "btn ico-cancel";
        }

        protected void dtTo_TextChanged(object sender, EventArgs e)
        {
            txtCustomer.Enabled = false;
            txtJobno.Enabled = false;
            btnclear.Text = "Cancel";
            btnclear.ToolTip = "Cancel";
            btn_cancel1.Attributes["class"] = "btn ico-cancel";
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
            JobInput.Text = "";
            GridViewlog.Visible = true;
            Panel2.Visible = true;
            DataTable obj_dtlogdetails = new DataTable();

            obj_dtlogdetails = obj_da_Logobj.InsTempGrpLogdtlsGet(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), 334, "Job", txtJobno.Text, txtJobno.Text, Session["StrTranType"].ToString());
            if (txtJobno.Text != "")
            {
                JobInput.Text = txtJobno.Text;
            }

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
