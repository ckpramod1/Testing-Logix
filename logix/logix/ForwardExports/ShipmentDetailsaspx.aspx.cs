using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using ClosedXML.Excel;
using System.IO;
using System.Text;
using DataAccess.Accounts;

namespace logix.ForwardExports
{
    public partial class ShipmentDetailsaspx : System.Web.UI.Page
    {
        DataAccess.Masters.MasterPort da_obj_Port = new DataAccess.Masters.MasterPort();
        DataAccess.HR.Employee da_obj_HrEmp = new DataAccess.HR.Employee();
        DataAccess.LogDetails Logobj = new DataAccess.LogDetails();
        DataAccess.Masters.MasterBranch da_obj_Branch = new DataAccess.Masters.MasterBranch();
        DataAccess.TotalShipmentDtls da_obj_Totalship = new DataAccess.TotalShipmentDtls();
        DataAccess.LogDetails obj_da_Log = new DataAccess.LogDetails();
        public string Str_Trantype, Str_by;
        string trantype;
        int branchID, employeeID, divisionID;
        DataTable dt_MenuRights = new DataTable();

        protected void Page_Load(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "SpanTagMoveInputBottom();MuiTextField();", true);


            string Ccode = Convert.ToString(Session["Ccode"]);

            if (Ccode != "")
            {

                da_obj_Port.GetDataBase(Ccode);
                da_obj_HrEmp.GetDataBase(Ccode);
                da_obj_Branch.GetDataBase(Ccode);
                da_obj_Totalship.GetDataBase(Ccode);
                obj_da_Log.GetDataBase(Ccode);
                Logobj.GetDataBase(Ccode);
                




            }

            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(btncancel);
            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(btn_exp1);

            if (Session["LoginUserName"] == null || Session["LoginEmpId"] == null || Session["LoginDivisionId"] == null || Session["LoginBranchid"] == null)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alertify.alert('Session TimeOut');window.open('"+ Session["Site"].ToString() + "/','_top');", true);
            }


            employeeID = Convert.ToInt32(Session["LoginEmpId"]);
            branchID = Convert.ToInt32(Session["LoginBranchid"]);
            //if (Session["StrTranType"]!=null)
            //{
            //    trantype = Session["StrTranType"].ToString();
            //}


            //if (ddl_product.Text != "" && ddl_product.Text != "0")
            //{
            //    if (ddl_product.Text == "Ocean Exports")
            //    {
            //        Session["StrTranType"] = "FE";

            //    }
            //    else if (ddl_product.Text == "Ocean Imports")
            //    {
            //        Session["StrTranType"] = "FI";

            //    }
            //    else if (ddl_product.Text == "Air Exports")
            //    {
            //        Session["StrTranType"] = "AE";

            //    }
            //    else if (ddl_product.Text == "Air Imports")
            //    {
            //        Session["StrTranType"] = "AI";

            //    }
            //    else if (ddl_product.Text == "ALL")
            //    {
            //        Session["StrTranType"] = "AC";

            //    }

            //}

