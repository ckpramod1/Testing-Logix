using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Sql;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.DataVisualization.Charting;
using System.Web.Services;
using System.Text;
using System.IO;
using ClosedXML.Excel;
using System.Net;
using System.Text.RegularExpressions;
using System.Drawing.Imaging;


namespace logix.ShipmentDetails
{
    public partial class PendingGSTDetails : System.Web.UI.Page
    {
       
        DataAccess.LogDetails objlog = new DataAccess.LogDetails();
        DataAccess.Masters.MasterBranch da_obj_Branch = new DataAccess.Masters.MasterBranch();

        DataAccess.Documents objnew = new DataAccess.Documents(); 


        protected void Page_Load(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "SpanTagMoveInputBottom();MuiTextField();", true);



            string Ccode = Convert.ToString(Session["Ccode"]);

            if (Ccode != "")
            {

                objlog.GetDataBase(Ccode);
                da_obj_Branch.GetDataBase(Ccode);
                objnew.GetDataBase(Ccode);
               

            }

            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(btn_Export);
            DataTable dt = new DataTable();
            if (Session["LoginUserName"] == null || Session["LoginEmpId"] == null || Session["LoginDivisionId"] == null || Session["LoginBranchid"] == null)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alertify.alert('Session TimeOut');window.open('"+ Session["Site"].ToString() + "/','_top');", true);
            }

