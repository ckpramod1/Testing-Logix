using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Configuration;
using System.Web.UI.HtmlControls;
using System.Web.Services;
using System.Data;
using System.Data.SqlClient;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html;
using iTextSharp.text.html.simpleparser;
using System.IO;
using System.Globalization;
using DataAccess.Accounts;
using System.Runtime.Remoting;

namespace logix.ShipmentDetails
{
    public partial class TransferToPoL : System.Web.UI.Page
    {
        DataAccess.ForwardingExports.BLDetails BLtrobj = new DataAccess.ForwardingExports.BLDetails();
        DataAccess.Masters.MasterPort objport = new DataAccess.Masters.MasterPort();
        DataAccess.ForwardingExports.BLDetails BLSTrobj = new DataAccess.ForwardingExports.BLDetails();
        DataAccess.Masters.MasterEmployee EmpObj = new DataAccess.Masters.MasterEmployee();
        DataAccess.LogDetails LogObj = new DataAccess.LogDetails();
        DataAccess.LogDetails obj_da_Log1 = new DataAccess.LogDetails();
        DataAccess.Reportasp objRpt = new DataAccess.Reportasp();

        int pod, pol, fd;
        string StrTrantype;
        int intDivID;
        int branchid;
        Boolean blnerr;
        string PoLs, FDs;
        Boolean DiffPoL, DiffFD;
        string blno, strPoL, strBLnos;

        string strPD,strFD;
        string strQry = "";
        DataTable dt_comm = new DataTable();

        protected void Page_Load(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "SpanTagMoveInputBottom();MuiTextField();", true);

            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "SpanTagMoveInputBottom();MuiTextField();", true);


            string Ccode = Convert.ToString(Session["Ccode"]);

            if (Ccode != "")
            {

                BLtrobj.GetDataBase(Ccode);
                objport.GetDataBase(Ccode);
                BLSTrobj.GetDataBase(Ccode);
                EmpObj.GetDataBase(Ccode);
                LogObj.GetDataBase(Ccode);
                obj_da_Log1.GetDataBase(Ccode);
                objRpt.GetDataBase(Ccode);
               

            }

