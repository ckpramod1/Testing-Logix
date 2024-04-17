using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.Services;
using System.IO;
using System.Web.UI.HtmlControls;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html;
using iTextSharp.text.html.simpleparser;
using System.Web.UI.DataVisualization.Charting;
using System.Globalization;

namespace logix.MIS
{
    public partial class JMIS2 : System.Web.UI.Page
    {
        DataAccess.LogDetails Logobj = new DataAccess.LogDetails();
        string StrTranType = "";
        int empid = 0, intBranchID = 0, intDivID = 0, netret=0;
        protected void Page_Load(object sender, EventArgs e)
        {
            StrTranType = Session["StrTranType"].ToString();
            intDivID = Convert.ToInt32(Session["LoginDivisionId"].ToString());
            intBranchID = Convert.ToInt32(Session["LoginBranchid"].ToString());
            empid = Convert.ToInt32(Session["LoginEmpId"].ToString());
            if(!IsPostBack)
            {
                if (Session["From"] !=null)
                {
                   txt_from.Text=Session["From"].ToString();
                   txt_to.Text = Session["To"].ToString();
                   fn_MIS();
                   return;
                }
                txt_from.Text = Utility.fn_ConvertDate(Logobj.GetDate().ToShortDateString());
                txt_to.Text = txt_from.Text;
                Grd_MISA.DataSource = new DataTable();
                Grd_MISA.DataBind();
                Grd_MISD.DataSource = new DataTable();
                Grd_MISD.DataBind();
                Grd_MISC.DataSource = new DataTable();
                Grd_MISC.DataBind();
                Grd_MISB.DataSource = new DataTable();
                Grd_MISB.DataBind();
            }
        }

        protected void btn_get_Click(object sender, EventArgs e)
        {
            fn_MIS();
        }

