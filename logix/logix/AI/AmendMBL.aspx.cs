using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace logix.Maintenance
{
    public partial class AmendMBL : System.Web.UI.Page
    {
        DataAccess.ForwardingExports.AmendBL Amendobj = new DataAccess.ForwardingExports.AmendBL();
        DataAccess.Accounts.Invoice INVOICEobj = new DataAccess.Accounts.Invoice();
        DataAccess.LogDetails Logobj = new DataAccess.LogDetails();
        // DataAccess.HR.Employee hrempobj = new DataAccess.HR.Employee();
        DataTable Dt = new DataTable();
        //int int_divisionid;
        //int int_branchid;
        //int int_empid;
        string str_TranType;
        // string str_oldblno;
        string mbl;

        protected void Page_Load(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "GenerateLabelAfter();", true);

            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(btn_back);

            if (Session["LoginUserName"] == null || Session["LoginEmpId"] == null || Session["LoginDivisionId"] == null || Session["LoginBranchid"] == null)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alertify.alert('Session TimeOut');window.open('"+ Session["Site"].ToString() + "/','_top');", true);
            }

            else if (Session["StrTranType"] == null)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alertify.alert('Session TimeOut');window.open('"+ Session["Site"].ToString() + "/FormMain.aspx','_top');", true);
            }

            str_TranType = Session["StrTranType"].ToString();
            if (!IsPostBack == true)
            {

                try
                {
                    if (Session["StrTranType"].ToString() == "FE")
                    {
                        headerlable1.InnerText = "OceanExports";
                    }
                    else if (Session["StrTranType"].ToString() == "FI")
                    {
                        headerlable1.InnerText = "OceanImports";
                    }
                    else if (Session["StrTranType"].ToString() == "AE")
                    {
                        headerlable1.InnerText = "AirExports";
                    }
                    else if (Session["StrTranType"].ToString() == "AI")
                    {
                        headerlable1.InnerText = "AirImports";
                    }

                    if (Request.QueryString.ToString().Contains("jobno"))
                    {
                        txt_Job.Text = Request.QueryString["jobno"].ToString();
                        txt_Job_TextChanged(sender, e);
                    }


                    //  str_TranType = Session["StrTranType"].ToString();
                }
                catch (Exception ex)
                {
                    string message = ex.Message.ToString();
                    ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
                }
            }
        }


        protected void btn_Amendbl_Click(object sender, EventArgs e)
        {
            if (txt_Job.Text != "")
            {
                // txt_Mbl.Text = txt_AmedBl.Text.ToUpper();
                Hid_amendbl.Value = txt_AmedBl.Text.Trim();
                Hid_amendmbl.Value = txt_Mbl.Text;
                string str_newblno;

                int bid = Convert.ToInt32(HttpContext.Current.Session["LoginBranchid"].ToString());
                int did = Convert.ToInt32(HttpContext.Current.Session["LoginDivisionid"].ToString());
                int empid = Convert.ToInt32(HttpContext.Current.Session["LoginEmpId"].ToString());
                if (txt_AmedBl.Text.Trim() != "")
                {
                    Dt = Amendobj.GetMBLnoToAmend(str_TranType, Convert.ToInt32(Session["LoginBranchid"]), txt_AmedBl.Text.Trim().ToUpper());
                    for (int i = 0; i <= Dt.Rows.Count - 1; i++)
                    {
                        if (txt_AmedBl.Text.Trim().ToUpper() == Dt.Rows[i].ItemArray[0].ToString())
                        {
                            ScriptManager.RegisterStartupScript(btn_Amendbl, typeof(Button), "DataFound", "alertify.alert('Mbl# Already Exist');", true);
                            txt_AmedBl.Focus();
                            txt_AmedBl.Text = "";
                            return;
                        }
                    }

                    Dt = Amendobj.GetBLno(str_TranType, txt_AmedBl.Text.Trim().ToUpper(), Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(Session["LoginDivisionId"]));
                    for (int i = 0; i < Dt.Rows.Count; i++)
                    {
                        if (txt_AmedBl.Text.Trim().ToUpper() == Dt.Rows[i][0].ToString())
                        {
                            ScriptManager.RegisterStartupScript(btn_Amendbl, typeof(Button), "DataFound", "alertify.alert('BLno #:" + txt_AmedBl.Text.ToUpper() + " Already Exist');", true);
                            txt_AmedBl.Focus();
                            txt_AmedBl.Text = "";
                            return;

                        }

                    }
                    Amendobj.UpdAmendMBL(txt_Mbl.Text.ToUpper(), txt_Job.Text, txt_AmedBl.Text.Trim().ToUpper(), str_TranType, Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(Session["LoginDivisionId"]));
                    Session["amendmbl"] = txt_AmedBl.Text.Trim().ToUpper();
                    switch (str_TranType)
                    {
                        case "FE":
                            Logobj.InsLogDetail(empid, 93, 1, bid, txt_Mbl.Text.Trim().ToUpper() + "/" + txt_AmedBl.Text.Trim().ToUpper() + "/AmdMBL");
                            break;
                        case "FI":
                            Logobj.InsLogDetail(empid, 94, 1, bid, txt_Mbl.Text.Trim().ToUpper() + "/" + txt_AmedBl.Text.Trim().ToUpper() + "/AmdMBL");
                            break;
                        case "AE":
                            Logobj.InsLogDetail(empid, 95, 1, bid, txt_Mbl.Text.Trim().ToUpper() + "/" + txt_AmedBl.Text.Trim().ToUpper() + "/AmdMBL");
                            break;
                        case "AI":
                            Logobj.InsLogDetail(empid, 96, 1, bid, txt_Mbl.Text.Trim().ToUpper() + "/" + txt_AmedBl.Text.Trim().ToUpper() + "/AmdMBL");
                            break;
                    }

                    ScriptManager.RegisterStartupScript(btn_Amendbl, typeof(Button), "DataFound", "alertify.alert('MBL # Changed');", true);
                    txt_Mbl.Text = "";
                    txt_AmedBl.Text = "";
                    txt_Job.Text = "";
                    //if (Request.QueryString.ToString().Contains("jobno"))
                    //{
                    //    Response.Redirect(Request.QueryString["link"].ToString());
                    //}
                }
            }
        }



        protected void txt_Job_TextChanged(object sender, EventArgs e)
        {
            if (txt_Job.Text != "")
            {
                txt_Mbl.Text = "";
                if (INVOICEobj.CheckClosedJobs(str_TranType, Convert.ToInt32(txt_Job.Text), Convert.ToInt32(Session["LoginBranchid"].ToString())) == 1)
                {
                    ScriptManager.RegisterStartupScript(btn_Amendbl, typeof(Button), "DataFound", "alertify.alert('Job has been Closed Already You Cannot Update the Job Details');", true);
                    txt_Job.Focus();
                    btn_Amendbl_id.Visible = false;
                    btn_Amendbl.Visible = false;
                    return;
                }
                else
                {
                    btn_Amendbl_id.Visible = true;
                    btn_Amendbl.Visible = true;
                }
                mbl = Amendobj.GetMblForAmend(Convert.ToInt32(txt_Job.Text), str_TranType, Convert.ToInt32(Session["LoginBranchid"]));
                txt_Mbl.Text = mbl;
                Session["amendmbl"]= mbl;
                btn_back.Text = "Cancel";
            }
        }

        protected void btn_back_Click(object sender, EventArgs e)
        {
            if (btn_back.Text == "Cancel")
            {
                txt_AmedBl.Text = "";
               // txt_Job.Text = "";
              //  txt_Mbl.Text = "";
              //  btn_back.Text = "Back";
            }
            else
            {
              //  this.Response.End();
              //  Response.Redirect("../Home/OEOpsAndDocs.aspx");
            }
        }

      
    }
}
