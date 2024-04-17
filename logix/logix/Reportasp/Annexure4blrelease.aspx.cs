using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace logix.Reportasp
{
    public partial class Annexure4blrelease : System.Web.UI.Page
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
                     
                    Blno = Request.QueryString["Blno"];
                    Bid = Convert.ToInt32(Request.QueryString["Bid"]);
                    Cid = Convert.ToInt32(Request.QueryString["Cid"]);
                    AnnuxureType = Request.QueryString["Type"];
                    DataTable Dt = objRpt.GetBLDetails4Rpt(Blno, Bid, Cid);
                    if (Dt.Rows.Count > 0)
                    {
                        lblBlno.Text = Blno;

                        //lblMarksandnumbers.Text = Dt.Rows[0]["Marks"].ToString();
                        //lblContainerno.Text = Dt.Rows[0]["cntrdetails"].ToString();
                        lblDescription.Text = Dt.Rows[0]["descannex"].ToString();
                        Div_H_Desc.Visible = true;
                        DivDesc.Visible = true;
                        //if (AnnuxureType == "MCD")
                        //{
                        //    Div_H_Marks.Visible = true;
                        //    Div_H_Containerno.Visible = true;
                        //    Div_H_Desc.Visible = true;
                        //    DivMarks.Visible = true;
                        //    DivContainerno.Visible = true;
                        //    DivDesc.Visible = true;
                        //}
                        //else if (AnnuxureType == "MC")
                        //{
                        //    Div_H_Marks.Visible = true;
                        //    Div_H_Containerno.Visible = true;
                        //    DivMarks.Visible = true;
                        //    DivContainerno.Visible = true;
                        //    //DivDesc.Visible = true;
                        //}
                        //else if (AnnuxureType == "MD")
                        //{
                        //    Div_H_Marks.Visible = true;
                        //    Div_H_Desc.Visible = true;
                        //    DivMarks.Visible = true;
                        //    DivDesc.Visible = true;
                        //}
                        //else if (AnnuxureType == "CD")
                        //{
                        //    Div_H_Containerno.Visible = true;
                        //    Div_H_Desc.Visible = true;
                        //    DivContainerno.Visible = true;
                        //    DivDesc.Visible = true;
                        //}

                        //else if (AnnuxureType == "C")
                        //{
                        //    Div_H_Containerno.Visible = true;
                        //    DivContainerno.Visible = true;
                        //}
                        //else if (AnnuxureType == "M")
                        //{
                        //    Div_H_Marks.Visible = true;
                        //    DivMarks.Visible = true;
                        //}
                        //else if (AnnuxureType == "D")
                        //{
                        //    Div_H_Desc.Visible = true;
                        //    DivDesc.Visible = true;
                        //}
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