        private void fn_MIS()
        {
            try
            {
                DataSet obj_ds = new DataSet();
                string str_fromdate = Utility.fn_ConvertDate(txt_from.Text);
                string str_todate = Utility.fn_ConvertDate(txt_to.Text);
                DateTime frm_date, to_date;
                frm_date = Convert.ToDateTime(str_fromdate);
                to_date = Convert.ToDateTime(str_todate);
                DataAccess.CostingDetails da_obj_Costing = new DataAccess.CostingDetails();
                if (Session["StrTranType"].ToString() == "AC")
                {
                    obj_ds = da_obj_Costing.SELTempMISFTWOAC(int.Parse(Session["LoginBranchid"].ToString()), frm_date, to_date, int.Parse(Session["LoginEmpId"].ToString()));
                }
                else
                {
                    obj_ds = da_obj_Costing.SELTempMISFTWO(Session["StrTranType"].ToString(), int.Parse(Session["LoginBranchid"].ToString()), frm_date, to_date, int.Parse(Session["LoginEmpId"].ToString()));
                }
                DataTable obj_dt = new DataTable();
                DataTable obj_dttemp = new DataTable();
                DataTable obj_dt_MISA = new DataTable();
                DataTable obj_dt_MISB = new DataTable();
                DataTable obj_dt_MISC = new DataTable();
                DataTable obj_dt_MISD = new DataTable();

                if (obj_ds.Tables.Count > 2)
                {
                    Pln_MIS.Visible = true;
                    obj_dt = obj_ds.Tables[0];
                    obj_dt_MISA = obj_ds.Tables[1];
                    obj_dt_MISB = obj_ds.Tables[2];
                    obj_dt_MISC = obj_ds.Tables[3];
                    obj_dt_MISD = obj_ds.Tables[4];
                    DataView obj_dvMIS = new DataView(obj_dt_MISD);
                    DataRow dr;
                    int i;
                    double MIS_A, MIS_B, MIS_C, MIS_D;
                    MIS_A = 0;
                    MIS_B = 0;
                    MIS_C = 0;
                    MIS_D = 0;
                    netret = 0;
                    if (obj_dt.Rows.Count > 0)
                    {
                        //obj_dt.DefaultView.Sort = "jobno";
                        obj_dvMIS.RowFilter = "flagtype='A'";
                        obj_dttemp = obj_dvMIS.ToTable();
                        i = obj_dt.Columns.Count - 4;
                        dr = obj_dt.NewRow();
                        dr[i] = "Total-A";
                        dr[i + 1] = obj_dttemp.Rows[0]["income"];
                        dr[i + 2] = obj_dttemp.Rows[0]["expense"];
                        dr[i + 3] = obj_dttemp.Rows[0]["Retention"];
                        MIS_A = Convert.ToDouble(obj_dttemp.Rows[0]["Retention"].ToString());
                        obj_dt.Rows.InsertAt(dr, obj_dt.Rows.Count + 1);
                        lbl_MISA.Visible = true;
                        Grd_MISA.Visible = true;
                        Grd_MISA.DataSource = obj_dt;
                        Grd_MISA.DataBind();
                    }
                    else
                    {
                        Grd_MISA.Visible = true;
                        Grd_MISA.DataSource = new DataTable();
                        Grd_MISA.DataBind();
                    }
                    if (obj_dt_MISA.Rows.Count > 0)
                    {
                        //obj_dt_MISA.DefaultView.Sort = "jobno";
                        obj_dvMIS.RowFilter = "flagtype='B'";
                        obj_dttemp = obj_dvMIS.ToTable();
                        i = obj_dt_MISA.Columns.Count - 4;
                        dr = obj_dt_MISA.NewRow();
                        dr[i] = "Total-D";
                        dr[i + 1] = obj_dttemp.Rows[0]["income"];
                        dr[i + 2] = obj_dttemp.Rows[0]["expense"];
                        dr[i + 3] = obj_dttemp.Rows[0]["Retention"];
                        MIS_D = Convert.ToDouble(obj_dttemp.Rows[0]["Retention"].ToString());
                        obj_dt_MISA.Rows.InsertAt(dr, obj_dt_MISA.Rows.Count + 1);
                        lbl_MISD.Visible = true;
                        Grd_MISD.Visible = true;
                        Grd_MISD.DataSource = obj_dt_MISA;
                        Grd_MISD.DataBind();
                    }
                    else
                    {
                        Grd_MISD.Visible = true;
                        Grd_MISD.DataSource = new DataTable();
                        Grd_MISD.DataBind();
                    }
                    if (obj_dt_MISB.Rows.Count > 0)
                    {
                        //obj_dt_MISB.DefaultView.Sort = "jobno";
                        obj_dvMIS.RowFilter = "flagtype='C'";
                        obj_dttemp = obj_dvMIS.ToTable();
                        i = obj_dt_MISB.Columns.Count - 4;
                        dr = obj_dt_MISB.NewRow();
                        dr[i] = "Total-C";
                        dr[i + 1] = obj_dttemp.Rows[0]["income"];
                        dr[i + 2] = obj_dttemp.Rows[0]["expense"];
                        dr[i + 3] = obj_dttemp.Rows[0]["Retention"];
                        MIS_C = Convert.ToDouble(obj_dttemp.Rows[0]["Retention"].ToString());
                        obj_dt_MISB.Rows.InsertAt(dr, obj_dt_MISB.Rows.Count + 1);
                        lbl_MISC.Visible = true;
                        Grd_MISC.Visible = true;
                        Grd_MISC.DataSource = obj_dt_MISB;
                        Grd_MISC.DataBind();
                    }
                    else
                    {
                        Grd_MISC.Visible = true;
                        Grd_MISC.DataSource = new DataTable();
                        Grd_MISC.DataBind();
                    }
                    if (obj_dt_MISC.Rows.Count > 0)
                    {
                        //obj_dt_MISC.DefaultView.Sort = "jobno";

                        obj_dvMIS.RowFilter = "flagtype='D'";
                        obj_dttemp = obj_dvMIS.ToTable();
                        i = obj_dt_MISC.Columns.Count - 4;
                        dr = obj_dt_MISC.NewRow();
                        dr[i] = "Total-B";
                        dr[i + 1] = obj_dttemp.Rows[0]["income"];
                        dr[i + 2] = obj_dttemp.Rows[0]["expense"];
                        dr[i + 3] = obj_dttemp.Rows[0]["Retention"];
                        MIS_B = Convert.ToDouble(obj_dttemp.Rows[0]["Retention"].ToString());
                        obj_dt_MISC.Rows.InsertAt(dr, obj_dt_MISC.Rows.Count + 1);
                        lbl_MISB.Visible = true;
                        Grd_MISB.Visible = true;
                        Grd_MISB.DataSource = obj_dt_MISC;
                        Grd_MISB.DataBind();
                    }
                    else
                    {
                        Grd_MISB.Visible = true;
                        Grd_MISB.DataSource = new DataTable();
                        Grd_MISB.DataBind();
                    }
                    if (obj_dt.Rows.Count > 0 || obj_dt_MISA.Rows.Count > 0 || obj_dt_MISB.Rows.Count > 0 || obj_dt_MISC.Rows.Count > 0)
                    {
                        netret = Convert.ToInt32(String.Format("{0:0.00}", ((MIS_A + MIS_B) - Math.Abs(MIS_C + MIS_D))));
                        lbl_retention.Text = "";
                        lbl_retention.Visible = true;
                        lbl_retention.Text = "(A+B) - (C+D)           Net Retention = " + netret;
                       // btn_cancel.Text = "Cancel";

                        btn_cancel.ToolTip = "Cancel";
                        btn_cancel1.Attributes["class"] = "btn ico-cancel";
                    }
                    
                    
                }
                else
                {
                    ScriptManager.RegisterStartupScript(btn_get, typeof(LinkButton), "MIS", "alertify.alert('No Data Found');", true);
                }

                //btn_cancel.Text = "Cancel";
                btn_cancel.ToolTip = "Cancel";
                btn_cancel1.Attributes["class"] = "btn ico-cancel";

            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        protected void btn_print_Click(object sender, EventArgs e)
        {
            string str_sp = "";
            string str_sf = "";
            string str_RptName = "";
            string str_Script = "";
            Session["str_sfs"] = "";
            Session["str_sp"] = "";
            if(StrTranType =="AC")
            {
                fn_MIS();
                str_RptName="FirstAC.rpt";
                str_sf="{TempMIS.empid}=" + empid + " and {TempMIS.bid}=" + intBranchID;
                str_sp = "netret=" + netret;

            }else
            {
                fn_MIS();
                str_RptName = "First.rpt";
                str_sf = "{TempMIS.empid}=" + empid + " and {TempMIS.bid}=" + intBranchID;
                str_sp = "netret=" + netret;
            }
            str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
            ScriptManager.RegisterStartupScript(btn_print, typeof(Button), "logix", str_Script, true);
            Session["str_sp"] = str_sp;
            Session["str_sfs"] = str_sf;
        }

        protected void btn_cancel_Click(object sender, EventArgs e)
        {
            if(btn_cancel.ToolTip =="Cancel")
            {
                txt_from.Text = Utility.fn_ConvertDate(Logobj.GetDate().ToShortDateString());
                txt_to.Text = txt_from.Text;
               // btn_cancel.Text = "Back";

                btn_cancel.ToolTip = "Back";
                btn_cancel1.Attributes["class"] = "btn ico-back";
                Grd_MISA.DataSource = new DataTable();
                Grd_MISA.DataBind();
                Grd_MISD.DataSource = new DataTable();
                Grd_MISD.DataBind();
                Grd_MISC.DataSource = new DataTable();
                Grd_MISC.DataBind();
                Grd_MISB.DataSource = new DataTable();
                Grd_MISB.DataBind();
            }else if(btn_cancel.ToolTip == "Back")
            {
                if(Session["From"] !=null)
                {
                    Response.Redirect("../MIS/MISBT.aspx", true);
                }
                this.Response.End();
            }
        }

        protected void btn_Jobdetails_Click(object sender, EventArgs e)
        {
            Response.Redirect("../BT/Jobdate.aspx",true);
        }


    }
}