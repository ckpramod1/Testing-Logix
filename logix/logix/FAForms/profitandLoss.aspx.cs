using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using DocumentFormat.OpenXml.Bibliography;
using System.Xml;
using System.Web.UI.DataVisualization.Charting;

namespace logix.FAForm
{
    public partial class profitandLoss : System.Web.UI.Page
    {
        DataAccess.FAMaster.ReportView FAObj = new DataAccess.FAMaster.ReportView();
        DataAccess.LogDetails logobj = new DataAccess.LogDetails();
        DataAccess.FAMaster.ReportView obj_FAReportview = new DataAccess.FAMaster.ReportView();
        DataAccess.FAMaster.ReportView Obj_Report = new DataAccess.FAMaster.ReportView();
        DataAccess.LogDetails Obj_LogDet = new DataAccess.LogDetails();
        DataAccess.MISGrd da_obj_misgrd = new DataAccess.MISGrd();
        DataAccess.MisCorporate miscorobj = new DataAccess.MisCorporate();
        DataAccess.LogDetails Logobj = new DataAccess.LogDetails();
        int RowIndex, ColumnIndex, GroupID;
        string GroupName, Str_CurrrentDate;
        int lcu;
        int gplr;
        int gpler;
        double tgpl;
        int cont;
        double gpl, dingpl, dexgpl;
        bool chkgp;
        protected void Page_Load(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "SpanTagMoveInputBottom();MuiTextField();", true);

            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(btn_Export);
            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(btn_gpprofit);
            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(btn_jobclose1);
            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(btn_jobclose2);
            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(btn_close3);
            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(btn_close4);
            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(btn_cancel);
            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(grd_profit);
            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(grd_all);

            string Ccode = Convert.ToString(Session["Ccode"]);

            if (Ccode != "")
            {

                FAObj.GetDataBase(Ccode);
                logobj.GetDataBase(Ccode);
                obj_FAReportview.GetDataBase(Ccode);
                Obj_Report.GetDataBase(Ccode);
                Obj_LogDet.GetDataBase(Ccode);
                da_obj_misgrd.GetDataBase(Ccode);
                miscorobj.GetDataBase(Ccode);
                Obj_Report.GetDataBase(Ccode);
                Logobj.GetDataBase(Ccode);




            }

            if (Session["LoginUserName"] == null || Session["LoginEmpId"] == null || Session["LoginDivisionId"] == null || Session["LoginBranchid"] == null)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alertify.alert('Session TimeOut');window.open('http://SL.copperhawk.tech/','_top');", true);
            }

            if (Request.QueryString.ToString().Contains("FormName"))
            {
                lbl_MainHeader.Text = Request.QueryString["FormName"].ToString();
            }

