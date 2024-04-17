using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Web.Services;
namespace logix.Sales
{
   
    public partial class Salespersonchanged : System.Web.UI.Page
    {
        public string strtrantype;
        DataTable Dt = new DataTable();
        DataAccess.Masters.MasterBranch obj_main = new DataAccess.Masters.MasterBranch();
        DataAccess.CloseJobs jobobj = new DataAccess.CloseJobs();
        DataTable dtbn = new DataTable();
        DataAccess.LogDetails Logobj = new DataAccess.LogDetails();
         DataTable dt_MenuRights = new DataTable();
         DataAccess.UserPermission userperobj = new DataAccess.UserPermission();
         string str_Uiid = "", str_FornName;
         protected void Page_Load(object sender, EventArgs e)
         {
             ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "GenerateLabelAfter();", true);

             if (ddl_product.Text != "" && ddl_product.Text != "0")
             {
                 if (ddl_product.Text == "Ocean Exports")
                 {
                     Session["StrTranType"] = "FE";
                     strtrantype = Session["StrTranType"].ToString();



                 }
                 else if (ddl_product.Text == "Ocean Imports")
                 {
                     Session["StrTranType"] = "FI";
                     strtrantype = Session["StrTranType"].ToString();


                 }
                 else if (ddl_product.Text == "Air Exports")
                 {
                     Session["StrTranType"] = "AE";
                     strtrantype = Session["StrTranType"].ToString();


                 }
                 else if (ddl_product.Text == "Air Imports")
                 {
                     Session["StrTranType"] = "AI";
                     strtrantype = Session["StrTranType"].ToString();


                 }
             }


            if (!IsPostBack)
            {

                if (Session["StrTranType"].ToString() == "FE")
                {
                    HeaderLabel1.InnerText = "OceanExports";
                }
                else if (Session["StrTranType"].ToString() == "FI")
                {
                    HeaderLabel1.InnerText = "OceanImports";
                }
                else if (Session["StrTranType"].ToString() == "AE")
                {
                    HeaderLabel1.InnerText = "AirExports";
                }
                else if (Session["StrTranType"].ToString() == "AI")
                {
                    HeaderLabel1.InnerText = "AirImports";
                }

                BranchLoad();

                string product1 = "";
                if (Request.QueryString.ToString().Contains("product"))
                {
                    product1 = Request.QueryString["product"].ToString();
                }
                /*  if (product1 == "OE")
                  {
                      ddl_product.Items.Add("Ocean Exports");
                      ddl_product.SelectedValue = "Ocean Exports";
                      strtrantype = "FE";
                  }
                  else if (product1 == "OI")
                  {
                      ddl_product.Items.Add("Ocean Imports");
                      ddl_product.SelectedValue = "Ocean Imports";
                      strtrantype = "FI";
                  }
                  else if (product1 == "AI")
                  {
                      ddl_product.Items.Add("Air Imports");
                      ddl_product.SelectedValue = "Air Imports";
                      strtrantype = product1;
                  }
                  else if (product1 == "AE")
                  {
                      ddl_product.Items.Add("Air Exports");
                      ddl_product.SelectedValue = "Air Exports";
                      strtrantype = product1;
                  }
                  Session["StrTranType"] = strtrantype;
              }
          else*/
                if (Request.QueryString.ToString().Contains("bookno"))
                {
                    txt_blno.Text = Request.QueryString["bookno"].ToString();
                    txt_blno_TextChanged(sender, e);
                    txt_blno.Enabled = false;
                }
                if (Session["trantype_process"] != null)
                {
                    dt_MenuRights = userperobj.Getformuserrights(Convert.ToInt16(Session["LoginEmpId"].ToString()), "", Convert.ToInt16(Session["LoginBranchid"].ToString()), 2, "Quotation (Selling)");//Session["trantype_process"] as DataTable;
                    ddl_product.Items.Add("");
                   // Session["StrTranType"] = null;
                    for (int i = 0; i < dt_MenuRights.Rows.Count; i++)
                    {
                        if (dt_MenuRights.Rows[i]["trantype"].ToString() == "FE")
                        {
                            ddl_product.Items.Add("Ocean Exports");
                            Session["StrTranType"] = "FE";
                        }
                        else if (dt_MenuRights.Rows[i]["trantype"].ToString() == "FI")
                        {
                            ddl_product.Items.Add("Ocean Imports");
                            Session["StrTranType"] = "FI";
                        }
                        else if (dt_MenuRights.Rows[i]["trantype"].ToString() == "AE")
                        {
                            ddl_product.Items.Add("Air Exports");
                            Session["StrTranType"] = "AE";
                        }
                        else if (dt_MenuRights.Rows[i]["trantype"].ToString() == "AI")
                        {
                            ddl_product.Items.Add("Air Imports");
                            Session["StrTranType"] = "AI";
                        }
                    }
                    // Session["StrTranType"] = dt_MenuRights.Rows[i]["modulename"].ToString();
                }
                else if (Session["StrTranType"] != null)
                {
                    ddl_product.Items.Add("");
                    if (Session["StrTranType"].ToString() == "FE")
                    {
                        ddl_product.Items.Add("Ocean Exports");
                        //ddl_product.SelectedIndex = 1;
                        ddl_product.SelectedValue = "Ocean Exports";
                    }
                    else if (Session["StrTranType"].ToString() == "FI")
                    {
                        ddl_product.Items.Add("Ocean Imports");
                        ddl_product.SelectedValue = "Ocean Imports";
                        //ddl_product.SelectedIndex = 1;
                    }
                    else if (Session["StrTranType"].ToString() == "AE")
                    {
                        ddl_product.Items.Add("Air Exports");
                        ddl_product.SelectedValue = "Air Exports";
                        //ddl_product.SelectedIndex = 1;
                    }
                    else if (Session["StrTranType"].ToString() == "AI")
                    {
                        ddl_product.Items.Add("Air Imports");
                        ddl_product.SelectedValue = "Air Imports";
                    }
                    //ddl_product.SelectedIndex = 1;
                }

                //product();


                
            }
         }

            
        //}
        [WebMethod]
        public static List<string> GetSalesPerson(string prefix)
        {
            List<string> List_Result = new List<string>();
            DataAccess.Masters.MasterEmployee obj_branchmgr = new DataAccess.Masters.MasterEmployee();
            DataTable dt_Bgr = new DataTable();
            dt_Bgr = obj_branchmgr.GetLikeEmployee(prefix.Trim());
            List_Result = Utility.Fn_DatatableToList_int16Display(dt_Bgr, "empnamecode", "employeeid", "empname");
            return List_Result;
        }
        [WebMethod]
        public static List<string> getlikebl(string prefix)
        {

            List<string> List_Result = new List<string>();
            string StrTranType = "";
            if (HttpContext.Current.Session["StrTranType"] != null)
            {
                StrTranType = HttpContext.Current.Session["StrTranType"].ToString();
            }

            DataAccess.Marketing.Booking bookingobj = new DataAccess.Marketing.Booking();
            DataTable dtbooking = new DataTable();
            dtbooking = bookingobj.GetBookingPendingnew(StrTranType, Convert.ToInt32(HttpContext.Current.Session["LoginBranchid"]), prefix.ToUpper());
            List_Result = Utility.Fn_TableToList(dtbooking, "bookingno", "bookno");
            return List_Result;
        }

