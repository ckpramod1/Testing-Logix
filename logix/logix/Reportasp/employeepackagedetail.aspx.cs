using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace logix.Reportasp
{
    public partial class employeepackagedetail : System.Web.UI.Page
    {
        DataAccess.HR.Employee empobj = new DataAccess.HR.Employee();
        DataAccess.LogDetails logobj = new DataAccess.LogDetails();
        DataTable dt = new DataTable();
        DataTable dt1 = new DataTable();
        DataTable dt2 = new DataTable();
        DataTable dt3 = new DataTable();
        DataTable dt4 = new DataTable();
        string empid;
        string empcode;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString.ToString().Contains("Str_Empid"))
            {
                //lbl_img.ImageUrl = "../images/mr_Logo.jpg";

                string Ccode = Convert.ToString(Session["Ccode"]);

                if (Ccode != "")
                {

                    logobj.GetDataBase(Ccode);
                    empobj.GetDataBase(Ccode);
                   

                }

                empid = Request.QueryString["Str_Empid"].ToString();
                empcode = Request.QueryString["Empcode"].ToString();
                DateTime joudate = logobj.GetDate();
                lbl_date.Text = joudate.ToShortDateString();
                dt = empobj.sp_hrmpackages(empcode);
                if (dt.Rows.Count > 0)
                {
                    lbl_empcode.Text = dt.Rows[0]["empcode"].ToString();
                    lbl_empname.Text = dt.Rows[0]["empname"].ToString();
                    lbl_division.Text = dt.Rows[0]["divisionname"].ToString();
                    lbl_branch.Text = dt.Rows[0]["portname"].ToString();
                    lbl_dob.Text = Convert.ToDateTime(dt.Rows[0]["dob"]).ToShortDateString();
                    lbl_doj.Text = Convert.ToDateTime(dt.Rows[0]["doj"]).ToShortDateString();
                    lbl_doc.Text = Convert.ToDateTime(dt.Rows[0]["doc"]).ToShortDateString();
                    lbl_dept.Text = dt.Rows[0]["deptname"].ToString();
                    lbl_desgination.Text = dt.Rows[0]["designame"].ToString();


                }
                dt1 = empobj.sp_HRMSalaryPackages(Convert.ToInt32(Session["LoginEmpId"]));
                DataTable dts = new DataTable();
                dts.Columns.Add("sfrom");
                dts.Columns.Add("sto");
                dts.Columns.Add("basic");
                dts.Columns.Add("hra");
                dts.Columns.Add("sallowence");
                dts.Columns.Add("lallowence");
                dts.Columns.Add("conveyance");
                dts.Columns.Add("others");
                dts.Columns.Add("total");
                DataRow dr;
                if (dt1.Rows.Count > 0)
                {

                    for (int j = 0; j <= dt1.Rows.Count - 1; j++)
                    {
                        dr = dts.NewRow();
                        dts.Rows.Add();
                        dts.Rows[j]["sfrom"] = dt1.Rows[j]["sfrom"].ToString();
                        dts.Rows[j]["sto"] = dt1.Rows[j]["sto"].ToString();
                        dts.Rows[j]["basic"] = dt1.Rows[j]["basic"].ToString();
                        dts.Rows[j]["hra"] = dt1.Rows[j]["hra"].ToString();
                        dts.Rows[j]["sallowence"] = dt1.Rows[j]["sallowence"].ToString();
                        dts.Rows[j]["lallowence"] = dt1.Rows[j]["lallowence"].ToString();
                        dts.Rows[j]["conveyance"] = dt1.Rows[j]["conveyance"].ToString();
                        dts.Rows[j]["others"] = dt1.Rows[j]["others"].ToString();
                        Double total = Convert.ToDouble(dt1.Rows[j]["basic"]) + Convert.ToDouble(dt1.Rows[j]["hra"]) + Convert.ToDouble(dt1.Rows[j]["sallowence"]) + Convert.ToDouble(dt1.Rows[j]["lallowence"]) + Convert.ToDouble(dt1.Rows[j]["conveyance"]) + Convert.ToDouble(dt1.Rows[j]["others"]);
                        dts.Rows[j]["total"] = total.ToString();

                    }
                    if (dts.Rows.Count > 0)
                    {
                        for (int i = 0; i <= dts.Rows.Count - 1; i++)
                        {
                            tr_row1.Text += "<tr style='background-color:#d0d0d0; border-bottom:1px solid #b1b1b1;'>";
                            tr_row1.Text += "<td style='color:#2c2b2b; font-size:14px; padding:5px 2px 5px 2px;  border-right:1px solid #b1b1b1;'>" + Convert.ToDateTime(dts.Rows[i]["sfrom"]).ToShortDateString() + "</td>";
                            tr_row1.Text += "<td style='color:#2c2b2b; font-size:14px; padding:5px 2px 5px 2px;  border-right:1px solid #b1b1b1;'>" + Convert.ToDateTime(dts.Rows[i]["sto"]).ToShortDateString() + "</td>";
                            tr_row1.Text += "<td style='color:#2c2b2b; text-align:right; font-size:14px; padding:5px 2px 5px 2px;  border-right:1px solid #b1b1b1;'>" + Convert.ToDouble(dts.Rows[i]["basic"]).ToString("#,0.00") + "</td>";
                            tr_row1.Text += "<td style='color:#2c2b2b; text-align:left; font-size:14px; padding:5px 2px 5px 2px;  border-right:1px solid #b1b1b1;'>" + Convert.ToDouble(dts.Rows[i]["hra"]).ToString("#,0.00") + "</td>";
                            tr_row1.Text += "<td style='color:#2c2b2b; text-align:left; font-size:14px; padding:5px 2px 5px 2px;  border-right:1px solid #b1b1b1;'>" + Convert.ToDouble(dts.Rows[i]["sallowence"]).ToString("#,0.00") + "</td>";
                            tr_row1.Text += "<td style='color:#2c2b2b; text-align:left; font-size:14px; padding:5px 2px 5px 2px;  border-right:1px solid #b1b1b1;'>" + Convert.ToDouble(dts.Rows[i]["lallowence"]).ToString("#,0.00") + "</td>";
                            tr_row1.Text += "<td style='color:#2c2b2b; text-align:left; font-size:14px; padding:5px 2px 5px 2px;  border-right:1px solid #b1b1b1;'>" + Convert.ToDouble(dts.Rows[i]["conveyance"]).ToString("#,0.00") + "</td>";
                            tr_row1.Text += "<td style='color:#2c2b2b; text-align:left; font-size:14px; padding:5px 2px 5px 2px;  border-right:1px solid #b1b1b1;'>" + Convert.ToDouble(dts.Rows[i]["others"]).ToString("#,0.00") + "</td>";
                            tr_row1.Text += "<td style='color:#2c2b2b; text-align:left; font-size:14px; padding:5px 2px 5px 2px;  border-right:1px solid #b1b1b1;'>" + Convert.ToDouble(dts.Rows[i]["total"]).ToString("#,0.00") + "</td>";
                            tr_row1.Text += "</tr>";

                        }
                    }
                }
                dt2 = empobj.sp_compensation(Convert.ToInt32(empid));
                DataTable dts2 = new DataTable();
                dts2.Columns.Add("acfrom");
                dts2.Columns.Add("acto");
                dts2.Columns.Add("lta");
                dts2.Columns.Add("medical");
                dts2.Columns.Add("bonus");
                dts2.Columns.Add("loyalty");
                dts2.Columns.Add("others");
                dts2.Columns.Add("total");
                DataRow dr1;
                if (dt2.Rows.Count > 0)
                {
                    for (int c = 0; c <= dt2.Rows.Count - 1; c++)
                    {
                        dr1 = dts2.NewRow();
                        dts2.Rows.Add();
                        dts2.Rows[c]["acfrom"] = dt2.Rows[c]["acfrom"].ToString();
                        dts2.Rows[c]["acto"] = dt2.Rows[c]["acto"].ToString();
                        dts2.Rows[c]["lta"] = dt2.Rows[c]["lta"].ToString();
                        dts2.Rows[c]["medical"] = dt2.Rows[c]["medical"].ToString();
                        dts2.Rows[c]["bonus"] = dt2.Rows[c]["bonus"].ToString();
                        dts2.Rows[c]["loyalty"] = "0.00";
                        dts2.Rows[c]["others"] = dt2.Rows[c]["others"].ToString();
                        Double total = Convert.ToDouble(dt2.Rows[c]["lta"]) + Convert.ToDouble(dt2.Rows[c]["medical"]) + Convert.ToDouble(dt2.Rows[c]["bonus"]) + Convert.ToDouble(dt2.Rows[c]["others"]);
                        dts2.Rows[c]["total"] = total.ToString();

                    }
                    if (dts2.Rows.Count > 0)
                    {
                        for (int d = 0; d<=dts2.Rows.Count - 1; d++)
                        {
                            tr_row2.Text += "<tr style='background-color:#d0d0d0; border-bottom:1px solid #b1b1b1;'>";
                            tr_row2.Text += "<td style='color:#2c2b2b; font-size:14px; padding:5px 2px 5px 2px;  border-right:1px solid #b1b1b1;'>" + Convert.ToDateTime(dts2.Rows[d]["acfrom"]).ToShortDateString() + "</td>";
                            tr_row2.Text += "<td style='color:#2c2b2b; font-size:14px; padding:5px 2px 5px 2px;  border-right:1px solid #b1b1b1;'>" + Convert.ToDateTime(dts2.Rows[d]["acto"]).ToShortDateString() + "</td>";
                            tr_row2.Text += "<td style='color:#2c2b2b; text-align:right; font-size:14px; padding:5px 2px 5px 2px;  border-right:1px solid #b1b1b1;'>" + Convert.ToDouble(dts2.Rows[d]["lta"]).ToString("#,0.00") + "</td>";
                            tr_row2.Text += "<td style='color:#2c2b2b; text-align:left; font-size:14px; padding:5px 2px 5px 2px;  border-right:1px solid #b1b1b1;'>" + Convert.ToDouble(dts2.Rows[d]["medical"]).ToString("#,0.00") + "</td>";
                            tr_row2.Text += "<td style='color:#2c2b2b; text-align:left; font-size:14px; padding:5px 2px 5px 2px;  border-right:1px solid #b1b1b1;'>" + Convert.ToDouble(dts2.Rows[d]["bonus"]).ToString("#,0.00") + "</td>";
                            tr_row2.Text += "<td style='color:#2c2b2b; text-align:left; font-size:14px; padding:5px 2px 5px 2px;  border-right:1px solid #b1b1b1;'>" + Convert.ToDouble(dts2.Rows[d]["loyalty"]).ToString("#,0.00") + "</td>";
                            tr_row2.Text += "<td style='color:#2c2b2b; text-align:left; font-size:14px; padding:5px 2px 5px 2px;  border-right:1px solid #b1b1b1;'>" + Convert.ToDouble(dts2.Rows[d]["others"]).ToString("#,0.00") + "</td>";
                            tr_row2.Text += "<td style='color:#2c2b2b; text-align:left; font-size:14px; padding:5px 2px 5px 2px;  border-right:1px solid #b1b1b1;'>" + Convert.ToDouble(dts2.Rows[d]["total"]).ToString("#,0.00") + "</td>";
                            tr_row2.Text += "</tr>";
                        }
                    }
                }
                dt3 = empobj.sp_allowances(Convert.ToInt32(empid));
                DataTable dts3 = new DataTable();
                dts3.Columns.Add("afrom");
                dts3.Columns.Add("ato");
                dts3.Columns.Add("petrol");
                dts3.Columns.Add("mobile");
                dts3.Columns.Add("phoner");
                dts3.Columns.Add("datacard");
                dts3.Columns.Add("others");
                dts3.Columns.Add("total");
                DataRow dr2;
                if (dt3.Rows.Count > 0)
                {
                    for (int c = 0; c <= dt3.Rows.Count - 1; c++)
                    {
                        dr1 = dts3.NewRow();
                        dts3.Rows.Add();
                        dts3.Rows[c]["afrom"] = dt3.Rows[c]["afrom"].ToString();
                        dts3.Rows[c]["ato"] = dt3.Rows[c]["ato"].ToString();
                        dts3.Rows[c]["petrol"] = dt3.Rows[c]["petrol"].ToString();
                        dts3.Rows[c]["mobile"] = dt3.Rows[c]["mobile"].ToString();
                        dts3.Rows[c]["phoner"] = dt3.Rows[c]["phoner"].ToString();
                        dts3.Rows[c]["datacard"] = dt3.Rows[c]["datacard"].ToString();
                        dts3.Rows[c]["others"] = dt3.Rows[c]["others"].ToString();
                        Double total = Convert.ToDouble(dt3.Rows[c]["petrol"]) + Convert.ToDouble(dt3.Rows[c]["mobile"]) + Convert.ToDouble(dt3.Rows[c]["phoner"]) + Convert.ToDouble(dt3.Rows[c]["datacard"]) + Convert.ToDouble(dt3.Rows[c]["others"]);
                        dts3.Rows[c]["total"] = total.ToString();

                    }
                    if (dts3.Rows.Count > 0)
                    {
                        for (int d = 0; d<= dts3.Rows.Count - 1; d++)
                        {
                            tr_row3.Text += "<tr style='background-color:#d0d0d0; border-bottom:1px solid #b1b1b1;'>";
                            tr_row3.Text += "<td style='color:#2c2b2b; font-size:14px; padding:5px 2px 5px 2px;  border-right:1px solid #b1b1b1;'>" + Convert.ToDateTime(dts3.Rows[d]["afrom"]).ToShortDateString() + "</td>";
                            tr_row3.Text += "<td style='color:#2c2b2b; font-size:14px; padding:5px 2px 5px 2px;  border-right:1px solid #b1b1b1;'>" + Convert.ToDateTime(dts3.Rows[d]["ato"]).ToShortDateString() + "</td>";
                            tr_row3.Text += "<td style='color:#2c2b2b; text-align:right; font-size:14px; padding:5px 2px 5px 2px;  border-right:1px solid #b1b1b1;'>" + Convert.ToDouble(dts3.Rows[d]["petrol"]).ToString("#,0.00") + "</td>";
                            tr_row3.Text += "<td style='color:#2c2b2b; text-align:left; font-size:14px; padding:5px 2px 5px 2px;  border-right:1px solid #b1b1b1;'>" + Convert.ToDouble(dts3.Rows[d]["mobile"]).ToString("#,0.00") + "</td>";
                            tr_row3.Text += "<td style='color:#2c2b2b; text-align:left; font-size:14px; padding:5px 2px 5px 2px;  border-right:1px solid #b1b1b1;'>" + Convert.ToDouble(dts3.Rows[d]["phoner"]).ToString("#,0.00") + "</td>";
                            tr_row3.Text += "<td style='color:#2c2b2b; text-align:left; font-size:14px; padding:5px 2px 5px 2px;  border-right:1px solid #b1b1b1;'>" + Convert.ToDouble(dts3.Rows[d]["datacard"]).ToString("#,0.00") + "</td>";
                            tr_row3.Text += "<td style='color:#2c2b2b; text-align:left; font-size:14px; padding:5px 2px 5px 2px;  border-right:1px solid #b1b1b1;'>" + Convert.ToDouble(dts3.Rows[d]["others"]).ToString("#,0.00") + "</td>";
                            tr_row3.Text += "<td style='color:#2c2b2b; text-align:left; font-size:14px; padding:5px 2px 5px 2px;  border-right:1px solid #b1b1b1;'>" + Convert.ToDouble(dts3.Rows[d]["total"]).ToString("#,0.00") + "</td>";
                            tr_row3.Text += "</tr>";
                        }
                    }
                }
                dt4 = empobj.sp_Contribution(Convert.ToInt32(empid));
                DataTable dts4 = new DataTable();
                dts4.Columns.Add("cfrom");
                dts4.Columns.Add("cto");
                dts4.Columns.Add("pf");
                dts4.Columns.Add("esi");
                dts4.Columns.Add("total");

                 DataRow dr4;
                if (dt4.Rows.Count > 0)
                {
                    for (int c = 0; c <= dt4.Rows.Count - 1; c++)
                    {
                        dr4 = dts4.NewRow();
                        dts4.Rows.Add();
                        dts4.Rows[c]["cfrom"] = dt4.Rows[c]["cfrom"].ToString();
                        dts4.Rows[c]["cto"] = dt4.Rows[c]["cto"].ToString();
                        dts4.Rows[c]["pf"] = dt4.Rows[c]["pf"].ToString();
                        dts4.Rows[c]["esi"] = dt4.Rows[c]["esi"].ToString();
                        Double total = Convert.ToDouble(dt4.Rows[c]["pf"]) + Convert.ToDouble(dt4.Rows[c]["esi"]);
                        dts4.Rows[c]["total"] = total.ToString();

                    }
                    if (dts4.Rows.Count > 0)
                    {
                        for (int d = 0; d<=dts4.Rows.Count - 1; d++)
                        {
                            tr_row4.Text += "<tr style='background-color:#d0d0d0; border-bottom:1px solid #b1b1b1;'>";
                            tr_row4.Text += "<td style='color:#2c2b2b; font-size:14px; padding:5px 2px 5px 2px;  border-right:1px solid #b1b1b1;'>" + Convert.ToDateTime(dts4.Rows[d]["cfrom"]).ToShortDateString() + "</td>";
                            tr_row4.Text += "<td style='color:#2c2b2b; font-size:14px; padding:5px 2px 5px 2px;  border-right:1px solid #b1b1b1;'>" + Convert.ToDateTime(dts4.Rows[d]["cto"]).ToShortDateString() + "</td>";
                            tr_row4.Text += "<td style='color:#2c2b2b; text-align:right; font-size:14px; padding:5px 2px 5px 2px;  border-right:1px solid #b1b1b1;'>" + Convert.ToDouble(dts4.Rows[d]["pf"]).ToString("#,0.00") + "</td>";
                            tr_row4.Text += "<td style='color:#2c2b2b; text-align:left; font-size:14px; padding:5px 2px 5px 2px;  border-right:1px solid #b1b1b1;'>" + Convert.ToDouble(dts4.Rows[d]["esi"]).ToString("#,0.00") + "</td>";
                            tr_row4.Text += "<td style='color:#2c2b2b; text-align:left; font-size:14px; padding:5px 2px 5px 2px;  border-right:1px solid #b1b1b1;'>" + Convert.ToDouble(dts4.Rows[d]["total"]).ToString("#,0.00") + "</td>";
                            tr_row4.Text += "</tr>";

                        }
                    }

                }
            }
        }
    }
}