            if (!IsPostBack)
            {
                lbnl_logyear.Text = Session["LYEAR"].ToString();
                int Vouyear = Convert.ToInt32(Session["LogYear"].ToString());
                int stryear = Convert.ToInt32(DateTime.Now.Year.ToString());
                int vouyeartext = Convert.ToInt32(Session["Vouyear"].ToString());
                string Str_CurrrentDate = Utility.fn_ConvertDate(logobj.GetDate().ToShortDateString());

                if (Session["countryid"].ToString() == "1102" || Session["countryid"].ToString() == "102")
                {
                    if ((Vouyear == (DateTime.Now).Year - 1 && (DateTime.Now).Month <= 3) || Vouyear == (DateTime.Now).Year)
                    {
                        txt_From.Text = "01/04/" + vouyeartext;
                        txt_To.Text = Str_CurrrentDate.ToString();//Utility.fn_ConvertDate(Str_CurrrentDate.ToString());

                    }
                    else
                    {
                        txt_From.Text = "01/04/" + vouyeartext;
                        txt_To.Text = "31/03/" + (vouyeartext + 1);
                    }
                }
                else
                {
                    if (stryear == vouyeartext)
                    {
                        txt_From.Text = "01/01/" + vouyeartext;
                        txt_To.Text = Str_CurrrentDate.ToString();

                    }
                    else
                    {
                        txt_From.Text = "01/01/" + vouyeartext;
                        txt_To.Text = "31/12/" + (vouyeartext + 1);
                    }
                }
                //Str_CurrrentDate = Utility.fn_ConvertDate(logobj.GetDate().ToShortDateString());
                //txt_To.Text = Str_CurrrentDate.ToString();
                //txt_From.Text = "01/04/" + Vouyear;
                string str_CtrlLists = "txt_From~txt_To";
                btn_group.Attributes.Add("OnClick", "return IsDate('" + str_CtrlLists + "')");
                btn_ledger.Attributes.Add("OnClick", "return IsDate('" + str_CtrlLists + "')");

                if (Session["StrTranType"].ToString() == "CO")
                {
                    chk_consolidate.Visible = true;
                    btn_branch.Visible = true;
                    ddl_branch.Visible = true;
                }
                else
                {
                    chk_consolidate.Visible = false;
                    btn_branch.Visible = false;
                    ddl_branch.Visible = false;
                }

                grd_profit.Visible = true;
                grd_profit.DataSource = new DataTable();
                grd_profit.DataBind();


            }
        }

        protected void btn_group_Click(object sender, EventArgs e)
        {
            Loaddata();
        }

        public DataTable MakingPLData(string DBNAME, DateTime DFrom, DateTime Dto, int Branchid, int divisionid, CheckBox chk)
        {
            //DataAccess.FAMaster.ReportView obj_FAReportview = new DataAccess.FAMaster.ReportView();
            DataSet obj_ds = new DataSet();

            DataTable obj_dtDIE = new DataTable();
            DataTable obj_dtIIE = new DataTable();
            DataTable obj_dt = new DataTable();
            DataTable obj_dttemp = new DataTable();
            double Credit, Debit, Diffamount, TotalCramount = 0, TotalDramount = 0;
            int i;

            if (chk.Checked == true && Session["StrTranType"].ToString() == "CO")
            {
                //Ds = FAObj.SelProfitLosswithdate4AllBranch(Login.FADbname, dtfrom.Value, dtto.Value, Login.divisionid)
                obj_ds = obj_FAReportview.SelProfitLosswithdate4AllBranch(DBNAME, DFrom, Dto, divisionid);
            }
            else
            {
                obj_ds = obj_FAReportview.SelProfitLosswithdate4WEB(DBNAME, Branchid, DFrom, Dto);
            }

            obj_dt.Columns.Add(new DataColumn { ColumnName = "part1", DataType = typeof(string) });
            obj_dt.Columns.Add(new DataColumn { ColumnName = "amount1", DataType = typeof(double) });
            obj_dt.Columns.Add(new DataColumn { ColumnName = "part2", DataType = typeof(string) });
            obj_dt.Columns.Add(new DataColumn { ColumnName = "amount2", DataType = typeof(double) });

            if (obj_ds.Tables.Count > 0)
            {
                obj_dtDIE = obj_ds.Tables[0];
                obj_dtIIE = obj_ds.Tables[1];

                DataView obj_dataview = new DataView(obj_dtDIE);
                obj_dataview.RowFilter = "grouptype='E'";
                obj_dttemp = obj_dataview.ToTable();

                for (i = 0; i <= obj_dttemp.Rows.Count - 1; i++)
                {
                    Credit = 0;
                    Debit = 0;
                    Diffamount = 0;
                    DataRow dr = obj_dt.NewRow();
                    obj_dt.Rows.Add(dr);
                    Debit = double.Parse(obj_dttemp.Rows[i]["debit"].ToString()) + double.Parse(obj_dttemp.Rows[i]["OB_debit"].ToString());
                    Credit = double.Parse(obj_dttemp.Rows[i]["credit"].ToString()) + double.Parse(obj_dttemp.Rows[i]["OB_credit"].ToString());
                    dr[0] = obj_dttemp.Rows[i]["groupname"].ToString();

                    if (Debit >= Credit)
                    {
                        Diffamount = Debit - Credit;
                        dr[1] = Diffamount;
                    }
                    else if (Credit > Debit)
                    {
                        Diffamount = Credit - Debit;
                        dr[1] = -Diffamount;
                        Diffamount = -Diffamount;
                    }
                    TotalDramount = TotalDramount + Diffamount;
                }

                obj_dataview = new DataView(obj_dtDIE);
                obj_dataview.RowFilter = "grouptype='I'";
                obj_dttemp = obj_dataview.ToTable();


                

                for (i = 0; i <= obj_dttemp.Rows.Count - 1; i++)
                {
                    DataRow drr = obj_dt.NewRow();
                    obj_dt.Rows.Add(drr);

                    Credit = 0;
                    Debit = 0;
                    Diffamount = 0;
                    //DataRow dr = obj_dt.NewRow();
                    //obj_dt.Rows.Add(dr);
                    Debit = double.Parse(obj_dttemp.Rows[i]["debit"].ToString()) + double.Parse(obj_dttemp.Rows[i]["OB_debit"].ToString());
                    Credit = double.Parse(obj_dttemp.Rows[i]["credit"].ToString()) + double.Parse(obj_dttemp.Rows[i]["OB_credit"].ToString());

                    obj_dt.Rows[i]["part2"] = obj_dttemp.Rows[i]["groupname"].ToString();
                    if (Debit > Credit)
                    {
                        Diffamount = Debit - Credit;
                        obj_dt.Rows[i]["amount2"] = -Diffamount;
                        Diffamount = -Diffamount;
                    }
                    else if (Credit >= Debit)
                    {
                        Diffamount = Credit - Debit;
                        obj_dt.Rows[i]["amount2"] = Diffamount;
                    }
                    TotalCramount = TotalCramount + Diffamount;
                }

                DataRow dr1 = obj_dt.NewRow();
                obj_dt.Rows.Add(dr1);

                double GP = 0, GL = 0;
                if (TotalCramount > TotalDramount)
                {
                    dr1[0] = "Gross Profit";
                    GP = TotalCramount - TotalDramount;
                    dr1[1] = GP;
                    hid_Gp.Value = GP.ToString();
                }
                else if (TotalCramount < TotalDramount)
                {
                    dr1[2] = "Gross Loss";
                    GL = TotalDramount - TotalCramount;
                    dr1[3] = GL;
                    hid_Gl.Value = GL.ToString();
                }
                DataRow dr2 = obj_dt.NewRow();
                obj_dt.Rows.Add(dr2);
                dr2[0] = "Total";
                dr2[1] = TotalDramount + GP;
                dr2[2] = "Total";
                dr2[3] = TotalCramount + GL;
                DataRow dr3 = obj_dt.NewRow();
                obj_dt.Rows.Add(dr3);

                if (TotalDramount > TotalCramount)
                {
                    dr3[0] = "Gross Loss";
                    dr3[1] = TotalDramount - TotalCramount;
                }
                else if (TotalCramount > TotalDramount)
                {
                    dr3[2] = "Gross Profit";
                    dr3[3] = TotalCramount - TotalDramount;
                }

                TotalCramount = 0;
                TotalDramount = 0;
                obj_dataview = new DataView(obj_dtIIE);
                obj_dataview.RowFilter = "grouptype='E'";
                obj_dttemp = obj_dataview.ToTable();
                DataRow dr_Row = obj_dt.NewRow();
                obj_dt.Rows.Add(dr_Row);

                for (i = 0; i <= obj_dttemp.Rows.Count - 1; i++)
                {
                    Credit = 0;
                    Debit = 0;
                    Diffamount = 0;

                    Debit = double.Parse(obj_dttemp.Rows[i]["debit"].ToString()) + double.Parse(obj_dttemp.Rows[i]["OB_debit"].ToString());
                    Credit = double.Parse(obj_dttemp.Rows[i]["credit"].ToString()) + double.Parse(obj_dttemp.Rows[i]["OB_credit"].ToString());
                    dr_Row[0] = obj_dttemp.Rows[i]["groupname"].ToString();

                    if (Debit >= Credit)
                    {
                        Diffamount = Debit - Credit;
                        dr_Row[1] = Diffamount;
                    }
                    else if (Credit > Debit)
                    {
                        Diffamount = Credit - Debit;
                        dr_Row[1] = -Diffamount;
                        Diffamount = -Diffamount;
                    }
                    TotalDramount = TotalDramount + Diffamount;
                }

                obj_dataview = new DataView(obj_dtIIE);
                obj_dataview.RowFilter = "grouptype='I'";
                obj_dttemp = obj_dataview.ToTable();

                for (i = 0; i <= obj_dttemp.Rows.Count - 1; i++)
                {
                    Credit = 0;
                    Debit = 0;
                    Diffamount = 0;

                    Debit = double.Parse(obj_dttemp.Rows[i]["debit"].ToString()) + double.Parse(obj_dttemp.Rows[i]["OB_debit"].ToString());
                    Credit = double.Parse(obj_dttemp.Rows[i]["credit"].ToString()) + double.Parse(obj_dttemp.Rows[i]["OB_credit"].ToString());
                    dr_Row[2] = obj_dttemp.Rows[i]["groupname"].ToString();
                    if (Debit >= Credit)
                    {
                        Diffamount = Debit - Credit;
                        dr_Row[3] = -Diffamount;
                        Diffamount = -Diffamount;
                    }
                    else if (Credit > Debit)
                    {
                        Diffamount = Credit - Debit;
                        dr_Row[3] = Diffamount;
                    }
                    TotalCramount = TotalCramount + Diffamount;
                }

                double NP = 0, NL = 0;
                DataRow dr4 = obj_dt.NewRow();
                obj_dt.Rows.Add(dr4);
                TotalCramount = GP + TotalCramount;
                TotalDramount = GL + TotalDramount;

                if (TotalCramount > TotalDramount)
                {
                    dr4[0] = "Net Profit";
                    NP = TotalCramount - TotalDramount;
                    dr4[1] = NP;
                }
                else if (TotalCramount < TotalDramount)
                {
                    dr4[2] = "Net Loss";
                    NL = TotalDramount - TotalCramount;
                    dr4[3] = NL;
                }

                DataRow dr5 = obj_dt.NewRow();
                obj_dt.Rows.Add(dr5);
                dr5[0] = "Total";
                dr5[1] = TotalDramount + NP;
                dr5[2] = "Total";
                dr5[3] = TotalCramount + NL;
            }

            return obj_dt;
        }
        public DataTable MakingPLData1(string DBNAME, DateTime DFrom, DateTime Dto, int Branchid, int divisionid, CheckBox chk)
        {
            //DataAccess.FAMaster.ReportView obj_FAReportview = new DataAccess.FAMaster.ReportView();
            DataSet obj_ds = new DataSet();
           // DataAccess.FAMaster.ReportView Obj_Report = new DataAccess.FAMaster.ReportView();
            DataTable obj_dtDIE = new DataTable();
            DataTable obj_dtIIE = new DataTable();
            DataTable obj_dt = new DataTable();
            DataTable obj_dttemp = new DataTable();
            double Credit, Debit, Diffamount, TotalCramount = 0, TotalDramount = 0;
            int i;


            if (chk.Checked == true && Session["StrTranType"].ToString() == "CO")
            {
                //Ds = FAObj.SelProfitLosswithdate4AllBranch(Login.FADbname, dtfrom.Value, dtto.Value, Login.divisionid)
                obj_ds = obj_FAReportview.SelProfitLosswithdate4AllBranch(DBNAME, DFrom, Dto, divisionid);
            }
            else
            {
                obj_ds = obj_FAReportview.SelProfitLosswithdate4WEB(DBNAME, Branchid, DFrom, Dto);
            }

            obj_dt.Columns.Add(new DataColumn { ColumnName = "part1", DataType = typeof(string) });
            obj_dt.Columns.Add(new DataColumn { ColumnName = "debit", DataType = typeof(string) });
            obj_dt.Columns.Add(new DataColumn { ColumnName = "credit", DataType = typeof(string) });
            obj_dt.Columns.Add(new DataColumn { ColumnName = "Net", DataType = typeof(string) });
            obj_dt.Columns.Add(new DataColumn { ColumnName = "amount1", DataType = typeof(double) });
            obj_dt.Columns.Add(new DataColumn { ColumnName = "subgroupid", DataType = typeof(int) });
            //obj_dt.Columns.Add(new DataColumn { ColumnName = "part2", DataType = typeof(string) });
            //obj_dt.Columns.Add(new DataColumn { ColumnName = "amount2", DataType = typeof(double) });

            //////////////////////////////////////DIRECT///////////////////////

            if (obj_ds.Tables.Count > 0)
            {
                obj_dtDIE = obj_ds.Tables[0];
                obj_dtIIE = obj_ds.Tables[1];

                DataView obj_dataview = new DataView(obj_dtDIE);
                obj_dataview.RowFilter = "grouptype='I'";
                obj_dttemp = obj_dataview.ToTable();
                DataTable dt_Profit=new DataTable();
                for (i = 0; i <= obj_dttemp.Rows.Count - 1; i++)
                {
                    Credit = 0;
                    Debit = 0;
                    Diffamount = 0;
                    DataRow dr = obj_dt.NewRow();
                    obj_dt.Rows.Add(dr);
                    Debit = double.Parse(obj_dttemp.Rows[i]["debit"].ToString()) + double.Parse(obj_dttemp.Rows[i]["OB_debit"].ToString());
                    Credit = double.Parse(obj_dttemp.Rows[i]["credit"].ToString()) + double.Parse(obj_dttemp.Rows[i]["OB_credit"].ToString());
                    dr[0] = obj_dttemp.Rows[i]["groupname"].ToString();
                    dr[1] = "";
                    dr[2] = "";
                    dr[3] = "";
                    if (Debit >= Credit)
                    {
                        Diffamount = Math.Abs(Credit - Debit);
                        dr[4] = "-"+Diffamount;
                        Diffamount = Math.Abs(-Diffamount);
                        
                    }
                    else if (Credit > Debit)
                    {
                        Diffamount = Debit - Credit;
                        dr[4] = Math.Abs( Diffamount);
                    }
                    TotalDramount = TotalDramount + Diffamount;
                    dr[5] = 0;
                    if (obj_dttemp.Rows[i]["groupname"].ToString() != "")
                    {
                        GroupName = obj_dttemp.Rows[i]["groupname"].ToString();
                        GroupID = Obj_Report.FASelGroupid(GroupName, Session["FADbname"].ToString());
                        if (GroupID != 0)
                        {
                            if (chk_consolidate.Checked == true)
                            {
                                dt_Profit = Obj_Report.GetSubGroupSummary4AllBranch(Session["FADbname"].ToString(), Convert.ToDateTime(Utility.fn_ConvertDate(txt_From.Text)), Convert.ToDateTime(Utility.fn_ConvertDate(txt_To.Text)), GroupID, Convert.ToInt32(Session["LoginDivisionId"].ToString()));
                            }
                            else
                            {
                                if (Session["StrTranType"].ToString() == "CO")
                                {
                                    dt_Profit = Obj_Report.GetSubGroupSummary(Session["FADbname"].ToString(), Convert.ToDateTime(Utility.fn_ConvertDate(txt_From.Text)), Convert.ToDateTime(Utility.fn_ConvertDate(txt_To.Text)), Convert.ToInt32(Session["LoginBranchid"].ToString()), GroupID);
                                }
                                else
                                {
                                    dt_Profit = Obj_Report.GetSubGroupSummary(Session["FADbname"].ToString(), Convert.ToDateTime(Utility.fn_ConvertDate(txt_From.Text)), Convert.ToDateTime(Utility.fn_ConvertDate(txt_To.Text)), Convert.ToInt32(Session["LoginBranchid"].ToString()), GroupID);
                                }
                            }
                            if (dt_Profit.Rows.Count > 0)
                            {
                                

                                for (i = 0; i <= dt_Profit.Rows.Count - 1; i++)
                                {
                                    DataRow drr1 = obj_dt.NewRow();
                           
                                    drr1[0] = dt_Profit.Rows[i]["subgroupname"].ToString();
                                    drr1[1] = dt_Profit.Rows[i]["debit"].ToString();
                                    drr1[2] = dt_Profit.Rows[i]["credit"].ToString();
                                    drr1[3] = Math.Abs(Convert.ToDouble(dt_Profit.Rows[i]["debit"].ToString()) - Convert.ToDouble(dt_Profit.Rows[i]["credit"].ToString()));
                                    drr1[4] = 0;
                                    drr1[5] = dt_Profit.Rows[i]["subgroupid"].ToString();
                                    obj_dt.Rows.Add(drr1);
                                }

                            }
                            else
                            {
                                //ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), "alertify.alert('No Entry Exists')", true);
                            }
                        }
                    }
                }
                DataRow dre = obj_dt.NewRow();
                    obj_dt.Rows.Add(dre);
                obj_dataview = new DataView(obj_dtDIE);
                obj_dataview.RowFilter = "grouptype='E'";
                obj_dttemp = obj_dataview.ToTable();




                for (i = 0; i <= obj_dttemp.Rows.Count - 1; i++)
                {
                    
                    DataRow drr = obj_dt.NewRow();
                    obj_dt.Rows.Add(drr);
                    if (obj_dt.Rows.Count>0)
                    {
                        cont = obj_dt.Rows.Count;
                    }
                    Credit = 0;
                    Debit = 0;
                    Diffamount = 0;
                    //DataRow dr = obj_dt.NewRow();
                    //obj_dt.Rows.Add(dr);
                    Debit = double.Parse(obj_dttemp.Rows[i]["debit"].ToString()) + double.Parse(obj_dttemp.Rows[i]["OB_debit"].ToString());
                    Credit = double.Parse(obj_dttemp.Rows[i]["credit"].ToString()) + double.Parse(obj_dttemp.Rows[i]["OB_credit"].ToString());

                    drr[0] = obj_dttemp.Rows[i]["groupname"].ToString();
                    drr[1] = "";
                    drr[2] = "";
                    drr[3] = "";
                    if (Debit > Credit)
                    {
                        Diffamount = Credit - Debit;
                        drr[4] = Math.Abs(Diffamount);
                    }
                    else if (Credit >= Debit)
                    {
                        
                        Diffamount = Math.Abs(Debit - Credit);
                        drr[4] = "-"+Diffamount;
                        Diffamount = Math.Abs(-Diffamount);
                    }
                    drr[5] = 0;
                    TotalCramount = TotalCramount + Diffamount;
                    if (obj_dttemp.Rows[i]["groupname"].ToString() != "")
                    {
                        GroupName = obj_dttemp.Rows[i]["groupname"].ToString();
                        GroupID = Obj_Report.FASelGroupid(GroupName, Session["FADbname"].ToString());
                        if (GroupID != 0)
                        {
                            if (chk_consolidate.Checked == true)
                            {
                                dt_Profit = Obj_Report.GetSubGroupSummary4AllBranch(Session["FADbname"].ToString(), Convert.ToDateTime(Utility.fn_ConvertDate(txt_From.Text)), Convert.ToDateTime(Utility.fn_ConvertDate(txt_To.Text)), GroupID, Convert.ToInt32(Session["LoginDivisionId"].ToString()));
                            }
                            else
                            {
                                if (Session["StrTranType"].ToString() == "CO")
                                {
                                    dt_Profit = Obj_Report.GetSubGroupSummary(Session["FADbname"].ToString(), Convert.ToDateTime(Utility.fn_ConvertDate(txt_From.Text)), Convert.ToDateTime(Utility.fn_ConvertDate(txt_To.Text)), Convert.ToInt32(Session["LoginBranchid"].ToString()), GroupID);
                                }
                                else
                                {
                                    dt_Profit = Obj_Report.GetSubGroupSummary(Session["FADbname"].ToString(), Convert.ToDateTime(Utility.fn_ConvertDate(txt_From.Text)), Convert.ToDateTime(Utility.fn_ConvertDate(txt_To.Text)), Convert.ToInt32(Session["LoginBranchid"].ToString()), GroupID);
                                }
                            }
                            if (dt_Profit.Rows.Count > 0)
                            {
                              

                                for (i = 0; i <= dt_Profit.Rows.Count - 1; i++)
                                {
                                    DataRow drr1 = obj_dt.NewRow();
                                    
                                    drr1[0] = dt_Profit.Rows[i]["subgroupname"].ToString();
                                    drr1[1] = dt_Profit.Rows[i]["debit"].ToString();
                                    drr1[2] = dt_Profit.Rows[i]["credit"].ToString();
                                    drr1[3] = Math.Abs(Convert.ToDouble(dt_Profit.Rows[i]["debit"].ToString()) - Convert.ToDouble(dt_Profit.Rows[i]["credit"].ToString()));
                                    drr1[4] = 0;
                                    drr1[5] = dt_Profit.Rows[i]["subgroupid"].ToString();
                                    obj_dt.Rows.Add(drr1);
                                }

                            }
                            else
                            {
                               // ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), "alertify.alert('No Entry Exists')", true);
                            }
                        }
                    }
                }

                DataRow dr1 = obj_dt.NewRow();
                obj_dt.Rows.Add(dr1);

                double GP = 0, GL = 0;
                //double gpl;
                //if (obj_dt.Rows.Count>0)
                //{
                //    for (i = 0; i <= obj_dt.Rows.Count - 1; i++)
                //    {
                //        if (obj_dt.Rows[i][0].ToString() == "DIRECT EXPENSES" || obj_dt.Rows[i][0].ToString() == "DIRECT INCOME")
                //        {
                //             gpl =  Convert.ToDouble(obj_dt.Rows[i]["amount1"].ToString())- Convert.ToDouble(gpl);
                //        } 
                //    }
                //    DataRow drr1 = obj_dt.NewRow();

                //    drr1[0] = "Gross Profit/Loss";
                //    drr1[1] = "";
                //    drr1[2] = "";
                //    drr1[3] = "";
                //    drr1[4] = Convert.ToDouble(Math.Abs( gpl));
                //    obj_dt.Rows.Add(drr1);

                //}
                if (obj_dt.Rows.Count > 0)
                {
                    Session["gpl"] = 0;
                    for (i = 0; i <= obj_dt.Rows.Count - 1; i++)
                    {
                        if (obj_dt.Rows[i][0].ToString() == "DIRECT INCOME")
                        {
                            dingpl = Math.Abs(Convert.ToDouble(obj_dt.Rows[i]["amount1"].ToString()));
                        }
                        if (obj_dt.Rows[i][0].ToString() == "DIRECT EXPENSES")
                        {
                            dexgpl = Math.Abs(Convert.ToDouble(obj_dt.Rows[i]["amount1"].ToString()));
                        }
                        if (obj_dt.Rows[i][0].ToString() == "DIRECT EXPENSES" || obj_dt.Rows[i][0].ToString() == "DIRECT INCOME")
                        {
                            
                            gpl = Convert.ToDouble(dingpl) - Convert.ToDouble(dexgpl);
                            Session["dgpl"] = Convert.ToDouble(gpl);
                        }
                    }
                    DataRow drr1 = obj_dt.NewRow();

                    if (dingpl > dexgpl)
                    {
                        drr1[0] = "Gross Profit";
                    }
                    else
                    {
                        drr1[0] = "Gross Loss";
                    }
                    drr1[1] = "";
                    drr1[2] = "";
                    drr1[3] = "";
                    drr1[4] = Convert.ToDouble(Math.Abs(gpl));
                    drr1[5] = 0;
                    obj_dt.Rows.Add(drr1);

                }


                //if (obj_dt.Rows.Count > 0)
                //{
                //    Session["gpl"] = 0;
                //    for (i = 0; i <= obj_dt.Rows.Count - 1; i++)
                //    {
                //        if (obj_dt.Rows[i][0].ToString() == "DIRECT INCOME")
                //        {
                //            dingpl = Math.Abs(Convert.ToDouble(obj_dt.Rows[i]["amount1"].ToString()));
                //        }
                        
                //    }
                //    DataRow drr1 = obj_dt.NewRow();

                    
                //        drr1[0] = "Total";
                    
                //    drr1[1] = "";
                //    drr1[2] = "";
                //    drr1[3] = "";
                //    drr1[4] = Convert.ToDouble(Math.Abs(dingpl));
                //    drr1[5] = 0;
                //    obj_dt.Rows.Add(drr1);

                //}

                DataRow dr3 = obj_dt.NewRow();
                obj_dt.Rows.Add(dr3);

                ////////////////////////////////////// inDIRECT///////////////////////

                TotalCramount = 0;
                TotalDramount = 0;
                obj_dataview = new DataView(obj_dtIIE);
                obj_dataview.RowFilter = "grouptype='I'";
                obj_dttemp = obj_dataview.ToTable();
                DataRow dr_Row = obj_dt.NewRow();
                obj_dt.Rows.Add(dr_Row);


                for (i = 0; i <= obj_dttemp.Rows.Count - 1; i++)
                {
                    Credit = 0;
                    Debit = 0;
                    Diffamount = 0;

                    Debit = double.Parse(obj_dttemp.Rows[i]["debit"].ToString()) + double.Parse(obj_dttemp.Rows[i]["OB_debit"].ToString());
                    Credit = double.Parse(obj_dttemp.Rows[i]["credit"].ToString()) + double.Parse(obj_dttemp.Rows[i]["OB_credit"].ToString());
                    dr_Row[0] = obj_dttemp.Rows[i]["groupname"].ToString();
                    dr_Row[1] = "";
                    dr_Row[2] = "";
                    dr_Row[3] = "";
                    if (Debit >= Credit)
                    {
                        Diffamount = Math.Abs(Credit - Debit);
                        dr_Row[4] = "-"+Diffamount;
                        Diffamount = Math.Abs(-Diffamount);
                    }
                    else if (Credit > Debit)
                    {
                       
                        Diffamount = Debit - Credit;
                        dr_Row[4] = Math.Abs(Diffamount);
                    }
                    dr_Row[5] = 0;
                    TotalDramount = TotalDramount + Diffamount;
                    if (obj_dttemp.Rows[i]["groupname"].ToString() != "")
                    {
                        GroupName = obj_dttemp.Rows[i]["groupname"].ToString();
                        GroupID = Obj_Report.FASelGroupid(GroupName, Session["FADbname"].ToString());
                        if (GroupID != 0)
                        {
                            if (chk_consolidate.Checked == true)
                            {
                                dt_Profit = Obj_Report.GetSubGroupSummary4AllBranch(Session["FADbname"].ToString(), Convert.ToDateTime(Utility.fn_ConvertDate(txt_From.Text)), Convert.ToDateTime(Utility.fn_ConvertDate(txt_To.Text)), GroupID, Convert.ToInt32(Session["LoginDivisionId"].ToString()));
                            }
                            else
                            {
                                if (Session["StrTranType"].ToString() == "CO")
                                {
                                    dt_Profit = Obj_Report.GetSubGroupSummary(Session["FADbname"].ToString(), Convert.ToDateTime(Utility.fn_ConvertDate(txt_From.Text)), Convert.ToDateTime(Utility.fn_ConvertDate(txt_To.Text)), Convert.ToInt32(Session["LoginBranchid"].ToString()), GroupID);
                                }
                                else
                                {
                                    dt_Profit = Obj_Report.GetSubGroupSummary(Session["FADbname"].ToString(), Convert.ToDateTime(Utility.fn_ConvertDate(txt_From.Text)), Convert.ToDateTime(Utility.fn_ConvertDate(txt_To.Text)), Convert.ToInt32(Session["LoginBranchid"].ToString()), GroupID);
                                }
                            }
                            if (dt_Profit.Rows.Count > 0)
                            {
                                for (i = 0; i <= dt_Profit.Rows.Count - 1; i++)
                                {
                                    DataRow drr1 = obj_dt.NewRow();

                                    drr1[0] = dt_Profit.Rows[i]["subgroupname"].ToString();
                                    drr1[1] = dt_Profit.Rows[i]["debit"].ToString();
                                    drr1[2] = dt_Profit.Rows[i]["credit"].ToString();
                                    drr1[3] = Math.Abs(Convert.ToDouble(dt_Profit.Rows[i]["debit"].ToString()) - Convert.ToDouble(dt_Profit.Rows[i]["credit"].ToString()));
                                    drr1[4] = 0;
                                    drr1[5] = dt_Profit.Rows[i]["subgroupid"].ToString();
                                    obj_dt.Rows.Add(drr1);
                                }

                            }
                            else
                            {
                                //ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), "alertify.alert('No Entry Exists')", true);
                            }
                        }
                    }
                }
                DataRow dr3e = obj_dt.NewRow();
                obj_dt.Rows.Add(dr3e);
                obj_dataview = new DataView(obj_dtIIE);
                obj_dataview.RowFilter = "grouptype='E'";
                obj_dttemp = obj_dataview.ToTable();
                DataRow dr_Row1 = obj_dt.NewRow();
                obj_dt.Rows.Add(dr_Row1);
                for (i = 0; i <= obj_dttemp.Rows.Count - 1; i++)
                {
                    Credit = 0;
                    Debit = 0;
                    Diffamount = 0;

                    Debit = double.Parse(obj_dttemp.Rows[i]["debit"].ToString()) + double.Parse(obj_dttemp.Rows[i]["OB_debit"].ToString());
                    Credit = double.Parse(obj_dttemp.Rows[i]["credit"].ToString()) + double.Parse(obj_dttemp.Rows[i]["OB_credit"].ToString());
                    dr_Row1[0] = obj_dttemp.Rows[i]["groupname"].ToString();
                    dr_Row1[1] = "";
                    dr_Row1[2] = "";
                    dr_Row1[3] = "";
                    if (Debit >= Credit)
                    {
                        Diffamount = Credit - Debit;
                        dr_Row1[4] = Math.Abs(Diffamount);
                    }
                    else if (Credit > Debit)
                    {

                        Diffamount = Math.Abs(Debit - Credit);
                        dr_Row1[4] = "-"+Diffamount;
                        Diffamount = Math.Abs(-Diffamount);
                    }
                    dr_Row1[5] = 0;
                    TotalCramount = TotalCramount + Diffamount;
                    if (obj_dttemp.Rows[i]["groupname"].ToString() != "")
                    {
                        GroupName = obj_dttemp.Rows[i]["groupname"].ToString();
                        GroupID = Obj_Report.FASelGroupid(GroupName, Session["FADbname"].ToString());
                        if (GroupID != 0)
                        {
                            if (chk_consolidate.Checked == true)
                            {
                                dt_Profit = Obj_Report.GetSubGroupSummary4AllBranch(Session["FADbname"].ToString(), Convert.ToDateTime(Utility.fn_ConvertDate(txt_From.Text)), Convert.ToDateTime(Utility.fn_ConvertDate(txt_To.Text)), GroupID, Convert.ToInt32(Session["LoginDivisionId"].ToString()));
                            }
                            else
                            {
                                if (Session["StrTranType"].ToString() == "CO")
                                {
                                    dt_Profit = Obj_Report.GetSubGroupSummary(Session["FADbname"].ToString(), Convert.ToDateTime(Utility.fn_ConvertDate(txt_From.Text)), Convert.ToDateTime(Utility.fn_ConvertDate(txt_To.Text)), Convert.ToInt32(Session["LoginBranchid"].ToString()), GroupID);
                                }
                                else
                                {
                                    dt_Profit = Obj_Report.GetSubGroupSummary(Session["FADbname"].ToString(), Convert.ToDateTime(Utility.fn_ConvertDate(txt_From.Text)), Convert.ToDateTime(Utility.fn_ConvertDate(txt_To.Text)), Convert.ToInt32(Session["LoginBranchid"].ToString()), GroupID);
                                }
                            }
                            if (dt_Profit.Rows.Count > 0)
                            {
                                for (i = 0; i <= dt_Profit.Rows.Count - 1; i++)
                                {
                                    DataRow drr1 = obj_dt.NewRow();

                                    drr1[0] = dt_Profit.Rows[i]["subgroupname"].ToString();
                                    drr1[1] = dt_Profit.Rows[i]["debit"].ToString();
                                    drr1[2] = dt_Profit.Rows[i]["credit"].ToString();
                                    drr1[3] = Math.Abs(Convert.ToDouble(dt_Profit.Rows[i]["debit"].ToString()) - Convert.ToDouble(dt_Profit.Rows[i]["credit"].ToString()));
                                    drr1[4] = 0;
                                    drr1[5] = dt_Profit.Rows[i]["subgroupid"].ToString();
                                    obj_dt.Rows.Add(drr1);
                                }

                            }
                            else
                            {
                                //ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), "alertify.alert('No Entry Exists')", true);
                            }
                        }
                    }
                }

                double NP = 0, NL = 0;
                DataRow dr4 = obj_dt.NewRow();
                obj_dt.Rows.Add(dr4);
                TotalCramount = GP + TotalCramount;
                TotalDramount = GL + TotalDramount;

                //if (TotalCramount > TotalDramount)
                //{
                //    dr4[0] = "Net Profit";
                //    NP = TotalCramount - TotalDramount;
                //    dr4[1] = NP;
                //}
                //else if (TotalCramount < TotalDramount)
                //{
                //    dr4[2] = "Net Loss";
                //    NL = TotalDramount - TotalCramount;
                //    dr4[3] = NL;
                //}
                dingpl = 0;
                    dexgpl = 0;
                if (obj_dt.Rows.Count > 0)
                {
                    for (i = 0; i <= obj_dt.Rows.Count - 1; i++)
                    {
                        if (obj_dt.Rows[i][0].ToString() == "INDIRECT INCOME")
                        {
                            dingpl = Math.Abs(Convert.ToDouble(obj_dt.Rows[i]["amount1"].ToString()));
                        }
                        if (obj_dt.Rows[i][0].ToString() == "INDIRECT EXPENSES")
                        {
                            dexgpl = Math.Abs(Convert.ToDouble(obj_dt.Rows[i]["amount1"].ToString()));
                        }
                        if (obj_dt.Rows[i][0].ToString() == "INDIRECT EXPENSES" || obj_dt.Rows[i][0].ToString() == "INDIRECT INCOME")
                        {
                            gpl = Convert.ToDouble(dingpl) - Convert.ToDouble(dexgpl);
                        }
                    }
                    DataRow drr1 = obj_dt.NewRow();

                    //if (dingpl > dexgpl)
                    //{
                    //    drr1[0] = "Gross Profit";
                    //}
                    //else
                    //{
                    //    drr1[0] = "Gross Loss";
                    //}
                    //drr1[1] = "";
                    //drr1[2] = "";
                    //drr1[3] = "";
                    //drr1[4] = Convert.ToDouble(Math.Abs(gpl));
                    //drr1[5] = 0;
                    //obj_dt.Rows.Add(drr1);

                }
                DataRow dr5 = obj_dt.NewRow();
                obj_dt.Rows.Add(dr5);
                if (obj_dt.Rows.Count > 0)
                {
                    Session["igpl"] = 0;
                    for (i = 0; i <= obj_dt.Rows.Count - 1; i++)
                    {
                        if (obj_dt.Rows[i][0].ToString() == "INDIRECT INCOME")
                        {
                            dingpl = Math.Abs(Convert.ToDouble(obj_dt.Rows[i]["amount1"].ToString()));
                        }
                        if (obj_dt.Rows[i][0].ToString() == "INDIRECT EXPENSES")
                        {
                            dexgpl = Math.Abs(Convert.ToDouble(obj_dt.Rows[i]["amount1"].ToString()));
                            Session["tegpl"] = dexgpl;
                        }
                        if (obj_dt.Rows[i][0].ToString() == "INDIRECT EXPENSES" || obj_dt.Rows[i][0].ToString() == "INDIRECT INCOME")
                        {
                            gpl = Convert.ToDouble(dingpl) - Convert.ToDouble(dexgpl);
                            Session["igpl"] = Convert.ToDouble(gpl);
                        }
                    }
                    DataRow drr1 = obj_dt.NewRow();

                    if (dingpl > dexgpl)
                    {
                        dr5[0] = "Net Profit";                        
                    }
                    else
                    {
                        dr5[0] = "Net Loss";
                    }
                    dr5[1] = "";
                    dr5[2] = "";
                    dr5[3] = "";
                    //if (Convert.ToDouble(Session["dgpl"]) > Convert.ToDouble(Session["igpl"]))
                    //{
                    //    dr5[4] = Convert.ToDouble(Session["dgpl"]) - Convert.ToDouble(Session["igpl"]);
                    //    Session["tgpl"] = Convert.ToDouble(Session["dgpl"]) - Convert.ToDouble(Session["igpl"]);

                    //}
                    //else
                    //{
                    //    dr5[4] = Convert.ToDouble(Session["dgpl"]) + Convert.ToDouble(Session["igpl"]);
                    //    Session["tgpl"] = Convert.ToDouble(Session["dgpl"]) + Convert.ToDouble(Session["igpl"]);
                    //}
                    //dr5[5] = 0;
                    if (Convert.ToDouble(Session["dgpl"]) > Convert.ToDouble(Session["igpl"]))
                    {
                        dr5[4] = Convert.ToDouble(Session["dgpl"]) - Convert.ToDouble(dingpl) - Convert.ToDouble(dexgpl);
                        Session["tgpl"] = Convert.ToDouble(Session["dgpl"]) - Convert.ToDouble(dingpl) - Convert.ToDouble(dexgpl);

                    }
                    else
                    {
                        dr5[4] = Convert.ToDouble(Session["dgpl"]) + Convert.ToDouble(dingpl) + Convert.ToDouble(dexgpl);
                        Session["tgpl"] = Convert.ToDouble(Session["dgpl"]) + Convert.ToDouble(dingpl) + Convert.ToDouble(dexgpl);
                    }
                    dr5[5] = 0;
                    //obj_dt.Rows.Add(drr1);


                    //drr1[0] = "Total Net";
                    //drr1[1] = "";
                    //drr1[2] = "";
                    //drr1[3] = "";
                    
                    

                    //if (Convert.ToDouble(Session["dgpl"])> Convert.ToDouble(Session["igpl"]))
                    //{
                    //    drr1[4] = Convert.ToDouble(Session["dgpl"]) - Convert.ToDouble(Session["igpl"]) - Convert.ToDouble(Session["tegpl"]);
                    //}
                    //else
                    //{
                    //    drr1[4] = Convert.ToDouble(Session["dgpl"]) + Convert.ToDouble(Session["igpl"]) - Convert.ToDouble(Session["tegpl"]);
                    //}
                    //drr1[5] = 0;

                    //drr1[0] = "Total";
                    //drr1[1] = "";
                    //drr1[2] = "";
                    //drr1[3] = "";
                    //obj_dt.Rows.Add(drr1);


                    //if (Convert.ToDouble(Session["dgpl"]) > Convert.ToDouble(Session["igpl"]))
                    //{
                    //    drr1[4] = Convert.ToDouble(Session["dgpl"]) - Convert.ToDouble(Session["igpl"]) - Convert.ToDouble(Session["tegpl"]);
                    //}
                    //else
                    //{
                        
                    //    drr1[4] = Convert.ToDouble(Session["dgpl"]) + Convert.ToDouble(Session["igpl"]) - Convert.ToDouble(Session["tegpl"]);
                    //}
                    //drr1[5] = 0;

                    //obj_dt.Rows.Add(drr1);
                }

                //dr5[0] = "Total";
                //dr5[1] = TotalDramount + NP;
                //dr5[2] = "Total";
                //dr5[3] = TotalCramount + NL;
            }

            
            return obj_dt;
        }
        private void Loaddata()
        {

            grd_all.Visible=false;
            DataTable obj_dt = new DataTable();
            obj_dt = MakingPLData(Session["FADbname"].ToString(), Convert.ToDateTime(Utility.fn_ConvertDate(txt_From.Text.ToString())), Convert.ToDateTime(Utility.fn_ConvertDate(txt_To.Text.ToString())), Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()), chk_consolidate);
            Grd_Ledger.Visible = false;
            GridSubgroup.Visible = false;
            Grd_Ledger_new.Visible = false;

            if (obj_dt.Rows.Count > 0)
            {
                Session["chkgp"] = "false";

                grd_profit.Visible = true;
                obj_dt.Columns.Add(new DataColumn { ColumnName = "LEGroupType", DataType = typeof(string) });
                obj_dt.Columns.Add(new DataColumn { ColumnName = "LIGroupType", DataType = typeof(string) });
                obj_dt.Columns.Add(new DataColumn { ColumnName = "LELedgerid", DataType = typeof(int) });
                obj_dt.Columns.Add(new DataColumn { ColumnName = "LILedgerid", DataType = typeof(int) });
                grd_profit.DataSource = obj_dt;
                ViewState["grd_profit"] = obj_dt;
                grd_profit.DataBind();
                btn_cancel.ToolTip = "Cancel";
                btn_cancel.Text = "Cancel";
                btn_cancel1.Attributes["class"] = "btn ico-cancel";
            }
        }


        private void Loaddata1()
        {
            grd_all.Visible = true;
            grd_profit.Visible = false;
            DataTable obj_dt = new DataTable();
            obj_dt = MakingPLData1(Session["FADbname"].ToString(), Convert.ToDateTime(Utility.fn_ConvertDate(txt_From.Text.ToString())), Convert.ToDateTime(Utility.fn_ConvertDate(txt_To.Text.ToString())), Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()), chk_consolidate);
            Grd_Ledger.Visible = false; 
            Grd_Ledger_new.Visible = false;
            GridSubgroup.Visible = false;
            if (obj_dt.Rows.Count > 0)
            {
                ////grd_profit.Visible = true;
                ///

                Session["chkgp"] = "true";

                obj_dt.Columns.Add(new DataColumn { ColumnName = "LEGroupType", DataType = typeof(string) });
                obj_dt.Columns.Add(new DataColumn { ColumnName = "LIGroupType", DataType = typeof(string) });
                obj_dt.Columns.Add(new DataColumn { ColumnName = "LELedgerid", DataType = typeof(int) });
                obj_dt.Columns.Add(new DataColumn { ColumnName = "LILedgerid", DataType = typeof(int) });
                grd_all.DataSource = obj_dt;
                ViewState["grd_profit"] = obj_dt;
                grd_all.DataBind();

                if (grd_all.Rows.Count > 0)
                {
                    for (int i = 0; i < grd_all.Rows.Count - 1; i++)
                    {
                        grd_all.Rows[i].Cells[4].ForeColor = System.Drawing.Color.Red;
                    }
                    
                }


                btn_cancel.ToolTip = "Cancel";
                btn_cancel.Text = "Cancel";
                btn_cancel1.Attributes["class"] = "btn ico-cancel";
            }
        }

        protected void btn_ledger_Click(object sender, EventArgs e)
        {

            GridSubgroup.Visible = false;
            Grd_Ledger.Visible = false;
            Grd_Ledger_new.Visible = false;
            btn_cancel.ToolTip = "Cancel";
            btn_cancel.Text = "Cancel";
            btn_cancel1.Attributes["class"] = "btn ico-cancel";
           // DataAccess.FAMaster.ReportView obj_FAReportview = new DataAccess.FAMaster.ReportView();
            DataSet obj_ds = new DataSet();
            DataTable obj_dtDIE = new DataTable();
            DataTable obj_dtIIE = new DataTable();
            DataTable obj_dt = new DataTable();
            DataTable obj_dtI = new DataTable();
            DataTable obj_dt_E = new DataTable();
            DataTable obj_dt_I = new DataTable();
            double Credit, Debit, Diffamount, TotalCramount = 0, TotalDramount = 0, TotalGroup = 0, TotalSubGroup = 0, Grossprofit = 0, Grossloss = 0;
            int i;
            int expense_count;

            if (Session["StrTranType"].ToString() == "CO")
            {
                obj_ds = obj_FAReportview.SelProfitLossLedgerwise4AllBranch(Session["FADbname"].ToString(), Convert.ToInt32(Session["LoginDivisionId"].ToString()), Convert.ToDateTime(Utility.fn_ConvertDate(txt_From.Text.ToString())), Convert.ToDateTime(Utility.fn_ConvertDate(txt_To.Text.ToString())));
            }
            else
            {
                obj_ds = obj_FAReportview.SelProfitLossLedgerwise(Session["FADbname"].ToString(), Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToDateTime(Utility.fn_ConvertDate(txt_From.Text.ToString())), Convert.ToDateTime(Utility.fn_ConvertDate(txt_To.Text.ToString())));
            }

            obj_dt.Columns.Add(new DataColumn { ColumnName = "part1", DataType = typeof(string) });
            obj_dt.Columns.Add(new DataColumn { ColumnName = "amount1", DataType = typeof(double) });
            obj_dt.Columns.Add(new DataColumn { ColumnName = "part2", DataType = typeof(string) });
            obj_dt.Columns.Add(new DataColumn { ColumnName = "amount2", DataType = typeof(double) });
            obj_dt.Columns.Add(new DataColumn { ColumnName = "LEGroupType", DataType = typeof(string) });
            obj_dt.Columns.Add(new DataColumn { ColumnName = "LIGroupType", DataType = typeof(string) });
            obj_dt.Columns.Add(new DataColumn { ColumnName = "LELedgerid", DataType = typeof(int) });
            obj_dt.Columns.Add(new DataColumn { ColumnName = "LILedgerid", DataType = typeof(int) });

            if (obj_ds.Tables.Count > 0)
            {
                obj_dtDIE = obj_ds.Tables[0];
                obj_dtIIE = obj_ds.Tables[1];
                DataView obj_dataview = new DataView();

                //-----------------------Income----------------------------

                if (obj_dtDIE.Rows.Count > 0)
                {
                    obj_dataview = new DataView(obj_dtDIE);
                    obj_dataview.RowFilter = "grouptype='E'";
                    obj_dt_E = obj_dataview.ToTable();
                    obj_dataview.RowFilter = "grouptype='I'";
                    obj_dt_I = obj_dataview.ToTable();


                    // Region For Expense
                    var dist_groupname = obj_dt_E.AsEnumerable()
                   .Select(row_value => new
                   {
                       groupname = row_value.Field<string>("groupname"),
                   }).Distinct();
                    DataRow dr_E;

                    foreach (var var_row in dist_groupname)
                    {
                        dr_E = obj_dt.NewRow();
                        obj_dt.Rows.Add(dr_E);
                        dr_E[0] = var_row.groupname;
                        dr_E[4] = "G";
                        int index = obj_dt.Rows.Count;
                        TotalGroup = 0;
                        var dist_subgroupname = obj_dt_E.AsEnumerable()
                      .Where(row => row["groupname"].ToString() == var_row.groupname.ToString())
                       .Select(row_value => new
                       {
                           subgroupname = row_value.Field<string>("subgroupname"),
                       }).Distinct();

                        foreach (var var_rowvalue in dist_subgroupname)
                        {
                            var ledgername = obj_dt_E.AsEnumerable()
                         .Where(row => row["subgroupname"].ToString() == var_rowvalue.subgroupname.ToString())
                          .Select(row_value => new
                          {
                              Ledgername = row_value.Field<string>("Ledgername"),
                              Debit = row_value.Field<decimal>("Debit"),
                              Credit = row_value.Field<decimal>("Credit"),
                              OB_Debit = row_value.Field<decimal>("OB_Debit"),
                              OB_Credit = row_value.Field<decimal>("OB_Credit"),
                              Ledgerid = row_value.Field<int>("Ledgerid")
                          });
                            dr_E = obj_dt.NewRow();
                            obj_dt.Rows.Add(dr_E);
                            dr_E[0] = var_rowvalue.subgroupname;
                            dr_E[4] = "S";
                            int count = obj_dt.Rows.Count;
                            TotalSubGroup = 0;
                            foreach (var var_ledger in ledgername)
                            {
                                Credit = 0;
                                Debit = 0;
                                Diffamount = 0;
                                Debit = double.Parse(var_ledger.Debit.ToString()) + double.Parse(var_ledger.OB_Debit.ToString());
                                Credit = double.Parse(var_ledger.Credit.ToString()) + double.Parse(var_ledger.OB_Credit.ToString());
                                dr_E = obj_dt.NewRow();
                                obj_dt.Rows.Add(dr_E);
                                dr_E[0] = var_ledger.Ledgername.ToString();
                                dr_E[4] = "L";
                                dr_E[6] = var_ledger.Ledgerid.ToString();
                                if (Debit >= Credit)
                                {
                                    Diffamount = Debit - Credit;
                                    dr_E[1] = Diffamount;
                                    TotalSubGroup = TotalSubGroup + Diffamount;

                                }
                                else if (Credit > Debit)
                                {
                                    Diffamount = Credit - Debit;
                                    Diffamount = -Diffamount;
                                    dr_E[1] = Diffamount;
                                    TotalSubGroup = TotalSubGroup + Diffamount;

                                }
                                TotalDramount = TotalDramount + Diffamount;
                            }

                            obj_dt.Rows[count - 1][1] = TotalSubGroup;
                            TotalGroup = TotalGroup + TotalSubGroup;
                        }

                        obj_dt.Rows[index - 1][1] = TotalGroup;
                    }

                    //End of Region Expense
                    //Region foe Income

                    obj_dtI.Columns.Add(new DataColumn { ColumnName = "part2", DataType = typeof(string) });
                    obj_dtI.Columns.Add(new DataColumn { ColumnName = "amount2", DataType = typeof(double) });
                    obj_dtI.Columns.Add(new DataColumn { ColumnName = "LIGroupType", DataType = typeof(string) });
                    obj_dtI.Columns.Add(new DataColumn { ColumnName = "LILedgerid", DataType = typeof(int) });
                    dist_groupname = obj_dt_I.AsEnumerable()
                   .Select(row_value => new
                   {
                       groupname = row_value.Field<string>("groupname"),
                   }).Distinct();
                    DataRow dr_I;
                    int count1 = 0;
                    foreach (var var_row in dist_groupname)
                    {
                        dr_I = obj_dtI.NewRow();
                        obj_dtI.Rows.Add(dr_I);
                        dr_I[0] = var_row.groupname;
                        dr_I[2] = "G";
                        int index = obj_dtI.Rows.Count;
                        TotalGroup = 0;
                        var dist_subgroupname = obj_dt_I.AsEnumerable()
                      .Where(row => row["groupname"].ToString() == var_row.groupname.ToString())
                       .Select(row_value => new
                       {
                           subgroupname = row_value.Field<string>("subgroupname"),
                       }).Distinct();

                        foreach (var var_rowvalue in dist_subgroupname)
                        {
                            var ledgername = obj_dt_I.AsEnumerable()
                         .Where(row => row["subgroupname"].ToString() == var_rowvalue.subgroupname.ToString())
                          .Select(row_value => new
                          {
                              Ledgername = row_value.Field<string>("Ledgername"),
                              Debit = row_value.Field<decimal>("Debit"),
                              Credit = row_value.Field<decimal>("Credit"),
                              OB_Debit = row_value.Field<decimal>("OB_Debit"),
                              OB_Credit = row_value.Field<decimal>("OB_Credit"),
                              Ledgerid = row_value.Field<int>("Ledgerid")
                          });
                            dr_I = obj_dtI.NewRow();
                            obj_dtI.Rows.Add(dr_I);
                            dr_I[0] = var_rowvalue.subgroupname;
                            dr_I[2] = "S";
                            int count = obj_dtI.Rows.Count;
                            TotalSubGroup = 0;
                            foreach (var var_ledger in ledgername)
                            {
                                Credit = 0;
                                Debit = 0;
                                Diffamount = 0;
                                Debit = double.Parse(var_ledger.Debit.ToString()) + double.Parse(var_ledger.OB_Debit.ToString());
                                Credit = double.Parse(var_ledger.Credit.ToString()) + double.Parse(var_ledger.OB_Credit.ToString());
                                dr_I = obj_dtI.NewRow();
                                obj_dtI.Rows.Add(dr_I);
                                dr_I[0] = var_ledger.Ledgername.ToString();
                                dr_I[2] = "L";
                                dr_I[3] = var_ledger.Ledgerid.ToString();
                                if (Debit > Credit)
                                {
                                    Diffamount = Debit - Credit;
                                    Diffamount = -Diffamount;
                                    dr_I[1] = Diffamount;
                                    TotalSubGroup = TotalSubGroup + Diffamount;

                                }
                                else if (Credit >= Debit)
                                {
                                    Diffamount = Credit - Debit;
                                    dr_I[1] = Diffamount;
                                    TotalSubGroup = TotalSubGroup + Diffamount;
                                }

                                TotalCramount = TotalCramount + Diffamount;
                            }

                            obj_dtI.Rows[count - 1][1] = TotalSubGroup;
                            TotalGroup = TotalGroup + TotalSubGroup;
                            count1 += 1;
                        }
                        obj_dtI.Rows[index - 1][1] = TotalGroup;

                    }

                    //End of Region Income
                }
                if (obj_dt_E.Rows.Count < obj_dt_I.Rows.Count)
                {
                    for (int k = obj_dt_E.Rows.Count; k < obj_dt_I.Rows.Count; k++)
                    {
                        DataRow dr_empty;
                        dr_empty = obj_dt.NewRow();
                        obj_dt.Rows.Add(dr_empty);
                    }
                }
                for (i = 0; i <= obj_dt.Rows.Count - 1; i++)
                {
                    if (i < obj_dtI.Rows.Count)
                    {
                        obj_dt.Rows[i][2] = obj_dtI.Rows[i][0].ToString();
                        obj_dt.Rows[i][3] = obj_dtI.Rows[i][1].ToString();
                        obj_dt.Rows[i][5] = obj_dtI.Rows[i][2].ToString();
                        obj_dt.Rows[i][7] = obj_dtI.Rows[i][3];
                    }
                }



                for (i = 0; i <= 3; i++)
                {
                    DataRow dr_empty;
                    dr_empty = obj_dt.NewRow();
                    obj_dt.Rows.Add(dr_empty);
                }

                double GP = 0, GL = 0;
                DataRow dr_total;
                dr_total = obj_dt.NewRow();
                obj_dt.Rows.Add(dr_total);

                if (TotalDramount > TotalCramount)
                {
                    GL = TotalDramount - TotalCramount;
                    dr_total[2] = "Gross Loss";
                    dr_total[3] = GL;
                    Grossprofit = 0;
                    Grossloss = GL;
                    hid_Gl.Value = GL.ToString();
                }
                else if (TotalCramount > TotalDramount)
                {
                    GP = TotalCramount - TotalDramount;
                    dr_total[0] = "Gross Profit";
                    dr_total[1] = GP;
                    Grossprofit = GP;
                    Grossloss = 0;
                    hid_Gp.Value = GP.ToString();
                }

                dr_total = obj_dt.NewRow();
                obj_dt.Rows.Add(dr_total);
                dr_total[0] = "Total";
                dr_total[1] = TotalDramount + GP;
                dr_total[2] = "Total";
                dr_total[3] = TotalCramount + GL;

                dr_total = obj_dt.NewRow();
                obj_dt.Rows.Add(dr_total);
                expense_count = obj_dt.Rows.Count;
                if (TotalDramount > TotalCramount)
                {
                    GL = TotalDramount - TotalCramount;
                    dr_total[0] = "Gross Loss";
                    dr_total[1] = GL;
                    Grossprofit = 0;
                    Grossloss = GL;
                    hid_Gp.Value = GL.ToString();
                }
                else if (TotalCramount > TotalDramount)
                {
                    GP = TotalCramount - TotalDramount;
                    dr_total[2] = "Gross Profit";
                    dr_total[3] = GP;
                    Grossprofit = GP;
                    Grossloss = 0;
                    hid_Gl.Value = GP.ToString();
                }

                TotalDramount = 0;
                TotalCramount = 0;

                //-------------Expense----------------

                if (obj_dtIIE.Rows.Count > 0)
                {
                    obj_dtI = new DataTable();
                    obj_dtI.Columns.Add(new DataColumn { ColumnName = "part2", DataType = typeof(string) });
                    obj_dtI.Columns.Add(new DataColumn { ColumnName = "amount2", DataType = typeof(double) });
                    obj_dtI.Columns.Add(new DataColumn { ColumnName = "LIGroupType", DataType = typeof(string) });
                    obj_dtI.Columns.Add(new DataColumn { ColumnName = "LILedgerid", DataType = typeof(int) });
                    obj_dataview = new DataView(obj_dtIIE);
                    obj_dataview.RowFilter = "grouptype='E'";
                    obj_dt_E = obj_dataview.ToTable();
                    obj_dataview.RowFilter = "grouptype='I'";
                    obj_dt_I = obj_dataview.ToTable();
                    if (obj_dt_E.Rows.Count > obj_dt_I.Rows.Count)
                    {

                    }

                    // Region For Expense
                    var dist_groupname = obj_dt_E.AsEnumerable()
                   .Select(row_value => new
                   {
                       groupname = row_value.Field<string>("groupname"),
                   }).Distinct();
                    DataRow dr_E;
                    foreach (var var_row in dist_groupname)
                    {
                        dr_E = obj_dt.NewRow();
                        obj_dt.Rows.Add(dr_E);
                        dr_E[0] = var_row.groupname;
                        dr_E[4] = "G";
                        int index = obj_dt.Rows.Count;
                        TotalGroup = 0;
                        var dist_subgroupname = obj_dt_E.AsEnumerable()
                      .Where(row => row["groupname"].ToString() == var_row.groupname.ToString())
                       .Select(row_value => new
                       {
                           subgroupname = row_value.Field<string>("subgroupname"),
                       }).Distinct();

                        foreach (var var_rowvalue in dist_subgroupname)
                        {
                            var ledgername = obj_dt_E.AsEnumerable()
                         .Where(row => row["subgroupname"].ToString() == var_rowvalue.subgroupname.ToString())
                          .Select(row_value => new
                          {
                              Ledgername = row_value.Field<string>("Ledgername"),
                              Debit = row_value.Field<decimal>("Debit"),
                              Credit = row_value.Field<decimal>("Credit"),
                              OB_Debit = row_value.Field<decimal>("OB_Debit"),
                              OB_Credit = row_value.Field<decimal>("OB_Credit"),
                              Ledgerid = row_value.Field<int>("Ledgerid")
                          });
                            dr_E = obj_dt.NewRow();
                            obj_dt.Rows.Add(dr_E);
                            dr_E[0] = var_rowvalue.subgroupname;
                            dr_E[4] = "S";
                            int count = obj_dt.Rows.Count;
                            TotalSubGroup = 0;
                            foreach (var var_ledger in ledgername)
                            {
                                Credit = 0;
                                Debit = 0;
                                Diffamount = 0;
                                Debit = double.Parse(var_ledger.Debit.ToString()) + double.Parse(var_ledger.OB_Debit.ToString());
                                Credit = double.Parse(var_ledger.Credit.ToString()) + double.Parse(var_ledger.OB_Credit.ToString());
                                dr_E = obj_dt.NewRow();

                                obj_dt.Rows.Add(dr_E);
                                dr_E[0] = var_ledger.Ledgername.ToString();
                                dr_E[4] = "L";
                                dr_E[6] = var_ledger.Ledgerid.ToString();
                                if (Debit >= Credit)
                                {
                                    Diffamount = Debit - Credit;
                                    dr_E[1] = Diffamount;
                                    TotalSubGroup = TotalSubGroup + Diffamount;

                                }
                                else if (Credit > Debit)
                                {
                                    Diffamount = Credit - Debit;
                                    Diffamount = -Diffamount;
                                    dr_E[1] = Diffamount;
                                    TotalSubGroup = TotalSubGroup + Diffamount;
                                }

                                TotalDramount = TotalDramount + Diffamount;
                            }
                            obj_dt.Rows[count - 1][1] = TotalSubGroup;
                            TotalGroup = TotalGroup + TotalSubGroup;
                        }

                        obj_dt.Rows[index - 1][1] = TotalGroup;

                    }

                    //End of Region Expense


                    //Region for Income


                    //obj_dtI.Columns.Add(new DataColumn { ColumnName = "part2", DataType = typeof(string) });
                    //obj_dtI.Columns.Add(new DataColumn { ColumnName = "amount2", DataType = typeof(double) });
                    dist_groupname = obj_dt_I.AsEnumerable()
                   .Select(row_value => new
                   {
                       groupname = row_value.Field<string>("groupname"),
                   }).Distinct();
                    DataRow dr_I;
                    foreach (var var_row in dist_groupname)
                    {
                        dr_I = obj_dtI.NewRow();
                        obj_dtI.Rows.Add(dr_I);
                        dr_I[0] = var_row.groupname;
                        dr_I[2] = "G";
                        int index = obj_dtI.Rows.Count;
                        TotalGroup = 0;
                        var dist_subgroupname = obj_dt_I.AsEnumerable()
                      .Where(row => row["groupname"].ToString() == var_row.groupname.ToString())
                       .Select(row_value => new
                       {
                           subgroupname = row_value.Field<string>("subgroupname"),
                       }).Distinct();

                        foreach (var var_rowvalue in dist_subgroupname)
                        {
                            var ledgername = obj_dt_I.AsEnumerable()
                         .Where(row => row["subgroupname"].ToString() == var_rowvalue.subgroupname.ToString())
                          .Select(row_value => new
                          {
                              Ledgername = row_value.Field<string>("Ledgername"),
                              Debit = row_value.Field<decimal>("Debit"),
                              Credit = row_value.Field<decimal>("Credit"),
                              OB_Debit = row_value.Field<decimal>("OB_Debit"),
                              OB_Credit = row_value.Field<decimal>("OB_Credit"),
                              Ledgerid = row_value.Field<int>("Ledgerid")
                          });
                            dr_I = obj_dtI.NewRow();
                            obj_dtI.Rows.Add(dr_I);
                            dr_I[0] = var_rowvalue.subgroupname;
                            dr_I[2] = "S";
                            int count = obj_dtI.Rows.Count;
                            TotalSubGroup = 0;
                            foreach (var var_ledger in ledgername)
                            {
                                Credit = 0;
                                Debit = 0;
                                Diffamount = 0;
                                Debit = double.Parse(var_ledger.Debit.ToString()) + double.Parse(var_ledger.OB_Debit.ToString());
                                Credit = double.Parse(var_ledger.Credit.ToString()) + double.Parse(var_ledger.OB_Credit.ToString());
                                dr_I = obj_dtI.NewRow();
                                obj_dtI.Rows.Add(dr_I);
                                dr_I[0] = var_ledger.Ledgername.ToString();
                                dr_I[2] = "L";
                                dr_I[3] = var_ledger.Ledgerid.ToString();
                                if (Debit > Credit)
                                {
                                    Diffamount = Debit - Credit;
                                    Diffamount = -Diffamount;
                                    dr_I[1] = Diffamount;
                                    TotalSubGroup = TotalSubGroup + Diffamount;

                                }
                                else if (Credit >= Debit)
                                {
                                    Diffamount = Credit - Debit;
                                    dr_I[1] = Diffamount;
                                    TotalSubGroup = TotalSubGroup + Diffamount;

                                }


                                TotalCramount = TotalCramount + Diffamount;
                            }
                            obj_dtI.Rows[count - 1][1] = TotalSubGroup;
                            TotalGroup = TotalGroup + TotalSubGroup;

                        }
                        obj_dtI.Rows[index - 1][1] = TotalGroup;
                    }
                    //End of Region Income
                }

                //if (obj_dt_E.Rows.Count < obj_dt_I.Rows.Count)
                //{
                //    for (int k = obj_dt_E.Rows.Count; k < obj_dt_I.Rows.Count; k++)
                //    {
                //        DataRow dr_empty;
                //        dr_empty = obj_dt.NewRow();
                //        obj_dt.Rows.Add(dr_empty);
                //    }
                //}

                for (i = 0; i < obj_dtI.Rows.Count - 1; i++)
                {
                    if (i < obj_dtI.Rows.Count)
                    {
                        obj_dt.Rows[expense_count][2] = obj_dtI.Rows[i][0].ToString();
                        obj_dt.Rows[expense_count][3] = obj_dtI.Rows[i][1].ToString();
                        obj_dt.Rows[expense_count][5] = obj_dtI.Rows[i][2].ToString();
                        obj_dt.Rows[expense_count][7] = obj_dtI.Rows[i][3];
                    }
                    expense_count += 1;
                }



                for (i = 0; i <= 1; i++)
                {
                    DataRow dr_empty;
                    dr_empty = obj_dt.NewRow();
                    obj_dt.Rows.Add(dr_empty);
                }

                TotalCramount = TotalCramount + Grossprofit;
                TotalDramount = TotalDramount + Grossloss;
                double NP = 0, NL = 0;
                DataRow dr_Nettotal;
                dr_Nettotal = obj_dt.NewRow();
                obj_dt.Rows.Add(dr_Nettotal);
                if (TotalDramount > TotalCramount)
                {
                    NL = TotalDramount - TotalCramount;
                    dr_Nettotal[2] = "Net Loss";
                    dr_Nettotal[3] = NL;
                }
                else if (TotalCramount > TotalDramount)
                {
                    NP = TotalCramount - TotalDramount;
                    dr_Nettotal[0] = "Net Profit";
                    dr_Nettotal[1] = NP;
                }

                dr_Nettotal = obj_dt.NewRow();
                obj_dt.Rows.Add(dr_Nettotal);
                dr_Nettotal[0] = "Total";
                dr_Nettotal[1] = TotalDramount + NP;
                dr_Nettotal[2] = "Total";
                dr_Nettotal[3] = TotalCramount + NL;

                grd_profit.Visible = true;
                grd_profit.DataSource = obj_dt;
                ViewState["grd_profit"] = obj_dt;
                grd_profit.DataBind();
            }
        }

        protected void btn_Export_Click(object sender, EventArgs e)
        {
            if (grd_profit.Visible == true)
            {
                string strtemp = "";
                strtemp = Utility.Fn_ExportExcel(grd_profit, "<tr><td></td><td><FONT FACE=arial SIZE=2>  </td></tr><tr><td></td><td></td><td><FONT FACE=arial SIZE=2>" + Session["LoginDivisionName"].ToString() + " - " + Session["LoginBranchName"].ToString() + "</td></tr>");
                Response.Clear();
                Response.AddHeader("Content-Disposition", "Attachment;Filename=Profit&Loss.xls");
                Response.Buffer = true;
                Response.Charset = "UTF-8";
                Response.ContentType = "application/vnd.ms-excel";
                Response.Write(strtemp);
                Response.End();
            }
            else if (Grd_Ledger.Visible == true)
            {
                string strtemp = "";
                strtemp = Utility.Fn_ExportExcel(Grd_Ledger, "<tr><td></td><td><FONT FACE=arial SIZE=2>  </td></tr><tr><td></td><td></td><td><FONT FACE=arial SIZE=2>" + Session["LoginDivisionName"].ToString() + " - " + Session["LoginBranchName"].ToString() + "</td></tr>");
                Response.Clear();
                Response.AddHeader("Content-Disposition", "Attachment;Filename=Profit&Loss.xls");
                Response.Buffer = true;
                Response.Charset = "UTF-8";
                Response.ContentType = "application/vnd.ms-excel";
                Response.Write(strtemp);
                Response.End();
            }
            else if (GridSubgroup.Visible == true)
            {
                string strtemp = "";
                strtemp = Utility.Fn_ExportExcel(GridSubgroup, "<tr><td></td><td><FONT FACE=arial SIZE=2>  </td></tr><tr><td></td><td></td><td><FONT FACE=arial SIZE=2>" + Session["LoginDivisionName"].ToString() + " - " + Session["LoginBranchName"].ToString() + "</td></tr>");
                Response.Clear();
                Response.AddHeader("Content-Disposition", "Attachment;Filename=Profit&Loss.xls");
                Response.Buffer = true;
                Response.Charset = "UTF-8";
                Response.ContentType = "application/vnd.ms-excel";
                Response.Write(strtemp);
                Response.End();
            }
            else
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), "alertify.alert('Excel Not Found')", true);
            }
        }

        protected void btn_cancel_Click(object sender, EventArgs e)
        {
            if (Grd_Ledger_new.Visible == true && GridSubgroup.Visible == false && grd_all.Visible == false && grd_profit.Visible == false && Session["chkgp"].ToString() == "true")
            {
                Grd_Ledger_new.Visible = false;
                GridSubgroup.Visible = false;
                grd_all.Visible = true;
                grd_all.DataSource = ViewState["grd_profit"] as DataTable;
                grd_all.DataBind();
                btn_cancel.Text = "Cancel";
                btn_cancel.ToolTip = "Cancel";
                btn_cancel1.Attributes["class"] = "btn ico-cancel";
               
            }
            else if (Grd_Ledger.Visible == true && GridSubgroup.Visible == false )
            {
                Grd_Ledger.Visible = false;
                GridSubgroup.Visible = true;
                GridSubgroup.DataSource = ViewState["GridSubgroup"] as DataTable;
                GridSubgroup.DataBind();
                btn_cancel.Text = "Cancel";
                btn_cancel.ToolTip = "Cancel";
                btn_cancel1.Attributes["class"] = "btn ico-cancel";
            }
            else if (GridSubgroup.Visible == true && grd_profit.Visible == false && grd_all.Visible == false && Session["chkgp"].ToString() == "false")
            {
                GridSubgroup.Visible = false;
                grd_profit.Visible = true;
                grd_profit.DataSource = ViewState["grd_profit"] as DataTable;
                grd_profit.DataBind();
                btn_cancel.Text = "Cancel";
                btn_cancel.ToolTip = "Cancel";
                btn_cancel1.Attributes["class"] = "btn ico-cancel";
            }
            else if (GridSubgroup.Visible == true && grd_all.Visible == false && Session["chkgp"].ToString() == "false")
            {
                grd_all.Visible = false;
                grd_all.Visible = true;
                grd_all.DataSource = ViewState["grd_profit"] as DataTable;
                grd_all.DataBind();
                btn_cancel.Text = "Cancel";
                btn_cancel.ToolTip = "Cancel";
                btn_cancel1.Attributes["class"] = "btn ico-cancel";
            }
            else

                if (btn_cancel.ToolTip == "Cancel")
                {
                    Session["chkgp"] = "false";

                    int Vouyear = Convert.ToInt32(Session["LogYear"].ToString());
                    //Str_CurrrentDate = logobj.GetDate().ToShortDateString();
                    int stryear = Convert.ToInt32(DateTime.Now.Year.ToString());
                    int vouyeartext = Convert.ToInt32(Session["Vouyear"].ToString());
                    string Str_CurrrentDate = Utility.fn_ConvertDate(logobj.GetDate().ToShortDateString());
                    if (Session["countryid"].ToString() == "1102" || Session["countryid"].ToString() == "102")
                    {
                        if ((Vouyear == (DateTime.Now).Year - 1 && (DateTime.Now).Month <= 3) || Vouyear == (DateTime.Now).Year)
                        {
                            txt_From.Text = "01/04/" + vouyeartext;
                            txt_To.Text = Str_CurrrentDate.ToString();//Utility.fn_ConvertDate(Str_CurrrentDate.ToString());

                        }
                        else
                        {
                            txt_From.Text = "01/04/" + vouyeartext;
                            txt_To.Text = "31/03/" + (vouyeartext + 1);
                        }
                    }
                    else
                    {
                        if (stryear == vouyeartext)
                        {
                            txt_From.Text = "01/01/" + vouyeartext;
                            txt_To.Text = Str_CurrrentDate.ToString();

                        }
                        else
                        {
                            txt_From.Text = "01/01/" + vouyeartext;
                            txt_To.Text = "31/12/" + (vouyeartext + 1);
                        }
                    }
                    if (grd_profit.Visible == true)
                    {
                        grd_profit.DataSource = new DataTable();
                        grd_profit.DataBind();
                        
                        chk_consolidate.Checked = false;
                        btn_cancel.ToolTip = "Back";
                        btn_cancel1.Attributes["class"] = "btn ico-back";
                    }
                    else if (Grd_Ledger.Visible == true)
                    {
                        Grd_Ledger.DataSource = new DataTable();
                        Grd_Ledger.DataBind();
                        //txt_From.Text = "01/01/" + Vouyear;
                        //txt_To.Text = Str_CurrrentDate.ToString();
                        chk_consolidate.Checked = false;
                        btn_cancel.Text = "Back";
                        btn_cancel.ToolTip = "Back";
                        btn_cancel1.Attributes["class"] = "btn ico-back";
                    }

                    if (grd_profit.Rows.Count == 0 & GridSubgroup.Rows.Count == 0 & Grd_Ledger.Rows.Count == 0)
                    {
                        //txt_From.Text = "01/01/" + Vouyear;
                        //txt_To.Text = Str_CurrrentDate.ToString();
                        chk_consolidate.Checked = false;
                        btn_cancel.ToolTip = "Back";
                        btn_cancel.Text = "Back";
                        btn_cancel1.Attributes["class"] = "btn ico-back";
                    }
                }
                else
                {
                    // this.Response.End();

                    if (Session["StrTranType"] != null)
                    {
                        if (Session["StrTranType"].ToString() == "CO")
                        {
                            Response.Redirect("../Home/CorporateHome.aspx");
                        }
                        else if (Session["StrTranType"].ToString() == "BR")
                        {
                            Response.Redirect("../Home/Branch_home.aspx");

                        }
                        else if (Session["StrTranType"].ToString() == "AC")
                        {
                            Response.Redirect("../Home/Branch_home.aspx");
                        }
                        else if (Session["home"] != null)
                        {
                            if (Session["home"].ToString() == "FABR")
                            {
                                Response.Redirect("../Home/Branch_home.aspx");
                            }
                            else if (Session["home"].ToString() == "FAFC")
                            {
                                Response.Redirect("../Home/CorporateHome.aspx");
                            }
                        }

                    }
                    else if (Session["home"] != null)
                    {
                        if (Session["home"].ToString() == "FABR")
                        {
                            Response.Redirect("../Home/Branch_home.aspx");
                        }
                        else if (Session["home"].ToString() == "FAFC")
                        {
                            Response.Redirect("../Home/CorporateHome.aspx");
                        }
                    }
                    else
                    {
                        this.Response.End();
                    }
                }
        }

        protected void btn_branch_Click(object sender, EventArgs e)
        {
            bool CheckedValue = false;
            GridSubgroup.Visible = false;
            grd_profit.Visible = false;
            Grd_Ledger.Visible = false;
            Grd_Ledger_new.Visible = false;

            if (chk_consolidate.Checked == true)
            {
                CheckedValue = true;
            }

             iframecost.Attributes["src"] = "ProfitLoss4allbranch.aspx?dtfrom=" + txt_From.Text + "&dtto=" + txt_To.Text + "&CheckedValue=" + CheckedValue + "";
            ModalPopupExtender1.Show();

        }

        public override void VerifyRenderingInServerForm(Control control)
        {
            //required to avoid the run time error "  
            //Control 'GridView1' of type 'Grid View' must be placed inside a form tag with runat=server."  
        }

        protected void grd_profit_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //----- For ColumnIndex never use SelectedIndexChanged event, use RowCommand Only

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                LinkButton _singleClickButton = (LinkButton)e.Row.Cells[4].Controls[0];
                string _jsSingle = ClientScript.GetPostBackClientHyperlink(_singleClickButton, "");
                // Add events to each editable cell
                for (int columnIndex = 0; columnIndex < e.Row.Cells.Count; columnIndex++)
                {
                    // Add the column index as the event argument parameter
                    string js = _jsSingle.Insert(_jsSingle.Length - 2, columnIndex.ToString());
                    // Add this javascript to the onclick Attribute of the cell
                    e.Row.Cells[columnIndex].Attributes["onclick"] = js;
                    // Add a cursor style to the cells
                    e.Row.Cells[columnIndex].Attributes["style"] += "cursor:pointer;cursor:hand;";
                }

                for (int i = 0; i < e.Row.Cells.Count; i++)
                {
                    if (e.Row.Cells[i].Text == "&nbsp;")
                    {
                        e.Row.Cells[i].Text = "";
                    }
                    if (grd_profit.DataKeys[e.Row.RowIndex].Values[0].ToString() == "G")
                    {
                        e.Row.Cells[0].ForeColor = System.Drawing.Color.DarkBlue;
                        e.Row.Cells[1].ForeColor = System.Drawing.Color.DarkBlue;
                        e.Row.Cells[0].Font.Bold = true;
                        e.Row.Cells[1].Font.Bold = true;
                    }
                    if (grd_profit.DataKeys[e.Row.RowIndex].Values[0].ToString() == "S")
                    {
                        e.Row.Cells[0].ForeColor = System.Drawing.Color.Maroon;
                        e.Row.Cells[1].ForeColor = System.Drawing.Color.Maroon;
                    }

                    if (grd_profit.DataKeys[e.Row.RowIndex].Values[1].ToString() == "G")
                    {
                        e.Row.Cells[2].ForeColor = System.Drawing.Color.DarkBlue;
                        e.Row.Cells[3].ForeColor = System.Drawing.Color.DarkBlue;
                        e.Row.Cells[2].Font.Bold = true;
                        e.Row.Cells[3].Font.Bold = true;
                    }
                    if (grd_profit.DataKeys[e.Row.RowIndex].Values[1].ToString() == "S")
                    {
                        e.Row.Cells[2].ForeColor = System.Drawing.Color.Maroon;
                        e.Row.Cells[3].ForeColor = System.Drawing.Color.Maroon;
                    }
                    e.Row.Cells[i].ToolTip = e.Row.Cells[i].Text;
                }

                for (int h = 0; h < e.Row.Cells.Count; h++)
                {
                    double dbl_temp = 0;

                    if (double.TryParse(e.Row.Cells[h].Text.ToString(), out dbl_temp))
                    {
                        e.Row.Cells[h].Text = string.Format("{0:#,##0.00}", dbl_temp);
                        e.Row.Cells[h].Attributes.CssStyle["text-align"] = "Right";
                    }
                }
            }
        }

        protected void btn_view_Click(object sender, EventArgs e)
        {
            string Str_RptName = "", Str_SF = "", Str_SP = "", Str_Script = "";
            string rptpartinc = "", rptpartexp = "";
            double rptincamnt = 0.00, rptexpamnt = 0.00;
            DateTime fromdate, todate;

            fromdate = Convert.ToDateTime(Utility.fn_ConvertDate(txt_From.Text.ToString()));
            todate = Convert.ToDateTime(Utility.fn_ConvertDate(txt_To.Text.ToString()));
            //DataAccess.LogDetails Obj_LogDet = new DataAccess.LogDetails();

            if (fromdate > todate)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Button), "alert", "alertify.alert('From Date Should be Less than To Date');", true);
                txt_From.Focus();
                return;
            }

            FAObj.DelPLReports(Convert.ToInt32(Session["LoginEmpId"]), Session["FADbname"].ToString());

            for (int i = 0; i <= grd_profit.Rows.Count - 1; i++)
            {
                if (grd_profit.Rows[i].Cells[0].Text != "" || grd_profit.Rows[i].Cells[1].Text != "" || grd_profit.Rows[i].Cells[2].Text != "" || grd_profit.Rows[i].Cells[3].Text != "")
                {
                    if (grd_profit.Rows[i].Cells[0].Text == "")
                    {
                        rptpartinc = "noparti";
                    }
                    else
                    {
                        rptpartinc = grd_profit.Rows[i].Cells[0].Text;
                    }

                    if (grd_profit.Rows[i].Cells[1].Text == "")
                    {
                        rptincamnt = 0;
                    }
                    else
                    {
                        rptincamnt = Convert.ToDouble(grd_profit.Rows[i].Cells[1].Text);
                    }

                    if (grd_profit.Rows[i].Cells[2].Text == "")
                    {
                        rptpartexp = "noparti";
                    }
                    else
                    {
                        rptpartexp = grd_profit.Rows[i].Cells[2].Text;
                    }

                    if (grd_profit.Rows[i].Cells[3].Text == "")
                    {
                        rptexpamnt = 0;
                    }
                    else
                    {
                        rptexpamnt = Convert.ToDouble(grd_profit.Rows[i].Cells[3].Text);
                    }
                }

                string EGroupType = "", IGrouptype = "";
                EGroupType = "L";
                IGrouptype = "L";
                FAObj.GetInsPLReports(Convert.ToInt32(Session["LoginEmpId"].ToString()), rptpartinc, rptincamnt, rptpartexp, rptexpamnt, Session["FADbname"].ToString(), Convert.ToInt32(Session["LoginBranchid"].ToString()), EGroupType, IGrouptype, i);
            }

            Str_RptName = "rptFAPl.rpt";
            Session["str_sfs"] = "{temppl.empid}=" + Session["LoginEmpId"].ToString();
            Session["str_sp"] = "Title=Profit And Loss ~fdate=" + fromdate + "~tdate=" + todate;

            Str_Script = "window.open('../Tools/ReportViewFA.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
            ScriptManager.RegisterStartupScript(btn_view, typeof(Button), "JobInfo", Str_Script, true);

            if (Session["str_ModuleName"].ToString() == "FA")
            {
                Obj_LogDet.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"].ToString()), 1117, 3, Convert.ToInt32(Session["LoginBranchid"].ToString()), "BalanceSheet" + txt_From.Text + "~" + txt_To.Text + "/FA/V");
            }
            else
            {
                Obj_LogDet.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"].ToString()), 1206, 3, Convert.ToInt32(Session["LoginBranchid"].ToString()), "BalanceSheet" + txt_From.Text + "~" + txt_To.Text + "/FC/V");
            }
        }

        protected void GP_Profit(int Row_Index)
        {
            //DataAccess.FAMaster.ReportView Obj_Report = new DataAccess.FAMaster.ReportView();
            DataTable dt_Profit = new DataTable();
            int Vouyear = Convert.ToInt32(Session["LogYear"].ToString());
            string Str_CurrrentDate = DateTime.Now.ToString("dd/MM/yyyy");
            DateTime Date = FAObj.MaxVouGetDate(Session["FADbname"].ToString());

            //txt_From.Text = "01/04/" + Vouyear;
            //txt_To.Text = Utility.fn_ConvertDate(Date.ToString());

            if (ViewState["Row_Index"] != null)
            {
                Row_Index = Convert.ToInt32(ViewState["Row_Index"].ToString());
            }

            if (ViewState["Col_index"] != null)
            {
                ColumnIndex = Convert.ToInt32(ViewState["Col_index"].ToString());
            }

            if (grd_profit.Rows.Count > 0)
            {

                if (ColumnIndex == 2)
                {


                    if (grd_profit.Rows[Row_Index].Cells[2].Text != "")
                    {
                        GroupName = grd_profit.Rows[Row_Index].Cells[2].Text;
                        GroupID = Obj_Report.FASelGroupid(GroupName, Session["FADbname"].ToString());
                        if (GroupID != 0)
                        {
                            if (chk_consolidate.Checked == true)
                            {
                                dt_Profit = Obj_Report.GetSubGroupSummary4AllBranch(Session["FADbname"].ToString(), Convert.ToDateTime(Utility.fn_ConvertDate(txt_From.Text)), Convert.ToDateTime(Utility.fn_ConvertDate(txt_To.Text)), GroupID, Convert.ToInt32(Session["LoginDivisionId"].ToString()));
                            }
                            else
                            {
                                if (Session["StrTranType"].ToString() == "CO")
                                {

                                    dt_Profit = Obj_Report.GetSubGroupSummary(Session["FADbname"].ToString(), Convert.ToDateTime(Utility.fn_ConvertDate(txt_From.Text)), Convert.ToDateTime(Utility.fn_ConvertDate(txt_To.Text)), Convert.ToInt32(Session["LoginBranchid"].ToString()), GroupID);
                                }
                                else
                                {
                                    dt_Profit = Obj_Report.GetSubGroupSummary(Session["FADbname"].ToString(), Convert.ToDateTime(Utility.fn_ConvertDate(txt_From.Text)), Convert.ToDateTime(Utility.fn_ConvertDate(txt_To.Text)), Convert.ToInt32(Session["LoginBranchid"].ToString()), GroupID);
                                }
                            }
                            if (dt_Profit.Rows.Count > 0)
                            {
                                GridSubgroup.Visible = true;
                                GridSubgroup.DataSource = dt_Profit;
                                ViewState["GridSubgroup"] = dt_Profit;
                                GridSubgroup.DataBind();
                                grd_profit.Visible = false;
                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), "alertify.alert('No Entry Exists')", true);
                            }
                        }
                    }
                }
                else
                {
                    if (grd_profit.Rows[Row_Index].Cells[0].Text != "")
                    {
                        GroupName = grd_profit.Rows[Row_Index].Cells[0].Text;
                        GroupID = Obj_Report.FASelGroupid(GroupName, Session["FADbname"].ToString());
                        if (GroupID != 0)
                        {
                            if (chk_consolidate.Checked == true)
                            {
                                dt_Profit = Obj_Report.GetSubGroupSummary4AllBranch(Session["FADbname"].ToString(), Convert.ToDateTime(Utility.fn_ConvertDate(txt_From.Text)), Convert.ToDateTime(Utility.fn_ConvertDate(txt_To.Text)), GroupID, Convert.ToInt32(Session["LoginDivisionId"].ToString()));
                            }
                            else
                            {
                                if (Session["StrTranType"].ToString() == "CO")
                                {
                                    dt_Profit = Obj_Report.GetSubGroupSummary(Session["FADbname"].ToString(), Convert.ToDateTime(Utility.fn_ConvertDate(txt_From.Text)), Convert.ToDateTime(Utility.fn_ConvertDate(txt_To.Text)), Convert.ToInt32(Session["LoginBranchid"].ToString()), GroupID);
                                }
                                else
                                {
                                    dt_Profit = Obj_Report.GetSubGroupSummary(Session["FADbname"].ToString(), Convert.ToDateTime(Utility.fn_ConvertDate(txt_From.Text)), Convert.ToDateTime(Utility.fn_ConvertDate(txt_To.Text)), Convert.ToInt32(Session["LoginBranchid"].ToString()), GroupID);
                                }
                            }
                            if (dt_Profit.Rows.Count > 0)
                            {
                                GridSubgroup.Visible = true;
                                GridSubgroup.DataSource = dt_Profit;
                                ViewState["GridSubgroup"] = dt_Profit;
                                GridSubgroup.DataBind();
                                grd_profit.Visible = false;
                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), "alertify.alert('No Entry Exists')", true);
                            }
                        }
                    }
                }

                if ((grd_profit.Rows[Row_Index].Cells[0].Text== "Gross Profit"  || grd_profit.Rows[Row_Index].Cells[0].Text == "Gross Loss"))
                {
                    double GP, GL;
                    int GridRowsCount = grd_profit.Rows.Count;
                    if (hid_Gp.Value != "")
                    {
                        GP = Convert.ToDouble(hid_Gp.Value);
                    }
                    else
                    {
                        GP = 0.00;
                    }

                    if (hid_Gl.Value != "")
                    {
                        GL = Convert.ToDouble(hid_Gl.Value);
                    }
                    else
                    {
                        GL = 0.00;
                    }

                    bool chked = false;
                    if (chk_consolidate.Checked == true)
                    {
                        chked = true;
                    }
                    string strtrantype = "";
                    strtrantype = Session["StrTranType"].ToString();


                    //iframecost.Attributes["src"] = "../FAForms/GPBreakUp.aspx?GridRowsCount=" + GridRowsCount + "&FromDate=" + txt_From.Text + "&ToDate=" + txt_To.Text + "&GP=" + GP + "&GL=" + GL + "&chked=" + chked + "&strtrantype=" + strtrantype;
                    //ModalPopupExtender1.Show();
                    DataTable dt_OprProfit = new DataTable();
                    DataTable dt = new DataTable();
                    DataSet dtset = new DataSet();
                    //DataAccess.MISGrd da_obj_misgrd = new DataAccess.MISGrd();
                    //DataAccess.MisCorporate miscorobj = new DataAccess.MisCorporate();
                    int VouyearFA = Convert.ToInt32(Session["LogYear"].ToString());
                    string transtype = Session["StrTranType"].ToString();
                    int count;
                    double total;
                    string transtype1 = "";
                    string div;
                    if (Session["LoginBranchName"].ToString() == "CORPORATE")
                    {
                        dt_OprProfit = miscorobj.GetOperatingProfitcorp(0, int.Parse(Session["LoginDivisionId"].ToString()), transtype, Convert.ToDateTime(Utility.fn_ConvertDate(txt_From.Text)), Convert.ToDateTime(Utility.fn_ConvertDate(txt_To.Text)));
                    }
                    else
                    {
                        dt_OprProfit = da_obj_misgrd.GetOperatingProfit(Convert.ToInt32(Session["LoginBranchid"].ToString()), int.Parse(Session["LoginDivisionId"].ToString()), transtype, Convert.ToDateTime(Utility.fn_ConvertDate(txt_From.Text.ToString())), Convert.ToDateTime(Utility.fn_ConvertDate(txt_To.Text.ToString())));
                    }

                    if (chk_consolidate.Checked == true)
                    {
                        if (Session["LoginBranchName"].ToString() == "CORPORATE")
                        {
                            div = "D";
                            dtset = da_obj_misgrd.unclosedFAnew(Convert.ToDateTime(Utility.fn_ConvertDate(txt_From.Text.ToString())), Convert.ToDateTime(Utility.fn_ConvertDate(txt_To.Text.ToString())), VouyearFA, Convert.ToInt32(Session["LoginDivisionId"].ToString()), Session["FADbname"].ToString(), div);
                        }
                    }
                    else
                    {
                        div = "B";
                        dtset = da_obj_misgrd.unclosedFAnew(Convert.ToDateTime(Utility.fn_ConvertDate(txt_From.Text.ToString())), Convert.ToDateTime(Utility.fn_ConvertDate(txt_To.Text.ToString())), VouyearFA, Convert.ToInt32(Session["LoginBranchid"].ToString()), Session["FADbname"].ToString(), div);
                    }

                    //if(dt_OprProfit.Rows.Count>0)
                    //{
                    ModalPopupExtender2.Show();
                    dt_OprProfit.Columns.Add(new DataColumn("Total"));
                    double dbl_Total = 0, dbl_Full_Total = 0;
                    for (int k = 0; k < dt_OprProfit.Rows.Count; k++)
                    {
                        dbl_Total = 0;
                        if (Session["LoginBranchName"].ToString() == "CORPORATE")
                        {
                            for (int R = 2; R < dt_OprProfit.Columns.Count; R++)
                            {
                                if (dt_OprProfit.Rows[k][R].ToString().Length > 0)
                                    dbl_Total = dbl_Total + Convert.ToDouble(dt_OprProfit.Rows[k][R].ToString());
                            }
                        }
                        else
                        {
                            for (int R = 1; R < dt_OprProfit.Columns.Count; R++)
                            {
                                if (dt_OprProfit.Rows[k][R].ToString().Length > 0)
                                    dbl_Total = dbl_Total + Convert.ToDouble(dt_OprProfit.Rows[k][R].ToString());
                            }
                        }
                        dt_OprProfit.Rows[k]["Total"] = dbl_Total;
                        dbl_Full_Total = dbl_Full_Total + dbl_Total;
                    }


                    DataRow dr_temp = dt_OprProfit.NewRow();
                    dr_temp[0] = "Operating Profit-Total";

                    if (Session["LoginBranchName"].ToString() == "CORPORATE")
                    {
                        for (int R = 2; R < dt_OprProfit.Columns.Count - 1; R++)
                        {
                            dr_temp[R] = dt_OprProfit.Compute("sum(" + dt_OprProfit.Columns[R].Caption.ToString() + ")", "");
                        }
                    }
                    else
                    {
                        for (int R = 1; R < dt_OprProfit.Columns.Count - 1; R++)
                        {
                            dr_temp[R] = dt_OprProfit.Compute("sum(" + dt_OprProfit.Columns[R].Caption.ToString() + ")", "");
                        }
                    }

                    

                    dr_temp["Total"] = dbl_Full_Total;

                    dt_OprProfit.Rows.Add(dr_temp);
                    DataTable ds = new DataTable();
                    DataTable dsp = new DataTable();
                    DataTable dsp1 = new DataTable();
                    DataTable dsp2 = new DataTable();
                    DataTable dsp3 = new DataTable();
                    DataTable dsp4 = new DataTable();
                    DataTable dsp5 = new DataTable();
                    DataTable dsp6 = new DataTable();
                    Double ACLSamount = 0.00;
                    Double FAvoucher = 0.00;
                    Double UCLamount = 0.00;
                    Double CCLSamount = 0.00;
                    Double JNLSamount = 0.00;
                    if (dtset.Tables.Count > 0)
                    {
                        ds = dtset.Tables[0];
                        dsp = dtset.Tables[1];
                        dsp1 = dtset.Tables[2];
                        dsp2 = dtset.Tables[4];
                        dsp3 = dtset.Tables[5];
                        dsp4 = dtset.Tables[6];
                        dsp5 = dtset.Tables[7];
                        dsp6 = dtset.Tables[9];
                        Session["dsp3"] = dsp3;
                        Session["dsp4"] = dsp4;
                        Session["dsp5"] = dsp5;
                        Session["dsp6"] = dsp6;
                    }
                    if (ds.Rows.Count > 0)
                    {
                        ACLSamount = Convert.ToDouble(ds.Rows[0][1]);
                        UCLamount = Convert.ToDouble(dsp.Rows[0][1]);
                        CCLSamount = Convert.ToDouble(dsp1.Rows[0][1]);
                        JNLSamount = Convert.ToDouble(dsp2.Rows[0][1]);
                    }

                    Double overalltotal = 0;
                    if (Session["LoginBranchName"].ToString() != "CORPORATE")
                    {
                        DataRow dr_temp1 = dt_OprProfit.NewRow();
                        dr_temp1[0] = "Job closed in previous / Subsequent Month(s) & Voucher raised during the given period (+)";
                        dr_temp1[5] = ACLSamount.ToString("#,0.00");
                        hid_aclsamount.Value = ACLSamount.ToString("#,0") + "";
                        dt_OprProfit.Rows.Add(dr_temp1);
                        DataRow dr_temp4 = dt_OprProfit.NewRow();
                        dr_temp4[0] = "Voucher raised during the given period & Jobs Unclosed (+)";
                        dr_temp4[5] = UCLamount.ToString("#,0.00");
                        hid_UCLamount.Value = UCLamount.ToString("#,0") + "";
                        dt_OprProfit.Rows.Add(dr_temp4);
                        DataRow dr_temp5 = dt_OprProfit.NewRow();
                        dr_temp5[0] = "JobClosed during the given period but voucher raised previous / Subsequent Month(s) (-)";
                        dr_temp5[5] = CCLSamount.ToString("#,0.00");
                        hid_CCLSamount.Value = CCLSamount.ToString("#,0") + "";
                        dt_OprProfit.Rows.Add(dr_temp5);

                        DataRow dr_temp2 = dt_OprProfit.NewRow();
                        dr_temp2[0] = "Direct Account in FA (+)";
                        dr_temp2[5] = JNLSamount.ToString("#,0.00");
                        hid_JNLSamount.Value = CCLSamount.ToString("#,0") + "";
                        dt_OprProfit.Rows.Add(dr_temp2);
                        //if(dt_OprProfit.Rows.Count>0)
                        //{
                        //    //for(int i=0;i<=dt_OprProfit.Rows.Count-1;i++)
                        //    //{
                        //        if (!string.IsNullOrEmpty(dt_OprProfit.Rows[i][8].ToString()))
                        //        {
                        //            overalltotal = dbl_Full_Total + ACLSamount + UCLamount - CCLSamount + JNLSamount;
                        //        }

                        //    //}
                        //}

                        overalltotal = dbl_Full_Total + ACLSamount + UCLamount - CCLSamount + JNLSamount;

                        //overalltotal = dbl_Full_Total + ACLSamount + UCLamount - CCLSamount - JNLSamount;
                       
                        if (grd_profit.Rows.Count > 0)
                        {
                            if (grd_profit.Rows[2].Cells[0].Text != "" && grd_profit.Rows[2].Cells[1].Text != "")
                            {
                                Label1.Text = grd_profit.Rows[2].Cells[0].Text + " : " + grd_profit.Rows[2].Cells[1].Text;
                                Double grossprofit = Convert.ToDouble(grd_profit.Rows[2].Cells[1].Text);
                                Double profit = Convert.ToDouble(overalltotal) - Convert.ToDouble(grossprofit);
                                hid_diifer.Value = profit.ToString("#,0.00") + "";
                                Label5.Text = "Round UP / OFF :" + profit.ToString("#,0.00") + "";
                            }
                            else
                            {
                                Label1.Text = grd_profit.Rows[2].Cells[2].Text + " : " + grd_profit.Rows[2].Cells[3].Text;
                                Double grossprofit = Convert.ToDouble(grd_profit.Rows[2].Cells[3].Text);
                                Double profit = Convert.ToDouble(overalltotal) + Convert.ToDouble(grossprofit);
                                Label5.Text = "Round UP / OFF :" + profit.ToString("#,0.00") + "";
                                hid_diifer.Value = profit.ToString("#,0.00") + "";
                            }



                        }
                        DataRow dr_temp12 = dt_OprProfit.NewRow();
                        dr_temp12[0] = "Round UP / OFF";                    
                        dr_temp12[5] = hid_diifer.Value;
                        dt_OprProfit.Rows.Add(dr_temp12);
                        DataRow dr_temp3 = dt_OprProfit.NewRow();
                        dr_temp3[0] = "Balance as per GP";
                        //if (Convert.ToDouble(hid_diifer.Value) > 0)
                        //{
                        //    overalltotal = overalltotal - Convert.ToDouble(hid_diifer.Value);  // (+)
                        //}
                        //else
                        //{
                        //    overalltotal = overalltotal + Convert.ToDouble(hid_diifer.Value);  // (+)
                        //}

                        overalltotal = overalltotal - Convert.ToDouble(hid_diifer.Value);  // (+)
                        dr_temp3[5] = overalltotal.ToString("#,0.00") + "";
                      
                        dt_OprProfit.Rows.Add(dr_temp3);

                      
                        //if (dt_OprProfit.Rows.Count>0)
                        //{
                        //    var sum_Income = dt_OprProfit.Compute("sum(Total)", "");
                        //    dr_temp3[8] = sum_Income;

                        //   // overalltotal = Convert.ToInt32(dt_OprProfit.Compute("sum(Total)", ""));
                        //}


                        GridView1.DataSource = dt_OprProfit;
                        GridView1.DataBind();
                        GridView1.Rows[2].Cells[0].ForeColor = System.Drawing.Color.DarkBlue;
                        GridView1.Rows[2].Cells[5].ForeColor = System.Drawing.Color.DarkBlue;
                        GridView1.Rows[GridView1.Rows.Count - 1].Cells[0].ForeColor = System.Drawing.Color.DarkBlue;
                        GridView1.Rows[GridView1.Rows.Count - 1].Cells[5].ForeColor = System.Drawing.Color.DarkBlue;

                        //}
                        //if (grd_profit.Rows.Count > 0)
                        //{
                        //    if (grd_profit.Rows[1].Cells[0].Text != "" && grd_profit.Rows[1].Cells[1].Text != "")
                        //    {
                        //        Label1.Text = grd_profit.Rows[1].Cells[0].Text + " : " + grd_profit.Rows[1].Cells[1].Text;
                        //        Double grossprofit = Convert.ToDouble(grd_profit.Rows[1].Cells[1].Text);
                        //        Double profit = Convert.ToDouble(overalltotal) - Convert.ToDouble(grossprofit);
                        //        Label5.Text = "Difference :" + profit.ToString("#,0.00") + "";
                        //    }
                        //    else
                        //    {
                        //        Label1.Text = grd_profit.Rows[1].Cells[2].Text + " : " + grd_profit.Rows[1].Cells[3].Text;
                        //        Double grossprofit = Convert.ToDouble(grd_profit.Rows[1].Cells[3].Text);
                        //        Double profit = Convert.ToDouble(overalltotal) + Convert.ToDouble(grossprofit);
                        //        Label5.Text = "Difference :" + profit.ToString("#,0.00") + "";
                        //    }

                        //    GridView1.Rows[1].Cells[0].ForeColor = System.Drawing.Color.DarkBlue;
                        //    GridView1.Rows[1].Cells[8].ForeColor = System.Drawing.Color.DarkBlue;
                        //    GridView1.Rows[GridView1.Rows.Count - 1].Cells[0].ForeColor = System.Drawing.Color.DarkBlue;
                        //    GridView1.Rows[GridView1.Rows.Count - 1].Cells[8].ForeColor = System.Drawing.Color.DarkBlue;

                        //}
                    }
                    else
                    {
                        DataRow dr_temp1 = dt_OprProfit.NewRow();
                        dr_temp1[0] = "Job closed in previous / Subsequent Month(s) & Voucher raised during the given period (+)";
                        dr_temp1[5] = ACLSamount.ToString("#,0.00");
                        hid_aclsamount.Value = ACLSamount.ToString("#,0.00") + "";
                        dt_OprProfit.Rows.Add(dr_temp1);
                        DataRow dr_temp4 = dt_OprProfit.NewRow();
                        dr_temp4[0] = "Voucher raised during the given period & Jobs Unclosed (+)";
                        dr_temp4[5] = UCLamount.ToString("#,0.00");
                        hid_UCLamount.Value = UCLamount.ToString("#,0.00") + "";
                        dt_OprProfit.Rows.Add(dr_temp4);
                        DataRow dr_temp5 = dt_OprProfit.NewRow();
                        dr_temp5[0] = "JobClosed during the given period but voucher raised previous / Subsequent Month(s) (-)";
                        dr_temp5[5] = CCLSamount.ToString("#,0.00");
                        hid_CCLSamount.Value = CCLSamount.ToString("#,0.00") + "";
                        dt_OprProfit.Rows.Add(dr_temp5);

                        DataRow dr_temp2 = dt_OprProfit.NewRow();
                        dr_temp2[0] = "Direct Account in FA (+)";
                        dr_temp2[5] = JNLSamount.ToString("#,0.00");
                        hid_JNLSamount.Value = CCLSamount.ToString("#,0.00") + "";
                        dt_OprProfit.Rows.Add(dr_temp2);
                        overalltotal = dbl_Full_Total + ACLSamount + UCLamount - CCLSamount + JNLSamount;
                       
                        if (grd_profit.Rows.Count > 0)
                        {
                            Double grossprofit;
                            if (grd_profit.Rows[2].Cells[0].Text != "" && grd_profit.Rows[2].Cells[1].Text != "")
                            {
                                Label1.Text = grd_profit.Rows[2].Cells[0].Text + " : " + grd_profit.Rows[2].Cells[1].Text;
                                if (grd_profit.Rows[2].Cells[1].Text == "")
                                {

                                    grossprofit = Convert.ToDouble(0);
                                }
                                else
                                {
                                    grossprofit = Convert.ToDouble(grd_profit.Rows[2].Cells[1].Text);
                                }
                                Double profit = Convert.ToDouble(overalltotal) - Convert.ToDouble(grossprofit);
                                Label5.Text = "Round UP / OFF :" + profit.ToString("#,0.00") + "";
                                hid_diifer.Value = profit.ToString("#,0.00") + "";
                            }
                            else
                            {
                                Label1.Text = grd_profit.Rows[2].Cells[2].Text + " : " + grd_profit.Rows[1].Cells[3].Text;
                                if (grd_profit.Rows[2].Cells[3].Text == "")
                                {
                                     grossprofit = Convert.ToDouble(0);
                                }
                                else
                                {
                                     grossprofit = Convert.ToDouble(grd_profit.Rows[2].Cells[3].Text);
                                }
                                Double profit = Convert.ToDouble(overalltotal) + Convert.ToDouble(grossprofit);
                                Label5.Text = "Round UP / OFF :" + profit.ToString("#,0.00") + "";
                                hid_diifer.Value = profit.ToString("#,0.00") + "";
                            }
                        }
                        DataRow dr_temp6 = dt_OprProfit.NewRow();
                        dr_temp6[0] = "Round UP / OFF";
                        dr_temp6[5] = hid_diifer.Value;
                        dt_OprProfit.Rows.Add(dr_temp6);
                        DataRow dr_temp3 = dt_OprProfit.NewRow();
                        dr_temp3[0] = "Balance as per GP";
                      
                        overalltotal=overalltotal -Convert.ToDouble(hid_diifer.Value );  // (+)
                        dr_temp3[5] = overalltotal.ToString("#,0.00") + "";
                        dt_OprProfit.Rows.Add(dr_temp3);
                        GridView1.DataSource = dt_OprProfit;
                        GridView1.DataBind();

                        //GridView1.Rows[1].Cells[0].ForeColor = System.Drawing.Color.DarkBlue;
                        //GridView1.Rows[1].Cells[7].ForeColor = System.Drawing.Color.DarkBlue;
                        //GridView1.Rows[dt_OprProfit.Rows.Count - 1].Cells[0].ForeColor = System.Drawing.Color.DarkBlue;
                        //GridView1.Rows[dt_OprProfit.Rows.Count - 1].Cells[7].ForeColor = System.Drawing.Color.DarkBlue;

                        //if (grd_profit.Rows.Count > 0)
                        //{
                        //    if (grd_profit.Rows[1].Cells[0].Text != "" && grd_profit.Rows[1].Cells[1].Text != "")
                        //    {
                        //        Label1.Text = grd_profit.Rows[1].Cells[0].Text + " : " + grd_profit.Rows[1].Cells[1].Text;
                        //        Double grossprofit = Convert.ToDouble(grd_profit.Rows[1].Cells[1].Text);
                        //        Double profit = Convert.ToDouble(overalltotal) - Convert.ToDouble(grossprofit);
                        //        Label5.Text = "Difference :" + profit.ToString("#,0.00") + "";
                        //    }
                        //    else
                        //    {
                        //        Label1.Text = grd_profit.Rows[1].Cells[2].Text + " : " + grd_profit.Rows[1].Cells[3].Text;
                        //        Double grossprofit = Convert.ToDouble(grd_profit.Rows[1].Cells[3].Text);
                        //        Double profit = Convert.ToDouble(overalltotal) + Convert.ToDouble(grossprofit);
                        //        Label5.Text = "Difference :" + profit.ToString("#,0.00") + "";
                        //    }

                        //    GridView1.Rows[1].Cells[0].ForeColor = System.Drawing.Color.DarkBlue;
                        //    GridView1.Rows[1].Cells[7].ForeColor = System.Drawing.Color.DarkBlue;
                        //    GridView1.Rows[GridView1.Rows.Count - 1].Cells[0].ForeColor = System.Drawing.Color.DarkBlue;
                        //    GridView1.Rows[GridView1.Rows.Count - 1].Cells[7].ForeColor = System.Drawing.Color.DarkBlue;

                        //}
                    }



                }
            }
        }

        protected void grd_profit_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                int Row_Index, Column_Index;
                if (e.CommandName.ToString() == "Select")
                {
                    Row_Index = Convert.ToInt32(e.CommandArgument.ToString());
                    Column_Index = Convert.ToInt32(Request.Form["__EVENTARGUMENT"].ToString());
                    ViewState["Col_index"] = Column_Index;

                    //string text = grd_profit.Columns[Column_Index].HeaderText;                   
                    //grd_profit.SelectedRow.Cells[Column_Index].Attributes["style"] += "background-color:White;";

                    ViewState["Row_Index"] = Row_Index;
                    ViewState["Column_Index"] = Column_Index;

                    GP_Profit(Row_Index);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.StackTrace trace = new System.Diagnostics.StackTrace(ex, true);
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + ex.Message.ToString() + " " + trace.GetFrame(0).GetFileLineNumber() + "');", true);
            }
        }

        protected void btnEsc_Click(object sender, EventArgs e)
        {
            grd_profit.Visible = true;
            Loaddata();
            GridSubgroup.Visible = false;
            btn_cancel.ToolTip = "Cancel";
            btn_cancel.Text = "cancel";
            btn_cancel1.Attributes["class"] = "btn ico-cancel";
        }

        protected void GridSubgroup_RowDataBound(object sender, GridViewRowEventArgs e)
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

                for (int h = 0; h < e.Row.Cells.Count; h++)
                {
                    double dbl_temp = 0;

                    if (double.TryParse(e.Row.Cells[h].Text.ToString(), out dbl_temp))
                    {
                        e.Row.Cells[h].Text = string.Format("{0:#,##0.00}", dbl_temp);
                        e.Row.Cells[h].Attributes.CssStyle["text-align"] = "Right";
                    }
                }

                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(GridSubgroup, "Select$" + e.Row.RowIndex);
                e.Row.Attributes["style"] = "cursor:pointer";
            }
        }

        protected void GridSubgroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = GridSubgroup.SelectedRow.RowIndex;
            int subgroupid = Convert.ToInt32(GridSubgroup.DataKeys[index].Values[0].ToString());
            DataTable dt_Ledger = new DataTable();

            if (chk_consolidate.Checked == true)
            {
                dt_Ledger = FAObj.GetLedgerGroupSummary4AllBranch(Session["FADbname"].ToString(), Convert.ToDateTime(Utility.fn_ConvertDate(txt_From.Text)), Convert.ToDateTime(Utility.fn_ConvertDate(txt_To.Text)), Convert.ToInt32(Session["LoginDivisionId"].ToString()), subgroupid);
            }
            else
            {
                dt_Ledger = FAObj.GetLedgerGroupSummary(Session["FADbname"].ToString(), Convert.ToDateTime(Utility.fn_ConvertDate(txt_From.Text)), Convert.ToDateTime(Utility.fn_ConvertDate(txt_To.Text)), Convert.ToInt32(Session["LoginBranchid"].ToString()), subgroupid);
            }

            if (dt_Ledger.Rows.Count > 0)
            {
                GridSubgroup.Visible = false;
                Grd_Ledger.Visible = true;
                Grd_Ledger_new.Visible = false;
                Grd_Ledger.DataSource = dt_Ledger;
                ViewState["Grd_Ledger"] = dt_Ledger;
                Grd_Ledger.DataBind();
            }
        }

        protected void Grd_Ledger_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = Grd_Ledger.SelectedRow.RowIndex;
            string Consolidate = "";
            if (chk_consolidate.Checked == true)
            {
                Consolidate = "True";
            }
            iframecost.Attributes["src"] = "../FAForms/FALedgerView.aspx?Customer=" + Grd_Ledger.Rows[index].Cells[0].Text + "&CheckedValue=" + false + "&LedgerID=" + Grd_Ledger.DataKeys[index].Values[0].ToString() + "&FromDate=" + txt_From.Text + "&ToDate=" + txt_To.Text + "&Consolidate=" + Consolidate;
            ModalPopupExtender1.Show();
            return;
        }

        protected void Grd_Ledger_RowDataBound(object sender, GridViewRowEventArgs e)
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

                for (int h = 0; h < e.Row.Cells.Count; h++)
                {
                    double dbl_temp = 0;

                    if (double.TryParse(e.Row.Cells[h].Text.ToString(), out dbl_temp))
                    {
                        e.Row.Cells[h].Text = string.Format("{0:#,##0.00}", dbl_temp);
                        e.Row.Cells[h].Attributes.CssStyle["text-align"] = "Right";
                    }
                }

                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(Grd_Ledger, "Select$" + e.Row.RowIndex);
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
            //DataAccess.LogDetails Logobj = new DataAccess.LogDetails();

            if (Session["str_ModuleName"].ToString() == "FA")
            {
                obj_dtlogdetails = Logobj.InsTempGrpLogdtlsGet(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), 1117, "PA", "", "", Session["StrTranType"].ToString());
            }
            else
            {
                obj_dtlogdetails = Logobj.InsTempGrpLogdtlsGet(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), 1206, "PA", "", "", Session["StrTranType"].ToString());
            }

            //if (txt_jobno.Text != "")
            //{
            //    JobInput.Text = txt_jobno.Text;
            //}

            if (obj_dtlogdetails.Rows.Count >= 0)
            {
                ModalPopupExtenderlog.Show();
                GridViewlog.DataSource = obj_dtlogdetails;
                GridViewlog.DataBind();
            }
        }



        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
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
                for (int h = 1; h < e.Row.Cells.Count; h++)
                {
                    double dbl_temp = 0;

                    if (double.TryParse(e.Row.Cells[h].Text.ToString(), out dbl_temp))
                    {
                        e.Row.Cells[h].Attributes.CssStyle["text-align"] = "Right";
                        e.Row.Cells[h].Text = string.Format("{0:#,##0.00}", dbl_temp);
                    }
                }
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(GridView1, "Select$" + e.Row.RowIndex);
                e.Row.Attributes["style"] = "cursor:pointer";
            }
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //PanelGrid1.Visible = true;

          
            if (GridView1.Rows.Count > 0)
            {
                if (GridView1.SelectedRow.Cells[0].Text == "Job closed in previous / Subsequent Month(s) &amp; Voucher raised during the given period (+)")
                {
                    Panel3.Visible = true;
                    GridView1.Visible = true;
                    DataTable dtne = new DataTable();
                    dtne = (DataTable)Session["dsp3"];
                    if (dtne.Rows.Count > 0)
                    {
                        ModalPopupExtender2.Show();
                        ModalPopupExtender3.Show();
                        GridView2.DataSource = dtne;
                        GridView2.DataBind();
                    }
                    // Label3.Text = "Total :" + hid_aclsamount.Value;
                }
                if (GridView1.SelectedRow.Cells[0].Text == "Voucher raised during the given period &amp; Jobs Unclosed (+)")
                {
                    Panel3.Visible = true;
                    GridView1.Visible = true;
                    DataTable dtne1 = new DataTable();
                    dtne1 = (DataTable)Session["dsp4"];
                    if (dtne1.Rows.Count > 0)
                    {
                        ModalPopupExtender2.Show();
                        ModalPopupExtender4.Show();
                        GridView3.DataSource = dtne1;
                        GridView3.DataBind();
                    }
                    // Label6.Text = "Total :" + hid_UCLamount.Value;
                    
                }
                if (GridView1.SelectedRow.Cells[0].Text == "JobClosed during the given period but voucher raised previous / Subsequent Month(s) (-)")
                {
                    Panel3.Visible = true;
                    GridView1.Visible = true;
                    DataTable dtne2 = new DataTable();
                    dtne2 = (DataTable)Session["dsp5"];
                    if (dtne2.Rows.Count > 0)
                    {
                        ModalPopupExtender2.Show();
                        ModalPopupExtender5.Show();
                        GridView4.DataSource = dtne2;
                        GridView4.DataBind();
                    }
                    //Label7.Text = "Total :" + hid_CCLSamount.Value;
                }
                if (GridView1.SelectedRow.Cells[0].Text == "Direct Account in FA (+)")
                {
                    Panel3.Visible = true;
                    GridView1.Visible = true;
                    DataTable dtne3 = new DataTable();
                    dtne3 = (DataTable)Session["dsp6"];
                    if (dtne3.Rows.Count > 0)
                    {
                        ModalPopupExtender2.Show();
                        ModalPopupExtender6.Show();
                        GridView5.DataSource = dtne3;
                        GridView5.DataBind();
                    }
                    //Label8.Text = "Total :" + hid_JNLSamount.Value;
                }
                else
                {
                    Panel2.Visible = true;
                    GridView1.Visible = true;
                }

            }
        }

        protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                for (int i = 0; i < e.Row.Cells.Count; i++)
                {
                    if (e.Row.Cells[i].Text == "&nbsp;")
                    {
                        e.Row.Cells[i].Text = "";
                    }
                    if (e.Row.Cells[6].Text == "Total")
                    {
                        e.Row.ForeColor = System.Drawing.Color.Brown;
                        e.Row.Cells[0].Text = "";
                        e.Row.Cells[2].Text = "";
                        e.Row.Cells[4].Text = "";
                    }

                    e.Row.Cells[i].ToolTip = e.Row.Cells[i].Text;
                }
                for (int h = 7; h < e.Row.Cells.Count; h++)
                {
                    double dbl_temp = 0;

                    if (double.TryParse(e.Row.Cells[h].Text.ToString(), out dbl_temp))
                    {
                        e.Row.Cells[h].Attributes.CssStyle["text-align"] = "Right";
                        e.Row.Cells[h].Text = string.Format("{0:#,##0.00}", dbl_temp);
                    }
                }
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(GridView2, "Select$" + e.Row.RowIndex);
                e.Row.Attributes["style"] = "cursor:pointer";
            }
        }

        protected void btn_gpprofit_Click(object sender, EventArgs e)
        {
            if (GridView1.Rows.Count>0)
            {
                //string strtemp = "";
                //strtemp = Utility.Fn_ExportExcel(GridView1, "<tr><td></td><td><FONT FACE=arial SIZE=2>  </td></tr><tr><td></td><td></td><td><FONT FACE=arial SIZE=2>" + Session["LoginDivisionName"].ToString() + " - " + Session["LoginBranchName"].ToString() + "</td></tr>");
                //Response.Clear();
                //Response.AddHeader("Content-Disposition", "Attachment;Filename=Profit&Loss.xls");
                //Response.Buffer = true;
                //Response.Charset = "UTF-8";
                //Response.ContentType = "application/vnd.ms-excel";
                //Response.Write(strtemp);
                //Response.End();
                string filename = "";
                filename = "GP Vs Operating Profit";
                Response.Clear();
                Response.Buffer = true;
                Response.AddHeader("content-disposition", "attachment;filename=" + filename + ".xls");
                Response.Charset = "";
                Response.ContentType = "application/vnd.xls";
                StringWriter StringWriter = new System.IO.StringWriter();
                HtmlTextWriter HtmlTextWriter = new HtmlTextWriter(StringWriter);

                GridView1.AllowPaging = false;
                //  Grdincomnotbooked();
                // get_out();

                GridView1.GridLines = GridLines.Both;
                GridView1.HeaderStyle.Font.Bold = true;
                GridView1.RenderControl(HtmlTextWriter);
                Response.Write(StringWriter.ToString());
                Response.End();
            }
        }

        protected void btn_jobclose1_Click(object sender, EventArgs e)
        {
          /*  if (GridView2.Rows.Count>0)
            {
                string strtemp = "";
                strtemp = Utility.Fn_ExportExcel(GridView2, "<tr><td></td><td><FONT FACE=arial SIZE=2>  </td></tr><tr><td></td><td></td><td><FONT FACE=arial SIZE=2>" + Session["LoginDivisionName"].ToString() + " - " + Session["LoginBranchName"].ToString() + "</td></tr>");
                Response.Clear();
                Response.AddHeader("Content-Disposition", "Attachment;Filename=Profit&Loss.xls");
                Response.Buffer = true;
                Response.Charset = "UTF-8";
                Response.ContentType = "application/vnd.ms-excel";
                Response.Write(strtemp);
                Response.End();
            }*/
            if (GridView2.Rows.Count > 0)
            {
                string filename = "";
                filename = "Job closed in previous / Subsequent Month(s) & Voucher raised during the given period (+)";
                Response.Clear();
                Response.Buffer = true;
                Response.AddHeader("content-disposition", "attachment;filename=" + filename + ".xls");
                Response.Charset = "";
                Response.ContentType = "application/vnd.xls";
                StringWriter StringWriter = new System.IO.StringWriter();
                HtmlTextWriter HtmlTextWriter = new HtmlTextWriter(StringWriter);

                GridView2.AllowPaging = false;
                //  Grdincomnotbooked();
                // get_out();

                GridView2.GridLines = GridLines.Both;
                GridView2.HeaderStyle.Font.Bold = true;
                GridView2.RenderControl(HtmlTextWriter);
                Response.Write(StringWriter.ToString());
                Response.End();
            }

        }

        protected void btn_jobclose2_Click(object sender, EventArgs e)
        {
            if (GridView3.Rows.Count>0)
            {
                //string strtemp = "";
                //strtemp = Utility.Fn_ExportExcel(GridView3, "<tr><td></td><td><FONT FACE=arial SIZE=2>  </td></tr><tr><td></td><td></td><td><FONT FACE=arial SIZE=2>" + Session["LoginDivisionName"].ToString() + " - " + Session["LoginBranchName"].ToString() + "</td></tr>");
                //Response.Clear();
                //Response.AddHeader("Content-Disposition", "Attachment;Filename=Profit&Loss.xls");
                //Response.Buffer = true;
                //Response.Charset = "UTF-8";
                //Response.ContentType = "application/vnd.ms-excel";
                //Response.Write(strtemp);
                //Response.End();
                string filename = "";
                filename = "Voucher raised during the given period & Jobs Unclosed (+)";
                Response.Clear();
                Response.Buffer = true;
                Response.AddHeader("content-disposition", "attachment;filename=" + filename + ".xls");
                Response.Charset = "";
                Response.ContentType = "application/vnd.xls";
                StringWriter StringWriter = new System.IO.StringWriter();
                HtmlTextWriter HtmlTextWriter = new HtmlTextWriter(StringWriter);

                GridView3.AllowPaging = false;
                //  Grdincomnotbooked();
                // get_out();

                GridView3.GridLines = GridLines.Both;
                GridView3.HeaderStyle.Font.Bold = true;
                GridView3.RenderControl(HtmlTextWriter);
                Response.Write(StringWriter.ToString());
                Response.End();
            }
        }

        protected void btn_close3_Click(object sender, EventArgs e)
        {
            if (GridView4.Rows.Count>0)
            {
                //string strtemp = "";
                //strtemp = Utility.Fn_ExportExcel(GridView4, "<tr><td></td><td><FONT FACE=arial SIZE=2>  </td></tr><tr><td></td><td></td><td><FONT FACE=arial SIZE=2>" + Session["LoginDivisionName"].ToString() + " - " + Session["LoginBranchName"].ToString() + "</td></tr>");
                //Response.Clear();
                //Response.AddHeader("Content-Disposition", "Attachment;Filename=Profit&Loss.xls");
                //Response.Buffer = true;
                //Response.Charset = "UTF-8";
                //Response.ContentType = "application/vnd.ms-excel";
                //Response.Write(strtemp);
                //Response.End();
                string filename = "";
                filename = "Voucher not raised in given period & Jobs closed during the given period (-)";
                Response.Clear();
                Response.Buffer = true;
                Response.AddHeader("content-disposition", "attachment;filename=" + filename + ".xls");
                Response.Charset = "";
                Response.ContentType = "application/vnd.xls";
                StringWriter StringWriter = new System.IO.StringWriter();
                HtmlTextWriter HtmlTextWriter = new HtmlTextWriter(StringWriter);

                GridView4.AllowPaging = false;
                //  Grdincomnotbooked();
                // get_out();

                GridView4.GridLines = GridLines.Both;
                GridView4.HeaderStyle.Font.Bold = true;
                GridView4.RenderControl(HtmlTextWriter);
                Response.Write(StringWriter.ToString());
                Response.End();
            }
        }

        protected void btn_close4_Click(object sender, EventArgs e)
        {
            if (GridView5.Rows.Count>0)
            {
                //string strtemp = "";
                //strtemp = Utility.Fn_ExportExcel(GridView5, "<tr><td></td><td><FONT FACE=arial SIZE=2>  </td></tr><tr><td></td><td></td><td><FONT FACE=arial SIZE=2>" + Session["LoginDivisionName"].ToString() + " - " + Session["LoginBranchName"].ToString() + "</td></tr>");
                //Response.Clear();
                //Response.AddHeader("Content-Disposition", "Attachment;Filename=Profit&Loss.xls");
                //Response.Buffer = true;
                //Response.Charset = "UTF-8";
                //Response.ContentType = "application/vnd.ms-excel";
                //Response.Write(strtemp);
                //Response.End();

                string filename = "";
                filename = "Direct Account in FA (+)";
                Response.Clear();
                Response.Buffer = true;
                Response.AddHeader("content-disposition", "attachment;filename=" + filename + ".xls");
                Response.Charset = "";
                Response.ContentType = "application/vnd.xls";
                StringWriter StringWriter = new System.IO.StringWriter();
                HtmlTextWriter HtmlTextWriter = new HtmlTextWriter(StringWriter);

                GridView5.AllowPaging = false;
                //  Grdincomnotbooked();
                // get_out();

                GridView5.GridLines = GridLines.Both;
                GridView5.HeaderStyle.Font.Bold = true;
                GridView5.RenderControl(HtmlTextWriter);
                Response.Write(StringWriter.ToString());
                Response.End();
            }
        }

        protected void grd_profit_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = grd_profit.SelectedRow.RowIndex;
            //RowIndex = grd_profit.SelectedRow.RowIndex;
            if (ViewState["Col_index"] != null)
            {
                ColumnIndex = Convert.ToInt32(ViewState["Col_index"].ToString());
            }
            string Consolidate = "";
            if (chk_consolidate.Checked == true)
            {
                Consolidate = "True";
            }

            if (ColumnIndex == 0 && grd_profit.DataKeys[index].Values[0].ToString() == "L")
            {
                iframecost.Attributes["src"] = "../FAForms/FALedgerView.aspx?Customer=" + grd_profit.Rows[index].Cells[0].Text + "&CheckedValue=" + false + "&LedgerID=" + grd_profit.DataKeys[index].Values[2].ToString() + "&FromDate=" + txt_From.Text + "&ToDate=" + txt_To.Text + "&Consolidate=" + Consolidate;
                ModalPopupExtender1.Show();
            }
            else if (ColumnIndex == 2 && grd_profit.DataKeys[index].Values[1].ToString() == "L")
            {
                iframecost.Attributes["src"] = "../FAForms/FALedgerView.aspx?Customer=" + grd_profit.Rows[index].Cells[2].Text + "&CheckedValue=" + false + "&LedgerID=" + grd_profit.DataKeys[index].Values[3].ToString() + "&FromDate=" + txt_From.Text + "&ToDate=" + txt_To.Text + "&Consolidate=" + Consolidate;
                ModalPopupExtender1.Show();
            }
            return;
        }

        protected void grd_profit_PreRender(object sender, EventArgs e)
        {
            if (grd_profit.Rows.Count > 0)
            {
                grd_profit.UseAccessibleHeader = true;
                grd_profit.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }

        protected void GridSubgroup_PreRender(object sender, EventArgs e)
        {
            if (GridSubgroup.Rows.Count > 0)
            {
                GridSubgroup.UseAccessibleHeader = true;
                GridSubgroup.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }

        protected void Grd_Ledger_PreRender(object sender, EventArgs e)
        {
            if (Grd_Ledger.Rows.Count > 0)
            {
                Grd_Ledger.UseAccessibleHeader = true;
                Grd_Ledger.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }

        
        protected void btn_all_Click(object sender, EventArgs e)
        {
            Loaddata1();
        }

        protected void grd_all_RowDataBound(object sender, GridViewRowEventArgs e)
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

                for (int h = 0; h < e.Row.Cells.Count; h++)
                {
                    double dbl_temp = 0;

                    if (double.TryParse(e.Row.Cells[h].Text.ToString(), out dbl_temp))
                    {
                        e.Row.Cells[h].Text = string.Format("{0:#,##0.00}", dbl_temp);
                        e.Row.Cells[h].Attributes.CssStyle["text-align"] = "Right";
                    }

                }

                //for (int h = 0; h < e.Row.Cells.Count; h++)
                //{

                //    if (e.Row.Cells[h].Text != "")
                //    {
                //        e.Row.Cells[3].Attributes.CssStyle["background-color"] = "#ff0000";
                //    }
                //}
                
                for (int i = 0; i < e.Row.Cells.Count; i++)
                {
                    if (e.Row.Cells[i].Text == "0.00" || e.Row.Cells[i].Text == "0")
                    {
                        e.Row.Cells[i].Text = "";
                    }
                    e.Row.Cells[i].ToolTip = e.Row.Cells[i].Text;
                }
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(grd_all, "Select$" + e.Row.RowIndex);
                e.Row.Attributes["style"] = "cursor:pointer";
            }
        }

        protected void Grd_Ledger_new_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = Grd_Ledger_new.SelectedRow.RowIndex;
            string Consolidate = "";
            if (chk_consolidate.Checked == true)
            {
                Consolidate = "True";
            }
            iframecost.Attributes["src"] = "../FAForms/FALedgerView.aspx?Customer=" + Grd_Ledger_new.Rows[index].Cells[0].Text + "&CheckedValue=" + false + "&LedgerID=" + Grd_Ledger_new.DataKeys[index].Values[0].ToString() + "&FromDate=" + txt_From.Text + "&ToDate=" + txt_To.Text + "&Consolidate=" + Consolidate;
            ModalPopupExtender1.Show();
            return;
        }

        protected void Grd_Ledger_new_RowDataBound(object sender, GridViewRowEventArgs e)
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

                for (int h = 0; h < e.Row.Cells.Count; h++)
                {
                    double dbl_temp = 0;

                    if (double.TryParse(e.Row.Cells[h].Text.ToString(), out dbl_temp))
                    {
                        e.Row.Cells[h].Text = string.Format("{0:#,##0.00}", dbl_temp);
                        e.Row.Cells[h].Attributes.CssStyle["text-align"] = "Right";
                    }
                }

                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(Grd_Ledger_new, "Select$" + e.Row.RowIndex);
                e.Row.Attributes["style"] = "cursor:pointer";
            }
        }

        protected void Grd_Ledger_new_PreRender(object sender, EventArgs e)
        {
            if (Grd_Ledger_new.Rows.Count > 0)
            {
                Grd_Ledger_new.UseAccessibleHeader = true;
                Grd_Ledger_new.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }

        //protected void grd_all_RowCommand(object sender, GridViewCommandEventArgs e)
        //{
        //    try
        //    {
        //        int Row_Index, Column_Index;
        //        if (e.CommandName.ToString() == "Select")
        //        {
        //            //Row_Index = Convert.ToInt32(e.CommandArgument.ToString());
        //            //Column_Index = Convert.ToInt32(Request.Form["__EVENTARGUMENT"].ToString());
        //            //ViewState["Col_index"] = Column_Index;

        //            ////string text = grd_profit.Columns[Column_Index].HeaderText;                   
        //            ////grd_profit.SelectedRow.Cells[Column_Index].Attributes["style"] += "background-color:White;";

        //            //ViewState["Row_Index"] = Row_Index;
        //            //ViewState["Column_Index"] = Column_Index;

        //            //GP_Profit(Row_Index);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        System.Diagnostics.StackTrace trace = new System.Diagnostics.StackTrace(ex, true);
        //        ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + ex.Message.ToString() + " " + trace.GetFrame(0).GetFileLineNumber() + "');", true);
        //    }
        //}

        protected void grd_all_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = grd_all.SelectedRow.RowIndex;
            int subgroupid = Convert.ToInt32(grd_all.DataKeys[index].Values[4].ToString());
            DataTable dt_Ledger = new DataTable();

            string iename = grd_all.Rows[index].Cells[0].Text; // Vino New for GP [01-03-2024]

            if (Session["chkgp"].ToString() == "true")
            {
                if (iename.ToUpper() == "DIRECT INCOME" || iename.ToUpper() == "DIRECT EXPENSES")
                {
                    if (Session["LoginBranchName"].ToString() == "CORPORATE")
                    {
                        double ieamount = Convert.ToDouble(grd_all.Rows[index].Cells[4].Text); // Vino New for GP [01-03-2024]
                        iframe_GP.Attributes["src"] = "MISvsGP_Details.aspx?IEType=" + iename.ToUpper() + "&frmdate=" + txt_From.Text + "&todate=" + txt_To.Text + "&Amount=" + ieamount.ToString();
                        PanelGP.Visible = true;
                        this.ModalPopupGP.Show();
                    }
                }
                else
                {
                    if (chk_consolidate.Checked == true)
                    {
                        dt_Ledger = FAObj.GetLedgerGroupSummary4AllBranch_all(Session["FADbname"].ToString(), Convert.ToDateTime(Utility.fn_ConvertDate(txt_From.Text)), Convert.ToDateTime(Utility.fn_ConvertDate(txt_To.Text)), Convert.ToInt32(Session["LoginDivisionId"].ToString()), subgroupid);
                    }
                    else
                    {
                        dt_Ledger = FAObj.GetLedgerGroupSummary_all(Session["FADbname"].ToString(), Convert.ToDateTime(Utility.fn_ConvertDate(txt_From.Text)), Convert.ToDateTime(Utility.fn_ConvertDate(txt_To.Text)), Convert.ToInt32(Session["LoginBranchid"].ToString()), subgroupid);
                    }

                    if (dt_Ledger.Rows.Count > 0)
                    {
                        grd_all.Visible = false;
                        Grd_Ledger_new.Visible = true;
                        Grd_Ledger_new.DataSource = dt_Ledger;
                        ViewState["Grd_Ledger"] = dt_Ledger;
                        Grd_Ledger_new.DataBind();
                    }
                    return;
                }
            }

            //if (iename.ToUpper() == "DIRECT INCOME" || iename.ToUpper() == "DIRECT EXPENSES")
            //{
            //    double ieamount = Convert.ToDouble(grd_all.Rows[index].Cells[4].Text); // Vino New for GP [01-03-2024]
            //    iframe_GP.Attributes["src"] = "MISvsGP_Details.aspx?IEType=" + iename.ToUpper() + "&frmdate=" + txt_From.Text + "&todate=" + txt_To.Text + "&Amount=" + ieamount.ToString();
            //    PanelGP.Visible = true;
            //    this.ModalPopupGP.Show();
            //}
            else
            {

                if (chk_consolidate.Checked == true)
                {
                    dt_Ledger = FAObj.GetLedgerGroupSummary4AllBranch_all(Session["FADbname"].ToString(), Convert.ToDateTime(Utility.fn_ConvertDate(txt_From.Text)), Convert.ToDateTime(Utility.fn_ConvertDate(txt_To.Text)), Convert.ToInt32(Session["LoginDivisionId"].ToString()), subgroupid);
                }
                else
                {
                    dt_Ledger = FAObj.GetLedgerGroupSummary_all(Session["FADbname"].ToString(), Convert.ToDateTime(Utility.fn_ConvertDate(txt_From.Text)), Convert.ToDateTime(Utility.fn_ConvertDate(txt_To.Text)), Convert.ToInt32(Session["LoginBranchid"].ToString()), subgroupid);
                }

                if (dt_Ledger.Rows.Count > 0)
                {
                    grd_all.Visible = false;
                    Grd_Ledger_new.Visible = true;
                    Grd_Ledger_new.DataSource = dt_Ledger;
                    ViewState["Grd_Ledger"] = dt_Ledger;
                    Grd_Ledger_new.DataBind();
                }


                return;
            }

        }

        protected void grd_all_PreRender(object sender, EventArgs e)
        {
            if (grd_all.Rows.Count > 0)
            {
                grd_all.UseAccessibleHeader = true;
                grd_all.HeaderRow.TableSection = TableRowSection.TableHeader;
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

        protected void btn_group_mm_Click(object sender, EventArgs e)
        {
            grd_profit.Visible = false;
            DataTable obj_PL = new DataTable();
            GridView11.Visible = true;
            obj_PL = FAObj.PandLDetails(Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToDateTime(Utility.fn_ConvertDate(txt_From.Text.ToString())), Convert.ToDateTime(Utility.fn_ConvertDate(txt_To.Text.ToString())), Session["FADbname"].ToString());
            DataTable dttemp = new DataTable();
            int RN = 2, CN = 1;
            DataTable newTable = new DataTable();
            newTable.Columns.Add(obj_PL.Columns[0].ToString());
            for (int i = 1; i <= obj_PL.Columns.Count - 1; i++)
            {
                newTable.Columns.Add(obj_PL.Columns[i].ToString());
                newTable.Columns.Add(" " + obj_PL.Columns[i].ToString());
            }
            newTable.Rows.Add();
            newTable.Rows[0][0] = "";
            for (int k = 0; k <= newTable.Columns.Count - 1; k++)
            {
                if (CN != newTable.Columns.Count)
                {
                    newTable.Rows[0][CN] = "DIRECT EXPENSES";

                    CN = CN + 1;
                    newTable.Rows[0][CN] = "DIRECT INCOME";

                    CN = CN + 1;
                }
            }
            CN = 1;
            RN = 0;
            for (int l = 0; l <= obj_PL.Rows.Count - 1; l++)
            {
                CN = 1;
                RN = RN + 1;
                newTable.Rows.Add();
                for (int ld = 1; ld <= newTable.Columns.Count - 1; ld++)
                {
                    lcu = obj_PL.Columns.Count;
                    if (lcu > ld)
                    {
                        if (obj_PL.Rows[l]["groupname"].ToString() == "DIRECT EXPENSES" || obj_PL.Rows[l]["groupname"].ToString() == "INDIRECT EXPENSES")
                        {

                            newTable.Rows[RN][CN - 1] = obj_PL.Rows[l][ld - 1].ToString();
                            if (ld != 1)
                            {
                                CN = CN + 1;
                            }
                            newTable.Rows[RN][CN] = string.Format("{0:0.00}", Math.Abs(Convert.ToDouble(obj_PL.Rows[l][ld])));
                            CN = CN + 1;
                            //newTable.Rows[RN][CN] = string.Format("{0:0.00}", 0);
                        }
                        else
                        {
                            newTable.Rows[RN][CN - 1] = obj_PL.Rows[l][ld - 1].ToString();
                            newTable.Rows[RN][CN] = "";
                            if (CN < newTable.Columns.Count - 2)
                            {
                                CN = CN + 2;
                            }
                            else
                            {
                                CN = CN + 1;
                            }
                            newTable.Rows[RN][CN] = string.Format("{0:0.00}", Math.Abs(Convert.ToDouble(obj_PL.Rows[l][ld])));
                        }
                    }
                    else
                    {
                        break;
                    }
                }
            }
            dttemp = newTable.Clone();
            for (int i = 0; i < newTable.Rows.Count - 2; i++)
            {
                DataRow drNew = dttemp.NewRow();
                drNew.ItemArray = newTable.Rows[i].ItemArray;
                dttemp.Rows.Add(drNew);
            }

            if (dttemp.Rows.Count > 0)
            {
                DataRow dr = dttemp.NewRow();
                dttemp.Rows.Add();
                dttemp.Rows.Add();
                RN = 4;
                CN = 1;
                gplr = 1;
                gpler = 2;
                dttemp.Rows[RN][0] = "Gross Profit / Loss ";
                for (int i = 0; i <= newTable.Columns.Count - 1; i++)
                {
                    if (CN < newTable.Columns.Count)
                    {
                        if (Convert.ToDouble(newTable.Rows[2][gpler].ToString()) > Convert.ToDouble(newTable.Rows[1][gplr].ToString()))
                        {
                            dttemp.Rows[RN][CN] = Math.Abs(Convert.ToDouble(newTable.Rows[2][gpler].ToString()) - Convert.ToDouble(newTable.Rows[1][gplr].ToString()));
                            gplr = gplr + 2;
                            gpler = gpler + 2;
                            CN = CN + 2;
                        }
                        else
                        {
                            CN = CN + 1;
                            dttemp.Rows[RN][CN] = Math.Abs(Convert.ToDouble(newTable.Rows[2][gpler].ToString()) - Convert.ToDouble(newTable.Rows[1][gplr].ToString()));
                            gplr = gplr + 2;
                            gpler = gpler + 2;
                            CN = CN + 1;
                        }
                    }
                }
                dttemp.Rows.Add();

                dttemp.Rows[RN + 1][0] = "Total";
                RN = dttemp.Rows.Count - 1;
                CN = 1;
                gplr = 1;
                gpler = 2;
                for (int i = 0; i <= newTable.Columns.Count - 1; i++)
                {
                    if (CN < newTable.Columns.Count)
                    {
                        if (Convert.ToDouble(newTable.Rows[2][gpler].ToString()) > Convert.ToDouble(newTable.Rows[1][gplr].ToString()))
                        {
                            dttemp.Rows[RN][CN] = Math.Abs(Convert.ToDouble(newTable.Rows[1][gplr].ToString()) + Convert.ToDouble(dttemp.Rows[4][gplr].ToString()));
                            gplr = gplr + 2;
                            gpler = gpler + 2;
                            CN = CN + 2;
                        }
                        else
                        {
                            CN = CN + 1;
                            dttemp.Rows[RN][CN] = Math.Abs(Convert.ToDouble(newTable.Rows[2][gpler].ToString()) + Convert.ToDouble(dttemp.Rows[4][gpler].ToString()));
                            gplr = gplr + 2;
                            gpler = gpler + 2;
                            CN = CN + 1;
                        }
                    }
                }
                dttemp.Rows.Add();
                dttemp.Rows[RN + 1][0] = "Gross Profit / Loss ";
                RN = 6;
                CN = 1;
                gplr = 1;
                gpler = 2;
                for (int i = 0; i <= newTable.Columns.Count - 1; i++)
                {
                    if (CN < newTable.Columns.Count)
                    {
                        if (Convert.ToDouble(newTable.Rows[2][gpler].ToString()) > Convert.ToDouble(newTable.Rows[1][gplr].ToString()))
                        {
                            CN = CN + 1;
                            dttemp.Rows[RN][CN] = Math.Abs(Convert.ToDouble(newTable.Rows[2][gpler].ToString()) - Convert.ToDouble(newTable.Rows[1][gplr].ToString()));
                            gplr = gplr + 2;
                            gpler = gpler + 2;
                            CN = CN + 1;

                        }
                        else
                        {
                            dttemp.Rows[RN][CN] = Math.Abs(Convert.ToDouble(newTable.Rows[2][gpler].ToString()) - Convert.ToDouble(newTable.Rows[1][gplr].ToString()));
                            gplr = gplr + 2;
                            gpler = gpler + 2;
                            CN = CN + 2;
                        }
                    }
                }
                dttemp.Rows.Add();
                RN = dttemp.Rows.Count - 1;
                CN = 1;
                for (int k = 0; k <= dttemp.Columns.Count - 1; k++)
                {
                    if (CN != dttemp.Columns.Count)
                    {
                        dttemp.Rows[RN][CN] = "INDIRECT EXPENSES";

                        CN = CN + 1;
                        dttemp.Rows[RN][CN] = "INDIRECT INCOME";

                        CN = CN + 1;
                    }
                }
            }
            for (int i = 3; i < newTable.Rows.Count; i++)
            {
                DataRow drNew = dttemp.NewRow();
                drNew.ItemArray = newTable.Rows[i].ItemArray;
                dttemp.Rows.Add(drNew);
            }
            if (dttemp.Rows.Count > 0)
            {
                RN = 11;
                CN = 1;
                gplr = 1;
                gpler = 2;
                dttemp.Rows.Add();
                dttemp.Rows.Add();
                dttemp.Rows[RN][0] = "Net Profit / Loss ";
                for (int i = 0; i <= newTable.Columns.Count - 1; i++)
                {
                    if (CN < newTable.Columns.Count)
                    {
                        if (Convert.ToDouble(newTable.Rows[4][gpler].ToString()) > Convert.ToDouble(newTable.Rows[3][gplr].ToString()))
                        {

                            tgpl = Convert.ToDouble(newTable.Rows[4][gpler].ToString()) - Convert.ToDouble(newTable.Rows[3][gplr].ToString());

                            dttemp.Rows[RN][CN] = Math.Abs(tgpl + Convert.ToDouble(newTable.Rows[2][gpler].ToString()) - Convert.ToDouble(newTable.Rows[1][gplr].ToString()));
                            //dttemp.Rows[RN][CN] = tgpl;
                            gplr = gplr + 2;
                            gpler = gpler + 2;
                            CN = CN + 2;
                        }
                        else
                        {
                            CN = CN + 1;

                            tgpl = Convert.ToDouble(newTable.Rows[4][gpler].ToString()) - Convert.ToDouble(newTable.Rows[3][gplr].ToString());

                            dttemp.Rows[RN][CN] = Math.Abs(tgpl + Convert.ToDouble(newTable.Rows[2][gpler].ToString()) - Convert.ToDouble(newTable.Rows[1][gplr].ToString()));
                            //dttemp.Rows[RN][CN] = tgpl;
                            gplr = gplr + 2;
                            gpler = gpler + 2;
                            CN = CN + 1;


                        }
                    }
                }
                dttemp.Rows.Add();
                dttemp.Rows[RN + 1][0] = "Total";
                RN = 12;
                CN = 1;
                gplr = 1;
                gpler = 2;
                for (int i = 0; i <= newTable.Columns.Count - 1; i++)
                {
                    if (CN < newTable.Columns.Count)
                    {
                        if (Convert.ToDouble(newTable.Rows[4][gpler].ToString()) > Convert.ToDouble(newTable.Rows[3][gplr].ToString()))
                        {
                            tgpl = Convert.ToDouble(newTable.Rows[4][gpler].ToString()) - Convert.ToDouble(newTable.Rows[3][gplr].ToString());

                            tgpl = tgpl + Convert.ToDouble(newTable.Rows[2][gpler].ToString()) - Convert.ToDouble(newTable.Rows[1][gplr].ToString());
                            dttemp.Rows[RN][CN] = Math.Abs(Convert.ToDouble(newTable.Rows[3][gplr].ToString()) + tgpl);
                            gplr = gplr + 2;
                            gpler = gpler + 2;
                            CN = CN + 2;
                        }
                        else
                        {


                            tgpl = Convert.ToDouble(newTable.Rows[4][gpler].ToString()) - Convert.ToDouble(newTable.Rows[3][gplr].ToString());

                            tgpl = tgpl + Convert.ToDouble(newTable.Rows[2][gpler].ToString()) - Convert.ToDouble(newTable.Rows[1][gplr].ToString());

                            CN = CN + 1;
                            dttemp.Rows[RN][CN] = Math.Abs(Convert.ToDouble(newTable.Rows[4][gpler].ToString()) + tgpl);
                            gplr = gplr + 2;
                            gpler = gpler + 2;
                            CN = CN + 1;

                        }
                    }
                }
            }
            GridView11.DataSource = dttemp;
            GridView11.DataBind();
        }

        protected void GridView11_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.Cells[0].Text = " ";
            }
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
               
               
                if (e.Row.Cells[0].Text == "DIRECT EXPENSES")
                {
                    e.Row.Cells[0].Text = "";
                }
                else if (e.Row.Cells[0].Text == "DIRECT INCOME")
                {
                    e.Row.Cells[0].Text = "";
                }
                else if (e.Row.Cells[0].Text == "INDIRECT EXPENSES")
                {
                    e.Row.Cells[0].Text = "";
                }
                else if (e.Row.Cells[0].Text == "INDIRECT INCOME")
                {
                    e.Row.Cells[0].Text = "";
                }
                for (int i = 0; i < e.Row.Cells.Count; i++)
                {
                    if (e.Row.Cells[i].Text == "&nbsp;")
                    {
                        e.Row.Cells[i].Text = "";
                    }
                   
                    e.Row.Cells[i].ToolTip = e.Row.Cells[i].Text;
                }
                for (int h = 1; h < e.Row.Cells.Count; h++)
                {
                    double dbl_temp = 0;

                    if (double.TryParse(e.Row.Cells[h].Text.ToString(), out dbl_temp))
                    {
                        e.Row.Cells[h].Attributes.CssStyle["text-align"] = "Right";
                        e.Row.Cells[h].Text = string.Format("{0:#,##0.00}", dbl_temp);
                    }
                }
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(GridView1, "Select$" + e.Row.RowIndex);
                e.Row.Attributes["style"] = "cursor:pointer";
            }
        }
    }
}