            if (Session["LoginUserName"] == null || Session["LoginEmpId"] == null || Session["LoginDivisionId"] == null || Session["LoginBranchid"] == null)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alertify.alert('Session TimeOut');window.open('"+ Session["Site"].ToString() + "/','_top');", true);
            }
            else if (Session["StrTranType"] == null)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alertify.alert('Session TimeOut');window.open('"+ Session["Site"].ToString() + "/FormMain.aspx','_top');", true);
            }

                ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(btnback);
                if (!IsPostBack)
                {
                    try
                    {
                        StrTrantype = HttpContext.Current.Session["StrTranType"].ToString();
                        GetButtonText();
                        BindTranferBL();
                        //btntranfer.Text = lblMeText.Text;


                        btntranfer.ToolTip = lblMeText.Text;
                        btntranfer1.Attributes["class"] = "btn ico-transfer-to-pol";

                        if (Session["StrTranType"].ToString() == "FE")
                        {
                            HeaderLabel1.InnerText = "Ocean Exports";
                           
                        }
                        else if (Session["StrTranType"].ToString() == "FI")
                        {
                            HeaderLabel1.InnerText = "Ocean Imports";
                          
                        }
                        else if (Session["StrTranType"].ToString() == "AE")
                        {
                            HeaderLabel1.InnerText = "Air Exports";
                           
                        }
                        else if (Session["StrTranType"].ToString() == "AI")
                        {
                            HeaderLabel1.InnerText = "Air Imports";
                           
                        }
                        //btnback.Text = "Cancel";
                    }
                    catch (Exception ex)
                    {
                        string message = ex.Message.ToString();
                        ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
                    }

                }

           
            
        }

        private void GetButtonText()
        {
            if (StrTrantype == "FE" || StrTrantype == "AE" || StrTrantype == "AI")
            {
                string taskid = Request.QueryString["taskid"];
                if (taskid != null)
                {
                    lblMeText.Text = taskid;
                }
                else
                {
                    lblMeText.Text = Request.QueryString["type"].ToString();
                }
                menu.InnerText = lblMeText.Text;
            }
            else
            {
                lblMeText.Text = "Transfer To ICD";
                menu.InnerText = lblMeText.Text;
            }
        }

        private void BindTranferBL()
        {
            intDivID = Convert.ToInt32(Session["LoginDivisionId"].ToString());
            branchid = Convert.ToInt32(Session["LoginBranchid"].ToString());
            StrTrantype = HttpContext.Current.Session["StrTranType"].ToString();
           int empid= Convert.ToInt32(Session["LoginEmpId"].ToString()) ;

            if (StrTrantype == "FE" || StrTrantype == "FI")
            {
                dt_comm = BLtrobj.GETFEIBLTransfer(branchid, StrTrantype, intDivID);
            }
            //change
            else
            {
                dt_comm = BLtrobj.GETAEIBLTransfer(branchid, StrTrantype, intDivID);
            }
            //change

            if (dt_comm.Rows.Count > 0)
            {
                GrdToPol.DataSource = dt_comm;
                GrdToPol.DataBind();
            }
            else
            {
                EmptyGridShow();
            }
        }

        private void EmptyGridShow()
        {
            //DataTable dtempty1 = new DataTable();

            //dtempty1.Columns.Add("blno");
            //dtempty1.Columns.Add("shipper");
            //dtempty1.Columns.Add("consignee");
            //dtempty1.Columns.Add("pol");
            //dtempty1.Columns.Add("pod");
            //dtempty1.Columns.Add("fd");

            //dtempty1.Rows.Add(dtempty1.NewRow());

            //GrdToPol.DataSource = dtempty1;
            //GrdToPol.DataBind();
            //int totalcolums = GrdToPol.Rows[0].Cells.Count;
            //GrdToPol.Rows[0].Cells.Clear();
            //GrdToPol.Rows[0].Cells.Add(new TableCell());
            //GrdToPol.Rows[0].Cells[0].ColumnSpan = totalcolums;

            GrdToPol.DataSource = new DataTable();
            GrdToPol.DataBind();
        }

        private bool CheckPOL()
        {
            DiffPoL = false;
            PoLs = "";
            for (int i = 0; i < GrdToPol.Rows.Count; i++)
            {
                CheckBox chkRows = (GrdToPol.Rows[i].Cells[6].FindControl("ChkStatus") as CheckBox);
                if (chkRows.Checked == true)
                {
                    PoLs = PoLs + GrdToPol.Rows[i].Cells[3].Text + ",";
                }
            }
            if (PoLs != "")
            {
                PoLs = PoLs.Remove(PoLs.Length - 1, 1);
                string[] ArrPoL = PoLs.Split(new string[] { "," }, StringSplitOptions.None);
                for (int k = 0; k < ArrPoL.Length - 2; k++)
                {
                    DiffPoL = true;
                }


            }
            return DiffPoL;


        }

        private bool CheckFD()
        {
            DiffFD = false;
            FDs = "";
            for (int i = 0; i < GrdToPol.Rows.Count; i++)
            {
                CheckBox chkRows = (GrdToPol.Rows[i].Cells[6].FindControl("ChkStatus") as CheckBox);
                if (chkRows.Checked == true)
                {
                    FDs = FDs + GrdToPol.Rows[i].Cells[5].Text + ",";
                }
            }
            if (FDs != "")
            {
                FDs = FDs.Remove(FDs.Length - 1, 1);
                string[] ArrFD = FDs.Split(new string[] { "," }, StringSplitOptions.None);
                for (int m = 0; m < ArrFD.Length - 2; m++)
                {
                    if (ArrFD[m] != ArrFD[m + 1])
                    {
                        DiffFD = true;
                    }

                }
            }


            return DiffFD;
        }

        protected void btntranfer_Click(object sender, EventArgs e)
        {
            try
            {
                string strQry = "";
                StrTrantype = Session["StrTranType"].ToString();
                intDivID = Convert.ToInt32(Session["LoginDivisionId"].ToString());
                branchid = Convert.ToInt32(Session["LoginBranchid"].ToString());
                bool chk = false;
                Label TxtstrPoL = new Label();
                Label TxtstrPD = new Label();
                Label TxtstrFD = new Label();
                if (StrTrantype == "FE")
                {
                    blnerr = CheckPOL();
                    if (blnerr == true)
                    {
                        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Transfer To PoL", "alertify.alert('Only One PoL Applicable per Transaction');", true);
                        blnerr = false;
                        return;
                    }

                    for (int i = 0; i < GrdToPol.Rows.Count; i++)
                    {
                        CheckBox chkRows = (GrdToPol.Rows[i].Cells[6].FindControl("ChkStatus") as CheckBox);
                        if (chkRows.Checked == true)
                        {
                            blno = GrdToPol.Rows[i].Cells[0].Text;
                            strPoL = GrdToPol.Rows[i].Cells[3].Text;
                            strBLnos = strBLnos + GrdToPol.Rows[i].Cells[0].Text + " ";
                            //elaa
                            BLtrobj.InsFEIBLTransfer(blno, StrTrantype, branchid, intDivID);
                            strBLnos = strBLnos.TrimEnd();
                            strBLnos = strBLnos.Replace(" ", "/");


                            //DataAccess.Reportasp objRpt = new DataAccess.Reportasp();
                            hid_date.Value = Utility.fn_ConvertDate(obj_da_Log1.GetDate().ToShortDateString());

                            objRpt.InsOEeventdetailsTask(Convert.ToInt32("0"), blno.ToString(), "", "ICD - PoL Movement",
                           Convert.ToDateTime(Utility.fn_ConvertDate(hid_date.Value.ToString())), Convert.ToInt32(Session["LoginEmpId"].ToString()), Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString(),0,"",5);


                            // BuildICDMailFE(strPoL);
                            /*
                               BuildICDMailFE(strPoL)
            strMailID = EmpObj.SelBranchHeadMailID(Login.divisionid, Login.BranchName)
            sendmail.SendEmail(strMailID, "", "pandi", "Shipment Transfer - " & strBLnos, strQry, True, Login.MailServer, "", "", Login.MailUser, Login.mailpwd, "")
            BuildPOLMailFE()
            strMailID = EmpObj.SelBranchHeadMailID(Login.divisionid, strPoL)
            sendmail.SendEmail(strMailID, "", "pandi", "Shipment Transfer - " & strBLnos, strQry, True, Login.MailServer, "", "", Login.MailUser, Login.mailpwd, "")
                             */
                            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Transfer To PoL", "alertify.alert('BL #:" + blno + " Transfered Successsfully');", true);

                            LogObj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 541, 1, Convert.ToInt32(Session["LoginBranchid"]), strBLnos);
                            chk = true;
                        }

                    }
                    if (chk == false)
                    {
                        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Transfer To PoL", "alertify.alert('Need to select for Transaction);", true);
                        return;
                    }
                }
                else if (StrTrantype == "FI")
                {
                    blnerr = CheckFD();
                    if (blnerr == true)
                    {
                        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Transfer To PoL", "alertify.alert('Only One FinalDestination Applicable per Transaction');", true);
                        blnerr = false;
                        return;
                    }

                    for (int i = 0; i < GrdToPol.Rows.Count; i++)
                    {
                        CheckBox chkRows = (GrdToPol.Rows[i].Cells[6].FindControl("ChkStatus") as CheckBox);
                        if (chkRows.Checked == true)
                        {
                            blno = GrdToPol.Rows[i].Cells[0].Text;
                            strPoL = GrdToPol.Rows[i].Cells[3].Text;
                            strBLnos = strBLnos + GrdToPol.Rows[i].Cells[0].Text + " ";
                            BLtrobj.InsFEIBLTransfer(blno, StrTrantype, branchid, intDivID);
                            strBLnos = strBLnos.TrimEnd();
                            strBLnos = strBLnos.Replace(" ", "/");




                            //DataAccess.Reportasp objRpt = new DataAccess.Reportasp();
                            hid_date.Value = Utility.fn_ConvertDate(obj_da_Log1.GetDate().ToShortDateString());

                            objRpt.InsOEeventdetailsTask(Convert.ToInt32("0"), blno.ToString(), "", "ICD - PoL Movement",
                           Convert.ToDateTime(Utility.fn_ConvertDate(hid_date.Value.ToString())), Convert.ToInt32(Session["LoginEmpId"].ToString()), Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString(),0,"",5);






                            //  BuildPOLMailFI(strPoL);
                            /* BuildPOLMailFI(strPoL)
            strMailID = EmpObj.SelBranchHeadMailID(Login.divisionid, Login.BranchName)
            sendmail.SendEmail(strMailID, "", "pandi", "Shipment Transfer - " & strBLnos, strQry, True, Login.MailServer, "", "", Login.MailUser, Login.mailpwd, "")
            BuildICDMailFI()
            strMailID = EmpObj.SelBranchHeadMailID(Login.divisionid, strFD)
            sendmail.SendEmail(strMailID, "", "pandi", "Shipment Transfer - " & strBLnos, strQry, True, Login.MailServer, "", "", Login.MailUser, Login.mailpwd, "")
                            */
                            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Transfer To PoL", "alertify.alert('BL #:" + blno + " Transfered Successsfully');", true);
                            LogObj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 541, 1, Convert.ToInt32(Session["LoginBranchid"]), strBLnos);
                            chk = true;
                        }

                    }
                    if (chk == false)
                    {
                        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Transfer To PoL", "alertify.alert('Need to select for Transaction);", true);
                        return;
                    }
                }

                //change
                else if (StrTrantype == "AE")
                {
                    blnerr = CheckPOL();
                    if (blnerr == true)
                    {
                        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Transfer To PoL", "alertify.alert('Only One PoL Applicable per Transaction');", true);
                        blnerr = false;
                        return;
                    }

                    for (int i = 0; i < GrdToPol.Rows.Count; i++)
                    {
                        CheckBox chkRows = (GrdToPol.Rows[i].Cells[6].FindControl("ChkStatus") as CheckBox);
                        if (chkRows.Checked == true)
                        {
                            blno = GrdToPol.Rows[i].Cells[0].Text;
                            //strPoL = GrdToPol.Rows[i].Cells[3].Text;
                            strBLnos = strBLnos + GrdToPol.Rows[i].Cells[0].Text + " ";
                            //elaa
                            TxtstrPoL = (Label)GrdToPol.Rows[i].FindControl("pol");
                            TxtstrPD = (Label)GrdToPol.Rows[i].FindControl("pod");
                            TxtstrFD = (Label)GrdToPol.Rows[i].FindControl("fd");
                            if (TxtstrPD.Text == TxtstrFD.Text)
                            {
                                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Transfer To PoL", "alertify.alert('Port of Delivery and Final Destination is same, so BL not transfer ');", true);
                                continue;
                            }

                            BLtrobj.InsAEIBLTransfer(blno, StrTrantype, branchid, intDivID);
                            strBLnos = strBLnos.TrimEnd();
                            strBLnos = strBLnos.Replace(" ", "/");
                            // BuildICDMailFE(strPoL);
                            /*
                               BuildICDMailFE(strPoL)
            strMailID = EmpObj.SelBranchHeadMailID(Login.divisionid, Login.BranchName)
            sendmail.SendEmail(strMailID, "", "pandi", "Shipment Transfer - " & strBLnos, strQry, True, Login.MailServer, "", "", Login.MailUser, Login.mailpwd, "")
            BuildPOLMailFE()
            strMailID = EmpObj.SelBranchHeadMailID(Login.divisionid, strPoL)
            sendmail.SendEmail(strMailID, "", "pandi", "Shipment Transfer - " & strBLnos, strQry, True, Login.MailServer, "", "", Login.MailUser, Login.mailpwd, "")
                             */
                            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Transfer To PoL", "alertify.alert('BL #:" + blno + " Transfered Successsfully');", true);

                            LogObj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 541, 1, Convert.ToInt32(Session["LoginBranchid"]), strBLnos);
                            chk = true;
                        }

                    }
                    if (chk == false)
                    {
                        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Transfer To PoL", "alertify.alert('Need to select for Transaction);", true);
                        return;
                    }
                }
                else if (StrTrantype == "AI")
                {
                    blnerr = CheckFD();
                    if (blnerr == true)
                    {
                        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Transfer To PoL", "alertify.alert('Only One FinalDestination Applicable per Transaction');", true);
                        blnerr = false;
                        return;
                    }

                    for (int i = 0; i < GrdToPol.Rows.Count; i++)
                    {
                        CheckBox chkRows = (GrdToPol.Rows[i].Cells[6].FindControl("ChkStatus") as CheckBox);
                        if (chkRows.Checked == true)
                        {
                            blno = GrdToPol.Rows[i].Cells[0].Text;

                            TxtstrPoL = (Label)GrdToPol.Rows[i].FindControl("pol");
                            TxtstrPD = (Label)GrdToPol.Rows[i].FindControl("pod");
                            TxtstrFD = (Label)GrdToPol.Rows[i].FindControl("fd");
                                
                              //  (TextBox)GrdToPol.Rows[GrdToPol.Rows].FindControl("TDSPERS");
                           
                            /*strPoL = GrdToPol.Rows[i].Cells[3].Text;
                            strPD = GrdToPol.Rows[i].Cells[4].Text;
                            strFD = GrdToPol.Rows[i].Cells[5].Text;*/



                            strBLnos = strBLnos + GrdToPol.Rows[i].Cells[0].Text + " ";

                            if (TxtstrPD.Text == TxtstrFD.Text)
                            {
                                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Transfer To PoL", "alertify.alert('Port of Delivery and Final Destination is same, so BL not transfer ');", true);
                                continue;
                            }


                           // BLtrobj.InsAEIBLTransfer(blno, StrTrantype, branchid, intDivID);
                            strBLnos = strBLnos.TrimEnd();
                            strBLnos = strBLnos.Replace(" ", "/");
                            //  BuildPOLMailFI(strPoL);
                            /* BuildPOLMailFI(strPoL)
            strMailID = EmpObj.SelBranchHeadMailID(Login.divisionid, Login.BranchName)
            sendmail.SendEmail(strMailID, "", "pandi", "Shipment Transfer - " & strBLnos, strQry, True, Login.MailServer, "", "", Login.MailUser, Login.mailpwd, "")
            BuildICDMailFI()
            strMailID = EmpObj.SelBranchHeadMailID(Login.divisionid, strFD)
            sendmail.SendEmail(strMailID, "", "pandi", "Shipment Transfer - " & strBLnos, strQry, True, Login.MailServer, "", "", Login.MailUser, Login.mailpwd, "")
                            */
                            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Transfer To PoL", "alertify.alert('BL #:" + blno + " Transfered Successsfully');", true);
                            LogObj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 541, 1, Convert.ToInt32(Session["LoginBranchid"]), strBLnos);
                            chk = true;
                        }

                    }
                    if (chk == false)
                    {
                        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Transfer To PoL", "alertify.alert('Need to select for Transaction);", true);
                        return;
                    }
                }
                //change
                BindTranferBL();
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
            // btnback.Text = "Cancel";
        }

        protected void grd_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    Label lblCustomer = (Label)e.Row.FindControl("shipper");
                    string tooltip = lblCustomer.Text;
                    e.Row.Cells[1].Attributes.Add("title", tooltip);
                    Label lblCustomer1 = (Label)e.Row.FindControl("consignee");
                    string tooltip1 = lblCustomer1.Text;
                    e.Row.Cells[2].Attributes.Add("title", tooltip1);
                    Label lblCustomer2 = (Label)e.Row.FindControl("pol");
                    string tooltip2 = lblCustomer2.Text;
                    e.Row.Cells[3].Attributes.Add("title", tooltip2);
                    Label lblCustomer3 = (Label)e.Row.FindControl("pod");
                    string tooltip3 = lblCustomer3.Text;
                    e.Row.Cells[4].Attributes.Add("title", tooltip3);
                    Label lblCustomer4 = (Label)e.Row.FindControl("fd");
                    string tooltip4 = lblCustomer4.Text;
                    e.Row.Cells[5].Attributes.Add("title", tooltip4);

                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        protected void btnback_Click(object sender, EventArgs e)
        {
            this.Response.End();
            //if (btnback.Text == "Cancel")
            //{
            //    GrdToPol.DataSource = new DataTable();
            //    GrdToPol.DataBind();
            //    btnback.Text = "Back";
            //}
            //else
            //{
            //    this.Response.End();
            //}
        }

        protected void GrdToPol_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                GrdToPol.PageIndex = e.NewPageIndex;
                BindTranferBL();

            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        protected void GrdToPol_PreRender(object sender, EventArgs e)
        {
            if (GrdToPol.Rows.Count > 0)
            {
                GrdToPol.UseAccessibleHeader = true;
                GrdToPol.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }

        
    }
}