using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace logix
{
    public class MasterAll
    {
        public string strScript = "";
        public enum MasterType
        {
            Port,
            Vessel,
            Charges,
            Cargo,
            Event,
            Bank,
            Packages,
            Currency,
            Employee,
            EmployeeID,
            PortCountry
        }

        public enum MasterCustomerType
        {
            AllCustomerLoc,
            ShipperLoc,
            ConsigneeLoc,
            NotifyPartyLoc,
            Agent_PrincipalLoc,
            CHA_CNFLoc,
            Carrier_Airliner_MLO_Freight_ForwarderLoc,
            TransporterLoc,
            CounterPartLoc,
            CFSLoc,
            WarehouseLoc,

            AllCustomerID,
            ShipperID,
            ConsigneeID,
            NotifyPartyID,
            Agent_PrincipalID,
            CHA_CNFID,
            Carrier_Airliner_MLO_Freight_ForwarderID,
            TransporterID,
            CounterPartID,
            CFSID,
            WarehouseID
        }
        public MasterAll()
        {
        }
        public MasterAll(ImageButton imgBtn, TextBox txtBox, MasterType mtype)
        {
            //strScript="var mywin=window.open('LikeMasterPort.aspx?type="+mtype+"&txt1="+ txtBox.ID +"&txt2=&txt3=','CustomerSelectionWindow','fullscreen=yes,menubar=0,resizable=0,width=650,height=330,scrollbars=1');mywin.moveTo(200,150);return false;";
            strScript = "var mywin=window.open('LikeMasterPort.aspx?type=" + mtype + "&txt1=" + txtBox.ID + "&txt2=&txt3=','CustomerSelectionWindow','menubar=0,resizable=0,width=650,height=330,scrollbars=1');return false;";
            imgBtn.Attributes.Add("OnClick", strScript);
            txtBox.Attributes.Add("OnKeyDown", "return false;");
        }
        public MasterAll(ImageButton imgBtn, TextBox txtBox, TextBox txtBoxLoc, MasterType mtype)
        {
            strScript = "var mywin=window.open('LikeMasterPort.aspx?type=" + mtype + "&txt1=" + txtBox.ID + "&txt2=" + txtBoxLoc.ID + "&txt3=','CustomerSelectionWindow','menubar=0,resizable=0,width=650,height=330,scrollbars=1');mywin.moveTo(200,150);return false;";
            imgBtn.Attributes.Add("OnClick", strScript);
            //txtBox.Attributes.Add("OnKeyDown", "return false;");
        }
        //public MasterAll(ImageButton imgBtn, TextBox txtBox,TextBox txtBoxLoc,MasterCustomerType mtype,Page p)
        //{
        //    strScript = "<script type=text/javascript> function Master(){var mywin=window.open('LikeMasterPort.aspx?type=" + mtype + "&txt1="+ txtBox.ID +"&txt2="+txtBoxLoc.ID+"&txt3=','CustomerSelectionWindow','menubar=0,resizable=0,width=650,height=330,scrollbars=1');mywin.moveTo(200,150);return false;}</script>";
        //    p.RegisterClientScriptBlock("ScriptMaster", strScript);
        //    imgBtn.Attributes.Add("OnClick", "return Master();");
        //    txtBox.Attributes.Add("OnKeyDown", "return false;");
        //    txtBoxLoc.Attributes.Add("OnKeyDown", "return false;");
        //}

        public MasterAll(ImageButton imgBtn, TextBox txtBox, TextBox txtBoxLoc, MasterCustomerType mtype)
        {
            strScript = "var mywin=window.open('LikeMasterPort.aspx?type=" + mtype + "&txt1=" + txtBox.ID + "&txt2=" + txtBoxLoc.ID + "&txt3=','CustomerSelectionWindow','menubar=0,resizable=0,width=650,height=330,scrollbars=1');mywin.moveTo(200,150);return false;";
            imgBtn.Attributes.Add("OnClick", strScript);
            txtBox.Attributes.Add("OnKeyDown", "return false;");
            txtBoxLoc.Attributes.Add("OnKeyDown", "return false;");
        }
        public MasterAll(ImageButton imgBtn, TextBox txtBox, TextBox txtBoxLoc, TextBox txtAddr, MasterCustomerType mtype)
        {
            strScript = "var mywin=window.open('LikeMasterPort.aspx?type=" + mtype + "&txt1=" + txtBox.ID + "&txt2=" + txtBoxLoc.ID + "&txt3=" + txtAddr.ID + "','CustomerSelectionWindow','menubar=0,resizable=0,width=650,height=330,scrollbars=1');mywin.moveTo(200,150);return false;";
            imgBtn.Attributes.Add("OnClick", strScript);
            txtBox.Attributes.Add("OnKeyDown", "return false;");
            txtBoxLoc.Attributes.Add("OnKeyDown", "return false;");
        }
    }
}