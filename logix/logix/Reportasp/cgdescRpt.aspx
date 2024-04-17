<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="cgdescRpt.aspx.cs" Inherits="logix.Reportasp.cgdescRpt" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <style>
        .details thead th{
    font-size:14px;
    font-family:sans-serif;
}
.details tbody td{
    font-size:14px;
    font-family:sans-serif;
} 
.details thead th:nth-child(1){
    padding:0 !important;
    width: 3%;
    height: 50px;
    border-bottom: 1px solid #000;
    
    border-right: 1px solid #000;
}
.details thead th:nth-child(2) {
    padding:0 !important;
    width: 5%;
    height: 50px;
    border-bottom: 1px solid #000;
    border-right: 1px solid #000;
}
.details thead th:nth-child(3) {
    padding:0 !important;
    width: 7%;
    height: 50px;
    border-bottom: 1px solid #000;
    border-right: 1px solid #000;
}
.details thead th:nth-child(4) {
    padding:0 !important;
    width: 13%;
    height: 50px;
    border-bottom: 1px solid #000;
    border-right: 1px solid #000;
}
.details thead th:nth-child(5) {
    padding:0 !important;
    width: 13%;
    height: 50px;
    border-bottom: 1px solid #000;
    border-right: 1px solid #000;
}
.details thead th:nth-child(6) {
    padding:0 !important;
    width: 15%;
    height: 50px;
    border-bottom: 1px solid #000;
    border-right: 1px solid #000;
}
.details thead th:nth-child(7) {
    padding:0 !important;
    width: 7%;
    height: 50px;
    border-bottom: 1px solid #000;
    border-right: 1px solid #000;
}
.details thead th:nth-child(8) {
    padding:0 !important;
    width: 7%;
    height: 50px;
    border-bottom: 1px solid #000;
    border-right: 1px solid #000;
}
.details thead th:nth-child(9) {
    padding:0 !important;
    width: 8%;
    height: 50px;
    border-bottom: 1px solid #000;
    border-right: 1px solid #000;
}
.details thead th:nth-child(10) {
    padding:0 !important;
    width: 6%;
    height: 50px;
    border-bottom: 1px solid #000;
    border-right: 1px solid #000; 
}
.details thead th:nth-child(11) {
    padding:0 !important;
    width: 5%;
    height: 50px;
    border-bottom: 1px solid #000;
    border-right: 1px solid #000;
}
.details thead th:nth-child(12) {
    padding:0 !important;
    width: 6%;
    height: 50px;
    border-bottom: 1px solid #000;
    border-right: 1px solid #000;
}
.details thead th:nth-child(13) {
    padding:0 !important;
    width: 20%;
    height: 50px;
    border-bottom: 1px solid #000;
    
}
table {
    border-collapse: collapse;
}
.details tbody tr td:nth-child(1)  {
    padding:0px 0px 0px 5px !important;
    width: 3%;
    height: auto;
    border-bottom: 1px solid #000;
    
    border-right: 1px solid #000;
}
.details tbody tr td:nth-child(2) {
    padding:0px 0px 0px 5px !important;
    width: 5%;
    height: auto;
    border-bottom: 1px solid #000;
    border-right: 1px solid #000;
}
.details tbody tr td:nth-child(3) {
    padding:0px 0px 0px 5px !important;
    width: 7%;
    height: auto;
    border-bottom: 1px solid #000;
    border-right: 1px solid #000;
}
.details tbody tr td:nth-child(4) {
    padding:0px 0px 0px 5px !important;
    width: 13%;
    height: auto;
    border-bottom: 1px solid #000;
    border-right: 1px solid #000;
    
    padding-right:5px !important;
}
.details tbody tr td:nth-child(5) {
    padding:0px 0px 0px 5px !important;
    width: 13%;
    height: auto;
    border-bottom: 1px solid #000;
    border-right: 1px solid #000;
    padding-right:5px !important;
}
.details tbody tr td:nth-child(6) {
    padding:0px 0px 0px 5px !important;
    width: 15%;
    height: auto;
    border-bottom: 1px solid #000;
    border-right: 1px solid #000;
}
.details tbody tr td:nth-child(7) {
    padding:0px 0px 0px 5px !important;
    width: 7%;
    height: auto;
    border-bottom: 1px solid #000;
    border-right: 1px solid #000;
}
.details tbody tr td:nth-child(8) {
    padding:0px 0px 0px 5px !important;
    width: 7%;
    height: auto;
    border-bottom: 1px solid #000;
    border-right: 1px solid #000;
}
.details tbody tr td:nth-child(9) {
    padding:0px 0px 0px 5px !important;
    width: 8%;
    height: auto;
    border-bottom: 1px solid #000;
    border-right: 1px solid #000;
}
.details tbody tr td:nth-child(10) {
    padding:0px 0px 0px 5px !important;
    width: 6%;
    height: auto;
    border-bottom: 1px solid #000;
    border-right: 1px solid #000;
}
.details tbody tr td:nth-child(11) {
    padding:0px 0px 0px 5px !important;
    width: 5%;
    height: auto;
    border-bottom: 1px solid #000;
    border-right: 1px solid #000;
}
.details tbody tr td:nth-child(12) {
    padding:0px 0px 0px 5px !important;
    width: 6%;
    height: auto;
    border-bottom: 1px solid #000;
    border-right: 1px solid #000;
}
.details tbody tr td:nth-child(13) {
    padding:0px 0px 0px 5px !important;
    width: 12%;
    height: auto;
    border-bottom: 1px solid #000;
    
}
</style>
</head>
<body>
    <div style="width:1024px;margin: 0 auto;">
    <div style="width: 100%; margin: 0px auto;border:1px solid #000;float: left;border-bottom: none;">
        <div style="float: left;width:100%;">
            <div style="float:left; width:150px; margin: 9px 10px 5px 15px;display:none;">
           <asp:Image  ID="lbl_img" runat="server" Width="80" Height="89" />
                </div>
           <div style="float:left; margin: 7px 0px 4px 9px;width:100%;">
               <h3 style="font-family: Segoe UI; font-size: 21px; font-weight: bold; color: #000; text-align: center; padding: 0px 0px 10px 0px; margin: 0px 0px 0px 22px;">
                   <asp:Label  runat="server">ANNEXURE - III</asp:Label></h3>
                       
               <div style="text-align: center; color: #000;font-weight: bold;">
                   <asp:Label ID="lbl_add" runat="server">PART - II CARGO DECLARATION</asp:Label><br />
                </div>
                <div style="text-align: center; color: #000;font-weight: bold;">
                   CONSOLE AGENT NAME :
                   <asp:Label ID="lbl_branch" runat="server" style="font-weight:bold !important;"></asp:Label>
                  <asp:Label ID="lbl_fax" runat="server" style="font-weight:normal !important;display: none;">faxno</asp:Label>
               </div>
               <div id="div_cnopshead" runat="server" style="font-weight: bold;display:none;">
                   Service Tax # :
                   <asp:Label ID="lbl_staxhead" runat="server" style="font-weight:normal !important;">servicetaxno</asp:Label>
                   PAN # :
                   <asp:Label ID="lbl_panno" runat="server" style="font-weight:normal !important;">panno</asp:Label>
               </div>

           </div>
