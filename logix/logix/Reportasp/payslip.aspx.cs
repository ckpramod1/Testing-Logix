using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace logix.Reportasp
{
    public partial class payslip : System.Web.UI.Page
    {
        DataAccess.HR.Employee hreobj = new DataAccess.HR.Employee();
        DataTable dt = new DataTable();
        DataAccess.LogDetails logobj = new DataAccess.LogDetails();
        protected void Page_Load(object sender, EventArgs e)
        {

            string Ccode = Convert.ToString(Session["Ccode"]);

            if (Ccode != "")
            {

                hreobj.GetDataBase(Ccode);
                logobj.GetDataBase(Ccode);
               
            }

            if (Session["LoginUserName"] == null || Session["LoginEmpId"] == null || Session["LoginDivisionId"] == null || Session["LoginBranchid"] == null)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alertify.alert('Session TimeOut');window.open('"+ Session["Site"].ToString() + "/','_top');", true);
            }


            if (Request.QueryString.ToString().Contains("fromyear"))
            {
                string fromyear = Request.QueryString["fromyear"].ToString();
                string toyear = Request.QueryString["toyear"].ToString();
                string fromonth = Request.QueryString["fromonth"].ToString();
                string tomonth = Request.QueryString["tomonth"].ToString();
              

                dt = hreobj.sp_hrpayslip(Convert.ToInt32(Session["LoginDivisionId"]), Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(fromyear), Convert.ToInt32(toyear), Convert.ToInt32(fromonth), Convert.ToInt32(tomonth));
                if (dt.Rows.Count > 0)
                {   
                    for (int i = 0; i <= dt.Rows.Count - 1; i++)
                    {

                        lbl_title.Text = "";
                        lbl_name.Text = "";
                        lbl_emp.Text = "";
                        lbl_grade.Text = "";
                        lbl_desgination.Text = "";

                        lbl_doj.Text = "";
                        lbl_pan.Text = "";
                        lbl_location.Text = "";
                        lbl_department.Text = "";
                        lbl_bankname.Text = "";
                        lbl_bankAC.Text = "";

                        lbl_basic.Text = "";
                        lbl_hra.Text = "";
                        lbl_conveyance.Text = "";
                        lbl_S_Allowances.Text = "";
                        lbl_other.Text = "";
                        lbl_basicarrear.Text = "";
                        lbl_OtherArrears.Text = "";
                        lbl_Medical.Text = "";
                        lbl_PF.Text = "";
                        lbl_esi.Text = "";
                        lbl_it.Text = "";
                        lbl_professional.Text = "";

                        lbl_lwf.Text = "";
                        lbl_loan.Text = "";
                        lbl_othering.Text = "";
                        lbl_total_earing.Text = "";
                        lbl_noofworkingday.Text = "";
                        lbl_lopdays.Text = "";
                        lbl_total_earing.Text = "";
                        lbl_totaldeduction.Text = "";
                        lbl_netsalary.Text = "";
                        if (dt.Rows[i]["paymonth"].ToString()=="1")
                        {
                            lbl_month.Text = "January" + fromyear;
                            

                        }
                        if (dt.Rows[i]["paymonth"].ToString() == "2")
                        {
                            lbl_month.Text = "February" + fromyear;
                        }
                        if (dt.Rows[i]["paymonth"].ToString() == "3")
                        {
                            lbl_month.Text = "March" + fromyear;
                        }
                        if (dt.Rows[i]["paymonth"].ToString() == "4")
                        {
                            lbl_month.Text = "April" + fromyear;
                        }
                        if (dt.Rows[i]["paymonth"].ToString() == "5")
                        {
                            lbl_month.Text = "May" + fromyear;
                        }
                        if (dt.Rows[i]["paymonth"].ToString() == "6")
                        {
                            lbl_month.Text = "June" + fromyear;
                        }
                        if (dt.Rows[i]["paymonth"].ToString() == "7")
                        {
                            lbl_month.Text = "July" + fromyear;
                        }
                        if (dt.Rows[i]["paymonth"].ToString() == "8")
                        {
                            lbl_month.Text = "August" + fromyear;
                        }
                        if (dt.Rows[i]["paymonth"].ToString() == "9")
                        {
                            lbl_month.Text = "September" + fromyear;
                        }
                        if (dt.Rows[i]["paymonth"].ToString() == "10")
                        {
                            lbl_month.Text = "October" + fromyear;
                        }
                        if (dt.Rows[i]["paymonth"].ToString() == "11")
                        {
                            lbl_month.Text = "November" + fromyear;
                        }
                        if (dt.Rows[i]["paymonth"].ToString() == "12")
                        {
                            lbl_month.Text = "December" + fromyear;
                        }
                        lbl_title.Text = dt.Rows[i]["divisionname"].ToString();
                        lbl_name.Text = dt.Rows[i]["empname"].ToString();
                        lbl_emp.Text = dt.Rows[i]["employeeid"].ToString();
                        lbl_grade.Text = dt.Rows[i]["grade"].ToString();
                        lbl_desgination.Text = dt.Rows[i]["designame"].ToString();
                        DateTime lbl_dojing = Convert.ToDateTime(dt.Rows[i]["doj"]);
                        lbl_doj.Text = lbl_dojing.ToShortDateString();
                        lbl_pan.Text = dt.Rows[i]["panno"].ToString();
                        lbl_location.Text = dt.Rows[i]["portname"].ToString();
                        lbl_department.Text = dt.Rows[i]["deptname"].ToString();
                        lbl_bankname.Text = dt.Rows[i]["bankname"].ToString();
                        lbl_bankAC.Text = dt.Rows[i]["accountno"].ToString();

                        if(dt.Rows[i]["basic"].ToString()!="")
                        {
                            lbl_basic.Text = Convert.ToDouble(dt.Rows[i]["basic"]).ToString("#,0.00") + "";
                        }
                        else
                        {
                            lbl_basic.Text = "0.00"; 
                        }
                        if (dt.Rows[i]["hra"].ToString() != "")
                        {
                            lbl_hra.Text = Convert.ToDouble(dt.Rows[i]["hra"]).ToString("#,0.00") + "";
                        }
                        else
                        {
                            lbl_hra.Text = "0.00";
                        }

                        if (dt.Rows[i]["conv"].ToString() != "")
                        {
                             lbl_conveyance.Text = Convert.ToDouble(dt.Rows[i]["conv"]).ToString("#,0.00") + "";
                        }
                        else
                        {
                            lbl_conveyance.Text = "0.00";
                        }
                        if(dt.Rows[i]["spallow"].ToString()!="")
                        {
                           lbl_S_Allowances.Text = Convert.ToDouble(dt.Rows[i]["spallow"]).ToString("#,0.00") + "";
                        }
                        else
                        {
                            lbl_S_Allowances.Text = "0.00";
                        }
                        if( dt.Rows[i]["otherearn"].ToString()!="")
                        {
                           lbl_other.Text = Convert.ToDouble(dt.Rows[i]["otherearn"]).ToString("#,0.00") + "";
                        }
                        else
                        {
                            lbl_other.Text = "0.00";
                        }
                        if (dt.Rows[i]["basicarr"].ToString() != "")
                        {
                            lbl_basicarrear.Text = Convert.ToDouble(dt.Rows[i]["basicarr"]).ToString("#,0.00") + "";
                        }
                        else
                        {
                            lbl_basicarrear.Text = "0.00";
                        }
                        if(dt.Rows[i]["otherarr"].ToString()!="")
                        {
                            lbl_OtherArrears.Text = Convert.ToDouble(dt.Rows[i]["otherarr"]).ToString("#,0.00") + "";
                        }
                        else
                        {
                            lbl_OtherArrears.Text = "0.00";
                        }
                        if(dt.Rows[i]["medical"].ToString()!="")
                        {
                            lbl_Medical.Text = Convert.ToDouble(dt.Rows[i]["medical"]).ToString("#,0.00") + "";
                        }
                        else
                        {
                            lbl_Medical.Text = "0.00";
                        }
                       
                        if(dt.Rows[i]["pf"].ToString()!="")
                        {
                            lbl_PF.Text = Convert.ToDouble(dt.Rows[i]["pf"]).ToString("#,0.00") + "";
                        }
                        else
                        {
                            lbl_PF.Text = "0.00";
                        }
                        if(dt.Rows[i]["esi"].ToString()!="")
                        {
                            lbl_esi.Text = Convert.ToDouble(dt.Rows[i]["esi"]).ToString("#,0.00") + "";
                        }
                        else
                        {
                            lbl_esi.Text = "0.00";
                        }
                        if(dt.Rows[i]["itax"].ToString()!="")
                        {
                            lbl_it.Text = Convert.ToDouble(dt.Rows[i]["itax"]).ToString("#,0.00") + "";
                        }
                        else
                        {
                            lbl_it.Text = "0.00";
                        }
                        if (dt.Rows[i]["amount"].ToString() == "")
                        {
                            lbl_professional.Text = "0.00";
                            
                        }
                        else
                        {
                          
                            lbl_professional.Text = Convert.ToDouble(dt.Rows[i]["amount"]).ToString("#,0.00") + "";
                        }
                        if(dt.Rows[i]["LWF"].ToString()!="")
                        {
                             lbl_lwf.Text = Convert.ToDouble(dt.Rows[i]["LWF"]).ToString("#,0.00") + "";
                        }
                        else
                        {
                            lbl_lwf.Text = "0.00";
                        }

                        if (dt.Rows[i]["loan"].ToString() != "")
                        {
                            lbl_loan.Text = Convert.ToDouble(dt.Rows[i]["loan"]).ToString("#,0.00") + "";
                        }
                        else
                        {
                            lbl_loan.Text = "0.00";
                        }
                        if (dt.Rows[i]["otherarr"].ToString() != "")
                        {
                            lbl_othering.Text = Convert.ToDouble(dt.Rows[i]["otherarr"]).ToString("#,0.00") + "";
                        }
                        else
                        {
                            lbl_othering.Text = "0.00";
                        }

                        if (dt.Rows[i]["esi"].ToString() != "")
                        {
                            lbl_total_earing.Text = Convert.ToDouble(dt.Rows[i]["esi"]).ToString("#,0.00") + "";
                        }
                        else
                        {
                            lbl_total_earing.Text = "0.00";
                        }
                        if (dt.Rows[i]["workdays"].ToString() != "")
                        {
                            lbl_noofworkingday.Text = Convert.ToDouble(dt.Rows[i]["workdays"]).ToString("#,0.00") + "";
                        }
                        else
                        {
                            lbl_noofworkingday.Text = "0.00";
                        }

                        if (dt.Rows[i]["lopdays"].ToString() != "")
                        {
                            lbl_lopdays.Text = Convert.ToDouble(dt.Rows[i]["lopdays"]).ToString("#,0.00") + "";
                        }
                        else
                        {
                            lbl_lopdays.Text = "0.00";
                        }
                     
                        Double total_earing;

                        total_earing = Convert.ToDouble(lbl_basic.Text) + Convert.ToDouble(lbl_hra.Text) + Convert.ToDouble(lbl_conveyance.Text) + Convert.ToDouble(lbl_S_Allowances.Text) + Convert.ToDouble(lbl_other.Text) + Convert.ToDouble(lbl_basicarrear.Text) + Convert.ToDouble(lbl_OtherArrears.Text) + Convert.ToDouble(lbl_Medical.Text);
                        lbl_total_earing.Text = total_earing.ToString();
                        Double total_deduction = Convert.ToDouble(lbl_PF.Text) + Convert.ToDouble(lbl_esi.Text) + Convert.ToDouble(lbl_it.Text) + Convert.ToDouble(lbl_professional.Text) + Convert.ToDouble(lbl_lwf.Text) + Convert.ToDouble(lbl_loan.Text) + Convert.ToDouble(lbl_othering.Text);
                        lbl_totaldeduction.Text = total_deduction.ToString();
                        Double lbl_netsalarying = Convert.ToDouble(lbl_total_earing.Text) - Convert.ToDouble(lbl_totaldeduction.Text);
                        lbl_netsalary.Text = lbl_netsalarying.ToString();
                        lbl_img.ImageUrl = "../images/mr_Logo.jpg";
                        if (!DBNull.Value.Equals(dt.Rows[i]["empphoto"]))
                        {
                            DataTable obj_dtimg = new DataTable();
                            DataRow dr;
                            dr = obj_dtimg.NewRow();
                            obj_dtimg.Columns.Add("image", Type.GetType("System.Byte[]"));
                            Byte[] empimage = (byte[])(dt.Rows[i]["empphoto"]);
                            dr["image"] = empimage;
                            obj_dtimg.Rows.Add(dr);
                            Session["dt"] = obj_dtimg;
                            string base64String = Convert.ToBase64String(empimage);
                            img_emp.ImageUrl = "data:image/png;base64," + base64String;
                            //Img_Emp.ImageUrl = "../imgEmp.aspx";
                        }
                       
                      
                       // div1.Controls.Add(new LiteralControl("<iframe src='../Reportasp/payslip.aspx></iframe>"));
                       // form1.Controls.Add(new LiteralControl("<iframe src='../Reportasp/payslip.aspx?employeeid=" + dt.Rows[i]["employeeid"] + "&toyear=" + dt.Rows[i]["payyear"] + "&tomonth=" + dt.Rows[i]["paymonth"] + "'></iframe>"));
                        
                    }
                    

                  // ?employeeid=" + dt.Rows[i]["employeeid"] + "&toyear=" + dt.Rows[i]["payyear"] + "&tomonth=" + dt.Rows[i]["paymonth"] + "'

                }
               
               
            }

           
        }

    }
}
        
        
       