        //public  void  product()
        //{   
        //    ddl_product.Items.Add("OCEAN EXPORT");
        //    ddl_product.Items.Add("OCEAN IMPORT");
        //    ddl_product.Items.Add("AIR EXPORT");
        //    ddl_product.Items.Add("AIR IMPORT");
        //}
        public void BranchLoad()
        {
            //ddl_branch.SelectedValue = "0";
            //int i;
            //int divid = Convert.ToInt32(Session["LoginDivisionId"].ToString());

            //Dt = obj_main.GetBranchByDivID(divid);

            //if (Dt.Rows.Count > 0)
            //{
            //    for (i = 0; i <= Dt.Rows.Count - 1; i++)
            //    {
            //        ddl_branch.Items.Add(Dt.Rows[i]["branch"].ToString());
            //    }
            //}
        }


        protected void UserRights()
        {
            try
            {
                if (Request.QueryString.ToString().Contains("type"))
                {
                    Boolean btn_delete;
                    str_FornName = Request.QueryString["type"].ToString();
                    str_Uiid = Request.QueryString["uiid"].ToString();
                    Utility.Fn_CheckUserRights(str_Uiid, btn_save, null, null);
                    DataTable obj_Dtuser = new DataTable();
                    obj_Dtuser = (DataTable)Session["dt_UserRights"];
                    DataView obj_dtview = new DataView(obj_Dtuser);
                    obj_dtview.RowFilter = "uiid=" + str_Uiid + " and submenuname='" + str_FornName + "'";
                    obj_Dtuser = obj_dtview.ToTable();
                    //btn_delete = Boolean.Parse(obj_Dtuser.Rows[0]["btndelete"].ToString());


                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }

        }


        protected void btn_save_Click(object sender, EventArgs e)
        {
            UserRights();
            this.PopUpService.Show();
            return;

           
        }

        protected void btn_back_Click(object sender, EventArgs e)
        {
            if(btn_back.ToolTip=="Cancel")
            {
                txt_blno.Text = "";
                txt_oldsalesperson.Text = "";
                txt_salesperson.Text = "";
                btn_back.ToolTip = "Back";
                btn_back.Text = "Back";
                lbl_back.Attributes["class"] = "btn ico-back";
            }
            else
            {
               // Response.Redirect("../Home/OEOpsAndDocs.aspx");
            }
        }

        protected void txt_blno_TextChanged(object sender, EventArgs e)
        {
            DataTable dts = new DataTable();
            dts = jobobj.getquotno(txt_blno.Text, Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString());
            if (dts.Rows.Count > 0)
            {
               int quotno = Convert.ToInt32(dts.Rows[0]["quotno"].ToString());
               int salesperson= jobobj.getoldsalespersonname(quotno, Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString());
               txt_oldsalesperson.Text = jobobj.getsalespersonnameold(salesperson);
            }
        }

        protected void btn_yes_Click(object sender, EventArgs e)
        {
            //UserRights();
            string strantype = "";
            int quotno = 0, jobno = 0;
            string blno = "";
            DataTable dt = new DataTable();
            if (txt_blno.Text != "")
            {
                //if (ddl_branch.Text == "OCEAN EXPORT")
                //{
                //    strantype = "FE";
                //}
                //else if (ddl_branch.Text == "OCEAN IMPORT")
                //{
                //    strantype = "FI";
                //}
                //else if (ddl_branch.Text == "AIR IMPORT")
                //{
                //    strantype = "AI";
                //}
                //else if (ddl_branch.Text == "AIR EXPORT")
                //{
                //    strantype = "AE";
                //}

                dt = jobobj.getquotno(txt_blno.Text, Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString());
                if (dt.Rows.Count > 0)
                {
                    quotno = Convert.ToInt32(dt.Rows[0]["quotno"].ToString());
                    blno = dt.Rows[0]["blno"].ToString();
                    if (!string.IsNullOrEmpty(dt.Rows[0]["job"].ToString()))
                    {
                        jobno = Convert.ToInt32(dt.Rows[0]["job"]);
                    }
                    if (jobno == 0 && blno != "" || jobno.ToString() == "" && blno != "")
                    {
                        DataAccess.Accounts.Invoice objinv = new DataAccess.Accounts.Invoice();
                        jobno = objinv.getjobnobldetails(blno.ToString(), Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString());
                        objinv.sp_updjobbldet(jobno, blno.ToString(), Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString());

                    }

                    
                }

                
               jobobj.Updatesalespersonquotation(quotno, Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString(), Convert.ToInt32(hdn_salesid.Value));
                ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "DataFound", "alertify.alert('Salesperson has  been  Changed');", true);
                DataTable dttm = jobobj.GetJobclosedjobstatus(Convert.ToInt32(jobno), Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString());
                if (dttm.Rows.Count > 0)
                {
                    if (dttm.Rows[0]["jobclosed"].ToString() == "C")
                    {


                    //    jobobj.Updatesalespersonquotation(quotno, Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString(), Convert.ToInt32(hdn_salesid.Value));
                        if (blno != null)
                        {
                            
                                jobobj.Updatesalespersonbldetails(Convert.ToInt32(jobno), Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString(), blno.ToString(), Convert.ToInt32(hdn_salesid.Value));

                            jobobj.UpdatesalespersonMISDetails(Convert.ToInt32(jobno), Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString(), blno.ToString(), Convert.ToInt32(hdn_salesid.Value));
                            //jobobj.Updatesalespersonrptcosting(Convert.ToInt32(jobno), Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString(), blno.ToString(), Convert.ToInt32(hdn_salesid.Value));

                        }
                        ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "DataFound", "alertify.alert('Salesperson has  been  Changed');", true);
                    }
                    else if (dttm.Rows[0]["jobclosed"].ToString() == "U")
                    {

                        if (dt.Rows.Count > 0)
                        {
                            quotno = Convert.ToInt32(dt.Rows[0]["quotno"].ToString());
                            blno = dt.Rows[0]["blno"].ToString();
                        }
                        if (blno != null)
                        {
                           
                               // jobobj.Updatesalespersonquotation(quotno, Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString(), Convert.ToInt32(hdn_salesid.Value));
                                jobobj.Updatesalespersonbldetails(Convert.ToInt32(jobno), Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString(), blno.ToString(), Convert.ToInt32(hdn_salesid.Value));
                            
                        }
                        ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "DataFound", "alertify.alert('Salesperson has  been  Changed');", true);
                    }

                }

                switch (Session["StrTranType"].ToString())
                {
                    case "FE":

                        Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1854, 2, Convert.ToInt32(Session["LoginBranchid"]), txt_oldsalesperson.Text + " - " + txt_salesperson.Text + " - " + txt_blno.Text + "/U");
                        break;
                    case "FI":
                        Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1855, 2, Convert.ToInt32(Session["LoginBranchid"]), txt_oldsalesperson.Text + " - " + txt_salesperson.Text + " - " + txt_blno.Text + "/U");
                        break;
                    case "AE":
                        Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1856, 2, Convert.ToInt32(Session["LoginBranchid"]), txt_oldsalesperson.Text + " - " + txt_salesperson.Text + " - " + txt_blno.Text + "/U");
                        break;
                    case "AI":
                        Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1857, 2, Convert.ToInt32(Session["LoginBranchid"]), txt_oldsalesperson.Text + " - " + txt_salesperson.Text + " - " + txt_blno.Text + "/U");
                        break;
                }
                btn_back.ToolTip = "Cancel";
                lbl_back.Attributes["class"] = "btn-ico-cancel";
                
            }

        }

        protected void btn_no_Click(object sender, EventArgs e)
        {
            this.PopUpService.Hide();
        }

       
    }
}