</div>

        <div style="float:left;width:100%;border-bottom: 1px solid #000;min-height:100px;border-top: 1px solid #000;">
        <div style="float:left;width:60%;">
            <div style="width:13%;float:left;padding: 7px 0px 5px 10px;font-weight: bold;font-size: 14px; color: #000;font-family: sans-serif;">
                <label id="label_carnno" style="color: #000000;" runat="server">CARN NO :</label>
           </div>
           <div style="width:84%;float:left;padding: 7px 0px 5px 3px;font-size: 14px; color: #000;font-family: sans-serif;">
               <asp:Label ID="lbl_carnnoline" runat="server"></asp:Label>
           </div>
           <div style="width:11%;float:left;padding: 7px 0px 5px 10px;font-weight: bold;font-size: 14px; color: #000;font-family: sans-serif;">
            <label id="label_igmno" style="color: #000000;" runat="server">IGM NO :</label>
       </div>
       <div style="width:86%;float:left;padding: 7px 0px 5px 3px;font-size: 14px; color: #000;font-family: sans-serif;">
           <asp:Label ID="lbl_ourigmno" runat="server"></asp:Label>
       </div>
       <div style="width:28%;float:left;padding: 7px 0px 5px 10px;font-weight: bold;font-size: 14px; color: #000;font-family: sans-serif;">
        <label id="label_shipline" style="color: #000000;" runat="server">SHIPPING LINE & CODE :</label>
   </div>
   <div style="width:69%;float:left;padding: 7px 0px 5px 3px;font-size: 14px; color: #000;font-family: sans-serif;">
       <asp:Label ID="lbl_shipcusname" runat="server"></asp:Label>
   </div>
   <div style="width:11%;float:left;padding: 7px 0px 5px 10px;font-weight: bold;font-size: 14px; color: #000;font-family: sans-serif;">
    <label id="label_lineno" style="color: #000000;" runat="server">LINE NO :</label>