            if (!IsPostBack)
            {
                int bid = Convert.ToInt32(Session["LoginBranchid"]);
               
                //dt = isfobj.GetPendingMREDIDetails(bid);
                //if (dt.Rows.Count > 0)
                //{
                //    grdpifsdtls.DataSource = dt;
                //    grdpifsdtls.DataBind();
                //    ViewState["GrdExcelDown"] = dt;
                //}
                //else
                //{
                //    grdpifsdtls.DataSource = new DataTable();
                //    grdpifsdtls.DataBind();
                //    ViewState["GrdExcelDown"] = null;
                //}
                if (Session["StrTranType"].ToString() == "FE")
                {
                    ddlEvents.SelectedValue = "0";
                }
                txt_From.Text = Utility.fn_ConvertDate(Convert.ToString(objlog.GetDate().ToShortDateString()));
                txt_To.Text = Utility.fn_ConvertDate(Convert.ToString(objlog.GetDate().ToShortDateString()));
                BindBranchDLL();
                GetPendOrComp4GST();
            }
        }


        protected void grdpifsdtls_RowDataBound(object sender, GridViewRowEventArgs e)
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
                //if (Session["LoginDivisionId"].ToString() != "40")
                //{
                //    e.Row.Attributes.Add("onmouseover", "this.originalcolor=this.style.backgroundColor;" + " this.style.backgroundColor='#FDCB0A';");
                //    e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalcolor;");
                //    e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(this.grdpifsdtls, "Select$" + e.Row.RowIndex);
                //    //e.Row.Attributes.Add("onclick", "__doPostBack('Grid_salesout','Select$" + e.Row.RowIndex + "');");
                //    e.Row.Attributes["style"] = "cursor:pointer";

                //}
            }
        }

      

        protected void ddlEvents_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetPendOrComp4GST();
         
        }


        protected void btn_cancel_Click(object sender, EventArgs e)
        {
            lbl_To.Visible = false;
            lbl_From.Visible = false;
            txt_From.Visible = false;
            txt_To.Visible = false;
            get_id.Visible = false;
            btn_get.Visible = false;
            ddlEvents.SelectedValue = "0";
            ddlEvents_SelectedIndexChanged(sender, e);
        }



        protected void btn_get_Click(object sender, EventArgs e)
        {
            BindBranchDLL();
            GetPendOrComp4GST();
            //DataTable dt = new DataTable();
            //lbl_To.Visible = true;
            //lbl_From.Visible = true;
            //txt_From.Visible = true;
            //txt_To.Visible = true;
            //btn_get.Visible = true;
            //DivComt.Visible = true;
            //dt = isfobj.GetCompletedMREDIDetails(Convert.ToInt32(Session["LoginBranchid"]), Convert.ToDateTime(Utility.fn_ConvertDatetime(txt_From.Text)), Convert.ToDateTime(Utility.fn_ConvertDatetime(txt_To.Text)));
            //if (dt.Rows.Count > 0)
            //{
            //    grdcifsdtls.DataSource = dt;
            //    grdcifsdtls.DataBind();
            //    ViewState["GrdExcelDown"] = dt;
            //}
            //else
            //{
            //    grdcifsdtls.DataSource = new DataTable();
            //    grdcifsdtls.DataBind();
            //    ViewState["GrdExcelDown"] = null;
            //}
        }


        protected void grdcifsdtls_RowDataBound(object sender, GridViewRowEventArgs e)
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

                if (Session["LoginBranchId"].ToString() != "40")
                {
                    e.Row.Attributes.Add("onmouseover", "this.originalcolor=this.style.backgroundColor;" + " this.style.backgroundColor='#FDCB0A';");
                    e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalcolor;");
                    e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(this.grdcifsdtls, "Select$" + e.Row.RowIndex);
                    //e.Row.Attributes.Add("onclick", "__doPostBack('Grid_salesout','Select$" + e.Row.RowIndex + "');");
                    e.Row.Attributes["style"] = "cursor:pointer";
                }
            }
        }

       



        protected void btn_Export_Click(object sender, EventArgs e)
        {
            if (ViewState["GrdExcelDown"] != null)
            {
                DataTable Dt=new DataTable();
                Dt = (DataTable)ViewState["GrdExcelDown"];
                if (Dt.Rows.Count > 0)
                {
                    if (Dt.Rows.Count > 0)
                    {
                        using (XLWorkbook wb = new XLWorkbook())
                        {
                            wb.Worksheets.Add(Dt, ddlEvents.SelectedItem.Text);
                            Response.Clear();
                            Response.Buffer = true;
                            Response.Charset = "";
                            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                            Response.AddHeader("content-disposition", "attachment;filename=" + ddlEvents.SelectedItem.Text + ".xlsx");
                            using (MemoryStream MyMemoryStream = new MemoryStream())
                            {
                                wb.SaveAs(MyMemoryStream);
                                MyMemoryStream.WriteTo(Response.OutputStream);
                                Response.Flush();
                                Response.End();
                            }
                        }
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(btn_Export, typeof(Button), "ComRpt", "alertify.alert('Data Not Found');", true);
                    return;
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(btn_Export, typeof(Button), "ComRpt", "alertify.alert('No Data in Grid');", true);
                return;
            }
        }

     
        public void BindBranchDLL()
        {
            try
            {
                int int_divid = Convert.ToInt32(Session["LoginDivisionId"].ToString());
                DataTable obj_dtTemp = new DataTable();
                obj_dtTemp = da_obj_Branch.GetBranchByDivID(int_divid);
                int i;
                ddl_branch.Items.Add(new ListItem("ALL", "0"));
                for (i = 0; i <= obj_dtTemp.Rows.Count - 1; i++)
                {
                    if (obj_dtTemp.Rows[i]["branch"].ToString() != "CORPORATE")
                    {
                        ddl_branch.Items.Add(new ListItem(obj_dtTemp.Rows[i]["branch"].ToString(), obj_dtTemp.Rows[i]["branchid"].ToString()));
                    }
                }

                if (Session["LoginBranchid"].ToString() != "40")
                {
                    ddl_branch.SelectedValue = Session["LoginBranchid"].ToString();
                    ddl_branch.Enabled = false;
                }

            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
                //ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alertify.alert('Session TimeOut');window.open('../Login.aspx','_top');", true);
            }

        }

        protected void ddl_branch_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetPendOrComp4GST();
        }

        public void GetPendOrComp4GST()
        {
            int Bid=0;
            if (ddl_branch.SelectedValue == "0")
            {
                //Bid = 5;

                Bid = Convert.ToInt32(Session["LoginBranchid"].ToString());
            }
            else
            {
                if (ddl_branch.SelectedValue != "" || ddl_branch.SelectedValue != "0")
                {
                    Bid = Convert.ToInt32(ddl_branch.SelectedValue);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(btn_get, typeof(Button), "ComRpt", "alertify.alert('Invalid branch');", true);
                    return;
                }

            }
            if (ddlEvents.SelectedValue == "0")
            {
                lbl_To.Visible = false;
                lbl_From.Visible = false;
                txt_From.Visible = false;
                txt_To.Visible = false;
                get_id.Visible = false;
                btn_get.Visible = false;
                DivPend.Visible = true;
                DivComt.Visible = false;
                btn_cancel.Visible = false;
                btn_cancel.Visible = false;
                DataTable dt = objnew.GetPendingGSTDetails(Bid);
                if (dt.Rows.Count > 0)
                {
                    grdpifsdtls.DataSource = dt;
                    grdpifsdtls.DataBind();
                    ViewState["GrdExcelDown"] = dt;
                }
                else
                {
                    grdpifsdtls.DataSource = new DataTable();
                    grdpifsdtls.DataBind();
                    ViewState["GrdExcelDown"] = null;
                }
            }
            else if (ddlEvents.SelectedValue == "1")
            {
                //txt_From.Text = Utility.fn_ConvertDate(Convert.ToString(objlog.GetDate().ToShortDateString()));
                //txt_To.Text = Utility.fn_ConvertDate(Convert.ToString(objlog.GetDate().ToShortDateString()));
                lbl_To.Visible = true;
                lbl_From.Visible = true;
                txt_From.Visible = true;
                txt_To.Visible = true;
                get_id.Visible = true;
                btn_get.Visible = true;
                btn_cancel1.Visible = true;
                btn_cancel.Visible = true;
                DivPend.Visible = false;
                DivComt.Visible = true;
                DataTable dt = objnew.GetCompletedGSTDetails(Bid, Convert.ToDateTime(Utility.fn_ConvertDatetime(txt_From.Text)), Convert.ToDateTime(Utility.fn_ConvertDatetime(txt_To.Text)));
                if (dt.Rows.Count > 0)
                {
                    grdcifsdtls.DataSource = dt;
                    grdcifsdtls.DataBind();
                    ViewState["GrdExcelDown"] = dt;
                }
                else
                {
                    grdcifsdtls.DataSource = new DataTable();
                    grdcifsdtls.DataBind();
                    ViewState["GrdExcelDown"] = null;
                }
            }
        }

        protected void btn_Transfer_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                string div_id = "";
                ImageButton lb = (ImageButton)sender;
                GridViewRow GvRow = (GridViewRow)lb.NamingContainer;
                int Row_ID = GvRow.RowIndex;
                int index, vouno, Int_Vou_No, Int_Vou_Year, vouyear,bid;
              //  index = grdpifsdtls.SelectedRow.RowIndex;
                string voutype = "";
               // lblvou.Text = grdpifsdtls.Rows[index].Cells[0].Text;

                vouno = Convert.ToInt32(grdpifsdtls.Rows[Row_ID].Cells[2].Text);



                bid = Convert.ToInt32(grdpifsdtls.Rows[Row_ID].Cells[14].Text);

                vouyear = Convert.ToInt32(grdpifsdtls.Rows[Row_ID].Cells[3].Text);

                voutype = grdpifsdtls.Rows[Row_ID].Cells[15].Text;
                DataTable R_Dt = new DataTable();
                DataTable R_Dt1 = new DataTable();
               int int_divisionid = int.Parse(Session["LoginDivisionId"].ToString());
                //if (ddlbranch.SelectedItem.ToString() == "ALL")
                //{
                //    Branch_Id = Convert.ToInt32(Session["LoginBranchid"].ToString());
                //}
                //else
                //{
                //    Branch_Id = Emp_Obj.GetBranchId(Convert.ToInt32(Session["LoginDivisionId"].ToString()), ddlbranch.SelectedItem.Text);
                //}





                //DataAccess.Documents objnew = new DataAccess.Documents();
                //vouno = 1399;  // 793 ,826
                //bid = 10;
                //vouyear = 2020;
                 // cid = 1;
               div_id = objnew.getinsmastergstdetailsMR(Convert.ToInt32(Session["LoginDivisionId"].ToString()));




               string custid1ung = objnew.getunregcustvouchers(vouno, vouyear, bid, voutype);


               if (div_id == "1" && custid1ung == "0")
               {

                   string json1 = objnew.getgstdetails(vouno, bid, vouyear, voutype);
                   //   DineshhttpPostWebRequets("http://my.gstzen.in/~gstzen/a/post-einvoice-data/einvoice-json/", "{\r\n    \"Version\": \"1.1\",\r\n    \"TranDtls\": {\r\n        \"TaxSch\": \"GST\",\r\n        \"SupTyp\": \"B2B\",\r\n        \"RegRev\": \"N\"\r\n    },\r\n    \"DocDtls\": {\r\n        \"Typ\": \"INV\",\r\n        \"No\": \"IN2021CHEOE100\",\r\n        \"Dt\": \"13\\/05\\/2020\"\r\n    },\r\n    \"SellerDtls\": {\r\n        \"Gstin\": \"29AAFCC9980MZZT\",\r\n        \"LglNm\": \"DEMO CUSTOMER21577\",\r\n        \"Addr1\": \"CUSTOMER ADDRESS\",\r\n        \"Loc\": \"Supreme Court\",\r\n        \"Pin\": 110001,\r\n        \"Stcd\": \"29\"\r\n    },\r\n    \"BuyerDtls\": {\r\n        \"Gstin\": \"07AAACA4691C2ZY\",\r\n        \"LglNm\": \"DEMO CUSTOMER21577\",\r\n        \"Pos\": \"07\",\r\n        \"Addr1\": \"CUSTOMER ADDRESS\",\r\n        \"Loc\": \"Supreme Court\",\r\n        \"Pin\": 110001,\r\n        \"Stcd\": \"07\"\r\n    },\r\n    \"ItemList\": [{\r\n        \"SlNo\": \"1\",\r\n        \"IsServc\": \"Y\",\r\n        \"HsnCd\": \"996759\",\r\n        \"UnitPrice\": 5.00,\r\n        \"TotAmt\": 388.25,\r\n        \"AssAmt\": 388.25,\r\n        \"SgstAmt\": 0.00,\r\n        \"CgstAmt\": 0.00,\r\n        \"IgstAmt\": 69.89,\r\n        \"GstRt\": 18.00,\r\n        \"TotItemVal\": 458.14\r\n    }, {\r\n        \"SlNo\": \"2\",\r\n        \"IsServc\": \"Y\",\r\n        \"HsnCd\": \"996759\",\r\n        \"UnitPrice\": 4050.00,\r\n        \"TotAmt\": 4050.00,\r\n        \"AssAmt\": 4050.00,\r\n        \"SgstAmt\": 0.00,\r\n        \"CgstAmt\": 0.00,\r\n        \"IgstAmt\": 729.00,\r\n        \"GstRt\": 18.00,\r\n        \"TotItemVal\": 4779.00\r\n    }, {\r\n        \"SlNo\": \"3\",\r\n        \"IsServc\": \"Y\",\r\n        \"HsnCd\": \"996759\",\r\n        \"UnitPrice\": 5500.00,\r\n        \"TotAmt\": 5500.00,\r\n        \"AssAmt\": 5500.00,\r\n        \"SgstAmt\": 0.00,\r\n        \"CgstAmt\": 0.00,\r\n        \"IgstAmt\": 990.00,\r\n        \"GstRt\": 18.00,\r\n        \"TotItemVal\": 6490.00\r\n    }],\r\n    \"ValDtls\": {\r\n        \"AssVal\": 9938.25,\r\n        \"CgstVal\": 0.00,\r\n        \"SgstVal\": 0.00,\r\n        \"IgstVal\": 1788.89,\r\n        \"RndOffAmt\": 0.00,\r\n        \"TotInvVal\": 11727.00\r\n    }\r\n}\r\n\r\n");

                   string datajson = DineshhttpPostWebRequets("http://my.gstzen.in/~gstzen/a/post-einvoice-data/einvoice-json/", json1);


                   //DataTable dtjson = ConvertJsonToDatatable(datajson);
                   //string l0 = dtjson.Rows[0][0].ToString().Trim();
                   DataTable dtjson = new DataTable();

                   string status = "";
                   if (datajson != null)
                   {
                       dtjson = ConvertJsonToDatatable(datajson);
                       status = dtjson.Rows[0][0].ToString().Trim();
                   }
                   else
                   {
                       status = "0";
                   }

                   string message1 = "";
                   string IRN1 = "";
                   string Ackdt = "";
                   string Ackno = "";
                   string status1 = "";
                   string SignedQRCode = "";
                   string SignedInvoice = "";

                   string uuid = "";
                   string SignedQrCodeImgUrl = "";
                   string IrnStatus = "";
                   string EwbStatus = "";
                   string Irp = "";

                   string EwbDt = "";
                   string EwbNo = "";
                   string EwbValidTill = "";
                   string Remarks = "";

                   if (status == "1")
                   {
                     /*  message1 = dtjson.Rows[0]["message"].ToString().Replace('"', ' ').Trim();
                       IRN1 = dtjson.Rows[0]["Irn"].ToString().Replace('"', ' ').Trim();
                       Ackdt = dtjson.Rows[0]["AckDt"].ToString().Replace('"', ' ').Trim();
                       Ackno = dtjson.Rows[0]["AckNo"].ToString().Replace('"', ' ').Trim();
                       status1 = dtjson.Rows[0]["Status"].ToString().Replace('"', ' ').Trim();
                       SignedQRCode = dtjson.Rows[0]["SignedQRCode"].ToString().Replace('"', ' ').Trim();

                       SignedInvoice = dtjson.Rows[0]["SignedInvoice"].ToString().Replace('"', ' ').Trim();



                       uuid = dtjson.Rows[0]["uuid"].ToString().Replace('"', ' ').Trim();
                       SignedQrCodeImgUrl = dtjson.Rows[0]["SignedQrCodeImgUrl"].ToString().Replace('"', ' ').Trim();
                       IrnStatus = dtjson.Rows[0]["IrnStatus"].ToString().Replace('"', ' ').Trim();
                       EwbStatus = dtjson.Rows[0]["EwbStatus"].ToString().Replace('"', ' ').Trim();
                       Irp = dtjson.Rows[0]["Irp"].ToString().Replace('"', ' ').Trim();

                       EwbDt = dtjson.Rows[0]["EwbDt"].ToString().Replace('"', ' ').Trim();
                       EwbNo = dtjson.Rows[0]["EwbNo"].ToString().Replace('"', ' ').Trim();
                       EwbValidTill = dtjson.Rows[0]["EwbValidTill"].ToString().Replace('"', ' ').Trim();
                       Remarks = dtjson.Rows[0]["Remarks"].ToString().Replace('"', ' ').Trim();*/


                       
                       message1 = dtjson.Rows[0][1].ToString().Replace('"', ' ').Trim();    		//	1                       
                       IRN1 = dtjson.Rows[0][2].ToString().Replace('"', ' ').Trim();       // 2
                       Ackdt = dtjson.Rows[0][3].ToString().Replace('"', ' ').Trim();     //3
                       Ackno = dtjson.Rows[0][4].ToString().Replace('"', ' ').Trim();    // 4 
                       status1 = dtjson.Rows[0][7].ToString().Replace('"', ' ').Trim();  // 7
                       SignedQRCode = dtjson.Rows[0][10].ToString().Replace('"', ' ').Trim(); //10

                       SignedInvoice = dtjson.Rows[0][11].ToString().Replace('"', ' ').Trim(); //11



                       uuid = dtjson.Rows[0][12].ToString().Replace('"', ' ').Trim();  //12
                       SignedQrCodeImgUrl = dtjson.Rows[0][13].ToString().Replace('"', ' ').Trim();// 13 
                       IrnStatus = dtjson.Rows[0][14].ToString().Replace('"', ' ').Trim();  //14 
                       EwbStatus = dtjson.Rows[0][15].ToString().Replace('"', ' ').Trim(); //15
                       Irp = dtjson.Rows[0][16].ToString().Replace('"', ' ').Trim(); //16

                       EwbDt = dtjson.Rows[0][5].ToString().Replace('"', ' ').Trim(); //5
                       EwbNo = dtjson.Rows[0][6].ToString().Replace('"', ' ').Trim(); //6
                       EwbValidTill = dtjson.Rows[0][9].ToString().Replace('"', ' ').Trim(); // 9
                       Remarks = dtjson.Rows[0][8].ToString().Replace('"', ' ').Trim();//  8




                       objnew.insmastergstdetails(vouno, vouyear, bid, int_divisionid, status, message1, IRN1, Ackdt, Ackno, status1, SignedQRCode, SignedInvoice, uuid, SignedQrCodeImgUrl, IrnStatus, EwbStatus, Irp, voutype, EwbDt, EwbNo, EwbValidTill, Remarks);

                       ScriptManager.RegisterStartupScript(btn_get, typeof(Button), "DataFound", "alertify.alert('Voucher transfer to GST portal');", true);
                   }
                   else
                   {
                       //  l1 = dtjson.Rows[0][1].ToString().Replace('"', ' ').Trim();
                       if (datajson != null)
                       {
                           message1 = dtjson.Rows[0][1].ToString().Replace('"', ' ').Trim();
                       }
                       else
                       {
                           message1 = "The GSTZen user credentials provided in the request are invalid-.";
                       }
                       objnew.insmastergstdetails(vouno, vouyear, bid, int_divisionid, status, message1, "", "", "", "", "", "", "", "", "", "", "", voutype,"","","","");
                    //   ScriptManager.RegisterStartupScript(btn_get, typeof(Button), "DataFound", "alertify.alert('Voucher not transfer to GST portal.check with Accounts Department');", true);

                     
                       ScriptManager.RegisterStartupScript(btn_get, typeof(Button), "DataFound", "alertify.alert('" + message1 + "');", true);
                   }
               }
               else
               {
                   ScriptManager.RegisterStartupScript(btn_get, typeof(Button), "DataFound", "alertify.alert('Unregister Customer not transfer to GST Portal');", true);
               }

                GetPendOrComp4GST();
               


            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }

        }

        public static string DineshhttpPostWebRequets(string url, string postData)
        {
            string strResponse = null;
            string dataval = null;
            string tokenvalue = null;
           DataAccess.Documents objnew = new DataAccess.Documents();

            string Ccode = HttpContext.Current.Session["Ccode"].ToString();
            objnew.GetDataBase(Ccode);

            if (System.Net.ServicePointManager.MaxServicePointIdleTime > 10000)
            {
                System.Net.ServicePointManager.MaxServicePointIdleTime = 10000;
            }

            if (System.Net.ServicePointManager.MaxServicePoints != 0) //unlimit
                System.Net.ServicePointManager.MaxServicePoints = 0;
            // System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
            ServicePointManager.SecurityProtocol = (SecurityProtocolType)192 |
(SecurityProtocolType)768 | (SecurityProtocolType)3072;
            //System.Net.ServicePointManager.SecurityProtocol =  SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls;

            //ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 |  SecurityProtocolType.Tls;
            try
            {

                var webRequest = System.Net.WebRequest.Create(url);
                if (webRequest != null)
                {
                    webRequest.Method = "POST";
                    webRequest.Timeout = 120000;
                    byte[] byteArray = Encoding.UTF8.GetBytes(postData);
                    webRequest.ContentType = "application/json";
                   // webRequest.Headers.Add("Token", "ceadc473-7dc7-42f9-a99b-63ae924a8adb"); // M+R Einvoice Token
                    tokenvalue = objnew.geteinvoicetoken(Convert.ToInt32(HttpContext.Current.Session["LoginDivisionId"].ToString()));

                    webRequest.Headers.Add("Token", tokenvalue);  //"ceadc473-7dc7-42f9-a99b-63ae924a8adb"

                    webRequest.ContentLength = byteArray.Length;
                    using (Stream dataStream = webRequest.GetRequestStream())
                    {
                        dataStream.Write(byteArray, 0, byteArray.Length);
                        dataStream.Close();
                        using (Stream s = webRequest.GetResponse().GetResponseStream())
                        {
                            using (StreamReader sr = new StreamReader(s))
                            {
                                strResponse = sr.ReadToEnd();
                            }
                        }


                    }
                }
                webRequest = null;


            }
            catch (Exception ex)
            {

            }
            return strResponse;
        }

        protected DataTable ConvertJsonToDatatable(string jsonString)
        {
            DataTable dt = new DataTable();
            //strip out bad characters
            string[] jsonParts = Regex.Split(jsonString.Replace("[", "").Replace("]", ""), "},{");

            //hold column names
            List<string> dtColumns = new List<string>();

            //get columns
            foreach (string jp in jsonParts)
            {
                //only loop thru once to get column names
                string[] propData = Regex.Split(jp.Replace("{", "").Replace("}", ""), ",");
                foreach (string rowData in propData)
                {
                    try
                    {
                        int idx = rowData.IndexOf(":");
                        string n = rowData.Substring(0, idx - 1);
                        string v = rowData.Substring(idx + 1);
                        if (!dtColumns.Contains(n))
                        {
                            dtColumns.Add(n.Replace("'", ""));//'
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(string.Format("Error Parsing Column Name : {0}", rowData));
                    }

                }
                break; // TODO: might not be correct. Was : Exit For
            }

            //build dt
            foreach (string c in dtColumns)
            {
                dt.Columns.Add(c);
            }
            //get table data
            foreach (string jp in jsonParts)
            {
                string[] propData = Regex.Split(jp.Replace("{", "").Replace("}", ""), ",");
                DataRow nr = dt.NewRow();
                foreach (string rowData in propData)
                {
                    try
                    {
                        int idx = rowData.IndexOf(":");
                        string n = rowData.Substring(0, idx - 1).Replace("'", "");
                        string v = rowData.Substring(idx + 1).Replace("'", "");
                        nr[n] = v;
                    }
                    catch (Exception)
                    {
                        continue;
                    }

                }
                dt.Rows.Add(nr);
            }
            return dt;
        }


        

    }
}