            if (!IsPostBack)
            {
                try
                {

                    if (Session["trantype_process"] != null)
                    {
                        Session["StrTranType"] = null;
                        dt_MenuRights = Session["trantype_process"] as DataTable;
                        ddl_product.Items.Add("");
                        ddl_product.Items.Add("ALL");
                        for (int i = 0; i < dt_MenuRights.Rows.Count; i++)
                        {
                            if (dt_MenuRights.Rows[i]["trantype"].ToString() == "FE")
                            {
                                ddl_product.Items.Add("Ocean Exports");
                            }
                            else if (dt_MenuRights.Rows[i]["trantype"].ToString() == "FI")
                            {
                                ddl_product.Items.Add("Ocean Imports");
                            }
                            else if (dt_MenuRights.Rows[i]["trantype"].ToString() == "AE")
                            {
                                ddl_product.Items.Add("Air Exports");
                            }
                            else if (dt_MenuRights.Rows[i]["trantype"].ToString() == "AI")
                            {
                                ddl_product.Items.Add("Air Imports");
                            }

                        }

                    }

                    else
                        if (Session["StrTranType"] != null)
                        {
                            if (Session["StrTranType"]=="CO")
                            {
                                ddl_product.Items.Add("");
                                ddl_product.Items.Add("ALL");
                                ddl_product.Items.Add("Ocean Exports");
                                ddl_product.Items.Add("Ocean Imports");
                                ddl_product.Items.Add("Air Exports");
                                ddl_product.Items.Add("Air Imports");
                                ddl_product.Items.Add("Custom House Agent");
                            }else
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

                                else if (Session["StrTranType"].ToString() == "AC")
                                {
                                    ddl_product.Items.Add("ALL");
                                    ddl_product.SelectedValue = "ALL";
                                    ddl_product_SelectedIndexChanged(sender, e);
                                }
                                else if (Session["StrTranType"].ToString() == "CH")
                                {
                                    ddl_product.Items.Add("Custom House Agent");
                                    ddl_product.SelectedValue = "Custom House Agent";
                                    ddl_product_SelectedIndexChanged(sender, e);
                                }
                                ddl_product.Enabled = false;
                            }
                            
                            //ddl_product.SelectedIndex = 1;
                        }



                    string str_CtrlLists = "txt_from~txt_to";
                    btnget.Attributes.Add("OnClick", "return IsDate('" + str_CtrlLists + "')");
                    //  Str_Trantype = Session["StrTranType"].ToString();
                    BindBranchDLL();
                   // string Str_CurrrentDate = DateTime.Now.ToString("dd/MM/yyyy");
                    string Str_CurrrentDate = Utility.fn_ConvertDate(Logobj.GetDate().ToShortDateString());
                    string firstDayOfMonth = Utility.fn_ConvertDate(new DateTime(Logobj.GetDate().Year, Logobj.GetDate().Month, 1).ToShortDateString());
                    txt_from.Text = firstDayOfMonth;
                    txt_to.Text = Str_CurrrentDate;

                    //txt_from.Text = Str_CurrrentDate;
                    //txt_to.Text = Str_CurrrentDate;
                    GrdJob.DataSource = new DataTable();
                    GrdJob.DataBind();
                    grdbudget.DataSource = new DataTable();
                    grdbudget.DataBind();

                    if (Session["StrTranType"] != null)
                    {
                        if (Session["StrTranType"].ToString() == "AC")
                        {
                            ddl_branch.Enabled = false;
                            ddl_product.Enabled = true;
                            ddl_branch.SelectedIndex = ddl_branch.Items.IndexOf(ddl_branch.Items.FindByText(Session["LoginBranchName"].ToString()));
                        }
                        else if (Session["StrTranType"].ToString() == "CO")
                        {
                            ddl_branch.Enabled = true;
                            ddl_product.Enabled = true;
                        }
                        else
                        {
                            ddl_branch.SelectedIndex = ddl_branch.Items.IndexOf(ddl_branch.Items.FindByText(Session["LoginBranchName"].ToString()));
                            ddl_product.SelectedIndex = ddl_product.Items.IndexOf(ddl_product.Items.FindByValue(Session["StrTranType"].ToString()));
                            ddl_product_SelectedIndexChanged(sender, e);
                            ddl_branch.Enabled = false;
                            ddl_product.Enabled = false;
                        }
                    }

                    if (Session["StrTranType"] != null)
                    {
                        if (Session["StrTranType"].ToString() == "CH")
                        {
                            headlbl.Visible = true;

                            headerlable1.InnerText = "Custom House Agent";
                        }
                        else if (Session["StrTranType"].ToString() == "AC")
                        {
                            headlbl.Visible = true;
                            headerlable1.InnerText = "Operating Accounts";
                        }
                        else if (Session["StrTranType"].ToString() == "CO")
                        {
                            headlbl.Visible = true;
                            headerlable1.InnerText = "MIS and Analysis";
                            if (Session["RightsTranType"].ToString() == "MI")
                            {
                                headerlable2.InnerText = "Analysis";
                            }
                        }
                        else
                        {
                            headlbl.Visible = false;
                            headlbl.Attributes["class"] = "headlbl";
                        }
                    }
                    else
                    {
                        headlbl.Visible = false;
                        headlbl.Attributes["class"] = "headlbl";
                    }

                }
                catch (Exception ex)
                {
                    string message = ex.Message.ToString();
                    ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
                }

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

        }

        protected void ddl_product_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddl_product.SelectedItem.Text == "Air Exports")
            {
                Str_Trantype = "AE";
                ddl_by.Items.Clear();
                ddl_by.Items.Add("");
                ddl_by.Items.Add("Job Open Date");
                ddl_by.Items.Add("Flight Date");
                ddl_by.Items.Add("Job Close Date");
            }
            else if (ddl_product.SelectedItem.Text == "Air Imports")
            {
                Str_Trantype = "AI";
                ddl_by.Items.Clear();
                ddl_by.Items.Add("");
                ddl_by.Items.Add("Job Open Date");
                ddl_by.Items.Add("Flight Date");
                ddl_by.Items.Add("Job Close Date");
            }
            else if (ddl_product.SelectedItem.Text == "Ocean Exports")
            {
                Str_Trantype = "FE";
                ddl_by.Items.Clear();
                ddl_by.Items.Add("");
                ddl_by.Items.Add("Job Open Date");
                ddl_by.Items.Add("ETD");
                ddl_by.Items.Add("Job Close Date");
            }
            else if (ddl_product.SelectedItem.Text == "Ocean Imports")
            {
                Str_Trantype = "FI";
                ddl_by.Items.Clear();
                ddl_by.Items.Add("");
                ddl_by.Items.Add("Job Open Date");
                ddl_by.Items.Add("ETA");
                ddl_by.Items.Add("Job Close Date");
            }
            else if (ddl_product.SelectedItem.Text == "Custom House Agent")
            {
                Str_Trantype = "CH";
                ddl_by.Items.Clear();
                ddl_by.Items.Add("");
                ddl_by.Items.Add("Job Open Date");
                ddl_by.Items.Add("Job Close Date");
            }
            else if (ddl_product.SelectedItem.Text == "ALL")
            {
                Str_Trantype = "AL";
                ddl_by.Items.Clear();
                ddl_by.Items.Add("");
                ddl_by.Items.Add("Job Open Date");
                ddl_by.Items.Add("ETA/ETD");
                ddl_by.Items.Add("Job Close Date");
            }
            hid_Str_Trantype.Value = Str_Trantype;

        }

        protected void btnget_Click(object sender, EventArgs e)
        {
            try
            {
                if (ddl_product.SelectedItem.Text.Trim().Length <= 0)
                {
                    ScriptManager.RegisterStartupScript(btnget, typeof(Button), "Shipment", "alertify.alert('Select Product Name');", true);
                    return;
                }
                else if (ddl_by.SelectedItem.Text.Trim().Length <= 0)
                {
                    ScriptManager.RegisterStartupScript(btnget, typeof(Button), "Shipment", "alertify.alert('Select By Name');", true);
                    return;
                }
                //Str_by=ddl_by.Text;
                if (ddl_product.SelectedItem.Text == "Air Exports")
                {
                    Str_Trantype = "AE";
                }
                else if (ddl_product.SelectedItem.Text == "Air Imports")
                {
                    Str_Trantype = "AI";
                }
                else if (ddl_product.SelectedItem.Text == "Ocean Exports")
                {
                    Str_Trantype = "FE";
                }
                else if (ddl_product.SelectedItem.Text == "Ocean Imports")
                {
                    Str_Trantype = "FI";
                }
                else if (ddl_product.SelectedItem.Text == "Custom House Agent")
                {
                    Str_Trantype = "CH";
                }
                else if (ddl_product.SelectedItem.Text == "ALL")
                {
                    Str_Trantype = "AL";
                }
                if (Str_Trantype == "AL")
                {
                    if (ddl_by.SelectedItem.Text == "Job Open Date")
                    {
                        Str_by = "JOD";
                    }
                    else if (ddl_by.SelectedItem.Text == "Job Close Date")
                    {
                        Str_by = "JCD";
                    }
                    else
                    {
                        Str_by = "ETA";
                    }
                }
                else
                {
                    if (ddl_by.SelectedItem.Text == "Job Open Date")
                    {
                        Str_by = "JOD";
                    }
                    else if (ddl_by.SelectedItem.Text == "Job Close Date")
                    {
                        Str_by = "JCD";
                    }
                    else
                    {
                        Str_by = "ETA";
                    }
                }
                GrdJob.Visible = true;
                GrdBL.Visible = false;
                int int_bid, int_divid, i;
                int_bid = Convert.ToInt32(ddl_branch.SelectedValue.ToString());
                int_divid = Convert.ToInt32(Session["LoginDivisionId"].ToString());
                DataSet obj_ds = new DataSet();
                DataSet obj_dstemp = new DataSet();
                DataTable dt1 = new DataTable();
                DataTable dt2 = new DataTable();
                DataTable dt3 = new DataTable();
                DataTable dt4 = new DataTable();
                string str_fromdate = Utility.fn_ConvertDate(txt_from.Text);
                string str_todate = Utility.fn_ConvertDate(txt_to.Text);
                obj_ds = da_obj_Totalship.GetTotalNoOfJobs(int_bid, int_divid, DateTime.Parse(str_fromdate), DateTime.Parse(str_todate), Str_Trantype, Str_by);
                obj_dstemp = da_obj_Totalship.GetTotalContDtls(int_bid, int_divid, DateTime.Parse(str_fromdate), DateTime.Parse(str_todate), Str_Trantype, Str_by);

                //dt1 = (DataTable)obj_dstemp.Tables[0];
                //dt2 = (DataTable)obj_dstemp.Tables[1];
                //dt3 = (DataTable)obj_dstemp.Tables[2];
                //dt4 = (DataTable)obj_dstemp.Tables[3];
                DataTable obj_DtGrd = new DataTable();
                obj_DtGrd.Columns.Add("Product", typeof(string));
                obj_DtGrd.Columns.Add("AgentBL", typeof(double));
                obj_DtGrd.Columns.Add("OurBL", typeof(double));
                if (obj_ds.Tables.Count > 0)
                {
                    if (Str_Trantype != "CH")
                    {
                        for (i = 0; i <= obj_ds.Tables[obj_ds.Tables.Count - 1].Rows.Count - 1; i++)
                        {
                            DataRow Dr = obj_DtGrd.NewRow();
                            obj_DtGrd.Rows.Add(Dr);

                            Dr[0] = obj_ds.Tables[obj_ds.Tables.Count - 1].Rows[i]["product"];
                            Dr[1] = obj_ds.Tables[obj_ds.Tables.Count - 1].Rows[i]["AgentControl"];
                            Dr[2] = obj_ds.Tables[obj_ds.Tables.Count - 1].Rows[i]["OurControl"];

                        }
                        var sum_agent = obj_DtGrd.Compute("sum(AgentBL)", "");
                        var sum_BL = obj_DtGrd.Compute("sum(OurBL)", "");
                        DataRow Dr1 = obj_DtGrd.NewRow();
                        Dr1 = obj_DtGrd.NewRow();
                        obj_DtGrd.Rows.Add(Dr1);

                        Dr1[0] = "Total"; ;
                        Dr1[1] = sum_agent;
                        Dr1[2] = sum_BL;

                        grdbudget.DataSource = obj_DtGrd;
                        grdbudget.DataBind();
                    }
                   
                    else if (Str_Trantype == "CH")
                    {
                        grdbudget.DataSource = obj_DtGrd;
                        grdbudget.DataBind();
                    }
                    if (Str_Trantype == "AL")
                    {
                        txt_linkjob.Text = obj_ds.Tables[0].Rows[0]["JobCount"].ToString();
                        txt_linkhbl.Text = obj_ds.Tables[0].Rows[0]["BLCount"].ToString();
                        txt_splitbl.Text = obj_ds.Tables[0].Rows[0]["SBLCount"].ToString();
                        if (Str_by != "ETA")
                        {
                            txt_Shpts.Text = obj_ds.Tables[1].Rows[0]["JobCount"].ToString();
                        }
                        txt_consol20.Text = obj_dstemp.Tables[0].Rows[0]["cont20"].ToString();
                        txt_consol40.Text = obj_dstemp.Tables[0].Rows[0]["cont40"].ToString();
                        txt_consolcbm.Text = string.Format("{0:0.00}", obj_dstemp.Tables[0].Rows[0]["Tues"]);
                        txt_cbm.Text = string.Format("{0:0.00}", obj_dstemp.Tables[1].Rows[0]["cbm"]);

                        txt_fcl20.Text = obj_dstemp.Tables[2].Rows[0]["cont20"].ToString();
                        txt_fcl40.Text = obj_dstemp.Tables[2].Rows[0]["cont40"].ToString();
                        txt_fcltues.Text = obj_dstemp.Tables[2].Rows[0]["Tues"].ToString();
                        lbl_AE.Text = "Air";
                        txt_GW.Text = string.Format("{0:0.00}", obj_dstemp.Tables[3].Rows[0]["GrossWt"]);
                        //return;

                    }
                    txt_linkjob.Text = obj_ds.Tables[0].Rows[0]["JobCount"].ToString();
                    if (Str_Trantype != "CH")
                    {
                        txt_linkhbl.Text = obj_ds.Tables[0].Rows[0]["BLCount"].ToString();
                    }
                    
                    if (Str_Trantype == "FI")
                    {
                        txt_splitbl.Text = obj_ds.Tables[0].Rows[0]["SBLCount"].ToString();
                    }

                    if (Str_Trantype == "FE" || Str_Trantype == "FI")
                    {
                        txt_consol20.Text = obj_dstemp.Tables[0].Rows[0]["cont20"].ToString();
                        txt_consol40.Text = obj_dstemp.Tables[0].Rows[0]["cont40"].ToString();
                        txt_consolcbm.Text = string.Format("{0:0.00}", obj_dstemp.Tables[0].Rows[0]["Tues"]);
                        txt_cbm.Text = string.Format("{0:0.00}", obj_dstemp.Tables[1].Rows[0]["cbm"]);

                        txt_fcl20.Text = obj_dstemp.Tables[2].Rows[0]["cont20"].ToString();
                        txt_fcl40.Text = obj_dstemp.Tables[2].Rows[0]["cont40"].ToString();
                        txt_fcltues.Text = obj_dstemp.Tables[2].Rows[0]["Tues"].ToString();
                    }
                    if (Str_Trantype == "AE")
                    {
                        lbl_AE.Text = "Air Exports";
                        txt_GW.Text = string.Format("{0:0.00}", obj_dstemp.Tables[0].Rows[0]["GrossWt"]);

                    }
                    if (Str_Trantype == "AI")
                    {
                        lbl_AE.Text = "Air Imports";
                        txt_GW.Text = string.Format("{0:0.00}", obj_dstemp.Tables[0].Rows[0]["GrossWt"]);
                    }
                    if (Str_Trantype == "FE")
                    {
                        div_AirExports.Attributes["class"] = "JoblinkGross1";
                        lbl_AE.Text = "Air";
                        txt_GW.Text = "0.00";
                    }
                    if (Str_Trantype == "FI")
                    {
                        div_AirExports.Attributes["class"] = "JoblinkGross1";
                        lbl_AE.Text = "Air";
                        txt_GW.Text = "0.00";
                    }
                    if (Str_Trantype == "CH")
                    {
                        div_AirExports.Attributes["class"] = "JoblinkGross1";
                        lbl_AE.Text = "Air";
                        txt_GW.Text = "0.00";
                    }

                    DataTable obj_dtjobtemp = new DataTable();
                    obj_dtjobtemp.Columns.Add("shortname");
                    obj_dtjobtemp.Columns.Add("jobno");
                    obj_dtjobtemp.Columns.Add("jobdate");
                    obj_dtjobtemp.Columns.Add("vslvoy");
                    obj_dtjobtemp.Columns.Add("eta");
                    obj_dtjobtemp.Columns.Add("agent");
                    obj_dtjobtemp.Columns.Add("preparedby");
                    obj_dtjobtemp.Columns.Add("bid");
                    obj_dtjobtemp.Columns.Add("cid");

                    obj_dtjobtemp.Columns.Add("ClosedOn");
                    DataTable obj_dtjob = new DataTable();
                    obj_dtjob = da_obj_Totalship.SPGetTotalNoOfJobDtls(int_bid, int_divid, DateTime.Parse(str_fromdate), DateTime.Parse(str_todate), Str_Trantype, Str_by);

                    if (obj_dtjob.Rows.Count > 0)
                    {
                        for (i = 0; i <= obj_dtjob.Rows.Count - 1; i++)
                        {
                            DataRow dr = obj_dtjobtemp.NewRow();
                            obj_dtjobtemp.Rows.Add(dr);
                            if (Str_Trantype != "CH")
                            {
                                dr[0] = obj_dtjob.Rows[i]["shortname"].ToString();
                                dr[1] = obj_dtjob.Rows[i]["jobno"].ToString();
                                dr[2] = obj_dtjob.Rows[i]["jobdate"].ToString();
                                dr[3] = obj_dtjob.Rows[i]["vslvoy"].ToString();
                                dr[4] = obj_dtjob.Rows[i]["eta"].ToString();
                                dr[5] = obj_dtjob.Rows[i]["agent"].ToString();
                                dr[6] = obj_dtjob.Rows[i]["preparedby"].ToString();
                                dr[7] = obj_dtjob.Rows[i]["bid"].ToString();
                                dr[8] = obj_dtjob.Rows[i]["cid"].ToString();
                                dr[9] = obj_dtjob.Rows[i]["closedate"].ToString();
                            }
                            else
                            {
                                dr[0] = obj_dtjob.Rows[i]["shortname"].ToString();
                                dr[1] = obj_dtjob.Rows[i]["jobno"].ToString();
                                dr[2] = obj_dtjob.Rows[i]["jobdate"].ToString();
                                dr[3] = obj_dtjob.Rows[i]["vslvoy"].ToString();
                                dr[4] = 0;
                                dr[5] = obj_dtjob.Rows[i]["agent"].ToString();
                                dr[6] = obj_dtjob.Rows[i]["preparedby"].ToString();
                                dr[7] = obj_dtjob.Rows[i]["bid"].ToString();
                                dr[8] = obj_dtjob.Rows[i]["cid"].ToString();
                                dr[9] = obj_dtjob.Rows[i]["closedate"].ToString();
                            }
                        }
                        GrdJob.DataSource = obj_dtjobtemp;
                        ViewState["GrdJob"] = obj_dtjobtemp;
                        GrdJob.DataBind();
                        if (Str_Trantype == "CH")
                        {
                            GrdJob.Columns[4].HeaderText = "Vsl/Flight/Truck";
                            GrdJob.Columns[5].Visible = false;
                        }
                        if (ddl_branch.Enabled == false)
                        {
                            GrdJob.Columns[1].Visible = false;
                        }


                        DataTable obj_dtjobtemp1 = new DataTable();
                        obj_dtjobtemp1.Columns.Add("Noofjobs");
                        obj_dtjobtemp1.Columns.Add("Noofhbl");
                        obj_dtjobtemp1.Columns.Add("spiltbl");
                        obj_dtjobtemp1.Columns.Add("FCLnoof20");
                        obj_dtjobtemp1.Columns.Add("FCLnoof40");
                        obj_dtjobtemp1.Columns.Add("FCLnooftues");
                        obj_dtjobtemp1.Columns.Add("consolnoof20");
                        obj_dtjobtemp1.Columns.Add("consolnoof40");
                        obj_dtjobtemp1.Columns.Add("consolnoofCBM");
                        obj_dtjobtemp1.Columns.Add("LCLCBM");
                        obj_dtjobtemp1.Columns.Add("AIRGSWT");
                        obj_dtjobtemp1.Columns.Add("CHASHPTS");

                        DataRow dr1 = obj_dtjobtemp1.NewRow();
                        obj_dtjobtemp1.Rows.Add();

                        obj_dtjobtemp1.Rows[0]["Noofjobs"] = txt_linkjob.Text;
                        obj_dtjobtemp1.Rows[0]["Noofhbl"] = txt_linkhbl.Text;
                        obj_dtjobtemp1.Rows[0]["spiltbl"] = txt_splitbl.Text;
                        obj_dtjobtemp1.Rows[0]["FCLnoof20"] = txt_fcl20.Text;
                        obj_dtjobtemp1.Rows[0]["FCLnoof40"] = txt_fcl40.Text;
                        obj_dtjobtemp1.Rows[0]["FCLnooftues"] = txt_fcltues.Text;
                        obj_dtjobtemp1.Rows[0]["consolnoof20"] = txt_consol20.Text;
                        obj_dtjobtemp1.Rows[0]["consolnoof40"] = txt_consol40.Text;
                        obj_dtjobtemp1.Rows[0]["consolnoofCBM"] = txt_consolcbm.Text;
                        obj_dtjobtemp1.Rows[0]["LCLCBM"] = txt_cbm.Text;
                        obj_dtjobtemp1.Rows[0]["AIRGSWT"] = txt_GW.Text;
                        obj_dtjobtemp1.Rows[0]["CHASHPTS"] = txt_Shpts.Text;

                        Session["obj_dtjobtemp"] = obj_dtjobtemp1;
                                
                    }
                    switch (trantype)
                    {
                        case "AC":
                            Logobj.InsLogDetail(employeeID, 574, 3, branchID, trantype + "/Branch: " + ddl_branch.Text + "/Product: " + ddl_product.Text + "/By: " + ddl_by.Text);
                            break;
                        case "FE":
                            Logobj.InsLogDetail(employeeID, 1007, 3, branchID, trantype + "/Branch: " + ddl_branch.Text + "/Product: " + ddl_product.Text + "/By: " + ddl_by.Text);
                            break;
                        case "FI":
                            Logobj.InsLogDetail(employeeID, 1008, 3, branchID, trantype + "/Branch: " + ddl_branch.Text + "/Product: " + ddl_product.Text + "/By: " + ddl_by.Text);
                            break;
                        case "AE":
                            Logobj.InsLogDetail(employeeID, 1009, 3, branchID, trantype + "/Branch: " + ddl_branch.Text + "/Product: " + ddl_product.Text + "/By: " + ddl_by.Text);
                            break;
                        case "AI":
                            Logobj.InsLogDetail(employeeID, 1010, 3, branchID, trantype + "/Branch: " + ddl_branch.Text + "/Product: " + ddl_product.Text + "/By: " + ddl_by.Text);
                            break;
                        case "CH":
                            Logobj.InsLogDetail(employeeID, 1011, 3, branchID, trantype + "/Branch: " + ddl_branch.Text + "/Product: " + ddl_product.Text + "/By: " + ddl_by.Text);
                            break;
                        case "MI":
                            Logobj.InsLogDetail(employeeID, 576, 3, branchID, trantype + "/Branch: " + ddl_branch.Text + "/Product: " + ddl_product.Text + "/By: " + ddl_by.Text);
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }

        }

        protected void ddl_by_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Str_Trantype == "AL")
            {
                if (ddl_by.SelectedItem.Text == "Job Open Date")
                {
                    Str_by = "JOD";
                }
                else if (ddl_by.SelectedItem.Text == "Job Close Date")
                {
                    Str_by = "JCD";
                }
                else
                {
                    Str_by = "ETA";
                }
            }
            else
            {
                if (ddl_by.SelectedItem.Text == "Job Open Date")
                {
                    Str_by = "JOD";
                }
                else if (ddl_by.SelectedItem.Text == "Job Close Date")
                {
                    Str_by = "JCD";
                }
                else
                {
                    Str_by = "ETA";
                }
            }
        }

        protected void link_job_Click(object sender, EventArgs e)
        {
            try
            {
                GrdBL.Visible = false;

                if (ddl_product.SelectedItem.Text == "Air Exports")
                {
                    Str_Trantype = "AE";
                }
                else if (ddl_product.SelectedItem.Text == "Air Imports")
                {
                    Str_Trantype = "AI";
                }
                else if (ddl_product.SelectedItem.Text == "Ocean Exports")
                {
                    Str_Trantype = "FE";
                }
                else if (ddl_product.SelectedItem.Text == "Ocean Imports")
                {
                    Str_Trantype = "FI";
                }
                else if (ddl_product.SelectedItem.Text == "Custom House Agent")
                {
                    Str_Trantype = "CH";
                }
                else if (ddl_product.SelectedItem.Text == "ALL")
                {
                    Str_Trantype = "AL";
                }

                if (Str_Trantype == "AL")
                {
                    if (ddl_by.SelectedItem.Text == "Job Open Date")
                    {
                        Str_by = "JOD";
                    }
                    else if (ddl_by.SelectedItem.Text == "Job Close Date")
                    {
                        Str_by = "JCD";
                    }
                    else
                    {
                        Str_by = "ETA";
                    }
                }
                else
                {
                    if (ddl_by.SelectedItem.Text == "Job Open Date")
                    {
                        Str_by = "JOD";
                    }
                    else if (ddl_by.SelectedItem.Text == "Job Close Date")
                    {
                        Str_by = "JCD";
                    }
                    else
                    {
                        Str_by = "ETA";
                    }
                }
                GrdJob.DataSource = new DataTable();
                GrdJob.DataBind();
                if (ddl_product.SelectedItem.Text != "" && ddl_by.SelectedItem.Text != "")
                {
                    int int_bid, int_divid, i;
                    int_bid = Convert.ToInt32(ddl_branch.SelectedValue.ToString());
                    int_divid = Convert.ToInt32(Session["LoginDivisionId"].ToString());
                    string str_fromdate = Utility.fn_ConvertDate(txt_from.Text);
                    string str_todate = Utility.fn_ConvertDate(txt_to.Text);
                    DataTable obj_dtjob = new DataTable();
                    DataTable obj_dtjobtemp = new DataTable();
                    obj_dtjobtemp.Columns.Add("shortname");
                    obj_dtjobtemp.Columns.Add("jobno");
                    obj_dtjobtemp.Columns.Add("jobdate");
                    obj_dtjobtemp.Columns.Add("vslvoy");
                    obj_dtjobtemp.Columns.Add("eta");
                    obj_dtjobtemp.Columns.Add("agent");
                    obj_dtjobtemp.Columns.Add("preparedby");
                    obj_dtjobtemp.Columns.Add("bid");
                    obj_dtjobtemp.Columns.Add("cid");

                    GrdBL.Visible = false;

                    obj_dtjob = da_obj_Totalship.SPGetTotalNoOfJobDtls(int_bid, int_divid, DateTime.Parse(str_fromdate), DateTime.Parse(str_todate), Str_Trantype, Str_by);

                    if (obj_dtjob.Rows.Count > 0)
                    {
                        for (i = 0; i <= obj_dtjob.Rows.Count - 1; i++)
                        {
                            DataRow dr = obj_dtjobtemp.NewRow();
                            obj_dtjobtemp.Rows.Add(dr);
                            if (Str_Trantype != "CH")
                            {
                                dr[0] = obj_dtjob.Rows[i]["shortname"].ToString();
                                dr[1] = obj_dtjob.Rows[i]["jobno"].ToString();
                                dr[2] = obj_dtjob.Rows[i]["jobdate"].ToString();
                                dr[3] = obj_dtjob.Rows[i]["vslvoy"].ToString();
                                dr[4] = obj_dtjob.Rows[i]["eta"].ToString();
                                dr[5] = obj_dtjob.Rows[i]["agent"].ToString();
                                dr[6] = obj_dtjob.Rows[i]["preparedby"].ToString();
                                dr[7] = obj_dtjob.Rows[i]["bid"].ToString();
                                dr[8] = obj_dtjob.Rows[i]["cid"].ToString();
                            }
                            else
                            {
                                dr[0] = obj_dtjob.Rows[i]["shortname"].ToString();
                                dr[1] = obj_dtjob.Rows[i]["jobno"].ToString();
                                dr[2] = obj_dtjob.Rows[i]["jobdate"].ToString();
                                dr[3] = obj_dtjob.Rows[i]["vslvoy"].ToString();
                                dr[4] = 0;
                                dr[5] = obj_dtjob.Rows[i]["agent"].ToString();
                                dr[6] = obj_dtjob.Rows[i]["preparedby"].ToString();
                                dr[7] = obj_dtjob.Rows[i]["bid"].ToString();
                                dr[8] = obj_dtjob.Rows[i]["cid"].ToString();
                            }
                        }
                        GrdJob.DataSource = obj_dtjobtemp;
                        GrdJob.DataBind();
                        GrdJob.Visible = true;
                        if (Str_Trantype == "CH")
                        {
                            GrdJob.Columns[4].HeaderText = "Vsl/Flight/Truck";
                            GrdJob.Columns[5].Visible = false;
                        }
                        if (ddl_branch.Enabled == false)
                        {
                            GrdJob.Columns[1].Visible = false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }

        }

        protected void link_hbl_Click(object sender, EventArgs e)
        {
            try
            {

                if (ddl_product.SelectedItem.Text == "Air Exports")
                {
                    Str_Trantype = "AE";
                }
                else if (ddl_product.SelectedItem.Text == "Air Imports")
                {
                    Str_Trantype = "AI";
                }
                else if (ddl_product.SelectedItem.Text == "Ocean Exports")
                {
                    Str_Trantype = "FE";
                }
                else if (ddl_product.SelectedItem.Text == "Ocean Imports")
                {
                    Str_Trantype = "FI";
                }
                else if (ddl_product.SelectedItem.Text == "Custom House Agent")
                {
                    Str_Trantype = "CH";
                }
                else if (ddl_product.SelectedItem.Text == "ALL")
                {
                    Str_Trantype = "AL";
                }
                if (Str_Trantype == "AL")
                {
                    if (ddl_by.SelectedItem.Text == "Job Open Date")
                    {
                        Str_by = "JOD";
                    }
                    else if (ddl_by.SelectedItem.Text == "Job Close Date")
                    {
                        Str_by = "JCD";
                    }
                    else
                    {
                        Str_by = "ETA";
                    }
                }
                else
                {
                    if (ddl_by.SelectedItem.Text == "Job Open Date")
                    {
                        Str_by = "JOD";
                    }
                    else if (ddl_by.SelectedItem.Text == "Job Close Date")
                    {
                        Str_by = "JCD";
                    }
                    else
                    {
                        Str_by = "ETA";
                    }
                }
                GrdJob.Visible = false;
                GrdBL.DataSource = new DataTable();
                GrdBL.DataBind();
                if (ddl_product.SelectedItem.Text != "" && ddl_by.SelectedItem.Text != "")
                {
                    int int_bid, int_divid, i;
                    int_bid = Convert.ToInt32(ddl_branch.SelectedValue.ToString());
                    int_divid = Convert.ToInt32(Session["LoginDivisionId"].ToString());
                    string str_fromdate = Utility.fn_ConvertDate(txt_from.Text);
                    string str_todate = Utility.fn_ConvertDate(txt_to.Text);
                    DataTable obj_dtbl = new DataTable();
                    DataTable obj_dtbltemp = new DataTable();
                    //GrdBL.Visible = true;

                    obj_dtbltemp.Columns.Add("shortname");
                    obj_dtbltemp.Columns.Add("jobno");
                    obj_dtbltemp.Columns.Add("nomination");
                    obj_dtbltemp.Columns.Add("blno");
                    obj_dtbltemp.Columns.Add("shipper");
                    obj_dtbltemp.Columns.Add("pol");
                    obj_dtbltemp.Columns.Add("fd");
                    obj_dtbltemp.Columns.Add("cbm");
                    obj_dtbltemp.Columns.Add("agent");
                    obj_dtbltemp.Columns.Add("preparedby");

                    obj_dtbl = da_obj_Totalship.SPGetTotalNoOfBLDetails(int_bid, int_divid, DateTime.Parse(str_fromdate), DateTime.Parse(str_todate), Str_Trantype, Str_by);

                    if (obj_dtbl.Rows.Count > 0)
                    {
                        for (i = 0; i <= obj_dtbl.Rows.Count - 1; i++)
                        {
                            DataRow dr = obj_dtbltemp.NewRow();
                            obj_dtbltemp.Rows.Add(dr);
                            dr[0] = obj_dtbl.Rows[i]["shortname"].ToString();
                            dr[1] = obj_dtbl.Rows[i]["jobno"].ToString();
                            if (Str_Trantype == "FE" || Str_Trantype == "AE")
                            {
                                if (obj_dtbl.Rows[i]["nomination"].ToString() == "N")
                                {
                                    dr[2] = "Nomination";
                                }
                                else
                                {
                                    dr[2] = "Freehand";
                                }
                            }
                            else if (Str_Trantype == "FI" || Str_Trantype == "AI")
                            {
                                if (obj_dtbl.Rows[i]["nomination"].ToString() == "N")
                                {
                                    dr[2] = "Freehand";
                                }
                                else
                                {
                                    dr[2] = "Nomination";
                                }
                            }
                            else if (Str_Trantype == "AL")
                            {
                                string Str_jobno = obj_dtbl.Rows[i]["jobno"].ToString();
                                if (Str_jobno.Trim().Length > 0)
                                {
                                    string[] Str_jobarray = Str_jobno.Split('-');
                                    if (Str_jobarray.Length > 0)
                                    {
                                        string Str_temp = Str_jobarray[0].ToString();
                                        if (Str_temp == "FE" || Str_temp == "AE")
                                        {
                                            if (obj_dtbl.Rows[i]["nomination"].ToString() == "N")
                                            {
                                                dr[2] = "Nomination";
                                            }
                                            else
                                            {
                                                dr[2] = "Freehand";
                                            }
                                        }
                                        else if (Str_temp == "FI" || Str_temp == "AI")
                                        {
                                            if (obj_dtbl.Rows[i]["nomination"].ToString() == "N")
                                            {
                                                dr[2] = "Freehand";
                                            }
                                            else
                                            {
                                                dr[2] = "Nomination";
                                            }
                                        }
                                    }
                                }
                            }
                            dr[3] = obj_dtbl.Rows[i]["blno"].ToString();
                            dr[4] = obj_dtbl.Rows[i]["shipper"].ToString();
                            dr[5] = obj_dtbl.Rows[i]["pol"].ToString();
                            dr[6] = obj_dtbl.Rows[i]["fd"].ToString();
                            dr[7] = obj_dtbl.Rows[i]["cbm"].ToString();
                            dr[8] = obj_dtbl.Rows[i]["agent"].ToString();
                            dr[9] = obj_dtbl.Rows[i]["preparedby"].ToString();
                        }

                        GrdBL.DataSource = obj_dtbltemp;
                        ViewState["GrdBL"] = obj_dtbltemp;
                        GrdBL.DataBind();
                        GrdBL.Visible = true;
                        if (Str_Trantype == "FE" || Str_Trantype == "AE")
                        {
                            GrdBL.Columns[5].HeaderText = "Shipper";
                        }
                        else if (Str_Trantype == "FI" || Str_Trantype == "AI")
                        {
                            GrdBL.Columns[5].HeaderText = "Consignee";
                        }
                        else if (Str_Trantype == "AL")
                        {
                            GrdBL.Columns[5].HeaderText = "Shipper/Consignee";
                        }
                        if (ddl_branch.Enabled == false)
                        {
                            GrdBL.Columns[1].Visible = false;
                        }
                        GrdBL.Columns[11].Visible = false;
                    }
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
                // ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alertify.alert('Session TimeOut');window.open('../Login.aspx','_top');", true);
            }


        }

        protected void btncancel_Click(object sender, EventArgs e)
        {
            if (btncancel.ToolTip == "Cancel")
            {
                string Str_CurrrentDate = DateTime.Now.ToString("dd/MM/yyyy");
                txt_from.Text = Str_CurrrentDate;
                txt_to.Text = Str_CurrrentDate;
                grdbudget.DataSource = new DataTable();
                grdbudget.DataBind();
                GrdJob.DataSource = new DataTable();
                GrdJob.DataBind();
                GrdBL.DataSource = new DataTable();
                GrdBL.DataBind();
                GrdBL.Visible = false;
                txt_linkjob.Text = "";
                txt_cbm.Text = "";
                txt_consol20.Text = "";
                txt_consol40.Text = "";
                txt_consolcbm.Text = "";
                txt_fcl20.Text = "";
                txt_fcl40.Text = "";
                txt_fcltues.Text = "";
                txt_GW.Text = "";
                txt_linkhbl.Text = "";
                txt_Shpts.Text = "";
                txt_splitbl.Text = "";
                //ddl_branch.SelectedIndex = 0;
                //ddl_product.SelectedIndex = 0;
                //ddl_by.SelectedIndex = 0;
                btncancel.Text = "Back";
                btncancel.ToolTip = "Back";
                btncancel1.Attributes["class"] = "btn ico-back";
            }
            else
            {


                if (Session["StrTranType"] != null)
                {

                    if (Session["StrTranType"].ToString() == "CO")
                    {
                        if (Session["home"] != null)
                        {
                            if (Session["home"].ToString() == "AC&FINhome")
                            {
                                Response.Redirect("../Home/CorpAccNFinance.aspx");
                            }
                            else if (Session["home"].ToString() == "CredConthome")
                            {
                                Response.Redirect("../Home/CorpCreditControl.aspx");
                            }
                            else if (Session["home"].ToString() == "Budgethome")
                            {
                                Response.Redirect("../Home/CorpBudgetHome.aspx");
                            }
                            else if (Session["home"].ToString() == "MISandAnalysisCor")
                            {
                                Response.Redirect("../Home/CORHomeMIS.aspx");
                            }
                            else if (Session["home"].ToString() == "MIS")
                            {
                                Response.Redirect("../Home/MISAndApproval.aspx");
                            }
                        }
                        else if (Session["StrTranType1"].ToString() == "MISandAnalysisCor")
                        {
                            Response.Redirect("../Home/CORHomeMIS.aspx");
                        }
                        else
                        {
                            this.Response.End();
                        }

                    }
                    else if (Session["StrTranType"].ToString() == "AC")
                    {
                        Response.Redirect("../Home/OAHome.aspx");
                    }
                    else
                    {
                        this.Response.End();
                    }
                }
                

                else
                {
                    this.Response.End();
                }

            }
        }




        protected void GrdJob_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

               Str_Trantype= hid_Str_Trantype.Value;
                if (GrdJob.Rows.Count > 0)
                {
                    int index = GrdJob.SelectedRow.RowIndex;
                    string str_jobno;
                    int int_bid, int_divid, i;
                    DataTable obj_temp = new DataTable();
                    int_bid = Convert.ToInt32(GrdJob.SelectedDataKey["bid"].ToString());
                    int_divid = Convert.ToInt32(Session["LoginDivisionId"].ToString());

                    if (Str_Trantype == "AL")
                    {
                        str_jobno = GrdJob.SelectedRow.Cells[2].Text;

                        if (str_jobno.Trim().Length > 0)
                        {
                            String[] str_jobarray = str_jobno.Split('-');
                            if (str_jobarray.Length > 0)
                            {
                                obj_temp = da_obj_Totalship.SPGetTotalNoOfBLDetails4Job(int_bid, int_divid, Convert.ToInt32(str_jobarray[1].ToString()), str_jobarray[0].ToString());
                            }
                        }
                    }

                    else
                    {

                        //String[] str_jobarray = GrdJob.SelectedRow.Cells[2].Text.Split('-');

                        int int_jobno = Convert.ToInt32(GrdJob.SelectedRow.Cells[2].Text);
                        obj_temp = da_obj_Totalship.SPGetTotalNoOfBLDetails4Job(int_bid, int_divid, int_jobno, Str_Trantype);
                    }

                   

                    if (obj_temp.Rows.Count > 0)
                    {
                        DataTable obj_dtbltemp = new DataTable();
                        GrdBL.Visible = true;
                        GrdJob.Visible = false;
                        obj_dtbltemp.Columns.Add("shortname");
                        obj_dtbltemp.Columns.Add("jobno");
                        obj_dtbltemp.Columns.Add("nomination");
                        obj_dtbltemp.Columns.Add("blno");
                        obj_dtbltemp.Columns.Add("shipper");
                        obj_dtbltemp.Columns.Add("pol");
                        obj_dtbltemp.Columns.Add("fd");
                        obj_dtbltemp.Columns.Add("cbm");
                        obj_dtbltemp.Columns.Add("agent");
                        obj_dtbltemp.Columns.Add("preparedby");
                        for (i = 0; i <= obj_temp.Rows.Count - 1; i++)
                        {
                            DataRow dr = obj_dtbltemp.NewRow();
                            obj_dtbltemp.Rows.Add(dr);
                            dr[0] = obj_temp.Rows[i]["shortname"].ToString();
                            dr[1] = obj_temp.Rows[i]["jobno"].ToString();
                            if (Str_Trantype == "FE" || Str_Trantype == "AE")
                            {
                                if (obj_temp.Rows[i]["nomination"].ToString() == "N")
                                {
                                    dr[2] = "Nomination";
                                }
                                else
                                {
                                    dr[2] = "Freehand";
                                }
                            }
                            else if (Str_Trantype == "FI" || Str_Trantype == "AI")
                            {
                                if (obj_temp.Rows[i]["nomination"].ToString() == "N")
                                {
                                    dr[2] = "Freehand";
                                }
                                else
                                {
                                    dr[2] = "Nomination";
                                }
                            }
                            else if (Str_Trantype == "AL")
                            {
                                string Str_jobno = obj_temp.Rows[i]["jobno"].ToString();
                                if (Str_jobno.Trim().Length > 0)
                                {
                                    string[] Str_jobarray = Str_jobno.Split('-');
                                    if (Str_jobarray.Length > 0)
                                    {
                                        string Str_temp = Str_jobarray[0].ToString();
                                        if (Str_temp == "FE" || Str_temp == "AE")
                                        {
                                            if (obj_temp.Rows[i]["nomination"].ToString() == "N")
                                            {
                                                dr[2] = "Nomination";
                                            }
                                            else
                                            {
                                                dr[2] = "Freehand";
                                            }
                                        }
                                        else if (Str_temp == "FI" || Str_temp == "AI")
                                        {
                                            if (obj_temp.Rows[i]["nomination"].ToString() == "N")
                                            {
                                                dr[2] = "Freehand";
                                            }
                                            else
                                            {
                                                dr[2] = "Nomination";
                                            }
                                        }
                                    }
                                }
                            }
                            dr[3] = obj_temp.Rows[i]["blno"].ToString();
                            dr[4] = obj_temp.Rows[i]["shipper"].ToString();
                            dr[5] = obj_temp.Rows[i]["pol"].ToString();
                            dr[6] = obj_temp.Rows[i]["fd"].ToString();
                            dr[7] = obj_temp.Rows[i]["cbm"].ToString();
                            dr[8] = obj_temp.Rows[i]["agent"].ToString();
                            dr[9] = obj_temp.Rows[i]["preparedby"].ToString();
                        }

                        GrdBL.DataSource = obj_dtbltemp;
                        GrdBL.DataBind();
                        if (Str_Trantype == "FE" || Str_Trantype == "AE")
                        {
                            GrdBL.Columns[5].HeaderText = "Shipper";
                        }
                        else if (Str_Trantype == "FI" || Str_Trantype == "AI")
                        {
                            GrdBL.Columns[5].HeaderText = "Consignee";
                        }
                        else if (Str_Trantype == "AL")
                        {
                            GrdBL.Columns[5].HeaderText = "Shipper/Consignee";
                        }
                        if (ddl_branch.Enabled == false)
                        {
                            GrdBL.Columns[1].Visible = false;
                        }
                        GrdBL.Columns[11].Visible = true;
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(GrdJob, typeof(Button), "Shipment", "alertify.alert('No Record Found');", true);
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
                // ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alertify.alert('Session TimeOut');window.open('../Login.aspx','_top');", true);
            }

        }

        protected void GrdBL_SelectedIndexChanged(object sender, EventArgs e)
        {
            GrdBL.Visible = false;
            GrdJob.Visible = true;
        }

        protected void grdbudget_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                if (e.Row.Cells[0].Text == "Total")
                {
                    e.Row.ForeColor = System.Drawing.Color.Brown;


                }

            }
        }

        protected void GrdJob_RowDataBound(object sender, GridViewRowEventArgs e)
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

                Label lbl_vessel = (Label)e.Row.FindControl("lbl_vessel");
                string tooltip = lbl_vessel.Text;
                e.Row.Cells[4].Attributes.Add("title", tooltip);
                Label lbl_Agent = (Label)e.Row.FindControl("lbl_Agent");
                string tooltip1 = lbl_Agent.Text;
                e.Row.Cells[6].Attributes.Add("title", tooltip1);



                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(GrdJob, "Select$" + e.Row.RowIndex);
                e.Row.Attributes["style"] = "cursor:pointer";
                e.Row.Attributes.Add("onmouseover", "this.originalcolor=this.style.backgroundColor;" + " this.style.backgroundColor='#FDCB0A';");
                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalcolor;");
            }
        }

        protected void GrdBL_RowDataBound(object sender, GridViewRowEventArgs e)
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
                Label shipper = (Label)e.Row.FindControl("shipper");
                string tooltip = shipper.Text;
                e.Row.Cells[5].Attributes.Add("title", tooltip);
                Label agent = (Label)e.Row.FindControl("agent");
                string tooltip1 = agent.Text;
                e.Row.Cells[9].Attributes.Add("title", tooltip1);
                Label pol = (Label)e.Row.FindControl("pol");
                string tooltip2 = pol.Text;
                e.Row.Cells[6].Attributes.Add("title", tooltip2);

                Label lblblno = (Label)e.Row.FindControl("blno");
                string tooltip3 = lblblno.Text;
                e.Row.Cells[3].Attributes.Add("title", tooltip3);

                Label lblfd = (Label)e.Row.FindControl("fd");
                string tooltip4 = lblfd.Text;
                e.Row.Cells[7].Attributes.Add("title", tooltip4);

                Label lblpreparedby = (Label)e.Row.FindControl("preparedby");
                string tooltip5 = lblpreparedby.Text;
                e.Row.Cells[10].Attributes.Add("title", tooltip5);

                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(GrdBL, "Select$" + e.Row.RowIndex);
                e.Row.Attributes["style"] = "cursor:pointer";
                e.Row.Attributes.Add("onmouseover", "this.originalcolor=this.style.backgroundColor;" + " this.style.backgroundColor='#FDCB0A';");
                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalcolor;");
            }
        }

        protected void GrdJob_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GrdJob.PageIndex = e.NewPageIndex;
            GrdJob.Visible = true;
            GrdJob.DataSource = (DataTable)ViewState["GrdJob"];
            GrdJob.DataBind();
        }

        protected void GrdBL_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GrdBL.PageIndex = e.NewPageIndex;
            GrdBL.Visible = true;
            GrdBL.DataSource = (DataTable)ViewState["GrdBL"];
            GrdBL.DataBind();
        }

      

        public override void VerifyRenderingInServerForm(Control control)
        {
            //required to avoid the run time error "  
            //Control 'GridView1' of type 'Grid View' must be placed inside a form tag with runat=server."  
        }

        protected void btn_exp1_Click(object sender, EventArgs e)
        {

           /* if (GrdJob.Visible == true)
            {
                if (GrdJob.Rows.Count > 0)
                {
                    Response.Clear();
                    Response.AddHeader("content-disposition", "Attachment;filename=Shipment Wise.xls");
                    Response.Charset = "";
                    Response.ContentType = "application/vnd.xls";
                    StringBuilder SB = new StringBuilder();
                    StringWriter StringWriter = new System.IO.StringWriter(SB);
                    HtmlTextWriter HtmlTextWriter = new HtmlTextWriter(StringWriter);


                    if (GrdJob.Visible == true)
                    {
                        GrdJob.GridLines = GridLines.Both;
                        GrdJob.HeaderStyle.Font.Bold = true;
                        GrdJob.RenderControl(HtmlTextWriter);
                    }
                    Response.Write(StringWriter.ToString());
                    Response.Flush();
                    Response.End();

                }
            }

            if (GrdBL.Visible == true)
            {

                if (GrdBL.Rows.Count > 0)
                {
                    Response.Clear();
                    Response.AddHeader("content-disposition", "Attachment;filename=Shipment Wise.xls");
                    Response.Charset = "";
                    Response.ContentType = "application/vnd.xls";
                    StringBuilder SB = new StringBuilder();
                    StringWriter StringWriter = new System.IO.StringWriter(SB);
                    HtmlTextWriter HtmlTextWriter = new HtmlTextWriter(StringWriter);


                    if (GrdBL.Visible == true)
                    {
                        GrdBL.GridLines = GridLines.Both;
                        GrdBL.HeaderStyle.Font.Bold = true;
                        GrdBL.RenderControl(HtmlTextWriter);
                    }
                    Response.Write(StringWriter.ToString());
                    Response.Flush();
                    Response.End();
                }
            }
            */


            StringBuilder SB = new StringBuilder();
            StringWriter StringWriter = new System.IO.StringWriter(SB);
            HtmlTextWriter HtmlTextWriter = new HtmlTextWriter(StringWriter);


            if (GrdJob.Visible == true)
            {
                if (GrdJob.Rows.Count > 0)
                {
                    Response.Clear();
                    Response.AddHeader("content-disposition", "Attachment;filename=Shipment Wise.xls");
                    Response.Charset = "";
                    Response.ContentType = "application/vnd.xls";
                    //StringBuilder SB = new StringBuilder();
                    //StringWriter StringWriter = new System.IO.StringWriter(SB);
                    //HtmlTextWriter HtmlTextWriter = new HtmlTextWriter(StringWriter);


                    if (GrdJob.Visible == true)
                    {
                        GrdJob.GridLines = GridLines.Both;
                        GrdJob.HeaderStyle.Font.Bold = true;
                        GrdJob.RenderControl(HtmlTextWriter);
                    }
                   

                }
            }

            if (GrdBL.Visible == true)
            {

                if (GrdBL.Rows.Count > 0)
                {
                    Response.Clear();
                    Response.AddHeader("content-disposition", "Attachment;filename=Shipment Wise.xls");
                    Response.Charset = "";
                    Response.ContentType = "application/vnd.xls";
                    

                    if (GrdBL.Visible == true)
                    {
                        GrdBL.GridLines = GridLines.Both;
                        GrdBL.HeaderStyle.Font.Bold = true;
                        GrdBL.RenderControl(HtmlTextWriter);
                    }
                    //Response.Write(StringWriter.ToString());
                    //Response.Flush();
                    //Response.End();
                }
            }
            DataTable dtnew = (DataTable)Session["obj_dtjobtemp"];
            int cnt = 0;
            if (dtnew.Rows.Count>0)
            {
                grdexcel.DataSource = dtnew;

                grdexcel.DataBind();
                cnt = grdexcel.Columns.Count;
                SB.Append("<table BORDER=1 BORDERCOLOR=Black><tr><td align=left colspan=" + cnt + "><font face=arial size=3><B> Shipment details</B></font></td></tr>");
                SB.Append("</table>");
                grdexcel.GridLines = GridLines.Both;
                grdexcel.HeaderStyle.Font.Bold = true;
                grdexcel.RenderControl(HtmlTextWriter);
            }
            Response.Write(StringWriter.ToString());
            Response.Flush();
            Response.End();



            
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
            Panel3.Visible = true;
            DataTable obj_dtlogdetails = new DataTable();
            //DataAccess.LogDetails obj_da_Log = new DataAccess.LogDetails();



            //  obj_dtlogdetails = obj_da_Log.InsTempGrpLogdtlsGet(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), 574, "Statistics", "", "", "");


            switch (trantype)
            {
                case "AC":
                    obj_dtlogdetails = obj_da_Log.InsTempGrpLogdtlsGet(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), 574, "Statistics", "", "", "");
                    break;
                case "FE":
                    obj_dtlogdetails = obj_da_Log.InsTempGrpLogdtlsGet(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), 1007, "Statistics", "", "", "");
                    break;
                case "FI":
                    obj_dtlogdetails = obj_da_Log.InsTempGrpLogdtlsGet(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), 1008, "Statistics", "", "", "");
                    break;
                case "AE":
                    obj_dtlogdetails = obj_da_Log.InsTempGrpLogdtlsGet(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), 1009, "Statistics", "", "", "");
                    break;
                case "AI":
                    obj_dtlogdetails = obj_da_Log.InsTempGrpLogdtlsGet(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), 1010, "Statistics", "", "", "");
                    break;
                case "CH":
                    obj_dtlogdetails = obj_da_Log.InsTempGrpLogdtlsGet(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), 1011, "Statistics", "", "", "");
                    break;
                case "MI":
                    obj_dtlogdetails = obj_da_Log.InsTempGrpLogdtlsGet(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), 633, "Statistics", "", "", "");
                    break;
            }



            lbl_no.InnerText = "Statistics #:";

            if (obj_dtlogdetails.Rows.Count >= 0)
            {
                ModalPopupExtenderlog.Show();
                GridViewlog.DataSource = obj_dtlogdetails;
                GridViewlog.DataBind();
            }
        }

        protected void GrdJob_PreRender(object sender, EventArgs e)
        {
            if (GrdJob.Rows.Count > 0)
            {
                GrdJob.UseAccessibleHeader = true;
                GrdJob.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }

        protected void grdbudget_PreRender(object sender, EventArgs e)
        {
            if (grdbudget.Rows.Count > 0)
            {
                grdbudget.UseAccessibleHeader = true;
                grdbudget.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }

        protected void GrdBL_PreRender(object sender, EventArgs e)
        {
            if (GrdBL.Rows.Count > 0)
            {
                GrdBL.UseAccessibleHeader = true;
                GrdBL.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }

        protected void GridViewlog_PreRender(object sender, EventArgs e)
        {
            if (GridViewlog.Rows.Count > 0)
            {
                GridViewlog.UseAccessibleHeader = true;
                GridViewlog.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }
    }
}