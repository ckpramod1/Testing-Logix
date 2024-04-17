using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace logix.Reportasp
{
    public partial class AnnexureDesc : System.Web.UI.Page
    {
        DataAccess.Reportasp objRpt = new DataAccess.Reportasp();
        int Bid, Cid;
        string Blno = "", AnnuxureType = "",Markes="",Container="",Desc="";
        protected void Page_Load(object sender, EventArgs e)
        {
            string Ccode = Convert.ToString(Session["Ccode"]);

            if (Ccode != "")
            {

                objRpt.GetDataBase(Ccode);




            }

            try
            {
                if (Request.QueryString.ToString().Contains("Blno"))
                {

                    //if (Session["LoginDivisionId"].ToString() == "1")
                    //{
                    //    lbl_img.ImageUrl = "../images/wiz_report.jpg";
                    //}
                    //else if (Session["LoginDivisionId"].ToString() == "10")
                    //{
                    //    lbl_img.ImageUrl = "../images/wiz_report.jpg";

                    //}
                    //else if (Session["LoginDivisionId"].ToString() == "11")
                    //{
                    //    lbl_img.ImageUrl = "../images/magik.png";
                    //}
                    //else if (Session["LoginDivisionId"].ToString() == "12")
                    //{
                    //    lbl_img.ImageUrl = "../images/radar.jpg";
                    //}
                    //else if (Session["LoginDivisionId"].ToString() == "13")
                    //{
                    //    lbl_img.ImageUrl = "../images/radar.jpg";
                    //}



                    Blno = Request.QueryString["Blno"];
                    Bid = Convert.ToInt32(Request.QueryString["Bid"]);
                    Cid = Convert.ToInt32(Request.QueryString["Cid"]);
                    AnnuxureType = Request.QueryString["Type"];
                    DataTable Dt = objRpt.GetBLDetails4Rpt(Blno, Bid, Cid);
                    if (Dt.Rows.Count > 0)
                    {
                        lblBlno.Text = Blno;

                        lblMarksandnumbers.Text = Dt.Rows[0]["Marks"].ToString();
                        lblContainerno.Text = Dt.Rows[0]["cntrdetails"].ToString();
                        //if (Request.QueryString["descannex"]=="Y")
                        //{
                        //    
                        //}
                        //else
                        //{
                        //    lblDescription.Text = Dt.Rows[0]["descn"].ToString();
                        //}
                        lblDescription.Text = Dt.Rows[0]["descannex"].ToString();
                        if (AnnuxureType == "MCD")
                        {
                            Div_H_Marks.Visible = true;
                            Div_H_Containerno.Visible = true;
                            Div_H_Desc.Visible = true;
                            DivMarks.Visible = true;
                            DivContainerno.Visible = true;
                            DivDesc.Visible = true;
                        }
                        else if (AnnuxureType == "MC")
                        {
                            Div_H_Marks.Visible = true;
                            Div_H_Containerno.Visible = true;
                            DivMarks.Visible = true;
                            DivContainerno.Visible = true;
                            //DivDesc.Visible = true;
                        }
                        else if (AnnuxureType == "MD")
                        {
                            Div_H_Marks.Visible = true;
                            Div_H_Desc.Visible = true;
                            DivMarks.Visible = true;
                            DivDesc.Visible = true;
                        }
                        else if (AnnuxureType == "CD")
                        {
                            Div_H_Containerno.Visible = true;
                            Div_H_Desc.Visible = true;
                            DivContainerno.Visible = true;
                            DivDesc.Visible = true;
                        }

                        else if (AnnuxureType == "C")
                        {
                            Div_H_Containerno.Visible = true;
                            DivContainerno.Visible = true;
                        }
                        else if (AnnuxureType == "M")
                        {
                            Div_H_Marks.Visible = true;
                            DivMarks.Visible = true;
                        }
                        else if (AnnuxureType == "D")
                        {
                           // lblDescription.Text = Dt.Rows[0]["descannex"].ToString();
                            Div_H_Desc.Visible = true;
                            DivDesc.Visible = true;
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString().Replace("'", "");
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }
    }
}