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
    public partial class CHQuery : System.Web.UI.Page
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
            try { 
            if (Request.QueryString.ToString().Contains("type"))
            {
                lbl_Header.Text = Request.QueryString["type"].ToString();
                if (lbl_Header.Text == "Job ")
                {
                    header.InnerText = "Job";
                    //txtjobno.Attributes.Add("PlaceHolder", "Job #");
                    lbljobno.Text = "Job #";
                    txtjobno.ToolTip = "Job #";
                    //txtDocno.Attributes.Add("PlaceHolder", "Doc #");
                    lblDocno.Text = "Doc #";
                    txtDocno.ToolTip = "Doc #";
                }
                else if (lbl_Header.Text == "Document ")
                {
                    header.InnerText = "Document";
                    //txtjobno.Attributes.Add("PlaceHolder", "Doc #");
                    txtjobno.ToolTip = "Doc #";

                    txtjobno.ToolTip = "Doc #";
                    //txtDocno.Attributes.Add("PlaceHolder", "Job #");
                    lblDocno.Text = "Job #";

                    txtDocno.ToolTip = "Job #";
                }

               
                if (IsPostBack != true)
                {
                    DataAccess.LogDetails obj_da_Logobj = new DataAccess.LogDetails();
                    dtdocdte.Text = Utility.fn_ConvertDate(obj_da_Logobj.GetDate().ToString());
                    grdEvent.DataSource = new DataTable();
                    grdEvent.DataBind();
                    txtjobno.Focus();
                }
            }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }

            header.InnerText = lbl_Header.Text;
        }

        protected void txtjobno_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string jtype;
                int jobno;
                DataAccess.CustomHousingAgent.CHQuery CHJobobj = new DataAccess.CustomHousingAgent.CHQuery();
                DataAccess.CustomHousingAgent.CHQuery CHDocobj = new DataAccess.CustomHousingAgent.CHQuery();
                DataTable dt, dtevent = new DataTable();
                DataTable obj_adddlts = new DataTable();
                int branchid = int.Parse(Session["LoginBranchid"].ToString());
                int divisionid = int.Parse(Session["LoginDivisionId"].ToString());

                if (txtjobno.Text != "")
                {
                    if (lbl_Header.Text == "Job ")
                    {
                        dt = CHJobobj.GetQueryforJobno(branchid, divisionid, int.Parse(txtjobno.Text));
                        if (dt.Rows.Count > 0)
                        {
                            jtype = dt.Rows[0][1].ToString();
                            if (jtype == "SE")
                            {
                                txtJobtype.Text = "SEA EXPORTS";
                            }
                            else if (jtype == "SI")
                            {
                                txtJobtype.Text = "SEA IMPORTS";
                            }
                            else if (jtype == "AI")
                            {
                                txtJobtype.Text = "AIR IMPORTS";
                            }
                            else if (jtype == "AE")
                            {
                                txtJobtype.Text = "AIR EXPORTS";
                            }
                            else if (jtype == "RI")
                            {
                                txtJobtype.Text = "ROAD IMPORTS";
                            }
                            else if (jtype == "RE")
                            {
                                txtJobtype.Text = "ROAD EXPORTS";
                            }
                            else if (jtype == "BR")
                            {
                                txtJobtype.Text = "BYROAD";
                            }
                            txtDocno.Text = dt.Rows[0][2].ToString();
                            txtMdocno.Text = dt.Rows[0][3].ToString();
                            txtShipper.Text = dt.Rows[0][4].ToString();
                            txtCustomer.Text = dt.Rows[0][5].ToString();
                            txtConsignee.Text = dt.Rows[0][6].ToString();
                            txtNotify.Text = dt.Rows[0][7].ToString();
                            txtPrincipal.Text = dt.Rows[0][8].ToString();
                            txtUser.Text = dt.Rows[0][9].ToString();
                            txtMode.Text = dt.Rows[0][10].ToString();
                            txtDocuments.Text = dt.Rows[0][11].ToString();
                            txtCargo.Text = dt.Rows[0][12].ToString();
                            txtVolume.Text = dt.Rows[0][13].ToString();
                            txtPod.Text = dt.Rows[0][15].ToString();
                            txtPol.Text = dt.Rows[0][16].ToString();
                            txtfd.Text = dt.Rows[0][17].ToString();
                            txtPkg.Text = dt.Rows[0][18].ToString();
                            txtNet.Text = dt.Rows[0][19].ToString();
                            txtGross.Text = dt.Rows[0][20].ToString();
                            DateTime dtnew=Convert.ToDateTime(dt.Rows[0][21].ToString());
                            dtdocdte.Text = dtnew.ToShortDateString();
                            dtevent = CHJobobj.GetQueryforEventdtls(int.Parse(txtjobno.Text), branchid, divisionid);

                            if (dtevent.Rows.Count > 0)
                            {
                                for (int i = 0; i < dtevent.Rows.Count - 1; i++)
                                {
                                    obj_adddlts.Rows.Add();
                                    obj_adddlts.Rows[i]["EventDetails"] = dtevent.Rows[i][0].ToString();
                                    obj_adddlts.Rows[i]["Occuredon"] = dtevent.Rows[i][1].ToString();
                                    obj_adddlts.Rows[i]["Remarks"] = dtevent.Rows[i][2].ToString();
                                }
                                grdEvent.DataSource = obj_adddlts;
                                grdEvent.DataBind();
                            }
                            else
                            {
                                grdEvent.DataSource = new DataTable();
                                grdEvent.DataBind();
                            }
                        }
                    }
                    else if (lbl_Header.Text == "Document ")
                    {
                        dt = CHDocobj.GetQueryfordocno(txtjobno.Text, branchid, divisionid);

                        if (dt.Rows.Count > 0)
                        {
                            txtDocno.Text = dt.Rows[0][0].ToString();
                            jobno = int.Parse(dt.Rows[0][0].ToString());
                            jtype = dt.Rows[0][1].ToString();

                            if (jtype == "SE")
                            {
                                txtJobtype.Text = "SEA EXPORTS";
                            }
                            else if (jtype == "SI")
                            {
                                txtJobtype.Text = "SEA IMPORTS";
                            }
                            else if (jtype == "AI")
                            {
                                txtJobtype.Text = "AIR IMPORTS";
                            }
                            else if (jtype == "AE")
                            {
                                txtJobtype.Text = "AIR EXPORTS";
                            }
                            else if (jtype == "RI")
                            {
                                txtJobtype.Text = "ROAD IMPORTS";
                            }
                            else if (jtype == "RE")
                            {
                                txtJobtype.Text = "ROAD EXPORTS";
                            }
                            else if (jtype == "BR")
                            {
                                txtJobtype.Text = "BYROAD";
                            }
                            txtMdocno.Text = dt.Rows[0][3].ToString();
                            txtShipper.Text = dt.Rows[0][4].ToString();
                            txtCustomer.Text = dt.Rows[0][5].ToString();
                            txtConsignee.Text = dt.Rows[0][6].ToString();
                            txtNotify.Text = dt.Rows[0][7].ToString();
                            txtPrincipal.Text = dt.Rows[0][8].ToString();
                            txtUser.Text = dt.Rows[0][9].ToString();
                            txtMode.Text = dt.Rows[0][10].ToString();
                            txtDocuments.Text = dt.Rows[0][11].ToString();
                            txtCargo.Text = dt.Rows[0][12].ToString();
                            txtVolume.Text = dt.Rows[0][13].ToString();
                            txtPod.Text = dt.Rows[0][15].ToString();
                            txtPol.Text = dt.Rows[0][16].ToString();
                            txtfd.Text = dt.Rows[0][17].ToString();
                            txtPkg.Text = dt.Rows[0][18].ToString();
                            txtNet.Text = dt.Rows[0][19].ToString();
                            txtGross.Text = dt.Rows[0][20].ToString();
                            DateTime dtnew = Convert.ToDateTime(dt.Rows[0][21].ToString());
                            dtdocdte.Text = dtnew.ToShortDateString();
                            dtevent = CHJobobj.GetQueryforEventdtls(jobno, branchid, divisionid);
                            if (dtevent.Rows.Count > 0)
                            {
                                for (int i = 0; i < dtevent.Rows.Count - 1; i++)
                                {
                                    obj_adddlts.Rows.Add();
                                    obj_adddlts.Rows[i]["EventDetails"] = dtevent.Rows[i][0].ToString();
                                    obj_adddlts.Rows[i]["Occuredon"] = dtevent.Rows[i][1].ToString();
                                    obj_adddlts.Rows[i]["Remarks"] = dtevent.Rows[i][2].ToString();
                                }
                                grdEvent.DataSource = obj_adddlts;
                                grdEvent.DataBind();
                            }
                            else
                            {
                                grdEvent.DataSource = new DataTable();
                                grdEvent.DataBind();
                            }
                        }
                    }
                   
                   
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
            txtread();
           // btnBack.Text = "Cancel";



            btnBack.ToolTip = "Cancel";
            btnBack1.Attributes["class"] = "btn ico-cancel";
        }

        [WebMethod]
        public static List<string> Getjobno(string prefix)
        {
            List<string> List_Result = new List<string>();
            DataTable obj_dt = new DataTable();
            DataAccess.CustomHousingAgent.JobInfo CHdoclikeobj = new DataAccess.CustomHousingAgent.JobInfo();
            obj_dt = CHdoclikeobj.GetLikeDocno(prefix.ToUpper(), int.Parse(HttpContext.Current.Session["LoginBranchid"].ToString()), int.Parse(HttpContext.Current.Session["LoginDivisionId"].ToString()));
            List_Result = Utility.Fn_DatatableToList_Text(obj_dt, "docno");
            return List_Result;
        }

        public void txtread()
        {
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

        protected void btnBack_Click(object sender, EventArgs e)
        {
            if (btnBack.ToolTip=="Cancel")
            {
                //btnBack.Text = "Back";



                btnBack.ToolTip = "Back";
                btnBack1.Attributes["class"] = "btn ico-back";

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
              
                txtVolume.ReadOnly = true;

                txtPol.Text = "";

                txtPkg.Text = "";

                txtGross.Text = "";

                txtDuty.Text = "";
                grdEvent.DataSource = new DataTable();
                grdEvent.DataBind();
                txtjobno.Focus();
            }
            else
            {
                this.Response.End();
            }
            
        }

        protected void grdEvent_PreRender(object sender, EventArgs e)
        {
            if (grdEvent.Rows.Count > 0)
            {
                grdEvent.UseAccessibleHeader = true;
                grdEvent.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }
    }
}