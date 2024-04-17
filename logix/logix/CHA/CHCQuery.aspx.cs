using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace logix.CHA
{
    public partial class CHCQuery : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["LoginUserName"] == null || Session["LoginEmpId"] == null || Session["LoginDivisionId"] == null || Session["LoginBranchid"] == null)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alertify.alert('Session TimeOut');window.open('"+ Session["Site"].ToString() + "/','_top');", true);
            }
            else if (Session["StrTranType"] == null)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alertify.alert('Session TimeOut');window.open('"+ Session["Site"].ToString() + "/FormMain.aspx','_top');", true);
            }
            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(btnBack);
            string str_CtrlLists, str_MsgLists, str_DataType;
            string str_FornName = "", str_Uiid = "";

            if (Request.QueryString.ToString().Contains("type"))
            {
                lbl_Header.Text = Request.QueryString["type"].ToString();
                Session["type"] = lbl_Header.Text;

                if (lbl_Header.Text == "Consignee")
                {
                    txtconandprinc.Attributes.Add("PlaceHolder", "Consignee");
                    txtconandprinc.ToolTip = "Consignee";
                }
                else if (lbl_Header.Text == "Principal")
                {
                    header.InnerText = "Principal";
                    txtconandprinc.Attributes.Add("PlaceHolder", "Principal");
                    txtconandprinc.ToolTip = "Principal";
                }
                if (IsPostBack != true)
                {
                    DataAccess.LogDetails obj_da_Logobj = new DataAccess.LogDetails();
                    dtdocdte.Text = Utility.fn_ConvertDate(obj_da_Logobj.GetDate().ToString());
                    grdEvent.DataSource = new DataTable();
                    grdEvent.DataBind();
                    txtread();
                   // btnBack.Text = "Cancel";

                    btnBack.ToolTip = "Cancel";
                    btnBack1.Attributes["class"] = "btn ico-cancel";


                    txtconandprinc.Focus();
                }
            }
        }

        [WebMethod]
        public static List<string> Getjobno(string prefix)
        {
            List<string> List_Result = new List<string>();
            DataTable obj_dt = new DataTable();
            DataAccess.Masters.MasterCustomer CHConLikeobj = new DataAccess.Masters.MasterCustomer();

            if (HttpContext.Current.Session["type"].ToString() == "Consignee")
            {
                obj_dt = CHConLikeobj.GetLikeCustomer(prefix.ToUpper(), "C");
                List_Result = Utility.Fn_DatatableToList_Text(obj_dt, "customername");
            }
            else if (HttpContext.Current.Session["type"].ToString() == "Principal")
            {
                obj_dt = CHConLikeobj.GetLikeCustomer(prefix.ToUpper(), "P");
                List_Result = Utility.Fn_DatatableToList_Text(obj_dt, "customername");
            }

            return List_Result;
        }

        protected void txtconandprinc_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DataAccess.Masters.MasterCustomer CHCidobj = new DataAccess.Masters.MasterCustomer();
                DataAccess.CustomHousingAgent.CHQuery CHCusobj = new DataAccess.CustomHousingAgent.CHQuery();
                DataTable dt, dtevent = new DataTable();
                DataTable obj_adddlts = new DataTable();
                int cid;
                cid = CHCidobj.GetCustomerid(txtconandprinc.Text);
                string custom = cid.ToString();
                if (custom == "0" || custom == "")
                {
                    ScriptManager.RegisterClientScriptBlock(this.Page, typeof(Page), "logix", "alertify.alert('Enter Valied CustomerName');", true);
                    txtconandprinc.Text = "";
                    txtconandprinc.Focus();
                    return;
                }
               
              
                DataRow dr;
                int branchid = int.Parse(Session["LoginBranchid"].ToString());
                int divisionid = int.Parse(Session["LoginDivisionId"].ToString());

                if (txtconandprinc.Text != "")
                {
                    obj_adddlts.Columns.Add("JobNo");
                    obj_adddlts.Columns.Add("JobType");
                    obj_adddlts.Columns.Add("DocNo");
                    obj_adddlts.Columns.Add("MdocNo");
                    obj_adddlts.Columns.Add("Customer");
                    obj_adddlts.Columns.Add("Shipper");
                    obj_adddlts.Columns.Add("Consignee");
                    obj_adddlts.Columns.Add("POL");
                    obj_adddlts.Columns.Add("POD");
                    obj_adddlts.Columns.Add("FD");
                    if (lbl_Header.Text == "Consignee")
                    {
                       
                        string jtype;

                        dt = CHCusobj.GetQueryforCustomers(cid, char.Parse("c"), branchid, divisionid);
                        if (dt.Rows.Count > 0)
                        {
                            dr = obj_adddlts.NewRow();
                            for (int i = 0; i <= dt.Rows.Count - 1; i++)
                            {

                               obj_adddlts.Rows.Add(dr);
                                obj_adddlts.Rows[i]["JobNo"] = dt.Rows[i][0].ToString();
                                jtype = dt.Rows[i][1].ToString();
                                if (jtype == "SE")
                                {
                                    obj_adddlts.Rows[i]["JobType"] = "SEA EXPORTS";
                                }
                                else if (jtype == "SI")
                                {
                                    obj_adddlts.Rows[i]["JobType"] = "SEA IMPORTS";
                                }
                                else if (jtype == "AI")
                                {
                                    obj_adddlts.Rows[i]["JobType"] = "AIR IMPORTS";
                                }
                                else if (jtype == "AE")
                                {
                                    obj_adddlts.Rows[i]["JobType"] = "AIR EXPORTS";
                                }
                                else if (jtype == "RI")
                                {
                                    obj_adddlts.Rows[i]["JobType"] = "ROAD IMPORTS";
                                }
                                else if (jtype == "RE")
                                {
                                    obj_adddlts.Rows[i]["JobType"] = "ROAD EXPORTS";
                                }
                                else if (jtype == "BR")
                                {
                                    obj_adddlts.Rows[i]["JobType"] = "BYROAD";
                                }
                                obj_adddlts.Rows[i]["DocNo"] = dt.Rows[i][2].ToString();
                                obj_adddlts.Rows[i]["MdocNo"] = dt.Rows[i][3].ToString();
                                obj_adddlts.Rows[i]["Customer"] = dt.Rows[i][4].ToString();
                                obj_adddlts.Rows[i]["Shipper"] = dt.Rows[i][5].ToString();
                                obj_adddlts.Rows[i]["Consignee"] = dt.Rows[i][6].ToString();
                                obj_adddlts.Rows[i]["POL"] = dt.Rows[i][7].ToString();
                                obj_adddlts.Rows[i]["POD"] = dt.Rows[i][8].ToString();
                                obj_adddlts.Rows[i]["FD"] = dt.Rows[i][9].ToString();

                            }
                            Grd_Job.DataSource = obj_adddlts;
                            ViewState["Table"] = obj_adddlts;
                            Grd_Job.DataBind();
                            
                            if (Grd_Job.Rows.Count>0)
                            {
                                this.popup_Grd.Show();
                                Grd_Job.Visible = true;
                                txtjobno.Focus();
                                txtread();
                                //return;
                            }
                                        
                           // return;
                        }
                        else
                        {
                            this.popup_Grd.Hide();
                            ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Job Not Avaliable');", true);
                        }
                    }
                    else if (lbl_Header.Text == "Principal")
                    {
                        //cid = CHCidobj.GetCustomerid(txtconandprinc.Text);
                        string jtype;

                        dt = CHCusobj.GetQueryforCustomers(cid, char.Parse("P"), branchid, divisionid);
                        if (dt.Rows.Count > 0)
                        {
                            dr = obj_adddlts.NewRow();
                            for (int i = 0; i <= dt.Rows.Count - 1; i++)
                            {

                               obj_adddlts.Rows.Add(dr);
                                obj_adddlts.Rows[i]["JobNo"] = dt.Rows[i][0].ToString();
                                jtype = dt.Rows[i][1].ToString();
                                if (jtype == "SE")
                                {
                                    obj_adddlts.Rows[i]["JobType"] = "SEA EXPORTS";
                                }
                                else if (jtype == "SI")
                                {
                                    obj_adddlts.Rows[i]["JobType"] = "SEA IMPORTS";
                                }
                                else if (jtype == "AI")
                                {
                                    obj_adddlts.Rows[i]["JobType"] = "AIR IMPORTS";
                                }
                                else if (jtype == "AE")
                                {
                                    obj_adddlts.Rows[i]["JobType"] = "AIR EXPORTS";
                                }
                                else if (jtype == "RI")
                                {
                                    obj_adddlts.Rows[i]["JobType"] = "ROAD IMPORTS";
                                }
                                else if (jtype == "RE")
                                {
                                    obj_adddlts.Rows[i]["JobType"] = "ROAD EXPORTS";
                                }
                                else if (jtype == "BR")
                                {
                                    obj_adddlts.Rows[i]["JobType"] = "BYROAD";
                                }
                                obj_adddlts.Rows[i]["DocNo"] = dt.Rows[i][2].ToString();
                                obj_adddlts.Rows[i]["MdocNo"] = dt.Rows[i][3].ToString();
                                obj_adddlts.Rows[i]["Customer"] = dt.Rows[i][4].ToString();
                                obj_adddlts.Rows[i]["Shipper"] = dt.Rows[i][5].ToString();
                                obj_adddlts.Rows[i]["Consignee"] = dt.Rows[i][6].ToString();
                                obj_adddlts.Rows[i]["POL"] = dt.Rows[i][7].ToString();
                                obj_adddlts.Rows[i]["POD"] = dt.Rows[i][8].ToString();
                                obj_adddlts.Rows[i]["FD"] = dt.Rows[i][9].ToString();

                            }
                            Grd_Job.DataSource = obj_adddlts;
                            ViewState["Table"] = obj_adddlts;
                            Grd_Job.DataBind();
                            if (Grd_Job.Rows.Count > 0)
                            {
                                
                                txtjobno.Focus();
                                txtread();
                                this.popup_Grd.Show();
                                Grd_Job.Visible = true;
                                //return;
                            }
                        }
                        else
                        {
                            this.popup_Grd.Hide();
                            ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Job Not Avaliable');", true);
                        }
                    }
                }
                
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
         //   btnBack.Text = "Cancel";




            btnBack.ToolTip = "Cancel";
            btnBack1.Attributes["class"] = "btn ico-cancel";
        }

        public void Txt_clear()
    {
        dtdocdte.Text = "";
        txtjobno.Text = "";
        txtJobtype.Text = "";
        txtDocno.Text = "";
        txtShipper.Text = "";
        txtConsignee.Text = "";
        txtPrincipal.Text = "";
        txtMode.Text = "";
        txtCargo.Text = "";          
        txtPod.Text = "";
        txtfd.Text = "";
        txtNet.Text = "";
        txtMdocno.Text = "";
        txtCustomer.Text = "";
        txtNotify.Text = "";
        txtUser.Text = "";
        txtDocuments.Text = "";
        txtVolume.Text = "";
        txtPol.Text = "";
        txtPkg.Text = "";
        txtGross.Text = ""; ;
        txtDuty.Text = "";
        grdEvent.DataSource = new DataTable();
        grdEvent.DataBind();
    }

        public void txtread()
        {
            txtjobno.BackColor = System.Drawing.Color.White;
            txtjobno.ReadOnly = true;
            txtJobtype.BackColor = System.Drawing.Color.White;
            txtJobtype.ReadOnly = true;
            txtDocno.BackColor = System.Drawing.Color.White;
            txtDocno.ReadOnly = true;
            txtShipper.BackColor = System.Drawing.Color.White;
            txtShipper.ReadOnly = true;
            txtConsignee.BackColor = System.Drawing.Color.White;
            txtConsignee.ReadOnly = true;
            txtPrincipal.BackColor = System.Drawing.Color.White;
            txtPrincipal.ReadOnly = true;
            txtMode.BackColor = System.Drawing.Color.White;
            txtMode.ReadOnly = true;
            txtCargo.BackColor = System.Drawing.Color.White;
            txtCargo.ReadOnly = true;
            txtPod.BackColor = System.Drawing.Color.White;
            txtPod.ReadOnly = true;
            txtfd.BackColor = System.Drawing.Color.White;
            txtfd.ReadOnly = true;
            txtNet.BackColor = System.Drawing.Color.White;
            txtNet.ReadOnly = true;
            txtMdocno.BackColor = System.Drawing.Color.White;
            txtMdocno.ReadOnly = true;
            txtCustomer.BackColor = System.Drawing.Color.White;
            txtCustomer.ReadOnly = true;
            txtNotify.BackColor = System.Drawing.Color.White;
            txtNotify.ReadOnly = true;
            txtUser.BackColor = System.Drawing.Color.White;
            txtUser.ReadOnly = true;
            txtDocuments.BackColor = System.Drawing.Color.White;
            txtDocuments.ReadOnly = true;
            txtVolume.BackColor = System.Drawing.Color.White;
            txtVolume.ReadOnly = true;
            txtPol.BackColor = System.Drawing.Color.White;
            txtPol.ReadOnly = true;
            txtPkg.BackColor = System.Drawing.Color.White;
            txtPkg.ReadOnly = true;
            txtGross.BackColor = System.Drawing.Color.White;
            txtGross.ReadOnly = true;
            txtDuty.BackColor = System.Drawing.Color.White;
            txtDuty.ReadOnly = true;
        }

        protected void Grd_Job_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }

        protected void Grd_Job_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = new DataTable();
                int index, intjobno;
                int branchid = int.Parse(Session["LoginBranchid"].ToString());
                int divisionid = int.Parse(Session["LoginDivisionId"].ToString());
                DataTable dtjobno, dtevent = new DataTable();
                DataTable deTable= new DataTable();
                DataRow dtrow;
                DataAccess.CustomHousingAgent.CHQuery CHCusobj = new DataAccess.CustomHousingAgent.CHQuery();
                dt = (DataTable)ViewState["Table"];
                if (Grd_Job.Rows.Count > 0)
                {
                    //foreach (GridViewRow row in Grd_Job.Rows)
                    //{
                       
                        index = Grd_Job.SelectedRow.RowIndex;
                        Label lbl = (Label)Grd_Job.Rows[index].FindControl("Job");
                        txtjobno.Text = lbl.Text;
                        intjobno = Convert.ToInt32(txtjobno.Text);
                        Label jobtype = (Label)Grd_Job.Rows[index].FindControl("JobType");
                        txtJobtype.Text = jobtype.Text;
                        Label docno = (Label)Grd_Job.Rows[index].FindControl("DocNo");
                        txtDocno.Text = docno.Text;
                        Label mdocno = (Label)Grd_Job.Rows[index].FindControl("MdocNo");
                        txtMdocno.Text = mdocno.Text;
                        Label customer = (Label)Grd_Job.Rows[index].FindControl("Customer");
                        txtCustomer.Text = customer.Text;
                        Label shipper = (Label)Grd_Job.Rows[index].FindControl("Shipper");
                        txtShipper.Text = shipper.Text;
                        Label consignee = (Label)Grd_Job.Rows[index].FindControl("Consignee");
                        txtConsignee.Text = consignee.Text;
                        Label pol = (Label)Grd_Job.Rows[index].FindControl("POL");
                        txtPol.Text = pol.Text;
                        Label pod = (Label)Grd_Job.Rows[index].FindControl("POD");
                        txtPod.Text = pod.Text;
                        Label fd = (Label)Grd_Job.Rows[index].FindControl("FD");
                        txtfd.Text = fd.Text;
                        dtjobno = CHCusobj.GetQueryforJobno(branchid, divisionid, intjobno);
                        if (dtjobno.Rows.Count > 0)
                        {
                            txtNotify.Text = dtjobno.Rows[0][7].ToString();
                            txtPrincipal.Text = dtjobno.Rows[0][8].ToString();
                            txtUser.Text = dtjobno.Rows[0][9].ToString();
                            txtMode.Text = dtjobno.Rows[0][10].ToString();
                            txtDocuments.Text = dtjobno.Rows[0][11].ToString();
                            txtCargo.Text = dtjobno.Rows[0][12].ToString();
                            txtVolume.Text = dtjobno.Rows[0][13].ToString();
                            txtPkg.Text = dtjobno.Rows[0][18].ToString();
                            txtNet.Text = dtjobno.Rows[0][19].ToString();
                            txtGross.Text = dtjobno.Rows[0][20].ToString();
                            DateTime date;
                            date = Convert.ToDateTime(dtjobno.Rows[0][21].ToString());
                            dtdocdte.Text = date.ToShortDateString();
                        }
                        dtevent = CHCusobj.GetQueryforEventdtls(intjobno, branchid, divisionid);
                        if (dtevent.Rows.Count > 0)
                        {
                            deTable.Columns.Add("EventDetails");
                            deTable.Columns.Add("Occuredon");
                            deTable.Columns.Add("Remarks");
                           
                            for (int i = 0; i <= dtevent.Rows.Count - 1; i++)
                            {
                                dtrow = deTable.NewRow();
                                deTable.Rows.Add(dtrow);
                                deTable.Rows[i]["EventDetails"] = dtevent.Rows[i][0].ToString();
                                deTable.Rows[i]["Occuredon"] = dtevent.Rows[i][1].ToString();
                                deTable.Rows[i]["Remarks"] = (dtevent.Rows[i][2].ToString()).ToUpper();
                            }
                            grdEvent.DataSource = deTable;
                            grdEvent.DataBind();
                        }
                        else
                        {
                            grdEvent.DataSource = new DataTable();
                            grdEvent.DataBind();
                     }
                    //}
                }
                txtjobno.Focus();
                Grd_Job.Visible = false;
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
          //  btnBack.Text = "Cancel";



            btnBack.ToolTip = "Cancel";
            btnBack1.Attributes["class"] = "btn ico-cancel";
        }

        protected void Grd_Job_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes.Add("onmouseover", "this.originalcolor=this.style.backgroundColor;" + " this.style.backgroundColor='#FDCB0A';");
                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalcolor;");

                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(Grd_Job, "Select$" + e.Row.RowIndex);
                e.Row.Attributes["style"] = "cursor:pointer";
            }
        }

        protected void grdEvent_SelectedIndexChanged(object sender, EventArgs e)
        {
           // this.Response.End();
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            if(btnBack.ToolTip=="Cancel")
            {
                txtconandprinc.Text = "";
                Txt_clear();
                //btnBack.Text = "Back";


                btnBack.ToolTip = "Back";
                btnBack1.Attributes["class"] = "btn ico-back";
                txtconandprinc.Focus();
            }
            else
            {
                this.Response.End();
            }
        }
    }
}