</div>
<div style="width:86%;float:left;padding: 7px 0px 5px 3px;font-size: 14px; color: #000;font-family: sans-serif;">
   <asp:Label ID="lbl_ourlineno" runat="server"></asp:Label>
</div>
   <div style="float:left;padding: 7px 0px 5px 10px;font-size: 14px; color: #000;font-family: sans-serif;width:100%;">
   <div style="width:14%;float:left;padding: 7px 0px 5px 3px;font-weight: bold;font-size: 14px; color: #000;font-family: sans-serif;">
    <label id="label_imo" style="color: #000000;" runat="server">IMO CODE :</label>
</div>
<div style="width:36%;float:left;padding: 7px 0px 5px 3px;font-size: 14px; color: #000;font-family: sans-serif;">
   <asp:Label ID="lbl_imocode" runat="server"></asp:Label>
</div>
<div style="width:10%;float:left;padding: 7px 0px 5px 10px;font-weight: bold;font-size: 14px; color: #000;font-family: sans-serif;">
    <label id="label_tpno" style="color: #000000;" runat="server">T.P.N.O :</label>
</div>
<div style="width:35%;float:left;padding: 7px 0px 5px 3px;font-size: 14px; color: #000;font-family: sans-serif;">
   <asp:Label ID="lbl_tpnoline" runat="server"></asp:Label>
</div>
</div>


        </div>
        <div style="float:left;width:40%;">
            <div style="width:27%;float:left;padding: 7px 0px 5px 10px;font-weight: bold;font-size: 14px; color: #000;font-family: sans-serif;">
                <label id="label_vesselcode" style="color: #000000;" runat="server">VESSEL CODE :</label>
           </div>
           <div style="width:69%;float:left;padding: 7px 0px 5px 3px;font-size: 14px; color: #000;font-family: sans-serif;">
               <asp:Label ID="lbl_ourvesselc" runat="server"></asp:Label>
           </div>
            <div style="clear:both"></div> 
           <div style="width:16%;float:left;padding: 7px 0px 5px 10px;font-weight: bold;font-size: 14px; color: #000;font-family: sans-serif;">
            <label id="label_vessel" style="color: #000000;" runat="server">VESSEL :</label>
           </div>
       <div style="width:80%;float:left;padding: 7px 0px 5px 3px;font-size: 14px; color: #000;font-family: sans-serif;">
           <asp:Label ID="lbl_ourvessel" runat="server"></asp:Label>
       </div>
            <div style="clear:both"></div> 

       
        </div>
        
</div> 
        
        <div class="table">
           
            <table class="details">
                <thead>
                    <tr>
                        <th>Sub Line NO</th>
                        <th>B/L NO</th>
                        <th>B/L Date</th>
                        <th>Port of Loading</th>
                        <th>Final Destination</th>
                        <th>Consignee Name & Address</th>
                        <th>Item Type</th>
                        <th>Cargo Movement</th>
                        <th>No of PKgs & Types</th>
                        <th>Gr.Wt</th>
                        <th>Volume</th>
                        <th>Marks & No</th>
                        <th>Description of the Goods</th>
                    </tr>
                </thead>
                <tbody>
                    <asp:Label ID="lbl_tr" runat="server"></asp:Label>
                    
    </tbody>
    </table>
    
    </div>
    </div>
    </div>
</body>
</html>
